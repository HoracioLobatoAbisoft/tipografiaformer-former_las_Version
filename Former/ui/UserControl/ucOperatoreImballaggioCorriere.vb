Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucOperatoreImballaggioCorriere
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        CaricaCombo()

    End Sub

    Private _IdCorr As Integer = 0
    Private _lstConsegne As List(Of ConsegnaProgrammata) = Nothing

    Public Sub Carica()

        CaricaImballaggioCorriere()
    End Sub

    Private Sub CaricaCombo()
        Try

            Using mgr As New ZoneDAO
                Dim lst As List(Of Zona) = mgr.GetAll(LFM.Zona.Descrizione, True)
                cmbZona.DisplayMember = "Descrizione"
                cmbZona.ValueMember = "Id"
                cmbZona.DataSource = lst
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tvClienti_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvClienti.AfterSelect

        If e.Node.Name.StartsWith("O") Then
            Dim IdOrd As Integer = e.Node.Name.Substring(1)
            Cursor.Current = Cursors.WaitCursor

            RaiseEvent OrdineSelezionato(IdOrd)

            Cursor.Current = Cursors.Default

        End If
    End Sub

    Public Event OrdineSelezionato(ByVal IdOrdine As Integer)

    Private Sub ForzaChiusuraConsegna()

        Dim IdCons As Integer = 0

        'devo recuperare l'id della consegna
        Dim Node As TreeNode = tvClienti.SelectedNode
        If Not Node Is Nothing Then
            If Node.Name.StartsWith("O") Then
                IdCons = Node.Parent.Name.Substring(1)
            ElseIf Node.Name.StartsWith("S") Then
                'qui ho la consegna
                IdCons = Node.Name.Substring(1)
            End If
        End If

        If IdCons Then

            Dim c As New ConsegnaProgrammata
            c.Read(IdCons)
            If c.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then ' c.ModificabileEx(True, False, True, True, False, False).Modificabile Then
                If MessageBox.Show("Vuoi forzare la chiusura della consegna selezionata sganciando gli ordini CHE SI TROVANO IN STATO PRECEDENTE A IMBALLAGGIO CORRIERE?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    If c.ListaOrdini.Count > 1 Then

                        If c.ListaOrdini.FindAll(Function(singO) singO.Stato = enStatoOrdine.ImballaggioCorriere).Count Then
                            'qui devo prendere gli ordini che non sono ancora stati inseriti e cambiargli la consegna spostandola

                            Dim SalvataScatola As Integer = 0

                            ParentFormEx.Sottofondo()
                            Using fr As New frmConsegnaImballaggio
                                SalvataScatola = fr.Carica(IdCons, True)
                            End Using
                            ParentFormEx.Sottofondo()

                            If SalvataScatola = 1 Then

                                'Dim DataNuova As Date = MgrDataConsegna.GetPrimaDataDisponibile(Now, c.IdCorr)

                                ''Dim DataNuova As Date = Now.Date

                                ''Select Case Now.DayOfWeek
                                ''    Case DayOfWeek.Saturday
                                ''        DataNuova = DataNuova.AddDays(2)
                                ''    Case DayOfWeek.Friday
                                ''        If c.IdCorr = enCorriere.RitiroCliente Then
                                ''            DataNuova = DataNuova.AddDays(1)
                                ''        Else
                                ''            DataNuova = DataNuova.AddDays(3)
                                ''        End If
                                ''    Case Else
                                ''        DataNuova = DataNuova.AddDays(1)
                                ''End Select

                                'For Each cpO As Ordine In c.ListaOrdini.FindAll(Function(singO) singO.Stato < enStatoOrdine.ImballaggioCorriere)

                                '    Using mgrC As New ConsegneProgrammateDAO
                                '        'TOLTO IL 08/04/2015
                                '        'mgrC.EliminaOrdineDaConsegna(0, cpO.IdOrd)
                                '        mgrC.RegistraConsegnaOrdineSuGiorno(cpO.IdOrd, c.IdCorr, DataNuova, c.IdRub, enMomentoConsegna.Pomeriggio, c.IdIndirizzo)
                                '    End Using

                                'Next

                                'c.AggiornaColliPeso()

                                CaricaImballaggioCorriere()
                            End If
                        Else
                            MessageBox.Show("Non puoi forzare la chiusura di una consegna in cui nessun ordine è stato preparato")
                        End If
                    Else
                        MessageBox.Show("Non puoi forzare la chiusura di una consegna che contiene un solo ordine")
                    End If

                End If
            Else
                MessageBox.Show("Questa consegna non può essere forzata")
            End If


        End If
    End Sub

    Private Sub btnForzaChiusuraCons_Click(sender As Object, e As EventArgs) Handles btnForzaChiusuraCons.Click
        ForzaChiusuraConsegna()
    End Sub
    Private Sub CaricaImballaggioCorriere(Optional ByVal Iniziale As String = "",
                          Optional ByVal IdRub As Integer = 0,
                          Optional ByVal TestoLibero As String = "",
                          Optional ByRef TvwRif As TreeView = Nothing)

        Cursor.Current = Cursors.WaitCursor

        If TvwRif Is Nothing Then
            TvwRif = tvClienti
        End If

        ' Dim IdCorrString As String = "(" & UcFiltroCorriereImballoCorriere.CorriereSelezionato & ")"
        _IdCorr = UcFiltroCorriereImballoCorriere.CorriereSelezionatoEnum

        Using mgr As New ConsegneProgrammateDAO
            _lstConsegne = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.InConsegna),
                                         New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.No),
                                         New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, String.Empty, "<>"),
                                         New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.DataTrasmissioneCorriere, Now.Date))
        End Using

        Dim Corriere As String = String.Empty

        'Dim SoloGls As Boolean = chkSoloGlsImballoCorr.Checked

        Dim FiltroCorriere As String = UcFiltroCorriereImballoCorriere.CorriereSelezionato

        Using mgr As New ConsegneRicercaDAO
            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.Registrato & "," &
                                        enStatoOrdine.InCodaDiStampa & "," &
                                        enStatoOrdine.StampaInizio & "," &
                                        enStatoOrdine.StampaFine & "," &
                                        enStatoOrdine.FinituraCommessaInizio & "," &
                                        enStatoOrdine.FinituraCommessaFine & "," &
                                        enStatoOrdine.FinituraProdottoInizio & "," &
                                        enStatoOrdine.FinituraProdottoFine & "," &
                                        enStatoOrdine.Imballaggio & "," &
                                        enStatoOrdine.ImballaggioCorriere & "," &
                                        enStatoOrdine.ProntoRitiro  '& "," & _'& "," & _
            'enStatoOrdine.ProntoRitiro()
            LstM = mgr.Lista(-1, 0, , , ListaStati, , , Iniziale, TestoLibero, CInt(enCorriere.RitiroCliente) & "," & CInt(enCorriere.TipografiaFormer) & "," & CInt(enCorriere.TipografiaFormerFuoriRaccordo), , , , , , FiltroCorriere)
            LstM.Sort(AddressOf Comparer)
            TvwRif.Nodes.Clear()

            For Each c As ConsegnaRicerca In LstM
                Dim checkOk As Boolean = True

                'If TabOperatore.SelectedTab Is tpConsegne Then
                '    If chkSoloConsegnabili.Checked Then
                '        If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
                '            checkOk = False
                '        End If
                '        If _AltroCorrCodTrack = False Then
                '            If c.CodTrack = String.Empty Then
                '                checkOk = False
                '            End If
                '        Else
                '            If c.CodTrack <> String.Empty Then
                '                checkOk = False
                '            End If
                '        End If
                '    Else
                '        If _AltroCorrCodTrack Then
                '            If c.CodTrack <> String.Empty Then
                '                checkOk = False
                '            End If
                '        End If
                '    End If
                'End If



                If chkSoloProntiRitiroCorr.Checked Then
                    If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
                        checkOk = False
                    End If
                End If

                If chkSoloDaImballCorr.Checked Then
                    If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ImballaggioCorriere).Count = 0 Then
                        checkOk = False
                    End If
                End If


                If checkOk Then
                    If cmbZona.SelectedValue Then
                        If c.Cliente.IdZona <> cmbZona.SelectedValue Then
                            checkOk = False
                        End If
                    End If
                End If

                If checkOk Then

                    Dim ChiaveData As String = "D" & c.Giorno.ToString("ddMMyyyy")
                    Dim NodoData As TreeNode = TvwRif.Nodes(ChiaveData)
                    If NodoData Is Nothing Then
                        NodoData = TvwRif.Nodes.Add(ChiaveData, c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                        'NodoCorr.Expand()
                    End If
                    Dim ChiaveCorriere As String = "C" & c.IdCorr
                    Dim ChiaveRubrica As String = "S" & c.IdCons
                    Dim ChiaveOrdine As String = "O" & c.IdOrd

                    Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
                    If NodoCorr Is Nothing Then
                        NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, c.CorriereNome, 6, 6)
                        'NodoCorr.Expand()
                    End If
                    Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
                    If NodoRub Is Nothing Then

                        Dim DescrRub As String = c.RagSoc

                        Dim DescrInd As String = " (" & c.Cliente.IndirizzoRegistrazione & ")"

                        If c.IdIndirizzo Then
                            'qui devo calcolare l'indirizzo
                            Dim I As New Indirizzo
                            I.Read(c.IdIndirizzo)
                            DescrInd = " (" & I.Riassunto & ")"
                            I = Nothing
                        End If

                        DescrRub &= DescrInd

                        NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)
                        'NodoRub.Expand()
                        'NodoRub.EnsureVisible()
                    End If
                    Dim Icona As Integer = 9

                    If c.Inserito Then Icona = 8

                    Dim nodoOrd As TreeNode = NodoRub.Nodes.Add("O" & c.IdOrd, "Lavoro " & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                    nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                    nodoOrd.Tag = c
                    If c.Giorno.Date = Now.Date Then NodoData.Expand()
                    NodoCorr.Expand()
                    'NodoRub.Expand()
                End If

            Next
        End Using

        Cursor.Current = Cursors.Default
    End Sub

    Private Function Comparer(ByVal x As ConsegnaRicerca, ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = x.Giorno.CompareTo(y.Giorno)
        If result = 0 Then
            result = x.Cliente.RagSocNome.CompareTo(y.Cliente.RagSocNome)
            If result = 0 Then result = x.Inserito.CompareTo(y.Inserito)
        End If
        Return result
    End Function

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click

        CaricaImballaggioCorriere()

    End Sub

    Private Sub btnGestCons_Click(sender As Object, e As EventArgs) Handles btnGestCons.Click

        Dim IdCons As Integer = 0

        'devo recuperare l'id della consegna
        Dim Node As TreeNode = tvClienti.SelectedNode
        If Not Node Is Nothing Then
            If Node.Name.StartsWith("O") Then
                IdCons = Node.Parent.Name.Substring(1)
            ElseIf Node.Name.StartsWith("S") Then
                'qui ho la consegna
                IdCons = Node.Name.Substring(1)
            End If
        End If

        If IdCons Then
            Dim c As New ConsegnaProgrammata
            c.Read(IdCons)

            Dim OkGiorno As Boolean = True ' False
            'If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then
            '    Dim Differenza As Integer = 0
            '    Differenza = DateDiff(DateInterval.Day, c.Giorno, Now.Date)

            '    If Differenza <> 0 Then
            '        OkGiorno = False
            '    End If

            'Else
            '    OkGiorno = True
            'End If

            If OkGiorno Then
                If c.ListaOrdini.FindAll(Function(xx) xx.Stato < enStatoOrdine.ImballaggioCorriere).Count > 0 Then
                    MessageBox.Show("Per GLS si possono gestire solo le consegne in cui tutti gli ordini sono in stato Imballaggio Corriere")
                Else
                    ParentFormEx.Sottofondo()

                    Using x As New frmConsegnaImballaggio
                        x.Carica(IdCons)
                    End Using

                    ParentFormEx.Sottofondo()
                End If
            Else
                MessageBox.Show("Per GLS si possono gestire solo le consegne previste per oggi")
            End If

        End If
    End Sub

    Private Sub chkSoloDaImballCorr_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloDaImballCorr.CheckedChanged
        If sender.focused Then CaricaImballaggioCorriere()
    End Sub

    Private Sub chkSoloProntiRitiroCorr_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloProntiRitiroCorr.CheckedChanged
        If sender.focused Then CaricaImballaggioCorriere()
    End Sub

    Private Sub cmbZona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbZona.SelectedIndexChanged
        If sender.focused Then CaricaImballaggioCorriere()
    End Sub

    Private Sub UcFiltroCorriereImballoCorriere_SelezionatoCorriere(sender As Object) Handles UcFiltroCorriereImballoCorriere.SelezionatoCorriere
        If sender.focused Then CaricaImballaggioCorriere()
    End Sub
End Class
