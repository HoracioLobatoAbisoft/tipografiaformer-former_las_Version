#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.11.4 
'Author: Diego Lunadei
'Date: 24/11/2017 
#End Region



''' <summary>
'''Entity Class for table Tr_formatomacchinario
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FormatoSuMacchinario
	Inherits _FormatoSuMacchinario
    Implements IFormatoSuMacchinario

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdFormatoMacc() as integer
    Get
	    Return MyBase.IdFormatoMacc
    End Get
    Set (byval value as integer)
        MyBase.IdFormatoMacc= value
    End Set
End property 


Public Overrides Property IdFormato() as integer
    Get
	    Return MyBase.IdFormato
    End Get
    Set (byval value as integer)
        MyBase.IdFormato= value
    End Set
End property 


Public Overrides Property IdMacchinario() as integer
    Get
	    Return MyBase.IdMacchinario
    End Get
    Set (byval value as integer)
        MyBase.IdMacchinario= value
    End Set
End property


#End Region

#Region "Logic Field"

    Private _Macchinario As Macchinario = Nothing
    Public ReadOnly Property Macchinario As Macchinario
        Get
            If _Macchinario Is Nothing Then
                _Macchinario = New Macchinario
                _Macchinario.Read(IdMacchinario)
            End If
            Return _Macchinario
        End Get
    End Property

    Private _FormatoMacchina As Formato = Nothing
    Public ReadOnly Property FormatoMacchina As Formato
        Get
            If _FormatoMacchina Is Nothing Then
                _FormatoMacchina = New Formato
                _FormatoMacchina.Read(IdFormato)
            End If
            Return _FormatoMacchina
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IFormatoSuMacchinario.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IFormatoSuMacchinario.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IFormatoSuMacchinario.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Tr_formatomacchinario
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFormatoSuMacchinario
        Inherits _IFormatoSuMacchinario

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface