Imports System.Drawing
Imports FormerLib.FormerEnum

Public Class FormerColori

    Public Shared Property ColoreRubricaCliente As Color = Color.FromArgb(214, 224, 61)
    Public Shared Property ColoreRubricaRivenditore As Color = Color.FromArgb(255, 128, 0)
    Public Shared Property ColoreRubricaFornitore As Color = Color.Red

    Public Shared Property ColoreAmbienteSfondoForm As Color = Color.FromArgb(236, 239, 241)
    Public Shared Property ColoreAmbienteSfondoPrincipale As Color = Color.FromArgb(255, 128, 0)
    Public Shared Property ColoreAmbienteGrigioChiaro As Color = Color.FromArgb(208, 208, 208)
    Public Shared Property ColoreAmbienteGrigioChiarissimo As Color = Color.FromArgb(248, 248, 248)
    Public Shared Property ColoreAmbienteSfondoGrigioScuro As Color = Color.FromArgb(64, 64, 64)
    Public Shared Property ColoreAmbienteVerde As Color = Color.FromArgb(214, 224, 61)

    Public Shared Property ColoreStatoCommessaPreinserito As Color = Color.FromArgb(255, 0, 0)
    Public Shared Property ColoreStatoCommessaPronto As Color = Color.FromArgb(248, 195, 0)
    Public Shared Property ColoreStatoCommessaStampa As Color = Color.FromArgb(255, 245, 0)
    Public Shared Property ColoreStatoCommessaFinituraSuCommessa As Color = Color.FromArgb(215, 237, 251)
    Public Shared Property ColoreStatoCommessaFinituraSuProdotti As Color = Color.FromArgb(117, 197, 240)
    Public Shared Property ColoreStatoCommessaCompletata As Color = Color.FromArgb(0, 255, 0)

    Public Shared Property ColoreStatoAccettato As Color = Color.FromArgb(70, 197, 85)
    Public Shared Property ColoreStatoRifiutato As Color = Color.FromArgb(242, 47, 47)

    Public Shared Property ColoreStatoOrdineInAttesaAllegati As Color = Color.FromArgb(255, 0, 0)
    Public Shared Property ColoreStatoOrdineRefine As Color = Color.FromArgb(245, 159, 85)
    Public Shared Property ColoreStatoOrdinePreinserito As Color = Color.FromArgb(245, 130, 32)
    Public Shared Property ColoreStatoOrdineInAttesaPagamento As Color = Color.FromArgb(232, 22, 22)
    Public Shared Property ColoreStatoOrdineRegistrato As Color = Color.FromArgb(214, 224, 61)
    Public Shared Property ColoreStatoOrdineInSospeso As Color = Color.FromArgb(100, 100, 100)
    Public Shared Property ColoreStatoOrdineProntoConCommessa As Color = Color.FromArgb(255, 245, 0)
    Public Shared Property ColoreStatoOrdineInLavorazione As Color = Color.FromArgb(222, 222, 222)
    Public Shared Property ColoreStatoOrdineImballaggio As Color = Color.FromArgb(215, 237, 251)
    Public Shared Property ColoreStatoOrdineImballaggioCorriere As Color = Color.FromArgb(215, 237, 251)
    Public Shared Property ColoreStatoOrdineProntoStampa As Color = Color.FromArgb(117, 197, 240)
    Public Shared Property ColoreStatoOrdineUscitoDaMagazzino As Color = Color.FromArgb(240, 117, 236)
    Public Shared Property ColoreStatoOrdineInConsegna As Color = Color.FromArgb(182, 221, 199)
    Public Shared Property ColoreStatoOrdineConsegnato As Color = Color.FromArgb(60, 179, 194)
    Public Shared Property ColoreStatoOrdinePagato As Color = Color.FromArgb(0, 255, 0)
    Public Shared Property ColoreStatoOrdineRifiutato As Color = Color.White
    Public Shared Property ColoreStatoOrdineEliminato As Color = Color.White

    Public Shared Property ColoreOrdineOmaggio As Color = Color.FromArgb(133, 12, 112)

    Public Shared Property ColoreStatoDocRegistrato As Color = Color.FromArgb(248, 195, 0)
    Public Shared Property ColoreStatoDocPagatoAcconto As Color = Color.FromArgb(255, 90, 0)
    Public Shared Property ColoreStatoDocPagatoInteramente As Color = Color.FromArgb(0, 255, 0)

    Public Shared Property ColoreCorriereRitiroCliente As Color = Color.FromArgb(252, 251, 160)
    Public Shared Property ColoreCorriereTipografiaFormer As Color = Color.FromArgb(184, 252, 160)
    Public Shared Property ColoreCorriereAltro As Color = Color.FromArgb(216, 253, 250)

    Public Shared Property ColoreRepartoOffset As Color = Color.FromArgb(133, 12, 112)
    Public Shared Property ColoreRepartoDigitale As Color = Color.FromArgb(0, 158, 201)
    Public Shared Property ColoreRepartoPackaging As Color = Color.FromArgb(245, 130, 32)
    Public Shared Property ColoreRepartoEtichette As Color = Color.FromArgb(231, 0, 49)
    Public Shared Property ColoreRepartoRicamo As Color = Color.FromArgb(214, 224, 61)

    Public Shared Property ColoreControlloPrimario As Color = Color.FromArgb(255, 128, 0)
    Public Shared Property ColoreControlloSecondario As Color = Color.FromArgb(249, 178, 79)

    Public Shared Property ColoreOmaggioSfondo As Color = Color.FromArgb(133, 12, 112)
    Public Shared Property ColoreOmaggioPrimoPiano As Color = Color.White

    Public Shared Property ColoreFunctionLocked As Color = Color.FromArgb(134, 255, 140)
    Public Shared Property ColoreFunctionUnlocked As Color = Color.White

    Public Shared Property ColoreStatoIncassoNormale As Color = Color.FromArgb(192, 255, 192)
    Public Shared Property ColoreStatoIncassoProblematico As Color = Color.FromArgb(255, 255, 192)
    Public Shared Property ColoreStatoIncassoDifficile As Color = Color.FromArgb(255, 224, 192)
    Public Shared Property ColoreStatoIncassoImpossibile As Color = Color.FromArgb(255, 128, 128)

    Public Shared Function GetForeColor(BackColor As Color) As Color

        Dim Somma As Integer = (CInt(BackColor.R) + CInt(BackColor.G) + CInt(BackColor.B)) / 3

        If Somma > 128 Then
            Return Color.Black
        Else
            Return Color.White
        End If

    End Function

    Public Shared Function GetColoreCasuale() As Color

        'Dim R As Integer = 0
        'Dim G As Integer = 0
        'Dim B As Integer = 0

        Dim random As New Random
        'Randomize()
        'R = random.Next(0, 255)
        'Randomize()
        'G = random.Next(0, 255)
        'Randomize()
        'B = random.Next(0, 255)

        'Dim ris As Color = Color.FromArgb(R, G, B)


        Dim ris As Color = Color.FromArgb(&HFF000000 Or random.Next(&HFFFFFF + 1))

        Return ris
    End Function

    Public Shared Function GetColoreStatoIncasso(StatoIncasso As enStatoIncasso) As Color
        Dim Ris As Color = Color.White
        Select Case StatoIncasso
            Case enStatoIncasso.Normale
                Ris = ColoreStatoIncassoNormale
            Case enStatoIncasso.Problematico
                Ris = ColoreStatoIncassoProblematico
            Case enStatoIncasso.Difficile
                Ris = ColoreStatoIncassoDifficile
            Case enStatoIncasso.Impossibile
                Ris = ColoreStatoIncassoImpossibile
        End Select
        Return Ris
    End Function

    Public Shared Function GetColoreStatoDocFiscale(stDoc As enStatoDocumentoFiscale) As Color

        Dim _C As Color

        Select Case stDoc
            Case enStatoDocumentoFiscale.Registrato
                _C = ColoreStatoDocRegistrato
            Case enStatoDocumentoFiscale.PagatoAcconto
                _C = ColoreStatoDocPagatoAcconto
            Case enStatoDocumentoFiscale.PagatoInteramente
                _C = ColoreStatoDocPagatoInteramente
        End Select

        Return _C

    End Function

    Public Shared Function GetColoreToHtml(colore As Color) As String

        Return ColorTranslator.ToHtml(colore)

    End Function


    Public Shared Function GetColorefromHtml(colore As String) As Color

        Return ColorTranslator.FromHtml(colore)

    End Function

    Public Shared Function GetColoreStatoOrdineHtml(stOrd As enStatoOrdine) As String
        Return ColorTranslator.ToHtml(GetColoreStatoOrdine(stOrd))
    End Function

    Public Shared Function GetColoreSfondoCorriere(IdCorr As Integer) As Color
        Dim _ColoreCorr As Color = Color.White
        Select Case IdCorr
            Case enCorriere.RitiroCliente
                _ColoreCorr = ColoreCorriereRitiroCliente
            Case enCorriere.TipografiaFormer
                _ColoreCorr = ColoreCorriereTipografiaFormer
            Case Else
                _ColoreCorr = ColoreCorriereAltro
        End Select
        Return _ColoreCorr
    End Function

    Public Shared Function GetColoreStatoOrdine(stOrd As enStatoOrdine) As Color
        Dim _StatoColore As Color = Color.White
        Select Case stOrd
            Case enStatoOrdine.InAttesaAllegati
                _StatoColore = ColoreStatoOrdineInAttesaAllegati
            Case enStatoOrdine.RefineAutomatico
                _StatoColore = ColoreStatoOrdineRefine
            Case enStatoOrdine.Preinserito
                _StatoColore = ColoreStatoOrdinePreinserito
            Case enStatoOrdine.InAttesaPagamento
                _StatoColore = ColoreStatoOrdineInAttesaPagamento
            Case enStatoOrdine.Registrato
                _StatoColore = ColoreStatoOrdineRegistrato
            Case enStatoOrdine.InSospeso
                _StatoColore = ColoreStatoOrdineInSospeso
            Case enStatoOrdine.InCodaDiStampa
                _StatoColore = ColoreStatoOrdineProntoConCommessa
            Case enStatoOrdine.StampaInizio
                _StatoColore = ColoreStatoOrdineInLavorazione
            Case enStatoOrdine.StampaFine
                _StatoColore = ColoreStatoOrdineInLavorazione
            Case enStatoOrdine.FinituraCommessaInizio
                _StatoColore = ColoreStatoOrdineInLavorazione
            Case enStatoOrdine.FinituraCommessaFine
                _StatoColore = ColoreStatoOrdineInLavorazione
            Case enStatoOrdine.FinituraProdottoInizio
                _StatoColore = ColoreStatoOrdineInLavorazione
            Case enStatoOrdine.FinituraProdottoFine
                _StatoColore = ColoreStatoOrdineInLavorazione
            Case enStatoOrdine.Imballaggio
                _StatoColore = ColoreStatoOrdineImballaggio
            Case enStatoOrdine.ImballaggioCorriere
                _StatoColore = ColoreStatoOrdineImballaggioCorriere
            Case enStatoOrdine.ProntoRitiro
                _StatoColore = ColoreStatoOrdineProntoStampa
            Case enStatoOrdine.UscitoMagazzino
                _StatoColore = ColoreStatoOrdineUscitoDaMagazzino
            Case enStatoOrdine.InConsegna
                _StatoColore = ColoreStatoOrdineInConsegna
            Case enStatoOrdine.Consegnato
                _StatoColore = ColoreStatoOrdineConsegnato
            Case enStatoOrdine.PagatoAcconto
                _StatoColore = ColoreStatoOrdinePagato
            Case enStatoOrdine.PagatoInteramente
                _StatoColore = ColoreStatoOrdinePagato
            Case enStatoOrdine.Rifiutato
                _StatoColore = ColoreStatoOrdineRifiutato
            Case enStatoOrdine.Eliminato
                _StatoColore = ColoreStatoOrdineEliminato
        End Select

        Return _StatoColore
    End Function

    Public Shared Function GetColoreStatoCommessa(stCom As enStatoCommessa) As Color
        Dim _StatoColore As Color = Color.White
        Select Case stCom
            Case enStatoCommessa.Preinserito
                _StatoColore = ColoreStatoCommessaPreinserito
            Case enStatoCommessa.Pronto
                _StatoColore = ColoreStatoCommessaPronto
            Case enStatoCommessa.Stampa
                _StatoColore = ColoreStatoCommessaStampa
            Case enStatoCommessa.FinituraSuCommessa
                _StatoColore = ColoreStatoCommessaFinituraSuCommessa
            Case enStatoCommessa.FinituraSuProdotti
                _StatoColore = ColoreStatoCommessaFinituraSuProdotti
            Case enStatoCommessa.Completata
                _StatoColore = ColoreStatoCommessaCompletata
        End Select

        Return _StatoColore
    End Function

    Public Shared Function GetColoreStatoConsegna(stCons As enStatoConsegna) As Color
        Dim _StatoColore As Color = Color.White
        Select Case stCons
            Case enStatoConsegna.Inserito
                _StatoColore = ColoreStatoOrdinePreinserito
            Case enStatoConsegna.InLavorazione
                _StatoColore = ColoreStatoOrdineRegistrato
            Case enStatoConsegna.InConsegna
                _StatoColore = ColoreStatoOrdineInConsegna
            Case enStatoConsegna.Consegnata
                _StatoColore = ColoreStatoOrdineConsegnato
            Case enStatoConsegna.InAttesaDiPagamento
                _StatoColore = ColoreStatoOrdineInAttesaPagamento
            Case enStatoConsegna.Eliminata
                _StatoColore = ColoreStatoOrdineEliminato
            Case enStatoConsegna.Pagato
                _StatoColore = ColoreStatoOrdinePagato
            Case enStatoConsegna.Sospesa
                _StatoColore = ColoreStatoOrdineInSospeso
        End Select
        Return _StatoColore
    End Function

    Public Shared Function GetColoreStatoConsegnaHtml(stCons As enStatoConsegna) As String
        Return ColorTranslator.ToHtml(GetColoreStatoConsegna(stCons))
    End Function

    Public Shared Function GetColoreReparto(Reparto As enRepartoWeb) As Color
        Dim ris As Color

        Select Case Reparto
            Case enRepartoWeb.Etichette
                ris = ColoreRepartoEtichette
            Case enRepartoWeb.StampaDigitale
                ris = ColoreRepartoDigitale
            Case enRepartoWeb.StampaOffset
                ris = ColoreRepartoOffset
            Case enRepartoWeb.Packaging
                ris = ColoreRepartoPackaging
            Case enRepartoWeb.Ricamo
                ris = ColoreRepartoRicamo
            Case enRepartoWeb.Tutto
                ris = Color.White
        End Select


        Return ris
    End Function

End Class
