#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/11/2018 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Tr_gruppovarianterif
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class GruppiVariantiRifDAO
	Inherits _GruppiVariantiRifDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub DeleteByIdGruppoVariante(Id As Integer)
        Try
            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_gruppovarianterif SET DELETED=True "
                Dim Sql As String = "DELETE FROM Tr_Gruppovarianterif"
                Sql &= " WHERE IdGruppoVariante = " & Id
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Sub DeleteByParam(IdListinoBase As Integer,
                             Optional TipoRiferimento As Integer = 0,
                             Optional IdRiferimento As Integer = 0)
        Try
            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_gruppovarianterif SET DELETED=True "
                Dim Sql As String = "DELETE FROM Tr_Gruppovarianterif"
                Sql &= " WHERE IdListinoBase = " & IdListinoBase

                If TipoRiferimento Then
                    Sql &= " AND TipoRiferimento = " & TipoRiferimento
                End If

                If IdRiferimento Then
                    Sql &= " AND IdRiferimento = " & IdRiferimento
                End If


                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub


End Class