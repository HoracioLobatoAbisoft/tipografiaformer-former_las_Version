Imports FormerDALSql
Imports FormerLib

Friend Class frmLocked
    'Inherits frmUsbResponsiveForm

    Private _Ris As Integer = 1
    Friend Sub Carica()

        'qui mi devo disconnettere 

        'formattiva
        'AttivaAscolto()
        'Show(FormPrincipale)

        Location = New Point(80, 80)

        PostazioneCorrente.ChiudiSessioneLavoro()

        ShowDialog()

    End Sub

    Friend Sub Chiudi()
        Close()
    End Sub

    Private Sub btnChiudi_Click(sender As Object, e As EventArgs) Handles btnChiudi.Click
        'If MessageBox.Show("Confermi la chiusura del gestionale?", "Chiusura forzata", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        UpdateAppAtShutdown = True
        Application.Exit()

        'End If
    End Sub
End Class