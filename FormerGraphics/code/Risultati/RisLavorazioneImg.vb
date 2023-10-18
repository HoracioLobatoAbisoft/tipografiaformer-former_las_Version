Imports System.Drawing

Public Class RisLavorazioneImg

    Private _ImgRis As Bitmap = Nothing
    Public Property ImgRis As Bitmap
        Get
            Return _ImgRis
        End Get
        Set(value As Bitmap)
            _ImgRis = value
        End Set
    End Property

    Private _lColor As New List(Of Color)
    Public ReadOnly Property ListaColoriPresenti As List(Of Color)
        Get
            Return _lColor
        End Get
    End Property

    Private _lColorUtilizzati As New List(Of ColoreEx)
    Public ReadOnly Property ListaColoriUtilizzati As List(Of ColoreEx)
        Get
            Return _lColorUtilizzati
        End Get
    End Property

    Public Property NumeroPixel As Integer = 0

End Class