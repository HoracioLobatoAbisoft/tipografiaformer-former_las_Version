#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.2 
'Author: Diego Lunadei
'Date: 06/06/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table T_progressivi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ProgressiviFiscali
	Inherits _ProgressiviFiscali
    Implements IProgressiviFiscali

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property NextFat() as integer
    Get
            Dim ris As Integer = MyBase.NextFat
            If ris = 0 Then ris = 1
            Return ris
    End Get
    Set (byval value as integer)
        MyBase.NextFat= value
    End Set
End property 


Public Overrides Property NextDDT() as integer
        Get
            Dim ris As Integer = MyBase.NextDDT
            If ris = 0 Then ris = 1
            Return ris
        End Get
    Set (byval value as integer)
        MyBase.NextDDT= value
    End Set
End property 


Public Overrides Property NextPrev() as integer
    Get

            Dim ris As Integer = MyBase.NextPrev
            If ris = 0 Then ris = 1
            Return ris
    End Get
    Set (byval value as integer)
        MyBase.NextPrev= value
    End Set
End property 


Public Overrides Property NextProgrBart() as integer
    Get
	    Return MyBase.NextProgrBart
    End Get
    Set (byval value as integer)
        MyBase.NextProgrBart= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IProgressiviFiscali.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IProgressiviFiscali.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IProgressiviFiscali.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_progressivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IProgressiviFiscali
        Inherits _IProgressiviFiscali

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface