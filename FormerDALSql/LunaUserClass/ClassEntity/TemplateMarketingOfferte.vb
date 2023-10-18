#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 06/10/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_templmarkoff
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TemplateMarketingOfferte
	Inherits _TemplateMarketingOfferte
    Implements ITemplateMarketingOfferte

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdTmOff() as integer
    Get
	    Return MyBase.IdTmOff
    End Get
    Set (byval value as integer)
        MyBase.IdTmOff= value
    End Set
End property 


#End Region

#Region "Logic Field"

    Private _FiltroMarketing As FiltroMarketing = Nothing
    Public ReadOnly Property FiltroMarketing As FiltroMarketing
        Get
            If _FiltroMarketing Is Nothing Then

                _FiltroMarketing = New FiltroMarketing
                _FiltroMarketing.Read(IdFM)

            End If

            Return _FiltroMarketing

        End Get
    End Property

    Private _DataInizio As Date = Date.MinValue
    Public ReadOnly Property DataInizio As Date
        Get
            'qui devo ottenere la data del prossimo mese di questo anno in corso
            If _DataInizio = Date.MinValue Then
                Dim Giorno As Integer = 1
                Dim Anno As Integer = Now.Year

                Dim DataRif As New Date(Anno, Mese, Giorno)

                If Mese < Now.Month Then
                    DataRif = DataRif.AddYears(1)
                End If
                _DataInizio = DataRif
            End If

            Return _DataInizio
        End Get
    End Property

    Private _DataFine As Date = Date.MinValue
    Public ReadOnly Property DataFine As Date
        Get
            If _DataFine = Date.MinValue Then
                _DataFine = DataInizio.AddMonths(1).AddDays(-1)
            End If
            Return _DataFine
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ITemplateMarketingOfferte.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ITemplateMarketingOfferte.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ITemplateMarketingOfferte.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_templmarkoff
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITemplateMarketingOfferte
        Inherits _ITemplateMarketingOfferte

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface