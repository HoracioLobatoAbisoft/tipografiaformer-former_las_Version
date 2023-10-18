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


''' <summary>
'''DAO Class for table T_fasceprezzo
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class FascePrezzoDAO
    Inherits _FascePrezzoDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function PercentualePrezzo(PrezzoRif As Decimal) As Integer
        Dim Ris As Integer = 0
        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = "SELECT * FROM T_FascePrezzo where " & PrezzoRif & "> Min AND " & PrezzoRif & " <= MAX "
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            myReader.Read()
            If myReader.HasRows Then
                Ris = myReader("Perc")
            End If
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function
End Class