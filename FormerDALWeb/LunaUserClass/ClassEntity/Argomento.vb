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

''' <summary>
'''Entity Class for table Argomenti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Argomento
    Inherits _Argomento
    Implements IArgomento

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IArgomento.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IArgomento.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IArgomento.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public ReadOnly Property GetTopN(Optional N As Integer = 3) As IEnumerable(Of Faq)
        Get

            Using m As New FaqDAO
                Return m.GetTopN(_IDArgomento, N)
            End Using

        End Get
    End Property

#End Region

End Class



''' <summary>
'''Interface for table Argomenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IArgomento
    Inherits _IArgomento

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface