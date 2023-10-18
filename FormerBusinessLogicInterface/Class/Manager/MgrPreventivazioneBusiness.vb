Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrPreventivazioneB

    Public Shared ReadOnly Property VMotoreCalcolo As Integer
        Get
            Dim Versione As Integer = 5

            Return Versione
        End Get
    End Property

    Public Shared Function GetMoltiplicatoreByQta(L As IListinoBaseB,
                                                  Qta As Single) As Integer
        Dim ris As Integer = 0

        If Qta < L.qta1 Then
            If L.AbilitaQtaSottoColonna1 = enSiNo.Si Then ris = L.MoltiplicatoreQta0
        ElseIf Qta >= L.qta1 And Qta < L.qta2 Then
            ris = L.MoltiplicatoreQta
            If L.AbilitaQtaIntermedie = enSiNo.Si AndAlso (L.MoltiplicatoreQta = 0 Or L.MoltiplicatoreQtaIntermedia < L.MoltiplicatoreQta) Then
                ris = L.MoltiplicatoreQtaIntermedia
            End If
        ElseIf Qta >= L.qta2 And Qta < L.qta3 Then
            ris = L.MoltiplicatoreQta2
            If L.AbilitaQtaIntermedie = enSiNo.Si AndAlso (L.MoltiplicatoreQta2 = 0 Or L.MoltiplicatoreQtaIntermedia < L.MoltiplicatoreQta2) Then
                ris = L.MoltiplicatoreQtaIntermedia
            End If
        ElseIf Qta >= L.qta3 And Qta < L.qta4 Then
            ris = L.MoltiplicatoreQta3
            If L.AbilitaQtaIntermedie = enSiNo.Si AndAlso (L.MoltiplicatoreQta3 = 0 Or L.MoltiplicatoreQtaIntermedia < L.MoltiplicatoreQta3) Then
                ris = L.MoltiplicatoreQtaIntermedia
            End If
        ElseIf Qta >= L.qta4 And Qta < L.qta5 Then
            ris = L.MoltiplicatoreQta4
            If L.AbilitaQtaIntermedie = enSiNo.Si AndAlso (L.MoltiplicatoreQta4 = 0 Or L.MoltiplicatoreQtaIntermedia < L.MoltiplicatoreQta4) Then
                ris = L.MoltiplicatoreQtaIntermedia
            End If
        ElseIf Qta >= L.qta5 And Qta < L.qta6 Then
            ris = L.MoltiplicatoreQta5
            If L.AbilitaQtaIntermedie = enSiNo.Si AndAlso (L.MoltiplicatoreQta5 = 0 Or L.MoltiplicatoreQtaIntermedia < L.MoltiplicatoreQta5) Then
                ris = L.MoltiplicatoreQtaIntermedia
            End If
        End If

        'If ris = 0 Then ris = 1

        Return ris
    End Function

    Public Shared Function ArrotondaQtaConMoltiplicatore(QtaIniziale As Single,
                                                         Lb As IListinoBaseB,
                                                         Optional ForzaMoltiplicatore As Integer = 0) As Single
        Dim ris As Single = QtaIniziale

        'If QtaIniziale > Lb.qta6 Then
        '    ris = Lb.qta6
        'Else

        If Lb.TipoPrezzo = enTipoPrezzo.SuQuantita Then
            Dim Moltiplicatore As Integer = MgrPreventivazioneB.GetMoltiplicatoreByQta(Lb, QtaIniziale)

            If ForzaMoltiplicatore Then
                Moltiplicatore = ForzaMoltiplicatore
            End If

            If Moltiplicatore Then
                'Dim x As Integer = QtaIniziale \ Moltiplicatore

                'ris = Moltiplicatore * x

                If QtaIniziale <> Lb.qta1 AndAlso
                   QtaIniziale <> Lb.qta2 AndAlso
                   QtaIniziale <> Lb.qta3 AndAlso
                   QtaIniziale <> Lb.qta4 AndAlso
                   QtaIniziale <> Lb.qta5 AndAlso
                   QtaIniziale <> Lb.qta6 Then

                    Dim x As Integer = Math.Ceiling(QtaIniziale / Moltiplicatore)
                    ris = Moltiplicatore * x
                End If

            End If
        End If

        'End If

        Return ris
    End Function

    Private Shared Function CalcolaPrezzoDiretto(QtaRich As Single,
                                                 L As IListinoBaseB,
                                                 lstLavObbl As List(Of ILavorazioneB),
                                                 Optional lstLavOpz As List(Of ILavorazioneB) = Nothing,
                                                 Optional AltezzaMm As Integer = 0,
                                                 Optional LarghezzaMm As Integer = 0,
                                                 Optional UsaMacchinarioAlternativo As Boolean = False) As RisPrezzoIntermedio

        Dim Ris As New RisPrezzoIntermedio

        Dim Tc As ITipoCartaB = L.TipoCarta
        Dim Cs As IColoreStampaB = L.ColoreStampa
        Dim Fm As IFormatoB = Nothing
        Dim R As ResaFPsuFM = Nothing

        If UsaMacchinarioAlternativo Then
            Fm = L.Formato2
            R = L.Resa2
        Else
            Fm = L.Formato
            R = L.Resa
        End If

        Dim PrezzoStampa As Decimal = CalcolaPrezzoStampa(QtaRich, Fm, R, Cs, L, True).PrezzoNetto
        Ris.PrezzoRiv += PrezzoStampa

        Dim PrezzoCarta As Decimal = CalcolaPrezzoCarta(QtaRich, R, Fm, Tc, L)
        Ris.PrezzoRiv += PrezzoCarta

        For Each Lav As ILavorazioneB In lstLavObbl

            If Lav.IdTipoLav <> enTipoLavorazione.suCmQuadri Then
                'prima di aggiungerla controllo che non ci sia un altra lavorazione della stessa famiglia tra le opzionali

                Dim CalcolaNelPrezzo As Boolean = True

                If Not lstLavOpz Is Nothing Then
                    'If lstLavOpz.FindAll(Function(x) x.IdLavoro = Lav.IdLavoro).Count = 0 Then
                    If (Lav.Categoria.TipoCaratteristica = enSiNo.Si And Lav.Categoria.TipoControllo = enTipoControllo.CheckBox) Then

                        If lstLavOpz.FindAll(Function(x) x.IdCatLav = Lav.IdCatLav And x.IdLavoro <> Lav.IdLavoro).Count Then
                            'qui non la devo calcolare
                            CalcolaNelPrezzo = False

                        End If
                    Else
                        For Each lopz As ILavorazioneB In lstLavOpz
                            If lopz.IdLavoro <> Lav.IdLavoro AndAlso lopz.IdCatLav = Lav.IdCatLav Then
                                CalcolaNelPrezzo = False
                                Exit For
                            End If
                        Next
                    End If

                End If

                If CalcolaNelPrezzo Then
                    Dim PLav As Decimal = CalcolaPrezzoLavorazione(QtaRich, Lav, L, L.TipoCarta, AltezzaMm, LarghezzaMm, True).PrezzoTotale
                    Ris.PrezzoRiv += PLav
                End If
            End If

        Next

        If Not lstLavOpz Is Nothing Then

            For Each Lav As ILavorazioneB In lstLavOpz

                Dim CalcolaNelPrezzo As Boolean = True

                If (Lav.Categoria.TipoCaratteristica = enSiNo.Si And Lav.Categoria.TipoControllo = enTipoControllo.CheckBox) Then
                    If lstLavObbl.FindAll(Function(x) x.IdLavoro = Lav.IdLavoro).Count Then
                        If lstLavOpz.FindAll(Function(x) x.IdCatLav = Lav.IdCatLav And x.IdLavoro <> Lav.IdLavoro).Count = 0 Then
                            'qui non la devo calcolare
                            CalcolaNelPrezzo = False
                        End If
                    End If
                Else
                    If lstLavObbl.FindAll(Function(x) x.IdLavoro = Lav.IdLavoro).Count <> 0 Then CalcolaNelPrezzo = False
                End If

                If CalcolaNelPrezzo Then
                    If Lav.IdTipoLav <> enTipoLavorazione.suCmQuadri Then
                        Dim PLav As Decimal = CalcolaPrezzoLavorazione(QtaRich, Lav, L, L.TipoCarta, AltezzaMm, LarghezzaMm, True).PrezzoTotale
                        Ris.PrezzoRiv += PLav
                    End If
                End If

            Next

        End If

        Ris.PrezzoPubbl = ApplicaCurva(Ris.PrezzoRiv, L.CurvaAtt.v1)
        Ris.PrezzoConsigliatoPubbl = ApplicaCurva(Ris.PrezzoRiv, L.CurvaPub.v1)

        Ris.PrezzoRiv = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Ris.PrezzoRiv, 0)
        Ris.PrezzoPubbl = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Ris.PrezzoPubbl, 0)
        Ris.PrezzoConsigliatoPubbl = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Ris.PrezzoConsigliatoPubbl, 0)

        Return Ris

    End Function

    Private Shared Function CalcolaPrezzoIntermedio(ByVal R As RichiestaCalcoloPrezzo,
                                                   ByVal _Risultato As RisListinoBase,
                                                   ByVal _ListinoBase As IListinoBaseB,
                                                   ByVal lstLavObbl As List(Of ILavorazioneB),
                                                    Optional ByVal lstLavOpz As List(Of ILavorazioneB) = Nothing,
                                                    Optional ByVal IRp As IRisultatoPlugin = Nothing,
                                                    Optional ByVal AltezzaMm As Integer = 0,
                                                    Optional ByVal LarghezzaMm As Integer = 0,
                                                    Optional ByVal CalcolaPrezzoLavorazioniNonPreviste As Boolean = False) As RisPrezzoIntermedio

        If R.QtaRichiesta <> R.QtaDaUsareNelCalcoloLavorazioni Then
            'in questo caso il primo non lo arrotondo perche il moltiplicatore vale per le quantita espresse dall'utente 
            R.QtaDaUsareNelCalcoloLavorazioni = ArrotondaQtaConMoltiplicatore(R.QtaDaUsareNelCalcoloLavorazioni, _ListinoBase)
        Else
            R.QtaRichiesta = ArrotondaQtaConMoltiplicatore(R.QtaRichiesta, _ListinoBase)
            R.QtaDaUsareNelCalcoloLavorazioni = R.QtaRichiesta
        End If

        Dim Ris As New RisPrezzoIntermedio

        Dim QtaPrima As Integer = 0
        Dim QtaDopo As Integer = 0
        Dim PrezzoPrimaRiv As Decimal = 0
        Dim PrezzoDopoRiv As Decimal = 0
        Dim PrezzoPrimaPubbl As Decimal = 0
        Dim PrezzoDopoPubbl As Decimal = 0
        Dim PrezzoPrimaConsPubbl As Decimal = 0
        Dim PrezzoDopoConsPubbl As Decimal = 0

        Dim PrezzoFinaleRiv As Decimal = 0
        Dim PrezzoFinalePubbl As Decimal = 0
        Dim PrezzoFinaleConsPubbl As Decimal = 0

        Dim P1Riv As Decimal = _Risultato.PrezzoRivFinale1
        Dim P2Riv As Decimal = _Risultato.PrezzoRivFinale2
        Dim P3Riv As Decimal = _Risultato.PrezzoRivFinale3
        Dim P4Riv As Decimal = _Risultato.PrezzoRivFinale4
        Dim P5Riv As Decimal = _Risultato.PrezzoRivFinale5
        Dim P6Riv As Decimal = _Risultato.PrezzoRivFinale6

        Dim P1Pubbl As Decimal = _Risultato.PrezzoPubblFinale1
        Dim P2Pubbl As Decimal = _Risultato.PrezzoPubblFinale2
        Dim P3Pubbl As Decimal = _Risultato.PrezzoPubblFinale3
        Dim P4Pubbl As Decimal = _Risultato.PrezzoPubblFinale4
        Dim P5Pubbl As Decimal = _Risultato.PrezzoPubblFinale5
        Dim P6Pubbl As Decimal = _Risultato.PrezzoPubblFinale6

        Dim P1ConsPubbl As Decimal = _Risultato.PrezzoConsPubblFinale1
        Dim P2ConsPubbl As Decimal = _Risultato.PrezzoConsPubblFinale2
        Dim P3ConsPubbl As Decimal = _Risultato.PrezzoConsPubblFinale3
        Dim P4ConsPubbl As Decimal = _Risultato.PrezzoConsPubblFinale4
        Dim P5ConsPubbl As Decimal = _Risultato.PrezzoConsPubblFinale5
        Dim P6ConsPubbl As Decimal = _Risultato.PrezzoConsPubblFinale6

        'If _ListinoBase.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
        '    PrezzoFinaleRiv = P1Riv * QtaRich
        '    PrezzoFinalePubbl = P1Pubbl * QtaRich
        '    PrezzoFinaleConsPubbl = P1ConsPubbl * QtaRich
        'ElseIf _ListinoBase.TipoPrezzo = enTipoPrezzo.SuCopie Then
        'ElseIf _ListinoBase.TipoPrezzo = enTipoPrezzo.SuQuantita Or
        If _ListinoBase.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Or
           _ListinoBase.TipoPrezzo = enTipoPrezzo.SuQuantita Or
           _ListinoBase.TipoPrezzo = enTipoPrezzo.SuFoglio Or'TODO:MODIFICATOTIPOPREZZO
           _ListinoBase.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            If R.QtaRichiesta <= _ListinoBase.qta1 Then

                PrezzoFinaleRiv = P1Riv
                PrezzoFinalePubbl = P1Pubbl
                PrezzoFinaleConsPubbl = P1ConsPubbl

            ElseIf R.QtaRichiesta <= _ListinoBase.qta2 Then
                QtaPrima = _ListinoBase.qta1
                QtaDopo = _ListinoBase.qta2
                PrezzoPrimaRiv = P1Riv
                PrezzoDopoRiv = P2Riv
                PrezzoPrimaPubbl = P1Pubbl
                PrezzoDopoPubbl = P2Pubbl
                PrezzoPrimaConsPubbl = P1ConsPubbl
                PrezzoDopoConsPubbl = P2ConsPubbl
            ElseIf R.QtaRichiesta <= _ListinoBase.qta3 Then
                QtaPrima = _ListinoBase.qta2
                QtaDopo = _ListinoBase.qta3
                PrezzoPrimaRiv = P2Riv
                PrezzoDopoRiv = P3Riv
                PrezzoPrimaPubbl = P2Pubbl
                PrezzoDopoPubbl = P3Pubbl
                PrezzoPrimaConsPubbl = P2ConsPubbl
                PrezzoDopoConsPubbl = P3ConsPubbl
            ElseIf R.QtaRichiesta <= _ListinoBase.qta4 Then
                QtaPrima = _ListinoBase.qta3
                QtaDopo = _ListinoBase.qta4
                PrezzoPrimaRiv = P3Riv
                PrezzoDopoRiv = P4Riv
                PrezzoPrimaPubbl = P3Pubbl
                PrezzoDopoPubbl = P4Pubbl
                PrezzoPrimaConsPubbl = P3ConsPubbl
                PrezzoDopoConsPubbl = P4ConsPubbl
            ElseIf R.QtaRichiesta <= _ListinoBase.qta5 Then
                QtaPrima = _ListinoBase.qta4
                QtaDopo = _ListinoBase.qta5
                PrezzoPrimaRiv = P4Riv
                PrezzoDopoRiv = P5Riv
                PrezzoPrimaPubbl = P4Pubbl
                PrezzoDopoPubbl = P5Pubbl
                PrezzoPrimaConsPubbl = P4ConsPubbl
                PrezzoDopoConsPubbl = P5ConsPubbl
            ElseIf R.QtaRichiesta <= _ListinoBase.qta6 Then
                QtaPrima = _ListinoBase.qta5
                QtaDopo = _ListinoBase.qta6
                PrezzoPrimaRiv = P5Riv
                PrezzoDopoRiv = P6Riv
                PrezzoPrimaPubbl = P5Pubbl
                PrezzoDopoPubbl = P6Pubbl
                PrezzoPrimaConsPubbl = P5ConsPubbl
                PrezzoDopoConsPubbl = P6ConsPubbl
            Else
                PrezzoFinaleRiv = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(((P6Riv / _ListinoBase.qta6) * R.QtaRichiesta), 0)
                PrezzoFinalePubbl = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(((P6Pubbl / _ListinoBase.qta6) * R.QtaRichiesta), 0)
                PrezzoFinaleConsPubbl = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(((P6ConsPubbl / _ListinoBase.qta6) * R.QtaRichiesta), 0)
            End If

            If PrezzoFinaleRiv = 0 Then
                Dim DiffPrezzo As Single = PrezzoDopoRiv - PrezzoPrimaRiv
                Dim DiffQta As Integer = QtaDopo - QtaPrima
                Dim Incr As Double = 0
                Try
                    If DiffPrezzo = 0 And DiffQta = 0 Then
                        Incr = 0
                    Else
                        Incr = DiffPrezzo / DiffQta
                    End If

                Catch ex As Exception

                End Try

                Dim IncrQta As Single = R.QtaRichiesta - QtaPrima
                PrezzoFinaleRiv = (IncrQta * Incr) + PrezzoPrimaRiv

            End If

            If PrezzoFinalePubbl = 0 Then
                Dim DiffPrezzo As Single = PrezzoDopoPubbl - PrezzoPrimaPubbl
                Dim DiffQta As Integer = QtaDopo - QtaPrima
                Dim Incr As Double = 0
                Try
                    If DiffPrezzo = 0 And DiffQta = 0 Then
                        Incr = 0
                    Else
                        Incr = DiffPrezzo / DiffQta
                    End If

                Catch ex As Exception

                End Try
                Dim IncrQta As Single = R.QtaRichiesta - QtaPrima
                PrezzoFinalePubbl = (IncrQta * Incr) + PrezzoPrimaPubbl

            End If
            If PrezzoFinaleConsPubbl = 0 Then
                Dim DiffPrezzo As Single = PrezzoDopoConsPubbl - PrezzoPrimaConsPubbl
                Dim DiffQta As Integer = QtaDopo - QtaPrima
                Dim Incr As Double = 0
                Try
                    If DiffPrezzo = 0 And DiffQta = 0 Then
                        Incr = 0
                    Else
                        Incr = DiffPrezzo / DiffQta
                    End If

                Catch ex As Exception

                End Try
                Dim IncrQta As Single = R.QtaRichiesta - QtaPrima
                PrezzoFinaleConsPubbl = (IncrQta * Incr) + PrezzoPrimaConsPubbl

            End If

        End If

        'qui avro il prezzo intermedio. Nel caso pero si tratta di prezzo su cmquadri devo calcolare tutte le lavorazioni obbligatorie
        'e opzionali e applicarci sempre la curva corretta
        Dim PlavorazPost As Decimal = 0
        Dim PlavorazPostPubbl As Decimal = 0
        Dim PlavorazPostConsPubbl As Decimal = 0

        For Each Lav As ILavorazioneB In lstLavObbl

            If Lav.IdTipoLav = enTipoLavorazione.suCmQuadri Then

                Dim TrovataAltraLav As Boolean = False

                If Not lstLavOpz Is Nothing Then
                    For Each lopz As ILavorazioneB In lstLavOpz
                        If lopz.IdCatLav = Lav.IdCatLav Then TrovataAltraLav = True
                    Next
                End If

                If TrovataAltraLav = False Then
                    Dim QtaToSend As Single = R.QtaDaUsareNelCalcoloLavorazioni
                    If QtaToSend = 0 Then QtaToSend = R.QtaRichiesta
                    Dim Risp As RisCalcoloPrezzoLavorazione = CalcolaPrezzoLavorazione(QtaToSend,
                                                                   Lav,
                                                                   _ListinoBase,
                                                                   _ListinoBase.TipoCarta,,, CalcolaPrezzoLavorazioniNonPreviste,,,,,
                                                                   IRp)
                    R.AnomaliaPrezzoCalcolato = Risp.AnomaliaPrezzoCalcolato
                    PlavorazPost += Risp.PrezzoTotale
                End If
            ElseIf Lav.SePresenteCalcolaSuSoggetti = enSiNo.Si And _ListinoBase.ConSoggettiDuplicati = enSiNo.Si Then
                Dim Risp As RisCalcoloPrezzoLavorazione = CalcolaPrezzoLavorazione(R.QtaDaUsareNelCalcoloLavorazioni,
                                                               Lav,
                                                               _ListinoBase,
                                                               _ListinoBase.TipoCarta,,, CalcolaPrezzoLavorazioniNonPreviste,
                                                               LarghezzaMm,
                                                               AltezzaMm)
                R.AnomaliaPrezzoCalcolato = Risp.AnomaliaPrezzoCalcolato
                PlavorazPost += Risp.PrezzoTotale
            End If

        Next

        If Not lstLavOpz Is Nothing Then
            For Each Lav As ILavorazioneB In lstLavOpz
                If lstLavObbl.FindAll(Function(x) x.IdLavoro = Lav.IdLavoro).Count = 0 Then
                    If Lav.IdTipoLav = enTipoLavorazione.suCmQuadri Then
                        Dim QtaToSend As Single = R.QtaDaUsareNelCalcoloLavorazioni
                        If QtaToSend = 0 Then QtaToSend = R.QtaRichiesta
                        Dim Risp As RisCalcoloPrezzoLavorazione = CalcolaPrezzoLavorazione(QtaToSend, Lav, _ListinoBase, _ListinoBase.TipoCarta,,, CalcolaPrezzoLavorazioniNonPreviste,,,,, IRp)
                        R.AnomaliaPrezzoCalcolato = Risp.AnomaliaPrezzoCalcolato
                        PlavorazPost += Risp.PrezzoTotale
                    ElseIf Lav.SePresenteCalcolaSuSoggetti = enSiNo.Si And _ListinoBase.ConSoggettiDuplicati = enSiNo.Si Then
                        Dim Risp As RisCalcoloPrezzoLavorazione = CalcolaPrezzoLavorazione(R.QtaDaUsareNelCalcoloLavorazioni, Lav, _ListinoBase, _ListinoBase.TipoCarta,,, CalcolaPrezzoLavorazioniNonPreviste, LarghezzaMm, AltezzaMm)
                        R.AnomaliaPrezzoCalcolato = Risp.AnomaliaPrezzoCalcolato
                        PlavorazPost += Risp.PrezzoTotale
                    End If
                End If
            Next
        End If

        'qui ci calcolo sopra la curva di attenuazione per pubblico e privato e poi li sommo ai ripsettivi totali 
        If PlavorazPost Then
            PlavorazPostPubbl = ApplicaCurva(PlavorazPost, _ListinoBase.CurvaAtt.v1)
            PlavorazPostConsPubbl = ApplicaCurva(PlavorazPost, _ListinoBase.CurvaPub.v1)
        End If

        'If PlavorazPost Then
        '    PlavorazPost = ApplicaCurva(PlavorazPost, _ListinoBase.CurvaAtt.v1)
        '    PlavorazPostPubbl = ApplicaCurva(PlavorazPost, _ListinoBase.CurvaPub.v1)
        'End If


        'Ris.PrezzoRiv = PrezzoFinaleRiv + PlavorazPost
        'Ris.PrezzoPubbl = PrezzoFinalePubbl + PlavorazPostPubbl

        Ris.PrezzoRiv = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(PrezzoFinaleRiv + PlavorazPost, 0)
        Ris.PrezzoPubbl = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(PrezzoFinalePubbl + PlavorazPostPubbl, 0)
        Ris.PrezzoConsigliatoPubbl = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(PrezzoFinaleConsPubbl + PlavorazPostConsPubbl, 0)

        Return Ris

    End Function

    Public Shared Function CalcolaPrezzoFinale(ByVal L As IListinoBaseB,
                                               ByVal RichiesteCalcoloPrezzo As List(Of RichiestaCalcoloPrezzo),
                                               ByVal lstLavObbl As List(Of ILavorazioneB),
                                               Optional ByVal lstLavOpz As List(Of ILavorazioneB) = Nothing,
                                               Optional ByVal CalcolaPercAdattamento As Boolean = True,
                                               Optional ByVal AltezzaCm As Single = 0,
                                               Optional ByVal LarghezzaCm As Single = 0,
                                               Optional ByVal CalcolaPrezzoLavorazioniNonPreviste As Boolean = False,
                                               Optional ByVal IRp As IRisultatoPlugin = Nothing) As List(Of RisPrezzoIntermedio)

        Dim Ris As New List(Of RisPrezzoIntermedio)

        Dim risLb As RisListinoBase = Nothing

        Dim AltezzaMm As Integer = 0
        Dim LarghezzaMm As Integer = 0

        AltezzaMm = AltezzaCm * 10
        LarghezzaMm = LarghezzaCm * 10

        risLb = CalcolaPrezzi(L,
                              lstLavObbl,
                              lstLavOpz,
                              CalcolaPercAdattamento,
                              AltezzaMm,
                              LarghezzaMm,
                              CalcolaPrezzoLavorazioniNonPreviste)



        'If (L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Or L.TipoPrezzo = enTipoPrezzo.SuFoglio) AndAlso L.ConSoggettiDuplicati = enSiNo.Si Then
        '    'altezza e larghezza mi arrivano in cm , li devo convertire in mm

        'End If

        For Each Richiesta In RichiesteCalcoloPrezzo
            'qui vado a calcolare i singoli prezzi per qta
            Dim risRichiesta As RisPrezzoIntermedio = CalcolaPrezzoIntermedio(Richiesta,
                                                                              risLb,
                                                                              L,
                                                                              lstLavObbl,
                                                                              lstLavOpz,
                                                                              IRp,
                                                                              AltezzaMm,
                                                                              LarghezzaMm,
                                                                              CalcolaPrezzoLavorazioniNonPreviste)

            risRichiesta.RichiestaCalcoloPrezzo = Richiesta

            If Richiesta.QtaRichiesta < L.qta1 Then
                If L.AbilitaQtaSottoColonna1 = enSiNo.Si Then
                    If Not L.MacchinarioProduzione2 Is Nothing AndAlso L.MacchinarioProduzione2.IdMacchinario <> 0 Then

                        'Dim risLbAlternativo As RisListinoBase = Nothing
                        'risLbAlternativo = CalcolaPrezzi(L,
                        '            lstLavObbl,
                        '            lstLavOpz,
                        '            CalcolaPercAdattamento,
                        '            CalcolaPrezzoMercato,
                        '            Altezza,
                        '            Larghezza,
                        '            NumeroPezzi,
                        '            CalcolaPrezzoLavorazioniNonPreviste,
                        '            True)



                        Dim risAlternativo As RisPrezzoIntermedio

                        risAlternativo = CalcolaPrezzoDiretto(Richiesta.QtaRichiesta,
                                                              L,
                                                              lstLavObbl,
                                                              lstLavOpz,
                                                              AltezzaMm,
                                                              LarghezzaMm,
                                                              True) 'c'era cm 
                        risAlternativo.RichiestaCalcoloPrezzo = Richiesta

                        If risAlternativo.PrezzoRiv < risRichiesta.PrezzoRiv Then
                            risRichiesta = risAlternativo
                            risRichiesta.IdMacchinarioStampa = L.MacchinarioProduzione2.IdMacchinario
                        End If

                    End If

                End If
            End If
            'qui devo capire se aggiungerlo o no in lista 
            Ris.Add(risRichiesta)
        Next

        Return Ris

    End Function

    <Obsolete("This method is deprecated, use CalcolaPrezzoFinale con RichiestaDiCalcoloPrezzo.")>
    Public Shared Function CalcolaPrezzoFinale(L As IListinoBaseB,
                                               QtaRichiesta As Single,
                                               lstLavObbl As List(Of ILavorazioneB),
                                               Optional QtaDaUsareNelCalcoloLavorazioni As Single = 0,
                                               Optional lstLavOpz As List(Of ILavorazioneB) = Nothing,
                                               Optional CalcolaPercAdattamento As Boolean = True,
                                               Optional DEPRECATOCalcolaPrezzoMercato As Boolean = False,
                                               Optional AltezzaCm As Single = 0,
                                               Optional LarghezzaCm As Single = 0,
                                               Optional DEPRECATONumeroPezzi As Integer = 0,
                                               Optional CalcolaPrezzoLavorazioniNonPreviste As Boolean = False,
                                               Optional IRp As IRisultatoPlugin = Nothing) As RisPrezzoIntermedio

        Dim ris As RisPrezzoIntermedio
        Dim LRis As List(Of RisPrezzoIntermedio) = Nothing
        Dim Lric As New List(Of RichiestaCalcoloPrezzo)

        Dim ric As New RichiestaCalcoloPrezzo

        ric.QtaRichiesta = QtaRichiesta
        ric.QtaDaUsareNelCalcoloLavorazioni = QtaDaUsareNelCalcoloLavorazioni

        Lric.Add(ric)

        LRis = CalcolaPrezzoFinale(L,
                                  Lric,
                                  lstLavObbl,
                                  lstLavOpz,
                                  CalcolaPercAdattamento,
                                  AltezzaCm,
                                  LarghezzaCm,
                                  CalcolaPrezzoLavorazioniNonPreviste,
                                  IRp)

        If LRis.Count Then
            ris = LRis(0)
        End If


        'Dim risLb As RisListinoBase = Nothing

        'risLb = CalcolaPrezzi(L,
        '                      lstLavObbl,
        '                      lstLavOpz,
        '                      CalcolaPercAdattamento,
        '                      AltezzaCm,
        '                      LarghezzaCm,
        '                      CalcolaPrezzoLavorazioniNonPreviste)

        'Dim AltezzaMm As Integer = 0
        'Dim LarghezzaMm As Integer = 0

        'If (L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Or L.TipoPrezzo = enTipoPrezzo.SuFoglio) AndAlso L.ConSoggettiDuplicati = enSiNo.Si Then
        '    'altezza e larghezza mi arrivano in cm , li devo convertire in mm
        '    AltezzaMm = AltezzaCm * 10
        '    LarghezzaMm = LarghezzaCm * 10
        'End If

        'ris = CalcolaPrezzoIntermedio(QtaRichiesta,
        '                              QtaDaUsareNelCalcoloLavorazioni,
        '                              risLb,
        '                              L,
        '                              lstLavObbl,
        '                              lstLavOpz,
        '                              IRp,
        '                              AltezzaMm,
        '                              LarghezzaMm,
        '                              CalcolaPrezzoLavorazioniNonPreviste)

        'If QtaRichiesta < L.qta1 Then
        '    If L.AbilitaQtaSottoColonna1 = enSiNo.Si Then
        '        If Not L.MacchinarioProduzione2 Is Nothing AndAlso L.MacchinarioProduzione2.IdMacchinario <> 0 Then

        '            'Dim risLbAlternativo As RisListinoBase = Nothing
        '            'risLbAlternativo = CalcolaPrezzi(L,
        '            '            lstLavObbl,
        '            '            lstLavOpz,
        '            '            CalcolaPercAdattamento,
        '            '            CalcolaPrezzoMercato,
        '            '            Altezza,
        '            '            Larghezza,
        '            '            NumeroPezzi,
        '            '            CalcolaPrezzoLavorazioniNonPreviste,
        '            '            True)



        '            Dim risAlternativo As RisPrezzoIntermedio

        '            risAlternativo = CalcolaPrezzoDiretto(QtaRichiesta, L, lstLavObbl, lstLavOpz, AltezzaCm, LarghezzaCm, True)

        '            If risAlternativo.PrezzoRiv < ris.PrezzoRiv Then
        '                ris = risAlternativo
        '                ris.IdMacchinarioStampa = L.MacchinarioProduzione2.IdMacchinario
        '            End If

        '        End If

        '    End If
        'End If

        Return ris

    End Function

    Public Shared Function CalcolaPrezzi(ByRef L As IListinoBaseB,
                                ByVal lstLavObbl As List(Of ILavorazioneB),
                                Optional ByVal lstLavOpz As List(Of ILavorazioneB) = Nothing,
                                Optional ByVal CalcolaPercAdattamento As Boolean = True,
                                Optional ByVal AltezzaMm As Integer = 0,
                                Optional ByVal LarghezzaMm As Integer = 0,
                                Optional ByVal CalcolaPrezzoLavorazioniNonPreviste As Boolean = False) As RisListinoBase

        'chiamo la funzione interna che calcola il listino base 
        Dim Ris As RisListinoBase = CalcolaListinoBase(L,
                                                       lstLavObbl,
                                                       lstLavOpz,
                                                       AltezzaMm,
                                                       LarghezzaMm,
                                                       CalcolaPrezzoLavorazioniNonPreviste)

        If CalcolaPercAdattamento Then
            'calcolo le percentuali di adattamento
            'togliendo dal valore di mercato il costo delle lavorazioni obbligatorie in modo che siano a parita 
            Dim Val1 As Decimal = L.v1 - Ris.PrezzoLavObbl1
            Dim Val2 As Decimal = L.v2 - Ris.PrezzoLavObbl2
            Dim Val3 As Decimal = L.v3 - Ris.PrezzoLavObbl3
            Dim Val4 As Decimal = L.v4 - Ris.PrezzoLavObbl4
            Dim Val5 As Decimal = L.v5 - Ris.PrezzoLavObbl5
            Dim Val6 As Decimal = L.v6 - Ris.PrezzoLavObbl6

            L.p1 = CalcolaPercScarto(Val1, Ris.PrezzoRivCalc1)
            L.p2 = CalcolaPercScarto(Val2, Ris.PrezzoRivCalc2)
            L.p3 = CalcolaPercScarto(Val3, Ris.PrezzoRivCalc3)
            L.p4 = CalcolaPercScarto(Val4, Ris.PrezzoRivCalc4)
            L.p5 = CalcolaPercScarto(Val5, Ris.PrezzoRivCalc5)
            L.p6 = CalcolaPercScarto(Val6, Ris.PrezzoRivCalc6)
        End If

        Ris.P1 = L.p1
        Ris.P2 = L.p2
        Ris.P3 = L.p3
        Ris.P4 = L.p4
        Ris.P5 = L.p5
        Ris.P6 = L.p6

        '********qui ci applico la percentuale di adattamento
        If L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            Ris.PrezzoRivFinale1 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Ris.PrezzoRivCalc1, 0)
            Ris.PrezzoRivFinale2 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Ris.PrezzoRivCalc2, 0)
            Ris.PrezzoRivFinale3 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Ris.PrezzoRivCalc3, 0)
            Ris.PrezzoRivFinale4 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Ris.PrezzoRivCalc4, 0)
            Ris.PrezzoRivFinale5 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Ris.PrezzoRivCalc5, 0)
            Ris.PrezzoRivFinale6 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(Ris.PrezzoRivCalc6, 0)
        Else
            Ris.PrezzoRivFinale1 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((Ris.PrezzoRivCalc1 + ((Ris.PrezzoRivCalc1 * L.p1) / 100)), 0)
            Ris.PrezzoRivFinale2 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((Ris.PrezzoRivCalc2 + ((Ris.PrezzoRivCalc2 * L.p2) / 100)), 0)
            Ris.PrezzoRivFinale3 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((Ris.PrezzoRivCalc3 + ((Ris.PrezzoRivCalc3 * L.p3) / 100)), 0)
            Ris.PrezzoRivFinale4 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((Ris.PrezzoRivCalc4 + ((Ris.PrezzoRivCalc4 * L.p4) / 100)), 0)
            Ris.PrezzoRivFinale5 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((Ris.PrezzoRivCalc5 + ((Ris.PrezzoRivCalc5 * L.p5) / 100)), 0)
            Ris.PrezzoRivFinale6 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((Ris.PrezzoRivCalc6 + ((Ris.PrezzoRivCalc6 * L.p6) / 100)), 0)
        End If

        '********QUI CI DEVO SOMMARE IL PREZZO DELLE LAVORAZIONI
        Ris.PrezzoRivFinale1 += Ris.PrezzoLavObbl1 + Ris.PrezzoLavOpz1
        Ris.PrezzoRivFinale2 += Ris.PrezzoLavObbl2 + Ris.PrezzoLavOpz2
        Ris.PrezzoRivFinale3 += Ris.PrezzoLavObbl3 + Ris.PrezzoLavOpz3
        Ris.PrezzoRivFinale4 += Ris.PrezzoLavObbl4 + Ris.PrezzoLavOpz4
        Ris.PrezzoRivFinale5 += Ris.PrezzoLavObbl5 + Ris.PrezzoLavOpz5
        Ris.PrezzoRivFinale6 += Ris.PrezzoLavObbl6 + Ris.PrezzoLavOpz6

        '********AGGIUNTO per ATTIVARE LA CURVA DI ATTENUAZIONE A POSTERIORI 21/05/2014
        'DISATTIVATO IL CALCOLO DELLA CURVA SUL PREZZO RIVENDITORE 19/01/2017
        'Ris.PrezzoRivFinale1 = ApplicaCurva(Ris.PrezzoRivFinale1, L.CurvaAtt.v1)
        'Ris.PrezzoRivFinale2 = ApplicaCurva(Ris.PrezzoRivFinale2, L.CurvaAtt.v2)
        'Ris.PrezzoRivFinale3 = ApplicaCurva(Ris.PrezzoRivFinale3, L.CurvaAtt.v3)
        'Ris.PrezzoRivFinale4 = ApplicaCurva(Ris.PrezzoRivFinale4, L.CurvaAtt.v4)
        'Ris.PrezzoRivFinale5 = ApplicaCurva(Ris.PrezzoRivFinale5, L.CurvaAtt.v5)
        'Ris.PrezzoRivFinale6 = ApplicaCurva(Ris.PrezzoRivFinale6, L.CurvaAtt.v6)
        '********FINE AGGIUNTA

        'CALCOLO LA CURVA PER IL PREZZO AL PUBBLICO CHE E' La PRIMA 

        Ris.PrezzoPubblFinale1 = ApplicaCurva(Ris.PrezzoRivFinale1, L.CurvaAtt.v1)
        Ris.PrezzoPubblFinale2 = ApplicaCurva(Ris.PrezzoRivFinale2, L.CurvaAtt.v2)
        Ris.PrezzoPubblFinale3 = ApplicaCurva(Ris.PrezzoRivFinale3, L.CurvaAtt.v3)
        Ris.PrezzoPubblFinale4 = ApplicaCurva(Ris.PrezzoRivFinale4, L.CurvaAtt.v4)
        Ris.PrezzoPubblFinale5 = ApplicaCurva(Ris.PrezzoRivFinale5, L.CurvaAtt.v5)
        Ris.PrezzoPubblFinale6 = ApplicaCurva(Ris.PrezzoRivFinale6, L.CurvaAtt.v6)

        'CALCOLO LA CURVA PER IL PREZZO CONSIGLIATO AL PUBBLICO CHE E' La SECONDA
        Ris.PrezzoConsPubblFinale1 = ApplicaCurva(Ris.PrezzoRivFinale1, L.CurvaPub.v1)
        Ris.PrezzoConsPubblFinale2 = ApplicaCurva(Ris.PrezzoRivFinale2, L.CurvaPub.v2)
        Ris.PrezzoConsPubblFinale3 = ApplicaCurva(Ris.PrezzoRivFinale3, L.CurvaPub.v3)
        Ris.PrezzoConsPubblFinale4 = ApplicaCurva(Ris.PrezzoRivFinale4, L.CurvaPub.v4)
        Ris.PrezzoConsPubblFinale5 = ApplicaCurva(Ris.PrezzoRivFinale5, L.CurvaPub.v5)
        Ris.PrezzoConsPubblFinale6 = ApplicaCurva(Ris.PrezzoRivFinale6, L.CurvaPub.v6)

        Return Ris

    End Function

    Public Shared Function ApplicaCurva(PrezzoStart As Decimal, Perc As Single) As Decimal
        Dim ris As Decimal = PrezzoStart
        ris = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((PrezzoStart * Perc), 0)
        Return ris
    End Function

    Public Shared Function CalcolaListinoBase(ByVal L As IListinoBaseB,
                                               ByVal lstLavObbl As List(Of ILavorazioneB),
                                               Optional ByVal lstLavOpz As List(Of ILavorazioneB) = Nothing,
                                               Optional ByVal Altezza As Integer = 0,
                                               Optional ByVal Larghezza As Integer = 0,
                                               Optional ByVal CalcolaPrezzoLavorazioniNonPreviste As Boolean = False) As RisListinoBase

        Dim Ris As New RisListinoBase(L)

        Dim C As ICurvaAttB
        Dim CPubbl As ICurvaAttB

        C = L.CurvaAtt
        CPubbl = L.CurvaPub

        Dim Tc As ITipoCartaB = L.TipoCarta
        Dim Cs As IColoreStampaB = L.ColoreStampa

        Dim Fm As IFormatoB = L.Formato
        Dim R As ResaFPsuFM = Nothing
        R = L.Resa

        If Not R Is Nothing Then

            Ris.PrezzoStampa1 = CalcolaPrezzoStampa(L.qta1, Fm, R, Cs, L, False).PrezzoNetto
            Ris.PrezzoStampa2 = CalcolaPrezzoStampa(L.qta2, Fm, R, Cs, L, False).PrezzoNetto
            Ris.PrezzoStampa3 = CalcolaPrezzoStampa(L.qta3, Fm, R, Cs, L, False).PrezzoNetto
            Ris.PrezzoStampa4 = CalcolaPrezzoStampa(L.qta4, Fm, R, Cs, L, False).PrezzoNetto
            Ris.PrezzoStampa5 = CalcolaPrezzoStampa(L.qta5, Fm, R, Cs, L, False).PrezzoNetto
            Ris.PrezzoStampa6 = CalcolaPrezzoStampa(L.qta6, Fm, R, Cs, L, False).PrezzoNetto

            Ris.PrezzoRivCalc1 += Ris.PrezzoStampa1
            Ris.PrezzoRivCalc2 += Ris.PrezzoStampa2
            Ris.PrezzoRivCalc3 += Ris.PrezzoStampa3
            Ris.PrezzoRivCalc4 += Ris.PrezzoStampa4
            Ris.PrezzoRivCalc5 += Ris.PrezzoStampa5
            Ris.PrezzoRivCalc6 += Ris.PrezzoStampa6

            'calcolo e aggiungo il costo impianti

            Ris.CostoImpianti = CalcolaPrezzoImpianti(R, Fm, Cs, L)

            Ris.PrezzoRivCalc1 += Ris.CostoImpianti
            Ris.PrezzoRivCalc2 += Ris.CostoImpianti
            Ris.PrezzoRivCalc3 += Ris.CostoImpianti
            Ris.PrezzoRivCalc4 += Ris.CostoImpianti
            Ris.PrezzoRivCalc5 += Ris.CostoImpianti
            Ris.PrezzoRivCalc6 += Ris.CostoImpianti



            'applico la curva rivenditori
            '********commentato per ATTIVARE LA CURVA DI ATTENUAZIONE A POSTERIORI 21/05/2014
            'Ris.PrezzoRivCalc1 = CalcolaPrezzoCurva(Ris.PrezzoRivCalc1, C.v1)
            'Ris.PrezzoRivCalc2 = CalcolaPrezzoCurva(Ris.PrezzoRivCalc2, C.v2)
            'Ris.PrezzoRivCalc3 = CalcolaPrezzoCurva(Ris.PrezzoRivCalc3, C.v3)
            'Ris.PrezzoRivCalc4 = CalcolaPrezzoCurva(Ris.PrezzoRivCalc4, C.v4)
            'Ris.PrezzoRivCalc5 = CalcolaPrezzoCurva(Ris.PrezzoRivCalc5, C.v5)
            'Ris.PrezzoRivCalc6 = CalcolaPrezzoCurva(Ris.PrezzoRivCalc6, C.v6)

            'calcolo e aggiungo il costo carta

            Ris.PrezzoCarta1 = CalcolaPrezzoCarta(L.qta1, R, Fm, Tc, L)
            Ris.PrezzoCarta2 = CalcolaPrezzoCarta(L.qta2, R, Fm, Tc, L)
            Ris.PrezzoCarta3 = CalcolaPrezzoCarta(L.qta3, R, Fm, Tc, L)
            Ris.PrezzoCarta4 = CalcolaPrezzoCarta(L.qta4, R, Fm, Tc, L)
            Ris.PrezzoCarta5 = CalcolaPrezzoCarta(L.qta5, R, Fm, Tc, L)
            Ris.PrezzoCarta6 = CalcolaPrezzoCarta(L.qta6, R, Fm, Tc, L)

            Ris.PrezzoTotCartaImpianti1 = Ris.PrezzoCarta1 + Ris.CostoImpianti
            Ris.PrezzoTotCartaImpianti2 = Ris.PrezzoCarta2 + Ris.CostoImpianti
            Ris.PrezzoTotCartaImpianti3 = Ris.PrezzoCarta3 + Ris.CostoImpianti
            Ris.PrezzoTotCartaImpianti4 = Ris.PrezzoCarta4 + Ris.CostoImpianti
            Ris.PrezzoTotCartaImpianti5 = Ris.PrezzoCarta5 + Ris.CostoImpianti
            Ris.PrezzoTotCartaImpianti6 = Ris.PrezzoCarta6 + Ris.CostoImpianti

            Ris.PrezzoRivCalc1 += Ris.PrezzoCarta1
            Ris.PrezzoRivCalc2 += Ris.PrezzoCarta2
            Ris.PrezzoRivCalc3 += Ris.PrezzoCarta3
            Ris.PrezzoRivCalc4 += Ris.PrezzoCarta4
            Ris.PrezzoRivCalc5 += Ris.PrezzoCarta5
            Ris.PrezzoRivCalc6 += Ris.PrezzoCarta6

            For Each Lav As ILavorazioneB In lstLavObbl
                Dim CalcolareNelPrezzo As Boolean = True
                If Lav.IdTipoLav = enTipoLavorazione.suCmQuadri Then
                    CalcolareNelPrezzo = False
                Else
                    If Lav.SePresenteCalcolaSuSoggetti = enSiNo.Si AndAlso L.ConSoggettiDuplicati = enSiNo.Si Then
                        CalcolareNelPrezzo = False
                    End If
                End If

                If CalcolareNelPrezzo Then
                    'prima di aggiungerla controllo che non ci sia un altra lavorazione della stessa famiglia tra le opzionali

                    Dim CalcolaNelPrezzo As Boolean = True

                    If Not lstLavOpz Is Nothing Then
                        'If lstLavOpz.FindAll(Function(x) x.IdLavoro = Lav.IdLavoro).Count = 0 Then
                        If (Lav.Categoria.TipoCaratteristica = enSiNo.Si And Lav.Categoria.TipoControllo = enTipoControllo.CheckBox) Then

                            If lstLavOpz.FindAll(Function(x) x.IdCatLav = Lav.IdCatLav And x.IdLavoro <> Lav.IdLavoro).Count Then
                                'qui non la devo calcolare
                                CalcolaNelPrezzo = False

                            End If
                        Else
                            For Each lopz As ILavorazioneB In lstLavOpz
                                If lopz.IdLavoro <> Lav.IdLavoro AndAlso lopz.IdCatLav = Lav.IdCatLav Then
                                    CalcolaNelPrezzo = False
                                    Exit For
                                End If
                            Next
                        End If

                        'For Each lopz As ILavorazioneB In lstLavOpz
                        '    If Not (lopz.Categoria.TipoCaratteristica = enSiNo.Si And lopz.Categoria.TipoControllo = enTipoControllo.CheckBox) Then
                        '        If lopz.IdLavoro <> Lav.IdLavoro AndAlso lopz.IdCatLav = Lav.IdCatLav Then CalcolaNelPrezzo = False
                        '    End If
                        'Next
                        'Else
                        'TrovataAltraLav = True
                        'End If
                    End If

                    If CalcolaNelPrezzo Then
                        Dim PLav1 As Decimal = CalcolaPrezzoLavorazione(L.qta1, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                        Dim PLav2 As Decimal = CalcolaPrezzoLavorazione(L.qta2, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                        Dim PLav3 As Decimal = CalcolaPrezzoLavorazione(L.qta3, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                        Dim PLav4 As Decimal = CalcolaPrezzoLavorazione(L.qta4, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                        Dim PLav5 As Decimal = CalcolaPrezzoLavorazione(L.qta5, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                        Dim PLav6 As Decimal = CalcolaPrezzoLavorazione(L.qta6, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale

                        'Ris.PrezzoRivCalc1 += PLav1
                        'Ris.PrezzoRivCalc2 += PLav2
                        'Ris.PrezzoRivCalc3 += PLav3
                        'Ris.PrezzoRivCalc4 += PLav4
                        'Ris.PrezzoRivCalc5 += PLav5
                        'Ris.PrezzoRivCalc6 += PLav6

                        Ris.PrezzoLavObbl1 += PLav1
                        Ris.PrezzoLavObbl2 += PLav2
                        Ris.PrezzoLavObbl3 += PLav3
                        Ris.PrezzoLavObbl4 += PLav4
                        Ris.PrezzoLavObbl5 += PLav5
                        Ris.PrezzoLavObbl6 += PLav6
                    End If
                End If

            Next

            If Not lstLavOpz Is Nothing Then

                For Each Lav As ILavorazioneB In lstLavOpz

                    Dim CalcolaNelPrezzo As Boolean = True

                    If (Lav.Categoria.TipoCaratteristica = enSiNo.Si And Lav.Categoria.TipoControllo = enTipoControllo.CheckBox) Then
                        If lstLavObbl.FindAll(Function(x) x.IdLavoro = Lav.IdLavoro).Count Then
                            If lstLavOpz.FindAll(Function(x) x.IdCatLav = Lav.IdCatLav And x.IdLavoro <> Lav.IdLavoro).Count = 0 Then
                                'qui non la devo calcolare
                                CalcolaNelPrezzo = False
                            End If
                        End If
                    Else
                        If lstLavObbl.FindAll(Function(x) x.IdLavoro = Lav.IdLavoro).Count <> 0 Then CalcolaNelPrezzo = False
                    End If

                    If CalcolaNelPrezzo Then
                        If Lav.PrevistaSu(L.IdListinoBase) = True OrElse
                           CalcolaPrezzoLavorazioniNonPreviste = True OrElse
                           Lav.IdTipoLav = enTipoLavorazione.UnaTantum Then

                            Dim CalcolareNelPrezzo As Boolean = True
                            If Lav.IdTipoLav = enTipoLavorazione.suCmQuadri Then
                                CalcolareNelPrezzo = False
                            Else
                                If Lav.SePresenteCalcolaSuSoggetti = enSiNo.Si AndAlso L.ConSoggettiDuplicati = enSiNo.Si Then
                                    CalcolareNelPrezzo = False
                                End If
                            End If

                            If CalcolareNelPrezzo Then
                                Dim PLav1 As Decimal = CalcolaPrezzoLavorazione(L.qta1, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                                Dim PLav2 As Decimal = CalcolaPrezzoLavorazione(L.qta2, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                                Dim PLav3 As Decimal = CalcolaPrezzoLavorazione(L.qta3, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                                Dim PLav4 As Decimal = CalcolaPrezzoLavorazione(L.qta4, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                                Dim PLav5 As Decimal = CalcolaPrezzoLavorazione(L.qta5, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale
                                Dim PLav6 As Decimal = CalcolaPrezzoLavorazione(L.qta6, Lav, L, Tc, Altezza, Larghezza, CalcolaPrezzoLavorazioniNonPreviste, L.ForzatoFormatoW, L.ForzatoFormatoH, L.ForzatoIdFormProd, L.ForzatoIdFormCarta).PrezzoTotale

                                'Ris.PrezzoRivCalc1 += PLav1
                                'Ris.PrezzoRivCalc2 += PLav2
                                'Ris.PrezzoRivCalc3 += PLav3
                                'Ris.PrezzoRivCalc4 += PLav4
                                'Ris.PrezzoRivCalc5 += PLav5
                                'Ris.PrezzoRivCalc6 += PLav6

                                Ris.PrezzoLavOpz1 += PLav1
                                Ris.PrezzoLavOpz2 += PLav2
                                Ris.PrezzoLavOpz3 += PLav3
                                Ris.PrezzoLavOpz4 += PLav4
                                Ris.PrezzoLavOpz5 += PLav5
                                Ris.PrezzoLavOpz6 += PLav6
                            End If
                        End If
                    End If

                Next

            End If

            'APPLICO LA CURVA DI ATTENUAZIONE ALLE LAVORAZIONI
            'Ris.PrezzoLavObbl1 = CalcolaPrezzoCurva(Ris.PrezzoLavObbl1, C.v1)
            'Ris.PrezzoLavObbl2 = CalcolaPrezzoCurva(Ris.PrezzoLavObbl2, C.v2)
            'Ris.PrezzoLavObbl3 = CalcolaPrezzoCurva(Ris.PrezzoLavObbl3, C.v3)
            'Ris.PrezzoLavObbl4 = CalcolaPrezzoCurva(Ris.PrezzoLavObbl4, C.v4)
            'Ris.PrezzoLavObbl5 = CalcolaPrezzoCurva(Ris.PrezzoLavObbl5, C.v5)
            'Ris.PrezzoLavObbl6 = CalcolaPrezzoCurva(Ris.PrezzoLavObbl6, C.v6)

            ''APPLICO LA CURVA DI ATTENUAZIONE ALLE LAVORAZIONI OPZIONALI
            'Ris.PrezzoLavOpz1 = CalcolaPrezzoCurva(Ris.PrezzoLavOpz1, C.v1)
            'Ris.PrezzoLavOpz2 = CalcolaPrezzoCurva(Ris.PrezzoLavOpz2, C.v2)
            'Ris.PrezzoLavOpz3 = CalcolaPrezzoCurva(Ris.PrezzoLavOpz3, C.v3)
            'Ris.PrezzoLavOpz4 = CalcolaPrezzoCurva(Ris.PrezzoLavOpz4, C.v4)
            'Ris.PrezzoLavOpz5 = CalcolaPrezzoCurva(Ris.PrezzoLavOpz5, C.v5)
            'Ris.PrezzoLavOpz6 = CalcolaPrezzoCurva(Ris.PrezzoLavOpz6, C.v6)

        Else
            'qui c'e' un errore di concetto con una resa non presente
        End If

        Return Ris

    End Function

    Public Shared Function CalcolaKgCarta(Qta As Single,
                                          L As IListinoBaseB,
                                          Optional TieniContoResa As Boolean = True) As Single
        Dim Ris As Single = 0

        Dim Fp As IFormatoProdottoB = L.FormatoProdotto

        Dim Tc As ITipoCartaB = L.TipoCarta

        Dim R As ResaFPsuFM = L.Resa
        Dim Fc As IFormatoCartaB = R.FormatoCarta

        Dim MoltiplF As Integer = L.NumFacciate / 2

        Dim QtaRif As Integer = Qta * MoltiplF

        Dim Pz As Single = QtaRif '/ R.Resa

        If TieniContoResa Then Pz = Pz / R.Resa

        Dim Kg As Single = 0

        If Tc.ComposizioniCarta.Count Then

            For Each Composizione In Tc.ComposizioniCarta
                Kg += CalcolaKgCarta(Fc.Altezza, Fc.Larghezza, Tc.Grammi, (Pz * Composizione.NumFogli))
            Next

        Else

            Kg = CalcolaKgCarta(Fc.Altezza, Fc.Larghezza, Tc.Grammi, Pz)

        End If

        Ris = Math.Round(Kg)

        If Ris = 0 Then Ris = 1

        Return Ris

    End Function

    Private Shared Function CalcolaPrezzoLavorazioneEx(Qta As Integer,
                                                    L As ILavorazioneB,
                                                    Lb As IListinoBaseB,
                                                    Tc As ITipoCartaB,
                                                    Optional AltezzaMm As Integer = 0,
                                                    Optional LarghezzaMm As Integer = 0,
                                                    Optional CalcolaPrezzoLavorazioniNonPreviste As Boolean = False,
                                                    Optional FormatoWForzato As Integer = 0,
                                                    Optional FormatoHForzato As Integer = 0,
                                                    Optional IdFormProdForzato As Integer = 0,
                                                    Optional IdFormCartaForzato As Integer = 0,
                                                    Optional Rp As IRisultatoPlugin = Nothing,
                                                    Optional UsaSecondoMacchinario As Boolean = False) As Decimal
        'QUI NON PRENDO MAI IN CONSIDERAZIONE LE LAVORAZIONI SU CENTIMETRO QUADRO PERCHE NON VENGONO CALCOLATE IN QUESTA FASE
        'MA SOLO SUL PREZZO INTERMEDIO IN QUANTO SI APPLICA SOLO SULLA QUANTITA REALMENTE LAVORATA 

        Dim Ris As Decimal = 0

        'qui devo controllare se la lavorazione è prevista su questo listino base altrimenti tornare zero
        'metto anche cheentra per i listinibase con listinobase Id 0 perche quando li salvi da parte amministrazione
        'i listinibase sono oggetti nuovi per fare i calcoli chenon hanno mai id
        'quindi in quel caso e' sempre prevista la lavorazione
        'in caso di lavorazioni una tantum entra cmq perche va conteggiata anche se non era prevista 
        If Lb.IdListinoBase = 0 OrElse
           L.PrevistaSu(Lb.IdListinoBase) OrElse
           L.IdTipoLav = enTipoLavorazione.UnaTantum OrElse
           CalcolaPrezzoLavorazioniNonPreviste = True Then

            Dim QtaRiferimento As Integer = 0
            Dim PrezzoToUse As Decimal = 0
            Dim PrezzoToUse2 As Decimal = 0

            Dim NumFacciate As Integer = Lb.NumFacciate
            Dim NumFogli As Integer = Lb.NumFacciate / 2

            Dim CostoSingolaUnita As Decimal = 0

            Dim IdFormProdRif As Integer = Lb.IdFormProd
            Dim IdFormCartaRif As Integer = Lb.FormatoCarta.IdFormCarta

            If IdFormProdForzato Then IdFormProdRif = IdFormProdForzato
            If IdFormCartaForzato Then IdFormCartaRif = IdFormCartaForzato

            Dim P As IPrezzoLavoroB = Nothing

            'If FormatoWForzato = 0 Then
            P = L.Prezzi.Find(Function(x) x.IdFormProd = IdFormProdRif)
            'End If

            If P Is Nothing Or IdFormProdRif = 0 Then
                '27/04/2015 - MODIFICA PER PRENDERE IL FORMATO CARTA BASE DI QUEL FORMATO PRODOTTO SPECIFICO
                'if FormatoWForzato = 0 Then
                P = L.Prezzi.Find(Function(x) x.IdFormCarta = IdFormCartaRif) ' And x.PrezzoSuProdottoFinito = False) ' MODIFICA 21/05/2019 PER PRENDERE IL PREZZO SULLO STESSO FORMATO CARTA ANCHE SE NON SPECIFICO
                'End If
                'P = L.Prezzi.Find(Function(x) x.IdFormProd = 0)
                If Not P Is Nothing And IdFormCartaRif <> 0 Then
                    QtaRiferimento = P.QtaRif
                    PrezzoToUse = P.Prezzo
                    PrezzoToUse2 = P.Prezzo2

                    If UsaSecondoMacchinario Then
                        CostoSingolaUnita = P.Prezzo2
                    Else
                        CostoSingolaUnita = P.Prezzo
                    End If
                Else

                    'se ho forzato i valori passo quelli altrimenti faccio diventare forzati i valori del formato prodotto 
                    If FormatoWForzato = 0 And FormatoHForzato = 0 Then
                        If AltezzaMm <> 0 And LarghezzaMm <> 0 Then
                            FormatoWForzato = LarghezzaMm
                            FormatoHForzato = AltezzaMm
                        Else
                            FormatoWForzato = Lb.FormatoProdotto.Larghezza
                            FormatoHForzato = Lb.FormatoProdotto.Lunghezza
                        End If
                    End If

                    'QUI NON AVENDO TROVATO UNO SPECIFICO NEL FORMATO PRODOTTO O NEL FORMATO CARTA
                    'VADO A FARE UNA PROPORZIONE PER TROVARE UN GENERICO FATTIBILE
                    'PER FUNZIONARE HO SEMPRE BISOGNO DEL GENERICO MINIMO E GENERICO MASSIMO

                    If FormatoWForzato <> 0 AndAlso FormatoHForzato <> 0 Then

                        Dim pMin As IPrezzoLavoroB = L.Prezzi.Find(Function(x) x.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Piccolo)
                        Dim pMax As IPrezzoLavoroB = L.Prezzi.Find(Function(x) x.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Grande)

                        'cerco il prezzo sul meno piu piccolo e il meno piu grande
                        Dim Lp As New List(Of IPrezzoLavoroB)
                        Lp.AddRange(L.Prezzi.FindAll(Function(x) x.IdFormProd <> 0))
                        'Lp.AddRange(L.Prezzi)
                        If Lp.Count Then
                            Lp.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))
                        End If

                        If Not pMin Is Nothing Then Lp.Insert(0, pMin)
                        If Not pMax Is Nothing Then Lp.Insert(Lp.Count, pMax)

                        Dim pPrima As IPrezzoLavoroB = Nothing
                        Dim pDopo As IPrezzoLavoroB = Nothing

                        For Each pSing As IPrezzoLavoroB In Lp
                            Dim Larghezza As Integer = 0
                            Dim Altezza As Integer = 0

                            If pSing.IdFormProd Then
                                Larghezza = pSing.FormatoProdotto.Larghezza
                                Altezza = pSing.FormatoProdotto.Lunghezza
                            Else
                                If pSing.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Piccolo Then
                                    Larghezza = L.DimensMinW
                                    Altezza = L.DimensMinH
                                ElseIf pSing.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Grande Then
                                    Larghezza = L.DimensMaxW
                                    Altezza = L.DimensMaxH
                                End If

                            End If

                            If pSing.IdFormProd Then
                                'se si tratta di un formato esistente li confronto per area
                                Dim AreaFp As Integer = Larghezza * Altezza
                                Dim AreaRic As Integer = FormatoWForzato * FormatoHForzato

                                If AreaFp <= AreaRic Then
                                    pPrima = pSing
                                End If
                                If pDopo Is Nothing Then
                                    If AreaFp >= AreaRic Then
                                        pDopo = pSing
                                    End If
                                End If
                            Else
                                'se mi baso sulle misure fisse per la lavorazione confronto proprio le misure 
                                If (Larghezza <= FormatoWForzato And Altezza <= FormatoHForzato) OrElse
                                   (Larghezza <= FormatoHForzato And Altezza <= FormatoWForzato) Then
                                    pPrima = pSing
                                End If
                                If pDopo Is Nothing Then
                                    If (Larghezza >= FormatoWForzato And Altezza >= FormatoHForzato) OrElse
                                        (Larghezza >= FormatoHForzato And Altezza >= FormatoWForzato) Then
                                        pDopo = pSing
                                    End If
                                End If
                            End If
                        Next

                        Dim PrezzoCalcolato As Decimal = 0

                        If Not pPrima Is Nothing AndAlso Not pDopo Is Nothing Then
                            Dim cm2Min As Integer = 0
                            Dim cm2Max As Integer = 0

                            Dim LarghezzaPrima As Integer = 0
                            Dim AltezzaPrima As Integer = 0

                            Dim LarghezzaDopo As Integer = 0
                            Dim AltezzaDopo As Integer = 0

                            If pPrima.IdFormProd Then
                                LarghezzaPrima = pPrima.FormatoProdotto.Larghezza
                                AltezzaPrima = pPrima.FormatoProdotto.Lunghezza
                            Else
                                LarghezzaPrima = L.DimensMinW
                                AltezzaPrima = L.DimensMinH
                            End If

                            If pDopo.IdFormProd Then
                                LarghezzaDopo = pDopo.FormatoProdotto.Larghezza
                                AltezzaDopo = pDopo.FormatoProdotto.Lunghezza
                            Else
                                LarghezzaDopo = L.DimensMaxW
                                AltezzaDopo = L.DimensMaxH
                            End If

                            cm2Min = Math.Ceiling(LarghezzaPrima * AltezzaPrima) / 10
                            cm2Max = Math.Ceiling(LarghezzaDopo * AltezzaDopo) / 10

                            Dim cm2Sviluppati As Integer = (FormatoWForzato * FormatoHForzato) / 10
                            Dim DeltaCm As Integer = cm2Sviluppati - cm2Min

                            Dim PrezzoCm2Max As Decimal = pDopo.Prezzo / cm2Max

                            Dim DiffPrezzo As Single = pDopo.Prezzo - pPrima.Prezzo
                            Dim DiffQta As Integer = cm2Max - cm2Min

                            Dim Incr As Double = DiffPrezzo / DiffQta

                            PrezzoCalcolato = (DeltaCm * Incr) + pPrima.Prezzo

                            P = pDopo.ClonaPrezzo
                            P.Prezzo = PrezzoCalcolato
                            P.PrezzoMin = PrezzoCalcolato
                            P.PrezzoOltre = PrezzoCalcolato
                            P.Prezzo2 = PrezzoCalcolato
                            P.PrezzoMin2 = PrezzoCalcolato
                            P.PrezzoOltre2 = PrezzoCalcolato
                            'L.PrezziLavorazioniInvalidati = True

                            'MgrPreventivazioneB.CalcolaPrezzoLavorazione()
                        End If

                        'se qui non ho ancora un prezzo cerco sul generico di dimensioni medie 
                        If P Is Nothing Then
                            Dim DimensiToFind As enTipoGrandezzaPrezzoLavorazione = enTipoGrandezzaPrezzoLavorazione.Medio

                            P = L.Prezzi.Find(Function(x) x.IdFormProd = 0 And x.TipoGrandezza = DimensiToFind)

                        End If

                    End If
                    'qui calcolo l'area 
                    'Dim AreaForzata As Integer = FormatoWForzato * FormatoHForzato

                    'If P Is Nothing Then 'alla fine se non ho trovato un formato generico specifico cerco il generico standard
                    '    P = L.Prezzi.Find(Function(x) x.IdFormProd = 0 And x.TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Medio) 'qui devo prendere il generico medio
                    'End If

                    If Not P Is Nothing Then
                        QtaRiferimento = P.QtaRif
                        PrezzoToUse = P.Prezzo
                        PrezzoToUse2 = P.Prezzo2
                        If UsaSecondoMacchinario Then
                            CostoSingolaUnita = P.Prezzo2
                        Else
                            CostoSingolaUnita = P.Prezzo
                        End If
                    Else
                        'qui nn ha trovato il prezzo tecnicamente
                        CostoSingolaUnita = -1
                    End If
                End If
            Else
                QtaRiferimento = P.QtaRif
                PrezzoToUse = P.Prezzo
                PrezzoToUse2 = P.Prezzo2
                If UsaSecondoMacchinario Then
                    CostoSingolaUnita = P.Prezzo2
                Else
                    CostoSingolaUnita = P.Prezzo
                End If
            End If

            If CostoSingolaUnita > 0 Then

                If L.IdLavoro = FormerLib.FormerConst.Lavorazioni.Taglio Or L.IdLavoro = FormerLib.FormerConst.Lavorazioni.TaglioAMisuraOffset Then

                    'qui devo rivedere la quantità se il prezzo cad è presente
                    'qui manometto la quantita moltiplicandola per 4 e calcolando mazzetti da 6 cm

                    'If Qta = 5000 Then Stop

                    If Lb.ConSoggettiDuplicati = enSiNo.Si AndAlso L.SePresenteCalcolaSuSoggetti = enSiNo.Si Then
                        'QUI DEVO VEDERE SE CALCOLARE IL TAGLIO 
                        'PER ORA LO LASCIO COSI VUOTO QUINDI PRENDERA LA QUANTITA SECONDARIA


                    Else
                        If Tc.Spessore Then

                            Dim QtaDaCalc As Integer = Qta * NumFogli
                            Dim NumeroTagliDaFare As Integer = 4

                            If L.IdLavoro = FormerLib.FormerConst.Lavorazioni.TaglioAMisuraOffset Then
                                NumeroTagliDaFare = 2
                            End If


                            Dim CmTotaliDelLavoro As Single = MgrCalcoliTecnici.CalcolaSpessoreCarta(QtaDaCalc, Tc.Spessore)
                            Dim NumeroMazzetti As Integer = Math.Ceiling(CmTotaliDelLavoro / FormerConst.ProdottiCaratteristiche.CmTaglioMazzetta)

                            Dim QtaDaPrendereInConsiderazionePerIlTaglio As Integer = NumeroMazzetti 'Math.Ceiling(CmTotaliDelLavoro / NumeroMazzetti)

                            'QtaDaPrendereInConsiderazionePerIlTaglio = Math.Ceiling(Qta / QtaDaPrendereInConsiderazionePerIlTaglio)

                            QtaDaPrendereInConsiderazionePerIlTaglio *= NumeroTagliDaFare

                            Qta = QtaDaPrendereInConsiderazionePerIlTaglio

                        End If
                    End If

                End If

                If L.IdTipoLav = enTipoLavorazione.UnaTantum Then
                    Ris += CostoSingolaUnita
                Else
                    'qui tanto calcolo il prezzo intermedio per la qta se inferiore a quella di riferimento
                    'Dim QtaRiferimento As Integer = 0
                    Dim TotaleIntermedio As Single = 0

                    If L.IdTipoLav <> enTipoLavorazione.suMetriLineari And
                       L.IdTipoLav <> enTipoLavorazione.suCmQuadri Then
                        If Qta < P.QtaRif Then
                            'qui minore la calcolo
                            CostoSingolaUnita = CalcolaCostoCadIntermedio(P, Qta, UsaSecondoMacchinario)
                        ElseIf Qta = P.QtaRif Then
                            'qui uguale prendo la rif
                            If UsaSecondoMacchinario Then
                                CostoSingolaUnita = P.Prezzo2
                            Else
                                CostoSingolaUnita = P.Prezzo
                            End If
                        Else
                            'qui è maggiore ma devo prima fare il calcolo di quella rif e sommare
                            'CostoSingolaUnita = P.PrezzoOltre
                            If UsaSecondoMacchinario Then
                                CostoSingolaUnita = P.PrezzoOltre2
                                Qta = Qta - P.QtaRif

                                Select Case L.IdTipoLav
                                    Case enTipoLavorazione.suFoglio
                                        If L.IdLavoro = FormerLib.FormerConst.Lavorazioni.Taglio Then
                                            TotaleIntermedio = P.Prezzo2 * (P.QtaRif) ' * NumFogli'Ris = Qta * CostoSingolaUnita
                                        Else
                                            TotaleIntermedio = P.Prezzo2 * (P.QtaRif) * NumFogli
                                        End If

                                    Case enTipoLavorazione.suFacciata
                                        TotaleIntermedio = P.Prezzo2 * (P.QtaRif) * NumFacciate
                                    Case enTipoLavorazione.suQuantita
                                        TotaleIntermedio = P.Prezzo2 * (P.QtaRif)
                                    Case enTipoLavorazione.suMetriQuadri
                                        TotaleIntermedio = P.Prezzo2 * (P.QtaRif)
                                End Select
                            Else
                                CostoSingolaUnita = P.PrezzoOltre
                                Qta = Qta - P.QtaRif

                                Select Case L.IdTipoLav
                                    Case enTipoLavorazione.suFoglio
                                        If L.IdLavoro = FormerLib.FormerConst.Lavorazioni.Taglio Then
                                            TotaleIntermedio = P.Prezzo * (P.QtaRif) '* NumFogli 'Ris = Qta * CostoSingolaUnita
                                        Else
                                            TotaleIntermedio = P.Prezzo * (P.QtaRif) * NumFogli
                                        End If

                                    Case enTipoLavorazione.suFacciata
                                        TotaleIntermedio = P.Prezzo * (P.QtaRif) * NumFacciate
                                    Case enTipoLavorazione.suQuantita
                                        TotaleIntermedio = P.Prezzo * (P.QtaRif)
                                    Case enTipoLavorazione.suMetriQuadri
                                        TotaleIntermedio = P.Prezzo * (P.QtaRif)
                                End Select
                            End If
                        End If
                    End If

                    If L.IdTipoLav = enTipoLavorazione.suCmQuadri Then
                        Dim BaseF As Integer = 0
                        Dim AltezzaF As Integer = 0
                        Dim Margine As Integer = 0

                        If Not Rp Is Nothing Then
                            'qui la lavorazione e' su centimetri quadri e il risultato del plugin mi da modo di capire 
                            'su cosa applicare la lavorazione se particolare
                            If L.ListExtraData.Count Then

                                Dim EDCalcola As ExtraData = L.ListExtraData.Find(Function(x) x.Chiave = MgrExtraData.GetExtraDataKey(MgrExtraData.enExtraData.CalcolaSoloSuFacciata))

                                If Not EDCalcola Is Nothing AndAlso
                                       EDCalcola.Valore = enSiNo.Si Then
                                    'qui devo ricalcolare l'aria della facciata 
                                    BaseF = Rp.Base
                                    AltezzaF = Rp.Altezza

                                End If
                            End If
                        End If

                        If BaseF = 0 OrElse AltezzaF = 0 Then
                            'qui la devo calcolare su tutta l'area del formato prodotto
                            BaseF = FormatoWForzato
                            AltezzaF = FormatoHForzato
                        End If

                        If L.ListExtraData.Count Then
                            Dim EDMargine As ExtraData = L.ListExtraData.Find(Function(x) x.Chiave = MgrExtraData.GetExtraDataKey(MgrExtraData.enExtraData.MargineBordomm))

                            If Not EDMargine Is Nothing Then
                                Margine = EDMargine.Valore
                            End If
                        End If

                        BaseF = Math.Ceiling((BaseF - (Margine * 2)) / 10)
                        AltezzaF = Math.Ceiling((AltezzaF - (Margine * 2)) / 10)
                        Dim NuovaAreaCmQuadri As Integer = BaseF * AltezzaF '((Rp.Base - (Margine * 2)) / 10) * ((Rp.Altezza - (Margine * 2)) - 10)
                        '                                    NuovaAreaCmQuadri = Math.Ceiling(NuovaAreaCmQuadri / 10)
                        Qta = NuovaAreaCmQuadri * Qta
                    End If

                    Select Case L.IdTipoLav
                        Case enTipoLavorazione.suFoglio
                            If L.IdLavoro = FormerLib.FormerConst.Lavorazioni.Taglio Then
                                Ris = Qta * CostoSingolaUnita
                            Else
                                Ris = Qta * CostoSingolaUnita * NumFogli
                            End If

                        Case enTipoLavorazione.suFacciata
                            Ris = Qta * CostoSingolaUnita * NumFacciate
                        Case enTipoLavorazione.suQuantita
                            Ris = Qta * CostoSingolaUnita
                        Case enTipoLavorazione.suMetriQuadri
                            Ris = Qta * CostoSingolaUnita
                        Case enTipoLavorazione.suCmQuadri
                            Ris = Qta * CostoSingolaUnita
                        Case enTipoLavorazione.suMetriLineari
                            Dim cmLin As Integer = MgrCalcoliTecnici.CalcolaCmLineari(AltezzaMm, LarghezzaMm)
                            Dim mLin As Single = 0

                            Try
                                mLin = cmLin / 100
                            Catch ex As Exception

                            End Try

                            If mLin Then
                                TotaleIntermedio = Qta * (P.Prezzo * mLin)
                            End If

                    End Select

                    Ris += TotaleIntermedio
                End If
            ElseIf CostoSingolaUnita = -1 Then
                Ris = -1
            End If

            If Ris > 0 Then

                If UsaSecondoMacchinario Then
                    Ris += L.MacchinarioRif2.CostoMinAvv
                Else
                    Ris += L.MacchinarioRif.CostoMinAvv
                End If
            End If

            'If Ris < M.CostoMinAvv Then
            '    Ris = M.CostoMinAvv
            'End If

        End If

        Return Ris
    End Function
    'Public Shared Function CalcolaPrezzoLavorazione(R As RichiestaCalcoloPrezzo,
    '                                                L As ILavorazioneB,
    '                                                Lb As IListinoBaseB,
    '                                                Tc As ITipoCartaB,
    '                                                Optional AltezzaMm As Integer = 0,
    '                                                Optional LarghezzaMm As Integer = 0,
    '                                                Optional CalcolaPrezzoLavorazioniNonPreviste As Boolean = False,
    '                                                Optional FormatoWForzato As Integer = 0,
    '                                                Optional FormatoHForzato As Integer = 0,
    '                                                Optional IdFormProdForzato As Integer = 0,
    '                                                Optional IdFormCartaForzato As Integer = 0,
    '                                                Optional Rp As IRisultatoPlugin = Nothing) As RisCalcoloPrezzoLavorazione

    Public Shared Function CalcolaPrezzoLavorazione(Qta As Integer,
                                                        L As ILavorazioneB,
                                                        Lb As IListinoBaseB,
                                                        Tc As ITipoCartaB,
                                                        Optional AltezzaMm As Integer = 0,
                                                        Optional LarghezzaMm As Integer = 0,
                                                        Optional CalcolaPrezzoLavorazioniNonPreviste As Boolean = False,
                                                        Optional FormatoWForzato As Integer = 0,
                                                        Optional FormatoHForzato As Integer = 0,
                                                        Optional IdFormProdForzato As Integer = 0,
                                                        Optional IdFormCartaForzato As Integer = 0,
                                                        Optional Rp As IRisultatoPlugin = Nothing) As RisCalcoloPrezzoLavorazione

        'QUI NON PRENDO MAI IN CONSIDERAZIONE LE LAVORAZIONI SU CENTIMETRO QUADRO PERCHE NON VENGONO CALCOLATE IN QUESTA FASE
        'MA SOLO SUL PREZZO INTERMEDIO IN QUANTO SI APPLICA SOLO SULLA QUANTITA REALMENTE LAVORATA 
        Dim Ris As New RisCalcoloPrezzoLavorazione

        Dim PCalc As Decimal = 0
        Ris.IdMacchinario = L.IdMacchinario

        Ris.PrezzoTotale = CalcolaPrezzoLavorazioneEx(Qta,
                                         L,
                                         Lb,
                                         Tc,
                                         AltezzaMm,
                                         LarghezzaMm,
                                         CalcolaPrezzoLavorazioniNonPreviste,
                                         FormatoWForzato,
                                         FormatoHForzato,
                                         IdFormProdForzato,
                                         IdFormCartaForzato,
                                         Rp)


        If L.IdMacchinario2 Then
            'calcolo il prezzo con il secondo macchinario
            PCalc = CalcolaPrezzoLavorazioneEx(Qta,
                                                 L,
                                                 Lb,
                                                 Tc,
                                                 AltezzaMm,
                                                 LarghezzaMm,
                                                 CalcolaPrezzoLavorazioniNonPreviste,
                                                 FormatoWForzato,
                                                 FormatoHForzato,
                                                 IdFormProdForzato,
                                                 IdFormCartaForzato,
                                                 Rp,
                                                 True)
            If PCalc > 0 AndAlso PCalc < Ris.PrezzoTotale Then
                Ris.IdMacchinario = L.IdMacchinario2
                Ris.PrezzoTotale = PCalc
            End If
        End If

        If Ris.PrezzoTotale = -1 Then
            Ris.AnomaliaPrezzoCalcolato = True
            Ris.PrezzoTotale = 0
        End If

        Return Ris

    End Function

    Private Shared Function CalcolaPrezzoCarta(Qta As Single,
                                        R As ResaFPsuFM,
                                        Fm As IFormatoB,
                                        Tc As ITipoCartaB,
                                        L As IListinoBaseB) As Decimal

        Dim Ris As Decimal = 0

        Dim MoltiplF As Integer = L.NumFacciate / 2

        If L.TipoPrezzo = enTipoPrezzo.SuQuantita Then
            If L.IdTipoCartaDorso = 0 Then
                If L.IdTipoCartaCop Then MoltiplF -= 2
            End If
        End If

        Dim QtaRif As Integer = Qta * MoltiplF

        Dim ResaDiv As Integer = R.Resa

        If L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            ResaDiv = 1
        End If

        Dim Pz As Single = QtaRif / ResaDiv
        Dim Kg As Single = 0
        Pz += ((Pz * R.PercScarto) / 100)

        If L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then

            'in questo caso della quantita immessa calcolo la radice quadrata per avere un peso reale corretto

            Dim LatoCm As Single = Math.Sqrt(Pz)

            Kg = CalcolaKgCarta(LatoCm, LatoCm, Tc.Grammi, 1)
            Ris = Kg * Tc.CostoCartaKg
            If Ris < 1 Then Ris = 1
        Else
            'QUI VA FATTA UNA SPECIFICA PER I METRI QUADRI
            If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                Kg = CalcolaKgCarta(100, 100, Tc.Grammi, Pz)
                Ris = Kg * Tc.CostoCartaKg
            ElseIf L.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                'Kg = CalcolaKgCarta(100, 100, Tc.Grammi, Pz)
                Ris = Pz * Tc.CostoRiferimento
            Else
                If Tc.TipoCarta = enTipoCarta.Semplice Then
                    Kg = CalcolaKgCarta(Fm.Altezza, Fm.Larghezza, Tc.Grammi, Pz)
                    Ris = Kg * Tc.CostoCartaKg
                Else
                    For Each tcComp As IComposizioneCartaB In Tc.ComposizioniCarta
                        Dim PzComp As Single = Pz * tcComp.NumFogli
                        Kg = CalcolaKgCarta(Fm.Altezza, Fm.Larghezza, tcComp.CartaSingola.Grammi, PzComp)
                        Ris += Kg * tcComp.CartaSingola.CostoCartaKg
                    Next

                End If
            End If
        End If

        'CALCOLO COSTO CARTA COPERTINA
        If L.IdTipoCartaCop Then
            Dim MoltiplFCop As Integer = 1

            If L.TipoPrezzo = enTipoPrezzo.SuQuantita Then
                If L.IdTipoCartaDorso = 0 Then MoltiplFCop = 2
            End If

            Dim QtaRifCop As Integer = Qta * MoltiplFCop

            Dim PzCop As Single = QtaRifCop / R.Resa
            PzCop += ((PzCop * R.PercScarto) / 100)

            Dim tcCop As ITipoCartaB = L.TipoCartaCop

            Dim KgCop As Single = CalcolaKgCarta(Fm.Altezza, Fm.Larghezza, tcCop.Grammi, PzCop) '((Fm.Altezza * Fm.Larghezza * Tc.Grammi) / 10000000) * Pz

            Ris += KgCop * tcCop.CostoCartaKg
        End If

        'CALCOLO COSTO CARTA SOTTO
        If L.IdTipoCartaDorso Then

            Dim QtaRifSotto As Integer = Qta

            Dim PzSotto As Single = QtaRifSotto / R.Resa
            PzSotto += ((PzSotto * R.PercScarto) / 100)

            Dim tcSotto As ITipoCartaB = L.TipoCartaDorso

            Dim KgSotto As Single = CalcolaKgCarta(Fm.Altezza, Fm.Larghezza, tcSotto.Grammi, PzSotto) '((Fm.Altezza * Fm.Larghezza * Tc.Grammi) / 10000000) * Pz

            Ris += KgSotto * tcSotto.CostoCartaKg
        End If

        Return Ris

    End Function

    Private Shared Function CalcolaPrezzoImpianti(ByVal R As ResaFPsuFM,
                                           Fm As IFormatoB,
                                           Cs As IColoreStampaB,
                                           L As IListinoBaseB) As Decimal
        Dim Ris As Decimal = 0

        'MODIFICA FATTA PER FAR CALCOLARE GLI IMPIANTI 
        'If L.MacchinarioProduzione.IdRepartoDefault = enRepartoWeb.StampaOffset Then

        Dim ResaInt As Integer = R.Resa
        If L.noResa Then
            ResaInt = 1
        End If

        Dim MoltiplF As Integer = L.NumFacciate / 2

        If L.IdTipoCartaDorso = 0 Then
            If L.IdTipoCartaCop Then MoltiplF -= 2
        End If

        If L.NoFaccSuImpianti Then MoltiplF = 1

        Ris = Fm.CostoLastra * ((Cs.NLastre * MoltiplF) / ResaInt)

        'IMPIANTI COPERTINA
        If L.IdTipoCartaCop Then
            Dim MoltiplFCop As Integer = 1
            If L.IdTipoCartaDorso = 0 Then MoltiplFCop = 2

            Ris += Fm.CostoLastra * ((Cs.NLastre * MoltiplFCop) / ResaInt)
        End If

        'End If

        Return Ris

    End Function

    Private Shared Function CalcolaPrezzoStampa(Qta As Integer,
                                                 Fm As IFormatoB,
                                                 ByVal R As ResaFPsuFM,
                                                 Cs As IColoreStampaB,
                                                 L As IListinoBaseB,
                                                 Optional UsaMacchinarioProduzioneAlternativo As Boolean = False) As RisCalcoloPrezzoStampa

        'STAMPA INTERNO
        'Dim Ris As New RisCalcoloPrezzoStampa
        'Dim ListaPrezzi As New List(Of RisCalcoloPrezzoStampa)

        Dim MoltiplF As Integer = L.NumFacciate / 2

        If L.IdTipoCartaDorso = 0 Then
            If L.IdTipoCartaCop Then MoltiplF -= 2
        End If

        Dim QtaRif As Integer = Qta * MoltiplF
        Dim ResaInt As Integer = R.Resa
        If L.noResa Then
            ResaInt = 1
        End If

        Dim Pz As Single = QtaRif / ResaInt

        Pz += ((Pz * R.PercScarto) / 100)

        'calcolo il costo della stampa singola prendendolo dal macchinario associato a quel formato macchina
        Dim M As IMacchinarioB = Nothing
        Dim AvviamentoStampa As Integer = 0
        Dim MinimaleStampa As Integer = 0

        If UsaMacchinarioProduzioneAlternativo = False Then
            M = L.MacchinarioProduzione
            AvviamentoStampa = L.AvviamStampa
            MinimaleStampa = L.MinimaleStampa
        Else
            M = L.MacchinarioProduzione2
            AvviamentoStampa = L.AvviamStampa2
            MinimaleStampa = L.MacchinarioProduzione2.CostoMinAvv
        End If

        Dim RisSingolo As New RisCalcoloPrezzoStampa
        RisSingolo.IdMacchinario = M.IdMacchinario

        Dim CostoSingCopia As Decimal = M.CostoSingCopia

        If L.PercAdatCostoCopia Then
            CostoSingCopia += (CostoSingCopia * L.PercAdatCostoCopia) / 100
        End If

        RisSingolo.PrezzoNetto = Pz * CostoSingCopia

        If Cs.FR = True Then RisSingolo.PrezzoNetto *= 2

        '*** 06/02/2023 ** QUI DEVO VEDERE SE SI TRATTA DI CARTA COMPOSTA
        If L.TipoCarta.TipoCarta = enTipoCarta.Composta Then

            Dim ImportoSingolaStampa As Decimal = RisSingolo.PrezzoNetto
            Dim TotaleStampeComposte As Decimal = 0

            For Each c In L.TipoCarta.ComposizioniCarta
                TotaleStampeComposte += (ImportoSingolaStampa * c.NumFogli)
            Next

            If TotaleStampeComposte Then
                RisSingolo.PrezzoNetto = TotaleStampeComposte
            End If

        End If

        'If Ris < M.CostoMinAvv Then
        RisSingolo.PrezzoNetto += M.CostoMinAvv
        'End If

        'STAMPA COPERTINA
        If L.IdTipoCartaCop Then
            Dim MoltiplFCop As Integer = 1
            If L.IdTipoCartaDorso = 0 Then MoltiplFCop = 2
            Dim QtaRifCop As Integer = Qta * MoltiplFCop

            Dim PzCop As Single = QtaRifCop / ResaInt

            PzCop += ((PzCop * R.PercScarto) / 100)

            'calcolo il costo della stampa singola prendendolo dal macchinario associato a quel formato macchina
            'Dim MCop As IMacchinarioB = L.MacchinarioProduzione
            Dim costoIntermedio As Decimal = PzCop * CostoSingCopia
            If Cs.FR = True Then costoIntermedio = costoIntermedio * 2
            RisSingolo.PrezzoNetto += costoIntermedio

        End If

        RisSingolo.PrezzoNetto += AvviamentoStampa
        If RisSingolo.PrezzoNetto < MinimaleStampa Then
            RisSingolo.PrezzoNetto = MinimaleStampa
        End If

        'Dim M As IMacchinarioB = L.MacchinarioProduzione

        Return RisSingolo

    End Function

    Public Shared Function CalcolaCostoCadIntermedio(P As IPrezzoLavoroB,
                                                      Qta As Integer,
                                                      Optional UsaSecondoMacchinario As Boolean = False) As Decimal

        Dim ris As Decimal = 0
        If UsaSecondoMacchinario = False Then
            If P.PrezzoMin = 0 Or P.PrezzoMin = P.Prezzo Then
                ris = P.Prezzo
            Else

                Dim diffCad As Single = P.PrezzoMin - P.Prezzo
                Dim diffSingola As Double = diffCad / (P.QtaRif - 1)

                Dim risInt As Decimal = diffSingola * (P.QtaRif - Qta)

                ris = risInt + P.Prezzo

            End If

        Else
            If P.PrezzoMin2 = 0 Or P.PrezzoMin2 = P.Prezzo2 Then
                ris = P.Prezzo2
            Else

                Dim diffCad As Single = P.PrezzoMin2 - P.Prezzo2
                Dim diffSingola As Double = diffCad / (P.QtaRif - 1)

                Dim risInt As Decimal = diffSingola * (P.QtaRif - Qta)

                ris = risInt + P.Prezzo2

            End If

        End If

        Return ris

    End Function

    Public Shared Function CalcolaPercScarto(PrezzoMercato As Decimal,
                                             PrezzoCalcolato As Decimal) As Single

        Dim ris As Single = 1
        If PrezzoMercato <> 0 And PrezzoCalcolato <> 0 Then
            ris = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((((PrezzoMercato * 100) / PrezzoCalcolato) - 100), 2)
        End If

        Return ris

    End Function

    Public Shared Function CalcolaColli(Qta As Single, L As IListinoBaseB) As Integer

        Dim Ris As Single = 0

        Dim QtaDiv As Integer = 1
        If L.qtaCollo Then QtaDiv = L.qtaCollo
        Ris = Math.Ceiling(Qta / QtaDiv)

        Return Ris

    End Function

    'Private Shared Function CalcolaPrezzoCurva(Prezzo As Decimal,
    '                                           PercCurva As Single) As Decimal

    '    Dim Ris As Decimal = Prezzo * PercCurva
    '    Return Ris

    'End Function

    Public Shared Function CalcolaPrezzoAlKgCarta(Altezza As Single,
                                      Larghezza As Single,
                                      Grammi As Single,
                                      Pz As Single,
                                      PrezzoPerPz As Decimal) As Decimal

        Dim ris As Decimal = 0

        Dim Kg As Single = MgrPreventivazioneB.CalcolaKgCarta(Altezza, Larghezza, Grammi, Pz)

        If Kg Then ris = PrezzoPerPz / Kg

        Return ris

    End Function

    Public Shared Function CalcolaPesoLavoro(Altezza As Single,
                                              Larghezza As Single,
                                              Qta As Single,
                                              NumeroColli As Integer,
                                              L As IListinoBaseB,
                                              Optional TieniContoResa As Boolean = True) As Single
        Dim ris As Single = 0

        Dim PesoReale As Single = CalcolaKgCarta(Qta, L, TieniContoResa)

        Dim ProfonditaTotale As Single = (L.TipoCarta.Spessore * NumeroColli) / 10000
        Dim SpessoreSingoloLatoImballo As Integer = 1

        Altezza += SpessoreSingoloLatoImballo + SpessoreSingoloLatoImballo
        Larghezza += SpessoreSingoloLatoImballo + SpessoreSingoloLatoImballo
        ProfonditaTotale += SpessoreSingoloLatoImballo + SpessoreSingoloLatoImballo

        ProfonditaTotale = Math.Ceiling(ProfonditaTotale)

        Dim PesoVolumetrico As Single = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, ProfonditaTotale)

        If PesoVolumetrico > PesoReale Then
            ris = PesoVolumetrico
        Else
            ris = PesoReale
        End If
        ris = Math.Ceiling(ris)
        Return ris
    End Function

    Public Shared Function CalcolaKgCarta(AltezzaCm As Single,
                                      LarghezzaCm As Single,
                                      Grammi As Single,
                                      Pz As Single) As Single
        Return ((AltezzaCm * LarghezzaCm * Grammi) / 10000000) * Pz

    End Function

End Class