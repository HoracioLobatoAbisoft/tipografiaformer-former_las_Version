Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig

Friend Class frmMagazzinoBarCodeCorriere
    'Inherits baseFormInternaFixed
    Private _Ris As String = ""
    Private _BufferCodice As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(btnOk)
        'ColoraSfondo(btnCancel)

    End Sub

    Private _IdCorr As Integer = 0

    Friend Function Carica(Optional Msg As String = "",
                           Optional IdCorr As Integer = 0,
                           Optional ByVal MsgSupplement As String = "") As String

        _IdCorr = IdCorr

        Select Case _IdCorr
            Case enCorriere.GLS, enCorriere.PortoAssegnatoGLS, enCorriere.GLSIsole
                pctTipo.Visible = True
                pctTipo.Image = Former.My.Resources.logo_gls
            Case enCorriere.Bartolini, enCorriere.PortoAssegnatoBartolini
                pctTipo.Visible = True
                pctTipo.Image = Former.My.Resources.brt
        End Select

        'If _IdCorr Then
        '    btnHelp.Visible = True
        'Else
        btnHelp.Visible = False
        'End If

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
            btnHelp.Visible = True
            btnPulisci.Visible = True
            btnIncolla.Visible = True
        End If

        txtCodice.Focus()

        'If FormerDebug.DebugAttivo Then Me.AcceptButton = Nothing

        If Msg.Length Then
            lblMsg.Text = Msg
        Else
            lblMsg.Text = "Leggere il codice a barre sull'etichetta oppure inserire il codice che si trova nello spazio evidenziato in rosso."
        End If

        If MsgSupplement.Length Then
            lblMsg.Text &= vbNewLine & MsgSupplement
        End If

        'If IdOrd Then
        '    Dim O As New Ordine
        '    O.Read(IdOrd)
        '    Try
        '        pctAnte.Load(O.FilePath)
        '    Catch ex As Exception

        '    End Try
        'ElseIf IdCons Then
        '    'qui ho una consegna devo caricare l'immagine del pacco
        '    pctAnte.Image = My.Resources.scatola_chiusa
        'End If

        Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 30
        Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 30

        ShowDialog()
        _Ris = _Ris.TrimEnd
        Return _Ris

    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _Ris = ""

        Close()

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim Codice As String = txtCodice.Text

        'GLS SONO 16 CARATTERI SPARATI
        'BARTOLINI 18 CARATTERI SPARATI E 15 IN MANUALE
        If Codice.Length = 15 Or Codice.Length = 16 Or Codice.Length = 18 Then

            '_Ris = FromEan13(Codice)
            'If rdoManuale.Checked Then
            '    If Codice.StartsWith("0") Then Codice = Codice.Substring(1) & "0"
            'End If
            _Ris = Codice
            Close()

        Else
            MessageBox.Show("Codice inserito formalmente non valido!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub txtCodice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodice.KeyPress
        'MgrControl.ControlloNumerico(sender, e, True)
    End Sub

    Private Sub frmBarCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If rdoBarCode.Checked Then
            _BufferCodice &= e.KeyChar

            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                _Ris = _BufferCodice
                'If _Ris.Length > 13 Then
                '    _Ris = _Ris.Substring(0, 13)
                'End If
                '_Ris = FromEan13(_BufferCodice)

                'If FormerDebug.DebugAttivo Then MessageBox.Show(_Ris, "codice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Close()

            End If

        End If
    End Sub

    Private Sub rdoManuale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoManuale.CheckedChanged

        txtCodice.Enabled = rdoManuale.Checked
        btnOk.Visible = rdoManuale.Checked
        btnIncolla.Enabled = rdoManuale.Checked
        btnPulisci.Enabled = rdoManuale.Checked

    End Sub

    Private Sub rdoBarCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBarCode.CheckedChanged
        If rdoBarCode.Checked Then
            Me.AcceptButton = Nothing
        Else
            Me.AcceptButton = btnOk
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Cursor = Cursors.WaitCursor
        Dim PathCodici As String = FormerPath.PathTemp & FormerLib.FormerHelper.File.GetNomeFileTemp(".txt")
        Try
            'creo il file con i codici mancanti 
            Using w As New StreamWriter(PathCodici)
                Dim C As New ConsegnaProgrammata
                C.Read(_IdCorr)

                Dim lS As New List(Of Integer)

                For Each O As Ordine In C.ListaOrdini
                    If O.Stato = enStatoOrdine.ProntoRitiro Then

                        'qui prima devo controllare se questo ordine e' in una scatola
                        Dim l As List(Of OrdineScatola) = Nothing
                        Using mgr As New OrdiniScatoleDAO
                            l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.OrdineScatola.IdOrdine, O.IdOrd))
                        End Using

                        If l.Count = 0 Then
                            w.WriteLine("Ordine " & O.IdOrd)
                            w.WriteLine("***************")
                            Dim NumColli As Integer = O.NumeroColliCalcolati
                            If O.NumeroRealeColli Then NumColli = O.NumeroRealeColli
                            For i As Integer = 1 To NumColli
                                w.WriteLine("Collo " & i & ": " & "000" & O.IdOrd & i.ToString("0000") & "0")
                            Next
                            w.WriteLine(" ")
                        Else
                            'qui ci sono scatole per questa consegna 
                            For Each singScat In l
                                If lS.FindAll(Function(x) x = singScat.IdScatola).Count = 0 Then
                                    lS.Add(singScat.IdScatola)
                                End If
                            Next
                        End If
                    End If
                Next

                If lS.Count Then
                    For Each IDScat As Integer In lS
                        'qui ho le scatole 
                        w.WriteLine("Scatola Corriere " & IDScat)
                        w.WriteLine("***************")
                        w.WriteLine("Collo : 9" & FormerHelper.Stringhe.FormattaConZeri(IDScat, 7) & FormerHelper.Stringhe.FormattaConZeri(1, 4))
                        w.WriteLine(" ")
                    Next
                End If

            End Using

        Catch ex As Exception
            Beep()
        End Try
        Cursor = Cursors.Default
        FormerHelper.File.ShellExtended(PathCodici)

    End Sub

    Private Sub btnPulisci_Click(sender As Object, e As EventArgs) Handles btnPulisci.Click
        txtCodice.Text = String.Empty
    End Sub

    Private Sub btnIncolla_Click(sender As Object, e As EventArgs) Handles btnIncolla.Click
        txtCodice.Text = Clipboard.GetText()
    End Sub

    Private Sub txtCodice_LostFocus(sender As Object, e As EventArgs) Handles txtCodice.LostFocus
        txtCodice.Text = txtCodice.Text.TrimEnd(" ")
    End Sub
End Class