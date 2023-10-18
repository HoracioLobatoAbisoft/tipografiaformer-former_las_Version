Imports System.Data
Imports FormerLib

Public Class _cOldCollections
    Inherits CollectionBase

    Friend Sub OldManageError(ByVal ex As Exception, Optional Altro As String = "")
        Err.Raise(601, "ManageError", ex.Message)
    End Sub

End Class

Public Class _cOldDao
    Implements IDisposable

    Private _OldDbConnection As IDbConnection = Nothing

    Public ReadOnly Property OldDbConnection As IDbConnection
        Get
            If _OldDbConnection Is Nothing Then
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then
                    _OldDbConnection = LUNA.LunaContext.TransactionBox.DbConnection
                Else
                    _OldDbConnection = LUNA.LunaContext.OldDbConnection
                End If

            End If
            Return _OldDbConnection
        End Get
    End Property

    Friend Sub OldManageError(ByVal ex As Exception, Optional Altro As String = "")
        Err.Raise(601, "ManageError", ex.Message)
    End Sub

    Public Function Ap(ByVal Valore) As String
        Dim str As String = String.Empty
        If TypeOf Valore Is String Then
            str = Valore.ToString
            str = str.Replace("'", "''")
            str = " '" & str & "'"
        ElseIf TypeOf Valore Is Date Then
            Dim dateRif As Date = Valore
            str = "  convert(datetime,'" & dateRif.Day.ToString("00") & "-" & dateRif.Month.ToString("00") & "-" & dateRif.Year & "',103)"
        ElseIf TypeOf Valore Is [Enum] Then
            str = " " & Valore
        ElseIf Valore Is Nothing Then
            str = " NULL "
        Else
            str = " " & Valore.ToString
        End If
        Return str
    End Function

    Friend Function ApLike(ByVal testo)
        Dim str As String
        str = testo.ToString
        str = str.Replace("'", "''")
        str = "like '%" & str & "%'"
        Return str
    End Function

    'Friend Function ApLikeRight(ByVal testo)
    '    Dim str As String
    '    str = testo.ToString
    '    str = str.Replace("'", "''")
    '    str = "like '" & str & "%'"
    '    Return str
    'End Function

    '<Obsolete("This method is deprecated, use FormerHelper in FormerLib instead.")> _
    'Public Function GetNomeFile(ByVal NomeFile As String, Optional ByVal IdOrd As Integer = 0) As String

    '    Dim NuovoNome As String = FormerHelper.File.EstraiNomeFile(NomeFile, IdOrd)

    '    Return NuovoNome

    'End Function

    Private Sub RipulisciDbConn()
        If LUNA.LunaContext.TransactionBox Is Nothing Then
            If Not _OldDbConnection Is Nothing Then
                Try
                    _OldDbConnection.Close()
                Catch ex As Exception

                End Try
                Try
                    _OldDbConnection.Dispose()
                Catch ex As Exception

                End Try
                Try
                    _OldDbConnection = Nothing
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            RipulisciDbConn()
            If disposing Then

            End If

        End If
        Me.disposedValue = True
    End Sub

    ' *TODO: eseguire l'override di Finalize() solo se Dispose(ByVal disposing As Boolean) dispone del codice per liberare risorse non gestite.
    'Protected Overrides Sub Finalize()
    '    ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(ByVal disposing As Boolean).
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class
