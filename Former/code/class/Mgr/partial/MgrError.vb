Imports System.Windows.Forms
Imports FormerLib
Public Class MgrError
    Inherits FormerError.MgrError

    Public Overloads Shared Function ManageError(ByRef ex As Exception,
                            Optional ByVal dettaglio As String = "",
                            Optional NonGestito As Boolean = False) As Integer

        'Using f As New frmBug
        '    f.Carica(Me)
        'End Using

        'gestione errori generale
        Dim x As New Random

        Dim NomeFile As String = FormerConfig.FormerPath.PathLocale & "Err" & x.Next(0, 100000).ToString & ".txt"

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

        ScriviLogFile(NomeFile, Messaggioerrore)

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

End Class
