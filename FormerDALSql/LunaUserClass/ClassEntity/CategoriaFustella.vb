#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 20/10/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table Td_catfustelle
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CategoriaFustella
	Inherits _CategoriaFustella
    Implements ICategoriaFustella

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdCatFustella() as integer
    Get
	    Return MyBase.IdCatFustella
    End Get
    Set (byval value as integer)
        MyBase.IdCatFustella= value
    End Set
End property 


Public Overrides Property Categoria() as string
    Get
	    Return MyBase.Categoria
    End Get
    Set (byval value as string)
        MyBase.Categoria= value
    End Set
End property 


Public Overrides Property Descrizione() as string
    Get
	    Return MyBase.Descrizione
    End Get
    Set (byval value as string)
        MyBase.Descrizione= value
    End Set
End property 


#End Region

#Region "Logic Field"

    Public ReadOnly Property AnimaStr As String
        Get
            Dim ris As String = "-"

            If Anima Then
                ris = Anima & " mm"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property LarghezzaMaxStr As String
        Get
            Dim ris As String = "-"

            If LarghezzaMax Then
                ris = LarghezzaMax & " mm"
            End If
            Return ris
        End Get
    End Property

#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ICategoriaFustella.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ICategoriaFustella.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ICategoriaFustella.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
        Return Categoria
End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_catfustelle
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICategoriaFustella
        Inherits _ICategoriaFustella

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface