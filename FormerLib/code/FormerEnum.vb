Namespace FormerEnum

    Public Enum enTipoAzione As Integer
        Nuovo = 1
        Modifica
        Visualizzazione
        Eliminazione
        Duplicazione
    End Enum

    Public Enum enTipoSoluzione As Integer
        Perfetta = 1
        Plausibile
    End Enum

    Public Enum enEsigibilitaIVA As Integer
        Immediata = 0
        Differita = 1
        SplitPayment = 2
    End Enum

    Public Enum enTipoVoceLog As Integer
        Ordine = 1
        Consegna = 2
    End Enum

    Public Enum enTipoDecodificaVoceCosto As Integer
        Interpretazione = 1
        Esclusione
    End Enum
    Public Enum enStatoCheckMassivo As Integer
        DaEffettuare = 0
        Attenzione
        Completato
    End Enum

    Public Enum enSezioneF24 As Integer
        Erario = 1
        Inps
        Regioni
        Imu
        AltriEnti
    End Enum
    Public Enum enUnitaDiMisura As Integer
        Pezzi = 0
        kg = 1
        m = 2
        m3 = 3
        l = 4
        cm = 5
        cm3 = 6
        m2 = 7
        cm2 = 8
        bobina = 9
        lastra = 10
        mm = 11
    End Enum

    Public Enum enTipoSuono As Integer
        Ok = 1
        OkGiroCompletato
        ErroreNoClientiDiversi
        ErroreColloGiaCaricato
        ErroreCodiceInseritoNonValido
        ErroreCodiceABarreRelativoAUnAltroOrdine
        ErroreOrdineNonInConsegna
    End Enum

    Public Enum enTipoNotifica As Integer
        Chiamata
        NuoviOrdini
        NuoviPreventivi
        NuovaVersione
        FattureAcquisto
        FattureVendita
    End Enum

    Public Enum enTipoGrandezzaPrezzoLavorazione As Integer
        Piccolo = 1
        Medio = 0
        Grande = 2
    End Enum

    Public Enum enStatoFatturaFE As Integer
        Tutti = -1
        DaInviare = 0
        InCodaInvio
        InviatoXML
        ScartataSDI
        AccettataPEC
        ConsegnataPEC
        NonConsegnataDestinatario
        ConsegnataDestinatario
        RicevutoEsito
        DecorsiTerminiEsito
        TrasmessaSenzaRecapito
        Archiviata
        AllegatoXMLRicevuto
    End Enum

    Public Enum enTipoMailPEC As Integer
        Altro = 0
        Accettazione = 1
        Consegna
        Scarto
        Ricevuta
        MancataConsegna
        InvioFile
    End Enum

    Public Enum enStatoFEInterno As Integer
        Tutto = 0
        Inserito = 1
        Anomalia
        Collegato
    End Enum

    Public Enum enStatoFEInternoSearch As Integer
        Tutto = 0
        NonCollegato
        Collegato
    End Enum

    Public Enum enTipoRegola As Integer
        DiSistema = 0
        Utente = 1
    End Enum

    Public Enum enFunctionLock As Integer
        NonSpecificata = 0
        PreRefine = 1
        CreazioneCommesse = 2
        CreazioneCommesseFromGanging = 3
        CommessaAperta = 4
        OrdineAperto = 5
    End Enum

    Public Enum enTipoMail As Integer
        Preventivo = 0
        Ordine
    End Enum

    Public Enum enTipoBordoEmail As Integer
        Nessuno = 0
        Standard = 1
        Azzurro = 2
        Rosso = 3
    End Enum

    Public Enum enMotoreCalcoloSoluzioni As Integer
        MotoreStabile = 1
        MotoreBeta
    End Enum

    Public Enum enTipoControlloSuForm As Integer
        NonSpecificato = 0
        Principale = 1
        Secondario
    End Enum

    Public Enum enTipoControllo As Integer
        RadioButton = 0
        ComboBox = 1
        CheckBox = 2
    End Enum

    Public Enum enTipoControlloPrezzo As Integer
        ComboBox = 0
        Tabella = 1
        TextBox = 2
    End Enum

    Public Enum enTipoMessaggio As Integer
        Messaggio = 0
        Chiamata
        Automatico
    End Enum

    Public Enum enPluginOnline As Integer
        Nessuno = 0
        Packaging = 1
        Etichette = 2
        EtichetteCm = 3
        MisurePersonalizzate = 4
    End Enum

    Public Enum enAlertLevelOrdini As Integer
        Normale = 0
        InviataEmailAvviso = 1
        EliminatoDopoAlert = 2
    End Enum

    Public Enum enStepWizard As Integer
        Nessuno = 0
        Preventivazione = 1
        FormatoProdotto
        TipoCarta
        ColoriStampa
        Fogli
        Prodotto
    End Enum

    Public Enum enStatoRefineSorgente As Integer
        NonDefinito = 0
        InAttesaDiRefine = 1
        CompletatoSuccess = 2
        CompletatoErrore = 3
        CompletatoWarning = 4
        CompletatoCancelled = 5
    End Enum

    Public Enum enLatoAppoggio As Integer
        LatoLargLung = 1 ' il lato che sta tra la larghezza e l'altezza
        LatoLungProf = 2 ' il lato che sta tra l'altezza e la profondita
        LatoLargProf = 3 ' il lato che sta tra la larghezza e la profondita
    End Enum

    Public Enum enAsseXYZ
        Altezza = 1
        Base = 2
        Profondita = 3
    End Enum

    Public Enum enMetodoPagamento As Integer
        AllaConsegna = 1
        BonificoBancarioAnticipato = 2
        Contanti = 7
        ContrassegnoAlRitiro = 8
        PayPal = 9
        BonificoBancario = 10
        CartaDiCredito = 13
        StornoDaNotaDiCredito = 14
        AssegnoBancario = 15
    End Enum

    Public Enum enStatoPagamento As Integer
        DaPagare = 1
        Pagato = 2
        Annullato = 3
    End Enum

    Public Enum enVersoAppoggio As Integer
        PerCorto = 1
        PerLungo = 2
    End Enum

    Public Enum enDirezione As Integer
        Sopra = 1
        Sotto
        Sinistra
        Destra
    End Enum

    Public Enum enTipologiaScatola As Integer
        Scatola = 0
        Busta = 1
        ImballoPersonalizzato = 2
    End Enum

    Public Enum enTargetListinoBase As Integer
        Foglio = 0
        Pagina = 1
    End Enum

    Public Enum enTipoOrientamento As Integer
        Orizzontale = 0
        Verticale = 1
        Neutro = 2
        NonSpecificato = -1
    End Enum

    Public Enum enTipoCarta As Integer
        Semplice = 0
        Composta = 1
    End Enum

    Public Enum enTipoUtente As Integer
        Operatore = 1
        Admin = 2
        SuperOperatore = 3
    End Enum

    Public Enum enStatoComandoRemoto As Integer
        Inserito = 1
        PresoInCarico
        Completato
        Warning
        Errore
    End Enum

    Public Enum enTipoComandoRemoto As Integer
        NonSpecificato = 0
        CreaAnteprimaCommessa = 1
        CreaAnteprimaCommessaEMandaAlFlusso
        MandaAlFlussoCommessa


    End Enum

    Public Enum enTipoReportEconomico As Integer
        BilancioEsercizio = 1
        ReportIVA
        InventarioMagazzino
    End Enum

    Public Enum enTipoListiniBase As Integer
        Tutto = 0
        Sorgente = 1
        Produzione = 2
    End Enum

    Public Enum enTipoPrezzoToShow As Integer
        TotaleNetto = 0
        TotaleIVACompresa = 1
        CadNetto = 2
        'CadIVACompresa = 3
    End Enum

    Public Enum enSiNo As Integer
        No = 0
        Si = 1
        NonDefinito = 2
    End Enum


    Public Enum enColoriStampa As Integer
        ColoriFronteRetro = 1
        ColoriSoloFronte = 2
    End Enum

    Public Enum enTipologiaOmaggio As Integer
        Tutto = 0
        AlPrimoOrdine = 1
        ConCriteri = 2
    End Enum

    Public Enum enTipoAnteprima As Integer
        Generale = 1
        Breve = 2
        Lavorazioni = 3
        Imballo = 4
        Operatore = 5
    End Enum

    Public Enum enTipoOpFTP As Integer
        Upload = 1
        Download
    End Enum

    Public Enum enEmailStato As Integer
        Inviata = 0
        InCoda = 1
        DaInviare = 2
        DaNonInviare = 3
        Errore = 4
    End Enum

    Public Enum enFiltroTipoDocumento As Integer
        Tutto = 0
        Fattura = 1
        DDT
        Preventivo
        FatturaRiepilogativa
        NotaDiCredito
        DDTInFattura
        FatturaENotaDiCredito
        NotaDiDebito
        AccontoAnticipoSuFattura
    End Enum

    Public Enum enTipoDocumento As Integer
        Altro = 0
        Fattura = 1
        DDT
        Preventivo
        FatturaRiepilogativa
        NotaDiCredito
        NotaDiDebito
        AccontoAnticipoSuFattura
        AccontoAnticipoSuParcella
        Parcella
    End Enum

    Public Enum enTipoVoceContab As Integer
        NonSpecificata = 0
        VoceVendita = 1
        VoceAcquisto = 2
    End Enum

    Public Enum enTipoPagamento As Integer
        Anticipato = 1
        Posticipato = 2
    End Enum

    Public Enum enTipoVoceOrdineCommessa As Integer
        Ordine = 1
        Commessa
    End Enum
    Public Enum enStatoRichiestaRegistrazione As Integer
        InSospeso = 1
        Lavorata
    End Enum

    Public Enum enTipoFormaEtichetta As Integer
        Custom = 0
        Rettangolare = 1
        Cerchio = 2
        Ellisse = 3
    End Enum

    Public Enum enTipoFiltroMarketing As Integer
        SuListiniBase
        SuFileHtml
        SuTemplateFormer
    End Enum

    Public Enum enStatoFiltroMarketing As Integer
        Attivo = 0
        NonAttivo = 1
        Eliminato = 2
    End Enum

    Public Enum enStatoRichiesta As Integer
        Ok = 1
        No = 2
        Cancellato = 3
    End Enum

    Public Enum enTipoRubrica As Integer
        Tutto = 0
        Cliente = 1
        'Fornitore = 2
        Rivenditore = 3
        'Agente = 4
    End Enum

    'Public Enum enTipoWeb As Integer
    '    Privato = 0
    '    Societa = 1
    '    Rivenditore = 2
    'End Enum
    Public Enum enPeriodoPagamento As Integer
        Anticipato = 1
        Posticipato = 2
    End Enum

    Public Enum enStatoReview As Integer
        DaApprovare = 0
        Approvata = 1
        NonApprovata = 2
    End Enum

    Public Enum enTipoOggettoListino As Integer

        Preventivazione = 1
        Lavorazione
        Macchinario
        CatProd
        ColoreStampa
        FormatoProdotto
        TipoCarta
        CategoriaFustella
        TipoFustella
        CatLav
        CatFormatoProdotto
        ListinoBase

    End Enum

    Public Enum enStato As Integer
        Attivo = 0
        NonAttivo
    End Enum

    Public Enum enTipoRicercaRub As Integer
        RagioneSociale = 1
        Cognome
        PartitaIva
        CodiceFiscale
    End Enum

    'Public Enum enTipoComSSSS As Integer
    '    Offset = 1
    '    Digitale
    'End Enum

    Public Enum enStatoDocumentoFiscale As Integer
        NonDefinito = 0
        RegistratoAutomaticamente = 5
        Registrato = 10
        PagatoAcconto = 20
        PagatoInteramente = 30

    End Enum

    Public Enum enStatoCommessa As Integer
        Preinserito = 1 '10
        Pronto '20
        Stampa '30
        FinituraSuCommessa '40
        FinituraSuProdotti '50
        Completata '60
    End Enum

    Public Enum enTipoRiferimentoPath As Integer
        Ordine = 1
        Commessa
        FileSorgente
    End Enum

    Public Enum enDaemonService As Integer
        Syncronizer = 1
        Service
        Messenger
        UdpCommand
        Caller
    End Enum

    Public Enum enDaemonLogType As Integer
        Standard
        Exception
    End Enum

    Public Enum enStatoOrdine As Integer
        'VECCHI STATI 
        'Preinserito = 1
        'Pronto = 2
        'InLavorazione = 3
        'Imballaggio = 4
        'ProntoStampa = 5
        'InConsegna = 6 
        'Consegnato = 7 
        'Pagato = 8 
        'Rifiutato = 9 

        'NUOVI STATI
        InAttesaAllegati = 5 'STATO WEB
        RefineAutomatico = 7
        Preinserito = 10 '1
        InAttesaPagamento = 15 'STATO WEB
        Registrato = 20 '2
        InSospeso = 21
        InCodaDiStampa = 22
        StampaInizio = 30 '3
        StampaFine = 31
        FinituraCommessaInizio = 32
        FinituraCommessaFine = 33
        FinituraProdottoInizio = 34
        FinituraProdottoFine = 35
        Imballaggio = 40 '4
        ImballaggioCorriere = 45
        ProntoRitiro = 50 '5
        UscitoMagazzino = 51
        InConsegna = 60 '6
        Consegnato = 70 '7
        PagatoAcconto = 80 '8
        PagatoInteramente = 81
        Rifiutato = 90 '9
        Eliminato = 91

    End Enum

    Public Enum enStatoIncasso As Integer
        Tutto = -1
        Normale = 0
        Problematico = 1
        Difficile = 2
        Impossibile = 3
    End Enum

    Public Enum enTipoRisOffSet As Integer
        MateriaPrima = 0
        Lastra = -1
        ProdottoDiConsumo = 99
        Tutto = 100
    End Enum

    Public Enum enTipoLavorazione As Integer
        suFoglio = 0
        suQuantita = 1
        suFacciata = 2
        UnaTantum = 3
        suMetriQuadri = 4
        suMetriLineari = 5
        suCmQuadri = 6
    End Enum

    Public Enum enTipoMovMagaz
        Tutto = -1
        Inserimento = 0
        Carico = 1
        Scarico = 2
        Storno = 3
        Prenotazione = 4
        RichiestaAcquisto = 5
    End Enum

    Public Enum enRisultatoOrdineScaricato As Integer
        Nessuno = 0
        Accettato = 1
        Rifiutato
    End Enum

    Public Enum enTipoConsegna As Integer
        Normale = 0
        Fast = 1
        Slow = 2
    End Enum

    Public Enum enMomentoConsegna As Integer
        Pomeriggio = 0
        Mattina = 1
        OrarioSpecifico = 2
    End Enum

    Public Enum enTipoAzMarketing As Integer
        InvioMail = 1
        Telefono = 2
        SpedMat = 3
        Visita = 4
    End Enum

    Public Enum enRipetiMarketing As Integer
        Mai = 0
        Mensile = 1
        Trimestrale = 2
        Semestrale = 3
        Annuale = 4
    End Enum

    Public Enum enCorriere As Integer
        AltroCorriere = -1
        RitiroCliente = 1
        TipografiaFormer = 2
        PortoAssegnatoGLS = 6
        TipografiaFormerFuoriRaccordo = 7
        PortoAssegnatoBartolini = 9
        GLS = 10
        Bartolini = 11
        GLSIsole = 12
    End Enum

    Public Enum enTipoCorriere As Integer
        Gratis = 0
        ConTariffa = 1
        PortoAssegnato = 2
    End Enum

    Public Enum enTipoMacchinario As Integer
        Produzione = 1
        Allestimento = 2
    End Enum


    'QUESTE DUE ENUM DEVONO ANDARE OBBLIGATORIAMENTE DI PARI PASSO 
    'IN FUTURO SI PUO PENSARE DI ELIMINARE LA PRIMA E UNIFICARE LA SECONDA IN CASO

    'Public Enum enRepartoOperatore As Integer
    '    StampaOffset = 1
    '    FinituraSuCommessa
    '    FinituraSuProdotto
    '    Imballaggio
    '    ImballaggioCorriere
    '    Consegne
    '    Produzione
    'End Enum

    Public Enum enRepartoMacro As Integer
        OffSet = 1
        Digitale = 2
        ProdottoFinito = 3
    End Enum

    Public Enum enRepartoWeb As Integer
        Tutto = 0
        StampaOffset = 1
        StampaDigitale = 2
        Packaging = 3
        Ricamo = 4
        Etichette = 5
        ProdottoFinito = 6
    End Enum

    Public Enum enTipoProdCom As Integer
        StampaOffSet = 1
        StampaDigitale = 2
        Packaging = 3
        Ricamo = 4
        Etichette = 5

        NonSpecificato = 98
        Consumo = 99
    End Enum

    Public Enum enPrendiIcoDa As Integer
        FormatoProdotto = 0
        Preventivazione
        TipoCarta
        ColoreDiStampa
    End Enum

    Public Enum enFronteRetro As Integer
        Fronte = 1
        Retro = 2
        Copertina = 3
    End Enum

    Public Enum enTipoRetro As Integer
        RetroDifferente = 0
        RetroUgualeFronte = 1
        RetroNelFileFronte = 2
        RetroBianco = 3
    End Enum

    Public Enum enTipoPrezzo As Integer
        SuQuantita = 0 'curva di attenuazione
        SuMetriQuadri = 1
        'SuCCCCCCopie = 2 'DISMISSED
        SuCmQuadri = 3
        SuFoglio = 4
    End Enum

    Public Enum enStatoConsegna As Integer
        Inserito = 0 'NUOVO
        InAttesaDiPagamento = 10 '3
        InLavorazione = 20 ' 0
        RegistrataCorriere = 30 '7
        InConsegna = 40 '1 'stato 60 ordine
        Consegnata = 50 '2 'stato 70 ordine
        Eliminata = 60 '4
        Pagato = 70 '5
        Sospesa = 80 '6
    End Enum

    Public Enum enStatoDataOrdine As Integer
        NonDefinita = 0
        Prevista = 1
        Confermata
        Garantita
        Consegnata
    End Enum

    Public Enum enTipoImballo As Integer
        Fascette = 0
        Termoretraibile = 1
        Scatola = 2
    End Enum

    Public Enum enMesi As Integer
        Gennaio = 1
        Febbraio = 2
        Marzo = 3
        Aprile = 4
        Maggio = 5
        Giugno = 6
        Luglio = 7
        Agosto = 8
        Settembre = 9
        Ottobre = 10
        Novembre = 11
        Dicembre = 12
    End Enum

    Public Enum enPeriodoRiferimento As Integer
        Sempre = 0
        UnGiorno = 1
        UnMese = 2
        TreMesi = 3
        SeiMesi = 6
        UnAnno = 12
        Ieri = 24
        UnaSettimana = 48
    End Enum

    Public Enum enStatoPreventivoMail As Integer
        Qualsiasi = -1
        DaLavorare = 0
        Lavorata = 1
        Eliminata = 2

    End Enum

    Public Enum enStatoEmail As Integer
        DaInviare = 1
        Inviata = 2
        Errore = 3
    End Enum

    Public Enum enFunzionePackaging As Integer
        FunzioneECMA1 = 1
        FunzioneECMA2 = 2
        FunzioneECMA3 = 3
        FunzioneECMA4 = 4
    End Enum

    Public Enum enOrigineContatto As Integer
        Tutto = 0
        Rubrica = 1
        Marketing = 2
    End Enum

    Public Enum enTipoOrientamentoEtichette As Integer
        Su = 1
        Giu
        Destra
        Sinistra
    End Enum

    Public Enum enValidatorErrorLevel As Integer
        None = 0
        Informazione
        Attenzione
        Errore
    End Enum

    Public Enum enValidatorErrorCode As Integer
        Null
        FormatoFileNonCorretto
        DimensioniNonCorrette
        OrientamentoNonCorretto
        FontIncorporati
        FontNonIncorporati
        AbbondanzaErrata
    End Enum

    Public Enum enValidatorReturnCode As Integer
        ValidazioneOk
        ValidazioneKO
    End Enum

    Public Enum enStampaDocumenti As Integer
        No = 0
        Si = 1
        ForzaUscita = 2
    End Enum

    Public Enum enAzioneSottoScorta As Integer
        Nessuna = 0
        RichiestaDiAcquisto
        RiOrdina
    End Enum

    Public Enum enErroriPreRefine As Integer
        Nessuno = 0
        DimensioniErrate = 1
        ModelloNonPresente = 2
        NumeroSorgentiErrato = 4
        ErroreRefinePrinergy = 8
    End Enum

End Namespace