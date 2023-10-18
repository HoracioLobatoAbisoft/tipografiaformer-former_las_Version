Imports FormerLib
Imports FormerConfig
Imports FormerLib.FormerEnum
Imports FormerConfig.FConfiguration
Imports System.IO

#Region "Author"

'All rights reserved.

'Author: Diego Lunadei
'Date: Marzo 2008

#End Region

Public Class frmStampa
    'Inherits baseFormInternaFixed

    Private Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Long

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(btnOk)
    End Sub

    Public Sub Carica(ByRef WebBrowser As WebBrowser)

        Dim Sr As StreamWriter, PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")
        Sr = New System.IO.StreamWriter(PathFileStampa, False)

        Sr.Write(WebBrowser.DocumentText)

        Sr.Close()

        Carica(PathFileStampa)

        ''             sr = Nothing
    End Sub

    Public Sub Carica(ByVal NomeFile As String)

        If Not PostazioneCorrente.UtenteConnesso Is Nothing AndAlso PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then
            SetDefaultPrinter(Printer.FattureSrl)
        End If

        WebPrint.Navigate(NomeFile)

        ShowDialog()

    End Sub

    Private Sub btnAnteprima_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteprima.Click

        WebPrint.ShowPrintPreviewDialog()

    End Sub

    Private Sub btnChiudi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Close()

    End Sub

    Private Sub WebPrint_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebPrint.DocumentCompleted

        btnAnteprima.Enabled = True

    End Sub

    Private Sub btnImposta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImposta.Click

        WebPrint.ShowPageSetupDialog()

    End Sub

    Private Sub tabStampa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabStampa.SelectedIndexChanged

        If tabStampa.SelectedTab Is TabPHelp Then

            webHelp.Navigate(FormerPath.PathLocale & "help\stampe.htm")

        End If

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Close()

    End Sub

End Class