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
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table T_corriere
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CorrieriDAO
    Inherits _CorrieriDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function GetListaCorrieri(Optional withEmptyItem As Boolean = False) As List(Of ICorriereBusiness)
        Dim ris As New List(Of ICorriereBusiness)

        Dim l As List(Of Corriere) = FindAll(New LUNA.LunaSearchOption() With {.AddEmptyItem = withEmptyItem, .OrderBy = "IdCorriere"},
                                              New LUNA.LunaSearchParameter("DisponibileOnline", enSiNo.Si),
                                              New LUNA.LunaSearchParameter("Disattivo", enSiNo.Si, "<>"))

        For Each c As Corriere In l
            ris.Add(c)
        Next

        Return ris
    End Function


    'Public Function LeggiPrezzo(ByVal IdCorr As Integer) As String

    '    Try
    '        Dim Ris As Decimal = 0
    '        Dim myCommand As SqlCommand = _cn.CreateCommand()
    '        Dim sql As String = ""

    '        sql = "SELECT Costo from T_Corriere where idcorriere= " & IdCorr

    '        myCommand.CommandText = sql
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        myReader.Read()
    '        Ris = myReader("Costo")
    '        myReader.Close()
    '        myCommand.Dispose()
    '        Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Ris)
    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try

    'End Function

End Class