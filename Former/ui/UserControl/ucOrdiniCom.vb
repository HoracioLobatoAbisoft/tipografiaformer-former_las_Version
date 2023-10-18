Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucOrdiniCom
    Inherits ucFormerUserControl

    Private _SolaLettura As Boolean = False
    Public Property SolaLettura As Boolean
        Get
            Return _SolaLettura
        End Get
        Set(value As Boolean)
            _SolaLettura = value
        End Set
    End Property

    Private _idTipoCom As Integer
    Public Property IdTipoCom() As Integer
        Get
            Return _idTipoCom
        End Get
        Set(ByVal value As Integer)
            _idTipoCom = value

        End Set
    End Property

    Private _RepartoCom As enRepartoWeb = enRepartoWeb.StampaOffset
    Public Property RepartoCom As enRepartoWeb
        Get
            Return _RepartoCom
        End Get
        Set(value As enRepartoWeb)
            _RepartoCom = value
        End Set
    End Property

    Private _idCom As Integer
    Public Property IdCom() As Integer
        Get
            Return _idCom
        End Get
        Set(ByVal value As Integer)
            _idCom = value

        End Set
    End Property

    Public ReadOnly Property ListaOrdiniSelezionati As List(Of Ordine)
        Get
            Dim ris As New List(Of Ordine)

            For Each Id As Integer In ListaIdSelezionati
                Using O As New Ordine
                    O.Read(Id)
                    ris.Add(O)
                End Using
            Next

            Return ris
        End Get
    End Property

    Public ReadOnly Property ListaIdSelezionati() As Integer()
        Get
            Dim x As Integer() = Nothing

            If DGOrdiniSel.Rows.Count Then

                Array.Resize(x, DGOrdiniSel.Rows.Count)

                Dim dr As DataGridViewRow
                For Each dr In DGOrdiniSel.Rows
                    x.SetValue(dr.Cells(0).Value, dr.Index)
                Next
            Else
                Array.Resize(x, 0)
            End If

            Return x

        End Get
    End Property

    Public Sub Carica(Optional ByVal ListaIdOrd As String = "")
        'FormerDebug.Traccia()
        'carico la lista delle lavorazioni 
        'se mi viene passato l'id del prodotto carico dal db le check su quelle selezionate
        DGOrdiniDisp.Rows.Clear()
        DGOrdiniSel.Rows.Clear()

        Dim LDisp As List(Of Ordine) = Nothing

        Using mgr As New OrdiniDAO
            Dim ListaReparti As String = String.Empty

            If RepartoCom = enRepartoWeb.Packaging Or RepartoCom = enRepartoWeb.StampaOffset Then
                ListaReparti = "(" & enRepartoWeb.Packaging & "," & enRepartoWeb.StampaOffset & ")"
            Else
                ListaReparti = "(" & RepartoCom & ")"
            End If

            If ListaIdOrd.Length Then
                LDisp = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "(" & ListaIdOrd & ")", " NOT IN "),
                                    New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, 0),
                                    New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Registrato),
                                    New LUNA.LunaSearchParameter(LFM.Ordine.IdTipoProd, ListaReparti, " IN "))
            Else
                LDisp = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, 0),
                                    New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Registrato),
                                    New LUNA.LunaSearchParameter(LFM.Ordine.IdTipoProd, ListaReparti, " IN "))
            End If

        End Using

        For Each singO As Ordine In LDisp

            Dim Riga As New DataGridViewRow
            Riga.CreateCells(DGOrdiniDisp)

            Riga.Cells(0).Value = singO.Numero
            Riga.Cells(1).Value = singO.Numero
            Riga.Cells(2).Value = singO.Prodotto.Descrizione
            Riga.Cells(3).Value = singO.QtaOrdine
            Riga.Cells(4).Value = singO.DescrizioneCliente
            Riga.Cells(5).Value = singO.StatoStr
            Riga.Cells(6).Value = singO.Totale
            If Not singO.ConsegnaAssociata Is Nothing Then
                Riga.Cells(7).Value = singO.ConsegnaAssociata.Giorno.ToString("dd/MM/yyyy")
            Else
                Riga.Cells(7).Value = singO.DataPrevConsegna.ToString("dd/MM/yyyy")
            End If

            DGOrdiniDisp.Rows.Add(Riga)

            Riga = Nothing

        Next

        DGOrdiniDisp.Columns(0).Visible = False

        Dim L As List(Of Ordine) = Nothing

        Using mgr As New OrdiniDAO
            If ListaIdOrd.Length Then
                L = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "(" & ListaIdOrd & ")", "IN"))
            Else
                If _idCom Then
                    L = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, _idCom))
                End If

            End If

        End Using
        If Not L Is Nothing Then
            For Each singO As Ordine In L

                Dim Riga As New DataGridViewRow
                Riga.CreateCells(DGOrdiniSel)

                Riga.Cells(0).Value = singO.Numero
                Riga.Cells(1).Value = singO.Numero
                Riga.Cells(2).Value = singO.Prodotto.Descrizione
                Riga.Cells(3).Value = singO.QtaOrdine
                Riga.Cells(4).Value = singO.DescrizioneCliente
                Riga.Cells(5).Value = singO.StatoStr
                Riga.Cells(6).Value = singO.Totale
                If Not singO.ConsegnaAssociata Is Nothing Then
                    Riga.Cells(7).Value = singO.ConsegnaAssociata.Giorno.ToString("dd/MM/yyyy")
                Else
                    Riga.Cells(7).Value = singO.DataPrevConsegna.ToString("dd/MM/yyyy")
                End If

                DGOrdiniSel.Rows.Add(Riga)

                Riga = Nothing

            Next
        End If

        DGOrdiniSel.Columns(0).Visible = False

    End Sub

    Private Sub lnkAggiungi_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiungi.LinkClicked

        AggiungiLav()

    End Sub

    Private Sub AggiungiLav()

        If SolaLettura Then
            MessageBox.Show("Non è  possibile modificare la lista degli ordini")
        Else

            If DGOrdiniDisp.SelectedRows.Count Then

                Dim Dr As DataGridViewRow = DGOrdiniDisp.SelectedRows(0)
                If Dr.Selected Then
                    'sposto la lavorazione tra quelle selezionate
                    'qui prima di aggiungere un ordine devo fare i controlli per capire se l'ordine è compatibile con quelli gia presenti
                    Dim okLav As Boolean = True
                    Dim L As New List(Of LavLog)

                    If IdCom Then
                        'qui devo controllare la commessa e non gli ordini
                        Dim IdOrdSing As Integer = Dr.Cells(0).Value
                        Using C As New Commessa
                            C.Read(IdCom)
                            Using O As New Ordine
                                O.Read(IdOrdSing)
                                For Each lav As Lavorazione In O.ListaLavori.FindAll(Function(x) x.Accorpabile = enSiNo.Si And x.Esclusiva = enSiNo.Si And x.LavorazioneInterna = enSiNo.No)
                                    If C.ListaLavLog.FindAll(Function(x) x.Idlav = lav.IdLavoro).Count = 0 Then
                                        L.Add(O.ListLavLog.Find(Function(x) x.Idlav = lav.IdLavoro))
                                    End If
                                Next

                                For Each lav As LavLog In C.ListaLavLog
                                    If O.ListLavLog.FindAll(Function(x) x.Idlav = lav.Idlav).Count = 0 Then
                                        If L.FindAll(Function(y) y.Idlav = lav.Idlav).Count = 0 Then L.Add(lav)
                                    End If
                                Next

                            End Using
                        End Using
                    Else
                        'qui devo controllare gli ordini
                        Dim ListaIdOrd As String = String.Empty

                        For Each singRow As DataGridViewRow In DGOrdiniSel.Rows
                            ListaIdOrd &= singRow.Cells(0).Value & ","
                        Next

                        ListaIdOrd &= Dr.Cells(0).Value

                        For Each Id As String In ListaIdOrd.Split(",")
                            Using o As New Ordine
                                o.Read(Id)

                                For Each lav As Lavorazione In o.ListaLavori.FindAll(Function(x) x.Accorpabile = enSiNo.Si And x.Esclusiva = enSiNo.Si And x.LavorazioneInterna = enSiNo.No)
                                    'la devo cercare in tutte le altre lavorazioni degli altri ordini
                                    For Each IdOther As String In ListaIdOrd.Split(",")
                                        If IdOther <> Id Then
                                            Using oInt As New Ordine
                                                oInt.Read(IdOther)
                                                If oInt.ListaLavori.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count = 0 Then
                                                    If L.FindAll(Function(x) x.Idlav = lav.IdLavoro).Count = 0 Then L.Add(o.ListLavLog.Find(Function(x) x.Idlav = lav.IdLavoro))
                                                End If
                                            End Using
                                        End If
                                    Next
                                Next

                            End Using
                        Next
                    End If

                    If L.Count Then

                        Dim bufLav As String = String.Empty
                        For Each Lav As LavLog In L
                            bufLav &= Lav.Descrizione & ", "
                        Next

                        bufLav = bufLav.TrimEnd(" ", ",")

                        MessageBox.Show("Le seguenti lavorazioni ACCORPABILI e ESCLUSIVE non sono previsti su tutti gli ordini selezionati: " &
                                    ControlChars.NewLine & bufLav & ControlChars.NewLine &
                                    "Modificare gli ordini per renderli compatibili tra loro.", "Ordini non compatibili", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        okLav = False
                    End If

                    If okLav Then
                        Dim Riga As New DataGridViewRow
                        Riga.CreateCells(DGOrdiniSel)

                        Riga.Cells(0).Value = Dr.Cells(0).Value
                        Riga.Cells(1).Value = Dr.Cells(1).Value
                        Riga.Cells(2).Value = Dr.Cells(2).Value
                        Riga.Cells(3).Value = Dr.Cells(3).Value
                        Riga.Cells(4).Value = Dr.Cells(4).Value
                        Riga.Cells(5).Value = Dr.Cells(5).Value
                        Riga.Cells(6).Value = Dr.Cells(6).Value
                        'Riga.Cells(3).Value = Dr.Cells(3).Value

                        DGOrdiniSel.Rows.Add(Riga)
                        DGOrdiniDisp.Rows.Remove(DGOrdiniDisp.SelectedRows(0))

                        Riga = Nothing
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub DettLav()
        If DGOrdiniDisp.SelectedRows.Count Then
            Dim Dr As DataGridViewRow = DGOrdiniDisp.SelectedRows(0)
            If Dr.Selected Then
                'sposto la lavorazione tra quelle selezionate
                ParentFormEx.Sottofondo()
                Dim x As New frmOrdine
                x.Carica(Dr.Cells(0).Value)
                x = Nothing
                ParentFormEx.Sottofondo()
            End If
        End If
    End Sub

    Private Sub DettLavSel()
        If DGOrdiniSel.SelectedRows.Count Then
            Dim Dr As DataGridViewRow = DGOrdiniSel.SelectedRows(0)
            If Dr.Selected Then
                'sposto la lavorazione tra quelle selezionate
                ParentFormEx.Sottofondo()
                Dim x As New frmOrdine
                x.Carica(Dr.Cells(0).Value)
                x = Nothing
                ParentFormEx.Sottofondo()
            End If
        End If
    End Sub

    Private Sub lnkDel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked
        RimuoviLav()
    End Sub

    Private Sub DgLavorazioni_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOrdiniDisp.CellClick, DGOrdiniSel.CellClick

        If sender.SelectedRows.Count Then

            'qui si tratta di un ordine, mi prendo l'id e faccio la preview
            Dim IdOrd As Integer = 0

            IdOrd = sender.SelectedRows(0).Cells(0).value
            ShowPreview(IdOrd)

        End If

    End Sub

    Private Sub ShowPreview(ByVal IdOrd As Integer)
        Try
            Cursor.Current = Cursors.WaitCursor

            UcOrdineAnteprima.Carica(IdOrd)

            Cursor.Current = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RimuoviLav()
        If SolaLettura Then
            MessageBox.Show("Non è  possibile modificare la lista degli ordini")
        Else
            If DGOrdiniSel.SelectedRows.Count Then
                Dim Dr As DataGridViewRow = DGOrdiniSel.SelectedRows(0)
                If Dr.Selected Then
                    'sposto la lavorazione tra quelle selezionate

                    Dim Riga As New DataGridViewRow
                    Riga.CreateCells(DGOrdiniDisp)

                    Riga.Cells(0).Value = Dr.Cells(0).Value
                    Riga.Cells(1).Value = Dr.Cells(1).Value
                    Riga.Cells(2).Value = Dr.Cells(2).Value
                    Riga.Cells(3).Value = Dr.Cells(3).Value
                    Riga.Cells(4).Value = Dr.Cells(4).Value
                    Riga.Cells(5).Value = Dr.Cells(5).Value
                    Riga.Cells(6).Value = Dr.Cells(6).Value
                    'Riga.Cells(3).Value = Dr.Cells(3).Value


                    DGOrdiniDisp.Rows.Add(Riga)
                    DGOrdiniSel.Rows.Remove(DGOrdiniSel.SelectedRows(0))

                    Riga = Nothing

                End If
            End If
        End If

    End Sub

    Private Sub DgLavorazioni_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOrdiniDisp.CellDoubleClick
        AggiungiLav()
    End Sub

    Private Sub DGLavorazioniSel_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOrdiniSel.CellDoubleClick
        RimuoviLav()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        BackColor = Color.White

        DGOrdiniDisp.Columns.Add("IdOrd", "IdOrd")
        DGOrdiniDisp.Columns.Add("Numero", "Numero")
        DGOrdiniDisp.Columns.Add("Prodotto", "Prodotto")
        DGOrdiniDisp.Columns.Add("Quantita", "Quantita")
        DGOrdiniDisp.Columns.Add("Cliente", "Cliente")
        DGOrdiniDisp.Columns.Add("Stato", "Stato")
        DGOrdiniDisp.Columns.Add("Prezzo", "Prezzo")
        DGOrdiniDisp.Columns.Add("Consegna", "Consegna")

        DGOrdiniDisp.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGOrdiniDisp.Columns(6).DefaultCellStyle.Format = "0.00"

        DGOrdiniSel.Columns.Add("IdOrd", "IdOrd")
        DGOrdiniSel.Columns.Add("Numero", "Numero")
        DGOrdiniSel.Columns.Add("Prodotto", "Prodotto")
        DGOrdiniSel.Columns.Add("Quantita", "Quantita")
        DGOrdiniSel.Columns.Add("Cliente", "Cliente")
        DGOrdiniSel.Columns.Add("Stato", "Stato")
        DGOrdiniSel.Columns.Add("Prezzo", "Prezzo")
        DGOrdiniSel.Columns.Add("Consegna", "Consegna")
        ' Add any initialization after the InitializeComponent() call.
        DGOrdiniSel.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGOrdiniSel.Columns(6).DefaultCellStyle.Format = "0.00"

        UcOrdineAnteprima.NoLavori = True

    End Sub

    Private Sub lnkOrd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOrd.LinkClicked

        DettLav()

    End Sub

    Private Sub lnkDettLavSel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDettLavSel.LinkClicked

        DettLavSel()

    End Sub

    Private Sub DGOrdiniDisp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGOrdiniDisp.CellContentClick

    End Sub
End Class
