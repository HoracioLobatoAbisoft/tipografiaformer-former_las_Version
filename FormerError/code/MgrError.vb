Imports System.Windows.Forms
Imports FormerLib
Public Class MgrError

    Public Shared Sub InviaSegnalazione(Titolo As String,
                                        Errore As Exception,
                                        Optional AttachFilePath As String = "")
        InternalInviaSegnalazione(Titolo, Errore.Message.Replace(ControlChars.NewLine, "<br>"), AttachFilePath)
    End Sub

    Public Shared Sub InviaSegnalazione(Titolo As String,
                                        buffer As String,
                                        Optional AttachFilePath As String = "")
        InternalInviaSegnalazione(Titolo, buffer, AttachFilePath)
    End Sub

    Private Shared Sub InternalInviaSegnalazione(Titolo As String,
                                                 buffer As String,
                                                 Optional AttachFilePath As String = "")
        Try
            FormerLib.FormerHelper.Mail.InviaMail("Segnalazione Anomalia: " & Titolo, buffer.Replace(ControlChars.NewLine, "<br>"), FormerLib.FormerConst.EmailAssistenzaTecnica,,, AttachFilePath)
        Catch ex As Exception

        End Try

        Try
            My.Application.Log.WriteEntry("Segnalazione Anomalia: " & Titolo & ControlChars.NewLine & ControlChars.NewLine & buffer, TraceEventType.Error)
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub ScriviLogFile(ByVal NomeFile As String, ByVal Testo As String)

        Using objWriter As New System.IO.StreamWriter(NomeFile, True)

            objWriter.WriteLine(Testo)

            objWriter.Close()
        End Using
    End Sub

    Public Shared Function ManageError(ByRef ex As Exception,
                                Optional ByVal dettaglio As String = "",
                                Optional NonGestito As Boolean = False) As Integer
        InviaSegnalazione(ex.Message, ex)
    End Function

End Class
