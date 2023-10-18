Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerPrinter
Imports FormerBusinessLogicInterface

Friend Class frmConsegnaImballaggio
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Private _IdCons As Integer = 0
    Private _C As ConsegnaProgrammata = Nothing

    Private _ListaScatoleTW As New List(Of Scatola)

    Private Sub CaricaConsegnaRelativa()

        Dim AbilitaStampaEtichette As Boolean = False
        Dim AbilitaSballaScatole As Boolean = False
        Dim AbilitaCreaScatola As Boolean = False
        Dim AbilitaSalvaScatole As Boolean = True

        tvConsegne.Nodes.Clear()
        tvwScatole.Nodes.Clear()

        Dim nodoStart As TreeNode = tvConsegne.Nodes.Add("V", _C.Cliente.RagSocNome & " (Collo/i " & _C.NumColli & ")", 0, 0)
        Dim nodoStartS As TreeNode = tvwScatole.Nodes.Add("V", _C.Cliente.RagSocNome, 0, 0)

        'qui devo caricare gli ordini e le scatole 
        'se unh ordine sta in scatola non lo carico tra gli ordini e lo metto dentro la scatola

        Dim l As List(Of OrdineScatola)

        Using mgr As New OrdiniScatoleDAO
            l = mgr.OrdiniInScatolaByCons(_C)
        End Using

        For Each virtSc As FormerDALSql.Scatola In _ListaScatoleTW
            For Each virtOSc As OrdineScatola In virtSc.OrdiniInScatola
                l.Add(virtOSc)
            Next
        Next

        Dim lo As List(Of Ordine) = New List(Of Ordine)
        If _C.Forzata Then
            lo = _C.ListaOrdini.FindAll(Function(singO) singO.Stato >= enStatoOrdine.ImballaggioCorriere)
        Else
            lo = _C.ListaOrdini
        End If

        Select Case _C.IdCorr
            Case enCorriere.GLS, enCorriere.PortoAssegnatoGLS, enCorriere.GLSIsole
                lblCorr.Text = "GLS"
            Case enCorriere.Bartolini, enCorriere.PortoAssegnatoBartolini
                lblCorr.Text = "Bartolini"
        End Select

        If _C.StampaDocumenti = enStampaDocumenti.Si Then
            lblStampaAutomatica.Text = "sì"
        Else
            lblStampaAutomatica.Text = "no"
        End If

        For Each o As Ordine In lo
            Dim ChiaveOrdine As String = "O" & o.IdOrd
            Dim Icona As Integer = 1

            Dim NumColli As Integer = o.NumeroRealeColli

            Dim NodoOrd As New TreeNode

            NodoOrd.Name = "O" & o.IdOrd
            NodoOrd.Text = "Ord." & o.IdOrd & " - " & o.Prodotto.Descrizione '& " "
            NodoOrd.ImageIndex = Icona
            NodoOrd.SelectedImageIndex = Icona
            NodoOrd.Tag = NumColli

            'ora per ogni ordine carico i pacchi 

            For i As Integer = 1 To NumColli
                Dim CodBarScatola As String = FormerHelper.FormerBarCode.CodiceOrdine(o.IdOrd, i) & "0"
                Dim NumCollo As Integer = i

                If l.FindAll(Function(x) x.IdOrdine = o.IdOrd And x.NumeroCollo = NumCollo).Count = 0 Then
                    Dim nodoScat As TreeNode = NodoOrd.Nodes.Add("C" & o.IdOrd & "N" & i, "Collo " & CodBarScatola, 10, 10)
                End If
            Next

            If NodoOrd.Nodes.Count Then
                nodoStart.Nodes.Add(NodoOrd)
                'se aggiungo l'ordine controllo se sia di tipo inserito o di tipo non inserito per abilitare in caso il crea scatole
                Dim lstIns As List(Of ConsProgrOrdini) = Nothing
                Using mgr As New ConsProgrOrdiniDAO
                    lstIns = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdOrd, o.IdOrd))
                End Using

                If lstIns.Count Then
                    Dim OCheck As New Ordine
                    OCheck.Read(lstIns(0).IdOrd)

                    'If lstIns(0).Inserito = enSiNo.No And OCheck.Stato <> enStatoOrdine.ProntoRitiro Then
                    '    AbilitaCreaScatola = True
                    'End If

                    'If OCheck.Stato <> enStatoOrdine.ProntoRitiro Then
                    '    AbilitaCreaScatola = True
                    'End If

                    Dim ColliInScatola As Integer = l.FindAll(Function(x) x.IdOrdine = OCheck.IdOrd).Count

                    If ColliInScatola < OCheck.NumeroRealeColli Then
                        AbilitaCreaScatola = True
                        If ColliInScatola > 0 Then
                            AbilitaSalvaScatole = False
                        End If
                    End If

                End If

            End If
            NodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(o.Stato)
        Next

        'If _ListaScatoleTW.Count > 0 Then 'And AbilitaCreaScatola = False Then
        '    AbilitaStampaEtichette = True
        'ElseIf _ListaScatoleTW.Count <> 0 And AbilitaCreaScatola = False Then
        '    AbilitaSalvaScatole = True
        'End If

        'qui carico le scatole 
        For Each OS As OrdineScatola In l

            Dim NodoScat As TreeNode

            If OS.IdScatola Then
                NodoScat = nodoStartS.Nodes("S" & OS.IdScatola)
                If NodoScat Is Nothing Then
                    NodoScat = nodoStartS.Nodes.Add("S" & OS.IdScatola, "Scatola " & OS.IdScatola, 11, 11)
                    AbilitaSballaScatole = True
                End If
            Else
                NodoScat = nodoStartS.Nodes("V" & OS.GUIDScatola)
                If NodoScat Is Nothing Then
                    NodoScat = nodoStartS.Nodes.Add("V" & OS.GUIDScatola, "Scatola DA SALVARE", 11, 11)
                End If
            End If

            Dim O As New Ordine
            O.Read(OS.IdOrdine)

            Dim NodoOrd As TreeNode = NodoScat.Nodes.Add("C" & OS.IdOrdine & "N" & OS.NumeroCollo, "Ord." & O.IdOrd & " - " & O.Prodotto.Descrizione & " Collo " & OS.NumeroCollo, 1, 1)
            NodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(O.Stato)
        Next

        nodoStart.ExpandAll()
        nodoStartS.ExpandAll()

        AbilitaStampaEtichette = AbilitaSballaScatole

        'TODO: UNA VOLTA REGISTRATA SU GLS, PUO' ESSERE ANCORA MODIFICATA OPPURE NO? SI'
        If _C.IdStatoConsegna = enStatoConsegna.InLavorazione Or _C.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
            btnStampaEtichScat.Enabled = AbilitaStampaEtichette
            btnSballaScatola.Enabled = AbilitaSballaScatole
            btnSballaTutte.Enabled = btnSballaScatola.Enabled
            btnCreaScatola.Enabled = AbilitaCreaScatola
            btnSalvaScatole.Enabled = AbilitaSalvaScatole
        Else
            btnStampaEtichScat.Enabled = False
            btnSballaScatola.Enabled = False
            btnSballaTutte.Enabled = btnSballaScatola.Enabled
            btnCreaScatola.Enabled = False
            btnSalvaScatole.Enabled = False
            btnProponiSoluzione.Visible = False
        End If

        If _C.IdStatoConsegna >= enStatoConsegna.RegistrataCorriere Then
            If _C.DataTrasmissioneCorriere <> Date.MinValue And (_C.IdCorr = enCorriere.GLS Or _C.IdCorr = enCorriere.GLSIsole Or _C.IdCorr = enCorriere.PortoAssegnatoGLS) Then
                btnEtichettaGls.Enabled = True
            Else
                btnEtichettaGls.Enabled = False
            End If
            btnSalvaScatole.Enabled = False
            btnCreaScatola.Enabled = False
            btnProponiSoluzione.Enabled = False
        Else
            btnEtichettaGls.Enabled = False
        End If

    End Sub

    Friend Function Carica(IdCons As Integer, Optional Forzata As Boolean = False) As Integer

        UcOrdineAnteprima.Carica(0, True)

        _IdCons = IdCons
        _C = New ConsegnaProgrammata
        _C.Read(IdCons)

        _C.Forzata = Forzata

        If _C.IdStatoConsegna <> enStatoConsegna.InLavorazione Then
            btnSballaScatola.Enabled = False
            btnSballaTutte.Enabled = btnSballaScatola.Enabled
            btnCreaScatola.Enabled = False
        End If

        Dim TrovatiDiversi As Boolean = False
        Dim IdModelloCubetto As Integer = 0

        Dim lo As List(Of Ordine) = New List(Of Ordine)
        If _C.Forzata Then
            lo = _C.ListaOrdini.FindAll(Function(singO) singO.Stato >= enStatoOrdine.ImballaggioCorriere)
        Else
            lo = _C.ListaOrdini
        End If

        For Each o As Ordine In lo
            If o.ListinoBase Is Nothing Then
                TrovatiDiversi = True
                Exit For
            Else
                If o.ListinoBase.IdModelloCubetto <> 0 Then
                    If o.ListinoBase.IdModelloCubetto <> IdModelloCubetto Then
                        If IdModelloCubetto = 0 Then
                            IdModelloCubetto = o.ListinoBase.IdModelloCubetto
                        Else
                            TrovatiDiversi = True
                            Exit For
                        End If
                    End If
                Else
                    TrovatiDiversi = True
                    Exit For
                End If
            End If
        Next

        If TrovatiDiversi = False Then btnProponiSoluzione.Visible = True

        If _C.Forzata Then
            Dim PesoTemp As Single = 0
            For Each o As Ordine In lo
                PesoTemp += o.Prodotto.PesoComplessivo
            Next
            txtPesoConsegna.Text = PesoTemp
        Else
            txtPesoConsegna.Text = _C.Peso
        End If

        If _C.HaUnPagamentoAnticipato Then
            txtPesoConsegna.ReadOnly = True
            lnkCalcPeso.Enabled = False
            toolTipHelp.SetToolTip(txtPesoConsegna, "Il peso non può essere variato perchè è presente un pagamento anticipato")
        End If

        CaricaConsegnaRelativa()

        If Not PostazioneCorrente.UtenteConnesso Is Nothing AndAlso PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then

            If btnCreaScatola.Enabled Then
                btnChiudi.Enabled = False
            End If

        End If

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

    Private Sub tbProd_Click(sender As Object, e As EventArgs) Handles tbProd.Click

    End Sub

    Private Sub btnChiudi_Click(sender As Object, e As EventArgs) Handles btnChiudi.Click

        Close()

    End Sub

    Private Sub tvConsegne_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvConsegne.NodeMouseClick

        Dim Node As TreeNode = e.Node

        If Node.Name.StartsWith("O") Or Node.Name.StartsWith("C") Then

            Dim NomeNodo As String = Node.Name.Substring(1)
            Dim PosizN As Integer = NomeNodo.IndexOf("N")
            If PosizN <> -1 Then
                NomeNodo = NomeNodo.Substring(0, PosizN)
            End If

            Dim IdOrd As Integer = NomeNodo

            UcOrdineAnteprima.Carica(IdOrd, True)

        End If

    End Sub

    Private Sub btnCreaScatola_Click(sender As Object, e As EventArgs) Handles btnCreaScatola.Click

        'qui devo vedere se ci sono le condizioni per creare una scatola

        CreaScatola()

    End Sub

    Private Sub CreaScatola()

        Dim Ris As String = "GO"
        Dim Messaggio As String = ""
        Dim IdOrdRif As Integer = 0
        Dim IdConsRif As Integer = 0
        Dim MsgSupplement As String = ""
        Dim IdScatola As String = String.Empty
        Dim ChiudiRiapri As Boolean = False

        While Ris.Length

            'Sottofondo()

            Dim x As New frmMagazzinoBarCodeRCTF

            Ris = x.Carica(Messaggio, IdOrdRif, IdConsRif, MsgSupplement, True)
            Ris = Ris.TrimEnd
            Ris = Ris.TrimStart
            'Sottofondo()

            If Ris = FormerConst.Barcode.BarcodeChiudiScatolaERiapri Then
                If _ListaScatoleTW.FindAll(Function(xx) xx.OrdiniInScatola.Count = 0).Count = 0 Then
                    Using S = New FormerDALSql.Scatola
                        IdScatola = S.GUID
                        _ListaScatoleTW.Add(S)
                        Dim t As TreeNode = tvwScatole.Nodes("V")
                        t.Nodes.Add("V" & S.GUID, "Scatola DA SALVARE", 11, 11)
                    End Using
                End If

                ChiudiRiapri = True
                Ris = String.Empty
            Else
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
                    If O.IdOrd And NumCollo > 0 Then
                        If _C.IdRub <> O.IdRub Then
                            'MessageBox.Show("Non si possono scaricare da magazzino ordini di clienti diversi")
                            MgrSound.Suona(enTipoSuono.ErroreNoClientiDiversi)
                            MsgSupplement = "Non si possono imballare ordini di clienti diversi"
                        Else
                            If _C.IdCons <> O.IdCons Then
                                'MessageBox.Show("Non si possono scaricare da magazzino ordini di clienti diversi")
                                MgrSound.Suona(enTipoSuono.ErroreOrdineNonInConsegna)
                                MsgSupplement = "Ordine NON nella consegna in lavorazione"
                            Else

                                Dim OrdineGiaInscatolato As Boolean = False
                                Dim l As List(Of OrdineScatola) = Nothing
                                'qui controllo che l'etichetta che hai sparato non sia gia prevista in un altra scatola
                                Using mgr As New OrdiniScatoleDAO
                                    l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.OrdineScatola.IdOrdine, O.IdOrd),
                                                    New LUNA.LunaSearchParameter(LFM.OrdineScatola.NumeroCollo, NumCollo))

                                    If l.Count Then
                                        OrdineGiaInscatolato = True
                                    End If

                                End Using

                                For Each scatola As Scatola In _ListaScatoleTW
                                    If scatola.OrdiniInScatola.FindAll(Function(xx) xx.IdOrdine = O.IdOrd And xx.NumeroCollo = NumCollo).Count Then
                                        OrdineGiaInscatolato = True
                                        Exit For
                                    End If
                                Next

                                If OrdineGiaInscatolato Then
                                    'qui il collo e' gia stato inserito in qualche scatola
                                    MgrSound.Suona(enTipoSuono.ErroreColloGiaCaricato)
                                    MsgSupplement = "Ordine già caricato in una scatola"
                                Else
                                    'qui vado a creare la scatola se non ho gia l'id
                                    Dim S As FormerDALSql.Scatola

                                    If IdScatola = String.Empty Then
                                        'qui vedo se ci sta una scatola vuota
                                        S = _ListaScatoleTW.Find(Function(ss) ss.OrdiniInScatola.Count = 0)
                                    Else
                                        S = _ListaScatoleTW.Find(Function(ss) ss.GUID = IdScatola)
                                    End If

                                    Dim OkInserisci As Boolean = True

                                    If Not S Is Nothing Then
                                        IdScatola = S.GUID
                                        'qui vado a controllare che il collo non sia gia stato sparato
                                        If Not S.OrdiniInScatola.Find(Function(ax) ax.IdOrdine = O.IdOrd And ax.NumeroCollo = NumCollo) Is Nothing Then
                                            OkInserisci = False
                                        End If

                                        If OkInserisci Then
                                            'qui vado a controllare che il collo esista 
                                            If NumCollo > O.NumeroRealeColli Then
                                                OkInserisci = False
                                            End If
                                        End If

                                    Else
                                        S = New FormerDALSql.Scatola
                                        IdScatola = S.GUID
                                        _ListaScatoleTW.Add(S)
                                    End If

                                    If OkInserisci Then
                                        Dim Cs As New OrdineScatola
                                        Cs.IdOrdine = O.IdOrd
                                        Cs.GUIDScatola = S.GUID
                                        Cs.EtichettaCollo = Ris
                                        Cs.NumeroCollo = NumCollo
                                        S.OrdiniInScatola.Add(Cs)

                                        CaricaConsegnaRelativa()

                                        MsgSupplement = ""
                                    Else
                                        MsgSupplement = "Collo già inserito in una scatola o numero collo non valido"
                                    End If
                                End If
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
            End If

        End While

        If ChiudiRiapri Then
            CreaScatola()
        End If

    End Sub

    Private Sub SballaScatola(IdScatola As Integer)
        Using mgr As New OrdiniScatoleDAO

            Dim l As List(Of OrdineScatola) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.OrdineScatola.IdScatola, IdScatola))

            For Each singOs As OrdineScatola In l

                'TODO: A ME (MARCO) SEMBRA CHE PER COME STANNO ADESSO LE COSE, QUANDO UNA SCATOLA VIENE SBALLATA, A PRESCINDERE DAL FATTO CHE L'ORDINE SIA PASSATO
                'DA SOLUZIONE, DEVE COMUNQUE ESSERE RIPORTATO A IMBALLAGGIO CORRIERE
                'Dim O As New Ordine
                'O.Read(singOs.IdOrdine)
                'If O.InseritoNelPacco = False Then
                Using mgrO As New OrdiniDAO
                    mgrO.AvanzaOrdiniAStatoByIdOrd(singOs.IdOrdine, enStatoOrdine.ImballaggioCorriere)
                End Using
                'End If
            Next

            mgr.DeleteByIdScatola(IdScatola)

        End Using

        Using mgr As New ScatoleDAO
            mgr.Delete(IdScatola)
        End Using

        If _C.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
            Dim CodTrack As String = _C.CodTrack
            _C.CodTrack = String.Empty
            '_C.Blocco = enSiNo.No
            _C.NumeroPrimoColloBartolini = String.Empty
            _C.DataTrasmissioneCorriere = Date.MinValue

            Using mgr As New ConsegneProgrammateDAO()
                mgr.AvanzaStatoConsegna(_C, enStatoConsegna.InLavorazione)
            End Using

            Select Case _C.IdCorr
                Case enCorriere.GLS, enCorriere.PortoAssegnatoGLS, enCorriere.GLSIsole
                    Dim RisEliminazione As String = ""

                    If FormerDebug.DebugAttivo = False Then
                        RisEliminazione = FormerWebLabeling.MgrWebLabelingGls.EliminaSpedizione(CodTrack)
                    End If

                    MessageBox.Show(RisEliminazione & vbCrLf & "Ricorda di togliere le etichette di GLS vecchie dai pacchi," &
                                                " di reimmettere la spedizione su GLS e di rietichettare i pacchi prima che venga fatta l'uscita da magazzino!")
                Case enCorriere.Bartolini, enCorriere.PortoAssegnatoBartolini
                    MessageBox.Show("Ricorda di togliere le etichette di Bartolini vecchie dai pacchi, di far reimmettere la spedizione su Easy Sped in amministrazione e di" &
                            " rietichettare i pacchi prima che venga fatta l'uscita da magazzino!")
            End Select
        End If

        _Ris = 0

    End Sub

    Private Sub btnSballaScatola_Click(sender As Object, e As EventArgs) Handles btnSballaScatola.Click

        Dim Nodo As TreeNode = tvwScatole.SelectedNode
        Dim IdScatola As Integer = 0

        If Not Nodo Is Nothing Then
            If Nodo.Name.StartsWith("S") Then
                IdScatola = Nodo.Name.Substring(1)
            ElseIf Nodo.Name.StartsWith("C") Then
                IdScatola = Nodo.Parent.Name.Substring(1)
            End If
        End If

        If IdScatola = 0 Then
            MessageBox.Show("Seleziona una scatola dalla lista")
        Else
            If MessageBox.Show("ATTENZIONE, OPERAZIONE NON REVERSIBILE - Confermi l'eliminazione della scatola " & IdScatola & "?", "Sballa Scatola", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Using TB As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    'qui devo cancellare la scatola selezionata dal db e far ricalcolare alla consegna colli e peso
                    Try
                        'Dim ListaScatole As New List(Of Integer)
                        'Dim ListaOrdini As New List(Of Integer)
                        'ListaScatole.Add(IdScatola)

                        'Using mgr As New OrdiniScatoleDAO
                        '    Dim l As List(Of OrdineScatola) = mgr.FindAll(New LUNA.LunaSearchParameter("IdScatola", IdScatola)) 'qui ho tutti gli ordin icontenuti nellas catola 
                        '    For Each so As OrdineScatola In l
                        '        If ListaOrdini.IndexOf(so.IdOrdine) = -1 Then
                        '            ListaOrdini.Add(so.IdOrdine)
                        '        End If
                        '    Next
                        '    'qui ho la lista degli ordini contenuti nella scatola
                        '    For Each singO As Integer In ListaOrdini
                        '        Dim l2 As List(Of OrdineScatola) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrdine", singO)) 'qui ho tutti gli ordin icontenuti nellas catola 
                        '        For Each so As OrdineScatola In l
                        '            If ListaOrdini.IndexOf(so.IdOrdine) = -1 Then
                        '                ListaOrdini.Add(so.IdOrdine)
                        '            End If
                        '        Next
                        '    Next



                        'End Using

                        TB.TransactionBegin()

                        SballaScatola(IdScatola)

                        TB.TransactionCommit()

                        _C.AggiornaColliPeso()

                        CaricaConsegnaRelativa()

                    Catch ex As Exception
                        TB.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore durante l'operazione")
                    End Try

                End Using

            End If
        End If

    End Sub

    Private Function RisaliAIdScatola(Nodo As TreeNode) As Integer
        Dim Ris As Integer = 0
        If Not Nodo Is Nothing Then
            'Try
            If Nodo.Name.StartsWith("S") Then
                Ris = Nodo.Name.Substring(1)
            Else
                Ris = RisaliAIdScatola(Nodo.Parent)
            End If
            'Catch ex As Exception

            'End Try
        End If
        Return Ris
    End Function

    Private Sub btnStampaEtichScat_Click(sender As Object, e As EventArgs) Handles btnStampaEtichScat.Click

        Dim Nodo As TreeNode = tvwScatole.SelectedNode

        Dim IdScatola As Integer = 0

        If Not Nodo Is Nothing Then
            'qui il nodo e' selezionato risalgo fino alla scatola
            IdScatola = RisaliAIdScatola(Nodo)
        Else
            'qui provo a vedere se ci sta una scatola sola
            Dim TrovataScatola As Boolean = False
            Dim IdTempS As Integer = 0
            For Each NodoAlb As TreeNode In tvConsegne.Nodes(0).Nodes
                If NodoAlb.Name.StartsWith("S") Then
                    If TrovataScatola = False Then
                        IdTempS = NodoAlb.Name.Substring(1)
                        TrovataScatola = True
                    Else
                        IdTempS = 0
                        Exit For
                    End If
                End If
            Next
            If IdTempS Then
                IdScatola = IdTempS
            End If
        End If

        If IdScatola Then
            If MessageBox.Show("Vuoi stampare l'etichetta della scatola " & IdScatola & "?", "Stampa Etichette", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim x As New myPrinter
                x.PrinterName = PostazioneCorrente.StampanteEtichette
                x.IdCons = _IdCons
                x.IdScatola = IdScatola
                Dim t As New System.Threading.Thread(AddressOf x.StampaEtichetteScatola)
                t.Start()
                x = Nothing

            End If
        Else
            MessageBox.Show("Seleziona una scatola dalla lista")
        End If

    End Sub

    Private Sub btnSalvaScatole_Click(sender As Object, e As EventArgs) Handles btnSalvaScatole.Click

        If _ListaScatoleTW.FindAll(Function(x) x.OrdiniInScatola.Count > 0).Count Then
            If MessageBox.Show("Confermi il salvataggio di questa configurazione di imballaggio? Controlla il peso totale della consegna!", "Salva Scatole", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If txtPesoConsegna.Value > 0 Then

                    Dim OkGls As Boolean = True

                    'Test Servizi GLS 
                    Dim TestGlsOk As Boolean = False

                    TestGlsOk = FormerHelper.Web.IsOkWebsite("https://labelservice.gls-italy.com")

                    If TestGlsOk = False Then
                        If MessageBox.Show("Il servizio di GLS non sembra funzionante, vuoi continuare comunque?", "GLS Test", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            OkGls = False
                        End If
                    End If

                    If OkGls Then

                        _ListaScatoleTW = _ListaScatoleTW.FindAll(Function(x) x.OrdiniInScatola.Count > 0)

                        Dim ScritturaBuonFine As Boolean = True
                        Using TB As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                            Try
                                TB.TransactionBegin()

                                Dim lo As List(Of Ordine) = New List(Of Ordine)
                                If _C.Forzata Then
                                    lo = _C.ListaOrdini.FindAll(Function(singO) singO.Stato >= enStatoOrdine.ImballaggioCorriere)
                                Else
                                    lo = _C.ListaOrdini
                                End If

                                For Each o As Ordine In lo

                                    Using mgr As New OrdiniDAO
                                        mgr.AvanzaOrdiniAStatoByIdOrd(o.IdOrd, enStatoOrdine.ProntoRitiro)
                                    End Using

                                Next

                                For Each S As FormerDALSql.Scatola In _ListaScatoleTW

                                    S.IsChanged = True
                                    S.Save()

                                    For Each so As OrdineScatola In S.OrdiniInScatola
                                        so.IdScatola = S.IdScatola
                                        so.Save() 'ora sposto in avanti di stato tutti gli ordini inclusi nella consegna 
                                    Next

                                Next

                                'TODO: VERIFICARE COMPORTAMENTO CORRETTO QUANDO VIENE FORZATA CHIUSURA DI UNA CONSEGNA DI DOMANI
                                Dim DataNuova As Date = MgrDataConsegna.GetPrimaDataDisponibile(_C.Giorno, _C.IdCorr, True)
                                'Dim DataNuova As Date = MgrDataConsegna.GetPrimaDataDisponibile(Now, _C.IdCorr)

                                For Each cpO As Ordine In _C.ListaOrdini.FindAll(Function(singO) singO.Stato < enStatoOrdine.ImballaggioCorriere)

                                    Using mgrC As New ConsegneProgrammateDAO
                                        'TOLTO IL 08/04/2015
                                        'mgrC.EliminaOrdineDaConsegna(0, cpO.IdOrd)
                                        mgrC.RegistraConsegnaOrdineSuGiorno(cpO.IdOrd, _C.IdCorr, DataNuova, _C.IdRub, enMomentoConsegna.Pomeriggio, _C.IdIndirizzo, , , , _C.IdCons)
                                    End Using

                                Next

                                _C.AggiornaColliPeso(txtPesoConsegna.Value)
                                TB.TransactionCommit()
                            Catch ex As Exception
                                TB.TransactionRollBack()
                                ScritturaBuonFine = False
                                MessageBox.Show("Si è verificato un errore nel salvataggio: " & ex.Message)
                            End Try
                        End Using

                        If ScritturaBuonFine Then
                            Try
                                If FormerDebug.DebugAttivo = False Then
                                    For Each S As FormerDALSql.Scatola In _ListaScatoleTW
                                        Dim x As New myPrinter
                                        x.PrinterName = PostazioneCorrente.StampanteEtichette
                                        x.IdCons = _IdCons
                                        x.IdScatola = S.IdScatola
                                        Dim t As New System.Threading.Thread(AddressOf x.StampaEtichetteScatola)
                                        t.Start()
                                        x = Nothing
                                    Next
                                End If

                            Catch ex As Exception
                                MessageBox.Show("Si è verificato un errore nella stampa delle etichette. Ristamparle")
                            End Try

                            'If _C.ForzaCsvCorriere Then
                            'Select Case _C.IdCorr
                            '    Case enCorriere.GLS, enCorriere.PortoAssegnatoGLS
                            '        cGls.EsportaCsvGls(_C)
                            '    Case enCorriere.Bartolini, enCorriere.PortoAssegnatoBartolini
                            '        cBrt.EsportaCsvBartolini(_C)
                            'End Select
                            'Else

                            'End If

                            Dim RisStampaDocumenti As Integer = 0
                            If _C.Eliminato <> enSiNo.Si Then

                                Dim MessaggioStampa As String = "Si prega di RITIRARE i relativi documenti contabili"

                                If FormerDebug.DebugAttivo = False Then

                                    If _C.StampaDocumenti = enStampaDocumenti.Si Then 'And _C.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then

                                        If _C.HaDocumentiFiscali = False Then
                                            'EMETTO I DOCUMENTI
                                            RisStampaDocumenti = ProxyDocumenti.CreaDocumenti(_C.IdCons,
                                                                                              False,
                                                                                              False,
                                                                                              PostazioneCorrente.UtenteConnesso.IdUt)
                                        End If
                                    End If

                                    If _C.HaDocumentiFiscali Then
                                        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then
                                            'STAMPO TUTTI I DOCUMENTI
                                            Dim NumCopie As Integer = FormerLib.FormerConst.Fiscali.NumCopieDocFiscali
                                            Dim IdUtStampa As Integer = PostazioneCorrente.UtenteConnesso.IdUt
                                            If _C.NoCartaceo = enSiNo.Si Then
                                                MessaggioStampa = "Il documento fiscale non va inserito nel pacco. Una copia è stata stampata in amministrazione"
                                                NumCopie = 2
                                                IdUtStampa = FormerConst.UtentiSpecifici.IdUtenteLidia
                                            Else
                                                'ProxyStampa.StampanteLibera = PostazioneCorrente.StampanteLiberaOperatore
                                                'ProxyStampa.StampanteFatture = PostazioneCorrente.StampanteFattureOperatore
                                                MessaggioStampa &= " dalla stampante fatture"
                                            End If

                                            If _C.NoCartaceo <> enSiNo.Si Then
                                                For Each R As Ricavo In _C.ListaDocumenti
                                                    Try
                                                        MgrDocumentiFiscali.MessaggioModuloFattura(R, NumCopie)

                                                        ProxyStampa.StampaDocumentoFiscale(R,
                                                                                           False,
                                                                                           NumCopie,
                                                                                           IdUtStampa) 'modificato a true per stampare diretto
                                                        'STAMPA DOCUMENTO FISCALE OPERATORE una sola copia in caso di operatore per corriere
                                                    Catch ex As Exception
                                                        MessageBox.Show("Si è verificato un errore nella stampa dei documenti fiscali, ristamparli manualmente in amministrazione")
                                                    End Try

                                                Next
                                            End If

                                            'ProxyStampa.StampanteLibera = PostazioneCorrente.StampanteLibera
                                            'ProxyStampa.StampanteFatture = PostazioneCorrente.StampanteFatture
                                        Else

                                            For Each R As Ricavo In _C.ListaDocumenti
                                                Try
                                                    Dim NumCopie As Integer = FormerLib.FormerConst.Fiscali.NumCopieDocFiscali
                                                    If _C.NoCartaceo = enSiNo.Si Then
                                                        MessaggioStampa = "Il documento fiscale non va inserito nel pacco."
                                                        NumCopie = 2
                                                    End If
                                                    MgrDocumentiFiscali.MessaggioModuloFattura(R, NumCopie)
                                                    ProxyStampa.StampaDocumentoFiscale(R,
                                                                                       True,
                                                                                       NumCopie,
                                                                                       PostazioneCorrente.UtenteConnesso.IdUt)
                                                Catch ex As Exception
                                                    MessageBox.Show("Si è verificato un errore nella stampa dei documenti fiscali, ristamparli manualmente in amministrazione")
                                                End Try

                                            Next
                                            MessaggioStampa &= " in amministrazione"
                                        End If

                                    End If


                                    If _C.NoRegistrazioneGLS <> enSiNo.Si Then
                                        Try
                                            Cursor.Current = Cursors.WaitCursor
                                            'CHIAMATA ALLA ADDPARCEL DEL WS GLS
                                            MgrConsegneCorriere.GLS.PrenotaSpedizioneGls(_C)
                                            Cursor.Current = Cursors.Default
                                        Catch ex As Exception
                                            MessageBox.Show("Si è verificato un errore nella registrazione con GLS: " & ex.Message & vbCrLf & "Lo stato degli ordini è stato correttamente" &
                                                            " avanzato, ma è necessario procedere alla registrazione manuale delle spedizioni con GLS. Passare in amministrazione!")
                                            'cGls.EsportaCsvGls(_C)
                                        End Try
                                    End If
                                End If



                                If RisStampaDocumenti = 1 Then
                                    'si devono ritirare documenti
                                    MessageBox.Show(MessaggioStampa)
                                ElseIf RisStampaDocumenti = 2 Then
                                    'si deve saldare il pagamento
                                    MessageBox.Show(MessaggioStampa & " e SALDARE l'importo")
                                End If

                                If _C.IdCorr = enCorriere.Bartolini Or _C.IdCorr = enCorriere.PortoAssegnatoBartolini Then
                                    MessageBox.Show("Prima di poter far uscire da magazzino questa consegna (Bartolini) è necessario che in amministrazione venga effettuata" _
                                                    & " la registrazione via Easy Sped e che venga inserito manualmente il codice di tracking e il numero di primo collo!")
                                End If

                            End If

                            _Ris = 1
                        End If
                        _ListaScatoleTW.Clear()
                        CaricaConsegnaRelativa()

                        btnChiudi.Enabled = True

                    End If
                Else
                    MessageBox.Show("Il peso inserito non è valido!")
                End If
            End If
        Else
            MessageBox.Show("E' obbligatorio creare almeno una scatola!")
        End If
    End Sub

    Private Sub btnProponiSoluzione_Click(sender As Object, e As EventArgs) Handles btnProponiSoluzione.Click

        'qui se ci sono solo cubetti dello stesso tipo posso proporre una soluzione completa di inscatolamento

        'qui prendo il primo ordine della consegna e il totale dei colli reali contenuti nella consegna
        Dim IdOrd As Integer = 0
        Dim NumCubetti As Integer = 0

        Dim lo As List(Of Ordine) = New List(Of Ordine)
        If _C.Forzata Then
            lo = _C.ListaOrdini.FindAll(Function(singO) singO.Stato >= enStatoOrdine.ImballaggioCorriere)
        Else
            lo = _C.ListaOrdini
        End If

        For Each O As Ordine In lo
            If IdOrd = 0 Then IdOrd = O.IdOrd
            NumCubetti += O.NumeroRealeColli
        Next

        Dim NumScatole As Integer = MgrImballo.NumColliDaSoluzione(IdOrd, Me, NumCubetti)

    End Sub

    Private Sub btnEtichettaGls_Click(sender As Object, e As EventArgs) Handles btnEtichettaGls.Click
        If MessageBox.Show("Vuoi ristampare l'etichetta di GLS?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Cursor.Current = Cursors.WaitCursor
            Try
                MgrConsegneCorriere.GLS.EtichettaGls(_C)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub btnSballaTutte_Click(sender As Object, e As EventArgs) Handles btnSballaTutte.Click

        If MessageBox.Show("ATTENZIONE, OPERAZIONE NON REVERSIBILE - Confermi l'eliminazione di tutte le scatole?", "Sballa Scatole", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            For Each Nodo As TreeNode In tvwScatole.Nodes.Item("V").Nodes
                If Nodo.Name.StartsWith("S") Then
                    Dim IdScatola As Integer = Nodo.Name.Substring(1)

                    Using TB As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                        'qui devo cancellare la scatola selezionata dal db e far ricalcolare alla consegna colli e peso
                        Try

                            TB.TransactionBegin()

                            SballaScatola(IdScatola)

                            TB.TransactionCommit()

                        Catch ex As Exception
                            TB.TransactionRollBack()
                            MessageBox.Show("Si è verificato un errore durante l'operazione")
                        End Try

                    End Using

                    _C.AggiornaColliPeso()

                    CaricaConsegnaRelativa()


                End If
            Next

        End If

    End Sub

    Private Sub lnkCalcPeso_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCalcPeso.LinkClicked

        Using f As New frmCalcPesoConsegna

            Sottofondo()
            Dim Ris As Integer = f.Carica
            Sottofondo()

            If Ris Then
                txtPesoConsegna.Text = Ris
            End If

        End Using

    End Sub

End Class