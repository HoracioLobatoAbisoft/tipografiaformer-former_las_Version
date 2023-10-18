Imports FormerDALSql
Public Class ucMessaggiInterni
    Inherits ucFormerUserControl
    Private Sub ucMessaggi_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        BackColor = Color.White

        '' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent(). 
        'If LUNA.LunaContext.TotConnAttive Then
        '    ColoraSfondo(lnkAggiorna)
        '    ColoraSfondo(lnkNew)
        '    ColoraSfondo(pctMonitor)
        'End If

    End Sub

    Public ReadOnly Property NumAllegati As Integer
        Get
            Return dgMessRic.Rows.Count
        End Get
    End Property

    Private Sub pctMonitor_Click(sender As System.Object, e As System.EventArgs) Handles pctMonitor.Click
        Using f As New frmMonitor
            f.Carica()
        End Using
    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        MostraDati()
    End Sub

    Private Sub lnkNew_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        ParentFormEx.Sottofondo()
        Dim Ris As Integer = 0
        Dim f As New frmPostit
        Ris = f.Carica()
        If Ris Then MostraDati()
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub CaricaRicevuti()
        Try

            Using mgr As New MessaggiDAO
                Dim l As List(Of Messaggio) = mgr.MessaggiInEntrata(PostazioneCorrente.UtenteConnesso.IdUt)

                dgMessRic.AutoGenerateColumns = False
                dgMessRic.DataSourceVirtual = l

                dgMessRic.ClearSelection()

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CaricaInviati()
        Try

            Using mgr As New MessaggiDAO

                Dim l2 As List(Of Messaggio) = mgr.MessaggiInUscita(PostazioneCorrente.UtenteConnesso.IdUt)

                dgMessInv.AutoGenerateColumns = False
                dgMessInv.DataSourceVirtual = l2
                dgMessInv.ClearSelection()

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub MostraDati()
        CaricaRicevuti()
        CaricaInviati()
    End Sub

    Private Sub dgMessRic_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMessRic.CellDoubleClick
        If e.RowIndex <> -1 Then
            Dim R As DataGridViewRow = dgMessRic.Rows(e.RowIndex)
            ModificaSelezionato(R)
        End If
    End Sub

    Private Sub dgMess_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgMessRic.RowPostPaint
        Dim m As Messaggio = dgMessRic.Rows(e.RowIndex).DataBoundItem
        If m.Letto = False And m.IdDest <> 0 Then
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0)
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64)
        Else
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0)
            dgMessRic.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64)
        End If
    End Sub

    Private Sub dgMessInv_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgMessInv.RowPostPaint
        Dim m As Messaggio = dgMessInv.Rows(e.RowIndex).DataBoundItem
        If m.Letto = False And m.IdDest <> 0 Then
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            dgMessInv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0)
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

    Private Sub ModificaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaToolStripMenuItem.Click

        If dgMessRic.SelectedRows.Count Then
            Dim r As DataGridViewRow = dgMessRic.SelectedRows(0)
            ModificaSelezionato(r)
        End If

    End Sub

    Private Sub EliminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminaToolStripMenuItem.Click

        EliminaSelezionati()

    End Sub

    Private Sub SelezionaTuttoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelezionaTuttoToolStripMenuItem.Click
        SelezionaTutto()
    End Sub

    Private Sub SelezionaTutto()
        dgMessRic.SelectAll()
    End Sub

    Private Sub ModificaSelezionato(ByRef R As DataGridViewRow)

        Dim M As Messaggio = R.DataBoundItem

        If M.Letto = False Then
            M.Letto = True
            M.Save()
            R.DefaultCellStyle.BackColor = Color.White
        End If

        Using x As New frmPostit
            ParentFormEx.Sottofondo()
            x.Carica(M)
            ParentFormEx.Sottofondo()
        End Using

    End Sub

    Private Sub EliminaSelezionati()

        If MessageBox.Show("Confermi la cancellazione di tutti i messaggi selezionati?", "Elimina Messaggi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Using mgr As New MessaggiDAO
                For Each singRow As DataGridViewRow In SelectedGrid.SelectedRows
                    Dim messaggio As Messaggio = singRow.DataBoundItem

                    mgr.Delete(messaggio.IdPostit)

                Next
            End Using

            CaricaRicevuti()

        End If

    End Sub

    Private SelectedGrid As DataGridView = Nothing

    Private Sub dgMessRic_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMessRic.CellClick
        SelectedGrid = dgMessRic
    End Sub

    Private Sub dgMessInv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMessInv.CellClick
        SelectedGrid = dgMessInv
    End Sub

    Private Sub dgMessRic_MouseDown(sender As Object, e As MouseEventArgs) Handles dgMessRic.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim Punto As New Point(MousePosition.X, MousePosition.Y)
            mnuMessaggi.Show(Punto)
        End If
    End Sub
End Class
