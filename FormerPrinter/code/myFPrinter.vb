Imports FormerLib.FormerEnum
Imports FormerDALSql
Imports FormerLib
Imports System.Drawing
Imports FormerConfig
Imports FormerBusinessLogic

Public Class myFPrinter

    Friend TextToBePrinted As String
    Private _PrinterName As String
    Private _Ord As Ordine
    Private _NumCollo As Integer = 0
    Private _Barcode As String = ""
    Private _NumeroColli As Integer = 0
    Private _Doc As Ricavo = Nothing
    Private _M As Messaggio = Nothing

    Private _Mail As PreventivoMail = Nothing
    Private _NumeroPagina As Integer = 0
    Private _SpeseConsegnaCumulative As Single = 0

    Private _ContatoreRiga As Integer = 0
    Private _FormatoPDF As Boolean = False
    Private _Cons As ConsegnaProgrammata = Nothing
    Private _P As Promemoria = Nothing

    Public Property MargineXEtichette As Integer = 0
    Public Property MargineYEtichette As Integer = 0

    Public Property MargineXFatture As Integer = 0
    Public Property MargineYFatture As Integer = 0

    Public Property NumCopieDocFiscale As Integer = FormerLib.FormerConst.Fiscali.NumCopieDocFiscali

    Public Property PrinterName() As String
        Get
            Return _PrinterName
        End Get
        Set(ByVal value As String)
            _PrinterName = value
        End Set
    End Property

    Private _Cp As ConsegnaProgrammata = Nothing

    Public Property IdScatola As Integer

    Public Property IdCons As Integer

    Public Property IdOrd As Integer
    Public Property NumColli As Integer


    Private Property LEtichetteBuste As List(Of IVoceRubricaG) = Nothing
    Public Property DtEtichetteBuste As DataTable
    Dim IndiceEtichettaBusta As Integer = 0

    Public Sub StampaConsegnaOrdini(ByRef Cp As ConsegnaProgrammata)
        ' Try
        _Cp = Cp
        Dim prn As New Printing.PrintDocument

        prn.PrinterSettings.PrinterName = _PrinterName

        'tipoCarta.PaperName = Printing.PaperKind.GermanStandardFanfold.ToString
        'tipoCarta.RawKind = Printing.PaperKind.GermanStandardFanfold
        'tipoCarta.Width = 900
        'tipoCarta.Height = 1300

        'prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

        prn.DocumentName = "Stampa Consegna Ordini"

        AddHandler prn.PrintPage, AddressOf Me._StampaConsegnaOrdini

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaConsegnaOrdini

        prn.Dispose()
        ' Catch ex As Exception

        'End Try
    End Sub
    Private _EtichettaCustom As EtichettaCustom
    Public Sub StampaEtichettaCustom(E As EtichettaCustom)
        _EtichettaCustom = E

        Dim prn As New Printing.PrintDocument

        prn.PrinterSettings.PrinterName = _PrinterName

        Dim tipoCarta As New System.Drawing.Printing.PaperSize

        tipoCarta.PaperName = "Custom Paper size"
        tipoCarta.RawKind = Printing.PaperKind.Custom
        'qui va trasformato in centesimi di pollice
        tipoCarta.Width = FormerHelper.PDF.TrasformaMmInCentesimiPollice(_EtichettaCustom.WidthMM)
        tipoCarta.Height = FormerHelper.PDF.TrasformaMmInCentesimiPollice(_EtichettaCustom.HeightMM)

        prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

        prn.DocumentName = "Stampa Etichetta Custom"
        prn.PrinterSettings.Copies = _EtichettaCustom.Qta
        prn.DefaultPageSettings.PaperSize = tipoCarta

        AddHandler prn.PrintPage, AddressOf Me._StampaEtichettaCustom

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaEtichettaCustom

        prn.Dispose()
    End Sub

    Public Sub StampaPreventivoMail(ByVal M As PreventivoMail)
        _Mail = M

        Dim prn As New Printing.PrintDocument
        prn.PrinterSettings.PrinterName = _PrinterName
        Dim tipoCarta As New System.Drawing.Printing.PaperSize
        tipoCarta.PaperName = Printing.PaperKind.A4
        prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta
        prn.PrinterSettings.DefaultPageSettings.Landscape = False
        prn.DocumentName = "Stampa Email " & M.Titolo
        prn.PrinterSettings.Copies = 1

        AddHandler prn.PrintPage, AddressOf Me._StampaPreventivoMail

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaPreventivoMail

        prn.Dispose()

    End Sub

    Public Sub StampaComandaOperatore(ByVal M As Messaggio)

        _M = M

        Dim prn As New Printing.PrintDocument

        'Dim tipoCarta As New System.Drawing.Printing.PaperSize
        'tipoCarta.PaperName = Printing.PaperKind.Custom
        'tipoCarta.Width = 80
        'tipoCarta.Height = 80

        'prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

        prn.PrinterSettings.PrinterName = _PrinterName
        prn.PrinterSettings.Copies = 1

        AddHandler prn.PrintPage, AddressOf Me._StampaComandaOperatore

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaComandaOperatore

        prn.Dispose()

    End Sub

    Public Sub StampaDocumento(ByVal Doc As Ricavo,
                               Optional ByVal FormatoPDF As Boolean = False)
        ' Try
        _Doc = Doc
        _FormatoPDF = FormatoPDF
        Dim prn As New Printing.PrintDocument

        prn.PrinterSettings.PrinterName = _PrinterName

        Dim tipoCarta As New System.Drawing.Printing.PaperSize
        tipoCarta.PaperName = Printing.PaperKind.A4

        prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

        '**********************
        '24/03/2016 per prevenire orientamento orizzontale
        prn.PrinterSettings.DefaultPageSettings.Landscape = False

        '24/01/2017 se stampa fiscale mando sul cassetto 2 solo per la stampante ir
        'If _PrinterName.ToLower.IndexOf("ricoh mp") <> -1 Then
        '    prn.PrinterSettings.DefaultPageSettings.PaperSource.SourceName = "Vassoio 2"
        'End If

        'prn.PrinterSettings.DefaultPageSettings.PaperSource.
        'prn.PrinterSettings.PaperSource
        '**********************

        'Dim tipoCarta As New System.Drawing.Printing.PaperSize

        'tipoCarta.PaperName = Printing.PaperKind.GermanStandardFanfold.ToString
        'tipoCarta.RawKind = Printing.PaperKind.GermanStandardFanfold
        'tipoCarta.Width = 900
        'tipoCarta.Height = 1300

        'prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

        Dim NomeFat As String = Doc.AnnoRiferimento & "-" & Doc.Numero.ToString("0000")


        If Doc.Tipo = enTipoDocumento.DDT Then
            NomeFat = NomeFat & "-DDT"
        End If

        If _FormatoPDF Then
            'qui devo cancellare il file precedente per essere sicuro che sia sovrascritto 
            Dim PathExist As String = FormerPath.PathFatture(Doc.IdAzienda) & NomeFat & ".pdf"

            If System.IO.File.Exists(PathExist) Then
                Try
                    System.IO.File.Delete(PathExist)
                Catch ex As Exception

                End Try
            End If

            'qui setto il profilo sulla giusta cartella 

            'Try
            '    Dim PathPdf As String = "Z:\\fatture\\" & Doc.IdAzienda & "\\"
            '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\PDFCreator.net\Settings\ConversionProfiles\0\AutoSave", "TargetDirectory", PathPdf)
            'Catch ex As Exception

            'End Try
            'prn.PrinterSettings.PrintFileName = PathExist
            'prn.PrinterSettings.PrintFileName = Doc.IdAzienda
            'prn.PrinterSettings.PrintFileName = Doc.IdAzienda
            'prn.
            prn.DocumentName = Doc.IdAzienda & "_" & NomeFat
            'prn.PrinterSettings.PrintToFile = True
        Else
            prn.DocumentName = NomeFat

        End If
        'prn.DocumentName = NomeFat

        'prn.DocumentName = NomeFat

        If Doc.Tipo = enTipoDocumento.Preventivo Then
            prn.PrinterSettings.Copies = 1
        Else
            prn.PrinterSettings.Copies = NumCopieDocFiscale
        End If

        AddHandler prn.PrintPage, AddressOf Me._StampaDocumento

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaDocumento

        prn.Dispose()
        ' Catch ex As Exception

        'End Try
    End Sub

    Public Sub StampaEtichettaBusta(L As List(Of IVoceRubricaG))
        ' Try
        Dim prn As New Printing.PrintDocument

        prn.PrinterSettings.PrinterName = _PrinterName

        Dim tipoCarta As New System.Drawing.Printing.PaperSize

        tipoCarta.PaperName = Printing.PaperKind.Standard9x11.ToString
        tipoCarta.RawKind = Printing.PaperKind.Standard9x11
        tipoCarta.Width = 600
        tipoCarta.Height = 200

        prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

        prn.DocumentName = "Stampa Etichetta"
        LEtichetteBuste = L

        AddHandler prn.PrintPage, AddressOf Me._StampaEtichettaBustaEx

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaEtichettaBustaEx

        prn.Dispose()
        ' Catch ex As Exception

        'End Try
    End Sub

    Public Sub StampaEtichettaBusta(Dt As DataTable)
        ' Try
        Dim prn As New Printing.PrintDocument

        prn.PrinterSettings.PrinterName = _PrinterName

        Dim tipoCarta As New System.Drawing.Printing.PaperSize

        tipoCarta.PaperName = Printing.PaperKind.Standard9x11.ToString
        tipoCarta.RawKind = Printing.PaperKind.Standard9x11
        tipoCarta.Width = 600
        tipoCarta.Height = 200

        prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

        prn.DocumentName = "Stampa Etichetta"
        DtEtichetteBuste = Dt

        AddHandler prn.PrintPage, AddressOf Me._StampaEtichettaBusta

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaEtichettaBusta

        prn.Dispose()
        ' Catch ex As Exception

        'End Try
    End Sub

    Public Sub StampaPromemoria(P As Promemoria)
        ' Try
        _P = P
        Dim prn As New Printing.PrintDocument

        prn.PrinterSettings.PrinterName = _PrinterName


        prn.DocumentName = "Stampa Promemoria"

        AddHandler prn.PrintPage, AddressOf Me._StampaPromemoria

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaPromemoria

        prn.Dispose()
        ' Catch ex As Exception

        'End Try
    End Sub

    Public Sub StampaReticolo(Optional PrinterName As String = "")
        Try
            Dim prn As New Printing.PrintDocument

            If PrinterName.Length = 0 Then
                Dim prin As New System.Windows.Forms.PrintDialog
                prin.ShowDialog()
                If prin.PrinterSettings.PrinterName.Length Then prn.PrinterSettings.PrinterName = prin.PrinterSettings.PrinterName
            Else
                prn.PrinterSettings.PrinterName = PrinterName
            End If

            prn.DocumentName = "Stampa Reticolo"

            Dim tipoCarta As New System.Drawing.Printing.PaperSize

            tipoCarta.PaperName = Printing.PaperKind.GermanStandardFanfold.ToString
            tipoCarta.RawKind = Printing.PaperKind.GermanStandardFanfold
            tipoCarta.Width = 900
            tipoCarta.Height = 1300
            prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta


            AddHandler prn.PrintPage, AddressOf Me._StampaReticolo

            prn.Print()

            RemoveHandler prn.PrintPage, AddressOf Me._StampaReticolo

            prn.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub StampaEtichetteScatola() 'ByVal IdCons As Integer)
        Try

            _Cons = New ConsegnaProgrammata
            _Cons.Read(IdCons)

            Dim prn As New Printing.PrintDocument

            '_NumeroColli = _Ord.GetNumColli
            _NumCollo = 1
            _NumeroColli = 1

            prn.PrinterSettings.PrinterName = _PrinterName

            prn.DocumentName = "Stampa Etichetta Scatola"

            AddHandler prn.PrintPage, AddressOf Me._StampaEtichettaScatola

            prn.Print()

            RemoveHandler prn.PrintPage, AddressOf Me._StampaEtichettaScatola

            prn.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub StampaEtichetteConsegna() 'ByVal IdCons As Integer)
        Try

            _Cons = New ConsegnaProgrammata
            _Cons.Read(IdCons)

            Dim prn As New Printing.PrintDocument

            '_NumeroColli = _Ord.GetNumColli
            _NumeroColli = _Cons.NumColli

            prn.PrinterSettings.PrinterName = _PrinterName

            prn.DocumentName = "Stampa Etichette"

            For _NumCollo = 1 To _NumeroColli

                AddHandler prn.PrintPage, AddressOf Me._StampaEtichetteConsegna

                prn.Print()

                RemoveHandler prn.PrintPage, AddressOf Me._StampaEtichetteConsegna

            Next

            prn.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub StampaBarcodeFattura(Doc As Ricavo)

        _Doc = Doc

        Dim prn As New Printing.PrintDocument

        prn.PrinterSettings.PrinterName = _PrinterName

        prn.DocumentName = "#" & Doc.AnnoRiferimento & "-" & Doc.Numero.ToString("0000")

        AddHandler prn.PrintPage, AddressOf Me._StampaBarcodeFattura

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaBarcodeFattura

        prn.Dispose()

    End Sub

    Public Sub StampaBarcode(Barcode As String)
        Try

            Dim prn As New Printing.PrintDocument

            prn.PrinterSettings.PrinterName = _PrinterName

            prn.DocumentName = "Stampa Barcode"
            _Barcode = Barcode

            AddHandler prn.PrintPage, AddressOf Me._StampaBarcode

            prn.Print()

            RemoveHandler prn.PrintPage, AddressOf Me._StampaBarcode

            prn.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub StampaMantieniCampione() 'ByVal IdOrd As Integer, NumeroColli As Integer)
        Try

            _Ord = New Ordine
            _Ord.Read(IdOrd)

            If _Ord.ConsegnaAssociata Is Nothing Then
                _Cons = New ConsegnaProgrammata
            Else
                _Cons = _Ord.ConsegnaAssociata
            End If

            Dim prn As New Printing.PrintDocument

            prn.PrinterSettings.PrinterName = _PrinterName

            prn.DocumentName = "Stampa Mantieni Campione"

            AddHandler prn.PrintPage, AddressOf Me._StampaMantieniCampione

            prn.Print()

            RemoveHandler prn.PrintPage, AddressOf Me._StampaMantieniCampione

            prn.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub StampaEtichetteOrdine() 'ByVal IdOrd As Integer, NumeroColli As Integer)
        Try

            _Ord = New Ordine
            _Ord.Read(IdOrd)

            If _Ord.ConsegnaAssociata Is Nothing Then
                _Cons = New ConsegnaProgrammata
            Else
                _Cons = _Ord.ConsegnaAssociata
            End If

            Dim prn As New Printing.PrintDocument

            '_NumeroColli = _Ord.GetNumColli
            _NumeroColli = NumColli

            prn.PrinterSettings.PrinterName = _PrinterName

            prn.DefaultPageSettings.PrinterResolution.Kind = Printing.PrinterResolutionKind.High

            prn.DocumentName = "Stampa Etichette"

            For Me._NumCollo = 1 To _NumeroColli

                AddHandler prn.PrintPage, AddressOf Me._StampaEtichetteOrdine

                prn.Print()

                RemoveHandler prn.PrintPage, AddressOf Me._StampaEtichetteOrdine

            Next

            If _Ord.MantieniCampione = enSiNo.Si Then

                AddHandler prn.PrintPage, AddressOf Me._StampaMantieniCampione

                prn.Print()

                RemoveHandler prn.PrintPage, AddressOf Me._StampaMantieniCampione

            End If

            prn.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub StampaEtichettaGruppo(ByVal IdOrd As Integer)
        Try

            _Ord = New Ordine
            _Ord.Read(IdOrd)

            Dim prn As New Printing.PrintDocument

            _NumeroColli = _Ord.GetNumColli

            prn.PrinterSettings.PrinterName = _PrinterName

            prn.DocumentName = "Stampa Etichetta Gruppo"

            ' For _NumCollo = 1 To _NumeroColli

            AddHandler prn.PrintPage, AddressOf Me._StampaEtichettaGruppo

            prn.Print()

            RemoveHandler prn.PrintPage, AddressOf Me._StampaEtichettaGruppo

            'Next

            prn.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub StampaFont()

        Dim prn As New Printing.PrintDocument

        prn.PrinterSettings.PrinterName = _PrinterName

        prn.DocumentName = "Stampa Font"

        AddHandler prn.PrintPage, AddressOf Me._StampaFont

        prn.Print()

        RemoveHandler prn.PrintPage, AddressOf Me._StampaFont

        prn.Dispose()

    End Sub

    Private Sub _StampaFont(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim installed_fonts As New System.Drawing.Text.InstalledFontCollection

        ' Get an array of the system's font familiies.
        Dim font_families() As FontFamily = installed_fonts.Families()


        ' Display the font families.
        Dim y As Integer = 0
        Dim myFont As New Font("Courier new", 8)

        args.Graphics.DrawString("8: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 20)

        myFont = New Font("Courier new", 9)
        args.Graphics.DrawString("9: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 80)

        myFont = New Font("Courier new", 10)
        args.Graphics.DrawString("10: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 120)

        myFont = New Font("Courier new", 11)
        args.Graphics.DrawString("11: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 180)

        myFont = New Font("Courier new", 12)
        args.Graphics.DrawString("12: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 240)


        'For Each font_family As FontFamily In font_families
        '    'If font_family.Name.StartsWith("Cou") Then
        '    Try
        '        If font_families.IsFixedSize Then
        '            Dim myFontStampa As New Font(font_family.Name, 10, FontStyle.Regular)

        '            args.Graphics.DrawString(font_family.Name & ": abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFontStampa, Brushes.Black, 0, y)
        '        End If

        '    Catch ex As Exception

        '    End Try

        '    y += 15
        '    ' args.HasMorePages = True
        '    ' End If

        'Next font_family

    End Sub

    Private Sub _StampaReticolo(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim myFont As New Font("Arial", 8)
        Dim MgX As Integer = MargineXEtichette
        Dim MgY As Integer = MargineYEtichette

        Dim TestoDaStampare As String = ""

        myFont = New Font("Arial", 8)

        ' TestoDaStampare = "prova"

        '   args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

        Dim x1 As Integer = 0
        Dim y1 As Integer = 0

        For x1 = 0 To 750 Step 25
            If x1 Mod 50 Then
                args.Graphics.DrawLine(Pens.LightGray, x1, 0, x1, 1300)
            Else
                args.Graphics.DrawString(x1, New Font(myFont, FontStyle.Regular), Brushes.Black, x1, 0)
                args.Graphics.DrawLine(Pens.Black, x1, 0, x1, 1300)
            End If
        Next

        For y1 = 0 To 1100 Step 25
            If y1 Mod 50 Then
                args.Graphics.DrawLine(Pens.LightGray, 0, y1, 900, y1)
            Else
                args.Graphics.DrawString(y1, New Font(myFont, FontStyle.Regular), Brushes.Black, 0, y1)
                args.Graphics.DrawLine(Pens.Black, 0, y1, 900, y1)
            End If
        Next


        args.HasMorePages = False

    End Sub

    Private Sub StampaIntestazione(ByVal args As Printing.PrintPageEventArgs)

        Dim MYfontS As Font = New Font("Courier New", 10, FontStyle.Regular)
        Dim MYfontN As Font = New Font("Courier New", 11, FontStyle.Regular)

        'If _FormatoPDF Then
        '    MYfont = New Font("Courier New", 8, FontStyle.Regular)
        'Else
        '    MYfont = New Font("Courier New", 11, FontStyle.Regular)
        'End If

        Dim MgX As Integer = MargineXFatture
        Dim MgY As Integer = MargineYFatture

        'MgX += 50

        Dim TestoDaStampare As String = ""
        Dim PuntoScrittura As Integer = 0

        If _FormatoPDF Then
            If _Doc.Tipo <> enTipoDocumento.Preventivo Then
                Try
                    Dim Anteprima As Image

                    If _Doc.IdAzienda = MgrAziende.IdAziende.AziendaSnc Then
                        Anteprima = My.Resources.moduloDocumentoFiscalesnc
                    Else
                        Anteprima = My.Resources.moduloDocumentofiscalesrl
                    End If

                    args.Graphics.DrawImage(Anteprima, 0, 0, args.PageBounds.Width, args.PageBounds.Height) '1120
                    'args.Graphics.DrawImage(Anteprima, 0, 0, 810, 1146) '1120

                    Anteprima = Nothing
                    'MgX = 0
                    'MgY = 78
                    'MgY += 15
                    MgY += 25
                Catch ex As Exception

                End Try
            End If

        End If

        MgY += 62 'modifica per modulo nuovo

        If _Doc.Tipo = enTipoDocumento.Preventivo Then
            'qui stampo il codice a barre
            _StampaBarcodeFatturaReal(args)
        ElseIf _Doc.Tipo = enTipoDocumento.Fattura Or _Doc.Tipo = enTipoDocumento.FatturaRiepilogativa Or _Doc.Tipo = enTipoDocumento.NotaDiCredito Then
            'If _Email = False Then _StampaBarcodeFatturaReal(args, 300, 55)
            _StampaBarcodeFatturaReal(args, 300, 55)
        End If

        'intestazione
        TestoDaStampare = FormerLib.FormerHelper.Stringhe.SplittaByNumCaratteri(_Doc.pRagSoc, 30)
        'If _Doc.pRagSoc.Length > 30 Then
        '    TestoDaStampare = _Doc.pRagSoc.Substring(0, 30) & ControlChars.NewLine & _Doc.pRagSoc.Substring(30)
        'Else
        '    TestoDaStampare = _Doc.pRagSoc
        'End If

        TestoDaStampare &= ControlChars.NewLine & _Doc.pIndirizzo

        If FormerConst.Culture.CapEstero <> _Doc.pCap Then
            TestoDaStampare &= ControlChars.NewLine & _Doc.pCap & " " & _Doc.pCitta
        Else
            TestoDaStampare &= ControlChars.NewLine & _Doc.pCitta
        End If

        args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 465, MgY + 0)

        'descrizione documento
        Select Case _Doc.Tipo
            Case enTipoDocumento.DDT
                TestoDaStampare = "D.D.T."
            Case enTipoDocumento.Fattura
                TestoDaStampare = "FATTURA"
            Case enTipoDocumento.FatturaRiepilogativa
                TestoDaStampare = "FATTURA"
            Case enTipoDocumento.Preventivo
                TestoDaStampare = "PREVENTIVO"
            Case enTipoDocumento.NotaDiCredito
                TestoDaStampare = "NOTA DI CREDITO"
            Case enTipoDocumento.NotaDiDebito
                TestoDaStampare = "NOTA DI DEBITO"
            Case enTipoDocumento.AccontoAnticipoSuFattura
                TestoDaStampare = "ACCONTO/ANTICIPO SU FATTURA"
        End Select

        args.Graphics.DrawString(TestoDaStampare, MYfontS, Brushes.Black, MgX + 455, MgY + 100) '465

        TestoDaStampare = _Doc.Numero & "/" & _Doc.DataRicavo.Year
        'PuntoScrittura = 675 - (TestoDaStampare.Length * 10)
        PuntoScrittura = 675 - (TestoDaStampare.Length * 10) '680

        args.Graphics.DrawString(TestoDaStampare, MYfontS, Brushes.Black, MgX + PuntoScrittura, MgY + 100)

        TestoDaStampare = _Doc.DataRicavo.Day & "/" & _Doc.DataRicavo.Month & "/" & _Doc.DataRicavo.Year

        args.Graphics.DrawString(TestoDaStampare, MYfontS, Brushes.Black, MgX + 685, MgY + 100) '680

        'codice cliente
        TestoDaStampare = _Doc.IdRub
        args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 300, MgY + 150) '290

        Using Rub As New VoceRubrica
            Rub.Read(_Doc.IdRub)
            If _Doc.Tipo <> enTipoDocumento.Preventivo Then
                'partita iva

                'se c'e' il codice fiscale stampo pure quello 
                Dim CodFisc As String = Rub.CodFisc
                If _Doc.pIva.Length Then
                    TestoDaStampare = "P.I. " & _Doc.pIva
                ElseIf CodFisc.Length Then
                    TestoDaStampare = "C.F. " & CodFisc
                End If

                'args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 420, MgY + 140)
                args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 420, MgY + 150)
                'trasporto
                Using Corr As New Corriere
                    Corr.Read(_Doc.IdCorr)
                    TestoDaStampare = Corr.Descrizione
                    args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 255, MgY + IIf(_FormatoPDF, 175, 185)) 'era 365
                End Using
            Else
                'qui stiamo stampando un preventivo
                If Rub.Cellulare.Length Then
                    TestoDaStampare = "Cel. " & Rub.Cellulare & " " & IIf(Rub.CellulareRif.Length, "(" & Rub.CellulareRif & ")", String.Empty)
                    args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 440, MgY + 150)
                End If
            End If
        End Using

        'pagamento
        TestoDaStampare = _Doc.pPagamento.ToString

        If MgrFormerException.StampareDataScadenzaPagamento(_Doc) Then
            If _Doc.Idpagamento Then
                Dim tipoPagamento As New TipoPagamento
                tipoPagamento.Read(_Doc.Idpagamento)

                If tipoPagamento.ggToAdd Then
                    TestoDaStampare = "Scadenza: " & _Doc.Dataprevpagam.ToString("dd/MM/yyyy")
                End If

            End If
        End If

        'If TestoDaStampare <> "Alla consegna" Then
        '    TestoDaStampare = "Scadenza: " & _Doc.Dataprevpagam.ToString("dd/MM/yyyy")
        'End If

        'args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 15, MgY + 210)
        args.Graphics.DrawString(TestoDaStampare, MYfontS, Brushes.Black, MgX + 50, MgY + 215)


    End Sub

    Private Sub StampaFineDocumento(ByVal args As Printing.PrintPageEventArgs)
        Dim MYfontS As Font = New Font("Courier New", 10, FontStyle.Regular)
        Dim MYfontN As Font = New Font("Courier New", 11, FontStyle.Regular)

        Dim MgX As Integer = MargineXFatture
        Dim MgY As Integer = MargineYFatture
        Dim TestoDaStampare As String = ""
        Dim PuntoScrittura As Integer = 0

        If _FormatoPDF Then
            MgX = 25

            MgY += 20
        End If

        MgY += 85 'modifica per modulo nuovo

        'numcolli e peso
        If _Doc.Tipo = enTipoDocumento.DDT Or _Doc.Tipo = enTipoDocumento.Fattura Then

            TestoDaStampare = _Doc.NumColli
            args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 55, MgY + 935) '960

            TestoDaStampare = _Doc.Peso
            args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 130, MgY + 935)

        End If

        If _Doc.Tipo = enTipoDocumento.Fattura Or _Doc.Tipo = enTipoDocumento.FatturaRiepilogativa Or _Doc.Tipo = enTipoDocumento.NotaDiCredito Then

            TestoDaStampare = _Doc.PercIva.ToString & "%"
            args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 115, MgY + 900) '850

            TestoDaStampare = FormerHelper.Stringhe.FormattaPrezzo(_Doc.Importo)
            args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 240, MgY + 900)

            TestoDaStampare = FormerHelper.Stringhe.FormattaPrezzo(_Doc.Iva)
            args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 390, MgY + 900)

            TestoDaStampare = FormerHelper.Stringhe.FormattaPrezzo(_Doc.Totale)
            args.Graphics.DrawString(TestoDaStampare, MYfontN, Brushes.Black, MgX + 700, MgY + 900)

            Dim AnnotazioniDaConsegna As String = _Doc.AnnotazioniDaConsegna
            If AnnotazioniDaConsegna.Length Then
                TestoDaStampare = AnnotazioniDaConsegna
                args.Graphics.DrawString(TestoDaStampare, MYfontS, Brushes.Black, MgX + 200, MgY + 935)
            End If

        End If

        'indirizzo diverso di consegna
        If _Doc.pIndCons.Length Then
            TestoDaStampare = _Doc.pIndCons
            args.Graphics.DrawString(TestoDaStampare, MYfontS, Brushes.Black, MgX + 30, MgY + 1000) '15 - 1030
        End If

    End Sub

    Private Sub _StampaConsegnaOrdini(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim MYfont As Font

        MYfont = New Font("Courier New", 8, FontStyle.Regular)

        Dim MgX As Integer = 0
        Dim MgY As Integer = 0

        Dim TestoDaStampare As String = ""
        Dim PuntoScrittura As Integer = 0
        Dim yRiga As Integer = MgX

        TestoDaStampare = StrConv(Now.ToString("dddd dd/MM/yyyy hh:mm.ss"), VbStrConv.ProperCase)

        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

        yRiga += 15

        TestoDaStampare = _Cp.Cliente.RagSocNome

        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

        TestoDaStampare = "****************************************"
        yRiga += 15
        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

        Dim TotaleImp As Integer = 0

        For Each o As Ordine In _Cp.ListaOrdini
            Dim Descr As String = o.Prodotto.Descrizione
            If Descr.Length > 25 Then
                Descr = o.Prodotto.Descrizione.Substring(0, 25)
            End If
            yRiga += 15

            Dim idOrd As String = o.IdOrd
            If idOrd.Length = 5 Then idOrd = " " & idOrd
            TestoDaStampare = idOrd & " " & Descr & " € " & FormerHelper.Stringhe.FormattaPrezzo(o.TotaleImponibile)
            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)
            TotaleImp += o.TotaleImponibile
        Next
        TestoDaStampare = "****************************************"
        yRiga += 15
        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

        TestoDaStampare = "TOTALE € " & FormerHelper.Stringhe.FormattaPrezzo(TotaleImp) & " + iva"
        yRiga += 15
        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

    End Sub

    Private Sub _StampaEtichettaCustom(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim Buffer As String = String.Empty

        Dim DimensioneMin As Integer = 6
        Dim DimensioneMax As Integer = 50
        Dim FontToUse As String = "Consolas"
        Dim WidthMM As Single = _EtichettaCustom.WidthMM
        Dim HeightMM As Single = _EtichettaCustom.HeightMM

        Dim AltezzaStart As Integer = 0
        Dim LarghezzaPoint As Integer = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(WidthMM)

        Dim LarghezzaPerCar As Integer = 0

        Dim MYfont As Font

        If _EtichettaCustom.Riga1.Length Then

            LarghezzaPerCar = Math.Floor(LarghezzaPoint / _EtichettaCustom.Riga1.Length) * 1.58

            MYfont = New Font(FontToUse, LarghezzaPerCar, FontStyle.Regular)
            args.Graphics.DrawString(_EtichettaCustom.Riga1, MYfont, Brushes.Black, 0, AltezzaStart)
            AltezzaStart += (LarghezzaPerCar * 1.3)

        End If

        If _EtichettaCustom.Riga2.Length Then

            LarghezzaPerCar = Math.Floor(LarghezzaPoint / _EtichettaCustom.Riga2.Length) * 1.57

            If LarghezzaPerCar < DimensioneMin Then
                LarghezzaPerCar = DimensioneMin
            ElseIf LarghezzaPerCar > DimensioneMax Then
                LarghezzaPerCar = DimensioneMax
            End If

            If _EtichettaCustom.Riga1.Length = 0 And _EtichettaCustom.Riga3.Length = 0 Then
                'qui vuole centrare
                AltezzaStart = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(HeightMM) / 2 '+ LarghezzaPerCar * 1.3

            End If

            MYfont = New Font(FontToUse, LarghezzaPerCar, FontStyle.Regular)
            args.Graphics.DrawString(_EtichettaCustom.Riga2, MYfont, Brushes.Black, 0, AltezzaStart)



            AltezzaStart += (LarghezzaPerCar * 1.3)
        End If

        If _EtichettaCustom.Riga3.Length Then

            LarghezzaPerCar = Math.Floor(LarghezzaPoint / _EtichettaCustom.Riga3.Length) * 1.57

            If LarghezzaPerCar < DimensioneMin Then
                LarghezzaPerCar = DimensioneMin
            ElseIf LarghezzaPerCar > DimensioneMax Then
                LarghezzaPerCar = DimensioneMax
            End If

            MYfont = New Font(FontToUse, LarghezzaPerCar, FontStyle.Regular)
            args.Graphics.DrawString(_EtichettaCustom.Riga3, MYfont, Brushes.Black, 0, AltezzaStart)

        End If

        args.HasMorePages = False

    End Sub

    Private Sub _StampaEtichettaBustaEx(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)
        If LEtichetteBuste.Count Then
            Dim dr As IVoceRubricaG = LEtichetteBuste(IndiceEtichettaBusta)
            Dim Buffer As String = String.Empty

            Buffer = dr.NominativoG & ControlChars.NewLine & dr.Indirizzo & ControlChars.NewLine & dr.Cap & " - " & dr.Citta

            Dim MYfont As Font
            MYfont = New Font("Courier New", 11, FontStyle.Regular)
            args.Graphics.DrawString(Buffer, MYfont, Brushes.Black, 0, 0)

            If IndiceEtichettaBusta = LEtichetteBuste.Count - 1 Then
                args.HasMorePages = False
            Else
                args.HasMorePages = True
            End If

            IndiceEtichettaBusta += 1
        End If

    End Sub

    Private Sub _StampaEtichettaBusta(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim dr As DataRow = DtEtichetteBuste(IndiceEtichettaBusta)
        Dim Buffer As String = String.Empty
        Dim IdRub As Integer = dr("Id")
        Dim v As New VoceRubrica
        v.Read(IdRub)

        Buffer = v.RagSocNome & ControlChars.NewLine & v.Indirizzo & ControlChars.NewLine & v.CAP & " - " & v.Citta

        Dim MYfont As Font
        MYfont = New Font("Courier New", 11, FontStyle.Regular)
        args.Graphics.DrawString(Buffer, MYfont, Brushes.Black, 0, 0)

        If IndiceEtichettaBusta = DtEtichetteBuste.Rows.Count - 1 Then
            args.HasMorePages = False
        Else
            args.HasMorePages = True
        End If

        IndiceEtichettaBusta += 1

    End Sub

    Private Sub _StampaBarcodeFatturaReal(ByRef args As Printing.PrintPageEventArgs, Optional PosX As Integer = 0, Optional PosY As Integer = 0)

        'qui stampo effettivamente il barcode della fattura
        Dim myFont As New Font("Arial", 10)
        Dim MgX As Integer = MargineXEtichette
        Dim MgY As Integer = MargineYEtichette

        Dim TestoDaStampare As String = String.Empty
        'Dim AltezzaStampa As Integer = 0
        'If IncludiIntestazione Then
        '    Using Cliente As New VoceRubrica

        '        Cliente.Read(_Doc.IdRub)

        '        TestoDaStampare = Cliente.RagSocNome
        '    End Using

        '    args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

        '    myFont = New Font("Arial", 9)

        '    TestoDaStampare = _Doc.Numero & "/" & _Doc.AnnoRiferimento

        '    args.Graphics.DrawString(TestoDaStampare, myFont, Brushes.Black, MgX + 0, MgY + 15)
        '    AltezzaStampa = 30
        'End If

        myFont = New Font("Code EAN13", 36)

        Dim CodiceDaStampare As String = "8" & Format(_Doc.IdRicavo, "00000000000")

        If CodiceDaStampare.Length = 12 Then
            CodiceDaStampare = FormerHelper.EAN13.ToEAN13(CodiceDaStampare)
        End If

        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + PosX, MgY + PosY) '170

    End Sub

    Private Sub _StampaBarcodeFattura(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        _StampaBarcodeFatturaReal(args)

        args.HasMorePages = False

    End Sub

    Private Sub _StampaPreventivoMail(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim MYf As Font = New Font("Tahoma", 11, FontStyle.Regular)
        Dim MYfBody As Font = New Font("Tahoma", 12, FontStyle.Regular)
        Dim MYfB As Font = New Font("Tahoma", 11, FontStyle.Bold)
        Dim MYfTitolo As Font = New Font("Tahoma", 16, FontStyle.Bold)

        Dim TestoDaStampare As String = ""
        Dim PuntoScrittura As Integer = 0

        args.Graphics.DrawString(_Mail.Titolo,
                                 MYfTitolo,
                                 Brushes.Black, 50, 50) '155

        args.Graphics.DrawLine(Pens.Black, 50, 80, 700, 80)
        args.Graphics.DrawString("Da: ", MYfB, Brushes.Black, 50, 90)

        Dim Mittente As String = String.Empty

        If _Mail.IdUtFormer Then
            Using U As New Utente
                U.Read(_Mail.IdUtFormer)
                Mittente = U.Login & " <" & FormerConfig.FConfiguration.PreventiviMail.EmailSender & ">"
            End Using
        Else
            If _Mail.IdRub Then
                Mittente = _Mail.VoceRubrica.RagSocNome & " "
            End If

            Mittente &= "<" & _Mail.Mittente & ">"
        End If

        args.Graphics.DrawString(Mittente, MYf, Brushes.Black, 100, 90)

        args.Graphics.DrawString("Data: ", MYfB, Brushes.Black, 50, 120)
        args.Graphics.DrawString(_Mail.DataRif.ToString("dd/MM/yyyy HH:mm.ss"), MYf, Brushes.Black, 100, 120)
        args.Graphics.DrawLine(Pens.Gray, 50, 145, 700, 145)

        args.Graphics.DrawString(_Mail.Testo, MYfBody, Brushes.Black, 50, 160)

    End Sub

    Private Sub _StampaComandaOperatore(ByVal sender As Object,
                                        ByVal args As Printing.PrintPageEventArgs)

        Dim MYf As Font = New Font("Arial", 16, FontStyle.Regular)
        Dim MYfTitolo As Font = New Font("Arial", 28, FontStyle.Bold)
        Dim MYfSmall As Font = New Font("Arial", 14, FontStyle.Regular)

        Dim TestoDaStampare As String = ""
        Dim PuntoScrittura As Integer = 0
        Dim CoordinataY As Integer = 0
        args.Graphics.DrawString(_M.NomeDest.ToUpper,
                                 MYfTitolo,
                                 Brushes.Black, 0, CoordinataY)

        CoordinataY += 40
        args.Graphics.DrawLine(Pens.Black, 0, CoordinataY, 275, CoordinataY)
        CoordinataY += 5
        args.Graphics.DrawString(_M.DataInsFormat,
                                 MYfSmall,
                                 Brushes.Black, 0, CoordinataY)
        CoordinataY += 20
        args.Graphics.DrawString("inviato da " & _M.NomeMitt,
                                 MYfSmall,
                                 Brushes.Black, 0, CoordinataY)
        CoordinataY += 25
        args.Graphics.DrawLine(Pens.Black, 0, CoordinataY, 275, CoordinataY)
        CoordinataY += 10
        args.Graphics.DrawString(FormerLib.FormerHelper.Stringhe.SplittaByNumCaratteri(_M.Testo, 24),
                                 MYfSmall,
                                 Brushes.Black, 0, CoordinataY)

    End Sub

    Private Sub _StampaDocumento(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        '_doc e' una variabile privata del modulo di stampa
        Dim MYfont As Font

        Dim MYfontCondensed As Font = New Font("Courier Condensed", 11, FontStyle.Regular)

        If _FormatoPDF Then
            MYfont = New Font("Courier New", 8, FontStyle.Regular)
        Else
            MYfont = New Font("Courier New", 11, FontStyle.Regular)
        End If

        Dim MgX As Integer = MargineXFatture
        Dim MgY As Integer = MargineYFatture

        If _FormatoPDF Then
            MgY += 5
        End If

        MgY += 70 'modifica per modulo nuovo

        'args.PageSettings.PaperSize.PaperName = "ARCH A"
        'args.PageSettings.PaperSize.Kind = Printing.PaperKind.Custom
        'args.PageSettings.PaperSize.Width = 1000
        'Dim prova As System.Drawing.Printing.PrinterResolutionKind = Printing.PrinterResolutionKind.Low
        'args.PageSettings.PrinterResolution=

        Dim TestoDaStampare As String = ""
        Dim PuntoScrittura As Integer = 0

        StampaIntestazione(args)

        'NUMERO PAGINA
        _NumeroPagina += 1
        TestoDaStampare = _NumeroPagina
        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 750, MgY + IIf(_FormatoPDF, 160, 142)) '775

        'CORPO DOCUMENTO

        Dim VociFat As New cVociFatColl, Dt As DataTable, IsRiepilogativa As Boolean = False

        If _Doc.Tipo = enTipoDocumento.FatturaRiepilogativa Then IsRiepilogativa = True

        Dt = VociFat.Lista(_Doc.IdRicavo, IsRiepilogativa)

        Dim Dr As DataRow, yRiga As Integer = 260
        Dim IdVecchioDDT As Integer = 0, IdCurrentDDT As Integer = 0

        Dim ContatoreInterno As Integer = 0

        For Each Dr In Dt.Rows
            If ContatoreInterno = _ContatoreRiga Then
                If _Doc.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                    IdCurrentDDT = Dr("iddoc")
                    If IdCurrentDDT <> IdVecchioDDT Then

                        If IdVecchioDDT <> 0 Then yRiga += 15
                        'ristampo l'intestazione del doc
                        Dim Docume As New cContabRicavi
                        Docume.Read(Dr("iddoc"))

                        TestoDaStampare = "Riferimento DDT Numero " & Docume.Numero & " del " & Docume.DataRicavo.ToShortDateString

                        _SpeseConsegnaCumulative += Docume.CostoCorr

                        Docume = Nothing

                        args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, MgX + 5, MgY + yRiga)
                        yRiga += 30
                        IdVecchioDDT = IdCurrentDDT
                    End If
                ElseIf _Doc.Tipo = enTipoDocumento.NotaDiCredito Then
                    If _Doc.IdFatturaNotaDiCredito Then
                        Using RRif As New Ricavo
                            RRif.Read(_Doc.IdFatturaNotaDiCredito)
                            TestoDaStampare = "Rif. Fattura " & RRif.NumeroCompleto & " del " & RRif.DataRicavo.ToShortDateString

                            args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, MgX + 5, MgY + yRiga)
                            yRiga += 30
                        End Using
                    End If

                End If

                Dim Codice As String = Dr("Codice").ToString
                If Codice.Length > 10 Then
                    Codice = Codice.Substring(0, 10)
                End If
                TestoDaStampare = Codice

                '                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, IIf(_Email, 20, 0) + MgX + 5, MgY + yRiga)
                args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, IIf(_FormatoPDF, 20, 0) + MgX + 30, MgY + yRiga) '+35

                '*********************************
                'qui devo stampare la descrizione su piu righe splittate su 34 caratteri
                '*********************************
                Dim NewYRiga As Integer = 0
                NewYRiga = yRiga

                Dim DescrRiga As String = Dr("Descrizione").ToString

                Dim RigaCustom As Integer = 0

                Try
                    RigaCustom = Dr("Custom")
                Catch ex As Exception

                End Try


                If RigaCustom = enSiNo.Si Then
                    'DescrRiga = PulisciRigaFatt(DescrRiga)
                    'questo non serve perche la riga è gia inizializzata
                Else
                    DescrRiga = FormerLib.FormerHelper.Finanziarie.PulisciRigaFattura(DescrRiga)
                End If

                Dim TestoSuPiuRighe As String() = SplittaTesto(DescrRiga)

                For Each StringaSing As String In TestoSuPiuRighe
                    args.Graphics.DrawString(StringaSing, MYfontCondensed, Brushes.Black, IIf(_FormatoPDF, 30, 0) + MgX + 140, MgY + NewYRiga) '155
                    'args.Graphics.DrawString(StringaSing, MYfont, Brushes.Black, IIf(_Email, 30, 0) + MgX + 105, MgY + NewYRiga)
                    NewYRiga += 15
                Next

                TestoDaStampare = Dr("Qta").ToString
                'PuntoScrittura = 515 - (TestoDaStampare.Length * 10)
                'PuntoScrittura = 530 - (TestoDaStampare.Length * 10)
                PuntoScrittura = 520 - (TestoDaStampare.Length * 10)
                args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, MgX + PuntoScrittura, MgY + yRiga)

                TestoDaStampare = "Ord. " & Dr("IdOrd").ToString
                args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, MgX + IIf(_FormatoPDF, 555, 550), MgY + yRiga) '570

                If _Doc.Tipo <> enTipoDocumento.DDT Then

                    TestoDaStampare = FormerHelper.Stringhe.FormattaPrezzo(Dr("importo").ToString)
                    'PuntoScrittura = 745 - (TestoDaStampare.Length * 10)
                    PuntoScrittura = 735 - (TestoDaStampare.Length * 10)
                    args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, MgX + PuntoScrittura, MgY + yRiga)

                End If

                yRiga = NewYRiga

                ContatoreInterno += 1
                _ContatoreRiga += 1

                If yRiga > 830 Then 'IMPOSTAZIONE FINE SEZIONE CENTRALE era 730
                    'qui devo controllare se ci sono altre righe prima di andare avanti
                    If _ContatoreRiga < Dt.Rows.Count Then

                        'qui devo scrivere segue
                        TestoDaStampare = "Segue..."
                        args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, MgX + 225, MgY + yRiga)

                        args.HasMorePages = True

                        Exit For
                    Else
                        args.HasMorePages = True
                    End If


                Else
                    args.HasMorePages = False

                End If
            Else
                ContatoreInterno += 1
            End If

        Next

        'COSTI DI CONSEGNA
        If _Doc.CostoCorr Then

            TestoDaStampare = "Consegna"

            Dim C As New Corriere
            C.Read(_Doc.IdCorr)

            If C.TipoCorriere = enTipoCorriere.PortoAssegnato Then
                TestoDaStampare = "Spese di Imballo"
            End If

            C = Nothing

            args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, IIf(_FormatoPDF, 30, 0) + MgX + 155, MgY + yRiga)
            'args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, IIf(_Email, 30, 0) + MgX + 105, MgY + yRiga)

            If _Doc.Tipo <> enTipoDocumento.DDT Then
                TestoDaStampare = FormerHelper.Stringhe.FormattaPrezzo(_Doc.CostoCorr.ToString)

                PuntoScrittura = 745 - (TestoDaStampare.Length * 10)
                args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, MgX + PuntoScrittura, MgY + yRiga)
                yRiga += 15

            End If

        End If
        '
        yRiga += 30

        If args.HasMorePages = False Then
            ' qui devo anche calcolare se si tratta di una fattura riepilogativa i costi di consegna contenuti nei ddt
            'solo sull'ultima pagina
            If _Doc.Tipo = enTipoDocumento.FatturaRiepilogativa And _SpeseConsegnaCumulative <> 0 Then

                TestoDaStampare = "Consegna/e"
                args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, MgX + 105, MgY + yRiga)

                If _Doc.Tipo <> enTipoDocumento.DDT Then
                    TestoDaStampare = FormerHelper.Stringhe.FormattaPrezzo(_SpeseConsegnaCumulative.ToString)

                    PuntoScrittura = 765 - (TestoDaStampare.Length * 10)
                    args.Graphics.DrawString(TestoDaStampare, MYfontCondensed, Brushes.Black, MgX + PuntoScrittura, MgY + yRiga)
                    yRiga += 15

                End If

            End If

            'NOTE DI DOCUMENTO
            If _Doc.Tipo = enTipoDocumento.DDT Then
                'args.Graphics.DrawLine(Pens.Black, 25, yRiga, 700, yRiga)
                yRiga += 15
                TestoDaStampare = "D.D.T."
                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 350, MgY + yRiga)
            ElseIf _Doc.Tipo = enTipoDocumento.Preventivo Then
                ' args.Graphics.DrawLine(Pens.Black, 25, yRiga, 700, yRiga)
                yRiga += 15
                TestoDaStampare = "IL PRESENTE PREVENTIVO E' VALIDO 30 GIORNI"
                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 150, MgY + yRiga)
                yRiga += 30
                TestoDaStampare = "TOTALE " & FormerHelper.Stringhe.FormattaPrezzo(_Doc.Importo)
                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 150, MgY + yRiga)
            End If

            StampaFineDocumento(args)

        End If

    End Sub

    Private Function SplittaTesto(Descr As String, Optional Length As Integer = 44) As String()

        Dim Ris(0) As String
        Dim inizio As Integer = 0
        Dim GrandArr As Integer = Decimal.Truncate(Descr.Length / Length) + IIf(Descr.Length = Length, 0, 1)
        Array.Resize(Ris, GrandArr)
        Dim Cont As Integer = 0
        Do Until Cont = GrandArr

            If inizio + Length > Descr.Length Then Length = Descr.Length - inizio
            Dim Testo As String = ""
            If Length Then
                Testo = Descr.Substring(inizio, Length)
                Ris(Cont) = Testo
            Else
                If Cont = 0 Then Ris(0) = ""
            End If

            Cont += 1
            inizio += Length

        Loop

        Return Ris

    End Function

    Private Sub _StampaEtichettaScatola(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim myFont As New Font("Arial", 8)
        Dim MgX As Integer = MargineXEtichette
        Dim MgY As Integer = MargineYEtichette

        Dim TestoDaStampare As String
        myFont = New Font("Arial", 10)

        Dim Cliente As New VoceRubrica

        Cliente.Read(_Cons.IdRub)

        TestoDaStampare = Cliente.RagSocNome

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

        myFont = New Font("Arial", 9)

        If _Cons.IdIndirizzo = 0 Then
            TestoDaStampare = Cliente.Indirizzo & vbNewLine & Cliente.CAP & " " & Cliente.Citta
        Else
            Dim I As New Indirizzo
            I.Read(_Cons.IdIndirizzo)
            TestoDaStampare = I.Indirizzo & vbNewLine & I.Cap & " " & I.Citta
            I = Nothing
        End If

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 15)

        myFont = New Font("Arial", 8)

        TestoDaStampare = "Tel. " & Cliente.Tel

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 42)

        Cliente = Nothing

        args.Graphics.DrawLine(Pens.Black, 0, 55, 240, 55)

        myFont = New Font("Arial", 8)

        TestoDaStampare = "Scatola: " & IdScatola

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 60)

        myFont = New Font("Code EAN13", 30)

        Dim CodiceDaStampare As String = "9" & FormerHelper.Stringhe.FormattaConZeri(IdScatola, 7) & FormerHelper.Stringhe.FormattaConZeri(_NumCollo, 4)

        CodiceDaStampare = FormerHelper.EAN13.ToEAN13(CodiceDaStampare)

        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

        'myFont = New Font("FF Ean13", 12) 'FF EAN

        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 80, MgY + 150) '170

        ' myFont = New Font("Arial", 8)
        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 160, MgY + 180)

        Try
            Dim Anteprima As Image = My.Resources.icoScatola
            'Anteprima = Image.FromFile(_Ord.File)
            args.Graphics.DrawImage(Anteprima, MgX + 150, MgY + 60) ', 70, 95)

            Anteprima = Nothing
        Catch ex As Exception

        End Try


        args.HasMorePages = False


    End Sub

    Private Sub _StampaEtichetteConsegna(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim myFont As New Font("Arial", 8)
        Dim MgX As Integer = MargineXEtichette
        Dim MgY As Integer = MargineYEtichette

        Dim TestoDaStampare As String
        myFont = New Font("Arial", 10)

        Dim Cliente As New VoceRubrica

        Cliente.Read(_Cons.IdRub)

        TestoDaStampare = Cliente.RagSocNome

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

        myFont = New Font("Arial", 9)

        TestoDaStampare = Cliente.Indirizzo & vbNewLine & Cliente.CAP & " " & Cliente.Citta

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 15)

        myFont = New Font("Arial", 8)

        TestoDaStampare = "Tel. " & Cliente.Tel

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 42)

        Cliente = Nothing

        args.Graphics.DrawLine(Pens.Black, 0, 55, 240, 55)

        myFont = New Font("Arial", 8)

        TestoDaStampare = "Colli: " & _NumCollo & " di " & _NumeroColli

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 60)

        myFont = New Font("Code EAN13", 30)

        Dim CodiceDaStampare As String = "9" & FormerHelper.Stringhe.FormattaConZeri(_Cons.IdCons, 7) & FormerHelper.Stringhe.FormattaConZeri(_NumCollo, 4)

        CodiceDaStampare = FormerHelper.EAN13.ToEAN13(CodiceDaStampare)

        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

        'myFont = New Font("FF Ean13", 12) 'FF EAN

        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 80, MgY + 150) '170

        ' myFont = New Font("Arial", 8)
        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 160, MgY + 180)

        args.HasMorePages = False


    End Sub

    Private Sub _StampaMantieniCampione(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim myFont As New Font("Arial", 8)
        Dim MgX As Integer = MargineXEtichette
        Dim MgY As Integer = MargineYEtichette

        Dim Prod As New Prodotto, Prodotto As String
        Prod.Read(_Ord.IdProd)
        Prodotto = "Prod: " & Prod.Descrizione
        Prod = Nothing

        Dim TestoDaStampare As String

        myFont = New Font("Arial", 10)

        Dim Cliente As New VoceRubrica

        Cliente.Read(_Ord.IdRub)

        TestoDaStampare = Cliente.RagSocNome

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

        myFont = New Font("Arial", 9)

        TestoDaStampare = Prodotto & ControlChars.NewLine & "Ordine: " & _Ord.IdOrd

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 15)

        TestoDaStampare = Now.ToString("dd/MM/yyyy")

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 42)

        Cliente = Nothing

        args.Graphics.DrawLine(Pens.Black, MgX + 0, MgY + 55, MgX + 240, MgY + 55)

        myFont = New Font("Arial", 24)

        TestoDaStampare = "MANTENERE" & ControlChars.NewLine & "UN CAMPIONE"

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 60)

        args.HasMorePages = False

    End Sub

    Private Sub _StampaEtichetteOrdine(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim myFont As New Font("Arial", 8)
        Dim MgX As Integer = MargineXEtichette
        Dim MgY As Integer = MargineYEtichette

        Dim Prod As New Prodotto, Prodotto As String
        Prod.Read(_Ord.IdProd)
        Prodotto = "Prod: " & Prod.Codice
        Prod = Nothing

        Dim TestoDaStampare As String

        myFont = New Font("Arial", 10)

        Dim Cliente As New VoceRubrica

        Cliente.Read(_Ord.IdRub)

        TestoDaStampare = Cliente.RagSocNome

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

        myFont = New Font("Arial", 9)

        If _Cons.IdIndirizzo = 0 Then
            TestoDaStampare = Cliente.Indirizzo & vbNewLine & Cliente.CAP & " " & Cliente.Citta
        Else
            Dim I As New Indirizzo
            I.Read(_Cons.IdIndirizzo)
            TestoDaStampare = I.Indirizzo & vbNewLine & I.Cap & " " & I.Citta
            I = Nothing
        End If

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 15)

        myFont = New Font("Arial", 8)

        TestoDaStampare = "Tel. " & Cliente.Tel

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 42)

        Cliente = Nothing

        args.Graphics.DrawLine(Pens.Black, MgX + 0, MgY + 55, MgX + 240, MgY + 55)

        myFont = New Font("Arial", 8)

        TestoDaStampare = Prodotto & vbNewLine & "Ordine: " & _Ord.IdOrd & " Colli: " & _NumCollo & " di " & _NumeroColli

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 60)

        myFont = New Font("Code EAN13", 38) '30

        Dim CodiceDaStampare As String = FormerHelper.FormerBarCode.CodiceOrdine(_Ord.Numero, _NumCollo)

        CodiceDaStampare = FormerHelper.EAN13.ToEAN13(CodiceDaStampare)

        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

        'Try

        'Dim b As Bitmap = Bitmap.FromFile(_Ord.File)

        'b = ConvertToGrayscale(b)
        Try
            Dim Anteprima As Image = FormerGraphics.FormerGraphicsEngine.Thumbnail.GetThumbnail(_Ord.FilePath, 95, "", , False)
            'Anteprima = Image.FromFile(_Ord.File)
            args.Graphics.DrawImage(Anteprima, MgX + 205, MgY + 60) ', 70, 95)'150

            Anteprima = Nothing
        Catch ex As Exception

        End Try

        'Catch ex As Exception

        'End Try

        'myFont = New Font("FF Ean13", 12) 'FF EAN

        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 80, MgY + 150) '170

        ' myFont = New Font("Arial", 8)
        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 160, MgY + 180)

        args.HasMorePages = False

    End Sub

    Private Sub _StampaPromemoria(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim myFont As New Font("Arial", 12)
        Dim MgX As Integer = 10
        Dim MgY As Integer = 10

        args.Graphics.DrawString(_P.Titolo, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 10) '170

        args.Graphics.DrawString(_P.Testo, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 80) '170

        args.HasMorePages = False


    End Sub

    Private Sub _StampaBarcode(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim myFont As New Font("Arial", 8)
        Dim MgX As Integer = MargineXEtichette
        Dim MgY As Integer = MargineYEtichette

        myFont = New Font("Code EAN13", 30)

        Dim CodiceDaStampare As String = _Barcode

        If CodiceDaStampare.Length = 12 Then
            CodiceDaStampare = FormerHelper.EAN13.ToEAN13(CodiceDaStampare)
        End If

        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

        args.HasMorePages = False


    End Sub

    Public Function ConvertToGrayscale(ByVal source As Bitmap) As Bitmap
        Dim bm As New Bitmap(source.Width, source.Height)
        Dim x As Integer = 0
        Dim y As Integer = 0
        For y = 0 To bm.Height
            For x = 0 To bm.Width
                Dim c As Color = source.GetPixel(x, y)
                Dim luma As Integer = CInt(c.R * 0.3 + c.G * 0.59 + c.B * 0.11)
                bm.SetPixel(x, y, Color.FromArgb(luma, luma, luma))
            Next
        Next
        Return bm
    End Function

    Private Sub _StampaEtichettaGruppo(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

        Dim myFont As New Font("Arial", 8)
        Dim MgX As Integer = MargineXEtichette
        Dim MgY As Integer = MargineYEtichette

        Dim Prod As New Prodotto, Prodotto As String
        Prod.Read(_Ord.IdProd)
        Prodotto = "Prod: " & Prod.Codice
        Prod = Nothing

        Dim TestoDaStampare As String


        myFont = New Font("Arial", 10)

        Dim Cliente As New VoceRubrica

        Cliente.Read(_Ord.IdRub)

        TestoDaStampare = Cliente.RagSocNome

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

        myFont = New Font("Arial", 9)

        TestoDaStampare = Cliente.Indirizzo & vbNewLine & Cliente.CAP & " " & Cliente.Citta

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 15)

        myFont = New Font("Arial", 8)

        TestoDaStampare = "Tel. " & Cliente.Tel

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 42)

        Cliente = Nothing

        args.Graphics.DrawLine(Pens.Black, 0, 55, 240, 55)

        myFont = New Font("Arial", 8)

        TestoDaStampare = Prodotto & vbNewLine & "Ordine: " & _Ord.IdOrd & " Colli interni: " & _NumeroColli

        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 60)

        myFont = New Font("Code EAN13", 30)

        Dim CodiceDaStampare As String = FormerHelper.Stringhe.FormattaConZeri(_Ord.Numero, 8) & "0000" 'FormattaConZeri(_NumCollo, 4)

        CodiceDaStampare = FormerHelper.EAN13.ToEAN13(CodiceDaStampare)

        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

        Try
            Dim Anteprima As Image
            Anteprima = Image.FromFile(_Ord.FilePath)

            'Anteprima = Image.FromFile("H:\foto.jpg")
            args.Graphics.DrawImage(Anteprima, MgX + 150, MgY + 60, 70, 95)

            Anteprima = Nothing
        Catch ex As Exception

        End Try

        'myFont = New Font("FF Ean13", 12) 'FF EAN

        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 80, MgY + 150) '170

        ' myFont = New Font("Arial", 8)
        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 160, MgY + 180)

        args.HasMorePages = False


    End Sub

End Class

