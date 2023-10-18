#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 14/07/2016 
#End Region



''' <summary>
'''Entity Class for table Ipban
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class IpBan
	Inherits _IpBan
    Implements IIpBan

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdIpBan() as integer
    Get
	    Return MyBase.IdIpBan
    End Get
    Set (byval value as integer)
        MyBase.IdIpBan= value
    End Set
End property 


Public Overrides Property IpToBan() as string
    Get
	    Return MyBase.IpToBan
    End Get
    Set (byval value as string)
        MyBase.IpToBan= value
    End Set
End property 


Public Overrides Property Quando() as DateTime
    Get
	    Return MyBase.Quando
    End Get
    Set (byval value as DateTime)
        MyBase.Quando= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IIpBan.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IIpBan.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IIpBan.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Ipban
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IIpBan
        Inherits _IIpBan

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface