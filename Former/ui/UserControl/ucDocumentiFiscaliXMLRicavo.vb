Imports FormerBusinessLogic
Imports FormerConfig
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucDocumentiFiscaliXMLRicavo
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Private _R As Ricavo = Nothing
    Public Property CaricamentoCompletato As Boolean = False

    Private Sub CaricaDati()
        lblStato.Text = _R.StatoFEStr
        If _R.DataOraInvio <> Date.MinValue Then
            lblInviatoIl.Text = _R.DataOraInvio.ToString("dd/MM/yyyy HH:mm.ss")
        End If
        txtXMLOut.Text = _R.DocXML
        'lblIdSDI.Text = _R.IdentificativoSdI
        txtXMLIn.Text = _R.RicevutaXML
        'lblIdentificativo.Text = _R.IdMessaggioFE
        txtInfo.Text = _R.InfoFE
        If _R.DocXML.Length Then
            MgrAnteprime.CreaFatturaElettronica(_R.DocXML, webFattura)
        End If
        If _R.AnnoRiferimento >= 2019 Then
            If _R.StatoFE = enStatoFatturaFE.DaInviare OrElse _R.StatoFE = enStatoFatturaFE.ScartataSDI OrElse _R.StatoFE = enStatoFatturaFE.ConsegnataPEC Then
                lnkSendXML.Enabled = True
                lnkOutCoda.Enabled = False
            ElseIf _R.StatoFE = enStatoFatturaFE.InCodaInvio Then
                lnkSendXML.Enabled = False
                lnkOutCoda.Enabled = True
            Else
                lnkSendXML.Enabled = False
                lnkOutCoda.Enabled = False
            End If
        Else
            lnkSendXML.Enabled = False
            lnkOutCoda.Enabled = False
        End If

    End Sub

    Public Sub Carica(R As Ricavo)

        _R = R

        CaricaDati()

    End Sub

    Private Sub lnkExportXML_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkExportXML.LinkClicked

        If MessageBox.Show("Confermi l'export del documento in XML?", "Export in XML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim PathTemp As String = FormerPath.PathTempLocale & _R.AnnoRiferimento & "\" & _R.Numero & "\IT" & MgrAziende.GetPartitaIva(_R.IdAzienda) & "_00001.xml"

            FormerHelper.File.CreateLongPath(PathTemp)

            Dim Ris As String = MgrFattureFE.RicavoToXML(_R, PathTemp)

            FormerHelper.File.ShellExtended(PathTemp)

        End If

    End Sub

    Public Event WebLoadComplete()
    Private Sub lnkSendXML_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSendXML.LinkClicked

        'MessageBox.Show("Funzione non ancora completata")
        'Exit Sub
        Dim OkFattura As String = _R.VoceRubrica.Fatturabile
        If OkFattura.Length = 0 Then
            If _R.AnnoRiferimento >= 2019 Then
                Dim NewId As Integer = _R.IdRicavo
                Dim StatoAggiornato As enStatoFatturaFE = MgrFattureFE.GetStatoAggiornatoFatturaFE(_R.IdRicavo)
                If StatoAggiornato = enStatoFatturaFE.DaInviare OrElse
                   StatoAggiornato = enStatoFatturaFE.ScartataSDI OrElse
                   StatoAggiornato = enStatoFatturaFE.ConsegnataPEC Then

                    If MessageBox.Show("Confermi l'inserimento del documento in coda per l'invio all'agenzia entrate?", "Invio in XML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        'Dim PathTemp As String = FormerPath.PathTempLocale & _R.AnnoRiferimento & "\" & _R.Numero & "\IT" & MgrAziende.GetPartitaIva(_R.IdAzienda) & "_00001.xml"

                        'FormerHelper.File.CreateLongPath(PathTemp)

                        '_R.DocXML = MgrFatturePA.RicavoToXML(_R, PathTemp)
                        '_R.DataOraInvio = Now
                        _R.StatoFE = enStatoFatturaFE.InCodaInvio
                        _R.InfoFE = String.Empty
                        _R.Save()

                        RaiseEvent CambiatoStatoFE()
                        CaricaDati()
                        'If MessageBox.Show("Confermi l'invio della PEC all'agenzia delle entrate?", "Invio in XML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        '    'qui la devo spedire tramite PEC
                        '    'FormerHelper.File.ShellExtended(PathTemp)
                        '    'sdi01@pec.fatturapa.it

                        '    Dim ListaAllegati As New List(Of String)
                        '    ListaAllegati.Add(PathTemp)

                        '    Dim Ris As Integer = MgrFatturePA.InviaFatturaPEC(ListaAllegati, _R.IdAzienda)
                        '    If Ris = 0 Then
                        '        MessageBox.Show("Fattura Inviata")
                        '    Else
                        '        MessageBox.Show("Si è verificato un errore nell'invio della fattura. Codice: " & Ris)
                        '    End If


                        'End If



                    Else
                        MessageBox.Show("Lo stato della fattura non è in stato coerente per l'invio")
                    End If
                End If
            Else
                MessageBox.Show("Si possono inserire in coda invio solo documenti fiscali dal 2019")
            End If
        Else
            MessageBox.Show("I dati fiscali del cliente per l'invio della fattura non sono presenti o validi: " & OkFattura)
        End If

    End Sub

    Public Event CambiatoStatoFE()

    Private Sub lnkGeneraXML_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGeneraXML.LinkClicked
        If _R.Stato = enStatoFatturaFE.DaInviare OrElse
          _R.Stato = enStatoFatturaFE.ScartataSDI Then
            If MessageBox.Show("Confermi la generazione del documento in XML?", "Generazione in XML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim PathTemp As String = FormerPath.PathTempLocale & _R.AnnoRiferimento & "\" & _R.Numero & "\IT" & MgrAziende.GetPartitaIva(_R.IdAzienda) & "_00001.xml"

                FormerHelper.File.CreateLongPath(PathTemp)

                Dim Ris As String = MgrFattureFE.RicavoToXML(_R, PathTemp)

                txtXMLOut.Text = Ris

                If MessageBox.Show("Vuoi salvare l'XML generato come definitivo?", "Export in XML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    _R.DocXML = Ris
                    _R.Save()
                End If

                FormerHelper.File.ShellExtended(PathTemp)

            End If

        Else
            MessageBox.Show("Lo stato della fattura non è in stato coerente per la generazione")
        End If
    End Sub

    Private Sub lnkOutCoda_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOutCoda.LinkClicked


        If MgrFattureFE.GetStatoAggiornatoFatturaFE(_R.IdRicavo) = enStatoFatturaFE.InCodaInvio Then
            If MessageBox.Show("Confermi la cancellazione del documento da coda per l'invio all'agenzia entrate?", "Invio in XML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                _R.DocXML = String.Empty
                _R.DataOraInvio = Date.MinValue
                _R.StatoFE = enStatoFatturaFE.DaInviare
                _R.Save()

                RaiseEvent CambiatoStatoFE()

                CaricaDati()

                'If MessageBox.Show("Confermi l'invio della PEC all'agenzia delle entrate?", "Invio in XML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                '    'qui la devo spedire tramite PEC
                '    'FormerHelper.File.ShellExtended(PathTemp)
                '    'sdi01@pec.fatturapa.it

                '    Dim ListaAllegati As New List(Of String)
                '    ListaAllegati.Add(PathTemp)

                '    Dim Ris As Integer = MgrFatturePA.InviaFatturaPEC(ListaAllegati, _R.IdAzienda)
                '    If Ris = 0 Then
                '        MessageBox.Show("Fattura Inviata")
                '    Else
                '        MessageBox.Show("Si è verificato un errore nell'invio della fattura. Codice: " & Ris)
                '    End If


                'End If

            End If
        End If


    End Sub
    Private Sub webFattura_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles webFattura.DocumentCompleted

        If e.Url.AbsolutePath = (FormerPath.PathTempLocale & "tempfattura.xml").Replace("\", "/") Then
            RaiseEvent WebLoadComplete()
            CaricamentoCompletato = True
        End If

    End Sub

    Private Sub lnkStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        If Not webFattura.Document Is Nothing Then

            webFattura.ShowPrintDialog()

        End If
    End Sub

    Public Sub StampaFattura()
        webFattura.Print()
    End Sub

End Class
