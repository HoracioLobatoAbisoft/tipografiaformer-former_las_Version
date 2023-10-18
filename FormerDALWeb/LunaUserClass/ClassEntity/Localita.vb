#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.32350 
'Author: Diego Lunadei
'Date: 10/10/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table Localita
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Localita
	Inherits _Localita
    Implements ILocalita

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"

    Private _Comune As Comune = Nothing
    Public ReadOnly Property Comune As Comune
        Get
            If _Comune Is Nothing Then
                Using mgr As New ComuniDAO
                    _Comune = mgr.Find(New LUNA.LunaSearchParameter("CodComune", IdComune))
                End Using
            End If
            Return _Comune
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty

            ris = localita

            If IdComune Then
                ris &= " (" & Comune.DESCCOMUNE & ")"
            End If

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ILocalita.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ILocalita.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ILocalita.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Localita
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ILocalita
        Inherits _ILocalita

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface