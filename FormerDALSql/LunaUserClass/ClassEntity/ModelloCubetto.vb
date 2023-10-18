#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.21984 
'Author: Diego Lunadei
'Date: 29/11/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table Modellicubetti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ModelloCubetto
    Inherits _ModelloCubetto
    Implements IModelloCubetto

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub



#Region "Logic Field"

    Public ReadOnly Property Volume As Single
        Get
            Return Lunghezza * Larghezza * Profondita
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get

            Dim ris As String = ""
            If IDModelloCubetto Then
                ris = Nome & " (" & Lunghezza & "mm x " & Larghezza & "mm x " & Profondita & "mm)"
            Else
                ris = "Selezionare un modello di cubetto"
            End If
            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IModelloCubetto.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()

        If Larghezza = 0 Then Ris = False
        If Lunghezza = 0 Then Ris = False
        If Profondita = 0 Then Ris = False
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IModelloCubetto.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IModelloCubetto.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Modellicubetti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IModelloCubetto
    Inherits _IModelloCubetto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface