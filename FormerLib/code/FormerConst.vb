Public Class FormerConst

    Public Const EmailAmministrazione As String = "info@tipografiaformer.it"
    Public Const EmailNonDisponibile As String = "emailnondisponibile@tipografiaformer.it"
    Public Const FermoDeposito As String = "FERMO DEPOSITO"
    Public Const EmailAssistenzaTecnica As String = "soft@tipografiaformer.it"
    Public Const PrefissoFileListinoTemp As String = "ToBeReplaced_"

    Public Class Culture
        Public Const IdItalia As Integer = 0
        Public Const CapEstero As String = "00000"
    End Class

    Public Class Fiscali
        Public Const PercentualeIva As Integer = 22
        Public Const PercentualeMultiIva As Integer = 99
        Public Const NumCopieDocFiscali As Integer = 2
        Public Const PartitaIvaNonDisponibile As String = "00000000000"
        Public Const PrefissoNazioneIT As String = "IT"
        Public Const IdBiennio As Integer = -1
    End Class

    Public Class Tag
        Public Const NomeDiBattesimoCliente As String = "$$Cliente.Nome$$"
        Public Const NumeroPreventivo As String = "$$Numero.Preventivo$$"
    End Class

    Public Class Anteprime
        Public Const TagContenuto As String = "$$CONTENT$$"
    End Class

    Public Class Ambiente
        Public Const ConnectionStringServerInternoWEB As String = "Data Source=former-server\sqlexpress,1433;Initial Catalog=FormerWeb;MultipleActiveResultSets=true;User Id=sa;Password=tgHi9MaEQA;Connect Timeout=0;Encrypt=false;Packet Size=4096;"
        Public Const ConnectionStringServerWebTwin As String = "Data Source=former-server\sqlexpress,1433;Initial Catalog=FormerWebTwin;MultipleActiveResultSets=true;User Id=sa;Password=tgHi9MaEQA;Connect Timeout=0;Encrypt=false;Packet Size=4096;"

        Public Const PathFoglioStileFatturaElettronica As String = "z:/fatture/fe/"
        Public Const NomeFoglioStileFatturaElettronica As String = "fatturaordinaria_v1.2.xsl"
    End Class

    Public Class UtentiSpecifici
        Public Const IdUtenteAdmin As Integer = 1
        Public Const IdUtenteAntonio As Integer = 13
        Public Const IdUtenteAndrea As Integer = 14
        Public Const IdUtenteLidia As Integer = 15
        Public Const IdRubricaInternaFormer As Integer = 1343 'id rubrica interna dell'utente former che fa gli ordini dal sito 
    End Class

    Public Class ProdottiParticolari
        Public Const IdListinoBaseGabettiLazio As Integer = 464
        Public Const IdListinoBaseGabettiSardegna As Integer = 564
        Public Const IdListinoBaseGrimaldi As Integer = 486
        Public Const IdPreventivazioneOmaggi As Integer = 36 'QUELLA REALE 
        Public Const IdCatOrientamentoEtichette As Integer = 40

    End Class

    Public Class ProdottiCaratteristiche
        Public Const ScartoMMLatoSoggetto As Integer = 4
        Public Const AnimaDefaultBobineRotoliCm As Integer = 8
        Public Const CmTaglioMazzetta As Integer = 6
        Public Const PercentualeMassimaRiduzioneFormato As Integer = 60
        Public Class EtichetteCustom
            Public Const WidthMM As Integer = 80
            Public Const HeightMM As Integer = 50
        End Class
        Public Class EtichetteCmQuadri
            Public Const LatoCortoMin As Integer = 20
            Public Const MargineALato As Integer = 5
            Public Const MargineSopra As Single = 2.5
            Public Const CmQuadriEsempio As Integer = 10
            Public Const QtaMin As Integer = 500
            Public Const QtaMax As Integer = 50000
        End Class
    End Class

    Public Class CategorieContabili
        Public Const MateriePrime As Integer = 14
    End Class

    Public Class ExtraDataKey
        Public Const OrientamentoEtichette As String = "OrientamentoEtichetta"
        Public Const AnimaInCm As String = "AnimaInCm"
    End Class

    Public Class Lavorazioni
        Public Const Taglio As Integer = 1
        Public Const StampaRealizzazione As Integer = 155
        Public Const CreazioneFustella As Integer = 61
        Public Const InserimentoNelSistema As Integer = 202
        Public Const TaglioAMisura As Integer = 203
        Public Const TaglioAMisuraOffset As Integer = 207
    End Class

    Public Class MassimaliPrezzi
        Public Const Fast As Decimal = 1000
        Public Const Normal As Decimal = 6000
    End Class

    Public Class MassimaliSpedizione

        'MASSIMALI PER CONTROLLO CONGRUENZA COLLI PESO SPEDIZIONI
        Public Const NumColliIndicativiFascia1 As Integer = 1
        Public Const NumColliIndicativiFascia2 As Integer = 1
        Public Const NumColliIndicativiFascia3 As Integer = 1
        Public Const NumColliIndicativiFascia4 As Integer = 2
        Public Const NumColliIndicativiFascia5 As Integer = 3
        Public Const NumColliIndicativiFascia6 As Integer = 6
        Public Const NumColliIndicativiFascia7 As Integer = 3

        'MASSIMALI PESO IMBALLAGGIO
        Public Const MaxPesoSingoloOrdineInImballaggio As Integer = 15 'definisce il peso massimo di un ordine in imballaggio perche possa essere imballato insieme ad altri, altrimenti lo inscatola da se.
        Public Const MaxPesoInteraConsegnaPerImballaggio As Integer = 15 'definisce il peso massimo di un intera consegna perche venga presa in considerazione per essere reinscatolata

    End Class

    Public Class CTP
        Public Const MarcatoreBlankPage As String = "$$BlankPage$$"
        Public Const MarcatoreRigaSegnatura As String = "$$RigaSegnatura$$"
    End Class

    Public Class Coupon
        Public Const ImportoCouponScontoPerRecensione As Decimal = 1
        Public Const GruppoCouponViscom2016 As Integer = 85
        Public Const GruppoCouponShopExpo2017 As Integer = 86
    End Class

    Public Class Barcode
        Public Const BarcodeFineCaricamentoColli As String = "800000000001"
        Public Const BarcodeChiudiScatolaERiapri As String = "800000000002"
    End Class

    Public Class Macchinari
        Public Const IdAnapurna As Integer = 38
        Public Const IdFlora As Integer = 46
        Public Const IdEpsonT7000 As Integer = 18
    End Class

    Public Class Web

        Public Const IdRilascio As Integer = 9999

        Public Shared ReadOnly Property CrawlersList As List(Of String)
            Get
                Dim Crawlers As New List(Of String)() From {
   "bot",
   "crawler",
   "spider",
   "80legs",
   "baidu",
   "yahoo! slurp",
   "ia_archiver",
   "mediapartners-google",
   "lwp-trivial",
   "nederland.zoek",
   "ahoy",
   "anthill",
   "appie",
   "arale",
   "araneo",
   "ariadne",
   "atn_worldwide",
   "atomz",
   "bjaaland",
   "ukonline",
   "calif",
   "combine",
   "cosmos",
   "cusco",
   "cyberspyder",
   "digger",
   "grabber",
   "downloadexpress",
   "ecollector",
   "ebiness",
   "esculapio",
   "esther",
   "felix ide",
   "hamahakki",
   "kit-fireball",
   "fouineur",
   "freecrawl",
   "desertrealm",
   "gcreep",
   "golem",
   "griffon",
   "gromit",
   "gulliver",
   "gulper",
   "whowhere",
   "havindex",
   "hotwired",
   "htdig",
   "ingrid",
   "informant",
   "inspectorwww",
   "iron33",
   "teoma",
   "ask jeeves",
   "jeeves",
   "image.kapsi.net",
   "kdd-explorer",
   "label-grabber",
   "larbin",
   "linkidator",
   "linkwalker",
   "lockon",
   "marvin",
   "mattie",
   "mediafox",
   "merzscope",
   "nec-meshexplorer",
   "udmsearch",
   "moget",
   "motor",
   "muncher",
   "muninn",
   "muscatferret",
   "mwdsearch",
   "sharp-info-agent",
   "webmechanic",
   "netscoop",
   "newscan-online",
   "objectssearch",
   "orbsearch",
   "packrat",
   "pageboy",
   "parasite",
   "patric",
   "pegasus",
   "phpdig",
   "piltdownman",
   "pimptrain",
   "plumtreewebaccessor",
   "getterrobo-plus",
   "raven",
   "roadrunner",
   "robbie",
   "robocrawl",
   "robofox",
   "webbandit",
   "scooter",
   "search-au",
   "searchprocess",
   "senrigan",
   "shagseeker",
   "site valet",
   "skymob",
   "slurp",
   "snooper",
   "speedy",
   "curl_image_client",
   "suke",
   "www.sygol.com",
   "tach_bw",
   "templeton",
   "titin",
   "topiclink",
   "udmsearch",
   "urlck",
   "valkyrie libwww-perl",
   "verticrawl",
   "victoria",
   "webscout",
   "voyager",
   "crawlpaper",
   "webcatcher",
   "t-h-u-n-d-e-r-s-t-o-n-e",
   "webmoose",
   "pagesinventory",
   "webquest",
   "webreaper",
   "webwalker",
   "winona",
   "occam",
   "robi",
   "fdse",
   "jobo",
   "rhcs",
   "gazz",
   "dwcp",
   "yeti",
   "fido",
   "wlm",
   "wolp",
   "wwwc",
   "xget",
   "legs",
   "curl",
   "webs",
   "wget",
   "sift",
   "cmc"
}
                Return Crawlers

            End Get
        End Property

    End Class

End Class
