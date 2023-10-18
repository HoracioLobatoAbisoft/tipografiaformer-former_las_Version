Imports FormerDALSql
Imports FormerBusinessLogic

Friend Class frmSelectLB
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0

    Private Sub CaricaCombo()

        Using mgr As New ListinoBaseDAO

            cmbLB.ValueMember = "IdListinoBase"
            cmbLB.DisplayMember = "Nome"
            cmbLB.DataSource = mgr.GetListiniBaseProduzione

        End Using

    End Sub

    Friend Function Carica(Cat As CatVirtuale) As Integer

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

        If MessageBox.Show("Confermi il listino base selezionato?", "Seleziona Listino base", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            _Ris = cmbLB.SelectedValue

            Close()

        End If

    End Sub

    'Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

    '    If MessageBox.Show("Confermi l'inserimento dell'offerta nel template?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '        'qui controllo se c'e' gia e avviso 

    '        Dim OkDoppioni As Boolean = True
    '        Using mgr As New ListinoBaseSuTemplateDAO
    '            Dim l As List(Of ListinoBaseSuTemplate) = mgr.FindAll(New LUNA.LunaSearchParameter("IdListinoBase", cmbLB.SelectedValue),
    '                                                                  New LUNA.LunaSearchParameter("IdTmOff", _IdTmOff))
    '            If l.Count Then
    '                Dim qta As String = String.Empty

    '                For Each sing In l
    '                    qta &= sing.Qta & ";"
    '                Next

    '                If MessageBox.Show("Questo ListinoBase e' stato già inserito in questo Filtro Marketing con quantità " & qta & " confermi il salvataggio?", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
    '                    OkDoppioni = False
    '                End If

    '            End If
    '        End Using

    '        If OkDoppioni Then


    '            Close()
    '        End If

    '    End If

    'End Sub

End Class