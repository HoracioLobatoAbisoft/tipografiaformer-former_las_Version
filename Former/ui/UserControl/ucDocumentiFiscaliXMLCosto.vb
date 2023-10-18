Imports System.IO
Imports FormerBusinessLogic
Imports FormerConfig
Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucDocumentiFiscaliXMLCosto
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Event WebLoadComplete()

    Public Property CaricamentoCompletato As Boolean = False

    Private Sub CaricamentoIniziale(Optional XslConPath As Boolean = True)
        CaricamentoCompletato = False
        webFattura.Navigate("about:blank")

        lblIdSDI.Text = _C.IdentificativoSdI
        lblStato.Text = _C.StatoFEStr
        txtXMLOut.Text = _C.DocXML
        lblIdentificativo.Text = _C.IdMessaggioFE
        If _C.DocXML.Length Then
            Dim f As FatturaElettronica = MgrFattureFE.GetFatturaFromXMLBuffer(_C.DocXML)
            If Not f.FatturaElettronicaBody.DatiPagamento Is Nothing AndAlso
                Not f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento Is Nothing AndAlso
                Not f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento Is Nothing Then
                lblModalitaPagamento.Text = f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento & " " & MgrFattureFE.GetTipoPagamentoDescrizione(f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ModalitaPagamento)
            Else
                lblModalitaPagamento.Text = "-"
            End If

            If Not f.FatturaElettronicaBody.DatiPagamento Is Nothing AndAlso
                Not f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento Is Nothing AndAlso
                Not f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento Is Nothing Then
                lblScadenza.Text = MgrFattureFE.GetDataFromFormatoFE(f.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.DataScadenzaPagamento).ToString("dd/MM/yyyy")
            Else
                lblScadenza.Text = "-"
            End If
        End If

        If _C.DocXML.Length Then
            lnkImportXML.Enabled = False
            MgrAnteprime.CreaFatturaElettronica(_C.DocXML, webFattura)
        End If

        If _C.DataOraRicezione <> Date.MinValue Then lblInviatoIl.Text = _C.DataOraRicezione.ToString("dd/MM/yyyy HH:mm.ss")

    End Sub

    Private _C As Costo = Nothing
    Public Sub Carica(C As Costo,
                      Optional XslConPath As Boolean = True)
        _C = C

        'webFattura

        CaricamentoIniziale(XslConPath)

    End Sub

    Private Sub lnkExportXML_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkImportXML.LinkClicked
        If _C.StatoFE = enStatoFatturaFE.DaInviare Then
            If MessageBox.Show("Vuoi allegare il file XML al Documento fiscale?", "Import in XML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If dlgXML.ShowDialog() = DialogResult.OK Then

                    Dim PathRis As String = dlgXML.FileName
                    Dim Buffer As String = String.Empty

                    Using r As New StreamReader(PathRis)
                        Buffer = r.ReadToEnd
                    End Using

                    _C.DocXML = Buffer
                    _C.StatoFE = enStatoFatturaFE.InviatoXML
                    _C.DataOraRicezione = Now
                    _C.Save()

                    CaricamentoIniziale()

                End If

            End If
        Else
            MessageBox.Show("Non è possibile allegare il file XML in questo stato")
        End If

    End Sub

    Private Sub lnkStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        If Not webFattura.Document Is Nothing Then

            webFattura.ShowPrintDialog()

        End If
    End Sub

    Private Sub webFattura_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles webFattura.DocumentCompleted

        If e.Url.AbsolutePath = (FormerPath.PathTempLocale & "tempfattura.xml").Replace("\", "/") Then
            RaiseEvent WebLoadComplete()
            CaricamentoCompletato = True
        End If

    End Sub

    Public Sub StampaFatturaWithDialog()
        webFattura.ShowPrintDialog()
    End Sub

    Public Sub StampaFattura()
        webFattura.Print()
    End Sub
End Class
