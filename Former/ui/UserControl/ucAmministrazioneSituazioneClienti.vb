Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class ucAmministrazioneSituazioneClienti
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        MgrControl.InizializeGridview(DgClienti, True)
        CaricaCombo()
    End Sub

    Public Sub CaricaCombo()

        Dim lStatoI As New List(Of cEnum)
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Tutto, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Tutto)})
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Normale, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Normale)})
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Problematico, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Problematico)})
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Difficile, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Difficile)})
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Impossibile, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Impossibile)})

        cmbStatoIncasso.ValueMember = "Id"
        cmbStatoIncasso.DisplayMember = "Descrizione"
        cmbStatoIncasso.DataSource = lStatoI

    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        CaricaDati()
    End Sub

    Private _ColoriAnni As New Dictionary(Of Integer, Color)

    Private Sub EstraiAnni(L As List(Of RisSituazioneCliente))
        _ColoriAnni = New Dictionary(Of Integer, Color)
        For Each Situaz In L
            For Each anno In Situaz.ListaAnniDocumenti
                If _ColoriAnni.ContainsKey(anno) = False Then
                    Dim coloreCasuale As Color

                    Dim Esci As Boolean = False

                    Do
                        coloreCasuale = FormerColori.GetColoreCasuale()

                        If _ColoriAnni.ContainsValue(coloreCasuale) = False Then
                            Esci = True
                        End If

                    Loop Until Esci = True

                    _ColoriAnni(anno) = coloreCasuale

                End If
            Next
        Next

    End Sub

    Private Sub CaricaDati()
        Cursor.Current = Cursors.WaitCursor
        Dim L As List(Of RisSituazioneCliente) = MgrSituazioneCliente.GetSituazioneClienti(, cmbStatoIncasso.SelectedValue)

        L.Sort(AddressOf Comparer)
        EstraiAnni(L)
        DgClienti.DataSource = L

        Cursor.Current = Cursors.Default

    End Sub

    Private Function Comparer(ByVal x As RisSituazioneCliente, ByVal y As RisSituazioneCliente) As Integer
        Dim result As Integer = y.TotaleScopertoComplessivo.CompareTo(x.TotaleScopertoComplessivo)
        If result = 0 Then result = x.DataUltimoPagamento.CompareTo(y.DataUltimoPagamento) 'x.RagSocNome.CompareTo(y.RagSocNome)

        Return result
    End Function

    Private Sub DgClienti_Click(sender As Object, e As EventArgs) Handles DgClienti.Click

    End Sub

    Private Sub DgClienti_CellClick(sender As Object, e As GridViewCellEventArgs) Handles DgClienti.CellClick

        If DgClienti.SelectedRows.Count Then
            Dim R As GridViewRowInfo = e.Row

            Dim VoceSel As RisSituazioneCliente = R.DataBoundItem
            If Not VoceSel Is Nothing Then
                UcSituazPagam.IdRub = VoceSel.IdRub
                UcSituazPagam.MostraSituaz()
                UcDocumentiFiscali.IdRub = VoceSel.IdRub
                UcOrdini.IdRub = VoceSel.IdRub
                UcOrdini.Carica(False)
                'UcDocumentiFiscali.SelectAllYear()
            End If

        End If

    End Sub

    Private Sub DgClienti_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles DgClienti.CellDoubleClick

        If DgClienti.SelectedRows.Count Then
            Dim R As GridViewRowInfo = e.Row

            Dim VoceSel As RisSituazioneCliente = R.DataBoundItem

            If Not VoceSel Is Nothing Then
                ParentFormEx.Sottofondo()

                Using f As New frmVoceRubrica
                    f.Carica(VoceSel.IdRub)
                End Using

                ParentFormEx.Sottofondo()
            End If

        End If

    End Sub

    Private Sub DgClienti_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgClienti.CellFormatting

        If e.CellElement.ColumnInfo.Name = "TotaleScopertoComplessivo" Then
            e.CellElement.BackColor = Color.Red
            e.CellElement.ForeColor = Color.White
        ElseIf e.CellElement.ColumnInfo.Name = "TotaleIncassati" Then
            e.CellElement.BackColor = Color.Green
            e.CellElement.ForeColor = Color.White
        ElseIf e.CellElement.ColumnInfo.Name = "DataUltimoLavoro" Then
            Dim Valore As Date = e.CellElement.Value

            Dim colore As Color = Color.White
            _ColoriAnni.TryGetValue(Valore.Year, colore)
            e.CellElement.BorderBottomWidth = 3
            e.CellElement.BorderBottomColor = colore

            'e.CellElement.ForeColor = FormerColori.GetForeColor(e.CellElement.BackColor)

        ElseIf e.CellElement.ColumnInfo.Name = "DataUltimoPagamento" Then

            Dim Valore As Date = e.CellElement.Value
            Dim colore As Color = Color.White
            _ColoriAnni.TryGetValue(Valore.Year, colore)
            e.CellElement.BorderBottomWidth = 3
            e.CellElement.BorderBottomColor = colore
            'e.CellElement.ForeColor = FormerColori.GetForeColor(e.CellElement.BackColor)

        Else
            'e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
            'e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
            e.CellElement.BorderBottomWidth = 3
        End If
    End Sub

    Private Sub lnkStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        StampaGlobale("Situazione Clienti", DgClienti, False)
    End Sub

End Class
