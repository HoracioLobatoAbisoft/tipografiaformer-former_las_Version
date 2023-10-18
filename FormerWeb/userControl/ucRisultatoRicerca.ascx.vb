Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ucRisultatoRicerca
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then AggregateReview.IdListinoBase = ListinoBase.IdListinoBase

    End Sub

    Public Property IndiceRicerca As IndiceRicerca

    Private _ListinoBase As ListinoBaseW = Nothing
    Public ReadOnly Property ListinoBase As ListinoBaseW
        Get
            If _ListinoBase Is Nothing Then

                _ListinoBase = New ListinoBaseW

                _ListinoBase.Read(IndiceRicerca.IdListinoBase)
            End If
            Return _ListinoBase
        End Get
    End Property

    Public Function CountDown(P As PromoW) As String
        Dim ris As String = String.Empty
        '3 giorni 5 ore 8 minuti
        Dim DataOra As Date = Now

        Dim DiffGiorni As Single = DateDiff(DateInterval.Day, DataOra, P.DataFineValidita)
        If DiffGiorni Then

            ris = DiffGiorni & " giorni "

            DataOra = DataOra.AddDays(DiffGiorni)
        End If

        Dim DiffOre As Single = DateDiff(DateInterval.Hour, DataOra, P.DataFineValidita)

        If DiffOre Then

            ris &= DiffOre & " ore "

            DataOra = DataOra.AddHours(DiffOre)
        End If

        Dim DiffMinuti As Single = DateDiff(DateInterval.Minute, DataOra, P.DataFineValidita)

        If DiffMinuti Then

            ris &= DiffMinuti & " minuti "
        Else
            If ris = String.Empty Then
                ris = " pochi secondi "
            End If
        End If

        Return ris
    End Function

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