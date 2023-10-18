Public Class FormerDaemonService
    Private MainForm As frmMain = Nothing
    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Inserire qui il codice necessario per avviare il proprio servizio. Il metodo deve effettuare
        ' le impostazioni necessarie per il funzionamento del servizio.
        MainForm = New frmMain
        MainForm.Show()
    End Sub

    Protected Overrides Sub OnStop()
        ' Inserire qui il codice delle procedure di chiusura necessarie per arrestare il proprio servizio.
        If MainForm Is Nothing Then
            MainForm.Close()
            MainForm = Nothing
        End If
    End Sub
End Class