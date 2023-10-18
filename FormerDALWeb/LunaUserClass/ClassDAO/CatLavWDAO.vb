#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                

''' <summary>
''' 
'''DAO Class for table Td_catlav
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CatLavWDAO
	Inherits _CatLavWDAO

    Public Function GetNumeroLavorazioni(IdListinoBase As Integer, IdCatLav As Integer) As Integer

        Dim ris As Integer = 0

        Try
            Dim myCommand As Data.Common.DbCommand = _Cn.CreateCommand()
            Dim sql As String = "select COUNT(*) as totale from T_Lavori LZ, Tr_LavPrev lp where lz.idcatlav =" & IdCatLav & " and lp.IdLavoro = LZ.IdLavoro and lp.IdListinoBase = " & IdListinoBase

            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            myReader.Read()
            If myReader.HasRows Then

                ris = myReader("totale")
            End If

            myReader.Close()
            myCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return ris

    End Function

End Class