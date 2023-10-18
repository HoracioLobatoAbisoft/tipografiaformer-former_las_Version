#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region

Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogicInterface


''' <summary>
'''Entity Class for table T_rubrica
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class VoceRubrica
    Inherits _VoceRubrica
    Implements IVoceRubrica, IVoceRubricaG, ICloneable

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Private _SostitutaDa As VoceRubrica = Nothing
    Public ReadOnly Property SostituitaDa As VoceRubrica
        Get
            If _SostitutaDa Is Nothing Then
                If IdRub Then
                    Using mgr As New VociRubricaDAO
                        Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LSO() With {.Top = 1},
                                                                    New LUNA.LSP(LFM.VoceRubrica.IdRubricaLinked, IdRub))
                        If l.Count Then
                            _SostitutaDa = l(0)
                        End If
                    End Using
                End If

            End If

            Return _SostitutaDa
        End Get
    End Property

    Private _Sostituisce As VoceRubrica = Nothing
    Public ReadOnly Property Sostituisce As VoceRubrica
        Get
            If IdRubricaLinked Then
                If _Sostituisce Is Nothing Then
                    Using r As New VoceRubrica
                        r.Read(IdRubricaLinked)
                        _Sostituisce = r
                    End Using
                End If
            End If

            Return _Sostituisce
        End Get
    End Property

    Public ReadOnly Property ScopertoMaxStr As String
        Get
            Dim ris As String = "-"

            If ScopertoMax <> 0 Then
                ris = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ScopertoMax)
            End If
            Return ris
        End Get
    End Property

    Private _ScopertoComplessivo As Decimal = -1
    Public ReadOnly Property ScopertoComplessivo As Decimal
        Get
            If _ScopertoComplessivo = -1 Then
                'If ScopertoMax Then

                _ScopertoComplessivo = MgrSituazioneCliente.GetSituazioneCliente(IdRub).TotaleScopertoComplessivo

                'Else
                '_ScopertoComplessivo = 0
                'End If
            End If
            Return _ScopertoComplessivo
        End Get
    End Property

    Public ReadOnly Property ScopertoComplessivoStr As String
        Get
            Dim ris As String = "-"

            If ScopertoComplessivo <> 0 Then
                ris = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ScopertoComplessivo)
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property IntestazioneBloccataLogicamente As Boolean
        Get
            Dim ris As Boolean = False

            'If Piva.Length <> 0 OrElse CodFisc.Length <> 0 Then
            '    Using mgr As New RicaviDAO
            '        Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.IdRub, IdRub),
            '                                               New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, enTipoDocumento.Preventivo, "<>"))
            '        If l.Count Then
            '            ris = True
            '        End If
            '    End Using
            'End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property Fatturabile As String
        Get
            Dim ris As String = String.Empty

            If Piva.Length Then
                If Piva = FormerConst.Fiscali.PartitaIvaNonDisponibile Then
                    ris &= "Partita IVA non valida" & ControlChars.NewLine
                ElseIf FormerHelper.Finanziarie.CheckPartitaIva(Piva, PrefissoPiva) = False Then
                    ris &= "Partita IVA non valida" & ControlChars.NewLine
                End If
                'If Pec.Length = 0 AndAlso CodiceSDI.Length = 0 Then
                '    ris &= "PEC e Codice SDI mancanti" & ControlChars.NewLine
                'End If
            Else
                If CodFisc.Length Then
                    If FormerHelper.Finanziarie.CheckCodiceFiscale(CodFisc, PrefissoPiva) = False Then
                        ris &= "Codice Fiscale non valido" & ControlChars.NewLine
                    End If
                Else
                    ris &= "Codice Fiscale e Partita Iva Non Presenti" & ControlChars.NewLine
                End If
            End If

            If Pec.Trim.Length > 0 AndAlso FormerHelper.Mail.IsValidEmailAddress(Pec.Trim) = False Then
                ris &= "PEC non valida" & ControlChars.NewLine
            End If

            If EsigibilitaIva = enEsigibilitaIVA.SplitPayment And CodiceSDI.Length <> 6 Then
                ris &= "Codice SDI non valido" & ControlChars.NewLine
            Else
                If EsigibilitaIva <> enEsigibilitaIVA.SplitPayment AndAlso
                    CodiceSDI.Length > 0 AndAlso
                    CodiceSDI.Length <> 7 Then
                    ris &= "Codice SDI non valido" & ControlChars.NewLine
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property CheckDatiFiscaliStr As String
        Get
            Dim ris As String = String.Empty

            If Fatturabile.Length Then
                ris = "NO"
            Else
                ris = "SI"
            End If

            'If ris = "NO" Then
            '    If NoCheckDatiFisc = enSiNo.Si Then
            '        ris &= " (FORZATO)"
            '    End If
            'End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property EmissioneDocFiscStr As String
        Get
            Dim ris As String = "SI"

            If StampaAutomaticaDocumenti <> enSiNo.Si Then
                ris = "NO"
            End If

            Return ris

        End Get
    End Property


    Public ReadOnly Property IdRubRif As Integer Implements IVoceRubricaG.IdRubRif
        Get
            Return IdRub
        End Get
    End Property

    Public Property DataUltimoInvioNewsletter As Date Implements IVoceRubricaG.DataUltimoInvioNewsletter

    Public ReadOnly Property IdRubG As Integer Implements IVoceRubricaG.IdRubG
        Get
            Dim Ris As Integer = 0

            Using mgr As New VociRubGDAO
                Dim voce As VoceRubG = mgr.Find(New LUNA.LunaSearchParameter("IdRub", IdRub))
                If voce Is Nothing Then
                    voce = New VoceRubG
                    voce.IdRub = IdRub
                    voce.Save()
                End If
                Ris = voce.IdRubG
            End Using

            Return Ris
        End Get
    End Property

    Public ReadOnly Property DefaultIndirizzo As Indirizzo
        Get
            Dim Ris As Indirizzo = Nothing
            Using Mgr As New IndirizziDAO
                Dim lst As List(Of Indirizzo) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "citta"},
                                                            New LUNA.LunaSearchParameter("IdRubrica", IdRub),
                                                            New LUNA.LunaSearchParameter("Status", CInt(enStato.Attivo)))
                Dim IndPred As Indirizzo = lst.Find(Function(x) x.Predefinito = True)
                If Not IndPred Is Nothing Then
                    Ris = IndPred
                End If
            End Using

            If Ris Is Nothing Then
                Ris = New Indirizzo
                Ris.IdComune = IdComune
                Ris.IdProvincia = IdProvincia
                Ris.Destinatario = RagSocNome
                Ris.Citta = Citta
                Ris.Cap = CAP
                Ris.IdRubrica = IdRub
                Ris.Indirizzo = Indirizzo
                Ris.IdNazione = IdNazione
            End If

            Return Ris
        End Get
    End Property

    Public ReadOnly Property Ordini As List(Of Ordine)
        Get
            Dim ris As List(Of Ordine) = Nothing
            Using mgr As New OrdiniDAO
                ris = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", IdRub))
            End Using
            Return ris
        End Get
    End Property

    Public ReadOnly Property DefaultCAP As String
        Get
            Dim ris As String = CAP

            Using Mgr As New IndirizziDAO
                Dim lst As List(Of Indirizzo) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "citta"},
                                                            New LUNA.LunaSearchParameter("IdRubrica", IdRub),
                                                            New LUNA.LunaSearchParameter("Status", CInt(enStato.Attivo)))
                Dim IndPred As Indirizzo = lst.Find(Function(x) x.Predefinito = True)
                If Not IndPred Is Nothing Then
                    ris = IndPred.Cap
                End If
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property ProvenienzaVoce As String Implements IVoceRubricaG.ProvenienzaVoce
        Get
            Return "R"
        End Get
    End Property

    Public ReadOnly Property ProvenienzaVoceExt As String Implements IVoceRubricaG.ProvenienzaVoceExt
        Get
            Return "Rubrica"
        End Get
    End Property

    Public ReadOnly Property NominativoG As String Implements IVoceRubricaG.NominativoG
        Get
            Return RagSocNome
        End Get
    End Property

    Public ReadOnly Property NomeDiBattesimo As String Implements IVoceRubricaG.NomeDiBattesimo
        Get
            Return Nome
        End Get
    End Property

    Public ReadOnly Property IdCategoriaMarketing As Integer Implements IVoceRubricaG.IdCategoriaMarketing
        Get
            Return IdCategoria
        End Get
    End Property

    Public ReadOnly Property DataInserimento As Date Implements IVoceRubricaG.DataInserimento
        Get
            Return DataIns
        End Get
    End Property

    Public ReadOnly Property TipoG As Integer Implements IVoceRubricaG.Tipo
        Get
            Return Tipo
        End Get
    End Property

    Public ReadOnly Property IndirizzoG As String Implements IVoceRubricaG.Indirizzo
        Get
            Return Indirizzo
        End Get
    End Property

    Public ReadOnly Property CittaG As String Implements IVoceRubricaG.Citta
        Get
            Return Citta
        End Get
    End Property

    Public ReadOnly Property CAPG As String Implements IVoceRubricaG.Cap
        Get
            Return CAP
        End Get
    End Property

    Public ReadOnly Property EmailG As String Implements IVoceRubricaG.EmailG
        Get
            Return Email
        End Get
    End Property

    Public ReadOnly Property IdCorriereG As Integer Implements IVoceRubricaG.IdCorrierePredefinito
        Get
            Return IdCorriere
        End Get
    End Property

    Public ReadOnly Property SorgenteG As String Implements IVoceRubricaG.Sorgente
        Get
            Return Sorgente
        End Get
    End Property

    Public ReadOnly Property ListaOrdini As List(Of Ordine) Implements IVoceRubricaG.ListaOrdini
        Get
            Dim ris As New List(Of Ordine)

            Using mgr As New OrdiniDAO
                ris.AddRange(mgr.Lista(,,,,,,,,,,, IdRub))
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property PivaEx As String
        Get
            Dim Ris As String = String.Empty

            If Piva.Length Then
                Ris = PrefissoPiva.ToUpper & Piva
            End If

            Return Ris

        End Get
    End Property

    Public ReadOnly Property SpesaComplessivaNelPeriodo(Periodo As enPeriodoRiferimento) As Integer Implements IVoceRubricaG.SpesaComplessivaNelPeriodo
        Get
            Dim Ris As Integer = 0

            'mi arriva un periodo e calcolo quanto ha speso

            Using mgr As New OrdiniDAO

                Ris = mgr.ImportoTotaleOrdiniNelPeriodo(IdRub, Periodo)

            End Using

            Return Ris
        End Get
    End Property

    Public ReadOnly Property HannoAcquistatoAlmenoUnaVoltaUn(IdPreventivazione As Integer) As Boolean Implements IVoceRubricaG.HannoAcquistatoAlmenoUnaVoltaUn
        Get
            Dim ris As Boolean = False

            Using mgr As New PreventivazioniDAO
                Dim Count As Integer = mgr.NumeroOrdiniByIdRub(IdRub, IdPreventivazione)
                If Count Then ris = True
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property NonHannoMaiAcquistatoUn(IdPreventivazione As Integer) As Boolean Implements IVoceRubricaG.NonHannoMaiAcquistatoUn
        Get
            Dim ris As Boolean = False

            Using mgr As New PreventivazioniDAO
                Dim Count As Integer = mgr.NumeroOrdiniByIdRub(IdRub, IdPreventivazione)
                If Count = 0 Then ris = True
            End Using

            Return ris
        End Get
    End Property



    Public ReadOnly Property NonHannoMaiSpeso As Boolean Implements IVoceRubricaG.NonHannoMaiSpeso
        Get
            Dim ris As Boolean = False
            Using mgr As New OrdiniDAO
                Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", IdRub))
                If l.Count = 0 Then ris = True
            End Using
            Return ris
        End Get
    End Property

    Public ReadOnly Property TagG As String Implements IVoceRubricaG.Tag
        Get
            Return tag
        End Get
    End Property

    Public ReadOnly Property TipoVoce As String
        Get
            Dim Ris As String = ""

            Ris = FormerLib.FormerEnum.FormerEnumHelper.TipoRubricaStr(_Tipo, IsFornitore)

            Return Ris
        End Get
    End Property

    Private _Categoria As CatRubrMarketing
    Public Property Categoria As CatRubrMarketing
        Get
            If _Categoria Is Nothing Then
                _Categoria = New CatRubrMarketing
                _Categoria.Read(IdCategoria)
            End If
            Return _Categoria
        End Get
        Set(value As CatRubrMarketing)
            _Categoria = value
        End Set
    End Property

    Private _Localita As ComuneInElenco = Nothing
    Public ReadOnly Property Localita As ComuneInElenco
        Get
            If _Localita Is Nothing Then
                _Localita = New ComuneInElenco
                If IdComune Then _Localita.Read(IdComune)
            End If
            Return _Localita
        End Get
    End Property

    Private _nazione As Nazione = Nothing
    Public ReadOnly Property Nazione As Nazione
        Get
            _nazione = MgrNazioni.GetLista().Find(Function(x) x.IdNazione = IdNazione)
            Return _nazione
        End Get
    End Property

    Public ReadOnly Property IndirizzoRegistrazione As String
        Get
            Dim ris As String = String.Empty
            ris = "(REG) " & Indirizzo & " - " & CAP & " " & Citta & " (" & Localita.Provincia & ")"
            Return ris
        End Get

    End Property

    Public ReadOnly Property RagSocNome As String
        Get
            Dim ris As String = String.Empty

            If _RagSoc.Length Then
                ris = _RagSoc
            Else
                ris = _Cognome & " " & _Nome
            End If

            Return ris.TrimEnd
        End Get
    End Property

    Public ReadOnly Property Nominativo() As String
        Get
            Dim Ris As String = ""
            If _IdRub = 0 Then
                Ris = "- Tutti"
            Else
                If _RagSoc.Length Then Ris = _RagSoc & " - "
                Ris &= _Cognome & " " & _Nome & " " & TipoVoce
                'If NonIncludereSostituzione = False Then
                If IdRubricaLinked Then
                    Ris &= " (Sostituisce: '" & Sostituisce.Nominativo & "')"
                End If
                'End If

            End If

            Return Ris
        End Get
    End Property

    Public ReadOnly Property NominativoConId As String
        Get
            Dim ris As String = Nominativo
            If IdRub <> 0 Then
                ris &= " (" & IdRub & ")"
            End If
            Return ris
        End Get
    End Property

    Public Function Intestazione() As String

        Dim Intest As String = _RagSoc & " (" & _IdRub & ")" & vbNewLine
        Intest &= _Indirizzo & vbNewLine
        Intest &= _Citta & vbNewLine
        Intest &= _CAP & vbNewLine
        Intest &= "P.IVA " & _Piva & vbNewLine
        Intest &= "@ " & _Email & vbNewLine
        Intest &= "Tel " & _Tel & vbNewLine
        Intest &= "Ind.Cons. " & _IndCons & vbNewLine
        Intest &= "Pagamento " & _Pagamento & vbNewLine
        Return Intest
    End Function

    Public ReadOnly Property EmailAmministrativa As String
        Get
            If _EmailAdmin.Length Then
                Return _EmailAdmin
            Else
                Return _Email
            End If
        End Get
    End Property

    Public ReadOnly Property HaDocumentiInSospeso(Optional ByVal lstIdDocDaEscludere As List(Of Integer) = Nothing) As Boolean
        Get
            Dim ListaIdDocDaEscludereStr As String = "(0"
            If Not lstIdDocDaEscludere Is Nothing Then
                For Each idDoc As Integer In lstIdDocDaEscludere
                    ListaIdDocDaEscludereStr &= ", " & idDoc
                Next
            End If
            ListaIdDocDaEscludereStr &= ")"
            Dim _HaDocumentiInSospeso = False
            Using mgr As New RicaviDAO()
                'Dim Tipo = "(" & enTipoDocumento.enTipoDocFattura & "," & enTipoDocumento.enTipoDocFatturaRiepilogativa & "," & enTipoDocumento.enTipoDocPreventivo & ")"
                Dim DocumentiInSospeso As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", _IdRub),
                                            New LUNA.LunaSearchParameter("Tipo", enTipoDocumento.DDT, "<>"),
                                            New LUNA.LunaSearchParameter("IdRicavo", ListaIdDocDaEscludereStr, "NOT IN"))
                'TODO: IN QUESTO MODO C'E' UN PROBLEMA: BECCO ANCHE L'ULTIMO DOCUMENTO EMESSO E, SE NON C'ERA UN PAGAMENTO ANTICIPATO, MI TORNA COME NON PAGATO;
                'E' GIUSTO COSI'? IN QUESTO MODO MI SA CHE ALLA FINE PER QUASI TUTTE LE EMISSIONI DI DOCUMENTI VERRA' RICHIESTO SE SI VUOLE STAMPARE LA SITUAZIONE
                'CONTABILE!
                For Each R As Ricavo In DocumentiInSospeso
                    If R.PagatoInteramente = False Then
                        _HaDocumentiInSospeso = True
                        Exit For
                    End If
                Next

                Return _HaDocumentiInSospeso
            End Using
        End Get
    End Property

    Private Function PivaIsNotValid() As Boolean
        Dim Ris As Boolean = True


        '   Posizione
        '   0   1   2   3   4   5   6   7   8   9
        '   Valore
        '   0   2   4   6   8   1   3   5   7   9

        'Posizione 0
        Dim Totale As Integer, I As Integer

        For I = 0 To 10
            If (I Mod 2 = 0) Then
                Totale += CInt(_Piva.Chars(I).ToString)
            Else
                Select Case _Piva.Chars(I)
                    Case "0"
                        Totale += 0
                    Case "1"
                        Totale += 2
                    Case "2"
                        Totale += 4
                    Case "3"
                        Totale += 6
                    Case "4"
                        Totale += 8
                    Case "5"
                        Totale += 1
                    Case "6"
                        Totale += 3
                    Case "7"
                        Totale += 5
                    Case "8"
                        Totale += 7
                    Case "9"
                        Totale += 9
                End Select
            End If
        Next

        If Totale Mod 10 = 0 Then
            Ris = False
        End If

        Return Ris

    End Function

    Private _Indirizzi As List(Of Indirizzo) = Nothing
    Public ReadOnly Property Indirizzi(Optional ByVal ForceLoad As Boolean = False) As List(Of Indirizzo)
        Get
            If _Indirizzi Is Nothing Or ForceLoad = True Then
                Using mgr As New IndirizziDAO
                    _Indirizzi = mgr.FindAll(New LUNA.LunaSearchParameter("IdRubrica", IdRub))
                End Using

                'qui creo l'indirizzo base
                Dim I As New Indirizzo
                I.Nome = "Base"
                I.Indirizzo = Indirizzo
                I.Citta = Citta
                I.Cap = CAP
                I.Destinatario = RagSocNome
                I.Provincia = Provincia
                I.Comune = Citta

                If _Indirizzi.Count = 0 OrElse _Indirizzi.Find(Function(x) x.Predefinito = True) Is Nothing Then
                    I.Predefinito = True
                End If

                _Indirizzi.Add(I)

                _Indirizzi.Sort(AddressOf FormerListSorter.IndirizziSorter.SortDefault)

            End If
            Return _Indirizzi
        End Get
    End Property

    Public ReadOnly Property CorriereDefaultStr As String
        Get
            Dim ris As String = String.Empty

            ris = MgrMetodiConsegna.GetMetodoConsegna(IdCorriere).Descrizione

            Return ris
        End Get
    End Property

    Public ReadOnly Property PagamentoDefaultStr As String
        Get
            Dim ris As String = String.Empty

            If IdPagamento Then
                Using Tp As New TipoPagamento
                    Tp.Read(IdPagamento)
                    ris = Tp.TipoPagam
                End Using
            End If


            Return ris
        End Get
    End Property

#End Region

#Region "Database Field"

    Public Overrides Property PrefissoPiva As String
        Get
            Dim Ris As String = String.Empty

            Ris = MyBase.PrefissoPIva

            If Ris.Length = 0 Then
                Ris = "IT"
            End If

            Return Ris
        End Get
        Set(ByVal value As String)
            MyBase.PrefissoPIva = value
        End Set
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IVoceRubrica.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        ' Return True
        Dim Ris As Boolean = InternalIsValid()

        If _RagSoc.Trim.Length = 0 And _Cognome.Trim.Length = 0 Then
            Ris = False
        End If

        'If _CodFisc.Trim.Length = 0 And _Piva.Trim.Length = 0 Then
        '    Ris = False
        'End If

        'If _Piva.Trim.Length <> 0 Then
        '    If _Piva.Trim.Length <> 11 Then
        '        Ris = False
        '    Else
        '        'controllo validita partita Iva
        '        If FormerHelper.Finanziarie.CheckPartitaIva(_Piva) = False Then
        '            Ris = False
        '        End If
        '    End If
        'End If

        'If _CodFisc.Trim.Length <> 0 Then
        '    If _CodFisc.Trim.Length <> 11 And _CodFisc.Trim.Length <> 16 Then
        '        Ris = False
        '    Else
        '        If FormerHelper.Finanziarie.CheckCodiceFiscale(_CodFisc) = False Then
        '            Ris = False
        '        End If
        '    End If
        'End If

        'If FormerHelper.Mail.IsValidEmailAddress(_Email) = False Then
        '    Ris = False
        'End If

        'If _IdComune = 0 Then Ris = False

        'If _CAP.Length <> 5 Then Ris = False

        Return Ris

    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IVoceRubrica.Read

        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris

    End Function

    Private Function GetTestoFromVoce() As String

        Dim ris As String = String.Empty

        Dim myType As Type = GetType(_VoceRubrica)

        For Each P In myType.GetProperties
            Dim SingProp As String = String.Empty
            Try
                SingProp = P.Name & ": "
                Dim PropValue As Object = P.GetValue(Me, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
                SingProp &= PropValue & ControlChars.NewLine
            Catch ex As Exception
                SingProp = String.Empty
            End Try
            If SingProp.Length Then ris &= SingProp
        Next

        Return ris

    End Function

    Public Overrides Function Save() As Integer Implements IVoceRubrica.Save

        If IdRub = 0 Then
            SorgenteStorico = Sorgente
        End If

        Dim Ris As Integer = MyBase.Save()
        If IsChanged Then FormerLib.FormerLog.ScriviVoceRubrica(Ris, GetTestoFromVoce)

        'qui vado anche a vedere ogni volta che salvo una voce di rubrica che se ce ne sta con la mail uguale in rubrica marketing la disattivo 

        If Email.Length AndAlso Email <> FormerLib.FormerConst.EmailNonDisponibile Then
            Using mgr As New VoceRubricaMarketingDAO
                Dim l As List(Of VoceRubricaMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubricaMarketing.Email, Email))
                For Each singVM In l
                    singVM.Disattivo = enSiNo.Si
                    singVM.Save()
                Next
            End Using
        End If

        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function


    Public Function CalcolaChiave() As String

        Dim Ris As String = "", Risultato As String = ""

        Ris = _IdRub * 1809 ^ 2

        Dim car As String

        For Each car In Ris

            Risultato &= Chr(CInt(car) + 70)

        Next

        If Tipo = enTipoRubrica.Cliente Then
            Risultato = "@A" & Risultato
        End If

        Return Risultato

    End Function

    Public Function SituazioneContabile(Optional ByVal ShowInt As Boolean = True,
                                        Optional ByVal ShowMsg As Boolean = False,
                                        Optional MsgSupplementare As String = "") As String

        'calcolo la situazione contabile del cliente e torno l'html 

        Dim Buffer As String = ""

        Buffer &= "<html><head><title>Situazione contabile " & _RagSoc & "</title><style>BODY {font-family: 'Segoe UI';}</style></head>"
        Buffer &= "<body>"

        Using Contab As New cContab
            Dim TotSospeso As Double = 0

            Dim IntHtml = Intestazione().Replace(vbNewLine, "<br>")
            If ShowInt Then Buffer &= "<br><font size=2 FACE=TAHOMA>Spettabile <br>" & IntHtml & "<br>"
            If ShowMsg Then Buffer &= "<br>al fine di agevolare le operazioni amministrative <b>Le inviamo la sua situazione contabile aggiornata</b>.<br><br>"
            If MsgSupplementare.Length Then
                Buffer &= MsgSupplementare
            End If

            'Buffer &= "<br><br>Coordinate per Bonifico Bancario:<br><br>BANCA: <b>CARIPARMA</b><br>IBAN: <b>IT 55 A 06230 05089 0000 6337 9643</b>"

            Buffer &= "<br><br><b>Amministrazione Former</b><br>06.30884518<br><A HREF=""mailto:amministrazione@tipografiaformer.com"">amministrazione@tipografiaformer.com</A><BR><BR>"

            Dim dttable As DataTable = Contab.ListaSituaz(_IdRub, , , True)
            Buffer &= "<br><br><table border=0 width=100% >"

            Buffer &= "<tr style=""border-bottom:1px solid black;""><td colspan=5><FONT SIZE=2 FACE=TAHOMA><B>Documenti SCADUTI</td></tr>"

            Buffer &= "<tr bgcolor=""FE6601"">"
            Buffer &= "<td><font SIZE=2 FACE=TAHOMA>Documento</td>"
            'Buffer &= "<td align=Right><font SIZE=2 FACE=TAHOMA>Scadenza</td>"
            Buffer &= "<td align=Right><font size=2 FACE=TAHOMA>Importo</td>"
            Buffer &= "<td align=right><font SIZE=2 FACE=TAHOMA>Acconto</td>"
            Buffer &= "<td align=right><font SIZE=2 FACE=TAHOMA align=Right>Residuo</td>"
            Buffer &= "</tr>"

            For Each Dr In dttable.Rows
                Using R As New Ricavo
                    R.Read(Dr("IdRif"))
                    Dim dataPrevPagam As Date = R.Dataprevpagam
                    Dim ColoreRiga As String = " BGCOLOR=""#00FF00"""
                    Dim ColoreTesto As String = ""
                    ' If dataPrevPagam < Now Then
                    Dim Diff As Decimal = R.TotaleAncoraDaPagare
                    If Diff OrElse R.Tipo = enTipoDocumento.NotaDiCredito Then

                        ColoreRiga = " BGCOLOR=""#FF0000"""
                        ColoreTesto = "WHITE"
                        If R.Tipo = enTipoDocumento.NotaDiCredito Then
                            TotSospeso += R.TotaleMatematico
                        Else
                            TotSospeso += Diff
                        End If
                        Dim Doc As String = R.TipoDocStr
                        Buffer &= "<tr>"
                        Buffer &= "<td " & ColoreRiga & "><font SIZE=2 FACE=TAHOMA color=" & ColoreTesto & ">" & MgrAziende.GetRagioneSociale(R.IdAzienda) & " - " & Doc & " Num.<B>" & R.Numero & "</B> del " & R.DataRicavoStr & "</td>"
                        'Buffer &= "<td align=right><FONT SIZE=2 FACE=TAHOMA >"
                        'Dim DataRif As Date = R.Dataprevpagam
                        'Buffer &= DataRif.ToShortDateString & " (da " & Math.Abs(DateDiff(DateInterval.Day, DataRif, Now.Date)) & " giorni)"
                        'Buffer &= "</td>"
                        Buffer &= "<td align=right><font SIZE=2 FACE=tahoma>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(R.TotaleMatematico) & "</td>"
                        Buffer &= "<td align=right><font SIZE=2 FACE=tahoma>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(R.TotaleGiaPagato) & "</td>"

                        Dim Residuo As Decimal = 0
                        Residuo = R.TotaleAncoraDaPagare
                        Buffer &= "<td align=right><font SIZE=2 FACE=tahoma>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Residuo) & "</td>"
                        Buffer &= "</tr>"
                    End If
                End Using

            Next

            Buffer &= "<tr><td colspan=5><br><br></td></tr>"

            Buffer &= "<tr style=""border-bottom:1px solid black;""><td colspan=5><FONT SIZE=2 FACE=TAHOMA><b>Documenti In SCADENZA</td></tr>"

            Buffer &= "<tr bgcolor=""FE6601"">"
            Buffer &= "<td><font SIZE=2 FACE=TAHOMA>Documento</td>"
            'Buffer &= "<td align=Right><font SIZE=2 FACE=TAHOMA>Scadenza</td>"
            Buffer &= "<td align=Right><font size=2 FACE=TAHOMA>Importo</td>"
            Buffer &= "<td align=right><font SIZE=2 FACE=TAHOMA>Acconto</td>"
            Buffer &= "<td align=right><font SIZE=2 FACE=TAHOMA align=Right>Residuo</td>"
            Buffer &= "</tr>"

            dttable = Contab.ListaSituaz(_IdRub)

            For Each Dr In dttable.Rows
                Using R As New Ricavo
                    R.Read(Dr("IdRif"))
                    Dim dataPrevPagam As Date = R.Dataprevpagam
                    Dim ColoreRiga As String = " BGCOLOR=""#00FF00"""
                    Dim ColoreTesto As String = ""
                    ' If dataPrevPagam < Now Then

                    Dim Diff As Decimal = R.TotaleAncoraDaPagare
                    If Diff OrElse R.Tipo = enTipoDocumento.NotaDiCredito Then

                        ColoreRiga = " BGCOLOR=""#FF0000"""
                        ColoreTesto = "WHITE"
                        If R.Tipo = enTipoDocumento.NotaDiCredito Then
                            TotSospeso += R.TotaleMatematico
                        Else
                            TotSospeso += Diff
                        End If

                        Dim Doc As String = R.TipoDocStr
                        Buffer &= "<tr>"
                        Buffer &= "<td " & ColoreRiga & "><font SIZE=2 FACE=TAHOMA color=" & ColoreTesto & ">" & MgrAziende.GetRagioneSociale(R.IdAzienda) & " - " & Doc & " Num.<b>" & R.Numero & "</b> del " & R.DataRicavoStr & "</td>"
                        'Buffer &= "<td align=right><font SIZE=2 FACE=TAHOMA >"
                        'Dim DataRif As Date = R.Dataprevpagam
                        'Buffer &= DataRif.ToShortDateString & " (il " & Math.Abs(DateDiff(DateInterval.Day, DataRif, Now.Date)) & " giorni)"
                        'Buffer &= "</td>"
                        Buffer &= "<td align=right><font SIZE=2 FACE=tahoma>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(R.TotaleMatematico) & "</td>"
                        Buffer &= "<td align=right><font SIZE=2 FACE=tahoma>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(R.TotaleGiaPagato) & "</td>"

                        Dim Residuo As Decimal = 0
                        Residuo = R.TotaleAncoraDaPagare
                        Buffer &= "<td align=right><FONT SIZE=2 FACE=tahoma>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Residuo) & "</td>"
                        Buffer &= "</tr>"
                    End If
                End Using

            Next
            Buffer &= "<tr><td colspan=5><br><br></td></tr>"
            Buffer &= "<tr><td><font SIZE=2 FACE=TAHOMA>TOTALE ANCORA DA SALDARE: </td><td colspan=4 align=right><font SIZE=2 FACE=TAHOMA><b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotSospeso) & "</b></td></tr>"
        End Using
        Buffer &= "</table>"
        Buffer &= "</font>"

        Buffer &= "</body></html>"

        Return Buffer

    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function


#End Region

End Class



''' <summary>
'''Interface for table T_rubrica
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IVoceRubrica
    Inherits _IVoceRubrica

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface