Imports FormerLib.FormerEnum

Public Class ValidationFileResult

    Private _FilePath As String = String.Empty
    Public Sub New(Optional FilePath As String = "")
        _FilePath = FilePath
    End Sub

    Public Property TipoSorgente As enFronteRetro

    Public ReadOnly Property FilePath As String
        Get
            Return _FilePath
        End Get
    End Property

    Public ReadOnly Property FileName As String
        Get
            Return FormerLib.FormerHelper.File.EstraiNomeFile(_FilePath)
        End Get
    End Property

    Public ReadOnly Property ReturnCode As enValidatorReturnCode
        Get
            Dim ris As enValidatorReturnCode = enValidatorReturnCode.ValidazioneOk
            If ErrorList.Count Then
                ris = enValidatorReturnCode.ValidazioneKO
            End If

            Return ris
        End Get
    End Property

    Public Property Orientamento As enTipoOrientamento = enTipoOrientamento.Neutro

    Private _ErrorList As New List(Of ValidationError)

    Public ReadOnly Property ErrorList As List(Of ValidationError)
        Get
            Return _ErrorList
        End Get
    End Property

    Public ReadOnly Property ErrorBuffer(Optional PulisciHtml As Boolean = False) As String
        Get
            Dim ris As String = String.Empty
            ErrorList.Sort(Function(x, y) y.ErrorLevel.CompareTo(x.ErrorLevel))
            For Each singErr In ErrorList
                ris &= singErr.ErrorLevelStr(PulisciHtml) & " - " & singErr.Message & ControlChars.NewLine
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property ReturnMaxErrorLevel As enValidatorErrorLevel
        Get
            Dim ris As enValidatorErrorLevel = enValidatorErrorLevel.None

            For Each singErr In ErrorList
                If singErr.ErrorLevel > ris Then
                    ris = singErr.ErrorLevel
                End If
            Next

            Return ris
        End Get
    End Property

End Class