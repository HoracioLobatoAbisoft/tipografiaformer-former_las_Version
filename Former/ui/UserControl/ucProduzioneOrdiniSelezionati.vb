Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucProduzioneOrdiniSelezionati


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'BackColor = Color.White
    End Sub

    Private _L As List(Of OrdineRicerca)
    Public Sub Carica(L As List(Of OrdineRicerca))

        If L Is Nothing Then
            _L = New List(Of OrdineRicerca)
        Else
            _L = L
        End If

        CaricaNodi()

    End Sub

    Private Sub CaricaNodi()
        Cursor.Current = Cursors.WaitCursor
        tvwOrdini.Nodes.Clear()
        'controllo se gli ordini sono compatibili e li raggruppo per 
        Dim OrdiniCompatibili As Boolean = True
        If _L.Count Then
            Dim O As Ordine = _L(0)
            Dim lLavEscl As List(Of Lavorazione) = O.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
            For Each singO As OrdineRicerca In _L.FindAll(Function(x) x.IdOrd <> O.IdOrd)
                If singO.ListinoBase.IdTipoCarta = O.ListinoBase.IdTipoCarta Then
                    Dim OkLav As Boolean = True
                    For Each singLav In lLavEscl
                        If singO.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
                            OkLav = False
                            Exit For
                        End If
                    Next
                    If OkLav Then
                        Using mgr As New OrdiniDAO
                            OkLav = mgr.IsOrdineCompatibile(singO, _L)
                        End Using
                    End If
                    If OkLav = False Then
                        OrdiniCompatibili = False
                        Exit For
                    End If
                Else
                    OrdiniCompatibili = False
                    Exit For
                End If
            Next
        End If

        If OrdiniCompatibili Then
            For Each O As OrdineRicerca In _L
                Dim NodoFormProd As TreeNode = Nothing
                Dim ChiaveFP As String = "F" & O.ListinoBase.IdFormProd
                NodoFormProd = tvwOrdini.Nodes(ChiaveFP)
                If NodoFormProd Is Nothing Then
                    NodoFormProd = New TreeNode
                    NodoFormProd.Name = ChiaveFP
                    NodoFormProd.ImageIndex = 0
                    NodoFormProd.Text = O.ListinoBase.FormatoProdotto.Formato
                    tvwOrdini.Nodes.Add(NodoFormProd)
                End If

                'qui mo cerco la numerosita di questo ordine 
                Dim NodoQta As TreeNode = Nothing
                Dim ChiaveRic As String = "R" & O.CalcoloSoluzioniQTA
                NodoQta = NodoFormProd.Nodes(ChiaveRic)
                If NodoQta Is Nothing Then
                    NodoQta = New TreeNode
                    NodoQta.Name = ChiaveRic
                    NodoQta.ImageIndex = 1
                    NodoQta.SelectedImageIndex = 1
                    NodoQta.Text = O.CalcoloSoluzioniQTA & " (1)"
                    NodoQta.Tag = 1
                    NodoFormProd.Nodes.Add(NodoQta)
                Else
                    NodoQta.Tag += 1
                    NodoQta.Text = O.CalcoloSoluzioniQTA & " (" & NodoQta.Tag & ")"
                End If
            Next
        Else
            Dim NodoErrore As New TreeNode
            NodoErrore.Name = "Err"
            NodoErrore.ImageIndex = 2
            NodoErrore.SelectedImageIndex = 2
            NodoErrore.Text = "Ordini non compatibili"
            NodoErrore.BackColor = Color.Red
            tvwOrdini.Nodes.Add(NodoErrore)
        End If

        tvwOrdini.Sort()
        tvwOrdini.ExpandAll()
        Cursor.Current = Cursors.Default
    End Sub

End Class
