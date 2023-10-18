Imports FormerLib.FormerEnum

Public Class ValidationOrderResult

    Public Property IdOrdine As Integer = 0

    Public ReadOnly Property ReturnCode As enValidatorReturnCode
        Get
            Dim ris As enValidatorReturnCode = enValidatorReturnCode.ValidazioneOk

            If _ValidationFileList.FindAll(Function(x) x.ReturnCode = enValidatorReturnCode.ValidazioneKO).Count Then
                ris = enValidatorReturnCode.ValidazioneKO
            End If

            If HannoOrientamentoDifferente Then
                ris = enValidatorReturnCode.ValidazioneKO
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property MaxErrorLevelStr As String
        Get
            Dim ris As String = String.Empty

            Select Case MaxErrorLevel
                Case Is = enValidatorErrorLevel.Errore
                    ris = "ERRORE"
                Case Is = enValidatorErrorLevel.Informazione
                    ris = "INFORMAZIONE"
                Case Is = enValidatorErrorLevel.Attenzione
                    ris = "ATTENZIONE"
            End Select

            Return ris
        End Get
    End Property

    Public ReadOnly Property MaxErrorLevel As enValidatorErrorLevel
        Get
            Dim ris As enValidatorErrorLevel = enValidatorErrorLevel.None

            For Each singVal In ValidationFileListKO
                Dim singMaxErrorLevel As enValidatorErrorLevel = singVal.ReturnMaxErrorLevel
                If singMaxErrorLevel > ris Then
                    ris = singMaxErrorLevel
                End If
            Next

            If ris = enValidatorErrorLevel.None Then
                If HannoOrientamentoDifferente Then ris = enValidatorErrorLevel.Attenzione
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property HannoDimensioniErrate As Boolean
        Get
            Dim ris As Boolean = False

            For Each ValFile In ValidationFileList
                If ValFile.ErrorList.FindAll(Function(x) x.ReturnCode = enValidatorErrorCode.DimensioniNonCorrette).Count Then
                    ris = True
                    Exit For
                End If
            Next

            Return ris
        End Get
    End Property

    Public ReadOnly Property HannoOrientamentoDifferente As Boolean
        Get
            Dim ris As Boolean = False

            'qui controllo che tutti i file allegati davvero abbiamo un orientamento coerente
            Dim L As List(Of ValidationFileResult) = _ValidationFileList.FindAll(Function(x) x.FileName.Length)

            Dim OrientamentoTrovato As Integer = -1

            For Each singVal In L
                If OrientamentoTrovato = -1 Then
                    OrientamentoTrovato = singVal.Orientamento
                Else
                    If OrientamentoTrovato <> singVal.Orientamento Then
                        ris = True
                        Exit For
                    End If
                End If
            Next

            Return ris
        End Get
    End Property

    Private _ValidationFileList As New List(Of ValidationFileResult)

    Public ReadOnly Property ValidationFileList As List(Of ValidationFileResult)
        Get
            Return _ValidationFileList
        End Get
    End Property

    Public ReadOnly Property ValidationFileListKO As List(Of ValidationFileResult)
        Get
            Dim l As List(Of ValidationFileResult) = _ValidationFileList.FindAll(Function(x) x.ReturnCode = enValidatorReturnCode.ValidazioneKO)
            Return l
        End Get
    End Property

    Public ReadOnly Property ValidationFileListOK As List(Of ValidationFileResult)
        Get
            Dim l As List(Of ValidationFileResult) = _ValidationFileList.FindAll(Function(x) x.ReturnCode = enValidatorReturnCode.ValidazioneOk)
            Return l
        End Get
    End Property

End Class
