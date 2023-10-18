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
Imports System.Drawing

''' <summary>
'''Entity Class for table Tr_lavprev
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class LavorazSuPreventivaz
    Inherits _LavorazSuPreventivaz
    Implements ILavorazSuPreventivaz

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"

    Private _ListinoBase As ListinoBase = Nothing
    Public ReadOnly Property ListinoBase As ListinoBase
        Get
            If _ListinoBase Is Nothing Then
                _ListinoBase = New ListinoBase
                _ListinoBase.Read(IdListinoBase)
            End If
            Return _ListinoBase

        End Get
    End Property

    Private _Lavorazione As Lavorazione = Nothing
    Public ReadOnly Property Lavorazione As Lavorazione
        Get
            If _Lavorazione Is Nothing Then
                _Lavorazione = New Lavorazione
                _Lavorazione.Read(IdLavoro)
            End If
            Return _Lavorazione
        End Get
    End Property

    Public ReadOnly Property ImgLavorazione As Image
        Get
            Return Lavorazione.Img
        End Get
    End Property

    Public ReadOnly Property RiassuntoLavorazione As String
        Get
            Dim ris As String = String.Empty

            ris = Lavorazione.Descrizione

            Return ris
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ILavorazSuPreventivaz.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ILavorazSuPreventivaz.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ILavorazSuPreventivaz.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Tr_lavprev
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ILavorazSuPreventivaz
    Inherits _ILavorazSuPreventivaz

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface