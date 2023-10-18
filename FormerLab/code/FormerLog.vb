Imports System.IO
Imports FormerLib

Public Class FormerLog
    Inherits FormerLib.FormerLog

    Protected Shared PathLocale As String = AppDomain.CurrentDomain.BaseDirectory

    Public Shared ReadOnly Property PathLog As String
        Get
            Return PathLocale & "log"
        End Get
    End Property

    Public Shared Sub LogMe(txtLog As TextBox,
                            lblLastOp As Label,
                            ModuleName As String,
                            ModuleSigla As String,
                            Text As String,
                            Optional DontStore As Boolean = False,
                            Optional Errore As Exception = Nothing,
                            Optional TagLabel As String = "",
                            Optional WithEmail As Boolean = True)

        Dim Msg As String = Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & "." & Now.Second.ToString("00") & " - "
        If Not Errore Is Nothing Then
            Msg &= "EXCEPTION "
        End If
        Msg &= Text

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
                FormerHelper.Mail.InviaMail(S, FormerHelper.HTML.ConvertiTextToHtml(T), "soft@tipografiaformer.it")
            End If

        End If

    End Sub

End Class