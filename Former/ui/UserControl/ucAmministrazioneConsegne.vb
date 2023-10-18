Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerDALSql

Public Class ucAmministrazioneConsegne
    Inherits ucFormerUserControl

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

        lblLegRC.BackColor = FormerColori.ColoreCorriereRitiroCliente
        lblLegTF.BackColor = FormerColori.ColoreCorriereTipografiaFormer
        lblLegAC.BackColor = FormerColori.ColoreCorriereAltro
    End Sub

    Private _GiornoSel As Date = Date.MinValue

    Public Sub Carica()

        If _GiornoSel = Date.MinValue Then
            _GiornoSel = Now.Date
            dtPickCons.Value = _GiornoSel
            If PostazioneCorrente.CaricamentiAutomatici Then CaricaDati()
        End If

        'carico l'albero di sinistra e poi quello di destra

    End Sub

    Private Sub CaricaVociPrima()

        Using mgr As New ConsegneRicercaDAO
            Dim Lst As List(Of ConsegnaRicerca) = Nothing
            Dim ListaStati As String = enStatoOrdine.Preinserito & "," & _
                                enStatoOrdine.Registrato & "," & _
                                enStatoOrdine.InSospeso & "," & _
                                enStatoOrdine.InCodaDiStampa & "," & _
                                enStatoOrdine.StampaInizio & "," & _
                                enStatoOrdine.StampaFine & "," & _
                                enStatoOrdine.FinituraCommessaInizio & "," & _
                                enStatoOrdine.FinituraCommessaFine & "," & _
                                enStatoOrdine.FinituraProdottoInizio & "," & _
                                enStatoOrdine.FinituraProdottoFine & "," & _
                                enStatoOrdine.Imballaggio & "," & _
                                enStatoOrdine.ImballaggioCorriere & "," & _
                                enStatoOrdine.ProntoRitiro

            Lst = mgr.Lista(-1, 0, _GiornoSel, , ListaStati, , , , , , , , " r.ragsoc")
            'LstM.Sort(AddressOf Comparer)

            Dim ContCons As Integer = 0
            tvPrima.Nodes.Clear()

            Dim NodoPronte As TreeNode = tvPrima.Nodes.Add("IN CONSEGNA " & _GiornoSel.ToString("dddd dd/MM") & " PRONTE PER LA CONSEGNA --------------------------------------------------------------------------------------------")
            NodoPronte.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)

            Dim NodoNONPronte As TreeNode = tvPrima.Nodes.Add("IN CONSEGNA " & _GiornoSel.ToString("dddd dd/MM") & " NON ANCORA PRONTE -------------------------------------------------------------------------------------------------")
            NodoNONPronte.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)

            For Each c As ConsegnaRicerca In Lst
                '_cnOld Corriere con id
                'Rn Rubrica con Id
                'Pn 
                'cerco se c'e' il nodo del corriere senno lo creo
                'cerco se c'e' il nodo del cliente come figlio senno lo creo
                'creo il nodo per la consegna dell'ordine 
                'in tag metto l'id della consegna programmata
                Dim ChiaveCorriere As String = "C" & c.IdCorr
                'Dim ChiaveRubrica As String = "C" & c.IdCorr & "R" & c.IdRub
                Dim ChiaveRubrica As String = "S" & c.IdCons
                Dim ChiaveIndirizzo As String = "I" & c.IdCons
                Dim ChiaveOrdine As String = "O" & c.IdOrd


                Dim DescrNodoPadre As String = String.Format(Strings.Left(c.RagSoc, 32) & " (Colli: {0}, Peso {1})", IIf(c.NumColli, c.NumColli, "?"), c.Peso)

                'If c.IdCorr = 2 Then
                '    If c.IdOperatore Then
                '        Dim Utente As New Utente
                '        Utente.Read(c.IdOperatore)
                '        DescrNodoPadre &= " (" & Utente.Login & ")"
                '        Utente = Nothing
                '    End If
                'End If
                Dim NodoStart As TreeNode

                If c.ListaOrdini.FindAll(Function(x) x.Stato <> enStatoOrdine.ProntoRitiro).Count Then
                    NodoStart = NodoNONPronte
                Else
                    NodoStart = NodoPronte
                End If

                Dim NodoCorr As TreeNode = NodoStart.Nodes(ChiaveCorriere)
                If NodoCorr Is Nothing Then
                    Dim NomeCorriere As String = c.CorriereNome
                    Dim PosPar As Integer = NomeCorriere.IndexOf("(")

                    If PosPar <> -1 Then

                        NomeCorriere = NomeCorriere.Substring(0, PosPar - 1)

                    End If

                    NodoCorr = NodoStart.Nodes.Add(ChiaveCorriere, NomeCorriere, 3, 3)
                    NodoCorr.BackColor = FormerColori.GetColoreSfondoCorriere(c.IdCorr)
                End If
                'qui ho il nodo del corriere
                Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
                If NodoRub Is Nothing Then
                    NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, DescrNodoPadre, 0, 0)
                    NodoRub.Tag = c.IdCons
                    NodoRub.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)
                    ContCons += 1
                End If
                'qui ho il cliente  e inserisco l'ordine 
                NodoCorr.Expand()
                Dim NodoInd As TreeNode = NodoRub.Nodes(ChiaveIndirizzo)
                If NodoInd Is Nothing Then

                    Dim DescrInd As String = "Indirizzo: " & c.IndirizzoStr

                    NodoInd = NodoRub.Nodes.Add(ChiaveIndirizzo, DescrInd, 6, 6)
                End If

                Dim NodoOrdine As TreeNode
                Dim DescrOrd As String = Strings.Left("Ord. " & c.IdOrd & " - " & c.ProdottoNome, 32)

                If c.Ordine.TipoConsegna = enTipoConsegna.Fast Then
                    NodoRub.ForeColor = Color.Red
                End If

                NodoOrdine = NodoRub.Nodes.Add("O" & c.IdOrd, DescrOrd, 1, 1)
                NodoOrdine.Tag = c
                NodoOrdine.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)

            Next

            NodoPronte.Expand()
            NodoNONPronte.Expand()

            Dim NodoAltrePronte As TreeNode = tvPrima.Nodes.Add("CONSEGNE ANTICIPATE -------------------------------------------------------------------------------------------------")
            NodoAltrePronte.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)

            Dim LstF As List(Of ConsegnaRicerca) = Nothing

            LstF = mgr.Lista(-1, 0, , , enStatoOrdine.ProntoRitiro, , , , , enCorriere.RitiroCliente, , , " r.ragsoc", , Now.Date)

            For Each c As ConsegnaRicerca In LstF
                '_cnOld Corriere con id
                'Rn Rubrica con Id
                'Pn 
                'cerco se c'e' il nodo del corriere senno lo creo
                'cerco se c'e' il nodo del cliente come figlio senno lo creo
                'creo il nodo per la consegna dell'ordine 
                'in tag metto l'id della consegna programmata
                Dim ChiaveCorriere As String = "C" & c.IdCorr
                'Dim ChiaveRubrica As String = "C" & c.IdCorr & "R" & c.IdRub
                Dim ChiaveRubrica As String = "S" & c.IdCons
                Dim ChiaveIndirizzo As String = "I" & c.IdCons
                Dim ChiaveOrdine As String = "O" & c.IdOrd
                Dim DescrNodoPadre As String = String.Format(Strings.Left(c.RagSoc, 32) & " (Colli: {0}, Peso {1})", IIf(c.NumColli, c.NumColli, "?"), c.Peso)
                Dim ChiaveData As String = c.Giorno.ToString("yyyyMMdd")
                'If c.IdCorr = 2 Then
                '    If c.IdOperatore Then
                '        Dim Utente As New Utente
                '        Utente.Read(c.IdOperatore)
                '        DescrNodoPadre &= " (" & Utente.Login & ")"
                '        Utente = Nothing
                '    End If
                'End If
                Dim NodoStart As TreeNode = NodoAltrePronte

                Dim NodoCorr As TreeNode = NodoStart.Nodes(ChiaveCorriere)
                If NodoCorr Is Nothing Then
                    Dim NomeCorriere As String = c.CorriereNome
                    Dim PosPar As Integer = NomeCorriere.IndexOf("(")

                    If PosPar <> -1 Then

                        NomeCorriere = NomeCorriere.Substring(0, PosPar - 1)

                    End If

                    NodoCorr = NodoStart.Nodes.Add(ChiaveCorriere, NomeCorriere, 3, 3)
                    NodoCorr.BackColor = FormerColori.GetColoreSfondoCorriere(c.IdCorr)
                End If

                Dim NodoData As TreeNode = NodoCorr.Nodes(ChiaveData)
                If NodoData Is Nothing Then
                    NodoData = NodoCorr.Nodes.Add(ChiaveData, c.Giorno.ToString("dd/MM/yyyy"), 7, 7)
                    NodoData.Expand()
                End If

                'qui ho il nodo del corriere
                Dim NodoRub As TreeNode = NodoData.Nodes(ChiaveRubrica)
                If NodoRub Is Nothing Then
                    NodoRub = NodoData.Nodes.Add(ChiaveRubrica, DescrNodoPadre, 0, 0)
                    NodoRub.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)
                    NodoRub.Tag = c.IdCons
                    ContCons += 1
                End If
                'qui ho il cliente  e inserisco l'ordine 
                NodoCorr.Expand()
                Dim NodoInd As TreeNode = NodoRub.Nodes(ChiaveIndirizzo)
                If NodoInd Is Nothing Then

                    Dim DescrInd As String = "Indirizzo: " & c.IndirizzoStr

                    NodoInd = NodoRub.Nodes.Add(ChiaveIndirizzo, DescrInd, 6, 6)
                End If

                Dim NodoOrdine As TreeNode
                Dim DescrOrd As String = Strings.Left("Ord. " & c.IdOrd & " - " & c.ProdottoNome, 32)
                NodoOrdine = NodoRub.Nodes.Add("O" & c.IdOrd, DescrOrd, 1, 1)
                NodoOrdine.Tag = c
                NodoOrdine.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)

            Next

            NodoAltrePronte.Expand()
            Lst = Nothing
        End Using
    End Sub

    Private Sub CaricaVociDopo()

        Using mgr As New ConsegneRicercaDAO

            Dim ListaStatiD As String = enStatoOrdine.UscitoMagazzino & "," & _
              enStatoOrdine.InConsegna & "," & _
              enStatoOrdine.Consegnato & "," & _
              enStatoOrdine.PagatoAcconto & "," & _
              enStatoOrdine.PagatoInteramente & ","

            Dim Lst As List(Of ConsegnaRicerca) = Nothing

            'LstD = mgr.Lista(-1, 0, , , ListaStatiD, , , , , , , , " r.ragsoc", _GiornoSel)
            Lst = mgr.ListaConsegneConDocDaEmettere(_GiornoSel)

            Dim ContCons As Integer = 0
            tvDopo.Nodes.Clear()

            Dim NodoDocDaEmettere As TreeNode = tvDopo.Nodes.Add("DOCUMENTI DA EMETTERE --------------------------------------------")
            NodoDocDaEmettere.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)

            Dim NodoDocEmessi As TreeNode = tvDopo.Nodes.Add("DOCUMENTI EMESSI -----------------------------------------------------")
            NodoDocEmessi.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)

            For Each c As ConsegnaRicerca In Lst
                '_cnOld Corriere con id
                'Rn Rubrica con Id
                'Pn 
                'cerco se c'e' il nodo del corriere senno lo creo
                'cerco se c'e' il nodo del cliente come figlio senno lo creo
                'creo il nodo per la consegna dell'ordine 
                'in tag metto l'id della consegna programmata
                Dim ChiaveCorriere As String = "C" & c.IdCorr
                'Dim ChiaveRubrica As String = "C" & c.IdCorr & "R" & c.IdRub
                Dim ChiaveRubrica As String = "S" & c.IdCons
                Dim ChiaveIndirizzo As String = "I" & c.IdCons
                Dim ChiaveOrdine As String = "O" & c.IdOrd
                Dim DescrNodoPadre As String = Strings.Left(c.RagSoc, 32)

                'If c.IdCorr = 2 Then
                '    If c.IdOperatore Then
                '        Dim Utente As New Utente
                '        Utente.Read(c.IdOperatore)
                '        DescrNodoPadre &= " (" & Utente.Login & ")"
                '        Utente = Nothing
                '    End If
                'End If
                Dim DocEmessi As Boolean = True

                If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.UscitoMagazzino).Count Then
                    For Each o As Ordine In c.ListaOrdini
                        If o.IdDoc = 0 Then
                            DocEmessi = False
                            Exit For
                        End If
                    Next
                End If

                Dim NodoStart As TreeNode

                If DocEmessi Then
                    NodoStart = NodoDocEmessi
                Else
                    NodoStart = NodoDocDaEmettere
                End If

                Dim NodoCorr As TreeNode = NodoStart.Nodes(ChiaveCorriere)
                If NodoCorr Is Nothing Then
                    Dim NomeCorriere As String = c.CorriereNome
                    Dim PosPar As Integer = NomeCorriere.IndexOf("(")

                    If PosPar <> -1 Then

                        NomeCorriere = NomeCorriere.Substring(0, PosPar - 1)

                    End If

                    NodoCorr = NodoStart.Nodes.Add(ChiaveCorriere, NomeCorriere, 3, 3)
                    NodoCorr.BackColor = FormerColori.GetColoreSfondoCorriere(c.IdCorr)
                End If
                'qui ho il nodo del corriere
                Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
                If NodoRub Is Nothing Then
                    NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, DescrNodoPadre, 0, 0)
                    NodoRub.NodeFont = New Font("Segoe UI", 9, FontStyle.Bold)
                    NodoRub.Tag = c.IdCons
                    ContCons += 1
                End If
                'qui ho il cliente e inserisco l'ordine 
                NodoCorr.Expand()
                Dim NodoInd As TreeNode = NodoRub.Nodes(ChiaveIndirizzo)
                If NodoInd Is Nothing Then

                    Dim DescrInd As String = "Indirizzo: " & c.IndirizzoStr

                    NodoInd = NodoRub.Nodes.Add(ChiaveIndirizzo, DescrInd, 6, 6)
                End If

                Dim NodoOrdine As TreeNode
                Dim DescrOrd As String = Strings.Left("Ord. " & c.IdOrd & " - " & c.ProdottoNome, 32)

                If c.Ordine.TipoConsegna = enTipoConsegna.Fast Then
                    NodoRub.ForeColor = Color.Red
                End If

                NodoOrdine = NodoRub.Nodes.Add("O" & c.IdOrd, DescrOrd, 1, 1)
                NodoOrdine.Tag = c
                NodoOrdine.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)

            Next
            Lst = Nothing
            tvDopo.Sort()

            NodoDocDaEmettere.Expand()
            NodoDocEmessi.Expand()
        End Using
    End Sub

    Private Sub CaricaDati()

        Cursor = Cursors.WaitCursor

        lblOrdiniUscitiMagaz.Text = "ORDINI USCITI DA MAGAZZINO DEL " & _GiornoSel.ToString("dddd dd MMMM").ToUpper
        lblConsegneDaFare.Text = "CONSEGNE DA FARE DEL " & _GiornoSel.ToString("dddd dd MMMM").ToUpper

        dtPickCons.Value = _GiornoSel

        CaricaVociPrima()

        CaricaVociDopo()

        'CaricaUscitiDaMagazzinoProntoRitiro()

        Cursor = Cursors.Default
    End Sub

    Private Function ComparerConsM(ByVal x As ConsegnaRicerca, ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = x.Cliente.RagSocNome.CompareTo(y.Cliente.RagSocNome)
        If result = 0 Then result = x.Giorno.CompareTo(y.Giorno)

        Return result
    End Function

    Private Sub CaricaUscitiDaMagazzinoProntoRitiro()

        Using mgr As New ConsegneRicercaDAO
            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.UscitoMagazzino & "," & _
                                enStatoOrdine.ProntoRitiro  '& "," & _'& "," & _
            'enStatoOrdine.ProntoRitiro()
            LstM = mgr.Lista(-1, , , , ListaStati, , , , , )
            LstM.Sort(AddressOf ComparerConsM)
            tvwConsegnaMerci.Nodes.Clear()

            For Each c As ConsegnaRicerca In LstM
                Dim ChiaveRubrica As String = "R" & c.IdRub
                Dim NodoRub As TreeNode = tvwConsegnaMerci.Nodes(ChiaveRubrica)
                If NodoRub Is Nothing Then

                    Dim DescrRub As String = c.RagSoc

                    NodoRub = tvwConsegnaMerci.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)
                    'NodoRub.Expand()
                    'NodoRub.EnsureVisible()
                End If

                Dim ChiaveData As String = "S" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                Dim NodoData As TreeNode = NodoRub.Nodes(ChiaveData)
                If NodoData Is Nothing Then
                    NodoData = NodoRub.Nodes.Add(ChiaveData, "Consegna del " & c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                    'NodoCorr.Expand()
                End If

                'Dim DescrInd As String = c.Cliente.IndirizzoPredefinito

                'If c.IdIndirizzo Then
                '    'qui devo calcolare l'indirizzo
                '    Dim I As New Indirizzo
                '    I.Read(c.IdIndirizzo)
                '    DescrInd = I.Riassunto
                '    I = Nothing
                'End If

                'Dim ChiaveInd As String = "I" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                'Dim nodoInd As TreeNode = NodoData.Nodes(ChiaveInd)
                'If nodoInd Is Nothing Then
                '    nodoInd = NodoData.Nodes.Add("I" & c.IdCons, DescrInd, 12, 12)
                'End If

                Dim ChiaveOrdine As String = "O" & c.IdOrd

                Dim Icona As Integer = 1

                Dim nodoOrd As TreeNode = NodoData.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                nodoOrd.Tag = c
                If c.Giorno.Date = Now.Date Then NodoData.Expand()
                NodoData.Expand()
                'NodoRub.Expand()
            Next
        End Using
    End Sub

    Private Sub btnIndietro_Click(sender As Object, e As EventArgs) Handles btnIndietro.Click

        Cursor.Current = Cursors.WaitCursor
        Dim NewGiorno As Date = _GiornoSel.AddDays(-1)
        If NewGiorno.DayOfWeek = DayOfWeek.Sunday Then NewGiorno = NewGiorno.AddDays(-1)
        _GiornoSel = NewGiorno
        CaricaDati()
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnAvanti_Click(sender As Object, e As EventArgs) Handles btnAvanti.Click

        Cursor.Current = Cursors.WaitCursor
        Dim NewGiorno As Date = _GiornoSel.AddDays(1)
        If NewGiorno.DayOfWeek = DayOfWeek.Sunday Then NewGiorno = NewGiorno.AddDays(1)
        _GiornoSel = NewGiorno
        CaricaDati()
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click

        CaricaDati()

    End Sub

    Private TreeviewSel As TreeView = Nothing

    Private Sub GestisciConsegna()
        Dim IdCons As Integer = 0

        If Not TreeviewSel Is Nothing Then
            Dim Node As TreeNode = TreeviewSel.SelectedNode
            If Not Node Is Nothing Then
                If Node.Name.StartsWith("O") Or Node.Name.StartsWith("I") Then
                    IdCons = Node.Parent.Name.Substring(1)
                ElseIf Node.Name.StartsWith("S") Then
                    'qui ho la consegna
                    IdCons = Node.Name.Substring(1)
                End If
            End If

            If IdCons Then

                ParentFormEx.Sottofondo()

                Dim x As New frmConsegnaProgrammata
                Dim Ris As Integer = x.Carica(IdCons)

                If Ris Then CaricaDati()
                x = Nothing

                ParentFormEx.Sottofondo()
            End If
        Else
            MessageBox.Show("Selezionare una consegna dall'albero")
        End If
        'devo recuperare l'id della consegna

    End Sub

    Private Sub ModificaDatiConsegna()

        Dim IdCons As Integer = 0

        If Not TreeviewSel Is Nothing Then
            Dim Node As TreeNode = TreeviewSel.SelectedNode
            If Not Node Is Nothing Then
                If Node.Name.StartsWith("O") Or Node.Name.StartsWith("I") Then
                    IdCons = Node.Parent.Name.Substring(1)
                ElseIf Node.Name.StartsWith("S") Then
                    'qui ho la consegna
                    IdCons = Node.Name.Substring(1)
                End If
            End If

            If IdCons Then
                Dim c As New ConsegnaProgrammata
                Dim risC As RisConsegnaModificabile = c.Diritti.PossoModificareIndirizzoOppureCorriere
                If risC.Esito Then 'c.ModificabileEx(True, True, True, True, True, False).Modificabile Then
                    If MessageBox.Show("Sicuro di voler modificare i dati della consegna (Corriere, Indirizzo e Data)?", "Modifica Consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Dim Ris As Integer = 0

                        ParentFormEx.Sottofondo()
                        Dim x As New frmConsegnaModificaDati
                        Ris = x.Carica(IdCons)
                        x = Nothing
                        ParentFormEx.Sottofondo()

                        If Ris Then
                            CaricaVociPrima()
                        End If
                    End If
                Else
                    MessageBox.Show("Questa consegna non è modificabile:" & risC.BufferErrori)
                End If

            End If
        End If



    End Sub

    Private Sub btnGestCons_Click(sender As Object, e As EventArgs) Handles btnGestCons.Click

        GestisciConsegna()

    End Sub

    Private Sub tvPrima_GotFocus(sender As Object, e As EventArgs) Handles tvPrima.GotFocus, tvDopo.GotFocus

        TreeviewSel = sender

    End Sub

    Private Sub btnEmettiDocMerceSpedire_Click(sender As Object, e As EventArgs) Handles btnEmettiDocMerceSpedire.Click

        GestisciConsegna()

    End Sub

    Private Sub ucAmministrazioneConsegne_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tvPrima_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvPrima.AfterSelect

    End Sub

    Private Sub tvPrima_Move(sender As Object, e As EventArgs) Handles tvPrima.Move

    End Sub

    Private Sub tvPrima_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvPrima.NodeMouseClick, _
                                                                                                   tvDopo.NodeMouseClick
        Dim Node As TreeNode = e.Node
        If Node.Name.StartsWith("O") Then
            Dim IdOrd As Integer = Node.Name.Substring(1)
            Cursor.Current = Cursors.WaitCursor

            Dim x As New Ordine
            x.Read(IdOrd)

            UcOrdineAnteprima.Carica(x)
            'UcOrdineDett.Carica(x)
            x = Nothing
            Cursor.Current = Cursors.Default

        End If
    End Sub

    Private Sub dtPickCons_ValueChanged(sender As Object, e As EventArgs) Handles dtPickCons.ValueChanged
        If sender.focused Then
            _GiornoSel = dtPickCons.Value
            CaricaDati()
        End If

    End Sub

    Private Sub tvwConsegnaMerci_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwConsegnaMerci.AfterSelect

        If e.Node.Name.StartsWith("O") Then

            Dim IdOrd As Integer = e.Node.Name.Substring(1)
            Cursor.Current = Cursors.WaitCursor

            UcOrdineAnteprima.Carica(IdOrd)

            Cursor.Current = Cursors.Default

        End If
    End Sub

   
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblCarica.Click
        CaricaUscitiDaMagazzinoProntoRitiro()
    End Sub

    Private Sub GestisciConsegnaToolStripMenu_Click(sender As Object, e As EventArgs) Handles GestisciConsegnaToolStripMenu.Click
        GestisciConsegna()
    End Sub

    Private Sub ModificaDatiConsegnaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaDatiConsegnaToolStripMenuItem.Click
        ModificaDatiConsegna()
    End Sub

    Private Sub tvPrima_MouseClick(sender As Object, e As MouseEventArgs) Handles tvPrima.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            tvPrima.SelectedNode = tvPrima.GetNodeAt(e.X, e.Y)
            If Not tvPrima.SelectedNode Is Nothing Then
                mnuIncludiOrd.Show(MousePosition)
            End If
        End If
    End Sub
End Class
