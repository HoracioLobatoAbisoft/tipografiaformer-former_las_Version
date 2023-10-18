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
'''Entity Class for table T_step
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class StepProcedura
    Inherits _StepProcedura
    Implements IStepProcedura

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdStep() As Integer
        Get
            Return MyBase.IdStep
        End Get
        Set(ByVal value As Integer)
            MyBase.IdStep = value
        End Set
    End Property


    Public Overrides Property IdProcedura() As Integer
        Get
            Return MyBase.IdProcedura
        End Get
        Set(ByVal value As Integer)
            MyBase.IdProcedura = value
        End Set
    End Property


    Public Overrides Property Titolo() As String
        Get
            Return MyBase.Titolo
        End Get
        Set(ByVal value As String)
            MyBase.Titolo = value
        End Set
    End Property


    Public Overrides Property Testo() As String
        Get
            Return MyBase.Testo
        End Get
        Set(ByVal value As String)
            MyBase.Testo = value
        End Set
    End Property


    Public Overrides Property FilePath() As String
        Get
            Return MyBase.FilePath
        End Get
        Set(ByVal value As String)
            MyBase.FilePath = value
        End Set
    End Property


    Public Overrides Property Ordine() As Integer
        Get
            Return MyBase.Ordine
        End Get
        Set(ByVal value As Integer)
            MyBase.Ordine = value
        End Set
    End Property


#End Region

#Region "Logic Field"
    Public ReadOnly Property Img As Image
        Get
            Dim ris As Image = Nothing
            Dim PathRiferimento As String = FilePath
            If PathRiferimento.Length Then

                Try
                    If IO.File.Exists(PathRiferimento) Then
                        ris = Image.FromFile(PathRiferimento)
                    End If

                Catch ex As Exception

                End Try

            End If

            If ris Is Nothing Then ris = New Bitmap(My.Resources.no_image, New Size(75, 50))

            Return ris
        End Get
    End Property

    Public ReadOnly Property ImgThumb As Image
        Get
            Dim ris As Image = Nothing

            If FilePath.Length Then
                ris = New Bitmap(Img, New Size(75, 50))
            Else
                ris = New Bitmap(My.Resources.no_image, New Size(75, 50))
            End If

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IStepProcedura.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IStepProcedura.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IStepProcedura.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_step
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IStepProcedura
    Inherits _IStepProcedura

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface