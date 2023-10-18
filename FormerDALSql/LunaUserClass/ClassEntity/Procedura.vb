#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.37 
'Author: Diego Lunadei
'Date: 20/12/2017 
#End Region




Imports System.Drawing
''' <summary>
'''Entity Class for table T_procedure
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class Procedura
    Inherits _Procedura
    Implements IProcedura

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdProcedura() As Integer
        Get
            Return MyBase.IdProcedura
        End Get
        Set(ByVal value As Integer)
            MyBase.IdProcedura = value
        End Set
    End Property


    Public Overrides Property IdMacchinario() As Integer
        Get
            Return MyBase.IdMacchinario
        End Get
        Set(ByVal value As Integer)
            MyBase.IdMacchinario = value
        End Set
    End Property


    Public Overrides Property IdLavorazione() As Integer
        Get
            Return MyBase.IdLavorazione
        End Get
        Set(ByVal value As Integer)
            MyBase.IdLavorazione = value
        End Set
    End Property


    Public Overrides Property Nome() As String
        Get
            Return MyBase.Nome
        End Get
        Set(ByVal value As String)
            MyBase.Nome = value
        End Set
    End Property


    Public Overrides Property Descrizione() As String
        Get
            Return MyBase.Descrizione
        End Get
        Set(ByVal value As String)
            MyBase.Descrizione = value
        End Set
    End Property


#End Region

#Region "Logic Field"
    Private _Macchinario As Macchinario = Nothing
    Public ReadOnly Property Macchinario As Macchinario
        Get
            If _Macchinario Is Nothing Then
                _Macchinario = New Macchinario
                If IdMacchinario Then
                    _Macchinario.Read(IdMacchinario)
                End If
            End If
            Return _Macchinario
        End Get
    End Property

    Private _Lavorazione As Lavorazione = Nothing
    Public ReadOnly Property Lavorazione As Lavorazione
        Get
            If _Lavorazione Is Nothing Then
                _Lavorazione = New Lavorazione
                If IdLavorazione Then
                    _Lavorazione.Read(IdLavorazione)
                End If
            End If
            Return _Lavorazione
        End Get
    End Property

    Public ReadOnly Property RiferitoA As String
        Get
            Dim ris As String = String.Empty

            If Lavorazione.IdLavoro Then
                ris = Lavorazione.Descrizione
            End If

            If Macchinario.IdMacchinario Then

                If ris.Length Then ris &= " su "

                ris &= Macchinario.Descrizione
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property ImgLavorazione As Image
        Get
            Dim ris As Image = Nothing

            ris = Lavorazione.Img

            Return ris
        End Get
    End Property

    Public ReadOnly Property ImgMacchinario As Image
        Get
            Dim ris As Image = Nothing

            ris = Macchinario.Img

            Return ris
        End Get
    End Property

    Public ReadOnly Property ElencoStep As List(Of StepProcedura)
        Get
            Dim l As List(Of StepProcedura) = Nothing
            Using mgr As New StepProcedureDAO
                l = mgr.FindAll(LFM.StepProcedura.Ordine,
                                New LUNA.LunaSearchParameter(LFM.StepProcedura.IdProcedura, IdProcedura))
            End Using
            Return l
        End Get
    End Property

    Public ReadOnly Property ElencoFileAllegati As List(Of FileAllegato)
        Get
            Dim l As List(Of FileAllegato) = Nothing
            Using mgr As New FileAllegatiDAO
                l = mgr.FindAll(LFM.FileAllegato.FilePath,
                                New LUNA.LunaSearchParameter(LFM.FileAllegato.IdProcedura, IdProcedura))
            End Using
            Return l
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IProcedura.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IProcedura.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IProcedura.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_procedure
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IProcedura
    Inherits _IProcedura

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface