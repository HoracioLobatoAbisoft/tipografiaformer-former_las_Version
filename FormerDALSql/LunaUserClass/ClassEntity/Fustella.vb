#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 19/03/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_fustelle
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Fustella
	Inherits _Fustella
    Implements IFustella

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdFustella() as integer
    Get
	    Return MyBase.IdFustella
    End Get
    Set (byval value as integer)
        MyBase.IdFustella= value
    End Set
End property 


Public Overrides Property IdTipoFustella() as integer
    Get
	    Return MyBase.IdTipoFustella
    End Get
    Set (byval value as integer)
        MyBase.IdTipoFustella= value
    End Set
End property 


Public Overrides Property IdFormCarta() as integer
    Get
	    Return MyBase.IdFormCarta
    End Get
    Set (byval value as integer)
        MyBase.IdFormCarta= value
    End Set
End property 


Public Overrides Property Codice() as string
    Get
	    Return MyBase.Codice
    End Get
    Set (byval value as string)
        MyBase.Codice= value
    End Set
End property 


Public Overrides Property Ripetizione() as integer
    Get
	    Return MyBase.Ripetizione
    End Get
    Set (byval value as integer)
        MyBase.Ripetizione= value
    End Set
End property 


Public Overrides Property Annotazioni() as string
    Get
	    Return MyBase.Annotazioni
    End Get
    Set (byval value as string)
        MyBase.Annotazioni= value
    End Set
End property 


#End Region

#Region "Logic Field"

    Private _Tf As TipoFustella
    Public ReadOnly Property TipoFustella As TipoFustella
        Get
            If _Tf Is Nothing Then
                _Tf = New TipoFustella
                _Tf.Read(IdTipoFustella)

            End If
            Return _Tf
        End Get
    End Property

    Public ReadOnly Property TipologiaFustella As String
        Get
            Dim ris As String = TipoFustella.Base & "x" & TipoFustella.Altezza
            If TipoFustella.Profondita Then
                ris &= "x" & TipoFustella.Profondita
            End If

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IFustella.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IFustella.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IFustella.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_fustelle
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFustella
        Inherits _IFustella

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface