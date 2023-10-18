#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region
Imports System.Drawing
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig
Imports System.Web
Imports FormerBusinessLogicInterface
''' <summary>
'''Entity Class for table T_commesse
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Commessa
    Inherits _Commessa
    Implements ICommessa

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Public Sub New()
        _DataIns = Now
        _IdReparto = enRepartoWeb.StampaOffset
        '_Stato = enStatoCommessa.Preinserito
    End Sub

    Public ReadOnly Property StatoColore As Color
        Get

            Return FormerColori.GetColoreStatoCommessa(Stato)

        End Get
    End Property

    Public ReadOnly Property StatoColoreHTML As String
        Get
            Dim statoCol As String = ""
            statoCol = ColorTranslator.ToHtml(FormerColori.GetColoreStatoCommessa(Stato))
            Return statoCol

        End Get
    End Property


    Private _LavLogRealizzazione As LavLog = Nothing
    Public ReadOnly Property LavLogRealizzazione As LavLog
        Get
            If _LavLogRealizzazione Is Nothing Then
                'qui isolo il lavlog di stampa
                For Each ll As LavLog In ListaLavLog
                    If ll.IdLavoro = FormerConst.Lavorazioni.StampaRealizzazione Then
                        'questo e' il mio lavlog
                        _LavLogRealizzazione = ll
                    End If
                Next
            End If
            Return _LavLogRealizzazione
        End Get
    End Property

    Public ReadOnly Property CreataDa As String
        Get
            Dim ris As String = String.Empty

            If CreataAutomaticamente = enSiNo.Si Then
                ris = "Automatica"
            Else
                If IdUtCreatore Then
                    Using U As New Utente
                        U.Read(IdUtCreatore)
                        ris = U.Login
                    End Using

                    If FromJob = enSiNo.Si Then
                        ris &= " da File JOB"
                    End If

                Else
                    ris = "-"
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property StatoStr As String
        Get
            Dim Ris As String = FormerEnumHelper.StatoCommessaString(_Stato)
            Return Ris
        End Get
    End Property
    Private _Risorsa As Risorsa = Nothing
    Public ReadOnly Property Risorsa As Risorsa
        Get
            If _Risorsa Is Nothing Then
                _Risorsa = New Risorsa
                _Risorsa.Read(IdRis)
            End If
            Return _Risorsa
        End Get
    End Property

    Public ReadOnly Property CopieStr As String
        Get
            Dim ris As String = String.Empty

            If Segnature <= 1 Then
                If ListaOrdini.Count Then
                    Dim O As Ordine = ListaOrdini()(0)
                    If IdReparto <> enRepartoWeb.StampaOffset And IdReparto <> enRepartoWeb.Packaging Then
                        If ListaOrdini().Count = 1 Then
                            ris = FormerHelper.Stringhe.FormattaNumero(O.QtaOrdine)
                        Else
                            ris = FormerHelper.Stringhe.FormattaNumero(Copie)
                        End If

                    Else
                        If Not O.ListinoBase Is Nothing Then
                            If O.ListinoBase.TipoCarta.TipoCarta = enTipoCarta.Composta Then

                                Dim TotaleCartaComposta As Integer = 0

                                For Each c In O.ListinoBase.TipoCarta.ComposizioniCarta
                                    TotaleCartaComposta += c.NumFogli
                                Next

                                ris = TotaleCartaComposta & " copie da " & Copie 'Math.Ceiling(Copie / Segnature)
                            Else
                                ris = FormerHelper.Stringhe.FormattaNumero(Copie)
                            End If
                        Else
                            ris = FormerHelper.Stringhe.FormattaNumero(Copie)
                        End If
                    End If


                Else
                    ris = FormerHelper.Stringhe.FormattaNumero(Copie)
                End If
            Else
                'qui devo vedere se le copie totali 
                If ListaOrdini.Count = 1 Then
                    Dim NumSpazi As Integer = ModelloCommessa.NumSpazi
                    If NumSpazi = 0 Then NumSpazi = 1
                    Dim O As Ordine = ListaOrdini()(0)
                    Dim Nfogli As Integer = O.NFogli

                    'If Nfogli = 0 Then Nfogli = 1

                    'If IdCom = 39536 Then Stop
                    If ModelloCommessa.FronteRetro = enSiNo.Si Then
                        NumSpazi *= 2
                        If ModelloCommessa.FRSuSeStessa = enSiNo.No Then
                            Nfogli = Nfogli * 2
                        End If
                    End If

                    If O.ListinoBase.TipoCarta.TipoCarta = enTipoCarta.Composta Then

                        Dim TotaleCartaComposta As Integer = 0

                        For Each c In O.ListinoBase.TipoCarta.ComposizioniCarta
                            TotaleCartaComposta += c.NumFogli
                        Next

                        ris = TotaleCartaComposta & " copie da " & Copie 'Math.Ceiling(Copie / Segnature)
                    Else
                        Dim SegnatureCalcolate As Single = 0

                        SegnatureCalcolate = Nfogli / NumSpazi

                        If SegnatureCalcolate < 1 Then
                            ris = Copie
                        ElseIf SegnatureCalcolate Mod 2 = 0 Then
                            'pari 
                            ris = Segnature & " segnature da " & Math.Ceiling(Copie / Segnature)
                        Else
                            'dispari
                            Dim CopieSingole As Integer = Copie / SegnatureCalcolate

                            Dim ParteIntera As Integer = Math.Floor(SegnatureCalcolate)
                            ris = ParteIntera & " segnature da " & CopieSingole
                            Dim ParteNonIntera As Integer = (Copie - (CopieSingole * ParteIntera))
                            If ParteNonIntera Then
                                ris &= ", 1 segnatura da " & ParteNonIntera
                            End If
                        End If
                    End If

                Else

                    ris = Segnature & " segnature da " & Math.Ceiling(Copie / Segnature)

                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property DataStr As String
        Get
            Return _DataIns.ToString("dd.MM.yy")
        End Get
    End Property

    Public ReadOnly Property PrimaConsegnaStr As String
        Get
            Return DataPrimaConsegna.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public Property ModificataListaLav As Boolean = False

    Public ReadOnly Property ggMancanti As String
        Get
            Dim Ris As String = String.Empty

            If ListaOrdini.Count AndAlso Not PrimaConsegna Is Nothing Then
                If Stato < enStatoCommessa.Completata Then
                    Ris = MgrDataConsegna.CalcolaGiorniMancanti(Now,
                                                         PrimaConsegna.IdCorr,
                                                         DataPrimaConsegna)
                Else
                    Ris = "-"
                End If
            End If

            Return Ris

        End Get
    End Property

    Private _PrevistaPrimaConsegna As Date = Date.MinValue
    Public ReadOnly Property PrevistaPrimaConsegna As Date
        Get
            If _PrevistaPrimaConsegna = Date.MinValue Then

                Try
                    If ListaOrdini.Count Then
                        ListaOrdini.Sort(Function(x, y) x.DataPrevProduzione.CompareTo(y.DataPrevProduzione))
                        If ListaOrdini.FindAll(Function(X) X.DataPrevProduzione <> Date.MinValue).Count Then
                            _PrevistaPrimaConsegna = ListaOrdini.FindAll(Function(X) X.DataPrevProduzione <> Date.MinValue)(0).DataPrevProduzione
                        End If
                        If _PrevistaPrimaConsegna = Date.MinValue Then
                            ListaOrdini.Sort(Function(x, y) x.ConsegnaAssociata.Giorno.CompareTo(y.ConsegnaAssociata.Giorno))
                            _PrevistaPrimaConsegna = ListaOrdini()(0).ConsegnaAssociata.Giorno
                        End If
                    End If
                Catch ex As Exception

                End Try
            End If

            Return _PrevistaPrimaConsegna
        End Get
    End Property

    Private _PrimaConsegna As ConsegnaProgrammata = Nothing
    Public ReadOnly Property PrimaConsegna As ConsegnaProgrammata
        Get
            If _PrimaConsegna Is Nothing Then

                Try
                    If ListaOrdini.Count Then
                        ListaOrdini.Sort(Function(x, y) x.ConsegnaAssociata.Giorno.CompareTo(y.ConsegnaAssociata.Giorno))
                        _PrimaConsegna = ListaOrdini()(0).ConsegnaAssociata
                    End If
                Catch ex As Exception

                End Try
            End If

            Return _PrimaConsegna
        End Get
    End Property

    Public ReadOnly Property DataPrimaConsegna As Date
        Get
            Dim ris As Date = Date.MinValue

            'If IdCom = 46526 Then Stop
            If Not PrimaConsegna Is Nothing Then
                ris = PrimaConsegna.Giorno
            End If
            Return ris
        End Get
    End Property

    Private _ListaOrdini As List(Of Ordine) = Nothing
    Public ReadOnly Property ListaOrdini(Optional ForzaCaricamento As Boolean = False) As List(Of Ordine)
        Get
            If _ListaOrdini Is Nothing OrElse ForzaCaricamento = True Then

                If IdCom Then
                    Using mgr As New OrdiniDAO
                        _ListaOrdini = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, IdCom))
                    End Using
                Else
                    _ListaOrdini = New List(Of Ordine)
                End If


            End If
            Return _ListaOrdini
        End Get
    End Property

    Private _ListaLavLog As List(Of LavLog) = Nothing
    Public Property ListaLavLog As List(Of LavLog)
        Get
            If _ListaLavLog Is Nothing Then
                Using mgr As New LavLogDAO
                    _ListaLavLog = mgr.FindAll("Ordine",
                                               New LUNA.LunaSearchParameter("IdCom", IdCom),
                                               New LUNA.LunaSearchParameter("IdCom", 0, "<>"))
                End Using
            End If

            Return _ListaLavLog
        End Get
        Set(value As List(Of LavLog))
            _ListaLavLog = value
        End Set
    End Property

    Private _ListaLavorazioni As List(Of Lavorazione) = Nothing
    Public ReadOnly Property ListaLavorazioni As List(Of Lavorazione)
        Get
            _ListaLavorazioni = New List(Of Lavorazione)

            Using mgr As New LavLogDAO
                'Dim L As List(Of LavLog) = mgr.FindAll(New LUNA.LunaSearchParameter("IdCom", IdCom), _
                '                                       New LUNA.LunaSearchParameter("IdLav", FormerConst.Lavorazioni.Taglio, "<>"))
                Dim L As List(Of LavLog) = mgr.FindAll(LFM.LavLog.Ordine, New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, IdCom))
                For Each singLav As LavLog In L
                    Dim lav As New Lavorazione
                    lav.Read(singLav.Idlav)

                    _ListaLavorazioni.Add(lav)
                Next

            End Using

            Return _ListaLavorazioni
        End Get
    End Property

    Private _ListaIdOrdini As Integer()
    Public Property ListaIdOrdini() As Integer()
        Get
            Return _ListaIdOrdini
        End Get
        Set(ByVal value As Integer())
            _ListaIdOrdini = value
        End Set
    End Property

    Public Overrides Property Priorita As Integer
        Get
            Dim Ris As Integer = MyBase.Priorita

            If Ris = enSiNo.No Then
                'qui devo vedere se un ordine di quelli contenuti ha priorita, in quel caso tutta la commessa 
                'ha priorita a prescindere dalla sua priorita esplicita

                For Each Ord As Ordine In ListaOrdini
                    If Ord.Priorita = enSiNo.Si Then
                        Ris = enSiNo.Si
                        Exit For
                    End If
                Next

            End If

            Return Ris
        End Get
        Set(value As Integer)
            MyBase.Priorita = value
        End Set
    End Property

    Public ReadOnly Property PrioritaStr As String
        Get
            Dim Ris As String = ""
            If Priorita = enSiNo.Si Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property Colore As Color
        Get
            Dim ColoreSfondo As Color = Color.Transparent
            Select Case _Stato
                Case enStatoCommessa.Preinserito
                    ColoreSfondo = FormerColori.ColoreStatoCommessaPreinserito

                Case enStatoCommessa.Pronto
                    ColoreSfondo = FormerColori.ColoreStatoCommessaPronto

                Case enStatoCommessa.Stampa
                    ColoreSfondo = FormerColori.ColoreStatoCommessaStampa

                Case enStatoCommessa.FinituraSuCommessa
                    ColoreSfondo = FormerColori.ColoreStatoCommessaFinituraSuCommessa

                Case enStatoCommessa.FinituraSuProdotti
                    ColoreSfondo = FormerColori.ColoreStatoCommessaFinituraSuProdotti

                Case enStatoCommessa.Completata
                    ColoreSfondo = FormerColori.ColoreStatoCommessaCompletata

            End Select

            Return ColoreSfondo
        End Get
    End Property

    Private _ModelloCommessa As ModelloCommessa = Nothing
    Public ReadOnly Property ModelloCommessa As ModelloCommessa
        Get
            If _ModelloCommessa Is Nothing And IdModelloCommessa <> 0 Then
                _ModelloCommessa = New ModelloCommessa
                _ModelloCommessa.Read(IdModelloCommessa)
            End If
            Return _ModelloCommessa
        End Get
    End Property

    'Public ReadOnly Property RiepilogoBreve() As String
    '    Get
    '        Dim bufferHtml As String = ""
    '        Dim Dt As DataTable, Dr As DataRow

    '        'Dim RisColl As New cRisorseColl
    '        Dim _Comsel As Commessa = Me

    '        Dim p As New TipoCommessa
    '        p.Read(_Comsel.IdTipoCom)















    '        bufferHtml &= "<DIV style=""background-color:#EDEDED;width:200px;""><FONT SIZE=3><B>" & p.Descrizione & "</B></FONT></DIV><BR>"

    '        p = Nothing
    '        Dim PathFileStart As String = FormerPathCreator.GetAnteprima(_Comsel) 'FormerPath.PathCommesse & _Comsel.IdCom & "\" & _Comsel.IdCom & "." & i & "A.jpg"
    '        If _Comsel.Segnature AndAlso PathFileStart.IndexOf(".1A.jpg") <> -1 Then
    '            For i As Integer = 1 To _Comsel.Segnature
    '                Dim PathFile As String = PathFileStart
    '                PathFile = PathFile.Replace("1", i)
    '                bufferHtml &= "<A HREF=""" & PathFile & """ target=_new><IMG SRC=""" & PathFile & """ WIDTH=200px Border=0></A><bR><BR>"
    '                If _Comsel.FronteRetro = enSiNo.Si Then
    '                    PathFile = PathFile.Replace("1A.", i & "B.")
    '                    bufferHtml &= "<A HREF=""" & PathFile & """ target=_new><IMG SRC=""" & PathFile & """ WIDTH=200px Border=0></A><bR><BR>"
    '                End If
    '            Next
    '        Else
    '            bufferHtml &= "<A HREF=""" & PathFileStart & """ target=_new><IMG SRC=""" & PathFileStart & """ WIDTH=200px Border=0></A><bR><BR>"
    '        End If

    '        bufferHtml &= "<div style=""background-color:#EDEDED;width:200px;"">"

    '        bufferHtml &= "Data: <FONT SIZE=2>" & _Comsel.DataIns & "</FONT><BR><BR>"
    '        bufferHtml &= "Commessa N: <FONT SIZE=3><b>" & _Comsel.IdCom & "</B></FONT><BR><BR>"
    '        'qui carico i dettagli delle lavorazioni per questo ordine
    '        bufferHtml &= "<FONT SIZE=2>Copie di stampa:</font> <FONT SIZE=5 color=RED><B>" & _Comsel.CopieStr & "</B></FONT>"

    '        If _Comsel.Largo Then
    '            bufferHtml &= "<br><br><FONT SIZE=2>Dimensioni:</font> <FONT color=RED size=3 ><B>Larghezza " & _Comsel.Largo & " Altezza " & _Comsel.Lungo & "</B></FONT>"
    '        End If

    '        bufferHtml &= "<br>"

    '        Dim Ris As New Risorsa

    '        Ris.Read(_Comsel.IdRis)
    '        bufferHtml &= "<BR><FONT SIZE=2><b>"
    '        bufferHtml &= "N " & _Comsel.NLastreNecessarie & " - Lastre</B><BR><br>"

    '        bufferHtml &= "<b>" & _Comsel.MacchinaStampa & "</b><BR><br></FONT>"

    '        Ris = Nothing

    '        'Dim L As List(Of Risorsa) = Nothing
    '        'Using mgrR As New RisorseDAO
    '        '    L = mgrR.ListaRisorseCom(_Comsel.IdCom)
    '        'End Using

    '        bufferHtml &= "<table>"
    '        Using riscoll As New cRisorseColl()
    '            Dt = riscoll.ListaRisorseCom(_Comsel.IdCom)

    '            For Each Dr In Dt.Rows

    '                bufferHtml &= "<tr><td>"

    '                Using r As New Risorsa
    '                    r.Read(Dr("IdRis"))
    '                    If Not r.TipoCarta Is Nothing Then
    '                        bufferHtml &= "<img SRC=""" & r.TipoCarta.ImgRif & """ width=""64"" ALIGN=""ABSMIDDLE"">"
    '                    End If
    '                End Using

    '                bufferHtml &= "</td><td>"

    '                bufferHtml &= " - <font size=2><b>" & Dr("Descrizione") & "</font></b><br><br>"

    '                bufferHtml &= "</td></tr>"
    '            Next
    '        End Using
    '        bufferHtml &= "</table>"

    '        bufferHtml &= "Stampa <font size=3><b>"

    '        If _Comsel.FronteRetro Then
    '            bufferHtml &= " Fronte retro"
    '        Else
    '            bufferHtml &= " Solo fronte"
    '        End If

    '        bufferHtml &= "</b></font>"
    '        bufferHtml &= "</div><br>"

    '        bufferHtml &= "<div style=""background-color:#EDEDED;width:200px;"">"
    '        bufferHtml &= "<font size=1>Note: <b><font size=2 color=red>" & HttpUtility.HtmlDecode(_Comsel.Annotazioni) & "</font></b></font>"
    '        bufferHtml &= "</div>"
    '        bufferHtml &= "<br>"

    '        ' Dim x As New cLavoriColl
    '        bufferHtml &= "<div style=""background-color:#EDEDED;width:200px;"">"
    '        bufferHtml &= "<b>LAVORAZIONI SU COMMESSA</b>:<br> <font size=2>"

    '        Dim LstLavori As List(Of LavLog) = Nothing
    '        Using Mgr As New LavLogDAO
    '            LstLavori = Mgr.FindAll("ordine", New LUNA.LunaSearchParameter("IdCom", _Comsel.IdCom))
    '        End Using

    '        bufferHtml &= "<table border=0>"
    '        bufferHtml &= "<tr><td></td><td><font size=1><b>Lavorazione</b></font></td><td><font size=1><b>Prendibile da</b></font></td></tr>"
    '        For Each singl As LavLog In LstLavori
    '            bufferHtml &= "<tr>"
    '            Dim PathImg As String
    '            If singl.Idlav = FormerConst.Lavorazioni.StampaRealizzazione Then
    '                PathImg = singl.MacchinarioRif.ImgRif
    '            Else
    '                PathImg = singl.Lavorazione.ImgRif
    '            End If
    '            bufferHtml &= "<td> - <img SRC=""" & PathImg & """ width=""32"" ALIGN=""ABSMIDDLE""></td><td><b>" & singl.Descrizione & "</b></td><td><font size=1>" & singl.PrendibileDa.Replace(",", "<br>") & "</font></td>"
    '            bufferHtml &= "</tr>"
    '        Next
    '        bufferHtml &= "</table>"

    '        bufferHtml &= "</div>"

    '        bufferHtml &= "<br><table style=""background-color:#EDEDED;"">"
    '        bufferHtml &= "<tr>"
    '        bufferHtml &= "<td><font SIZE=1><B>ORDINE</B></td>"
    '        bufferHtml &= "<td><font SIZE=1><B>ANTEPRIMA</B></td>"
    '        bufferHtml &= "<td><font SIZE=1><B>PRODOTTO E CLIENTE</B></td>"
    '        bufferHtml &= "<td><font SIZE=1><B>LAVORAZIONI</B></td>"
    '        bufferHtml &= "</tr>"

    '        For Each O As Ordine In _Comsel.ListaOrdini
    '            bufferHtml &= "<tr>"
    '            bufferHtml &= "<td VALIGN=TOP><font SIZE=1>" & O.IdOrd & "</td>"
    '            bufferHtml &= "<td VALIGN=TOP><font SIZE=1><A HREF=""" & O.FilePath & """ target=_NEW><IMG SRC=""" & O.FilePath & """ border=0 width=50 height=75></A></td>"
    '            bufferHtml &= "<td VALIGN=TOP><font SIZE=2>Prod: " & O.Prodotto.Descrizione & "<BR>"

    '            If O.IdTipoFustella Then
    '                Using tf As New TipoFustella
    '                    tf.Read(O.IdTipoFustella)
    '                    If tf.Profondita Then
    '                        'fustella astucci
    '                        bufferHtml &= "Fustella: <b>Cod. " & IIf(tf.Codice.Length, tf.Codice, "n.d.") & " - " & tf.Base & "mm x " & tf.Profondita & "mm x " & tf.Altezza & "mm</b><br>"
    '                    Else
    '                        'fustella etichette
    '                        bufferHtml &= "Fustella: <b>Cod. " & IIf(tf.Codice.Length, tf.Codice, "n.d.") & " - " & tf.Base & "mm x " & tf.Altezza & "mm</b><br>"
    '                    End If
    '                End Using
    '            End If

    '            bufferHtml &= "Cliente: " & O.VoceRubrica.Nominativo & "<br>"

    '            For Each s As FileSorgente In O.ListaSorgenti
    '                bufferHtml &= "(S) <a href =""" & s.FilePath & """>" & s.FilePath & "</a><br>"
    '            Next

    '            bufferHtml &= "</td>"
    '            bufferHtml &= "<td VALIGN=TOP><font SIZE=1>"
    '            For Each ll As LavLog In O.ListLavLog
    '                bufferHtml &= ll.Descrizione & "<BR>"
    '            Next
    '            bufferHtml &= "</td>"
    '            bufferHtml &= "</tr>"
    '        Next
    '        bufferHtml &= "</table>"

    '        bufferHtml &= "</font><BR>"


    '        'bufferHtml &= "</body></html>" & ControlChars.NewLine

    '        Return bufferHtml


    '    End Get
    'End Property

    Public Overridable ReadOnly Property ImgMacchinario As Image
        Get
            Dim ImgNew As Image = Nothing
            Try

                Dim IdMacchinarioToUse As Integer = IdMacchinario

                If Not LavLogRealizzazione Is Nothing Then
                    IdMacchinarioToUse = LavLogRealizzazione.IdMacchinario
                End If

                If IdMacchinarioToUse Then
                    Using m As New Macchinario
                        m.Read(IdMacchinarioToUse)
                        ImgNew = m.Img
                    End Using
                End If

            Catch ex As Exception
                ImgNew = Nothing
            End Try

            If ImgNew Is Nothing Then ImgNew = New Bitmap(My.Resources.no_image, 75, 50)

            Return ImgNew
        End Get
    End Property

    Public ReadOnly Property CommessaSenzaFile As Boolean
        Get
            Dim ris As Boolean = False

            For Each O In ListaOrdini
                If Not O.ListinoBase Is Nothing AndAlso O.ListinoBase.NoAttachFile = enSiNo.Si Then
                    ris = True
                    Exit For
                End If
            Next

            Return ris
        End Get
    End Property
    Public Overrides Function Refresh() As Integer
        Return MyBase.Refresh
    End Function
    Public Overridable ReadOnly Property ImgAnteprima As Image
        Get
            Dim ImgPreview As Image
            Dim ImgNew As Image = Nothing
            If CommessaSenzaFile Then
                If ListaOrdini.Count Then
                    Using O As Ordine = ListaOrdini()(0)
                        ImgNew = O.ImgAnteprima
                    End Using
                End If
            Else
                Try
                    Dim Path As String = FormerPathCreator.GetAnteprima(Me)
                    Dim PathLocaleImg As String = FormerPath.PathTempImg & "C" & IdCom & ".jpg"

                    If FileIO.FileSystem.FileExists(PathLocaleImg) Then
                        Try
                            ImgNew = Image.FromFile(PathLocaleImg)
                        Catch ex As Exception

                        End Try
                    Else
                        Try
                            If FileIO.FileSystem.FileExists(Path) Then
                                ImgPreview = Image.FromFile(Path)

                                ImgNew = FormerThumbnail.GetForOrdineCommessa(ImgPreview)
                            End If
                        Catch ex As Exception
                            ImgNew = Nothing
                        End Try

                        If Not ImgNew Is Nothing Then
                            Try
                                ImgNew.Save(PathLocaleImg)
                            Catch ex As Exception

                            End Try
                        End If

                    End If

                Catch ex As Exception
                    ImgNew = Nothing
                End Try
            End If


            If ImgNew Is Nothing Then ImgNew = New Bitmap(My.Resources.no_image, 75, 50)

            Return ImgNew
        End Get
    End Property

    Public ReadOnly Property CreaRiepilogo(Optional Operatore As Boolean = False) As String
        Get
            'Cursor.Current = Cursors.WaitCursor

            Dim _comSel As Commessa = Me

            Dim bufferHtml As String = ""
            bufferHtml &= "<div class=""divOperatore"" style=""font-size:16px;""><h4>Commessa " & _comSel.IdCom & "</h4>"
            bufferHtml &= "<div style=""text-align:center;background-color:" & _comSel.StatoColoreHTML & ";""><b>" & _comSel.StatoStr & "</b></div>"
            bufferHtml &= "<center><b>" & _comSel.Riassunto.ToUpper & "</b></center><hr>"

            Dim TipoStampa As String = String.Empty
            If _comSel.FronteRetro Then
                TipoStampa = "F/R"
            Else
                TipoStampa = "F"
            End If

            bufferHtml &= "<b>" & _comSel.CopieStr & " copie " & TipoStampa & "</b><br>"
            bufferHtml &= "<b>" & _comSel.MacchinaStampa.ToUpper & "</b><br>"
            bufferHtml &= "<b>" & _comSel.NLastreNecessarie & " lastr" & IIf(_comSel.NLastreNecessarie <> 1, "e", "a") & "</b><br>"

            If _comSel.Largo Then
                bufferHtml &= "DIMENSIONI: <b>Larghezza " & _comSel.Largo & " Altezza " & _comSel.Lungo & "</b></br>"
            End If

            bufferHtml &= "<br><center>"
            If Operatore Then
                bufferHtml &= "<img src=""" & FormerPathCreator.GetAnteprima(_comSel) & """>"
            Else
                bufferHtml &= "<a href=""" & FormerPathCreator.GetAnteprima(_comSel) & """ target=""_new""><img src=""" & FormerPathCreator.GetAnteprima(_comSel) & """ width=200  border=0></a>"
            End If
            bufferHtml &= "</center>"

            bufferHtml &= "<div class=""note""><b>NOTE</b><br>"
            bufferHtml &= HttpUtility.HtmlDecode(_comSel.Annotazioni) & "</div>"

            If _comSel.ListaOrdini.Count = 1 Then

                'qui devo mettere anche le lavorazioni di tipo caratteristica


                'qui vedo se ci sono extra data o lavorazioni di tipo caratteristica e le mostro
                Dim o As Ordine = _comSel.ListaOrdini()(0)
                bufferHtml &= o.RiepilogoExtraData & "</br>"

            End If
            bufferHtml &= "</div>"

            bufferHtml &= "<div class=""divTable divOperatore""><h4>RISORSE</h4><center>"

            Dim Dt As DataTable, Dr As DataRow
            Using RisColl As New cRisorseColl

                Dt = RisColl.ListaRisorseCom(_comSel.IdCom)
                bufferHtml &= "<table>"
                For Each Dr In Dt.Rows

                    Using r As New Risorsa
                        r.Read(Dr("IdRis"))
                        If Not r.TipoCarta Is Nothing Then
                            bufferHtml &= "<tr><td width=""64""><img src=""" & r.TipoCarta.ImgRif & """ width=""64"" align=""absmiddle""></td>"
                        End If
                    End Using

                    bufferHtml &= "<td valign=""top"" style='font-size:16px;'><br><b>" & Dr("Descrizione") & "</b></td></tr>"

                Next
                bufferHtml &= "</table></center>"
            End Using

            bufferHtml &= " </div>"

            Dim AnteprimaF As String = String.Empty ' IIf(Not _comSel.ModelloCommessa Is Nothing, _comSel.ModelloCommessa.Anteprima, String.Empty) ' FormerPath.PathCommesse & IdCom & "\" & IdCom & "F.jpg"
            If Not _comSel.ModelloCommessa Is Nothing Then
                AnteprimaF = _comSel.ModelloCommessa.Anteprima
            End If

            Dim AnteprimaR As String = String.Empty 'IIf(Not _comSel.ModelloCommessa Is Nothing, _comSel.ModelloCommessa.AnteprimaR, String.Empty) 'FormerPath.PathJOB & IdCom & "\" & IdCom & "R.jpg"
            If Not _comSel.ModelloCommessa Is Nothing Then
                AnteprimaR = _comSel.ModelloCommessa.AnteprimaR
            End If

            Dim AnteprimaPdf As String = String.Empty 'IIf(Not _comSel.ModelloCommessa Is Nothing, _comSel.ModelloCommessa.PDF, String.Empty) 'FormerPath.PathJOB & IdCom & "\" & IdCom & ".pdf"
            If Not _comSel.ModelloCommessa Is Nothing Then
                AnteprimaPdf = _comSel.ModelloCommessa.PDF
            End If

            If AnteprimaF.Length AndAlso FileIO.FileSystem.FileExists(AnteprimaF) Then
                bufferHtml &= "<div class=""divOperatore""><h4>MODELLO COMMESSA</h4>"
                If FileIO.FileSystem.FileExists(AnteprimaF) Then
                    bufferHtml &= "<a href=""" & AnteprimaPdf & """ ><img src=""" & AnteprimaF & """ border=0 width=160></a>"
                End If
                If FileIO.FileSystem.FileExists(AnteprimaR) Then
                    bufferHtml &= "<a href=""" & AnteprimaPdf & """ ><img src=""" & AnteprimaR & """ border=0 width=160></a>"
                End If

                Using Form As New Formato
                    Form.Read(_comSel.IdFormato)
                    bufferHtml &= "<br><br><b>Formato:</b> " & Form.Formato & "<br><br>"

                    Dim DimensRis As String = "-"

                    Using MgrM As New MagazzinoDAO
                        Dim l As List(Of MovimentoMagazzino) = MgrM.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCom, _comSel.IdCom),
                                                                            New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdFat, 0))
                        l = l.FindAll(Function(x) x.Risorsa.IsLastra = enSiNo.No)

                        If l.Count Then
                            Using R As Risorsa = l(0).Risorsa
                                DimensRis = R.Larghezza & "x" & R.Lunghezza
                            End Using
                        End If

                    End Using

                    bufferHtml &= "<b>Resa:</b> " & _comSel.SoggettiFoglio & " su " & DimensRis & "<br><br>"

                End Using

                If _comSel.SchemaTaglio.Length Then
                    bufferHtml &= "<br><br><b>Schema di taglio:</b> <a href=""" & _comSel.SchemaTaglio & """ >" & _comSel.SchemaTaglio & "</a>"
                End If


                bufferHtml &= "<br> </div>"


            End If

            bufferHtml &= "<div class=""divTable divOperatore""><h4> LAVORAZIONI</h4><center><table>"
            bufferHtml &= "<tr style=""background-color:#EDEDED;""><td>&nbsp;</td><td align=center><b>I</td><td align=center><b>F</td><td>&nbsp;</td><td><b>LAVORAZIONE/FASE</td></tr>"

            For Each SingLav In _comSel.ListaLavLog
                Dim PathImg As String = String.Empty
                If SingLav.Idlav = FormerConst.Lavorazioni.StampaRealizzazione Then
                    PathImg = SingLav.MacchinarioRif.ImgRif
                Else
                    PathImg = SingLav.Lavorazione.ImgRif
                End If
                bufferHtml &= "<tr>"
                bufferHtml &= "<td width=""48""><img src=""" & PathImg & """ width=""48"" align=""absmiddle""></td>"

                bufferHtml &= "<td width=25 "

                If SingLav.Lavorazione.Categoria.TipoCaratteristica <> enSiNo.Si Then
                    If SingLav.DataOraInizio <> Date.MinValue Then
                        bufferHtml &= " style=""background-color:green;"""
                    Else
                        bufferHtml &= " style=""background-color:red;"""
                    End If
                End If

                bufferHtml &= ">"
                bufferHtml &= "</td>"
                bufferHtml &= "<td width=25 "
                If SingLav.Lavorazione.Categoria.TipoCaratteristica <> enSiNo.Si Then
                    If SingLav.DataOraFine <> Date.MinValue Then
                        bufferHtml &= " style=""background-color:green;"""
                    Else
                        bufferHtml &= " style=""background-color:red;"""
                    End If
                End If
                bufferHtml &= ">"
                bufferHtml &= "</td>"

                bufferHtml &= "<td style='background-color:white;'><b>COMMESSA</b></td>"

                bufferHtml &= "<td align=left valign=center style='background-color:white;'>"

                bufferHtml &= SingLav.LavorazioneStr

                bufferHtml &= "</td>"

                bufferHtml &= "</tr>"
            Next

            Dim ListLavLog As New List(Of LavLog)
            For Each O As Ordine In _comSel.ListaOrdini
                For Each Singlav In O.ListLavLog
                    If ListLavLog.FindAll(Function(x) x.Idlav = Singlav.Idlav).Count = 0 Then
                        ListLavLog.Add(Singlav)
                    End If
                Next
            Next

            'For Each O As Ordine In _comSel.ListaOrdini
            For Each Singlav In ListLavLog
                Dim PathImg As String = Singlav.Lavorazione.ImgRif
                bufferHtml &= "<tr>"
                bufferHtml &= "<td width=""48""><img src=""" & PathImg & """ width=""48"" align=""absmiddle""></td>"

                bufferHtml &= "<td width=25 "

                If Singlav.Lavorazione.Categoria.TipoCaratteristica <> enSiNo.Si Then
                    If Singlav.DataOraInizio <> Date.MinValue Then
                        bufferHtml &= " style=""background-color:green;"""
                    Else
                        bufferHtml &= " style=""background-color:red;"""
                    End If
                End If

                bufferHtml &= ">"
                bufferHtml &= "</td>"
                bufferHtml &= "<td width=25 "
                If Singlav.Lavorazione.Categoria.TipoCaratteristica <> enSiNo.Si Then
                    If Singlav.DataOraFine <> Date.MinValue Then
                        bufferHtml &= " style=""background-color:green;"""
                    Else
                        bufferHtml &= " style=""background-color:red;"""
                    End If
                End If
                bufferHtml &= ">"
                bufferHtml &= "</td>"

                bufferHtml &= "<td style='background-color:white;'><b>"

                Dim ElencoIdOrd As String = String.Empty

                For Each O As Ordine In _comSel.ListaOrdini.FindAll(Function(x) x.ListLavLog.FindAll(Function(z) z.Idlav = Singlav.Idlav).Count > 0)
                    ElencoIdOrd &= "Ord. " & O.IdOrd & "<br>"
                Next

                bufferHtml &= ElencoIdOrd & "</b></td>"

                bufferHtml &= "<td align=left valign=center style='background-color:white;'>"

                bufferHtml &= Singlav.LavorazioneStr

                bufferHtml &= "</td>"

                bufferHtml &= "</tr>"
            Next
            'Next

            bufferHtml &= " </table></center>"
            bufferHtml &= " </div>"

            bufferHtml &= "<div class=""divTable divOperatore""><h4>ORDINI</h4><center>"
            bufferHtml &= "<table style=""background-color:#EDEDED;"">"
            bufferHtml &= "<tr>"
            bufferHtml &= "<td><b>ORDINE</b></td>"
            bufferHtml &= "<td><b>ANTEPRIMA</b></td>"
            bufferHtml &= "<td><b>PRODOTTO E CLIENTE</b></td>"
            bufferHtml &= "</tr>"

            For Each O As Ordine In _comSel.ListaOrdini
                bufferHtml &= "<tr>"
                bufferHtml &= "<td valign=top><b>" & O.IdOrd & "</b></td>"
                bufferHtml &= "<td valign=top><a href=""" & O.FilePath & """ target=_NEW><img src=""" & O.FilePath & """ border=0 width=50 height=75></A></TD>"
                bufferHtml &= "<td valign=top>Prod: <b>" & O.Qta & " " & O.Prodotto.Descrizione & "</b><br>"

                If O.NFogli <> 1 Then

                    If O.ListinoBase.NoFaccSuImpianti = True Then
                        'blocchi
                        bufferHtml &= "NUMERO FOGLI: <b>" & O.NFogli

                        Dim CounterCarta As Integer = 0
                        If O.ListinoBase.TipoCarta.ComposizioniCarta.Count Then
                            For Each tc In O.ListinoBase.TipoCarta.ComposizioniCarta
                                CounterCarta += tc.NumFogli
                            Next
                        End If

                        If CounterCarta Then
                            bufferHtml &= "x" & CounterCarta
                        End If
                    Else
                        'riviste
                        bufferHtml &= "FACCIATE: <b>" & (O.NFogli * 2)
                    End If



                    bufferHtml &= "</b><br>"
                End If


                If O.IdTipoFustella Then
                    Using tf As New TipoFustella
                        tf.Read(O.IdTipoFustella)
                        If tf.Profondita Then
                            'fustella astucci
                            bufferHtml &= "Fustella: <b>Cod. " & IIf(tf.Codice.Length, tf.Codice, "n.d.") & " - " & tf.Base & "mm x " & tf.Profondita & "mm x " & tf.Altezza & "mm</b><br>"
                        Else
                            'fustella etichette
                            bufferHtml &= "Fustella: <b>Cod. " & IIf(tf.Codice.Length, tf.Codice, "n.d.") & " - " & tf.Base & "mm x " & tf.Altezza & "mm</b><br>"
                        End If
                    End Using
                End If

                bufferHtml &= "Cliente: " & O.VoceRubrica.Nominativo & "<br>"

                For Each s As FileSorgente In O.ListaSorgenti
                    bufferHtml &= "(S) <a href =""" & s.FilePath & """>" & s.FilePath & "</a><br>"
                Next

                bufferHtml &= "</td>"
                bufferHtml &= "<td VALIGN=TOP>"
                For Each ll As LavLog In O.ListLavLog
                    bufferHtml &= ll.Descrizione & "<br>"
                Next
                bufferHtml &= "</td>"
                bufferHtml &= "</tr>"
            Next
            bufferHtml &= "</table></center>"
            bufferHtml &= " </div>"

            bufferHtml &= "<div class=""divOperatore""><h4>PDF ALTA RISOLUZIONE</h4>"

            Dim D As New DirectoryInfo(FormerPath.PathCommesse & IdCom)
            Try
                For Each f As FileInfo In D.GetFiles(IdCom & ".*.pdf")
                    If f.FullName <> AnteprimaPdf Then
                        bufferHtml &= "(S) <a href=""" & f.FullName & """> - " & f.Name & "</a><br>"
                    End If
                Next
            Catch ex As Exception

            End Try

            bufferHtml &= " </div>"

            Return bufferHtml

        End Get
    End Property

    Private _MovMagaz As List(Of MovimentoMagazzino) = Nothing
    Public Property MovMagaz() As List(Of MovimentoMagazzino)
        Get
            If _MovMagaz Is Nothing Then
                _MovMagaz = New List(Of MovimentoMagazzino)
            End If
            Return _MovMagaz
        End Get
        Set(ByVal value As List(Of MovimentoMagazzino))
            _MovMagaz = value
        End Set
    End Property

    Public Sub CaricaMovimentiMagazzino()
        Using Mgr As New MagazzinoDAO
            MovMagaz = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCom, IdCom))
        End Using
    End Sub

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICommessa.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICommessa.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICommessa.Save
        Dim Ris As Integer = MyBase.Save()

        If ModificataListaLav Then
            'qui devo risalvare la lista lavorazioni perchè è stata alterata manualmente

            Using mgr As New LavLogDAO

                mgr.DeleteByIdCom(IdCom, False)

                For Each singLav As LavLog In ListaLavLog
                    singLav.IdLavLog = 0
                    singLav.Save()
                Next

            End Using

        End If

        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function




#End Region

End Class


Public Class CommessaRicerca
    Inherits Commessa
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    Public Sub New(TransactionBoxRif As LUNA.LunaTransactionBox)
        MyBase.New(TransactionBoxRif)
    End Sub

    'Private _TipoCommessaStr As String = ""
    Public ReadOnly Property TipoCommessaStr As String
        Get
            Return Riassunto
        End Get
        'Set(value As String)
        '    _TipoCommessaStr = value
        'End Set
    End Property

    'Private _RisorsaStr As String = ""
    Public ReadOnly Property RisorsaStr As String
        Get
            Dim ris As String = String.Empty

            Dim Dt As DataTable, Dr As DataRow
            Using RisColl As New cRisorseColl

                Dt = RisColl.ListaRisorseCom(IdCom)

                For Each Dr In Dt.Rows
                    ris &= FormerHelper.Stringhe.FormattaNumero(Dr("Qta")) & " fg. " & Dr("Descrizione") & ControlChars.NewLine
                Next
            End Using

            ris = ris.TrimEnd(vbCr, vbLf)

            Return ris
        End Get
        'Set(value As String)
        '    _RisorsaStr = value
        'End Set
    End Property

    'Private _QtaStr As String = ""
    Public ReadOnly Property QtaStr As String
        Get
            Dim ris As String = String.Empty

            If Segnature <= 1 Then
                Using mgr As New MagazzinoDAO
                    Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCom, IdCom))
                    If l.Count Then
                        Dim M As MovimentoMagazzino = l(0)
                        ris = FormerHelper.Stringhe.FormattaNumero(M.Qta)
                    Else
                        ris = "-"
                    End If
                End Using
            Else
                'qui devo vedere se le copie totali 
                If ListaOrdini.Count = 1 Then
                    Dim NumSpazi As Integer = ModelloCommessa.NumSpazi
                    Dim O As Ordine = ListaOrdini()(0)
                    Dim Nfogli As Integer = O.NFogli

                    If ModelloCommessa.FronteRetro = enSiNo.Si Then
                        NumSpazi *= 2
                        If ModelloCommessa.FRSuSeStessa = enSiNo.No Then
                            Nfogli = Nfogli * 2
                        End If
                    End If

                    Dim SegnatureCalcolate As Single = Nfogli / NumSpazi

                    If SegnatureCalcolate Mod 2 = 0 Then
                        'pari 
                        ris = Copie / Segnature
                    Else
                        'dispari
                        Dim CopieSingole As Integer = Copie / SegnatureCalcolate

                        'Dim ParteIntera As Integer = Math.Floor(SegnatureCalcolate)
                        ris = CopieSingole ' & " segnature da " & CopieSingole & ", 1 segnatura da " & (Copie - (CopieSingole * ParteIntera))

                    End If

                Else
                    ris = Copie / Segnature
                End If
            End If

            Return ris

            'Return _QtaStr
        End Get
    End Property

    Public ReadOnly Property MacchinaStampaStr As String
        Get
            Return _MacchinaStampa
        End Get
    End Property

    Private _NumeroMessaggi As Integer = 0
    Public Property NumeroMessaggi As Integer
        Get
            Return _NumeroMessaggi
        End Get
        Set(value As Integer)
            _NumeroMessaggi = value
        End Set
    End Property

    Public ReadOnly Property IcoMsg As Image
        Get
            If _NumeroMessaggi Then
                Return My.Resources.attach
            Else
                Return My.Resources.blank
            End If

        End Get
    End Property

End Class

Public Class CommessaOperatore
    Inherits CommessaRicerca

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    Public Sub New(TransactionBoxRif As LUNA.LunaTransactionBox)

        MyBase.New(TransactionBoxRif)

    End Sub

    Public ReadOnly Property FrStr() As String
        Get
            If FronteRetro = enSiNo.Si Then
                Return "F/R"
            Else
                Return "F"
            End If
        End Get
    End Property

    Private _LastraStr As String = ""
    Public Property LastraStr() As String
        Get
            Return _LastraStr
        End Get
        Set(value As String)
            _LastraStr = value
        End Set
    End Property

    Private _InCaricoAStr As String = ""
    Public ReadOnly Property InCaricoAStr() As String
        Get
            Dim Ris As String = ""
            If _InCaricoAStr.Length Then
                Ris = _InCaricoAStr
            Else
                If _IdOperatore Then
                    Dim U As New Utente
                    U.Read(_IdOperatore)
                    Ris = U.Login
                    U = Nothing
                End If

            End If
            Return Ris
        End Get
    End Property

    Private _LavorazioneStr As String = ""
    Public Property LavorazioneStr() As String
        Get
            Return _LavorazioneStr
        End Get
        Set(value As String)
            _LavorazioneStr = value
        End Set
    End Property

    Private _IdOperatore As Integer = 0
    Public Property IdOperatore() As Integer
        Get
            Return _IdOperatore
        End Get
        Set(value As Integer)
            _IdOperatore = value
        End Set
    End Property

    Public ReadOnly Property HaAlmenoUnOrdineFast As Boolean
        Get
            Dim ris As Boolean = False

            For Each O As Ordine In ListaOrdini
                If O.TipoConsegna = enTipoConsegna.Fast Then
                    ris = True
                    Exit For
                End If
            Next

            Return ris
        End Get
    End Property

    Public ReadOnly Property DataMinoreConsegna As Date
        Get
            Dim ris As Date = Date.MaxValue

            For Each o As Ordine In ListaOrdini
                If DateDiff(DateInterval.Day, ris, o.ConsegnaAssociata.Giorno) < 0 Then
                    ris = o.ConsegnaAssociata.Giorno
                End If
            Next

            Return ris
        End Get
    End Property

End Class

Public Class CommessaOperatoreNoImg
    Inherits CommessaOperatore

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    Public Sub New(TransactionBoxRif As LUNA.LunaTransactionBox)

        MyBase.New(TransactionBoxRif)

    End Sub

    Public Overrides ReadOnly Property ImgAnteprima As Image
        Get
            Dim ris As Image = New Bitmap(My.Resources.no_image, New Size(75, 50))
            Return ris
        End Get
    End Property

End Class



''' <summary>
'''Interface for table T_commesse
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICommessa
    Inherits _ICommessa

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface