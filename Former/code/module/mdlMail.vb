Imports FormerLib.FormerEnum
Imports FormerDao

'Module mdlMail

'    'Friend Sub InviaMailRispostaOrdine(ByVal stato As enStatoOrdMail, ByVal Ord As Ordine, ByVal Note As String, ByVal Dest As String)

'    '    Dim SoggettoMail As String = ""
'    '    Dim TestoMail As String = ""
'    '    Dim Attach As String = ""

'    '    If stato = enStatoOrdMail.Accettato Then

'    '        SoggettoMail = "Il suo ordine è stato ACCETTATO"

'    '        TestoMail = "Siamo lieti di informarla che il suo ordine del " & Date.Now & "è stato ACCETTATO." & ControlChars.NewLine & ControlChars.NewLine
'    '        TestoMail &= "Tutte le successive comunicazioni relative a questo ordine avranno come riferimento il numero:" & ControlChars.NewLine & ControlChars.NewLine
'    '        TestoMail &= "-  numero ordine: " & Ord.IdOrd & ControlChars.NewLine & ControlChars.NewLine
'    '        TestoMail &= "Cordiali saluti" & ControlChars.NewLine & ControlChars.NewLine

'    '        Attach = Ord.File

'    '    Else 'rifiutato

'    '        SoggettoMail = "Il suo ordine è stato RIFIUTATO"

'    '        TestoMail = "Siamo spiacenti di informarla che il suo ordine:" & ControlChars.NewLine & ControlChars.NewLine

'    '        TestoMail &= "- data: " & Now & ControlChars.NewLine & ControlChars.NewLine

'    '        TestoMail &= "è stato RIFIUTATO per il seguente motivo:" & ControlChars.NewLine & ControlChars.NewLine
'    '        TestoMail &= Note & ControlChars.NewLine & ControlChars.NewLine
'    '        TestoMail &= "Restiamo a disposizione per eventuali chiarimenti. Cordiali saluti" & ControlChars.NewLine & ControlChars.NewLine


'    '    End If

'    '    SendMail(Dest, SoggettoMail, TestoMail, Attach)


'    'End Sub

'    'Friend Sub InviaMailVersiosneNonCorretta(ByVal Dest As String)

'    '    Dim SoggettoMail As String = ""
'    '    Dim TestoMail As String = ""
'    '    Dim Attach As String = ""

'    '    SoggettoMail = "Importante! Aggiornamento programma FORMER CLIENTI"

'    '    TestoMail = "Gentile Cliente, " & ControlChars.NewLine & ControlChars.NewLine

'    '    TestoMail &= "la invitiamo ad aggiornare il programma FORMER CLIENTI inquanto è disponibile una nuova versione. " & Now & ControlChars.NewLine & ControlChars.NewLine

'    '    TestoMail &= "Restiamo a disposizione per eventuali chiarimenti. Cordiali saluti" & ControlChars.NewLine & ControlChars.NewLine

'    '    SendMail(Dest, SoggettoMail, TestoMail, Attach)

'    'End Sub

'    'Friend Sub InviaMailCambiostato(ByVal Ord As Ordine)

'    '    If Ord.Stato > enStatoOrdine.Registrato Then

'    '        Dim SoggettoMail As String = "Cambio stato Ordine numero: " & Ord.IdOrd
'    '        Dim TestoMail As String = ""
'    '        Dim Attach As String = ""
'    '        Dim MailDest As String = ""

'    '        'mi trvo la mail del destinatario

'    '        Dim Cli As New VoceRubrica

'    '        Cli.Read(Ord.IdRub)
'    '        MailDest = Cli.Email.ToString

'    '        If MailDest.Length Then

'    '            TestoMail = "Siamo lieti di informarla che il suo ordine numero " & Ord.IdOrd & " del " & Ord.DataIns & ControlChars.NewLine & ControlChars.NewLine

'    '            TestoMail &= "è passato allo stato " & Ord.StatoStr & ControlChars.NewLine & ControlChars.NewLine

'    '            If Ord.Stato = enStatoOrdine.ProntoRitiro Then
'    '                If Ord.IdCorriere Then
'    '                    TestoMail &= "Il materiale è pronto per "
'    '                    Dim corr As New Corriere
'    '                    corr.Read(Ord.IdCorriere)
'    '                    TestoMail &= corr.TestoMail
'    '                    TestoMail &= ControlChars.NewLine & ControlChars.NewLine
'    '                End If

'    '            End If

'    '            TestoMail &= "Cordiali saluti" & ControlChars.NewLine & ControlChars.NewLine
'    '            TestoMail &= "Tipografia FORMER " & ControlChars.NewLine
'    '            TestoMail &= "tel 06.30884057" & ControlChars.NewLine
'    '            TestoMail &= "info@tipografiaformer.com" & ControlChars.NewLine
'    '            TestoMail &= "http://www.tipografiaformer.it" & ControlChars.NewLine

'    '            Attach = Ord.File

'    '            SendMail(MailDest, SoggettoMail, TestoMail, Attach)

'    '        End If
'    '    End If

'    'End Sub

'End Module
