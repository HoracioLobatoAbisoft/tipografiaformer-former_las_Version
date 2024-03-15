Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerLib
Imports System.IO
Imports System.Xml.Serialization
Imports System.Drawing

Public Class ProdottoInCarrello
    Implements IOrdineBox

    ' Private _UtenteConnesso As UtenteSito = Nothing
    Public Sub New() 'UtenteConnesso As UtenteSito)
        '_UtenteConnesso = UtenteConnesso

        Dim Rnd As New Random
        _NumOrd = UtenteConnesso.IdUtente & Rnd.Next(1000, 9999).ToString

    End Sub

    Public Property BufferSVG As String = String.Empty

    Public Property IdOmaggioRegola As Integer = 0

    Public ReadOnly Property Omaggio As Integer Implements IOrdineBox.Omaggio
        Get
            Return OrdineOmaggio
        End Get
    End Property

    Public ReadOnly Property PercPromo As Integer Implements IOrdineBox.Promo
        Get
            Return IdPromo
        End Get
    End Property

    Public ReadOnly Property IdOrdineInt As Integer Implements IOrdineBox.IdOrdineInt
        Get
            Return 0
        End Get
    End Property

    Public Property IdPromo As Integer = 0

    Protected ReadOnly Property UtenteConnesso As UtenteSito
        Get
            Dim U As UtenteSito = DirectCast(HttpContext.Current.Session("UtenteConnesso"), UtenteSito)

            Return U
        End Get
    End Property

    Private _NumOrd As String = ""

    Public ReadOnly Property NumOrd() As String
        Get
            Return _NumOrd
        End Get
    End Property

    Public ReadOnly Property IdRiferimentoOrdine As Integer Implements IOrdineBox.IdRiferimentoOrdine
        Get
            Return Convert.ToInt32(_NumOrd)
        End Get
    End Property

    Public ReadOnly Property IdProdotto As Integer Implements IOrdineBox.IdProdotto
        Get
            Return L.IdListinoBase
        End Get
    End Property

    Public Property Stato As Integer Implements IOrdineBox.StatoOrdine
        Get
            Return enStatoOrdine.InAttesaAllegati
        End Get
        Set(value As Integer)

        End Set
    End Property

    Public Property StatoStr As String Implements IOrdineBox.StatoStr
        Get
            Dim ris As String = String.Empty

            If Omaggio = enSiNo.Si Then
                ris = "OMAGGIO"
            Else
                ris = FormerEnumHelper.StatoOrdineString(enStatoOrdine.InAttesaAllegati)
            End If

            Return ris

        End Get
        Set(value As String)

        End Set
    End Property

    Public ReadOnly Property SchedaProdottoStr As String Implements IOrdineBox.SchedaProdotto
        Get
            Dim Ris As String = "/" & P.IdPrev & "/" & F.IdFormProd & "/" & TC.IdTipoCarta & "/" & C.IdColoreStampa & "/" & (L.faccmin / 2) & "/"
            Ris &= P.NomeInUrl & "_" & F.NomeInUrl & "_" & TC.NomeInUrl & "_" & C.NomeInUrl

            Return Ris
        End Get
    End Property

    Public ReadOnly Property IconaStato As String Implements IOrdineBox.IconaStato
        Get
            Return FormerEnumHelper.GetIconaStato(enStatoOrdine.InAttesaAllegati)
        End Get
    End Property
    Public ReadOnly Property IdConsegna As Integer? Implements IOrdineBox.IdConsegna
        Get
            Return IdConsegna
        End Get
    End Property
    Public ReadOnly Property ColoreStato As System.Drawing.Color
        Get
            Dim Ris As Drawing.Color
            If Omaggio = enSiNo.Si Then
                Ris = FormerColori.ColoreOrdineOmaggio
            Else
                Ris = FormerColori.GetColoreStatoOrdine(enStatoOrdine.InAttesaAllegati)
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property ColoreStatoHTML As String Implements IOrdineBox.ColoreStatoHTML
        Get
            Dim ris As String = String.Empty

            If Omaggio = enSiNo.Si Then
                ris = ColorTranslator.ToHtml(FormerColori.ColoreOrdineOmaggio)
            Else
                ris = FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.InAttesaAllegati)
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property BoxLavorazioni As List(Of String) Implements IOrdineBox.BoxLavorazioni
        Get
            Dim ris As New List(Of String)

            For Each L As LavorazioneW In LavorazioniIncluse

                If L.LavorazioneInterna = enSiNo.No Then ris.Add(L.Descrizione)

            Next

            Return ris

        End Get
    End Property

    'Public ReadOnly Property NomeFileOrd() As String
    '    Get
    '        Return _NumOrd & ".xml"
    '    End Get
    'End Property

    Public Property ExtraData As String = String.Empty

    Public ReadOnly Property ListinoBase As ListinoBaseW Implements IOrdineBox.ListinoBase
        Get
            Return L

        End Get
    End Property

    Public Property L As ListinoBaseW
    Public Property P As PreventivazioneW
    Public Property F As FormatoProdottoW
    Public Property TC As TipoCartaW
    Public Property C As ColoreStampaW
    Public Property Corriere As CorriereW
    Public Property Qta As Integer = 1
    Public Property LavorazioniIncluse As List(Of LavorazioneW)
    Public Property NFogli As Integer = 0
    Public Property NFogliVis As Integer = 0
    Public Property OrdineOmaggio As Integer = enSiNo.No

    Public Property OrientamentoScelto As Integer = enTipoOrientamento.NonSpecificato

    Public ReadOnly Property OrientamentoSelezionato As Integer Implements IOrdineBox.OrientamentoSelezionato
        Get
            Return OrientamentoScelto
        End Get
    End Property

    Public ReadOnly Property OrientamentoSelezionatoStr As String Implements IOrdineBox.OrientamentoSelezionatoStr
        Get
            Return FormerEnumHelper.OrientamentoStr(OrientamentoScelto)
        End Get
    End Property

    Public ReadOnly Property PrezzoCalcolatoNetto As Decimal
        Get
            Dim ris As Decimal = 0
            ris = PrezzoCalcolatoNettoOriginale - Sconto
            If ris < 0 Then ris = 0
            Return ris
        End Get
    End Property

    Public Property IdMacchinarioProduzione As Integer = 0

    Public Property PrezzoCalcolatoNettoOriginale As Decimal
    Private _Sconto As Decimal = 0

    Public ReadOnly Property Sconto As Decimal 'Single
        Get
            Return _Sconto
        End Get
    End Property

    Public Property Peso As Integer = 0
    Public Property Colli As Integer = 0
    Public Property Quando As String
    Public Property ConVerificaFile As Boolean = False
    Public Property IdIndirizzoSped As Integer = 0

    Public Property IdCoupon As Integer = 0

    Private _CodiceCouponApplicato As String = String.Empty
    Public ReadOnly Property CodiceCouponApplicato As String
        Get
            Return _CodiceCouponApplicato
        End Get
    End Property

    Public Sub ApplicaPromo(P As PromoW)
        '_Sconto = 5
    End Sub

    Public Function ApplicaCoupon(C As CouponW) As Integer
        Dim ris As Integer = 0
        'ritorna l'id del coupon usato se riesce ad applicarlo
        If IdPromo = 0 Then ' COUPON APPLICABILE SOLO SU LISTINI BASE NON IN PROMO
            Dim CheckOk As Boolean = True
            If C.IdListinoBase Then
                If ListinoBase.IdListinoBase <> C.IdListinoBase Then
                    CheckOk = False
                End If
            End If
            If C.QtaSpecifica Then
                If Qta <> C.QtaSpecifica Then
                    CheckOk = False
                End If
            End If

            If C.RiservatoATipoUtente <> enTipoRubrica.Tutto AndAlso UtenteConnesso.Utente.TipoRub <> C.RiservatoATipoUtente Then
                CheckOk = False
            End If

            If CheckOk Then
                IdCoupon = C.IdCoupon
                If C.Percentuale Then
                    'qui e' una percentuale
                    _Sconto = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(((PrezzoCalcolatoNettoOriginale * C.Percentuale) / 100), 2)
                Else
                    'qui è un importo fisso
                    _Sconto = C.ImportoFisso
                End If
                _CodiceCouponApplicato = C.Codice
                ris = IdCoupon
            End If
        End If

        Return ris
    End Function

    Private _Note As String = String.Empty
    Public Property Note As String
        Get
            Return HttpContext.Current.Server.HtmlDecode(_Note)
        End Get
        Set(value As String)
            _Note = HttpContext.Current.Server.HtmlEncode(value)
        End Set
    End Property

    Private _NomeLavoro As String = String.Empty
    Public Property NomeLavoro As String
        Get
            Return HttpContext.Current.Server.HtmlDecode(_NomeLavoro)
        End Get
        Set(value As String)
            _NomeLavoro = HttpContext.Current.Server.HtmlEncode(value)
        End Set
    End Property

    Public ReadOnly Property NomeLavoroStr As String Implements IOrdineBox.NomeLavoro
        Get
            Return NomeLavoro
        End Get
    End Property

    Public Property Altezza As Integer = 0
    Public Property Larghezza As Integer = 0
    Public Property Profondita As Integer = 0


    Public ReadOnly Property AltezzaI As Integer Implements IOrdineBox.Altezza
        Get
            Return Altezza
        End Get
    End Property
    Public ReadOnly Property LarghezzaI As Integer Implements IOrdineBox.Base
        Get
            Return Larghezza
        End Get
    End Property
    Public ReadOnly Property ProfonditaI As Integer Implements IOrdineBox.Profondita
        Get
            Return Profondita
        End Get
    End Property

    Public Property IdTipoFustella As Integer = 0

    Public ReadOnly Property IdTipoFustellaI As Integer Implements IOrdineBox.IdTipoFustella
        Get
            Return IdTipoFustella
        End Get
    End Property


    Public Property PathSchedaProdotto As String

    Public ReadOnly Property PesoVolumetrico() As Integer
        Get
            Dim Ris As Integer = 0

            Dim AltezzaCalcolo As Single = 0
            Dim LarghezzaCalcolo As Single = 0
            Dim ProfonditaCalcolo As Single = 0

            If L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then

                Dim LunghezzaTotaleCm As Integer = 0
                Dim DiametroBobina As Integer = 0
                Dim LatoFisso As Integer = (L.LatoFissoRiferimento(Altezza, Larghezza).LatoFissoPrincipale * 10) '(L.FormatoCarta.Larghezza * 10)
                Dim NumeroPezziScelti As Integer = Qta

                LunghezzaTotaleCm = MgrCalcoliTecnici.CalcolaLunghezzaTotaleCm(Altezza,
                                                                            Larghezza,
                                                                            OrientamentoScelto,
                                                                            LatoFisso,
                                                                            NumeroPezziScelti)

                Dim AnimaSceltaCm As Integer = FormerConst.ProdottiCaratteristiche.AnimaDefaultBobineRotoliCm
                'qui devo vedere che ha scelto come anima il cliente 




                DiametroBobina = MgrCalcoliTecnici.CalcolaDiametroBobinaCm(LunghezzaTotaleCm,
                                                                                           AnimaSceltaCm,
                                                                                           L.TipoCarta.Spessore)

                AltezzaCalcolo = DiametroBobina
                LarghezzaCalcolo = L.LatoFissoRiferimento.LatoFissoPrincipale 'L.FormatoCarta.Larghezza
                ProfonditaCalcolo = DiametroBobina
            End If

            If AltezzaCalcolo = 0 Or LarghezzaCalcolo = 0 Or ProfonditaCalcolo = 0 Then
                AltezzaCalcolo = L.FormatoProdotto.Fc.Altezza + 3
                LarghezzaCalcolo = L.LatoFissoRiferimento.LatoFissoPrincipale + 3 'L.FormatoProdotto.Fc.Larghezza + 3
                ProfonditaCalcolo = L.TipoCarta.CalcolaSpessoreCM(Qta)
            End If

            If L.Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
                If L.IdModelloCubetto Then
                    Using M As New ModelloCubettoW
                        M.Read(L.IdModelloCubetto)
                        AltezzaCalcolo = M.Lunghezza / 10
                        LarghezzaCalcolo = M.Larghezza / 10
                        ProfonditaCalcolo = M.Profondita / 10
                    End Using

                    Ris = MgrCorriere.CalcolaPesoVolumetrico(AltezzaCalcolo, LarghezzaCalcolo, ProfonditaCalcolo)
                    Ris = Ris * Colli
                End If
            End If

            If Ris = 0 Then Ris = MgrCorriere.CalcolaPesoVolumetrico(AltezzaCalcolo, LarghezzaCalcolo, ProfonditaCalcolo)

            Return Ris

        End Get
    End Property

    Public ReadOnly Property BoxImgRif As String Implements IOrdineBox.BoxImgRif
        Get
            Dim Ris As String = String.Empty
            Select Case L.PrendiIcoDa
                Case enPrendiIcoDa.FormatoProdotto
                    Ris = L.FormatoProdotto.ImgRif
                Case enPrendiIcoDa.ColoreDiStampa
                    Ris = L.ColoreStampa.imgrif
                Case enPrendiIcoDa.Preventivazione
                    Ris = P.ImgRif
                Case enPrendiIcoDa.TipoCarta
                    Ris = L.TipoCarta.ImgRif
            End Select
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SupportoStr As String Implements IOrdineBox.SupportoStr
        Get
            Return TC.RiassuntoCarrello
        End Get
    End Property

    Public ReadOnly Property BoxTitolo As String Implements IOrdineBox.BoxTitolo
        Get
            Dim ris As String = String.Empty
            ris = P.Descrizione
            Return ris
        End Get
    End Property

    Public ReadOnly Property PrezzoCalcolatoNettoStr As String Implements IOrdineBox.ImportoNettoStr
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(PrezzoCalcolatoNetto)
        End Get
    End Property

    Public ReadOnly Property PrezzoCalcolatoNettoOriginaleStr As String Implements IOrdineBox.ImportoNettoOrigStr
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(PrezzoCalcolatoNettoOriginale)
        End Get
    End Property

    Public ReadOnly Property QtaStr As String Implements IOrdineBox.QtaStr
        Get
            Return FormerHelper.Stringhe.FormattaNumero(Qta)
        End Get
    End Property

    Public ReadOnly Property PathTemplate As String Implements IOrdineBox.PathTemplate
        Get
            Return F.PdfTemplate
        End Get
    End Property

    Public Property IdOrdineInserito As Integer = 0

    Public ReadOnly Property IdOrdineWeb As Integer Implements IOrdineBox.IdOrdineWeb
        Get
            Return 0
        End Get
    End Property

    Public ReadOnly Property DimensioniStr As String Implements IOrdineBox.DimensioniStr
        Get
            Dim Ris As String = String.Empty

            Dim Etichetta As String = FormerEnumHelper.TipoUnitaDiMisura(L.TipoUnitaMisuraInInput)

            If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse L.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                'qui ci va anche altezza e larghezza
                Ris = " (" & Larghezza & "B x " & Altezza & "A " & Etichetta & ")"
            ElseIf L.Preventivazione.IdPluginToUse = enPluginOnline.Packaging AndAlso L.Preventivazione.IdFunzionePack <> 0 Then
                Ris = " (" & Larghezza & "B x " & Altezza & "A x " & Profondita & "P " & Etichetta & " Chiuso)"
            ElseIf L.Preventivazione.IdPluginToUse = enPluginOnline.Etichette Then
                Ris = " (" & Larghezza & "B x " & Altezza & "A " & Etichetta & ")"
            ElseIf L.Preventivazione.IdPluginToUse = enPluginOnline.EtichetteCm Then
                Ris = " (" & Larghezza & "B x " & Altezza & "A " & Etichetta & ")"
            ElseIf L.AllowCustomSize = enSiNo.Si OrElse L.idGruppoLogico Then
                If (Larghezza <> 0 And Larghezza <> F.Larghezza) OrElse (Altezza <> 0 And Altezza <> F.Lunghezza) Then

                    Ris = " (" & Larghezza & "L x " & Altezza & "A " & Etichetta & ")"
                Else
                    Ris = F.FormatoCartaStr
                End If
            Else
                Ris = F.FormatoCartaStr
            End If



            Return Ris
        End Get
    End Property

    Public ReadOnly Property ColoriDiStampaStr As String Implements IOrdineBox.ColoriStampaStr
        Get
            Return C.Descrizione
        End Get
    End Property

    Public ReadOnly Property ColliStr As String Implements IOrdineBox.ColliStr
        Get
            Return Colli
        End Get
    End Property

    Public ReadOnly Property PesoStr As String Implements IOrdineBox.PesoStr
        Get
            Dim Ris As String = Peso
            If PesoVolumetrico > Peso Then Ris = PesoVolumetrico
            Return Ris
        End Get
    End Property

    Public ReadOnly Property CorriereStr As String Implements IOrdineBox.CorriereStr
        Get
            Return MgrMetodiConsegna.GetMetodoConsegna(Corriere).Descrizione
        End Get
    End Property

    Public ReadOnly Property AnteprimaWeb As String Implements IOrdineBox.AnteprimaWeb
        Get
            Return String.Empty
        End Get
    End Property

    Public ReadOnly Property NOrdineStr As String Implements IOrdineBox.NOrdineStr
        Get
            Dim Ris As String = "-"
            Return Ris
        End Get
    End Property

    Public ReadOnly Property RiassuntoBox As String
        Get
            Dim ris As String = Qta & " " & L.Nome

            If ris.Length > 35 Then ris = ris.Substring(0, 34) & "..."

            Return ris
        End Get
    End Property

    Public ReadOnly Property RiassuntoCarrello As String Implements IOrdineBox.NomeProdotto
        Get
            Dim Dimensioni As String = String.Empty
            If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                Dimensioni = "(" & Altezza & "x" & Larghezza & " cm)"
            End If

            Dim ris As String = FormerHelper.Stringhe.FormattaNumero(Qta) & " " & L.Nome & IIf(Dimensioni.Length, " " & Dimensioni, "") '& ", Ordine " & NumOrd

            Return ris
        End Get
    End Property

    Public ReadOnly Property DataPrevProduzione As Date
        Get
            'qui ci va della logica 
            'se l'ordine e' in stato da inviare 
            Dim Ris As Date = Date.MinValue

            'qui la devo calcolare 
            Dim l As New List(Of ILavorazioneB)
            For Each singLav As LavorazioneW In LavorazioniIncluse
                l.Add(singLav)
            Next

            Dim DateConsegna As RisDataConsegna = MgrDataConsegna.CalcolaDateConsegna(P, Corriere, l)
            Select Case TipoConsegna
                Case enTipoConsegna.Fast
                    Ris = DateConsegna.DataFastProduzione
                Case enTipoConsegna.Normale
                    Ris = DateConsegna.DataNormaleProduzione
                Case enTipoConsegna.Slow
                    Ris = DateConsegna.DataSlowProduzione
            End Select
            Return Ris
        End Get
    End Property

    Public ReadOnly Property NFogliVisStr As String Implements IOrdineBox.NFogliVisStr
        Get
            Return NFogliVis
        End Get
    End Property

    Public ReadOnly Property DataConsegna As Date
        Get
            Dim DataCons As Date = Date.MinValue
            If Quando.Length Then
                Dim Giorno As String = Quando.Substring(1, 2)
                Dim Mese As String = Quando.Substring(3, 2)
                Dim Anno As String = Quando.Substring(5, 4)

                DataCons = New Date(Anno, Mese, Giorno)
            End If

            Return DataCons

        End Get
    End Property

    Public ReadOnly Property DataConsegnaStr As String Implements IOrdineBox.DataConsegnaStr
        Get
            Dim ris As String = StrConv(DataConsegna.ToString("dddd dd/MM/yyyy"), vbProperCase)
            Return ris
        End Get
    End Property

    Public ReadOnly Property QuandoMomento As String
        Get
            Dim ris As String = "pomeriggio"

            If Corriere.IdCorriere = enCorriere.RitiroCliente And DataConsegna.DayOfWeek = DayOfWeek.Saturday Then ris = "mattina"

            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoConsegna As enTipoConsegna
        Get
            Dim Ris As Integer = enTipoConsegna.Normale
            If Quando.Substring(0, 1) = "F" Then
                Ris = enTipoConsegna.Fast
            ElseIf Quando.Substring(0, 1) = "S" Then
                Ris = enTipoConsegna.Slow
            End If
            Return Ris
        End Get
    End Property

    'Public ReadOnly Property SpeseDiTrasporto As Single
    '    Get
    '        Dim ris As Single = 0

    '        'calcolo le spese di trasporto
    '        Dim Mgr As New MGRCorriere

    '        Dim Altezza As Single = L.FormatoProdotto.Fc.Altezza + 3
    '        Dim Larghezza As Single = L.FormatoProdotto.Fc.Larghezza + 3
    '        Dim Profondita As Single = L.TipoCarta.CalcolaSpessoreCM(Qta)

    '        ris = Mgr.CalcolaTariffa(Corriere, _
    '                                  Altezza, _
    '                                   Larghezza, _
    '                                   Profondita, _
    '                                   Peso, _
    '                                   PrezzoCalcolatoNetto)

    '        Return ris
    '    End Get
    'End Property

    Public ReadOnly Property TotaleNetto As Decimal 'single 
        Get
            Return PrezzoCalcolatoNetto '+ SpeseDiTrasporto
        End Get
    End Property

    Public ReadOnly Property TotaleNettoStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleNetto)
        End Get
    End Property

    Public ReadOnly Property TotaleIvaStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleIva)
        End Get
    End Property

    Public ReadOnly Property TotaleOrdineStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(TotaleOrdine)
        End Get
    End Property

    Public ReadOnly Property TotaleIva As Decimal 'single
        Get
            Dim ris As Decimal = 0
            ris = FormerHelper.Finanziarie.CalcolaIva(TotaleNetto)
            'Return Math.Round(((TotaleNetto * FormerWebApp.GetPercIva) / 100), 2)
            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleOrdine As Decimal
        Get
            Return TotaleNetto + TotaleIva
        End Get
    End Property

    Public ReadOnly Property ElencoLavorazioni As String
        Get

            Dim Ris As String = String.Empty
            Dim ListaId As String = String.Empty
            For Each L As LavorazioneW In LavorazioniIncluse
                If L.IdLavoro Then
                    ListaId &= L.IdLavoro & ","
                End If
            Next

            If ListaId.Length Then
                ListaId = "(" & ListaId.TrimEnd(",") & ")"
                Using mgr As New LavorazSuPreventivazWDAO
                    Dim lP As List(Of LavorazSuPreventivazW) = mgr.FindAll("Ordine",
                                                                            New LUNA.LunaSearchParameter("IdListinoBase", L.IdListinoBase),
                                                                            New LUNA.LunaSearchParameter("IdLavoro", ListaId, " IN "))

                    For Each singlP As LavorazSuPreventivazW In lP
                        Ris &= singlP.IdLavoro & ","
                    Next

                End Using
            End If

            Ris = Ris.TrimEnd(",")

            Return Ris
        End Get
    End Property

    Private _EmailRiferimento As String = ""
    Public Property EmailRiferimento() As String
        Get
            Return _EmailRiferimento
        End Get
        Set(value As String)
            _EmailRiferimento = value
        End Set
    End Property

    Public Preventivo As Boolean = False

    Public Anteprima As New FileAllegato
    Public Sorgente1 As New FileAllegato
    Public Sorgente2 As New FileAllegato
    Public Property Mq As Single = 0
    Public Sub ResetCoupon()
        _Sconto = 0
        IdCoupon = 0
        _CodiceCouponApplicato = String.Empty
    End Sub
    Public Sub Salva(C As Consegna)

        Dim O As New OrdineWeb

        O.Altezza = Altezza
        O.Larghezza = Larghezza
        O.Profondita = Profondita
        O.IdTipoFustella = IdTipoFustella
        O.IdListinoBase = L.IdListinoBase
        O.IdCorriere = C.IdCorriere
        O.IdCons = C.IdConsegna
        O.Peso = Peso
        O.NumeroColli = Colli
        O.Lavorazioni = ElencoLavorazioni
        O.IdUt = UtenteConnesso.IdUtente
        O.Annotazioni = NoteOrd
        O.DataIns = Now
        O.DataPrevConsegna = DataConsegna
        O.IdIndirizzo = C.IdIndirizzo
        O.Mq = Mq
        O.Nfogli = NFogli
        O.Preventivo = Preventivo
        O.PrezzoCalcolatoNetto = PrezzoCalcolatoNettoOriginale

        O.IdMacchinarioProduzioneUtilizzato = IdMacchinarioProduzione

        'qui vado a ricontrollare il coupon
        If IdCoupon Then
            Dim OkCoupon As Boolean = False
            Using Coup As New CouponW
                Coup.Read(IdCoupon)
                Dim TotCoupon As Integer = 0
                Using mgr As New CouponWDAO
                    TotCoupon = mgr.TotaleCouponUtilizzati(IdCoupon, UtenteConnesso.IdUtente)
                End Using
                If TotCoupon < Coup.MaxVolte Then
                    OkCoupon = True
                End If
            End Using

            If OkCoupon Then
                O.Sconto = Sconto
                O.IdCoupon = IdCoupon

                'salvo il log del coupon
                Using cl As New CouponLog
                    cl.IdCoupon = IdCoupon
                    cl.IdUt = UtenteConnesso.IdUtente
                    cl.Quando = Now
                    cl.Save()
                End Using
            Else
                O.Sconto = 0
                O.IdCoupon = 0
                ResetCoupon()
            End If
        Else
            O.Sconto = Sconto
        End If

        O.Qta = Qta
        O.NomeLavoro = NomeLavoro
        O.OrdineInOmaggio = Omaggio
        O.IdPromo = IdPromo

        If O.Nfogli > 2 Then
            O.TipoRetro = enTipoRetro.RetroNelFileFronte
        End If

        If O.OrdineInOmaggio = enSiNo.Si Then
            O.Stato = enStatoOrdine.Preinserito
        Else
            If C.IdStatoConsegna = enStatoConsegna.InAttesaDiPagamento Then
                O.Stato = enStatoOrdine.InAttesaPagamento
            Else
                If O.L.NoAttachFile = enSiNo.Si Then
                    O.Stato = enStatoOrdine.Preinserito
                Else
                    O.Stato = enStatoOrdine.InAttesaAllegati
                End If
            End If
        End If
        O.Orientamento = OrientamentoScelto

        O.StatoWeb = enStato.Attivo
        O.TipoConsegna = TipoConsegna
        O.ExtraData = ExtraData
        O.OrdineWeb = True

        O.Save()
        IdOrdineInserito = O.IdOrdine

        ''VADO A SALVARE IL COUPON SE PREVISTO 
        'If UtenteConnesso.IsAdmin Then 'TODO: RIATTIVARE = False Then
        '    'solo se non e' un uno di noi
        '    If L.Preventivazione.PercCoupon Then
        '        'se c'e' una percentuale di coupon vado a inserire il nuovo coupon per questo utente
        '        Dim CodiceCoupon As String = String.Empty
        '        Using mgr As New CouponWDAO
        '            CodiceCoupon = mgr.GetCodiceCoupon(O.L.Preventivazione.Prefisso.ToUpper, UtenteConnesso.IdUtente)
        '        End Using
        '        Dim ggValid As Integer = 30
        '        Dim ImportoCoup As Single = Math.Round(((PrezzoCalcolatoNettoOriginale * L.Preventivazione.PercCoupon) / 100), 2)
        '        If UtenteConnesso.Tipo = enTipoRubrica.Cliente Then ggValid = 90
        '        Dim Coup As New CouponW
        '        Coup.VisibileOnline = enSiNo.No
        '        Coup.Riservato = UtenteConnesso.IdUtente
        '        Coup.RiservatoATipoUtente = UtenteConnesso.Tipo
        '        Coup.QtaSpecifica = Qta
        '        Coup.IdListinoBase = L.IdListinoBase
        '        Coup.DataInizioValidita = Now
        '        Coup.DataFineValidita = Now.AddDays(ggValid)
        '        Coup.MaxVolte = 1
        '        Coup.Stato = enStato.Attivo
        '        Coup.ImportoFisso = ImportoCoup
        '        Coup.Nome = "Coupon automatico Rif. Lavoro " & O.IdOrdine
        '        Coup.Codice = CodiceCoupon
        '        Coup.IdLavoro = IdOrdineInserito
        '        Coup.Save()
        '        'TODO: INVIARE MAIL DEL COUPON
        '    End If
        'End If
        'salvo una copia del lavoro a futura memoria
        Try
            Dim PathOrdine As String = FormerWebApp.PathOrdini & IdOrdineInserito & "\"

            If Directory.Exists(PathOrdine) = False Then
                Directory.CreateDirectory(PathOrdine)
            End If

            PathOrdine &= IdOrdineInserito & ".xml"

            FormerSerializator.SerializeObjectToFile(O, PathOrdine)

            'Using w As New StreamWriter(PathOrdine)
            '    w.Write(buffer)
            'End Using

            'Using mgr As New OrdiniWebDAO
            '    mgr.SaveSerialize(O, PathOrdine)
            'End Using

        Catch ex As Exception

            FormerLib.FormerHelper.Mail.InviaMail("Errore serializzazione Ordine", ex.Message, FormerConst.EmailAssistenzaTecnica)

        End Try


    End Sub

    Public ReadOnly Property NoteOrd As String Implements IOrdineBox.NoteOrd
        Get
            Return Note
        End Get
    End Property

    Private ReadOnly Property IOrdineBox_IdCoupon As Integer Implements IOrdineBox.IdCoupon
        Get
            Return IdCoupon
        End Get
    End Property

    Public ReadOnly Property ImportoTotaleScontiStr As String Implements IOrdineBox.ImportoTotaleScontiStr
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Sconto)
        End Get
    End Property
End Class
