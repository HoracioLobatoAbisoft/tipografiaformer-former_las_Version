Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports System.ComponentModel
Imports FormerLib

Public Class ucSituazioneClientiOLD
    Inherits ucFormerUserControl
    Private _Ordinamento As System.Windows.Forms.SortOrder = SortOrder.Ascending

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Private Sub CaricaCombo()
        'carico la combo dei clienti
        Dim cli As New VociRubricaDAO
        cmbCliente.ValueMember = "IdRub"
        cmbCliente.DisplayMember = "Nominativo"

        cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, True, "SituazioneContabileGenerale")
    End Sub

    Public Sub Carica()

        CaricaCombo()

    End Sub

    Private Sub AggiornaDati()
        If DgSituazClienti.SelectedRows.Count Then
            Cursor.Current = Cursors.WaitCursor
            Dim M As SituazioneCliente = DgSituazClienti.SelectedRows(0).DataBoundItem
            UcSituazContabEx.IdRub = M.IdRub
            UcSituazContabEx.MostraSituaz()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub DgSituazClienti_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgSituazClienti.CellDoubleClick
        If DgSituazClienti.SelectedRows.Count Then
            Dim M As SituazioneCliente = DgSituazClienti.SelectedRows(0).DataBoundItem
            ParentFormEx.Sottofondo()
            Dim f As New frmVoceRubrica
            f.Carica(M.IdRub)
            f = Nothing
            ParentFormEx.Sottofondo()
        End If
    End Sub

    Private Sub DgSituazClienti_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgSituazClienti.ColumnHeaderMouseClick

        OrdinatoreLista(Of SituazioneCliente).OrdinaLista(sender, e)

    End Sub


    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        Cursor.Current = Cursors.WaitCursor
        Using mgr As New SituazioneClienteDAO
            Dim L As List(Of SituazioneCliente) = mgr.Lista(cmbCliente.SelectedValue)
            DgSituazClienti.AutoGenerateColumns = False
            DgSituazClienti.DataSource = L

        End Using

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub DgSituazClienti_SelectionChanged(sender As Object, e As EventArgs) Handles DgSituazClienti.SelectionChanged
        AggiornaDati()
    End Sub
End Class


