#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 19/03/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_tipofustella
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TipoFustella
	Inherits _TipoFustella
    Implements ITipoFustella

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdTipoFustella() as integer
    Get
	    Return MyBase.IdTipoFustella
    End Get
    Set (byval value as integer)
        MyBase.IdTipoFustella= value
    End Set
End property 


Public Overrides Property IdPrev() as integer
    Get
	    Return MyBase.IdPrev
    End Get
    Set (byval value as integer)
        MyBase.IdPrev= value
    End Set
End property 


Public Overrides Property Base() as integer
    Get
	    Return MyBase.Base
    End Get
    Set (byval value as integer)
        MyBase.Base= value
    End Set
End property 


    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty
            If Profondita Then
                'fustella astucci
                ris = "Cod. " & IIf(Codice.Length, Codice, "n.d.") & " - " & Base & "mm x " & Profondita & "mm x " & Altezza & "mm"
            Else
                'fustella etichette
                ris = "Cod. " & IIf(Codice.Length, Codice, "n.d.") & " - " & Base & "mm x " & Altezza & "mm"
            End If
            Return ris
        End Get
    End Property

Public Overrides Property Profondita() as integer
    Get
	    Return MyBase.Profondita
    End Get
    Set (byval value as integer)
        MyBase.Profondita= value
    End Set
End property 


Public Overrides Property Altezza() as integer
    Get
	    Return MyBase.Altezza
    End Get
    Set (byval value as integer)
        MyBase.Altezza= value
    End Set
End property 


Public Overrides Property Disponibile() as integer
    Get
	    Return MyBase.Disponibile
    End Get
    Set (byval value as integer)
        MyBase.Disponibile= value
    End Set
End property 


#End Region

#Region "Logic Field"

    Private _P As Preventivazione = Nothing
    Public ReadOnly Property Preventivazione As Preventivazione
        Get
            If _P Is Nothing Then
                _P = New Preventivazione
                _P.Read(IdPrev)
            End If
            Return _P
        End Get
    End Property

    Private _C As CategoriaFustella = Nothing
    Public ReadOnly Property Categoria As CategoriaFustella
        Get
            If _C Is Nothing Then
                If IdCatFustella Then
                    _C = New CategoriaFustella
                    _C.Read(IdCatFustella)
                End If
            End If
            Return _C

        End Get
    End Property

    Public ReadOnly Property CategoriaFustellaStr As String
        Get
            Dim ris As String = ""

            If Not Categoria Is Nothing Then
                ris = Categoria.Categoria
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property PreventivazioneStr As String
        Get
            Dim ris As String = Preventivazione.Descrizione
            Return ris
        End Get
    End Property

    Public ReadOnly Property ImgRiferimento As Image
        Get
            Dim ris As Image = Nothing
            If File.Exists(ImgRif) Then
                Dim ImgInt As New Bitmap(ImgRif)
                Dim ImgNew = New Bitmap(ImgInt, New Size(48, 48))
                ris = ImgNew
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property ImgRiferimento128 As Image
        Get
            Dim ris As Image = Nothing
            If File.Exists(ImgRif) Then
                Dim ImgInt As New Bitmap(ImgRif)
                Dim ImgNew = New Bitmap(ImgInt, New Size(128, 128))
                ris = ImgNew
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property OrientabileStr As String
        Get
            Dim ris As String = "Non orientabile"
            If Orientabile = ensino.si Then
                ris = "Orientabile"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property DisponibileStr As String
        Get
            Dim ris As String = "No"
            If Disponibile = enSiNo.Si Then
                ris = "Si"
            End If
            Return ris
        End Get
    End Property

    Private _CategorieAssociate As List(Of CategoriaFustella) = Nothing
    Public ReadOnly Property CategorieAssociate As List(Of CategoriaFustella)
        Get
            If _CategorieAssociate Is Nothing Then
                _CategorieAssociate = New List(Of CategoriaFustella)

                Using mgr As New TipoFustellaSuCatDAO
                    Dim l As List(Of TipoFustellaSuCat) = mgr.FindAll(New LUNA.LunaSearchParameter("IdTipo", IdTipoFustella))
                    For Each c As TipoFustellaSuCat In l
                        Dim cat As New CategoriaFustella
                        cat.Read(c.IdCat)
                        _CategorieAssociate.Add(cat)
                    Next
                End Using
            End If

            Return _CategorieAssociate
        End Get
    End Property

    Public ReadOnly Property CategorieStr As String
        Get
            Dim ris As String = String.Empty

            For Each Cat As CategoriaFustella In CategorieAssociate
                ris &= Cat.Categoria & ", "
            Next
            ris = ris.TrimEnd(",", " ")
            Return ris

        End Get
    End Property

#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ITipoFustella.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        If Ris Then
            If Base = 0 Then
                Ris = False
            End If
        End If

        If Ris Then
            If Altezza = 0 Then
                Ris = False
            End If
        End If



	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ITipoFustella.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ITipoFustella.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_tipofustella
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITipoFustella
        Inherits _ITipoFustella

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface