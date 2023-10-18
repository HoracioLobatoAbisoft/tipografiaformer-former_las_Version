Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucCommesseRegoleCalcolo
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub CaricaDati()
        Using mgr As New RegoleCalcoloDAO
            Dim l As List(Of RegolaCalcolo) = mgr.GetAll("TipoRegola, Nome")
            DgRegole.AutoGenerateColumns = False
            DgRegole.DataSource = l
        End Using
    End Sub

    Private Sub lnkAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked

        CaricaDati()

    End Sub

    Private Sub DgRegole_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DgRegole.RowPrePaint

        'Dim Row As DataGridViewRow = DgRegole.Rows(e.RowIndex)
        'Using R As RegolaCalcolo = Row.DataBoundItem
        '    If R.TipoRegola = enTipoRegola.DiSistema Then
        '        For Each C As DataGridViewCell In Row.Cells
        '            C.Style.Font = New Font("Segoe UI", 9, FontStyle.Italic)
        '        Next
        '    End If
        'End Using

    End Sub

    Private Sub NuovaRegola()
        ParentFormEx.Sottofondo()
        Using f As New frmCommessaRegoleCalcolo
            If f.Carica() Then CaricaDati()
        End Using
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        NuovaRegola
    End Sub

    Private Sub DgRegole_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgRegole.CellContentClick

    End Sub

    Private Sub DgRegole_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgRegole.CellContentDoubleClick

    End Sub

    Private Sub DgRegole_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgRegole.CellDoubleClick

        ModificaRegola()

    End Sub

    Private Sub ModificaRegola()
        If DgRegole.SelectedRows.Count Then

            Dim Riga As DataGridViewRow = DgRegole.SelectedRows(0)
            Dim R As RegolaCalcolo = Riga.DataBoundItem

            ParentFormEx.Sottofondo()
            Using f As New frmCommessaRegoleCalcolo
                If f.Carica(R.IdRegola) Then CaricaDati()
            End Using
            ParentFormEx.Sottofondo()
        Else
            Beep()
        End If
    End Sub

    Private Sub lnkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEdit.LinkClicked
        ModificaRegola()
    End Sub

    Private Sub EliminaRegola()
        If DgRegole.SelectedRows.Count Then

            Dim Riga As DataGridViewRow = DgRegole.SelectedRows(0)
            Dim R As RegolaCalcolo = Riga.DataBoundItem

            If R.TipoRegola = enTipoRegola.DiSistema Then
                MessageBox.Show("Impossibile eliminare una regola di Sistema")
            Else
                If MessageBox.Show("Confermi l'eliminazione della Regola di Calcolo '" & R.Nome & "'?", "Eliminazione Regola", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Using mgr As New RegoleCalcoloDAO
                        mgr.Delete(R.IdRegola)
                    End Using
                    CaricaDati()
                End If
            End If

        Else
                Beep()
        End If
    End Sub

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked
        EliminaRegola()
    End Sub
End Class
