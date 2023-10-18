Imports FormerDALSql
Imports FormerLib.FormerEnum

#Region "Author"

'All rights reserved.

'Author: DC Consulting srl
'Date: Giugno 2008

#End Region

'Imports System.Data.OleDb
Public Class ucMessaggiInterniSmall
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        '' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(pctMonitor)
        'ColoraSfondo(lnkAggiorna)
        'ColoraSfondo(lnkNew)
    End Sub

    Public Sub AttivaTimer()
        If tmrAggiorna.Enabled = False Then tmrAggiorna.Enabled = True
    End Sub

    Public Sub MostraDati()
        Try

            Using mgr As New MessaggiDAO
                Dim l As List(Of Messaggio) = mgr.MessaggiInEntrata(PostazioneCorrente.UtenteConnesso.IdUt, True)

                dgMessRic.AutoGenerateColumns = False
                dgMessRic.DataSourceVirtual = l
                dgMessRic.ClearSelection()
                Dim l2 As List(Of Messaggio) = mgr.MessaggiInUscita(PostazioneCorrente.UtenteConnesso.IdUt, True)

                dgMessInv.AutoGenerateColumns = False
                dgMessInv.DataSourceVirtual = l2
                dgMessInv.ClearSelection()
            End Using
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub DGPostit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    '    If e.KeyCode = Keys.Delete Then

    '        If DGPostit.SelectedItems.Count Then

    '            Dim lv As ListViewItem = DGPostit.SelectedItems(0)
    '            Dim IdPostit As String = lv.Name.Substring(1)
    '            'qui la cancello
    '            Dim sql As String = ""
    '            sql = "UPDATE T_POSTIT SET STATUS=1 WHERE IDPOSTIT=" & IdPostit
    '            lv.Remove()
    '            Dim myCommand As OleDbCommand = _cnOld.CreateCommand()
    '            myCommand.CommandText = sql
    '            myCommand.ExecuteNonQuery()
    '        End If

    '    End If

    'End Sub

    'Private Sub DGPostit_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    '    If DGPostit.SelectedItems.Count Then

    '        Dim lv As ListViewItem = DGPostit.SelectedItems(0)
    '        Dim IdPostit As String = lv.Name.Substring(1)

    '        Dim testo As String = lv.Text, TestoNuovo As String
    '        Dim x As New frmPostit, sql As String = ""
    '        ParentFormerForm.Sottofondo 
    '        TestoNuovo = x.carica(testo)
    '        ParentFormerForm.Sottofondo 
    '        If TestoNuovo.Length Then
    '            If testo <> TestoNuovo Then
    '                'qui la modifico
    '                sql = "UPDATE T_POSTIT SET testo='" & TestoNuovo.Replace("'", "''") & "' WHERE IDPOSTIT=" & IdPostit
    '                lv.Text = TestoNuovo
    '            End If

    '        Else
    '            'qui la cancello
    '            sql = "UPDATE T_POSTIT SET STATUS=1 WHERE IDPOSTIT=" & IdPostit
    '            lv.Remove()

    '        End If
    '        If sql.Length Then
    '            Dim myCommand As OleDbCommand = _cnOld.CreateCommand()
    '            myCommand.CommandText = sql
    '            myCommand.ExecuteNonQuery()
    '        End If
    '    End If

    'End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        ParentFormEx.Sottofondo()
        Dim f As New frmPostit, Ris As Integer = 0
        Ris = f.Carica()
        If Ris Then MostraDati()
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub DGPostit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ucPostit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lnkAggiorna_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        MostraDati()
    End Sub

    Private Sub tmrAggiorna_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAggiorna.Tick

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then MostraDati()

    End Sub

    Private Sub dgMessRic_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMessRic.CellDoubleClick
        If e.RowIndex <> -1 Then
            Dim M As Messaggio = dgMessRic.Rows(e.RowIndex).DataBoundItem

            If M.Letto = False Then
                M.Letto = True
                M.Save()
                dgMessRic.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If

            Using x As New frmPostit
                ParentFormEx.Sottofondo()
                x.Carica(M)
                ParentFormEx.Sottofondo()
            End Using

            MostraDati()

        End If

    End Sub

    Private Sub dgMess_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgMessRic.RowPostPaint
        Dim m As Messaggio = dgMessRic.Rows(e.RowIndex).DataBoundItem
        If m.Letto = False And m.IdDest <> 0 Then
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0)
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
            Dim f As New Font("Segoe UI", 9, FontStyle.Bold)
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.Font = f
        Else
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0)
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64)
            Dim f As New Font("Segoe UI", 9, FontStyle.Regular)
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.Font = f
        End If
    End Sub

    Private Sub dgMessInv_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgMessInv.RowPostPaint
        Dim m As Messaggio = dgMessInv.Rows(e.RowIndex).DataBoundItem
        If m.Letto = False And m.IdDest <> 0 Then
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Red
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64)
        Else
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0)
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64)
        End If
    End Sub

    Private Sub dgMessInv_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMessInv.CellDoubleClick
        If e.RowIndex <> -1 Then
            Dim M As Messaggio = dgMessInv.Rows(e.RowIndex).DataBoundItem

            Dim x As New frmPostit
            ParentFormEx.Sottofondo()
            x.Carica(M)
            ParentFormEx.Sottofondo()
        End If
    End Sub

    Private Sub pctMonitor_Click(sender As System.Object, e As System.EventArgs) Handles pctMonitor.Click
        Dim f As New frmMonitor
        f.Carica()
        f = Nothing
    End Sub

    'Private Sub lnkDel_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked
    '    If tabMess.SelectedTab Is tpRic Then
    '        Dim dr As DataGridViewRow = dgMessRic.SelectedRows(0)
    '        If Not dr Is Nothing Then
    '            Dim m As Messaggio = dr.DataBoundItem
    '            If m.IdDest = Postazione.UtenteConnesso.IdUt Then
    '                If MessageBox.Show("Sicuro di voler cancellare il messaggio?"
    '                End If
    '            End If
    '        Else

    '        End If
    'End Sub

End Class
