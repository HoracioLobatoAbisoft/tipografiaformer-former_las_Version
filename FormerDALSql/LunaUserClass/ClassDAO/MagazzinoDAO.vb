#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports System.Data.Common

''' <summary>
'''DAO Class for table T_magaz
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class MagazzinoDAO
    Inherits _MagazzinoDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function getMovCampioneByVoceCosto(Descrizione As String, IdFornitore As Integer) As MovimentoMagazzino

        Dim ris As MovimentoMagazzino = Nothing

        Dim sql As String = String.Empty

        sql = "select TOP 1 * from t_magaz where idcarmag in (select IdMovMagaz from t_vocicosto where descrizione = " & Ap(Descrizione) & " and idcosto in (select idcosto from t_contabcosti where idrub= " & IdFornitore & " and idmovmagaz<>0))"

        sql &= " order by datamov desc"

        Dim l As List(Of MovimentoMagazzino) = GetData(sql)

        If l.Count Then
            ris = l(0)
        End If

        Return ris

    End Function

    Public Sub ReplaceRisorsa(IdRisOld As Integer, IdRisNew As Integer)

        Try

            'Dim l As List(Of MovimentoMagazzino)
            'l = FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Prenotazione),
            '                    New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCom, IdCom))

            'For Each singMov In l
            '    singMov.TipoMov = enTipoMovMagaz.Scarico
            '    singMov.Save()

            '    AggiornaQta(singMov)

            'Next

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE T_Commesse set IdRis =" & IdRisNew & " WHERE idris = " & IdRisOld
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE T_Magaz set IdRis =" & IdRisNew & " WHERE idris = " & IdRisOld
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "DELETE FROM TR_RisMacchina WHERE idrisorsa = " & IdRisOld
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "DELETE FROM t_azionisottoscorta WHERE idrisorsa = " & IdRisOld
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Public Function IdRisUsate(IdUtente As Integer,
                               TipoMov As enTipoMovMagaz) As List(Of Integer)

        Dim ris As New List(Of Integer)

        Try
            Dim Sql As String = "SELECT DISTINCT IdRis FROM T_Magaz WHERE IdUt = " & IdUtente & " AND TipoMov = " & TipoMov
            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As DbDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        ris.Add(myReader("IdRis"))
                    End While
                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return ris

    End Function

    Public Function IdRisUsateStr(IdUt As Integer,
                                  TipoMov As enTipoMovMagaz) As String
        Dim ris As String = String.Empty

        Dim l As List(Of Integer) = IdRisUsate(IdUt, TipoMov)

        For Each Valore In l
            ris &= Valore & ","
        Next

        ris = ris.TrimEnd(",")

        Return ris
    End Function

    Public Function TrasformaPrenotazioneInScarico(ByVal IdCom As Integer) As Integer
        Dim Ris As Integer = 0
        Try


            'Dim l As List(Of MovimentoMagazzino)
            'l = FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Prenotazione),
            '                    New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCom, IdCom))

            'For Each singMov In l
            '    singMov.TipoMov = enTipoMovMagaz.Scarico
            '    singMov.Save()

            '    AggiornaQta(singMov)

            'Next

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE T_Magaz set tipomov =" & enTipoMovMagaz.Scarico & " WHERE tipomov= " & enTipoMovMagaz.Prenotazione & " and idcom = " & IdCom
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function TrasformaCodiceOldMovimenti(ByVal IdRis As Integer,
                                                OldVal As String,
                                                NewVal As String) As Integer
        Dim Ris As Integer = 0
        Try


            'Dim l As List(Of MovimentoMagazzino)
            'l = FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Prenotazione),
            '                    New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCom, IdCom))

            'For Each singMov In l
            '    singMov.TipoMov = enTipoMovMagaz.Scarico
            '    singMov.Save()

            '    AggiornaQta(singMov)

            'Next

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE T_Magaz set Codiceforn=" & Ap(NewVal) & " WHERE codiceforn = " & Ap(OldVal) & " and idris = " & IdRis
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function TrasformaDescrOldMovimenti(ByVal IdRis As Integer,
                                                OldVal As String,
                                                NewVal As String) As Integer
        Dim Ris As Integer = 0
        Try


            'Dim l As List(Of MovimentoMagazzino)
            'l = FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.Prenotazione),
            '                    New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCom, IdCom))

            'For Each singMov In l
            '    singMov.TipoMov = enTipoMovMagaz.Scarico
            '    singMov.Save()

            '    AggiornaQta(singMov)

            'Next

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE T_Magaz set Descrforn=" & Ap(NewVal) & " WHERE Descrforn = " & Ap(OldVal) & " and idris = " & IdRis
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function DeleteByIdFat(ByVal IdFat As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "DELETE FROM T_Magaz WHERE IdFat = " & IdFat
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function AnnullaMovimento(Mov As MovimentoMagazzino) As Integer
        Dim ris As Integer = 0

        Delete(Mov.IdCarMag)
        AggiornaQta(Mov.IdRis)

        Return ris
    End Function

    Public Function AggiornaQta(Mov As MovimentoMagazzino) As Single
        Dim Ris As Single = 0
        Try
            Ris = AggiornaQta(Mov.IdRis)

            'End If
        Catch ex As Exception
            ManageError(ex)

        End Try
        Return Ris
    End Function

    Public Function GetGiacenzaAggiornata(IdRis As Integer,
                                          Optional DataFinoA As Date = Nothing) As Single

        Dim NewGiacenza As Single = 0
        Using mgr As New MagazzinoDAO

            Dim pData As LUNA.LunaSearchParameter = Nothing

            If DataFinoA <> Date.MinValue Then
                pData = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.DataMov, DataFinoA, "<=")
            End If

            Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = LFM.MovimentoMagazzino.DataMov.Name},
                                                               New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, IdRis),
                                                               pData)

            For Each Mov As MovimentoMagazzino In l

                Select Case Mov.TipoMov
                    Case enTipoMovMagaz.Carico
                        NewGiacenza += Mov.Qta
                    Case enTipoMovMagaz.Scarico
                        NewGiacenza -= Mov.Qta
                    Case enTipoMovMagaz.Storno
                        NewGiacenza += Mov.Qta
                    Case enTipoMovMagaz.Prenotazione
                        NewGiacenza -= Mov.Qta
                End Select

            Next

        End Using

        Using R As New Risorsa
            R.Read(IdRis)
            If R.TipoRis = enTipoProdCom.StampaOffSet Then
                NewGiacenza = Math.Floor(NewGiacenza)
            End If
        End Using
        'If NewGiacenza < 0 Then NewGiacenza = 0

        Return NewGiacenza

    End Function

    Public Function AggiornaQta(IdRis As Integer) As Single

        Dim Ris As Single = 0
        Try

            'If Mov.TipoMov = enTipoMovMagaz.Carico Or
            '   Mov.TipoMov = enTipoMovMagaz.Prenotazione Or
            '   Mov.TipoMov = enTipoMovMagaz.Storno Then

            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _Cn

                Ris = GetGiacenzaAggiornata(IdRis)

                Dim Sql As String = "UPDATE T_RISORSE SET Giacenza = " & Ris.ToString.Replace(",", ".")

                'Select Case Mov.TipoMov

                '    Case enTipoMovMagaz.Carico
                '        Sql &= " - " & (Old) & " + " & (NewQta) & ")"

                '    Case enTipoMovMagaz.Prenotazione, enTipoMovMagaz.Storno
                '        Sql &= " + " & (Old) & " - " & (NewQta) & ")"
                '        'Case enTipoMovMagaz.Carico
                '        '    Sql &= "( - " & Ap(Old) & " + " & Ap(NewQta) & ")"

                '        'Case enTipoMovMagaz.Prenotazione, enTipoMovMagaz.Storno
                '        '    Sql &= "( + " & Ap(Old) & " - " & Ap(NewQta) & ")"

                'End Select

                Sql &= " Where IdRis = " & IdRis
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

                UpdateCommand.CommandText = Sql
                UpdateCommand.ExecuteNonQuery()
            End Using

            'End If
        Catch ex As Exception
            ManageError(ex)
            'Ris = ex.GetHashCode
        End Try
        Return Ris

    End Function

    Public Function AggiornaQta(Mov As MovimentoMagazzino,
                                ByVal Old As Double,
                                ByVal NewQta As Double) As Single

        Dim Ris As Single = 0
        Try
            Ris = AggiornaQta(Mov.IdRis)

            'End If
        Catch ex As Exception
            ManageError(ex)

        End Try
        Return Ris

    End Function



End Class