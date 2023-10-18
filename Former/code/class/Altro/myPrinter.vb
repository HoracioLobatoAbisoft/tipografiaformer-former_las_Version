Imports System.Runtime.InteropServices
Imports System.IO

Public Class myPrinter
    Inherits FormerPrinter.myFPrinter

    Public Sub New()

        MargineXEtichette = PostazioneCorrente.MargineXEtichette
        MargineYEtichette = PostazioneCorrente.MargineyEtichette
        MargineXFatture = PostazioneCorrente.MargineXFatture
        MargineYFatture = PostazioneCorrente.MargineyFatture

    End Sub

End Class

Public Class RawPrinterHelper
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Class DOCINFOA
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pDocName As String
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pDataType As String
    End Class
    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function OpenPrinter(<MarshalAs(UnmanagedType.LPStr)> ByVal szPrinter As String, ByRef hPrinter As IntPtr, ByVal pd As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal di As DOCINFOA) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array
    ' of bytes, the function sends those bytes to the print queue.
    ' Returns true on success, false on failure.
    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String,
                                              ByVal pBytes As IntPtr,
                                              ByVal dwCount As Int32,
                                              Optional ByVal DocName As String = "") As Boolean
        Dim dwError As Int32 = 0
        Dim dwWritten As Int32 = 0
        Dim hPrinter As New IntPtr(0)
        Dim di As New DOCINFOA()
        Dim bSuccess As Boolean = False
        ' Assume failure unless you specifically succeed.
        di.pDocName = DocName
        di.pDataType = "RAW"

        ' Open the printer.
        If OpenPrinter(szPrinterName.Normalize(), hPrinter, IntPtr.Zero) Then
            ' Start a document.
            If StartDocPrinter(hPrinter, 1, di) Then
                ' Start a page.
                If StartPagePrinter(hPrinter) Then
                    ' Write your bytes.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function

    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String,
                                             ByVal szFileName As String) As Boolean
        ' Open the file.
        Dim fs As New FileStream(szFileName, FileMode.Open)
        '  Make sure we're at the beginning of the stream
        fs.Seek(0, SeekOrigin.Begin)
        Dim bSuccess As Boolean = False
        bSuccess = SendStreamToPrinter(szPrinterName, fs)
        Return bSuccess
    End Function

    Public Shared Function SendStreamToPrinter(ByVal szPrinterName As String,
                                               ByVal fs As Stream) As Boolean
        ' Create a BinaryReader on the file.
        Dim br As New BinaryReader(fs)
        ' Dim an array of bytes big enough to hold the file's contents.
        Dim bytes As [Byte]() = New [Byte](fs.Length - 1) {}
        Dim bSuccess As Boolean = False
        ' Your unmanaged pointer.
        Dim pUnmanagedBytes As New IntPtr(0)
        Dim nLength As Integer

        nLength = Convert.ToInt32(fs.Length)
        ' Read the contents of the file into the array.
        bytes = br.ReadBytes(nLength)
        ' Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength)
        ' Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength)
        ' Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength)
        ' Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        Return bSuccess
    End Function

    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String,
                                               ByVal szString As String) As Boolean
        Dim pBytes As IntPtr

        Dim dwCount As Int32

        ' How many characters are in the string?
        dwCount = szString.Length

        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
        Return True
    End Function

End Class

'Public Class myPrinter

'    Friend TextToBePrinted As String
'    Private _PrinterName As String
'    Private _Ord As Ordine
'    Private _NumCollo As Integer = 0
'    Private _Barcode As String = ""
'    Private _NumeroColli As Integer = 0
'    Private _Doc As Ricavo
'    Private _NumeroPagina As Integer = 0
'    Private _SpeseConsegnaCumulative As Single = 0
'    ' qui devo anche calcolare se si tratta di una fattura riepilogativa i costi di consegna contenuti nei ddt
'    Private _ContatoreRiga As Integer = 0
'    Private _Email As Boolean = False
'    Private _Cons As ConsegnaProgrammata
'    Private _P As Promemoria

'    Public Property PrinterName() As String
'        Get
'            Return _PrinterName
'        End Get
'        Set(ByVal value As String)
'            _PrinterName = value
'        End Set
'    End Property

'    Private _Cp As ConsegnaProgrammata = Nothing
'    Friend Sub StampaConsegnaOrdini(ByRef Cp As ConsegnaProgrammata)
'        ' Try
'        _Cp = Cp
'        Dim prn As New Printing.PrintDocument

'        prn.PrinterSettings.PrinterName = _PrinterName

'        Dim tipoCarta As New System.Drawing.Printing.PaperSize

'        'tipoCarta.PaperName = Printing.PaperKind.GermanStandardFanfold.ToString
'        'tipoCarta.RawKind = Printing.PaperKind.GermanStandardFanfold
'        'tipoCarta.Width = 900
'        'tipoCarta.Height = 1300

'        'prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

'        prn.DocumentName = "Stampa Consegna Ordini"

'        AddHandler prn.PrintPage, AddressOf Me.StampaConsegnaOrdini

'        prn.Print()

'        RemoveHandler prn.PrintPage, AddressOf Me.StampaConsegnaOrdini

'        prn.Dispose()
'        ' Catch ex As Exception

'        'End Try
'    End Sub

'    Friend Sub StampaDocumento(ByVal Doc As Ricavo, Optional ByVal Email As Boolean = False)
'        ' Try
'        _Doc = Doc
'        _Email = Email
'        Dim prn As New Printing.PrintDocument

'        prn.PrinterSettings.PrinterName = _PrinterName

'        Dim tipoCarta As New System.Drawing.Printing.PaperSize

'        tipoCarta.PaperName = Printing.PaperKind.GermanStandardFanfold.ToString
'        tipoCarta.RawKind = Printing.PaperKind.GermanStandardFanfold
'        tipoCarta.Width = 900
'        tipoCarta.Height = 1300

'        prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta

'        prn.DocumentName = "Stampa Documento Fiscale"

'        AddHandler prn.PrintPage, AddressOf Me.StampaDocumento

'        prn.Print()

'        RemoveHandler prn.PrintPage, AddressOf Me.StampaDocumento

'        prn.Dispose()
'        ' Catch ex As Exception

'        'End Try
'    End Sub

'    Friend Sub StampaPromemoria(P As Promemoria)
'        ' Try
'        _P = P
'        Dim prn As New Printing.PrintDocument

'        prn.PrinterSettings.PrinterName = _PrinterName


'        prn.DocumentName = "Stampa Promemoria"

'        AddHandler prn.PrintPage, AddressOf Me.StampaPromemoria

'        prn.Print()

'        RemoveHandler prn.PrintPage, AddressOf Me.StampaPromemoria

'        prn.Dispose()
'        ' Catch ex As Exception

'        'End Try
'    End Sub

'    Friend Sub StampaReticolo()
'        Try
'            Dim prn As New Printing.PrintDocument

'            prn.PrinterSettings.PrinterName = _PrinterName

'            prn.DocumentName = "Stampa Reticolo"

'            Dim tipoCarta As New System.Drawing.Printing.PaperSize

'            tipoCarta.PaperName = Printing.PaperKind.GermanStandardFanfold.ToString
'            tipoCarta.RawKind = Printing.PaperKind.GermanStandardFanfold
'            tipoCarta.Width = 900
'            tipoCarta.Height = 1300
'            prn.PrinterSettings.DefaultPageSettings.PaperSize = tipoCarta


'            AddHandler prn.PrintPage, AddressOf Me.StampaReticolo

'            prn.Print()

'            RemoveHandler prn.PrintPage, AddressOf Me.StampaReticolo

'            prn.Dispose()
'        Catch ex As Exception

'        End Try
'    End Sub

'    Public Property IdScatola As Integer

'    Public Property IdCons As Integer

'    Friend Sub StampaEtichetteScatola() 'ByVal IdCons As Integer)
'        Try

'            _Cons = New ConsegnaProgrammata
'            _Cons.Read(IdCons)

'            Dim prn As New Printing.PrintDocument

'            '_NumeroColli = _Ord.GetNumColli
'            _NumCollo = 1
'            _NumeroColli = 1

'            prn.PrinterSettings.PrinterName = _PrinterName

'            prn.DocumentName = "Stampa Etichetta Scatola"

'            AddHandler prn.PrintPage, AddressOf Me.StampaEtichettaScatola

'            prn.Print()

'            RemoveHandler prn.PrintPage, AddressOf Me.StampaEtichettaScatola

'            prn.Dispose()

'        Catch ex As Exception

'        End Try

'    End Sub

'    Friend Sub StampaEtichetteConsegna() 'ByVal IdCons As Integer)
'        Try

'            _Cons = New ConsegnaProgrammata
'            _Cons.Read(IdCons)

'            Dim prn As New Printing.PrintDocument

'            '_NumeroColli = _Ord.GetNumColli
'            _NumeroColli = _Cons.NumColli

'            prn.PrinterSettings.PrinterName = _PrinterName

'            prn.DocumentName = "Stampa Etichette"

'            For _NumCollo = 1 To _NumeroColli

'                AddHandler prn.PrintPage, AddressOf Me.StampaEtichetteConsegna

'                prn.Print()

'                RemoveHandler prn.PrintPage, AddressOf Me.StampaEtichetteConsegna

'            Next

'            prn.Dispose()

'        Catch ex As Exception

'        End Try

'    End Sub

'    Public Property IdOrd As Integer
'    Public Property NumColli As Integer

'    Friend Sub StampaBarcode(Barcode As String)
'        Try

'            Dim prn As New Printing.PrintDocument

'            prn.PrinterSettings.PrinterName = _PrinterName

'            prn.DocumentName = "Stampa Barcode"
'            _Barcode = Barcode

'            AddHandler prn.PrintPage, AddressOf Me.StampaBarcode

'            prn.Print()

'            RemoveHandler prn.PrintPage, AddressOf Me.StampaBarcode

'            prn.Dispose()

'        Catch ex As Exception

'        End Try
'    End Sub

'    Friend Sub StampaEtichetteOrdine() 'ByVal IdOrd As Integer, NumeroColli As Integer)
'        Try

'            _Ord = New Ordine
'            _Ord.Read(IdOrd)

'            If _Ord.ConsegnaAssociata Is Nothing Then
'                _Cons = New ConsegnaProgrammata
'            Else
'                _Cons = _Ord.ConsegnaAssociata
'            End If

'            Dim prn As New Printing.PrintDocument

'            '_NumeroColli = _Ord.GetNumColli
'            _NumeroColli = NumColli

'            prn.PrinterSettings.PrinterName = _PrinterName

'            prn.DocumentName = "Stampa Etichette"

'            For Me._NumCollo = 1 To _NumeroColli

'                AddHandler prn.PrintPage, AddressOf Me.StampaEtichetteOrdine

'                prn.Print()

'                RemoveHandler prn.PrintPage, AddressOf Me.StampaEtichetteOrdine

'            Next

'            prn.Dispose()

'        Catch ex As Exception

'        End Try

'    End Sub

'    Friend Sub StampaEtichettaGruppo(ByVal IdOrd As Integer)
'        Try

'            _Ord = New Ordine
'            _Ord.Read(IdOrd)

'            Dim prn As New Printing.PrintDocument

'            _NumeroColli = _Ord.GetNumColli

'            prn.PrinterSettings.PrinterName = _PrinterName

'            prn.DocumentName = "Stampa Etichetta Gruppo"

'            ' For _NumCollo = 1 To _NumeroColli

'            AddHandler prn.PrintPage, AddressOf Me.StampaEtichettaGruppo

'            prn.Print()

'            RemoveHandler prn.PrintPage, AddressOf Me.StampaEtichettaGruppo

'            'Next

'            prn.Dispose()

'        Catch ex As Exception

'        End Try

'    End Sub

'    Friend Sub StampaFont()

'        Dim prn As New Printing.PrintDocument

'        prn.PrinterSettings.PrinterName = _PrinterName

'        prn.DocumentName = "Stampa Font"

'        AddHandler prn.PrintPage, AddressOf Me.StampaFont

'        prn.Print()

'        RemoveHandler prn.PrintPage, AddressOf Me.StampaFont

'        prn.Dispose()

'    End Sub

'    Private Sub StampaFont(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        Dim installed_fonts As New System.Drawing.Text.InstalledFontCollection

'        ' Get an array of the system's font familiies.
'        Dim font_families() As FontFamily = installed_fonts.Families()


'        ' Display the font families.
'        Dim y As Integer = 0
'        Dim myFont As New Font("Courier new", 8)

'        args.Graphics.DrawString("8: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 20)

'        myFont = New Font("Courier new", 9)
'        args.Graphics.DrawString("9: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 80)

'        myFont = New Font("Courier new", 10)
'        args.Graphics.DrawString("10: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 120)

'        myFont = New Font("Courier new", 11)
'        args.Graphics.DrawString("11: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 180)

'        myFont = New Font("Courier new", 12)
'        args.Graphics.DrawString("12: abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFont, Brushes.Black, 0, 240)


'        'For Each font_family As FontFamily In font_families
'        '    'If font_family.Name.StartsWith("Cou") Then
'        '    Try
'        '        If font_families.IsFixedSize Then
'        '            Dim myFontStampa As New Font(font_family.Name, 10, FontStyle.Regular)

'        '            args.Graphics.DrawString(font_family.Name & ": abcdefghijklmnopqrstuvz1234567890" & vbNewLine, myFontStampa, Brushes.Black, 0, y)
'        '        End If

'        '    Catch ex As Exception

'        '    End Try

'        '    y += 15
'        '    ' args.HasMorePages = True
'        '    ' End If

'        'Next font_family

'    End Sub

'    Private Sub StampaReticolo(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        Dim myFont As New Font("Segoe UI", 8)
'        Dim MgX As Integer = Postazione.MargineXEtichette
'        Dim MgY As Integer = Postazione.MargineyEtichette

'        Dim TestoDaStampare As String = ""

'        myFont = New Font("Segoe UI", 8)

'        ' TestoDaStampare = "prova"

'        '   args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

'        Dim x1 As Integer = 0
'        Dim y1 As Integer = 0

'        For x1 = 0 To 750 Step 25
'            If x1 Mod 50 Then
'                args.Graphics.DrawLine(Pens.LightGray, x1, 0, x1, 1300)
'            Else
'                args.Graphics.DrawString(x1, New Font(myFont, FontStyle.Regular), Brushes.Black, x1, 0)
'                args.Graphics.DrawLine(Pens.Black, x1, 0, x1, 1300)
'            End If
'        Next

'        For y1 = 0 To 1100 Step 25
'            If y1 Mod 50 Then
'                args.Graphics.DrawLine(Pens.LightGray, 0, y1, 900, y1)
'            Else
'                args.Graphics.DrawString(y1, New Font(myFont, FontStyle.Regular), Brushes.Black, 0, y1)
'                args.Graphics.DrawLine(Pens.Black, 0, y1, 900, y1)
'            End If
'        Next


'        args.HasMorePages = False

'    End Sub

'    Private Sub StampaIntestazione(ByVal args As Printing.PrintPageEventArgs)
'        Dim MYfont As Font

'        If _Email Then
'            MYfont = New Font("Courier New", 8, FontStyle.Regular)
'        Else
'            MYfont = New Font("Courier New", 11, FontStyle.Regular)
'        End If

'        Dim MgX As Integer = Postazione.MargineXFatture
'        Dim MgY As Integer = Postazione.MargineyFatture
'        Dim TestoDaStampare As String = ""
'        Dim PuntoScrittura As Integer = 0

'        If _Email Then
'            'qui se si tratta di fattura email stampo anche la fattura sotto
'            If _Doc.Tipo <> enTipoDocumento.enTipoDocPreventivo Then
'                Try
'                    Dim Anteprima As Image
'                    Anteprima = Image.FromFile(FormerPath.PathLocale & "modulo.jpg")

'                    args.Graphics.DrawImage(Anteprima, 0, 0, 810, 1120)

'                    Anteprima = Nothing
'                    MgX = 0
'                    MgY = 78

'                Catch ex As Exception

'                End Try
'            End If

'        End If


'        'intestazione
'        If _Doc.pRagSoc.Length > 46 Then
'            TestoDaStampare = _Doc.pRagSoc.Substring(0, 46) & vbNewLine & _Doc.pRagSoc.Substring(46)
'        Else
'            TestoDaStampare = _Doc.pRagSoc
'        End If

'        TestoDaStampare &= vbNewLine & _Doc.pIndirizzo & vbNewLine & _Doc.pCap & " " & _Doc.pCitta

'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 465, MgY + 0)

'        'descrizione documento
'        Select Case _Doc.Tipo
'            Case enTipoDocumento.enTipoDocDDT
'                TestoDaStampare = "D.D.T."
'            Case enTipoDocumento.enTipoDocFattura
'                TestoDaStampare = "FATTURA"
'            Case enTipoDocumento.enTipoDocFatturaRiepilogativa
'                TestoDaStampare = "FATTURA"
'            Case enTipoDocumento.enTipoDocPreventivo
'                TestoDaStampare = "PREVENTIVO"
'        End Select

'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 465, MgY + 100)

'        TestoDaStampare = _Doc.Numero & "/" & _Doc.DataRicavo.Year
'        PuntoScrittura = 675 - (TestoDaStampare.Length * 10)

'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + PuntoScrittura, MgY + 100)

'        TestoDaStampare = _Doc.DataRicavo.Day & "/" & _Doc.DataRicavo.Month & "/" & _Doc.DataRicavo.Year

'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 700, MgY + 100)

'        'codice cliente
'        TestoDaStampare = _Doc.IdRub
'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 290, MgY + 140)

'        If _Doc.Tipo <> enTipoDocumento.enTipoDocPreventivo Then
'            'partita iva

'            'se c'e' il codice fiscale stampo pure quello 

'            Dim Rub As New VoceRubrica
'            Rub.Read(_Doc.IdRub)
'            Dim CodFisc As String = Rub.CodFisc
'            Rub = Nothing

'            TestoDaStampare = "P.I. " & _Doc.pIva & IIf(CodFisc.Length, " C.F. " & CodFisc, "")
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 440, MgY + 140)

'            'trasporto
'            Dim Corr As New Corriere
'            Corr.Read(_Doc.IdCorr)

'            TestoDaStampare = Corr.Descrizione
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 240, MgY + 175) 'era 365
'            Corr = Nothing

'        End If

'        'pagamento
'        TestoDaStampare = _Doc.pPagamento.ToString

'        If TestoDaStampare <> "Alla consegna" Then
'            TestoDaStampare = "Scadenza: " & _Doc.Dataprevpagam.ToString("dd/MM/yyyy")
'        End If

'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 15, MgY + 210)


'    End Sub

'    Private Sub StampaFineDocumento(ByVal args As Printing.PrintPageEventArgs)
'        Dim MYfont As Font

'        If _Email Then
'            MYfont = New Font("Courier New", 8, FontStyle.Regular)
'        Else
'            MYfont = New Font("Courier New", 11, FontStyle.Regular)
'        End If

'        Dim MgX As Integer = Postazione.MargineXFatture
'        Dim MgY As Integer = Postazione.MargineyFatture
'        Dim TestoDaStampare As String = ""
'        Dim PuntoScrittura As Integer = 0

'        If _Email Then
'            MgX = 25
'            MgY = 30
'        End If

'        'numcolli e peso
'        If _Doc.Tipo = enTipoDocumento.enTipoDocDDT Or _Doc.Tipo = enTipoDocumento.enTipoDocFattura Then

'            TestoDaStampare = _Doc.NumColli
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 15, MgY + 960) '905

'            TestoDaStampare = _Doc.Peso
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 90, MgY + 960)

'        End If

'        If _Doc.Tipo = enTipoDocumento.enTipoDocFattura Or _Doc.Tipo = enTipoDocumento.enTipoDocFatturaRiepilogativa Then

'            TestoDaStampare = _Doc.PercIva.ToString & "%"
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 115, MgY + 900) '850

'            TestoDaStampare = FormattaPrezzo(_Doc.Importo)
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 240, MgY + 900)

'            TestoDaStampare = FormattaPrezzo(_Doc.Iva)
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 390, MgY + 900)

'            TestoDaStampare = FormattaPrezzo(_Doc.Totale)
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 700, MgY + 900)

'        End If

'        'indirizzo diverso di consegna
'        If _Doc.pIndCons.Length Then
'            TestoDaStampare = _Doc.pIndCons
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 15, MgY + 1030)
'        End If


'    End Sub

'    Private Sub StampaConsegnaOrdini(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        Dim MYfont As Font

'        MYfont = New Font("Courier New", 8, FontStyle.Regular)

'        Dim MgX As Integer = 0
'        Dim MgY As Integer = 0

'        Dim TestoDaStampare As String = ""
'        Dim PuntoScrittura As Integer = 0
'        Dim yRiga As Integer = MgX

'        TestoDaStampare = StrConv(Now.ToString("dddd dd/MM/yyyy hh:mm.ss"), VbStrConv.ProperCase)

'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

'        yRiga += 15

'        TestoDaStampare = _Cp.Cliente.RagSocNome

'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

'        TestoDaStampare = "****************************************"
'        yRiga += 15
'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

'        Dim TotaleImp As Integer = 0

'        For Each o As Ordine In _Cp.ListaOrdini
'            Dim Descr As String = o.Prodotto.Descrizione
'            If Descr.Length > 25 Then
'                Descr = o.Prodotto.Descrizione.Substring(0, 25)
'            End If
'            yRiga += 15

'            Dim idOrd As String = o.IdOrd
'            If idOrd.Length = 5 Then idOrd = " " & idOrd
'            TestoDaStampare = idOrd & " " & Descr & " € " & FormattaPrezzo(o.TotaleImponibile)
'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)
'            TotaleImp += o.TotaleImponibile
'        Next
'        TestoDaStampare = "****************************************"
'        yRiga += 15
'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

'        TestoDaStampare = "TOTALE € " & FormattaPrezzo(TotaleImp) & " + iva"
'        yRiga += 15
'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 0, yRiga)

'    End Sub

'    Private Sub StampaDocumento(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        '_doc e' una variabile privata del modulo di stampa
'        Dim MYfont As Font

'        If _Email Then
'            MYfont = New Font("Courier New", 8, FontStyle.Regular)
'        Else
'            MYfont = New Font("Courier New", 11, FontStyle.Regular)
'        End If

'        Dim MgX As Integer = Postazione.MargineXFatture
'        Dim MgY As Integer = Postazione.MargineyFatture


'        If _Email Then
'            MgX = 0
'            MgY = 80
'        End If
'        'args.PageSettings.PaperSize.PaperName = "ARCH A"
'        'args.PageSettings.PaperSize.Kind = Printing.PaperKind.Custom
'        'args.PageSettings.PaperSize.Width = 1000
'        'Dim prova As System.Drawing.Printing.PrinterResolutionKind = Printing.PrinterResolutionKind.Low
'        'args.PageSettings.PrinterResolution=

'        Dim TestoDaStampare As String = ""
'        Dim PuntoScrittura As Integer = 0

'        StampaIntestazione(args)
'        'NUMERO PAGINA
'        _NumeroPagina += 1
'        TestoDaStampare = _NumeroPagina
'        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 775, MgY + 140)

'        'CORPO DOCUMENTO

'        Dim VociFat As New cVociFatColl, Dt As DataTable, IsRiepilogativa As Boolean = False

'        If _Doc.Tipo = enTipoDocumento.enTipoDocFatturaRiepilogativa Then IsRiepilogativa = True

'        Dt = VociFat.Lista(_Doc.IdRicavo, IsRiepilogativa)

'        Dim Dr As DataRow, yRiga As Integer = 260
'        Dim IdVecchioDDT As Integer = 0, IdCurrentDDT As Integer = 0

'        Dim ContatoreInterno As Integer = 0


'        For Each Dr In Dt.Rows
'            If ContatoreInterno = _ContatoreRiga Then
'                If _Doc.Tipo = enTipoDocumento.enTipoDocFatturaRiepilogativa Then
'                    IdCurrentDDT = Dr("iddoc")
'                    If IdCurrentDDT <> IdVecchioDDT Then

'                        If IdVecchioDDT <> 0 Then yRiga += 15
'                        'ristampo l'intestazione del doc
'                        Dim Docume As New cContabRicavi
'                        Docume.Read(Dr("iddoc"))

'                        TestoDaStampare = "Riferimento DDT Numero " & Docume.Numero & " del " & Docume.DataRicavo.ToShortDateString

'                        _SpeseConsegnaCumulative += Docume.CostoCorr

'                        Docume = Nothing

'                        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 5, MgY + yRiga)
'                        yRiga += 30
'                        IdVecchioDDT = IdCurrentDDT
'                    End If
'                End If

'                Dim Codice As String = Dr("Codice").ToString
'                If Codice.Length > 10 Then
'                    Codice = Codice.Substring(0, 10)
'                End If
'                TestoDaStampare = Codice
'                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, IIf(_Email, 20, 0) + MgX + 5, MgY + yRiga)

'                '*********************************
'                'qui devo stampare la descrizione su piu righe splittate su 34 caratteri
'                '*********************************
'                Dim NewYRiga As Integer = 0
'                NewYRiga = yRiga
'                Dim TestoSuPiuRighe As String() = SplittaTesto(Dr("Descrizione").ToString)

'                For Each StringaSing As String In TestoSuPiuRighe
'                    args.Graphics.DrawString(StringaSing, MYfont, Brushes.Black, IIf(_Email, 30, 0) + MgX + 105, MgY + NewYRiga)
'                    NewYRiga += 15
'                Next

'                TestoDaStampare = Dr("Qta").ToString
'                PuntoScrittura = 515 - (TestoDaStampare.Length * 10)
'                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + PuntoScrittura, MgY + yRiga)

'                TestoDaStampare = "Ord. " & Dr("IdOrd").ToString
'                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 545, MgY + yRiga)

'                If _Doc.Tipo <> enTipoDocumento.enTipoDocDDT Then

'                    TestoDaStampare = FormattaPrezzo(Dr("importo").ToString)

'                    PuntoScrittura = 765 - (TestoDaStampare.Length * 10)
'                    args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + PuntoScrittura, MgY + yRiga)

'                End If

'                yRiga = NewYRiga

'                ContatoreInterno += 1
'                _ContatoreRiga += 1

'                If yRiga > 830 Then 'IMPOSTAZIONE FINE SEZIONE CENTRALE era 730
'                    'qui devo controllare se ci sono altre righe prima di andare avanti
'                    If _ContatoreRiga < Dt.Rows.Count Then

'                        'qui devo scrivere segue
'                        TestoDaStampare = "Segue..."
'                        args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 225, MgY + yRiga)

'                        args.HasMorePages = True

'                        Exit For
'                    Else
'                        args.HasMorePages = True
'                    End If


'                Else
'                    args.HasMorePages = False

'                End If
'            Else
'                ContatoreInterno += 1
'            End If

'        Next

'        'COSTI DI CONSEGNA
'        If _Doc.CostoCorr Then

'            TestoDaStampare = "Consegna"

'            Dim C As New Corriere
'            C.Read(_Doc.IdCorr)

'            If C.TipoCorriere = enTipoCorriere.PortoAssegnato Then
'                TestoDaStampare = "Spese di Imballo"
'            End If

'            C = Nothing

'            args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, IIf(_Email, 30, 0) + MgX + 105, MgY + yRiga)

'            If _Doc.Tipo <> enTipoDocumento.enTipoDocDDT Then
'                TestoDaStampare = FormattaPrezzo(_Doc.CostoCorr.ToString)

'                PuntoScrittura = 765 - (TestoDaStampare.Length * 10)
'                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + PuntoScrittura, MgY + yRiga)
'                yRiga += 15

'            End If

'        End If
'        '
'        yRiga += 30

'        If args.HasMorePages = False Then
'            ' qui devo anche calcolare se si tratta di una fattura riepilogativa i costi di consegna contenuti nei ddt
'            'solo sull'ultima pagina
'            If _Doc.Tipo = enTipoDocumento.enTipoDocFatturaRiepilogativa And _SpeseConsegnaCumulative <> 0 Then

'                TestoDaStampare = "Consegna"
'                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 105, MgY + yRiga)

'                If _Doc.Tipo <> enTipoDocumento.enTipoDocDDT Then
'                    TestoDaStampare = FormattaPrezzo(_SpeseConsegnaCumulative.ToString)

'                    PuntoScrittura = 765 - (TestoDaStampare.Length * 10)
'                    args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + PuntoScrittura, MgY + yRiga)
'                    yRiga += 15

'                End If

'            End If

'            'NOTE DI DOCUMENTO
'            If _Doc.Tipo = enTipoDocumento.enTipoDocDDT Then
'                args.Graphics.DrawLine(Pens.Black, 25, yRiga, 700, yRiga)
'                yRiga += 15
'                TestoDaStampare = "D.D.T."
'                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 350, MgY + yRiga)
'            ElseIf _Doc.Tipo = enTipoDocumento.enTipoDocPreventivo Then
'                args.Graphics.DrawLine(Pens.Black, 25, yRiga, 700, yRiga)
'                yRiga += 15
'                TestoDaStampare = "IL PRESENTE PREVENTIVO E' VALIDO 30 GIORNI"
'                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 150, MgY + yRiga)
'                yRiga += 30
'                TestoDaStampare = "TOTALE " & FormattaPrezzo(_Doc.Importo)
'                args.Graphics.DrawString(TestoDaStampare, MYfont, Brushes.Black, MgX + 150, MgY + yRiga)
'            End If

'            StampaFineDocumento(args)

'        End If

'    End Sub

'    Private Sub StampaEtichettaScatola(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        Dim myFont As New Font("Segoe UI", 8)
'        Dim MgX As Integer = Postazione.MargineXEtichette
'        Dim MgY As Integer = Postazione.MargineyEtichette

'        Dim TestoDaStampare As String
'        myFont = New Font("Segoe UI", 10)

'        Dim Cliente As New VoceRubrica

'        Cliente.Read(_Cons.IdRub)

'        TestoDaStampare = Cliente.RagSoc

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

'        myFont = New Font("Segoe UI", 9)

'        If _Cons.IdIndirizzo = 0 Then
'            TestoDaStampare = Cliente.Indirizzo & vbNewLine & Cliente.CAP & " " & Cliente.Citta
'        Else
'            Dim I As New Indirizzo
'            I.Read(_Cons.IdIndirizzo)
'            TestoDaStampare = I.Indirizzo & vbNewLine & I.Cap & " " & I.Citta
'            I = Nothing
'        End If

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 15)

'        myFont = New Font("Segoe UI", 8)

'        TestoDaStampare = "Tel. " & Cliente.Tel

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 42)

'        Cliente = Nothing

'        args.Graphics.DrawLine(Pens.Black, 0, 55, 240, 55)

'        myFont = New Font("Segoe UI", 8)

'        TestoDaStampare = "Scatola: " & IdScatola

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 60)

'        myFont = New Font("Code EAN13", 30)

'        Dim CodiceDaStampare As String = "9" & FormerHelper.Stringhe.FormattaConZeri(IdScatola, 7) & FormerHelper.Stringhe.FormattaConZeri(_NumCollo, 4)

'        CodiceDaStampare = FormerHelper.EAN13.ToEAN13(CodiceDaStampare)

'        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

'        'myFont = New Font("FF Ean13", 12) 'FF EAN

'        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 80, MgY + 150) '170

'        ' myFont = New Font("Segoe UI", 8)
'        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 160, MgY + 180)

'        Try
'            Dim Anteprima As Image = My.Resources.icoScatola
'            'Anteprima = Image.FromFile(_Ord.FilePath)
'            args.Graphics.DrawImage(Anteprima, MgX + 150, MgY + 60) ', 70, 95)

'            Anteprima = Nothing
'        Catch ex As Exception

'        End Try


'        args.HasMorePages = False


'    End Sub

'    Private Sub StampaEtichetteConsegna(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        Dim myFont As New Font("Segoe UI", 8)
'        Dim MgX As Integer = Postazione.MargineXEtichette
'        Dim MgY As Integer = Postazione.MargineyEtichette

'        Dim TestoDaStampare As String
'        myFont = New Font("Segoe UI", 10)

'        Dim Cliente As New VoceRubrica

'        Cliente.Read(_Cons.IdRub)

'        TestoDaStampare = Cliente.RagSoc

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

'        myFont = New Font("Segoe UI", 9)

'        TestoDaStampare = Cliente.Indirizzo & vbNewLine & Cliente.CAP & " " & Cliente.Citta

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 15)

'        myFont = New Font("Segoe UI", 8)

'        TestoDaStampare = "Tel. " & Cliente.Tel

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 42)

'        Cliente = Nothing

'        args.Graphics.DrawLine(Pens.Black, 0, 55, 240, 55)

'        myFont = New Font("Segoe UI", 8)

'        TestoDaStampare = "Colli: " & _NumCollo & " di " & _NumeroColli

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 60)

'        myFont = New Font("Code EAN13", 30)

'        Dim CodiceDaStampare As String = "9" & FormerHelper.Stringhe.FormattaConZeri(_Cons.IdCons, 7) & FormerHelper.Stringhe.FormattaConZeri(_NumCollo, 4)

'        CodiceDaStampare = FormerHelper.EAN13.ToEAN13(CodiceDaStampare)

'        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

'        'myFont = New Font("FF Ean13", 12) 'FF EAN

'        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 80, MgY + 150) '170

'        ' myFont = New Font("Segoe UI", 8)
'        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 160, MgY + 180)

'        args.HasMorePages = False


'    End Sub

'    Private Sub StampaEtichetteOrdine(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        Dim myFont As New Font("Segoe UI", 8)
'        Dim MgX As Integer = Postazione.MargineXEtichette
'        Dim MgY As Integer = Postazione.MargineyEtichette

'        Dim Prod As New Prodotto, Prodotto As String
'        Prod.Read(_Ord.IdProd)
'        Prodotto = "Prod: " & Prod.Codice
'        Prod = Nothing

'        Dim TestoDaStampare As String


'        myFont = New Font("Segoe UI", 10)

'        Dim Cliente As New VoceRubrica

'        Cliente.Read(_Ord.IdRub)

'        TestoDaStampare = Cliente.RagSoc

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

'        myFont = New Font("Segoe UI", 9)

'        If _Cons.IdIndirizzo = 0 Then
'            TestoDaStampare = Cliente.Indirizzo & vbNewLine & Cliente.CAP & " " & Cliente.Citta
'        Else
'            Dim I As New Indirizzo
'            I.Read(_Cons.IdIndirizzo)
'            TestoDaStampare = I.Indirizzo & vbNewLine & I.Cap & " " & I.Citta
'            I = Nothing
'        End If

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 15)

'        myFont = New Font("Segoe UI", 8)

'        TestoDaStampare = "Tel. " & Cliente.Tel

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 42)

'        Cliente = Nothing

'        args.Graphics.DrawLine(Pens.Black, 0, 55, 240, 55)

'        myFont = New Font("Segoe UI", 8)

'        TestoDaStampare = Prodotto & vbNewLine & "Ordine: " & _Ord.IdOrd & " Colli: " & _NumCollo & " di " & _NumeroColli

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 60)

'        myFont = New Font("Code EAN13", 30)

'        Dim CodiceDaStampare As String = FormerHelper.FormerBarCode.CodiceOrdine(_Ord.Numero, _NumCollo)

'        CodiceDaStampare = EAN13(CodiceDaStampare)

'        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

'        'Try

'        'Dim b As Bitmap = Bitmap.FromFile(_Ord.FilePath)

'        'b = ConvertToGrayscale(b)
'        Try
'            Dim Anteprima As Image = Grafica.thumbnail(_Ord.FilePath, 95, "", , False)
'            'Anteprima = Image.FromFile(_Ord.FilePath)
'            args.Graphics.DrawImage(Anteprima, MgX + 150, MgY + 60) ', 70, 95)

'            Anteprima = Nothing
'        Catch ex As Exception

'        End Try

'        'Catch ex As Exception

'        'End Try

'        'myFont = New Font("FF Ean13", 12) 'FF EAN

'        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 80, MgY + 150) '170

'        ' myFont = New Font("Segoe UI", 8)
'        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 160, MgY + 180)

'        args.HasMorePages = False


'    End Sub

'    Private Sub StampaPromemoria(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        Dim myFont As New Font("Segoe UI", 12)
'        Dim MgX As Integer = 10
'        Dim MgY As Integer = 10

'        args.Graphics.DrawString(_P.Titolo, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 10) '170

'        args.Graphics.DrawString(_P.Testo, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 80) '170

'        args.HasMorePages = False


'    End Sub

'    Private Sub StampaBarcode(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        Dim myFont As New Font("Segoe UI", 8)
'        Dim MgX As Integer = Postazione.MargineXEtichette
'        Dim MgY As Integer = Postazione.MargineyEtichette

'        myFont = New Font("Code EAN13", 30)

'        Dim CodiceDaStampare As String = _Barcode

'        CodiceDaStampare = EAN13(CodiceDaStampare)

'        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

'        args.HasMorePages = False


'    End Sub

'    Public Function ConvertToGrayscale(ByVal source As Bitmap) As Bitmap
'        Dim bm As New Bitmap(source.Width, source.Height)
'        Dim x
'        Dim y
'        For y = 0 To bm.Height
'            For x = 0 To bm.Width
'                Dim c As Color = source.GetPixel(x, y)
'                Dim luma As Integer = CInt(c.R * 0.3 + c.G * 0.59 + c.B * 0.11)
'                bm.SetPixel(x, y, Color.FromArgb(luma, luma, luma))
'            Next
'        Next
'        Return bm
'    End Function

'    Private Sub StampaEtichettaGruppo(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)

'        Dim myFont As New Font("Segoe UI", 8)
'        Dim MgX As Integer = Postazione.MargineXEtichette
'        Dim MgY As Integer = Postazione.MargineyEtichette

'        Dim Prod As New Prodotto, Prodotto As String
'        Prod.Read(_Ord.IdProd)
'        Prodotto = "Prod: " & Prod.Codice
'        Prod = Nothing

'        Dim TestoDaStampare As String


'        myFont = New Font("Segoe UI", 10)

'        Dim Cliente As New VoceRubrica

'        Cliente.Read(_Ord.IdRub)

'        TestoDaStampare = Cliente.RagSoc

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Bold), Brushes.Black, MgX + 0, MgY + 0)

'        myFont = New Font("Segoe UI", 9)

'        TestoDaStampare = Cliente.Indirizzo & vbNewLine & Cliente.CAP & " " & Cliente.Citta

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 15)

'        myFont = New Font("Segoe UI", 8)

'        TestoDaStampare = "Tel. " & Cliente.Tel

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 42)

'        Cliente = Nothing

'        args.Graphics.DrawLine(Pens.Black, 0, 55, 240, 55)

'        myFont = New Font("Segoe UI", 8)

'        TestoDaStampare = Prodotto & vbNewLine & "Ordine: " & _Ord.IdOrd & " Colli interni: " & _NumeroColli

'        args.Graphics.DrawString(TestoDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 0, MgY + 60)

'        myFont = New Font("Code EAN13", 30)

'        Dim CodiceDaStampare As String = FormerHelper.Stringhe.FormattaConZeri(_Ord.Numero, 8) & "0000" 'FormattaConZeri(_NumCollo, 4)

'        CodiceDaStampare = EAN13(CodiceDaStampare)

'        args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 10, MgY + 95) '170

'        Try
'            Dim Anteprima As Image
'            Anteprima = Image.FromFile(_Ord.FilePath)

'            'Anteprima = Image.FromFile("H:\foto.jpg")
'            args.Graphics.DrawImage(Anteprima, MgX + 150, MgY + 60, 70, 95)

'            Anteprima = Nothing
'        Catch ex As Exception

'        End Try

'        'myFont = New Font("FF Ean13", 12) 'FF EAN

'        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 80, MgY + 150) '170

'        ' myFont = New Font("Segoe UI", 8)
'        'args.Graphics.DrawString(CodiceDaStampare, New Font(myFont, FontStyle.Regular), Brushes.Black, MgX + 160, MgY + 180)

'        args.HasMorePages = False


'    End Sub

'End Class

