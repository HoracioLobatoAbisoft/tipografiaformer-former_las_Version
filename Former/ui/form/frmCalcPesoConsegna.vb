Imports FormerBusinessLogicInterface

Friend Class frmCalcPesoConsegna
    'Inherits baseFormInternaFixed

    Private _Ris As Integer = 0
    Private _PesoConsegna As Integer = 0

    Friend Function Carica() As Integer

        ShowDialog()

        Return _PesoConsegna

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        _PesoConsegna = 0
        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il peso complessivo della consegna?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Close()

        End If

    End Sub

    Private Sub dgScatole_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgScatole.CellContentClick

    End Sub

    Private Sub dgScatole_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgScatole.CellEndEdit

        Dim cell As DataGridViewCell = dgScatole.Rows(e.RowIndex).Cells(e.ColumnIndex)

        Try
            cell.Value = CInt(cell.Value)
        Catch ex As Exception
            cell.Value = ""
        End Try

        For Each cellS As DataGridViewCell In dgScatole.Rows(e.RowIndex).Cells
            If cellS.Value Is Nothing OrElse cellS.Value.ToString.Length = 0 Then
                cellS.Style.BackColor = Color.Red
            Else
                cellS.Style.BackColor = Color.White
            End If
        Next

        CalcolaPesoConsegna()

    End Sub

    Private Sub CalcolaPesoConsegna()

        Dim Ris As Integer = 0

        For Each r As DataGridViewRow In dgScatole.Rows

            Dim A As Integer = 0
            Dim L As Integer = 0
            Dim P As Integer = 0
            Dim K As Integer = 0

            Try
                A = r.Cells(0).Value
                L = r.Cells(1).Value
                P = r.Cells(2).Value
                K = r.Cells(3).Value

            Catch ex As Exception

            End Try

            If A <> 0 Or L <> 0 Or P <> 0 Or K <> 0 Then
                If A <> 0 And L <> 0 And P <> 0 And K <> 0 Then
                    Dim Pv As Integer = MgrCorriere.CalcolaPesoVolumetrico(A, L, P)
                    r.Cells(4).Value = Pv
                    If Pv > K Then
                        Ris += Pv
                    Else
                        Ris += K
                    End If

                Else
                    r.Cells(4).Value = "-"
                    Ris = 0
                    Exit For
                End If
            End If

        Next

        _PesoConsegna = Ris

        If Ris = 0 Then
            lblRis.Text = "Inserisci i dati di ogni scatola nella lista"
        Else
            lblRis.Text = "Il peso complessivo calcolato della consegna è " & Ris & " kg"
        End If

    End Sub

    Private Sub dgScatole_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgScatole.RowsRemoved
        CalcolaPesoConsegna()
    End Sub
End Class