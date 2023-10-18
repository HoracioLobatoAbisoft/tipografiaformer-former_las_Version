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
'''Entity Class for table Td_caratprod
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CaratProd
	Inherits _CaratProd
    Implements ICaratProd

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"
#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ICaratProd.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ICaratProd.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ICaratProd.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
        Return _NomeCarat
End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_caratprod
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICaratProd
        Inherits _ICaratProd

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface