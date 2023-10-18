#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib
''' <summary>
'''Entity Class for table Faq
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Faq
    Inherits _Faq
    Implements IFaq

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"
    Public ReadOnly Property DomandaEx() As String
        Get
            Return " - " & _Domanda
        End Get
    End Property


    Public ReadOnly Property RispostaWithLink() As String
        Get

            'formatto la risposta in modo da creare automaticamente i link contenuti all'interno
            Dim Risp As String = FormerHelper.Web.TrasformaLink(_Risposta)

            Return Risp

        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IFaq.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IFaq.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IFaq.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Faq
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFaq
    Inherits _IFaq

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface