Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class MgrOrderLock

    Public Shared Sub UnLock(IdUt As Integer,
                             L As List(Of Ordine))

        For Each O As Ordine In L
            Using mgr As New FunctionLockDAO
                mgr.DeleteByIdUt(IdUt, O.IdOrd)
            End Using
        Next

    End Sub

    Public Shared Sub UnlockAll(IdUt As Integer,
                                Optional IdFunction As enFunctionLock = enFunctionLock.NonSpecificata)

        'qui devo salvare nel log di ogni ordine che e' strata annullata l'estrazione

        Using Mgr As New FunctionLockDAO
            Dim L As List(Of FunctionLock) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FunctionLock.IdUt, IdUt))
            For Each F In L
                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, F.IdOrd, "Annullata estrazione ordine: " & IdFunction)
            Next
        End Using

        Using mgr As New FunctionLockDAO
            mgr.DeleteByIdUt(IdUt,, IdFunction)
        End Using

    End Sub

    Public Shared Function Lock(IdUt As Integer,
                                L As List(Of OrdineRicerca),
                                IdFunction As enFunctionLock) As Integer

        Return Lock(IdUt, GetListOfOrdineFromRicerca(L), IdFunction)

    End Function

    Public Shared Function Lock(IdUt As Integer,
                                L As List(Of Ordine),
                                IdFunction As enFunctionLock) As Integer
        'ritorna l'id del lock
        Dim ris As Integer = 0

        For Each O As Ordine In L

            If IsLockedByMe(O.IdOrd, IdUt) = False Then
                Using f As New FunctionLock
                    f.IdUt = IdUt
                    f.Quando = Now
                    f.IdOrd = O.IdOrd
                    f.IdFunction = IdFunction
                    f.Postazione = System.Environment.MachineName
                    ris = f.Save()
                End Using
            End If

        Next

        Return ris
    End Function

    Public Shared Function IsLockedByMe(IdOrd As Integer, IdUt As Integer) As Boolean
        Dim ris As Boolean = False

        Using mgr As New FunctionLockDAO

            Dim l As List(Of FunctionLock) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FunctionLock.IdOrd, IdOrd))

            If l.Count Then
                Using f As FunctionLock = l(0)
                    If f.IdUt = IdUt Then
                        ris = True
                    End If
                End Using
            End If

        End Using

        Return ris
    End Function

    Public Shared Function IsLocked(IdOrd As Integer) As Boolean
        Dim ris As Boolean = False

        Using mgr As New FunctionLockDAO

            Dim l As List(Of FunctionLock) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FunctionLock.IdOrd, IdOrd))

            If l.Count Then
                ris = True
            End If

        End Using

        Return ris
    End Function

    Public Shared Function IsLocked(IdOrd As Integer,
                                     IdUt As Integer) As RisIsLocked
        Dim ris As New RisIsLocked

        Using mgr As New FunctionLockDAO

            Dim l As List(Of FunctionLock) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FunctionLock.IdOrd, IdOrd),
                                                         New LUNA.LunaSearchParameter(LFM.FunctionLock.IdUt, IdUt, "<>"))

            If l.Count Then
                Using f As FunctionLock = l(0)
                    ris.IsLocked = True
                    'ris.IdFunctionLock = f.IdFunctionLock
                    ris.IdUt = f.IdUt
                    ris.IdOrd = IdOrd
                    ris.IdFunction = f.IdFunction
                    ris.Postazione = f.Postazione
                    ris.DaQuando = f.Quando
                End Using
            End If

        End Using

        Return ris

    End Function

    Public Shared Function GetMessageLocked(Check As RisFunctionICan,
                                            Optional WithHeader As Boolean = True) As String

        Dim Ris As String = String.Empty
        'qui creo il messaggio di errore
        If Check.IsLockedByAnother Then
            For Each SingRis In Check.LockedBy
                Ris &= "L'ordine " & SingRis.IdOrd & " è bloccato da " & SingRis.Utente.Login & " sulla postazione '" & SingRis.Postazione.ToUpper & "' per la funzione di " & FormerEnumHelper.GetFunctionLock(SingRis.IdFunction) & ControlChars.NewLine
            Next

            If WithHeader Then Ris = "Impossibile continuare i seguenti ordini risultano bloccati: " & ControlChars.NewLine & ControlChars.NewLine & Ris

        End If
        Return Ris

    End Function

    Private Shared Function GetListOfOrdineFromRicerca(L As List(Of OrdineRicerca)) As List(Of Ordine)

        Dim _L As New List(Of Ordine)

        For Each singO In L
            _L.Add(singO)
        Next

        Return _L

    End Function

    Public Shared Function HoOrdiniLocked(IdUt As Integer,
                                        IdFunction As enFunctionLock) As List(Of Integer)

        Dim ris As New List(Of Integer)

        Using mgr As New FunctionLockDAO
            Dim L As List(Of FunctionLock) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FunctionLock.IdUt, IdUt),
                                                         New LUNA.LunaSearchParameter(LFM.FunctionLock.IdFunction, IdFunction))

            For Each singLock In L
                ris.Add(singLock.IdOrd)
            Next

        End Using

        Return ris

    End Function

    Public Shared Function ICan(IdUt As Integer,
                                L As List(Of OrdineRicerca)) As RisFunctionICan

        Return ICan(IdUt, GetListOfOrdineFromRicerca(L))

    End Function

    Public Shared Function ICan(IdUt As Integer,
                                L As List(Of Ordine)) As RisFunctionICan
        Dim ris As New RisFunctionICan

        'ris.ICan = True

        'Return ris
        'FUNZIONE DISABILITATA PER IL MOMENTO
        Dim CollLocked As New List(Of RisIsLocked)
        For Each O As Ordine In L
            Dim Check As RisIsLocked = IsLocked(O.IdOrd, IdUt)

            If Check.IsLocked Then

                CollLocked.Add(Check)

            End If
        Next

        If CollLocked.Count Then
            ris.ICan = False
            ris.IsLockedByAnother = True
            ris.LockedBy = CollLocked
        Else
            ris.ICan = True
        End If

        Return ris
    End Function

End Class
