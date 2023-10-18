Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig

Friend Class frmMagazzinoSoluzioneImballo
    'Inherits baseFormInternaRedim

    Private _Ris As Integer
    Private _IdOrd As Integer = 0
    Private _Ord As Ordine = Nothing

    Private _SoluzioneScelta As SoluzioneImballo = Nothing

    Friend Function Carica(Ord As Ordine) As Integer

        _Ord = Ord
        _IdOrd = Ord.IdOrd

        CaricaConsegnaRelativa()

        Calcola()

        ShowDialog()

        Return _Ris

    End Function

    Private _QtaForzataCubetti As Integer = 0

    Friend Function Carica(IdOrd As Integer,
                           Optional QtaForzataCubetti As Integer = 0) As Integer
        _QtaForzataCubetti = QtaForzataCubetti

        _IdOrd = IdOrd

        _Ord = New Ordine
        _Ord.Read(IdOrd)

        lblTipo.Text = "Imballo Ordine " & IdOrd

        CaricaConsegnaRelativa()

        Calcola()

        If QtaForzataCubetti Then
            btnStampaEtich.Enabled = False
            'btnStampaEtich.Visible = False
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaConsegnaRelativa()

        tvConsegne.Nodes.Clear()

        Using Mgr As New ConsProgrOrdiniDAO

            Dim l As List(Of ConsProgrOrdini) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdCons, _Ord.ConsegnaAssociata.IdCons))

            Dim ChiaveData As String = "D" & _Ord.ConsegnaAssociata.Giorno.ToString("ddMMyyyy")

            Dim NodoData As TreeNode = tvConsegne.Nodes(ChiaveData)
            If NodoData Is Nothing Then
                NodoData = tvConsegne.Nodes.Add(ChiaveData, _Ord.ConsegnaAssociata.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                'NodoCorr.Expand()
            End If

            Dim ChiaveCorriere As String = "C" & _Ord.ConsegnaAssociata.IdCorr

            Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
            If NodoCorr Is Nothing Then
                NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, _Ord.ConsegnaAssociata.Corriere.Descrizione, 6, 6)
                'NodoCorr.Expand()
            End If

            Dim ChiaveRubrica As String = "S" & _Ord.ConsegnaAssociata.IdCons

            Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
            If NodoRub Is Nothing Then
                NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, _Ord.ConsegnaAssociata.Cliente.RagSocNome, 10, 10)
                'NodoRub.Expand()
                'NodoRub.EnsureVisible()
            End If

            For Each o As ConsProgrOrdini In l
                Dim ChiaveOrdine As String = "O" & o.IdOrd
                Dim Icona As Integer = 9

                If o.Inserito Then Icona = 8
                Dim SingO As New Ordine
                SingO.Read(o.IdOrd)

                Dim nodoOrd As TreeNode = NodoRub.Nodes.Add("O" & o.IdOrd, "Ord." & o.IdOrd & " - " & SingO.Prodotto.Descrizione, Icona, Icona)
                nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(SingO.Stato)

                NodoData.Expand()
                NodoCorr.Expand()
                NodoRub.Expand()
            Next

        End Using

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'If Not _SoluzioneScelta Is Nothing Then
        '    _Ris = -1
        'End If
        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub tbProd_Click(sender As Object, e As EventArgs) Handles tbProd.Click

    End Sub

    Private Sub DisegnaSoluzione(s As SoluzioneImballo)

        flowP.Controls.Clear()

        'prima disergno la scatola

        lblVerso.Text = s.NumeroCubetti & " cubetti, " & s.NumeroScatole & " collo/i, Cubetto " & s.Cubetto.Lunghezza & "mm " & s.Cubetto.Larghezza & "mm " & s.Cubetto.Profondita & "mm, Verso: " & s.TipoScatola.VersoCorrettoAppoggio.ToString & " Appoggio: " & s.TipoScatola.LatoCorrettoAppoggio.ToString

        Dim ContScatole As Integer = 0
        Dim CubettiDisegnati As Integer = 0
        For Each scat As ScatolaProposta In s.Scatole

            ContScatole += 1

            If scat.Cubetti.Count <> scat.TipoScatola.MaxCubetti And ContScatole = s.Scatole.Count And s.Scatole.Count <> 1 Then
                'qui la scatola non e' piena e devo vedere se posso cambiarla
                'per cambiarla riparametrizzo solo quello che ci sta in questa scatola 

                Dim QtaScat As Integer = 0

                For Each cub As Cubetto In scat.Cubetti
                    QtaScat += cub.NumeroPezzi
                Next

                Dim sExc As SoluzioneImballo = MgrImballo.CalcolaSoluzione(QtaScat, scat.Cubetti(0))(0)

                If Not sExc.TipoScatola Is scat.TipoScatola Then
                    scat.TipoScatola = sExc.TipoScatola.Clone
                End If

            End If

            Dim bitmap As New Bitmap(800, 800)
            Dim formGraphics As Graphics = Graphics.FromImage(bitmap)

            Dim MargineX As Single = 3
            Dim MargineY As Single = 3

            Dim PartenzaX As Single = bitmap.Width / 3
            Dim PartenzaY As Single = bitmap.Height / 3

            Dim PartScat As Single = bitmap.Width - scat.TipoScatola.Larghezza + 50

            Dim scDis As New ScatolaDisegnata(scat.TipoScatola.Lunghezza, scat.TipoScatola.Larghezza, scat.TipoScatola.Profondita)
            scDis.DrawMe(formGraphics, PartScat, 100)

            Dim Punti() As Point
            Dim ProxPunt As New Point(PartenzaX, PartenzaY)
            Dim PrimoDisegnato() As Point = Nothing

            'tutto questo ha senso in caso di oggetto poggiato sul lato larghezza-lunghezza
            Dim OrigInLarg As Integer = scat.TipoScatola.InLarghezza
            Dim OrigInLung As Integer = scat.TipoScatola.InLunghezza
            Dim OrigInProf As Integer = scat.TipoScatola.InProfondita

            Dim InLung As Integer = OrigInLung
            Dim InLarg As Integer = OrigInLarg
            Dim InProf As Integer = OrigInProf

            Dim CuLarghezza As Single = s.Cubetto.Larghezza
            Dim CuLunghezza As Single = s.Cubetto.Lunghezza
            Dim CuProfondita As Single = s.Cubetto.Profondita

            If scat.TipoScatola.LatoCorrettoAppoggio = enLatoAppoggio.LatoLargLung Then

                If scat.TipoScatola.VersoCorrettoAppoggio = enVersoAppoggio.PerCorto Then
                    CuLarghezza = s.Cubetto.Lunghezza
                    CuLunghezza = s.Cubetto.Larghezza
                    CuProfondita = s.Cubetto.Profondita
                End If

            ElseIf scat.TipoScatola.LatoCorrettoAppoggio = enLatoAppoggio.LatoLargProf Then
                'qui devo invertire i valori facendogli credere che siano diversi
                If scat.TipoScatola.VersoCorrettoAppoggio = enVersoAppoggio.PerLungo Then
                    CuLarghezza = s.Cubetto.Larghezza
                    CuLunghezza = s.Cubetto.Profondita
                    CuProfondita = s.Cubetto.Lunghezza
                ElseIf scat.TipoScatola.VersoCorrettoAppoggio = enVersoAppoggio.PerCorto Then
                    CuLarghezza = s.Cubetto.Profondita
                    CuLunghezza = s.Cubetto.Larghezza
                    CuProfondita = s.Cubetto.Lunghezza
                End If

            ElseIf scat.TipoScatola.LatoCorrettoAppoggio = enLatoAppoggio.LatoLungProf Then
                'qui devo invertire i valori facendogli credere che siano diversi
                If scat.TipoScatola.VersoCorrettoAppoggio = enVersoAppoggio.PerLungo Then
                    CuLarghezza = s.Cubetto.Lunghezza
                    CuLunghezza = s.Cubetto.Profondita
                    CuProfondita = s.Cubetto.Larghezza
                ElseIf scat.TipoScatola.VersoCorrettoAppoggio = enVersoAppoggio.PerCorto Then
                    CuLarghezza = s.Cubetto.Profondita
                    CuLunghezza = s.Cubetto.Lunghezza
                    CuProfondita = s.Cubetto.Larghezza
                End If

            End If

            For k As Integer = 1 To InProf

                For n As Integer = 1 To InLung
                    For i As Integer = 1 To InLarg

                        If CubettiDisegnati < s.NumeroCubetti Then
                            CubettiDisegnati += 1
                            Dim c As New CubettoDisegnato(CuLunghezza, CuLarghezza, CuProfondita)
                            Punti = c.DrawMe(formGraphics, ProxPunt.X, ProxPunt.Y)
                            If PrimoDisegnato Is Nothing Then PrimoDisegnato = Punti
                            'qui devo impostare il prossimo punto a seconda del lato su cui va poggiato 

                            ProxPunt.Y = Punti(0).Y + (Punti(0).Y - Punti(1).Y) + MargineY
                            ProxPunt.X = Punti(0).X - (Punti(1).X - Punti(0).X) - MargineX


                            'If s.TipoScatola.VersoCorrettoAppoggio = enVersoAppoggio.PerCorto Then
                            '    ProxPunt.Y = Punti(3).Y + MargineY
                            '    ProxPunt.X = Punti(3).X + MargineX
                            'Else
                            '    ProxPunt.Y = Punti(0).Y + (Punti(0).Y - Punti(1).Y) + MargineY
                            '    ProxPunt.X = Punti(0).X - (Punti(1).X - Punti(0).X) - MargineX
                            'End If
                        Else
                            Exit For
                        End If

                    Next
                    'qui mi devo spostare alla riga dopo 
                    ProxPunt.X = Punti(0).X - (Punti(1).X - Punti(0).X) - MargineX
                    ProxPunt.Y = Punti(0).Y - (Punti(1).Y - Punti(0).Y) + MargineY

                Next
                'qui devo salire di una riga 
                ProxPunt.X = PartenzaX
                ProxPunt.Y = PartenzaY - ((MargineY + (CuProfondita / 2)) * k)

            Next

            'qui la scatola e' disegnata ora ci metto qualche scritta 
            formGraphics.DrawString(scat.TipoScatola.TipologiaScatolaStr & " " & ContScatole & ControlChars.NewLine & "Oggetti " & scat.Cubetti.Count & ControlChars.NewLine & "Peso: " & scat.Peso, New Font("Segoe UI", 20), New Drawing.SolidBrush(Color.Black), New Point(0, 0))

            Dim PathImg As String = FormerPath.PathTempLocale() & FormerLib.FormerHelper.File.GetNomeFileTemp(".png")
            bitmap.Save(PathImg, Imaging.ImageFormat.Png)

            formGraphics.Dispose()

            Dim img As New PictureBox
            img.Image = Image.FromFile(PathImg)
            img.Width = 400
            img.Height = 400
            img.SizeMode = PictureBoxSizeMode.StretchImage
            img.BorderStyle = BorderStyle.FixedSingle

            flowP.Controls.Add(img)

        Next


    End Sub

    Private Sub Calcola()

        Dim Qta As Integer = _Ord.QtaRif

        'Dim Cubetto As New cCubetto(147, 210, 95, 1250, 4) ' 1250 volantini 'OK
        'Dim Cubetto As New cCubetto(210, 297, 55, 500, 1) ' 500 carta intestata
        'Dim Cubetto As New cCubetto(55, 85, 200, 500, 1) ' 500 carta intestata
        'Dim Cubetto As New cCubetto(190, 210, 95, 500, 1) ' 500 cartoline 'OK
        'Dim Cubetto As New cCubetto(170, 200, 55, 1000, 1) ' 1000 biglietti da visita
        Dim Cubetto As New Cubetto(_Ord.ModelloCubettoScelto.Lunghezza,
                                    _Ord.ModelloCubettoScelto.Larghezza,
                                    _Ord.ModelloCubettoScelto.Profondita,
                                     _Ord.ListinoBase.QtaCollo, 100) ' 1000 riviste separate tra loro

        Dim ListaSoluzioni As List(Of SoluzioneImballo) = MgrImballo.CalcolaSoluzione(Qta, Cubetto, _QtaForzataCubetti)

        _SoluzioneScelta = ListaSoluzioni(0)

        'disegno la soluzione ottimale e riempio l'albero con quelle alternative oltre a lei 
        DisegnaSoluzione(_SoluzioneScelta)

        tvwSoluzioni.Nodes.Clear()

        Dim NodoPart As New TreeNode("Soluzioni")
        NodoPart.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)
        tvwSoluzioni.Nodes.Add(NodoPart)

        Dim Indice As Integer = 0
        For Each sol As SoluzioneImballo In ListaSoluzioni

            Dim N As New TreeNode(sol.NumeroScatole & " " & sol.TipoScatola.TipologiaScatolaStr & " (" & sol.TipoScatola.Lunghezza & "x" & sol.TipoScatola.Larghezza & "x" & sol.TipoScatola.Profondita & ")")
            N.ImageIndex = 0
            N.SelectedImageIndex = 0
            N.Tag = sol
            If Indice = 0 Then
                N.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)
                N.ForeColor = Color.DarkGreen
            End If
            NodoPart.Nodes.Add(N)
            N.EnsureVisible()
            Indice += 1
        Next


    End Sub

    Private Sub tvwSoluzioni_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwSoluzioni.AfterSelect
        Dim Node As TreeNode = e.Node

        If Not Node Is Nothing AndAlso Not Node.Tag Is Nothing Then

            _SoluzioneScelta = DirectCast(Node.Tag, SoluzioneImballo)
            DisegnaSoluzione(_SoluzioneScelta)

        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnStampaEtich_Click(sender As Object, e As EventArgs) Handles btnStampaEtich.Click
        If MessageBox.Show("Confermi la soluzione selezionata?", "Imballo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Ris = _SoluzioneScelta.NumeroScatole
            Close()
        End If

    End Sub
End Class