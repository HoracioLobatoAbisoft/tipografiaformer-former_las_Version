Imports FormerDALSql
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum
Imports FormerLib

Public Class ListinoBaseInTemplate
    Inherits ListinoBaseSuTemplate

    Public ReadOnly Property Nome As String
        Get
            Return ListinoBase.Nome
        End Get
    End Property

    Private _Prezzo As Decimal = 0
    Public ReadOnly Property Prezzo As Decimal
        Get
            If _Prezzo = 0 Then
                CalcolaPrezzo()
            End If
            Return _Prezzo
        End Get
    End Property

    Public Property InPromo As Boolean = False

    Private _PrezzoInveceDi As Decimal = -1
    Public ReadOnly Property PrezzoInveceDi As Decimal
        Get
            If _PrezzoInveceDi = -1 Then
                CalcolaPrezzo()
            End If
            Return _PrezzoInveceDi
        End Get
    End Property

    Private Function CheckCoupon() As Decimal
        Dim Ris As Single = 0
        'controllo se nel periodo inserito ci sono coupon validi per la quantita inserita 
        Try

            Using mgr As New CouponDAO

                Dim C As Coupon = mgr.Find(New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase),
                                           New LUNA.LunaSearchParameter("RiservatoaTipoUtente", Tm.FiltroMarketing.Tipo),
                                           New LUNA.LunaSearchParameter("QtaSpecifica", Qta),
                                           New LUNA.LunaSearchParameter("Riservato", 0),
                                           New LUNA.LunaSearchParameter("datediff(""d"",DataInizioValidita,'" & Tm.DataInizio.ToString("MM/dd/yyyy") & "')", 0, ">="),
                                           New LUNA.LunaSearchParameter("datediff(""d"",DataFineValidita,'" & Tm.DataFine.ToString("MM/dd/yyyy") & "')", 0, "<="))

                If Not C Is Nothing Then
                    Ris = C.ImportoFisso
                End If

            End Using

        Catch ex As Exception

        End Try

        Return Ris

    End Function

    Private Function CalcolaPrezzi(L As ListinoBase, Qta As Single, Fogli As Integer) As RisPrezzoIntermedio
        If Fogli = 0 Then Fogli = 1

        'Dim QtaRichiesta As Integer = Convert.ToInt32(ddlQta.SelectedValue)

        Dim listaBaseB As List(Of ILavorazioneB) = L.LavorazioniBaseB

        L.NumFacciate = L.FaccMin

        'Dim _Risultato As RisultatoListinoBase
        '_Risultato = MgrPreventivazioneB.CalcolaPrezzi(L, listaBaseB,  , False)

        'Dim QtaSecondaria As Single = 0

        'Dim R As RisultatoPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoIntermedio(Qta, QtaSecondaria, L, _Risultato)

        Dim R As RisPrezzoIntermedio = Nothing

        If L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            Dim QtaRichiesta As Single = 0
            Dim QtaSecondaria As Integer = 0

            Dim LatoFisso As Integer = (L.FormatoProdotto.FormatoCarta.Larghezza * 10)
            Dim LatoRiferimento As Single = Math.Sqrt(FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.CmQuadriEsempio)

            QtaSecondaria = ((LatoRiferimento * LatoRiferimento)) * Qta
            QtaRichiesta = MgrCalcoliTecnici.CalcolaCmQuadri(LatoRiferimento,
                                                             LatoRiferimento,
                                                             enTipoOrientamento.Orizzontale,
                                                             LatoFisso,
                                                             QtaRichiesta)

            R = MgrPreventivazioneB.CalcolaPrezzoFinale(L, Qta, listaBaseB, QtaSecondaria,, False,, LatoRiferimento, LatoRiferimento)

        Else
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(L, Qta, listaBaseB,,, False)
        End If

        Return R

    End Function

    Private Sub CalcolaPrezzo()

        'calcola se e' presente un coupon il prezzo netto , se non e' presente il prezzo normale
        Dim PrezzoFinale As Decimal = 0

        Try
            PrezzoFinale = CalcolaPrezzoPieno()
            If PrezzoFinale Then
                Dim ImportoCoupon As Decimal = CheckCoupon()
                Dim ImportoPromo As Decimal = 0
                Dim PrezzoPromo As Decimal = 0

                If ListinoBase.ExistPromo Then
                    Dim PrezzoSlow As Decimal = PrezzoFinale * MgrPercentualiDay.PercentualeSlow(ListinoBase.Preventivazione)
                    PrezzoSlow = Math.Floor(PrezzoSlow)
                    PrezzoPromo = ListinoBase.Promo.GetPrezzoPromo(PrezzoSlow)
                    ImportoPromo = PrezzoSlow - PrezzoPromo
                End If

                If ImportoPromo > 0 And (ImportoPromo >= ImportoCoupon) Then
                    'qui devo usare il promo
                    _Prezzo = PrezzoPromo
                    _PrezzoInveceDi = PrezzoFinale
                    InPromo = True
                ElseIf ImportoCoupon > 0 Then
                    _Prezzo = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(PrezzoFinale - ImportoCoupon, 2)
                    _PrezzoInveceDi = PrezzoFinale
                Else
                    _Prezzo = PrezzoFinale
                    _PrezzoInveceDi = 0
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function CalcolaPrezzoPieno() As Decimal
        Dim ris As Decimal = 0
        Try

            ListinoBase.CaricaLavorazioni()
            Dim R As RisPrezzoIntermedio = CalcolaPrezzi(ListinoBase, Qta, Fogli)

            If Tm.FiltroMarketing.Tipo = enTipoRubrica.Rivenditore Then
                ris = R.PrezzoRiv
            Else
                ris = R.PrezzoPubbl
            End If
        Catch ex As Exception

        End Try

        Return ris

    End Function

End Class
