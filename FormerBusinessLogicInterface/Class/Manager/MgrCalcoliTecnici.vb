Imports System.Drawing
Imports FormerLib.FormerEnum

Public Class MgrCalcoliTecnici

    Public Shared Function CalcolaCmQuadri(AltezzaCm As Integer,
                                            LarghezzaCm As Integer) As Integer
        Dim ris As Integer = 0

        ris = AltezzaCm * LarghezzaCm

        Return ris
    End Function

    Public Shared Function GetUnitaMisuraInput(L As IListinoBaseB) As enUnitaDiMisura

        Dim ris As enUnitaDiMisura = enUnitaDiMisura.Pezzi

        If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            ris = enUnitaDiMisura.cm
        ElseIf L.TipoPrezzo = enTipoPrezzo.SuFoglio OrElse
                L.Preventivazione.IdPluginToUse Then
            ris = enUnitaDiMisura.mm
        End If

        'TOPPA MESSA TEMPORANEAMENTE 
        If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri AndAlso
                L.FormatoProdotto.IsRotolo = enSiNo.Si AndAlso
                L.FormatoProdotto.Larghezza <> 0 Then
            'qui uso cmq i mm per il momento
            'fa un po schifo come soluzione ma per il momento questa è
            ris = enUnitaDiMisura.mm
        End If

        Return ris

    End Function

    Public Shared Function DaCmQuadriAMetriQuadri(cm2 As Integer) As Single
        Dim ris As Single = 0
        ris = Math.Round(cm2 / 10000, 2)
        Return ris
    End Function

    Public Shared Function ValidaDimensioneInBaseAFormatoProdotto(DimensioneToValCm As Single,
                                                                  AltraDimensioneCm As Single,
                                                                  IFP As IFormatoProdottoB) As Single


        Dim H As Single = (IFP.Lunghezza / 10) - 1
        Dim W As Single = (IFP.Larghezza / 10) - 1

        Dim Max As Single = 0
        Dim Min As Single = 0

        If H > W Then
            Max = H
            Min = W
        Else
            Max = W
            Min = H
        End If

        If AltraDimensioneCm > Min Then
            If DimensioneToValCm > Min Then
                DimensioneToValCm = Min
            End If
        Else
            If DimensioneToValCm > Max Then
                DimensioneToValCm = Max
            End If
        End If

        Return DimensioneToValCm

    End Function

    Public Shared Function QuanteVolteFormatoInFormato(FormatoContenuto As Size,
                                                       FormatoContenitore As Size,
                                                       Optional Scarto As Single = 0) As RisQuanteVolteFormatoInFormato
        Dim ris As New RisQuanteVolteFormatoInFormato

        Dim TotSoluzione1 As Integer = 0

        Dim TotRigheO1 As Integer = Math.Floor(FormatoContenitore.Height / (FormatoContenuto.Height + Scarto))

        Dim TotColonneV1 As Integer = 0

        If TotRigheO1 Then
            'qui ce ne entra almeno uno vedo quanti ce ne entrano in verticale 
            TotColonneV1 = Math.Floor(FormatoContenitore.Width / (FormatoContenuto.Width + Scarto))
            If TotColonneV1 Then
                TotSoluzione1 = TotColonneV1 * TotRigheO1
            End If
        End If

        Dim TotSoluzione2 As Integer = 0

        Dim TotRigheO2 As Integer = Math.Floor(FormatoContenitore.Width / (FormatoContenuto.Height + Scarto))

        Dim TotColonneV2 As Integer = 0
        If TotRigheO2 Then
            'qui ce ne entra almeno uno vedo quanti ce ne entrano in verticale 
            TotColonneV2 = Math.Floor(FormatoContenitore.Height / (FormatoContenuto.Width + Scarto))

            If TotColonneV2 Then
                TotSoluzione2 = TotColonneV2 * TotRigheO2
            End If
        End If

        If TotSoluzione1 Then
            If TotSoluzione1 >= TotSoluzione2 Then
                ris.QuantiEntrano = TotSoluzione1
                ris.Righe = TotRigheO1
                ris.Colonne = TotColonneV1
            Else
                ris.QuantiEntrano = TotSoluzione2
                ris.Righe = TotRigheO2
                ris.Colonne = TotColonneV2
            End If
        ElseIf TotSoluzione2 Then
            ris.QuantiEntrano = TotSoluzione2
            ris.Righe = TotRigheO2
            ris.Colonne = TotColonneV2
        End If

        Return ris
    End Function

    Public Shared Function CalcolaSpessoreCarta(Qta As Integer,
                                         Spessore As Single) As Single

        Dim ris As Single = 1

        If Spessore Then
            'formula = MICRON * QTA / 1000
            ris = Spessore * Qta / 10000
        End If

        Return ris

    End Function

    Public Shared Function CalcolaDiametroBobinaCm(LunghezzaTotaleCm As Integer,
                                             DiametroAnimaInternaCm As Integer,
                                             SpessoreCartaMicron As Single) As Integer

        Dim ris As Integer = 0

        Dim CircLavorataMM As Single = 0
        CircLavorataMM = (DiametroAnimaInternaCm * 10) * 3.14

        Dim SpessoreCartaMM As Single = SpessoreCartaMicron / 1000

        Dim LunghezzaLavorata As Single = 0
        Dim NuovoDiametroMM As Single = DiametroAnimaInternaCm * 10
        While (LunghezzaLavorata / 10) < LunghezzaTotaleCm

            LunghezzaLavorata += CircLavorataMM

            NuovoDiametroMM += (SpessoreCartaMM * 2)

            CircLavorataMM = NuovoDiametroMM * 3.14

        End While

        'arrivato qui il nuovodiametro in mm mi esprime il diametro per cui avere il diametro della bobina 

        ris = NuovoDiametroMM / 10

        Return ris

    End Function

    Public Shared Function CalcolaLunghezzaTotaleCm(AltezzaMM As Integer,
                                                    LarghezzaMM As Integer,
                                     Orientamento As enTipoOrientamento,
                                     LatoFissoMM As Single,
                                     QtaRichiesta As Integer) As Single

        'Dim ris As Single = 0

        Dim LatoRiferimento As Single = 0
        Dim LatoCorto As Single = 0
        If AltezzaMM = LarghezzaMM Then
            'qui sono uguali altezza e larghezza
            LatoRiferimento = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato + AltezzaMM + FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato
            LatoCorto = AltezzaMM + FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineSopra
        Else
            If Orientamento = enTipoOrientamento.Orizzontale Then
                If AltezzaMM > LarghezzaMM Then
                    LatoRiferimento = AltezzaMM
                    LatoCorto = LarghezzaMM
                Else
                    LatoRiferimento = LarghezzaMM
                    LatoCorto = AltezzaMM
                End If
            ElseIf Orientamento = enTipoOrientamento.Verticale Then
                If AltezzaMM > LarghezzaMM Then
                    LatoRiferimento = LarghezzaMM
                    LatoCorto = AltezzaMM
                Else
                    LatoRiferimento = AltezzaMM
                    LatoCorto = LarghezzaMM
                End If
            End If
            LatoRiferimento = FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato + LatoRiferimento + FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineALato
            LatoCorto = LatoCorto + FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.MargineSopra
        End If

        'ora devo vedere quanti ce ne entrano sul latofisso
        Dim QtaPerRiga As Integer = Math.Floor(LatoFissoMM / LatoRiferimento)

        'ora che so le righe calcolo quanto e' la lunghezza 
        Dim AltezzaTotale As Single = LatoCorto * (Math.Ceiling(QtaRichiesta / QtaPerRiga))

        Return (AltezzaTotale / 10)

    End Function

    Public Shared Function CalcolaCmQuadri(AltezzaMM As Integer,
                                     LarghezzaMM As Integer,
                                     Orientamento As enTipoOrientamento,
                                     LatoFissoMM As Single,
                                     QtaRichiesta As Integer) As Single
        Dim ris As Single = 0

        'Dim LatoRiferimento As Single = 0
        'Dim LatoCorto As Single = 0
        'If AltezzaMM = LarghezzaMM Then
        '    'qui sono uguali altezza e larghezza
        '    LatoRiferimento = FormerLib.FormerConst.EtichetteCmQuadri.MargineALato + AltezzaMM + FormerLib.FormerConst.EtichetteCmQuadri.MargineALato
        '    LatoCorto = AltezzaMM + FormerLib.FormerConst.EtichetteCmQuadri.MargineSopra
        'Else
        '    If Orientamento = enTipoOrientamento.Orizzontale Then
        '        If AltezzaMM > LarghezzaMM Then
        '            LatoRiferimento = AltezzaMM
        '            LatoCorto = LarghezzaMM
        '        Else
        '            LatoRiferimento = LarghezzaMM
        '            LatoCorto = AltezzaMM
        '        End If
        '    ElseIf Orientamento = enTipoOrientamento.Verticale Then
        '        If AltezzaMM > LarghezzaMM Then
        '            LatoRiferimento = LarghezzaMM
        '            LatoCorto = AltezzaMM
        '        Else
        '            LatoRiferimento = AltezzaMM
        '            LatoCorto = LarghezzaMM
        '        End If
        '    End If
        '    LatoRiferimento = FormerLib.FormerConst.EtichetteCmQuadri.MargineALato + LatoRiferimento + FormerLib.FormerConst.EtichetteCmQuadri.MargineALato
        '    LatoCorto = LatoCorto + FormerLib.FormerConst.EtichetteCmQuadri.MargineSopra
        'End If

        ''ora devo vedere quanti ce ne entrano sul latofisso
        'Dim QtaPerRiga As Integer = Math.Floor(LatoFisso / LatoRiferimento)

        ''ora che so le righe calcolo quanto e' la lunghezza 
        'Dim AltezzaTotale As Single = LatoCorto * (Math.Ceiling(QtaRichiesta / QtaPerRiga))

        Dim AltezzaTotaleCm As Integer = CalcolaLunghezzaTotaleCm(AltezzaMM,
                                                                  LarghezzaMM,
                                                                  Orientamento,
                                                                  LatoFissoMM,
                                                                  QtaRichiesta)

        LatoFissoMM /= 10


        ris = CalcolaCmQuadri(AltezzaTotaleCm, LatoFissoMM)

        Return ris
    End Function

    Public Shared Function CalcolaCmLineari(Altezza As Integer,
                                            Larghezza As Integer) As Integer
        Dim ris As Integer = 0

        ris = (Altezza * 2) + (Larghezza * 2)

        Return ris
    End Function

    Public Shared Function CalcolaML(Cm As Integer) As Single
        Dim ris As Single = 0

        ris = Cm / 100

        Return ris
    End Function

    Public Shared Function CalcolaFogli(LarghezzaRiferimentoMm As Integer,
                                        AltezzaRiferimentoMm As Integer,
                                        Quantita As Integer,
                                        AltezzaValidataMm As Integer,
                                        LarghezzaValidataMm As Integer,
                                        Optional ScartoMM As Integer = 0) As Integer

        Dim Ris As Integer = 1

        Dim LatoRiferimento As Single = LarghezzaRiferimentoMm '+ ((LarghezzaRiferimento * 2) / 100)

        Dim Copie As Integer = Quantita

        Dim Altezza As Integer = AltezzaValidataMm
        Dim Larghezza As Integer = LarghezzaValidataMm
        Dim ScartoParam As Integer = ScartoMM '/ 10

        Dim AltezzaConScarto As Integer = Altezza + (ScartoMM) '/ 10)
        Dim LarghezzaConScarto As Integer = Larghezza + (ScartoMM) '/ 10)

        Dim Contenuto As New Size(Altezza, Larghezza)
        Dim Contenitore As New Size(AltezzaRiferimentoMm, LarghezzaRiferimentoMm)

        Dim QuantiEntranoFoglio As RisQuanteVolteFormatoInFormato = QuanteVolteFormatoInFormato(Contenuto, Contenitore, ScartoParam)

        Try
            Ris = Math.Ceiling(Copie / QuantiEntranoFoglio.QuantiEntrano)
        Catch ex As Exception

        End Try


        Return Ris

    End Function

    'Public Shared Function CalcolaMq(LarghezzaRiferimentoCm As Single,
    '                                 Quantita As Integer,
    '                                 AltezzaValidataCm As Single,
    '                                 LarghezzaValidataCm As Single,
    '                                 Optional LatoMinimoParam As Single = 0,
    '                                 Optional ScartoMM As Integer = 0,
    '                                 Optional AltezzaRiferimentoCm As Single = 0) As Single
    Public Shared Function CalcolaMq(LarghezzaRiferimentoCm As Single,
                                     Quantita As Integer,
                                     AltezzaValidataCm As Single,
                                     LarghezzaValidataCm As Single,
                                     Optional LatoMinimoParam As Single = 0,
                                     Optional ScartoMM As Integer = 0,
                                     Optional AltezzaRiferimentoCm As Single = 0) As RisSviluppoMq
        Dim RisEx As New RisSviluppoMq

        'Dim Ris As Single = 0

        Dim LatoRiferimento As Single = LarghezzaRiferimentoCm
        Dim LatoRiferimentoConfronto As Single = LatoRiferimento + 2 'aggiungo aribtrariamente 2cm ((LarghezzaRiferimento * 2) / 100)

        Dim LatoMinimo As Single = LatoMinimoParam ' 100
        'Dim Scarto As Integer = 0 '1
        Dim Copie As Integer = Quantita

        Dim Altezza As Single = AltezzaValidataCm
        Dim Larghezza As Single = LarghezzaValidataCm

        Dim AltezzaConScarto As Single = Altezza '+ (ScartoMM / 10)
        Dim LarghezzaConScarto As Single = Larghezza + (ScartoMM / 10)

        'Dim AreaSuAltezza As Single = 0
        'Dim AreaSuLarghezza As Single = 0
        'Dim QuantiFogli As Integer = 0

        Dim SoluzioneSuAltezza As New RisSviluppoMq
        Dim SoluzioneSuLarghezza As New RisSviluppoMq

        If AltezzaConScarto <= LatoRiferimentoConfronto AndAlso AltezzaConScarto <> 0 Then
            Dim QuantiSuRiga As Integer = Math.Floor(LatoRiferimentoConfronto / AltezzaConScarto)
            Dim QuanteRighe As Integer = Math.Ceiling(Copie / QuantiSuRiga)

            Dim AltezzaRif As Integer = QuanteRighe * LarghezzaConScarto
            If AltezzaRif < LatoMinimo Then
                AltezzaRif = LatoMinimo
            End If

            If AltezzaRiferimentoCm Then
                If AltezzaRiferimentoCm >= AltezzaRif Then
                    'qui vedo a fogli fissi quanti ne servono
                    Dim QuantiFogli As Single = AltezzaRif / AltezzaRiferimentoCm
                    QuantiFogli = Math.Ceiling(QuantiFogli)
                    AltezzaRif = QuantiFogli * AltezzaRiferimentoCm
                    SoluzioneSuAltezza.AreaCalcolata = LatoRiferimento * AltezzaRif
                End If
            Else
                'ora calcolo i centimetri quadrati del pezzo che uso 
                SoluzioneSuAltezza.AreaCalcolata = LatoRiferimento * AltezzaRif
            End If

        End If

        If LarghezzaConScarto <= LatoRiferimentoConfronto AndAlso LarghezzaConScarto <> 0 Then
            Dim QuantiSuRiga As Integer = Math.Floor(LatoRiferimentoConfronto / LarghezzaConScarto)
            Dim QuanteRighe As Integer = Math.Ceiling(Copie / QuantiSuRiga)

            Dim AltezzaRif As Single = QuanteRighe * AltezzaConScarto
            If AltezzaRif < LatoMinimo Then
                AltezzaRif = LatoMinimo
            End If
            'ora calcolo i centimetri quadrati del pezzo che uso 

            If AltezzaRiferimentoCm Then
                If AltezzaRiferimentoCm >= AltezzaRif Then
                    'qui vedo a fogli fissi quanti ne servono
                    Dim QuantiFogli As Single = AltezzaRif / AltezzaRiferimentoCm
                    QuantiFogli = Math.Ceiling(QuantiFogli)
                    AltezzaRif = QuantiFogli * AltezzaRiferimentoCm
                    SoluzioneSuLarghezza.AreaCalcolata = LatoRiferimento * AltezzaRif
                End If
            Else
                SoluzioneSuLarghezza.AreaCalcolata = LatoRiferimento * AltezzaRif
            End If

        End If

        Dim SoluzioneSuPannelli As New RisSviluppoMq

        'Dim AreaConPannelli As Single = 0
        If SoluzioneSuAltezza.AreaCalcolata = 0 And SoluzioneSuLarghezza.AreaCalcolata = 0 And LatoRiferimento <> 0 Then

            Dim SoluzioneSuPannelliH As New RisSviluppoMq
            Dim SoluzioneSuPannelliW As New RisSviluppoMq

            If LarghezzaRiferimentoCm <> 0 AndAlso AltezzaRiferimentoCm <> 0 Then

                'qui devo pannellizzare
                'Dim SviluppoAreaH As Single = 0
                'Dim SviluppoAreaW As Single = 0

                Dim NumeroRighe As Single = (LarghezzaValidataCm / LarghezzaRiferimentoCm)
                Dim NumeroColonne As Single = (AltezzaValidataCm / AltezzaRiferimentoCm)

                Dim ParteInteraR As Integer = 0
                Dim ParteInteraC As Integer = 0

                If NumeroRighe > 1 Then
                    'piu di un pannello 
                    ParteInteraR = Math.Floor(NumeroRighe) * LarghezzaRiferimentoCm
                    Dim DifferenzaR As Integer = LarghezzaValidataCm - (Math.Floor(NumeroRighe) * LarghezzaRiferimentoCm)
                    Dim ParteMobileR As Integer = 0

                    If DifferenzaR Then
                        ParteMobileR = Math.Floor(LarghezzaRiferimentoCm / DifferenzaR)
                        ParteMobileR = LarghezzaRiferimentoCm / ParteMobileR
                    End If

                    ParteInteraR += ParteMobileR

                    Dim ParteMobileC As Integer = 0
                    If NumeroColonne > 1 Then
                        ParteInteraC = Math.Floor(NumeroColonne) * AltezzaRiferimentoCm
                        Dim DifferenzaC As Integer = AltezzaValidataCm - (Math.Floor(NumeroColonne) * AltezzaRiferimentoCm)

                        If DifferenzaC Then
                            ParteMobileC = Math.Floor(AltezzaRiferimentoCm / DifferenzaC)
                            ParteMobileC = AltezzaRiferimentoCm / ParteMobileC
                        End If
                    Else
                        Dim QuantiFogli As Single = AltezzaRiferimentoCm / AltezzaValidataCm
                        QuantiFogli = Math.Floor(QuantiFogli)
                        ParteMobileC = AltezzaRiferimentoCm / QuantiFogli

                    End If

                    ParteInteraC += ParteMobileC

                Else
                    'un lato piu piccolo del pannello
                    Dim QuantiFogli As Single = LarghezzaRiferimentoCm / LarghezzaValidataCm
                    QuantiFogli = Math.Floor(QuantiFogli)
                    ParteInteraR = LarghezzaRiferimentoCm / QuantiFogli

                    Dim ParteMobileC As Integer = 0
                    ParteInteraC = Math.Floor(NumeroColonne) * AltezzaRiferimentoCm
                    If NumeroColonne > 1 Then
                        Dim DifferenzaC As Integer = AltezzaValidataCm - (Math.Floor(NumeroColonne) * AltezzaRiferimentoCm)

                        If DifferenzaC Then
                            ParteMobileC = Math.Floor(AltezzaRiferimentoCm / DifferenzaC)
                            ParteMobileC = AltezzaRiferimentoCm / ParteMobileC
                        End If
                    End If

                    ParteInteraC += ParteMobileC

                End If

                SoluzioneSuPannelliW.AreaCalcolata = (ParteInteraR * ParteInteraC) * Copie
                ParteInteraR = 0
                ParteInteraC = 0

                NumeroRighe = (LarghezzaValidataCm / AltezzaRiferimentoCm)
                NumeroColonne = (AltezzaValidataCm / LarghezzaRiferimentoCm)

                If NumeroRighe > 1 Then
                    'piu di un pannello 
                    ParteInteraR = Math.Floor(NumeroRighe) * AltezzaRiferimentoCm
                    Dim DifferenzaR As Integer = LarghezzaValidataCm - (Math.Floor(NumeroRighe) * AltezzaRiferimentoCm)
                    Dim ParteMobileR As Integer = 0

                    If DifferenzaR Then
                        ParteMobileR = Math.Floor(AltezzaRiferimentoCm / DifferenzaR)
                        ParteMobileR = AltezzaRiferimentoCm / ParteMobileR
                    End If

                    ParteInteraR += ParteMobileR

                    Dim ParteMobileC As Integer = 0

                    If NumeroColonne > 1 Then
                        ParteInteraC = Math.Floor(NumeroColonne) * LarghezzaRiferimentoCm
                        Dim DifferenzaC As Integer = AltezzaValidataCm - (Math.Floor(NumeroColonne) * LarghezzaRiferimentoCm)

                        If DifferenzaC Then
                            ParteMobileC = Math.Floor(LarghezzaRiferimentoCm / DifferenzaC)
                            ParteMobileC = LarghezzaRiferimentoCm / ParteMobileC
                        End If
                    Else
                        Dim QuantiFogli As Single = LarghezzaRiferimentoCm / AltezzaValidataCm
                        QuantiFogli = Math.Floor(QuantiFogli)
                        ParteMobileC = LarghezzaRiferimentoCm / QuantiFogli

                    End If
                    ParteInteraC += ParteMobileC

                Else
                    'un lato piu piccolo del pannello
                    Dim QuantiFogli As Single = LarghezzaRiferimentoCm / LarghezzaValidataCm
                    QuantiFogli = Math.Floor(QuantiFogli)
                    ParteInteraR = LarghezzaRiferimentoCm / QuantiFogli

                    Dim ParteMobileC As Integer = 0

                    If NumeroColonne > 1 Then
                        ParteInteraC = Math.Floor(NumeroColonne) * AltezzaRiferimentoCm
                        Dim DifferenzaC As Integer = AltezzaValidataCm - (Math.Floor(NumeroColonne) * AltezzaRiferimentoCm)

                        If DifferenzaC > 0 Then
                            ParteMobileC = Math.Ceiling(AltezzaRiferimentoCm / DifferenzaC)
                            ParteMobileC = AltezzaRiferimentoCm / ParteMobileC
                        End If
                    Else
                        ParteMobileC = AltezzaRiferimentoCm / QuantiFogli

                    End If

                    ParteInteraC += ParteMobileC

                End If

                SoluzioneSuPannelliH.AreaCalcolata = ParteInteraR * ParteInteraC * Copie

                If SoluzioneSuPannelliH.AreaCalcolata < SoluzioneSuPannelliW.AreaCalcolata Then
                    SoluzioneSuPannelli = SoluzioneSuPannelliH
                Else
                    SoluzioneSuPannelli = SoluzioneSuPannelliW
                End If

            Else
                'qui fa varie strisce di rotolo
                Dim LatoPiuCorto As Single = 0
                Dim LatoMoltiplicatore As Single = 0
                If Larghezza < Altezza Then
                    LatoPiuCorto = LarghezzaConScarto
                    LatoMoltiplicatore = AltezzaConScarto
                Else
                    LatoPiuCorto = AltezzaConScarto
                    LatoMoltiplicatore = LarghezzaConScarto
                End If

                Dim QuantiPannelli As Integer = Math.Ceiling(LatoPiuCorto / LatoRiferimento)
                SoluzioneSuPannelli.AreaCalcolata = (QuantiPannelli * LatoRiferimento) * LatoMoltiplicatore * Copie
            End If

        End If

        SoluzioneSuAltezza.AreaCalcolata = Math.Round((SoluzioneSuAltezza.AreaCalcolata / 10000), 2)
        SoluzioneSuLarghezza.AreaCalcolata = Math.Round((SoluzioneSuLarghezza.AreaCalcolata / 10000), 2)
        SoluzioneSuPannelli.AreaCalcolata = Math.Round((SoluzioneSuPannelli.AreaCalcolata / 10000), 2)

        If SoluzioneSuAltezza.AreaCalcolata > 0 Or SoluzioneSuLarghezza.AreaCalcolata > 0 Then
            If SoluzioneSuLarghezza.AreaCalcolata > 0 Then
                If (SoluzioneSuAltezza.AreaCalcolata < SoluzioneSuLarghezza.AreaCalcolata) And SoluzioneSuAltezza.AreaCalcolata > 0 Then
                    RisEx = SoluzioneSuAltezza
                Else
                    RisEx = SoluzioneSuLarghezza
                End If
            Else
                RisEx = SoluzioneSuAltezza
            End If
        Else
            RisEx = SoluzioneSuPannelli
        End If

        'RisEx.AreaCalcolata = Ris

        Return RisEx

    End Function

End Class