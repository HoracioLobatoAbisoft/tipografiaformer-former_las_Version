#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 24/10/2016 
#End Region



''' <summary>
'''Entity Class for table Paramlistini
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ParamListino
	Inherits _ParamListino
    Implements IParamListino

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdParamListino() as integer
    Get
	    Return MyBase.IdParamListino
    End Get
    Set (byval value as integer)
        MyBase.IdParamListino= value
    End Set
End property 


Public Overrides Property IdUt() as integer
    Get
	    Return MyBase.IdUt
    End Get
    Set (byval value as integer)
        MyBase.IdUt= value
    End Set
End property 


Public Overrides Property IdPrev() as integer
    Get
	    Return MyBase.IdPrev
    End Get
    Set (byval value as integer)
        MyBase.IdPrev= value
    End Set
End property 


Public Overrides Property PercRicarico() as integer
    Get
	    Return MyBase.PercRicarico
    End Get
    Set (byval value as integer)
        MyBase.PercRicarico= value
    End Set
End property 


Public Overrides Property Qta1() as integer
    Get
	    Return MyBase.Qta1
    End Get
    Set (byval value as integer)
        MyBase.Qta1= value
    End Set
End property 


Public Overrides Property Qta2() as integer
    Get
	    Return MyBase.Qta2
    End Get
    Set (byval value as integer)
        MyBase.Qta2= value
    End Set
End property 


Public Overrides Property Qta3() as integer
    Get
	    Return MyBase.Qta3
    End Get
    Set (byval value as integer)
        MyBase.Qta3= value
    End Set
End property 


Public Overrides Property Qta4() as integer
    Get
	    Return MyBase.Qta4
    End Get
    Set (byval value as integer)
        MyBase.Qta4= value
    End Set
End property 


Public Overrides Property Qta5() as integer
    Get
	    Return MyBase.Qta5
    End Get
    Set (byval value as integer)
        MyBase.Qta5= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IParamListino.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IParamListino.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IParamListino.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Paramlistini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IParamListino
        Inherits _IParamListino

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface