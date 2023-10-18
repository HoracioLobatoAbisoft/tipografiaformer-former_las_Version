Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ucLbConsigliato
    Inherits FormerUserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then AggregateReview.IdListinoBase = IdListinoBase

    End Sub

    Private _IdListinoBase As Integer = 0
    Public Property IdListinoBase As Integer
        Get
            Return _IdListinoBase
        End Get
        Set(value As Integer)
            _IdListinoBase = value
            _ListinoBase = Nothing
        End Set
    End Property

    Private _ListinoBase As ListinoBaseW = Nothing
    Public ReadOnly Property ListinoBase As ListinoBaseW
        Get
            If _ListinoBase Is Nothing Then

                _ListinoBase = New ListinoBaseW

                _ListinoBase.Read(IdListinoBase)
            End If
            Return _ListinoBase
        End Get
    End Property

    Public ReadOnly Property ShowPrezziRiv As Boolean
        Get
            Dim ris As Boolean = False

            If UtenteConnesso.Tipo = enTipoRubrica.Rivenditore Then
                ris = True
            End If

            Return ris
        End Get
    End Property

End Class