Imports FormerLib.FormerEnum

Public Class ValidationError

    Private _ErrorLevel As enValidatorErrorLevel = enValidatorErrorLevel.Informazione
    Private _ReturnCode As enValidatorErrorCode = enValidatorErrorCode.Null
    Private _Message As String = String.Empty
    Public Sub New(ReturnCode As enValidatorReturnCode, Message As String, ErrorLevel As enValidatorErrorLevel)
        _ReturnCode = ReturnCode
        _Message = Message
        _ErrorLevel = ErrorLevel
    End Sub

    Public ReadOnly Property ReturnCode As enValidatorErrorCode
        Get
            Return _ReturnCode
        End Get
    End Property

    Public ReadOnly Property ErrorLevel As enValidatorErrorLevel
        Get
            Return _ErrorLevel
        End Get
    End Property

    Public ReadOnly Property ErrorLevelStr(Optional PulisciHtml As Boolean = False) As String
        Get
            Dim ris As String = String.Empty

            Select Case ErrorLevel
                Case Is = enValidatorErrorLevel.Errore
                    If PulisciHtml Then
                        ris = "ERRORE"
                    Else
                        ris = "<b style=""color:white;background-color:red"">ERRORE</b>"
                    End If
                Case Is = enValidatorErrorLevel.Attenzione
                    If PulisciHtml Then
                        ris = "ATTENZIONE"
                    Else
                        ris = "<b style=""background-color:orange;"">ATTENZIONE</b>"
                    End If
                Case Is = enValidatorErrorLevel.Informazione
                    If PulisciHtml Then
                        ris = "INFORMAZIONE"
                    Else
                        ris = "<b style=""background-color:yellow;"">INFORMAZIONE</b>"
                    End If
            End Select

            Return ris
        End Get
    End Property

    Public ReadOnly Property Message As String
        Get
            Return _Message
        End Get
    End Property

End Class
