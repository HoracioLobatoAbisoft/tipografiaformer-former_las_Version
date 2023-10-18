Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerDALSql
Imports FormerLib
Imports FormerConfig
Imports FormerError
Imports FormerBusinessLogic

Module mdlMain

    'Public FormerDebug.DebugAttivo As Boolean = False
    Public FormPrincipale As frmMain

    Public WithEvents AnteprimaLavoro As New ucAnteprimaLavoro

    Public ServerCollaudo As ServerSito
    Public ServerTwin As ServerSito
    Public ServerProduzione As ServerSito

    Public UpdateAppAtShutdown As Boolean = False

    Public udp As System.Net.Sockets.UdpClient = Nothing

    Public Function ManageError(ByRef ex As Exception,
                                Optional ByVal dettaglio As String = "",
                                Optional NonGestito As Boolean = False) As Integer

        'Using f As New frmBug
        '    f.Carica(Me)
        'End Using

        'gestione errori generale
        Dim x As New Random

        Dim NomeFile As String = FormerPath.PathLocale & "Err" & x.Next(0, 100000).ToString & ".txt"

        If dettaglio.Length = 0 Then
            If Not ex.InnerException Is Nothing Then
                If ex.InnerException.Message.Length Then dettaglio = ex.InnerException.Message
            End If
        End If

        'Dim Messaggioerrore As String = "Inviare il seguente messaggio di posta elettronica all' indirizzo: " & FormerConst.EmailAssistenzaTecnica & ControlChars.NewLine & ControlChars.NewLine
        'Messaggioerrore &= "OGGETTO EMAIL: Errore " & PostazioneCorrente.Titolo & ControlChars.NewLine & ControlChars.NewLine

        'Messaggioerrore &= "TESTO EMAIL: " & ControlChars.NewLine & ControlChars.NewLine
        'Messaggioerrore &= "Postazione: " & PostazioneCorrente.Titolo & " Versione: " & PostazioneCorrente.Versione & ControlChars.NewLine
        'If Not PostazioneCorrente.UtenteConnesso Is Nothing Then Messaggioerrore &= "Utente Connesso: " & PostazioneCorrente.UtenteConnesso.Login & ControlChars.NewLine
        'Messaggioerrore &= "Data e ora: " & Date.Now & ControlChars.NewLine
        'Messaggioerrore &= "Dettaglio: " & dettaglio & ControlChars.NewLine & ControlChars.NewLine
        'Messaggioerrore &= "Errore: " & ex.Message & ControlChars.NewLine & ControlChars.NewLine
        'Messaggioerrore &= "Sorgente: " & ex.Source & ControlChars.NewLine & ControlChars.NewLine
        'Messaggioerrore &= "Stack Errore: " & ControlChars.NewLine & ControlChars.NewLine & ex.StackTrace & ControlChars.NewLine & ControlChars.NewLine
        'Messaggioerrore &= "Stack Generico: " & ControlChars.NewLine & ControlChars.NewLine & System.Environment.StackTrace.Replace(" in ", Chr(10)) & ControlChars.NewLine

        Dim Messaggioerrore As String = "Dettaglio: " & dettaglio & ControlChars.NewLine & ControlChars.NewLine
        Messaggioerrore &= "Errore: " & ex.Message & ControlChars.NewLine & ControlChars.NewLine
        Messaggioerrore &= "Sorgente: " & ex.Source & ControlChars.NewLine & ControlChars.NewLine
        Messaggioerrore &= "Stack Errore: " & ControlChars.NewLine & ControlChars.NewLine & ex.StackTrace & ControlChars.NewLine & ControlChars.NewLine
        Messaggioerrore &= "Stack Generico: " & ControlChars.NewLine & ControlChars.NewLine & System.Environment.StackTrace.Replace(" in ", Chr(10)) & ControlChars.NewLine

        MgrError.ScriviLogFile(NomeFile, Messaggioerrore)

        'Try
        '    FormerHelper.Mail.InviaMail("Errore Gestionale", FormerHelper.HTML.ConvertiTextToHtml(Messaggioerrore), "soft@tipografiaformer.it")
        'Catch exMail As Exception

        'End Try

        'qui devo vedere se l'anomalia è gia stata segnalata

        Dim ErrAvv As String = "Si è verificato un errore, si vuole inviare una segnalazione di anomalia? " & ControlChars.NewLine & ControlChars.NewLine & "- premendo Si, potrai inserire la segnalazione;" & ControlChars.NewLine & "- premendo No, il programma tenterà di continuare;" & ControlChars.NewLine & "- premendo Annulla, il programma verrà terminato;" & ControlChars.NewLine & ControlChars.NewLine & "In ogni caso il dettaglio dell'errore è stato salvato nel file " & NomeFile

        Dim res As System.Windows.Forms.DialogResult = DialogResult.Yes

        If NonGestito Then
            MessageBox.Show("Si è verificato un errore non gestito e il programma verrà terminato dopo l'inserimento della segnalazione di anomalia")
        Else
            res = MessageBox.Show(ErrAvv, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error)
        End If

        Select Case res
            Case DialogResult.Yes
                Using f As New frmBug
                    f.Carica(Nothing, Messaggioerrore, ex.GetHashCode)
                End Using

                End 'chiudo il programma perche c'e' un errore

            Case DialogResult.No
            'qui devo cercare di capire se c'e' aperta la form di sottofondo per toglierla
            Case DialogResult.Cancel

                End 'chiudo il programma perche c'e' un errore

        End Select

        Return ex.GetHashCode

    End Function

    'Public ChiamataInArrivo As Boolean = False
    'Public Sub SendUdpMessage(messaggio As String)
    '    Dim udp As New Net.Sockets.UdpClient()
    '    udp.EnableBroadcast = True
    '    Dim ep As New Net.IPEndPoint(Net.IPAddress.Broadcast, Postazione.PortaUDP)
    '    Dim b() As Byte = System.Text.Encoding.UTF32.GetBytes(messaggio)
    '    udp.Send(b, b.Length, ep)
    '    udp.Close()
    'End Sub

    'Public cPercIVA As Integer = 22

    'Public Sub ShellEx(ByVal Path As String)

    '    FormerHelper.File.ShellExtended(Path)

    'End Sub



    'Friend Function GetUltimoRilascioModClienti() As Integer

    '    Dim Ris As Integer = 0
    '    'leggo da un file di testo esterno l'ultimo rilascio del modulo clienti e faccio con quello i confronti
    '    Dim PathFile As String = FormerPath.PathLocale & "UltimoRilascioModClienti.txt"

    '    If Dir(PathFile) <> "" Then
    '        Dim sw As New StreamReader(PathFile, System.Text.Encoding.ASCII)
    '        Dim ContentFile As String = sw.ReadToEnd()

    '        If ContentFile.Length Then Ris = ContentFile

    '        sw.Close()
    '        sw = Nothing

    '    End If

    '    Return Ris

    'End Function

    'Public Function CreaPremium(ByVal IdCli As Integer, ByVal DataRif As Date) As String


    '    Dim DatoToConvert As String = IdCli.ToString

    '    DatoToConvert &= Format(DataRif.Day, "00") & Format(DataRif.Month, "00") & DataRif.Year.ToString.Substring(2, 2)

    '    DatoToConvert = (DatoToConvert * 89)

    '    Dim Car As String, Risultato As String = ""

    '    For Each Car In DatoToConvert.ToString

    '        Risultato &= Chr(CInt(Car) + 70)

    '    Next

    '    Return Risultato

    'End Function

    'Private Function CreaRiepContab(ByVal Voce As Object) As String

    '    Try

    '        Dim buffer As String = ""
    '        '<br clear=all style='page-break-before:always'> per andare a capo vediamo se funzia

    '        buffer = "<HTML><HEAD><TITLE>Riepilogo</TITLE></HEAD><BODY BGCOLOR=""WHITE"">" & ControlChars.NewLine
    '        buffer &= "<CENTER><FONT FACE=Verdana SIZE=4><B>Riepilogo Voce Contabilita'</B><BR></FONT></CENTER><BR><BR>" & ControlChars.NewLine
    '        buffer &= "<TABLE WIDTH=95% BORDER=0 bgcolor=""white"" > " & ControlChars.NewLine
    '        buffer &= "<TR><TD valign=top>" & ControlChars.NewLine
    '        buffer &= "<FONT FACE=Verdana SIZE=3><B>" & Voce.tipovoce & "</B></FONT><BR><BR><FONT SIZE=2 FACE=VERDANA>" & ControlChars.NewLine

    '        buffer &= "Data: <B>" & Voce.DataRif.ToString & "</B>" & "<BR>"
    '        buffer &= "Descrizione: <B>" & Voce.Descrizione.ToString & "</B>" & "<BR>"
    '        'qui carico se ha immagini e in caso faccio il box incorniciato
    '        buffer &= "Importo: <B>" & FormattaPrezzo(Voce.importo) & "</B>" & "<BR>"
    '        buffer &= "% Iva: <B>" & Voce.PercIva & "</B>" & "<BR>"
    '        buffer &= "Iva: <B>" & FormattaPrezzo(Voce.Iva) & "</B>" & "<BR><br>"

    '        If Voce.scansione.length Then
    '            buffer &= "<CENTER><A HREF=""" & Voce.scansione & """ target=""_new""><IMG SRC=""" & Voce.scansione & """ width=300 border=0></A></CENTER>"
    '        End If

    '        If Voce.scansione1.length Then
    '            buffer &= "<CENTER><A HREF=""" & Voce.scansione1 & """ target=""_new""><IMG SRC=""" & Voce.scansione1 & """ width=300 border=0></A></CENTER>"
    '        End If

    '        If Voce.scansione2.length Then
    '            buffer &= "<CENTER><A HREF=""" & Voce.scansione2 & """ target=""_new""><IMG SRC=""" & Voce.scansione2 & """ width=300 border=0></A></CENTER>"
    '        End If

    '        If Voce.scansione3.length Then
    '            buffer &= "<CENTER><A HREF=""" & Voce.scansione3 & """ target=""_new""><IMG SRC=""" & Voce.scansione3 & """ width=300 border=0></A></CENTER>"
    '        End If

    '        If Voce.scansione4.length Then
    '            buffer &= "<CENTER><A HREF=""" & Voce.scansione4 & """ target=""_new""><IMG SRC=""" & Voce.scansione4 & """ width=300 border=0></A></CENTER>"
    '        End If

    '        buffer &= "</TD></TR>" & ControlChars.NewLine

    '        buffer &= "</TABLE></CENTER>" & ControlChars.NewLine

    '        buffer &= "</BODY></HTML>" & ControlChars.NewLine
    '        'ciclo per le varie zone presenti nell'agenzia e creo una riga per ogni zona 
    '        'carico le offerte di quella zona

    '        'qui lancio il modulo esterno per visualizzarlo
    '        Dim PathMOd As String = FormerPath.PathLocale & "dettvocecontab.htm"

    '        Dim sr As New System.IO.StreamWriter(PathMOd, False)

    '        sr.Write(buffer)

    '        sr.Close()
    '        sr = Nothing


    '        Return PathMOd
    '        'Dim x As New Process

    '        'x.StartInfo.FileName = PathMOd
    '        'x.Start()

    '        '            WebGiorn.Navigate(PathMOd)

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try

    'End Function

    'Public Function CreaRiepilogoContabHTML(ByVal IdVoce As Integer, ByVal TipoVoce As Integer) As String
    '    Dim Buffer As String = ""

    '    If TipoVoce = enTipoVoceContab.enTipoVoceAcquisto Then
    '        Dim Costo As New cContabCosti
    '        Costo.Read(IdVoce)
    '        Buffer = CreaRiepContab(Costo)
    '        Costo = Nothing
    '    Else
    '        Dim Ricavo As New cContabRicavi
    '        Ricavo.Read(IdVoce)
    '        Buffer = CreaRiepContab(Ricavo)
    '        Ricavo = Nothing

    '    End If

    '    Return Buffer

    'End Function

    'Public Function MgrIO.FileCopia(ByVal Sender As frmBaseForm,
    '                          ByVal Origine As String,
    '                          ByVal Destinazione As String,
    '                          Optional ByVal ResizeImg As Boolean = False) As Integer

    'Public Function SelectIndexComboOld(ByVal combo As ComboBox, ByVal Valore As Integer) As Integer
    '    If IsDBNull(Valore) OrElse Valore = 0 Then SelectIndexComboOld = -1
    '    Dim i As Integer
    '    For i = 0 To combo.Items.Count - 1
    '        combo.SelectedIndex = i
    '        If combo.SelectedValue = Valore Then
    '            Return i
    '        End If
    '    Next
    '    Return -1
    'End Function

    'Public Sub Sottofondo(ByRef Oggetto)
    '    If Oggetto.visible Then
    '        If Oggetto.FormSopra Is Nothing Then

    '            Dim x As New cFormSopra(Oggetto)
    '            Oggetto.formsopra = x
    '            'x.StartPosition = FormStartPosition.CenterParent

    '            x.Show(Oggetto)

    '        Else

    '            Oggetto.Focus()
    '            Oggetto.FormSopra.hide()
    '            Oggetto.FormSopra.dispose()
    '            Oggetto.FormSopra = Nothing

    '        End If
    '    End If
    'End Sub

    Public Sub StampaGlobale(ByVal Titolo As String,
                             ByVal dt As Telerik.WinControls.UI.RadGridView,
                             Optional IsOrdini As Boolean = False)

        If dt Is Nothing Then Exit Sub

        'Dim Template As String = FormerPath.PathLocale & "lista.htm"
        Dim TitoloStampa As String = "", Contenuto As String

        TitoloStampa = Titolo
        Contenuto = CreaContenutoLista(dt, IsOrdini)

        'apro il template 
        'sostituisco il titolo
        'sostituisco il contenuto per le liste
        Dim ContentFile As String = String.Empty

        'Try
        '    Using sw As New StreamReader(Template, System.Text.Encoding.ASCII)
        '        ContentFile = sw.ReadToEnd()
        '        sw.Close()
        '    End Using
        'Catch ex As Exception

        'End Try

        Dim Pt As New My.Templates.ListaStampa
        ContentFile = Pt.TransformText


        If TitoloStampa.Length Then ContentFile = ContentFile.Replace("$TITOLO$", TitoloStampa)
        ContentFile = ContentFile.Replace("$CONTENUTO$", Contenuto)

        Dim PathFileStampa As String = FormerLib.FormerHelper.File.CreaFileHtml(ContentFile)

        'FileCopy(Template, StampaTemp)

        'qui ho il file completato e lo mando alla form di preview
        Using x As New frmStampa

            x.Carica(PathFileStampa)

        End Using



    End Sub

    Public Sub StampaGlobale(ByVal Titolo As String,
                             ByVal dt As DataGridView,
                             Optional IsOrdini As Boolean = False)

        If dt Is Nothing Then Exit Sub

        Dim Template As String = FormerPath.PathLocale & "lista.htm"
        Dim TitoloStampa As String = "", Contenuto As String

        TitoloStampa = Titolo
        Contenuto = CreaContenutoLista(dt, IsOrdini)

        'apro il template 
        'sostituisco il titolo
        'sostituisco il contenuto per le liste
        Dim ContentFile As String = String.Empty

        Dim Pt As New My.Templates.ListaStampa
        ContentFile = Pt.TransformText

        If TitoloStampa.Length Then ContentFile = ContentFile.Replace("$TITOLO$", TitoloStampa)
        ContentFile = ContentFile.Replace("$CONTENUTO$", Contenuto)

        Dim PathFileStampa As String = FormerLib.FormerHelper.File.CreaFileHtml(ContentFile)

        'FileCopy(Template, StampaTemp)

        'qui ho il file completato e lo mando alla form di preview
        Using x As New frmStampa

            x.Carica(PathFileStampa)

        End Using

    End Sub

    Public Sub StampaBuffer(ByVal Buffer As String)

        Dim PathFileStampa As String = FormerLib.FormerHelper.File.CreaFileHtml(Buffer)

        'FileCopy(Template, StampaTemp)

        'qui ho il file completato e lo mando alla form di preview
        Using x As New frmStampa
            x.Carica(PathFileStampa)
        End Using

    End Sub

    Private Function CreaContenutoLista(ByVal Dt As Telerik.WinControls.UI.RadGridView,
                                        Optional IsOrdini As Boolean = False) As String 'DataTable) As String

        Dim buffer As String = ""

        Dim I As Integer
        buffer = "<table WIDTH=90% border=0 "

        'If Postazione.printStampaGriglia Then

        'buffer &= " style=""border:1px solid #999999;font-family:Arial;font-size:11px;"" "

        ' End If

        buffer &= "><tr>"
        If IsOrdini Then

            'Dt.MasterTemplate.EnableSorting = True
            'Dim descriptor As New SortDescriptor()
            'descriptor.PropertyName = "IdOrdine"
            'descriptor.Direction = ListSortDirection.Ascending
            'Dt.MasterTemplate.SortDescriptors.Add(descriptor)

            buffer &= "<td bgcolor=""#FE6601"" align=center></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>LAVORO</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>DATA</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>CLIENTE</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>PRODOTTO</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>Q.TA</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>NOME LAVORO</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>TOTALE</b></td>"
        Else
            For I = 0 To Dt.ColumnCount - 1
                If Dt.Columns(I).IsVisible Then buffer &= "<td bgcolor=""#FE6601"" align=center><font size=" & 1 & " Face=arial color=black><b>" & Dt.Columns(I).HeaderText.ToUpper & "</b></font></td>"
            Next
        End If

        buffer &= "</tr>"

        Dim J As Integer

        For I = Dt.Rows.Count - 1 To 0 Step -1

            buffer &= "<tr>"

            If IsOrdini Then

                Using O As New Ordine

                    O.Read(Dt.Rows(I).Cells(3).Value)

                    buffer &= "<td><img src=""" & O.FilePath & """ width=100></td>"
                    buffer &= "<td>" & O.IdOrd & "</td>"
                    buffer &= "<td>" & O.DataInsStr & "</td>"
                    buffer &= "<td>" & O.VoceRubrica.RagSocNome & "</td>"
                    buffer &= "<td>" & O.Prodotto.Descrizione & "</td>"
                    buffer &= "<td>" & O.Qta & "</td>"
                    buffer &= "<td>" & O.NomeLavoro & "</td>"
                    buffer &= "<td>" & O.TotaleStrEx & "</td>"

                End Using

            Else
                For J = 0 To Dt.Columns.Count - 1

                    If Dt.Columns(J).IsVisible Then
                        buffer &= "<td "
                        '   If Postazione.printStampaGriglia Then

                        'buffer &= " style=""border:1px solid #999999;"" "

                        'End If

                        'qui imposto lo stile 
                        Select Case Dt.Columns(J).TextAlignment
                            Case ContentAlignment.MiddleCenter
                                buffer &= " align=center "
                            Case ContentAlignment.MiddleRight
                                buffer &= " align=right "
                        End Select

                        buffer &= "><font size=" & 1 & " Face=arial color=black>"

                        Dim Nome As String = Dt.Rows(I).Cells(J).GetType.Name

                        If Nome <> "Image" AndAlso Not TypeOf (Dt.Rows(I).Cells(J).Value) Is Image Then
                            buffer &= Dt.Rows(I).Cells(J).Value
                        End If

                        buffer &= "&nbsp;</font></td>"

                    End If

                Next
            End If

            buffer &= "</tr>"

        Next

        buffer &= "</table>"

        Return buffer

    End Function

    Private Function CreaContenutoLista(ByVal Dt As DataGridView,
                                        Optional IsOrdini As Boolean = False) As String 'DataTable) As String

        Dim buffer As String = ""

        Dim I As Integer
        buffer = "<table WIDTH=90% border=0 "

        'If Postazione.printStampaGriglia Then

        buffer &= " style=""border:1px solid #999999;font-family:Arial;font-size:11px;"" "

        ' End If

        buffer &= "><tr>"
        If IsOrdini Then

            buffer &= "<td bgcolor=""#FE6601"" align=center></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>Lavoro</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>Cliente</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>Prodotto</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>Q.ta</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>Nome Lavoro</b></td>"
            buffer &= "<td bgcolor=""#FE6601"" align=center><b>Totale</b></td>"
        Else
            For I = 0 To Dt.ColumnCount - 1
                If Dt.Columns(I).Visible Then buffer &= "<td bgcolor=""#FE6601"" align=center><font size=" & 1 & " Face=arial color=black><b>" & Dt.Columns(I).HeaderText & "</b></font></td>"
            Next
        End If

        buffer &= "</tr>"

        Dim J As Integer

        For I = 0 To Dt.Rows.Count - 1

            buffer &= "<tr>"

            If IsOrdini Then

                Using O As New Ordine

                    O.Read(Dt.Rows(I).Cells(3).Value)

                    buffer &= "<td><img src=""" & O.FilePath & """ width=100></td>"
                    buffer &= "<td>" & O.IdOrd & "</td>"
                    buffer &= "<td>" & O.VoceRubrica.RagSocNome & "</td>"
                    buffer &= "<td>" & O.Prodotto.Descrizione & "</td>"
                    buffer &= "<td>" & O.Qta & "</td>"
                    buffer &= "<td>" & O.NomeLavoro & "</td>"
                    buffer &= "<td>" & O.TotaleStrEx & "</td>"

                End Using

            Else
                For J = 0 To Dt.Columns.Count - 1

                    If Dt.Columns(J).Visible Then
                        buffer &= "<td "
                        '   If Postazione.printStampaGriglia Then

                        buffer &= " style=""border:1px solid #999999;"" "

                        'End If

                        'qui imposto lo stile 
                        Select Case Dt.Columns(J).DefaultCellStyle.Alignment
                            Case DataGridViewContentAlignment.MiddleCenter
                                buffer &= " align=center "
                            Case DataGridViewContentAlignment.MiddleRight
                                buffer &= " align=right "
                        End Select

                        buffer &= "bgcolor=white><font size=" & 1 & " Face=arial color=black>"
                        'If Dt.Columns(J).DefaultCellStyle.Format.Length Then
                        '    Try
                        '        buffer &= Dt.Rows(I).Cells(J).Value
                        '        'buffer &= Format(Dt.Rows(I).Cells(J).Value, Dt.Columns(J).DefaultCellStyle.Format)
                        '    Catch ex As Exception

                        '    End Try

                        'Else
                        If Dt.Rows(I).Cells(J).ValueType.Name <> "Image" Then
                            Dim Value As String = Dt.Rows(I).Cells(J).Value
                            Value = Value.Replace(ControlChars.NewLine, "<br>")
                            Value = Value.Replace("€", "&euro;")
                            buffer &= Value
                        End If

                        'End If

                        buffer &= "&nbsp;</font></td>"

                    End If

                Next
            End If

            buffer &= "</tr>"

        Next

        buffer &= "</table>"

        Return buffer

    End Function

    Public Sub ControlloCodice(ByRef sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs)
        Dim x As Char = vbBack
        If Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> x Then

            e.Handled = True

        End If

    End Sub

    'Public Sub ControlloMinUno(ByRef sender As Object)
    '    If sender.text.length = 0 Or sender.text = "0" Then
    '        sender.text = "1"
    '    End If
    'End Sub

End Module

'Public Module Ean

'    Public Function TrasformaInEan13(ByVal Codice As String) As String

'        Dim Ris As String = ""

'        Dim C As Char

'        For Each C In Codice

'            Select Case C
'                Case "0"
'                    Ris &= "a"

'                Case "1"
'                    Ris &= "b"

'                Case "2"
'                    Ris &= "c"

'                Case "3"
'                    Ris &= "d"

'                Case "4"
'                    Ris &= "e"

'                Case "5"
'                    Ris &= "f"

'                Case "6"
'                    Ris &= "g"

'                Case "7"
'                    Ris &= "h"

'                Case "8"
'                    Ris &= "i"

'                Case "9"
'                    Ris &= "l"

'            End Select

'        Next

'        Return Ris


'    End Function

'    Public Function TrasformaDaEan13(ByVal Codice As String) As String

'        Dim Ris As String = ""

'        Dim C As Char

'        For Each C In Codice

'            Select Case C
'                Case "A"
'                    Ris &= "0"

'                Case "B"
'                    Ris &= "1"

'                Case "C"
'                    Ris &= "2"

'                Case "D"
'                    Ris &= "3"

'                Case "E"
'                    Ris &= "4"

'                Case "F"
'                    Ris &= "5"

'                Case "G"
'                    Ris &= "6"

'                Case "H"
'                    Ris &= "7"

'                Case "I"
'                    Ris &= "8"

'                Case "L"
'                    Ris &= "9"
'                Case Else
'                    Ris &= C

'            End Select

'        Next

'        Return Ris


'    End Function

'    'Public Sub ColoraSfondo(ctl)
'    '    'On Error Resume Next
'    '    ctl.BackColor = Postazione.ColoreTema
'    '    If TypeOf (ctl) Is Button Then
'    '        ctl.forecolor = Postazione.ColorePrimoPiano
'    '        ctl.FlatAppearance.BorderSize = 0
'    '        ctl.FlatAppearance.Bordercolor = Color.White
'    '    ElseIf TypeOf (ctl) Is LinkLabel Then
'    '        ctl.LinkColor = Postazione.ColorePrimoPiano
'    '    End If


'    'End Sub

'End Module

'Public Module Mail

'    Public Function SendMail(ByVal strTo As String, _
'                             ByVal strSubject As String, _
'                             ByVal strBody As String, _
'                             ByVal strAttachments As String, _
'                             Optional ByVal Html As Boolean = False, _
'                             Optional ByVal RiportaErrore As Boolean = False) As String
'        Dim Ris As String = ""

'        Try
'            FormerHelper.Mail.InviaMail(strSubject, strBody, strTo, , , strAttachments)
'        Catch ex As Exception
'            If RiportaErrore Then
'                Ris = "Mail di riferimento: " & strTo & " - Errore: " & ex.Message.ToString()
'            Else
'                ManageError(ex)
'            End If
'        End Try



'        'Try

'        '    Dim strFrom As String = Postazione.Email
'        '    Dim insMail As New MailMessage(strFrom, strTo)

'        '    With insMail
'        '        .Subject = strSubject

'        '        .IsBodyHtml = Html

'        '        .Body = strBody

'        '        If Not strAttachments.Equals(String.Empty) Then
'        '            Dim strFile As String
'        '            Dim strAttach() As String = strAttachments.Split(";")
'        '            For Each strFile In strAttach
'        '                .Attachments.Add(New Attachment(strFile.Trim()))
'        '            Next
'        '        End If
'        '    End With

'        '    Dim server As New SmtpClient(Postazione.SmtpServer)

'        '    Dim cred As New System.Net.NetworkCredential(Postazione.Email, Postazione.EmailPwd)
'        '    server.UseDefaultCredentials = False
'        '    server.Credentials = cred

'        '    server.Send(insMail)

'        '    server = Nothing

'        'Catch e As Exception
'        '    If RiportaErrore Then
'        '        Ris = "Mail di riferimento: " & strTo & " - Errore: " & e.Message.ToString()
'        '    Else
'        '        ManageError(e)
'        '    End If


'        'End Try

'        Return Ris

'    End Function

'End Module

'Public Module Consegne

'    Public Sub RegistraConsegnaOrdineSuGiorno(IdOrd As Integer, IdCorr As Integer, Giorno As Date, IdRub As Integer, MomentoConsegna As Integer)

'        'prima cancello l'ordine dalle consegne programmate
'        'cerco una consegna programmata per quel cliente quel giorno con quel corriere
'        Dim mgr As New ConsegneProgrammateDAO
'        Dim lst As List(Of ConsegnaProgrammata) = mgr.Find(New LUNA.LunaSearchParameter("Giorno", Giorno), _
'                                                           New LUNA.LunaSearchParameter("IdCorr", IdCorr), _
'                                                           New LUNA.LunaSearchParameter("IdRub", IdRub), _
'                                                           New LUNA.LunaSearchParameter("MatPom", MomentoConsegna))
'        Dim OrdineRif As New Ordine
'        OrdineRif.Read(IdOrd)
'        Dim IdConsProgramata As Integer = 0
'        Dim C As ConsegnaProgrammata
'        Dim CreareConsegna As Boolean = True
'        If lst.Count Then
'            'qui ho trovato la consegna gia presente
'            C = lst(0)
'            IdConsProgramata = C.IdCons
'            'prima controllo che almeno uno degli ordini stia in uno stato antecedente a uscitoda magazzino, altrimenti scarto la consegna 
'            'e la faccio creare nuova
'            Dim cMgr As New OrdiniDAO
'            Dim lstO As List(Of OrdineRicerca) = cMgr.ListaOrdiniByIdCons(C.IdCons)
'            For Each o As OrdineRicerca In lstO
'                If o.Stato < enStatoOrdine.UscitoMagazzino Then
'                    CreareConsegna = False
'                    Exit For
'                End If
'            Next
'            If CreareConsegna = False Then
'                'se entro qui devo riportare indietro tutti gli ordini di quella consegna a non inserito
'                'riportare tutti gli ordini a imballaggio corriere
'                'mandare un messaggio agli operatori per avvisarli che la consegna va sballata e reimballata
'                If C.IdCorr <> enCorriere.RitiroCliente And C.IdCorr <> enCorriere.TipografiaFormer Then
'                    Dim cM As New ConsProgrOrdiniDAO
'                    Dim lM As List(Of ConsProgrOrdini) = cM.Find(New LUNA.LunaSearchParameter("IdCons", C.IdCons))
'                    For Each l As ConsProgrOrdini In lM
'                        Dim Oc As New Ordine
'                        Oc.Read(l.IdOrd)
'                        If Oc.Stato = enStatoOrdine.ProntoRitiro Then
'                            Dim MO As New OrdiniDAO
'                            MO.InserisciLog(Oc, enStatoOrdine.ImballaggioCorriere)
'                            Dim M As New Messaggio
'                            M.IdMitt = Postazione.UtenteConnesso.IdUt
'                            M.IdDest = 0
'                            M.IdOrd = Oc.IdOrd
'                            M.Titolo = "E' stata modificata la consegna programmata dell'ordine " & Oc.IdOrd
'                            M.Testo = "Attenzione, la consegna programmata dell'ordine " & Oc.IdOrd & " è stata modificata. I colli relativi alla consegna vanno rifatti"
'                            M.Save()
'                        End If
'                    Next
'                End If
'            End If
'        End If
'        If CreareConsegna Then
'            'qui la devo creare
'            C = New ConsegnaProgrammata
'            C.Giorno = Giorno
'            C.IdCorr = IdCorr
'            C.MatPom = MomentoConsegna
'            C.IdRub = IdRub
'            C.NumColli = OrdineRif.NumeroRealeColli
'            C.Peso = OrdineRif.Prodotto.PesoComplessivo
'            Dim R As New VoceRubrica
'            R.Read(IdRub)
'            C.IdPagam = R.IdPagamento
'            C.TipoDoc = R.TipoDoc
'            IdConsProgramata = C.Save()

'            If R.IdCorriere <> IdCorr Then
'                MessageBox.Show("ATTENZIONE! Il corriere previsto nell'ordine è diverso dal corriere che è stato inserito come default per il cliente!", , MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            End If
'        End If
'        Dim cO As New ConsProgrOrdini
'        cO.IdCons = IdConsProgramata
'        cO.IdOrd = IdOrd
'        cO.Save()
'    End Sub

'End Module