Public Class MessageBox

    Public Shared Function Show(Message As String,
                                Optional Caption As String = "",
                                Optional Buttons As System.Windows.Forms.MessageBoxButtons = MessageBoxButtons.OK,
                                Optional Icon As System.Windows.Forms.MessageBoxIcon = MessageBoxIcon.Exclamation) As System.Windows.Forms.DialogResult
        Dim Ris As System.Windows.Forms.DialogResult
        Using f As New baseFormMessagebox
            Ris = f.Show(Message, Caption, Buttons, Icon)
        End Using
        Return Ris

    End Function

End Class