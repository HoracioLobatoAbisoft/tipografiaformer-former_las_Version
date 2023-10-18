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
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_sorgenti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FileSorgente
    Inherits _FileSorgente
    Implements IFileSorgente

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    'Public Property ProgressivoAssegnato As Integer = 0 'SERVE IN EXPORT CTP
    Private _Ordine As Ordine = Nothing
    Public ReadOnly Property Ordine As Ordine
        Get
            If _Ordine Is Nothing Then
                _Ordine = New Ordine
                _Ordine.Read(IdOrd)
            End If
            Return _Ordine
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IFileSorgente.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IFileSorgente.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IFileSorgente.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public ReadOnly Property StatoRefineAutomatico As String
        Get
            Dim ris As String = String.Empty

            If StatoRefine = enStatoRefineSorgente.NonDefinito Then
                ris = "Non eseguito"
            ElseIf StatoRefine = enStatoRefineSorgente.InAttesaDiRefine Then
                ris = "In attesa"
            ElseIf StatoRefine = enStatoRefineSorgente.CompletatoErrore Then
                ris = "Errore"
            ElseIf StatoRefine = enStatoRefineSorgente.CompletatoSuccess Then
                ris = "Success"
            ElseIf StatoRefine = enStatoRefineSorgente.CompletatoWarning Then
                ris = "Warning"
            ElseIf StatoRefine = enStatoRefineSorgente.CompletatoCancelled Then
                ris = "Cancelled"
            End If

            Return ris
        End Get
    End Property


#End Region

End Class



''' <summary>
'''Interface for table T_sorgenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFileSorgente
    Inherits _IFileSorgente

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface