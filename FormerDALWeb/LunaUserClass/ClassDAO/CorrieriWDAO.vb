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
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table T_corriere
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CorrieriWDAO
    Inherits _CorrieriWDAO

    Protected Overrides Property EmptyItemDescription As String = "-----------"

    Public Function GetListaCorrieri() As List(Of ICorriereBusiness)
        Dim ris As New List(Of ICorriereBusiness)

        Dim l As List(Of CorriereW) = FindAll("IdCorriere",
                                              New LUNA.LunaSearchParameter("DisponibileOnline", enSiNo.Si),
                                              New LUNA.LunaSearchParameter("Disattivo", enSiNo.Si, "<>"))

        For Each c As CorriereW In l
            ris.Add(c)
        Next

        Return ris
    End Function

End Class