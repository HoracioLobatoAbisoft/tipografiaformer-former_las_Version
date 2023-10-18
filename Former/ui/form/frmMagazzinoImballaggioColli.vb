Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface

Friend Class frmMagazzinoImballaggioColli
    'Inherits baseFormInternaRedim

    'Public formSopra As cFormSopra
    Private _Ris As Integer = 0
    Private _IdCons As Integer = 0
    Private _IdRub As Integer = 0

    Friend Function Carica(IdCons As Integer) As Integer
        _IdCons = IdCons
        Dim C As New ConsegnaProgrammata
        C.Read(IdCons)
        _IdRub = C.IdRub

        Dim R As New VoceRubrica
        R.Read(C.IdRub)

        Dim CC As New Corriere
        CC.Read(C.IdCorr)

        lblTit.Text = "Imballaggio Colli - " & R.RagSoc & ", " & CC.Descrizione

        CaricaOrdini()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click

        If DgLavori.Rows.Count Then
            If MessageBox.Show("Confermi l'imballaggio dei colli inseriti?", "Consegna colli", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim okAll As Boolean = True
                For Each dr As DataGridViewRow In DgLavori.Rows
                    If dr.Cells(3).Value <> dr.Cells(4).Value Then
                        If dr.Cells(3).Value <> 0 Then okAll = False
                    End If
                Next

                If okAll = False Then
                    MessageBox.Show("E' obbligatorio passare con il lettore codice a barre tutti i colli previsti di ogni ordine iniziato")
                Else

                    Dim CheckAllOrd As Boolean = True
                    For Each dr As DataGridViewRow In DgLavori.Rows
                        If dr.Cells(3).Value <> dr.Cells(4).Value Then
                            If dr.Cells(3).Value = 0 Then CheckAllOrd = False
                        End If
                    Next
                    Dim CheckOk As Boolean = True
                    If CheckAllOrd = False Then
                        If MessageBox.Show("ATTENZIONE! Non tutti gli ordini della consegna sono stati imballati. Si vuole forzare la chiusura della consegna? In tale caso gli ordini non imballati saranno sganciati e dovranno essere riprogrammati per la consegna", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            'sgancio gli ordini non imballati 
                            Using mC As New ConsegneProgrammateDAO
                                For Each dr As DataGridViewRow In DgLavori.Rows
                                    If dr.Cells(3).Value <> dr.Cells(4).Value Then
                                        Dim IdOrd As Integer = dr.Cells(0).Value
                                        'CHIEDI
                                        Dim DataNuova As Date = Now.Date

                                        Dim c As New ConsegnaProgrammata
                                        c.Read(_IdCons)
                                        DataNuova = MgrDataConsegna.GetPrimaDataDisponibile(DataNuova, c.IdCorr)

                                        'TOLTO IL 08/04/2015
                                        'mC.EliminaOrdineDaConsegna(_IdCons, IdOrd)
                                        mC.RegistraConsegnaOrdineSuGiorno(IdOrd, c.IdCorr, DataNuova, c.IdRub, enMomentoConsegna.Pomeriggio, c.IdIndirizzo)

                                        'QUI INSERISCO UN MESSAGGIO PER TUTTI GLI ADMIN IN CUI AVVERTO DEL CAMBIAMENTO
                                        Dim lu As List(Of Utente) = Nothing
                                        Using mgr As New UtentiDAO
                                            lu = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Utente.Tipo, CInt(enTipoUtente.Admin)))
                                        End Using
                                        For Each u As Utente In lu
                                            Dim m As New Messaggio
                                            m.DataIns = Now
                                            m.Titolo = "Cambiamento consegna programmata ordine " & IdOrd
                                            m.Testo = "E' stata forzata la chiusura di una consegna programmata escludendo l'ordine " & IdOrd & ". La consegna di tale ordine va riprogrammata."
                                            m.IdMitt = 0
                                            m.IdDest = u.IdUt
                                            m.Save()
                                        Next

                                    End If
                                Next
                            End Using
                        Else
                            CheckOk = False
                        End If
                    End If

                    If CheckOk Then
                        'qui stampo le etichette 
                        Dim NumColliCons As String = InputBox("Inserisci il numero di pacchi reali della consegna", "Stampa etichette", "1")

                        If IsNumeric(NumColliCons) Then
                            Dim PesoCalcolato As Single = 0

                            'CALCOLARE IL PESO DELLA CONSEGNA
                            Using mC As New ConsProgrOrdiniDAO
                                Dim l As List(Of ConsProgrOrdini) = mC.FindAll(New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdCons, _IdCons))

                                For Each co As ConsProgrOrdini In l
                                    Dim singO As New Ordine
                                    singO.Read(co.IdOrd)

                                    Dim p As New Prodotto
                                    p.Read(singO.IdProd)

                                    PesoCalcolato += p.PesoComplessivo
                                Next

                                Dim c As New ConsegnaProgrammata
                                c.Read(_IdCons)
                                c.NumColli = NumColliCons
                                c.Peso = PesoCalcolato 'qui ci va il peso di tutti gli ordini contenuti nelal consegna 
                                c.Save()
                                Dim x As New myPrinter
                                x.PrinterName = PostazioneCorrente.StampanteEtichette
                                x.IdCons = _IdCons
                                Dim t As New System.Threading.Thread(AddressOf x.StampaEtichetteConsegna)
                                t.Start()
                                x = Nothing
                                'If MessageBox.Show("Le etichette sono state stampate correttamente! Vuoi passare gli ordini allo stato successivo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Dim Prossimostato As enStatoOrdine = enStatoOrdine.ProntoRitiro

                                Using OMgr As New OrdiniDAO
                                    OMgr.AvanzaOrdiniAStatoByIdCons(_IdCons, Prossimostato, PostazioneCorrente.UtenteConnesso.IdUt)
                                End Using

                            End Using
                            MessageBox.Show("Etichette del corriere stampate correttamente")
                            Close()
                            'End If

                        End If

                    End If

                End If

            End If

        Else
            MessageBox.Show("Inserire almeno un collo")

        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        CaricaColli()

    End Sub

    Private Sub CaricaColli()

        Dim Ris As String = "GO"
        Dim Messaggio As String = ""
        Dim IdOrdRif As Integer = 0
        Dim IdConsRif As Integer = 0
        Dim MsgSupplement As String = ""
        While Ris.Length

            'Sottofondo()

            Dim x As New frmMagazzinoBarCodeRCTF

            Ris = x.Carica(Messaggio, IdOrdRif, IdConsRif, MsgSupplement)
            Ris = Ris.TrimEnd
            Ris = Ris.TrimStart
            'Sottofondo()

            If Ris.Length = 12 Or Ris.Length = 13 Then
                Ris = Ris.Substring(0, 12)
                'qui si puo trattare di un ordine in consegna tramite corriere o diretto quindi ho i due codici da gestire
                Dim CodiceRifs As String = ""
                Dim CodiceRif As Integer = 0
                Dim NumCollo As Integer = 0
                CodiceRifs = Ris.Substring(0, 7)

                NumCollo = Ris.Substring(7, 4)

                'PACCO ORDINE
                CodiceRif = CInt(CodiceRifs)
                Dim O As New Ordine
                O.Read(CodiceRif)
                If O.IdOrd Then

                    If _IdRub <> O.IdRub Then
                        'MessageBox.Show("Non si possono scaricare da magazzino ordini di clienti diversi")
                        MgrSound.Suona(enTipoSuono.ErroreNoClientiDiversi)
                        MsgSupplement = "Non si possono imballare ordini di clienti diversi"
                    Else
                        Dim SwTrovato As Boolean = False
                        Dim Dr As DataGridViewRow = Nothing
                        For Each drEsist As DataGridViewRow In DgLavori.Rows
                            If drEsist.Cells(1).Value = CodiceRif Then
                                SwTrovato = True
                                Dr = drEsist
                                Exit For
                            End If
                        Next
                        If SwTrovato = False Then
                            'qui lo inserisco 

                            Dr = New DataGridViewRow

                            Dim ImgPreview As Image
                            Dim ImgNew As Image = Nothing
                            Try
                                ImgPreview = Image.FromFile(O.FilePath)
                                ImgNew = New Bitmap(ImgPreview, New Size(50, 75))
                            Catch ex As Exception

                            End Try

                            Dr.CreateCells(DgLavori)

                            Dr.Cells(0).Value = ImgNew
                            Dr.Cells(1).Value = O.IdOrd
                            Dr.Cells(2).Value = O.Prodotto.Descrizione
                            'Dr.Cells(3).Value = O.VoceRubrica.Nominativo
                            Dr.Cells(3).Value = 1
                            Dr.Cells(4).Value = O.NumeroRealeColli
                            Dr.Cells(5).Value = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(O.TotaleImponibile)
                            Dr.Tag = "O," & NumCollo & ","

                            DgLavori.Rows.Add(Dr)

                            MsgSupplement = ""
                        Else
                            'qui in dr ho gia la riga interessata
                            'controllo che il pacco non sia stato gia sparato

                            Dim TrovatoCollo As Integer = DirectCast(Dr.Tag.ToString, String).IndexOf("," & NumCollo & ",")
                            If TrovatoCollo = -1 Then
                                'qui non l'ho trovato
                                Dr.Cells(3).Value = CInt(Dr.Cells(3).Value) + 1
                                Dr.Tag &= NumCollo & ","
                                MsgSupplement = ""
                            Else
                                'MessageBox.Show("Collo gia caricato")
                                MgrSound.Suona(enTipoSuono.ErroreColloGiaCaricato)
                                MsgSupplement = "Collo già caricato"
                            End If

                        End If
                        'qui cmq vada in dr ho la riga relativa a cosa stavo lavorando
                        Dim nCollicaricati As Integer = (DirectCast(Dr.Tag, String).Split(",").Count) - 2
                        If O.NumeroRealeColli <> nCollicaricati Then
                            IdOrdRif = O.IdOrd
                            IdConsRif = 0
                            Messaggio = "Devono ancora essere caricati " & O.NumeroRealeColli - nCollicaricati & " colli"
                        Else
                            IdOrdRif = 0
                            IdConsRif = 0
                            Messaggio = ""
                            MsgSupplement = ""
                            MgrSound.Suona(enTipoSuono.OkGiroCompletato)

                        End If
                    End If
                Else
                    'MessageBox.Show("Codice inserito non valido")
                    MgrSound.Suona(enTipoSuono.ErroreCodiceInseritoNonValido)
                    MsgSupplement = "Codice inserito non valido"

                End If
            Else
                If Ris.Length Then
                    'MessageBox.Show("Codice formalmente non valido")
                    MgrSound.Suona(enTipoSuono.ErroreCodiceInseritoNonValido)
                    MsgSupplement = "Codice inserito non valido"
                End If

            End If
        End While
    End Sub

    Private Sub CaricaOrdini()

        Dim dt As DataTable, riga As DataRow

        Using Ordini As New cOrdiniColl
            Ordini.IdRub = _IdRub
            Dim ListaStati As String = enStatoOrdine.Registrato & "," & _
                               enStatoOrdine.InSospeso & "," & _
                               enStatoOrdine.InCodaDiStampa & "," & _
                               enStatoOrdine.StampaInizio & "," & _
                               enStatoOrdine.StampaFine & "," & _
                               enStatoOrdine.FinituraCommessaInizio & "," & _
                               enStatoOrdine.FinituraCommessaFine & "," & _
                               enStatoOrdine.FinituraProdottoInizio & "," & _
                               enStatoOrdine.FinituraProdottoFine & "," & _
                               enStatoOrdine.Imballaggio & "," & _
                               enStatoOrdine.ImballaggioCorriere '& "," & _
            dt = Ordini.Lista(, ListaStati, , , , , , True, , , , _IdCons)
        End Using

        For Each riga In dt.Rows
            Dim Dr As New DataGridViewRow

            Dim ImgPreview As Image
            Dim ImgNew As Image = Nothing
            Try
                ImgPreview = Image.FromFile(riga("filePath").ToString)
                ImgNew = New Bitmap(ImgPreview, New Size(50, 75))
            Catch ex As Exception
                ImgNew = Nothing
            End Try

            Dr.CreateCells(DgLavori)

            Dr.Cells(0).Value = ImgNew
            Dr.Cells(1).Value = riga("ord")
            Dr.Cells(2).Value = riga("Prodotto")
            'Dr.Cells(3).Value = riga("Cliente")
            Dr.Cells(3).Value = "0"
            Dr.Cells(4).Value = IIf(IsDBNull(riga("NumeroRealeColli")), riga("NumeroPrevistoColli"), riga("NumeroRealeColli"))
            Dr.Cells(5).Value = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(riga("TotaleImp").ToString)
            'Dr.Cells(5).Value = IIf(CInt(riga("preventivo").ToString) = enPreventivoSiNo.Si, "Si", "No")
            Dr.Tag = "O,"
            DgLavori.Rows.Add(Dr)
        Next
        DgLavori.Sort(DgLavori.Columns(4), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub DgLavori_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgLavori.RowPostPaint
        Dim x As DataGridViewRow = DgLavori.Rows.Item(e.RowIndex)

        If x.Cells(3).Value <> x.Cells(4).Value Then
            x.Cells(3).Style.BackColor = Color.Red
            x.Cells(3).Style.SelectionBackColor = Color.Red
        Else
            x.Cells(3).Style.BackColor = Color.Green
            x.Cells(3).Style.SelectionBackColor = Color.Green
        End If

    End Sub

    Private Sub tmrColli_Tick(sender As Object, e As EventArgs) Handles tmrColli.Tick
        tmrColli.Enabled = False
        CaricaColli()

    End Sub

    Private Function Comparer(ByVal x As ConsegnaRicerca, ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = x.Giorno.CompareTo(y.Giorno)
        If result = 0 Then result = x.Inserito.CompareTo(y.Inserito)

        Return result
    End Function

End Class