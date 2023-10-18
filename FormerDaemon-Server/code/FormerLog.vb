Imports System.IO
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class FormerLog

    Protected Shared PathLocale As String = AppDomain.CurrentDomain.BaseDirectory

    Public Shared ReadOnly Property PathLog As String
        Get
            Return PathLocale & "log"
        End Get
    End Property

    Public Shared Sub LogMe(ByRef txtLog As TextBox,
                            ByRef lblLastOp As Label,
                            ModuleName As String,
                            ModuleSigla As String,
                            Text As String,
                            Optional DontStore As Boolean = False,
                            Optional Errore As Exception = Nothing,
                            Optional TagLabel As String = "",
                            Optional WithEmail As Boolean = True)

        Dim Msg As String = Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & "." & Now.Second.ToString("00") & " - "

        Dim MsgCore As String = String.Empty

        If Not Errore Is Nothing Then
            MsgCore &= "EXCEPTION "
        End If
        MsgCore &= Text

        If Not Errore Is Nothing Then

            MsgCore &= ControlChars.NewLine & " MAIN EXCEPTION: " & Errore.Message

            Dim except As System.Exception = Errore.InnerException
            Dim countEx As Integer = 1

            Try
                Do Until except Is Nothing

                    MsgCore &= ControlChars.NewLine & "INNER EXCEPTION (" & countEx & "): " & except.Message
                    MsgCore &= ControlChars.NewLine & "INNER EXCEPTION (" & countEx & ") STACKTRACE: " & except.StackTrace.Replace(" in ", "<br>in ")

                    except = except.InnerException

                    countEx += 1
                Loop
            Catch ex As Exception

            End Try


        End If

        Msg &= MsgCore

        If Not txtLog Is Nothing Then
            Dim OldMsg As String = txtLog.Text

            OldMsg = Msg & ControlChars.NewLine & OldMsg

            If OldMsg.Length > 2000 Then OldMsg = OldMsg.Substring(0, 2000)

            txtLog.Text = OldMsg

            'txtLog.Text.Insert(0, Msg & ControlChars.NewLine)

            lblLastOp.Text = Msg
            lblLastOp.Tag = TagLabel

        End If

        If DontStore = False Then

            'Try
            '    Using Log As New DaemonLog

            '        Select Case ModuleSigla
            '            Case "SYN"
            '                Log.Servizio = enDaemonService.Syncronizer
            '            Case "CLR"
            '                Log.Servizio = enDaemonService.Caller
            '            Case "SRV"
            '                Log.Servizio = enDaemonService.Service
            '            Case "MSG"
            '                Log.Servizio = enDaemonService.Messenger
            '            Case "UDP"
            '                Log.Servizio = enDaemonService.UdpCommand
            '        End Select

            '        If Errore Is Nothing Then
            '            Log.Tipo = enDaemonLogType.Standard
            '        Else
            '            Log.Tipo = enDaemonLogType.Exception
            '        End If

            '        Log.Descrizione = MsgCore
            '        Log.Quando = Now
            '        Log.Save()
            '    End Using
            'Catch ex As Exception
            '    FormerHelper.Mail.InviaMail("Errore salvataggio LOG Demone", ex.Message, "soft@tipografiaformer.it")
            'End Try

            Try
                Dim FileLog As String = PathLog & "\" & ModuleSigla & "\" & Now.ToString("yyyyMMdd") & "-" & ModuleSigla & ".log"

                Using w As New StreamWriter(FileLog, True)
                    w.WriteLine(Msg)
                End Using

            Catch ex As Exception

            End Try
        End If

        If Not Errore Is Nothing Then

            'qui devo inviare una mail di segnalazione errore 
            Dim S As String = "Errore " & ModuleName
            Dim T As String = Text

            If WithEmail Then
                FormerHelper.Mail.InviaMail(S, FormerHelper.HTML.ConvertiTextToHtml(Msg), "soft@tipografiaformer.it")
            End If

        End If

    End Sub

End Class
