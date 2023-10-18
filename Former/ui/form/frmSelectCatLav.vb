Imports FormerDALSql
Imports FormerBusinessLogic
Imports FormerLib.FormerEnum

Friend Class frmSelectCatLav
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0

    Private Sub CaricaCombo()

        Using mgr As New CatLavDAO

            cmbLB.ValueMember = "IdCatLav"
            cmbLB.DisplayMember = "Descrizione"

            Dim IdTCDaEsc As String = String.Empty


            '    Using mgrC As New CatLavDAO
            Dim BufferIdCatLavEscluse As String = String.Empty
            If _IdLbEscluso Then
                Dim lC As List(Of CatLav) = mgr.GetBySQL("select distinct c.* from td_Catlav c, T_lavori l, TR_lavprev lp where c.idcatlav = l.idcatlav and l.idlavoro = lp.idlavoro and lp.idlistinobase =" & _IdLbEscluso)

                For Each voce In lC
                    BufferIdCatLavEscluse &= voce.IdCatLav & ","
                Next

                BufferIdCatLavEscluse = BufferIdCatLavEscluse.TrimEnd(",")

            End If

            Dim p As LUNA.LSP = Nothing

            If BufferIdCatLavEscluse.Length Then
                BufferIdCatLavEscluse = "(" & BufferIdCatLavEscluse & ")"
                p = New LUNA.LSP(LFM.CatLav.IdCatLav, BufferIdCatLavEscluse, " NOT IN ")
            End If

            Dim l As List(Of CatLav) = mgr.FindAll("Descrizione", p)
            cmbLB.DataSource = l
            '   End Using


        End Using

    End Sub

    Private _IdLbEscluso As Integer = 0

    Friend Function Carica(IdLbEscluso As Integer) As Integer

        _IdLbEscluso = IdLbEscluso

        CaricaCombo()

        ShowDialog()

        Return _Ris

    End Function

    'Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    Dim x As Char = vbCr
    '    If e.KeyChar = x Then
    '        e.Handled = True
    '        SendKeys.Send(vbTab)

    '    End If
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi la scelta della categoria di lavorazioni selezionate?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'qui controllo se c'e' gia e avviso 

            Dim fp As CatLav = DirectCast(cmbLB.SelectedItem, CatLav)

            _Ris = fp.IdCatLav

            Close()


        End If

    End Sub

End Class