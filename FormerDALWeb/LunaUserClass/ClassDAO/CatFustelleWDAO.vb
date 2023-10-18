#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 22/10/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                

''' <summary>
'''DAO Class for table Td_catfustelle
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CatFustelleWDAO
	Inherits _CatFustelleWDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Scegli una categoria"

    Public Function GetCatWithFustelle(IdPrev As Integer) As IEnumerable(Of CatFustellaW)

        Dim ris As List(Of CatFustellaW)

        Try

            Dim sql As String = ""
            sql = "select * from Td_Catfustelle where IdCatFustella in (select distinct idcat from TR_CatTipoFustella TR inner join t_TIPOFUSTELLA f on tr.IdTipo = f.IdTipoFustella where idprev = " & IdPrev & ") order by Categoria"

            ris = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return ris

    End Function

End Class