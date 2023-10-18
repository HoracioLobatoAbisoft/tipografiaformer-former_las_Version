Imports FormerDALSql
Imports FormerLib
Imports FormerWebLabeling
Imports F = FormerDALSql
Imports FW = FormerDALWeb

Friend Class frmIndirizzo
    'Inherits baseFormInternaRedim

    Private _Ris As Integer = 0

    Dim VoceRub As F.VoceRubrica
    Dim IndirizzoInt As F.Indirizzo
    'Dim IndirizzoOnline As FW.Indirizzo
    Dim ComuneScelto As F.ComuneInElenco

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Friend Function Carica(ByVal IdRub As Integer,
                           Optional ByVal IdIndirizzo As Integer = 0) As Integer

        VoceRub = New F.VoceRubrica
        IndirizzoInt = New F.Indirizzo
        'IndirizzoOnline = New FW.Indirizzo
        ComuneScelto = New F.ComuneInElenco

        cmbNazione.DisplayMember = "Riassunto"
        cmbNazione.ValueMember = "IdNazione"
        cmbNazione.DataSource = MgrNazioni.GetLista()

        VoceRub.Read(IdRub)
        If IdIndirizzo Then
            lblTitolo.Text = "Modifica Indirizzo"
            IndirizzoInt.Read(IdIndirizzo)
            'IndirizzoOnline.Read(IndirizzoInt.IdIndOnline)
            txtRiferimento.Text = IndirizzoInt.Nome
            txtIndirizzo.Text = IndirizzoInt.Indirizzo
            MgrControl.SelectIndexCombo(cmbNazione, IndirizzoInt.IdNazione)
            txtCAP.Text = IndirizzoInt.Cap
            cmbLocalita.SelectedValue = IndirizzoInt.Localita.IDCap
            chkPredefinito.Checked = IndirizzoInt.Predefinito
            chkDisattiva.Checked = IndirizzoInt.Status
            txtDestinatario.Text = IndirizzoInt.Destinatario
        Else
            lblTitolo.Text = "Nuovo Indirizzo"
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub cmbNazione_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNazione.SelectedIndexChanged
        If cmbNazione.SelectedValue = FormerLib.FormerConst.Culture.IdItalia Then
            cmbLocalita.DropDownStyle = ComboBoxStyle.DropDownList
            txtCAP.Text = String.Empty
            txtCAP.Enabled = True
        Else
            cmbLocalita.DropDownStyle = ComboBoxStyle.Simple
            txtCAP.Text = FormerConst.Culture.CapEstero
            txtCAP.Enabled = False
        End If
        'txtCAP.Text = String.Empty
        cmbLocalita.DataSource = Nothing
        cmbLocalita.Text = String.Empty

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dell'indirizzo?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If ModuloValido() Then
                ComuneScelto.Read(cmbLocalita.SelectedValue)

                Dim IndirizzoCorretto As Boolean = False

                If cmbNazione.SelectedValue = FormerLib.FormerConst.Culture.IdItalia Then
                    IndirizzoCorretto = GlsCheckAddress(ComuneScelto.Provincia,
                                                        txtCAP.Text,
                                                        ComuneScelto.Comune,
                                                        txtIndirizzo.Text,
                                                        cmbNazione.SelectedValue)
                Else
                    IndirizzoCorretto = True
                End If

                If IndirizzoCorretto = False Then
                    If MessageBox.Show("L'indirizzo sembra non essere corretto. Vuoi salvare lo stesso?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        SalvaIndirizzo()
                    End If
                Else
                    SalvaIndirizzo()
                End If
            Else
                MessageBox.Show("Riempire i campi obbligatori (*)!")
            End If
        End If
    End Sub

    Private Sub txtCAP_TextChanged(sender As Object, e As EventArgs) Handles txtCAP.TextChanged

        Dim CapScelto As String = txtCAP.Text

        If cmbNazione.SelectedValue = FormerLib.FormerConst.Culture.IdItalia Then

            If CapScelto.Length = 5 Then

                'qui provo a caricare le località

                CaricaLocalita(CapScelto)
            Else
                cmbLocalita.DataSource = Nothing
            End If
        Else
            cmbLocalita.DataSource = Nothing

        End If



    End Sub

    Private Sub CaricaLocalita(Cap As String)
        Dim IdComune As Integer = 0
        Using Mgr As New F.ElencoComuniDAO
            Dim l As List(Of F.ComuneInElenco) = Mgr.FindAll(New F.LUNA.LunaSearchOption With {.OrderBy = "Comune", .AddEmptyItem = True},
                                                             New F.LUNA.LunaSearchParameter(F.LFM.ComuneInElenco.CAP, Cap))
            If l.Count Then
                cmbLocalita.DisplayMember = "Riassunto"
                cmbLocalita.ValueMember = "IdCap"
                cmbLocalita.DataSource = l
            Else
                cmbLocalita.Items.Clear()
            End If
        End Using
    End Sub

    Private Sub SalvaIndirizzo()

        Using tb As F.LUNA.LunaTransactionBox = F.LUNA.LunaContext.CreateTransactionBox
            Using tbO As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox
                Try

                    tb.TransactionBegin()
                    tbO.TransactionBegin()

                    Dim IndirizzoOnline As FW.Indirizzo = New FW.Indirizzo

                    If IndirizzoInt.IdIndOnline Then IndirizzoOnline.Read(IndirizzoInt.IdIndOnline)

                    If chkPredefinito.Checked Then
                        Using mgr As New FW.IndirizziDAO
                            mgr.ResetPredefinito(VoceRub.IdUtOnline)
                        End Using
                        Using mgr As New F.IndirizziDAO
                            mgr.ResetPredefinito(VoceRub.IdRub)
                        End Using
                    End If

                    If cmbNazione.SelectedValue = FormerLib.FormerConst.Culture.IdItalia Then
                        IndirizzoInt.IdComune = cmbLocalita.SelectedValue
                        IndirizzoInt.Citta = ComuneScelto.Comune
                        IndirizzoInt.Provincia = ComuneScelto.Provincia
                        IndirizzoInt.IdProvincia = ComuneScelto.ProvinciaSel.ID
                    Else
                        IndirizzoInt.IdComune = 0
                        IndirizzoInt.IdProvincia = 0
                        IndirizzoInt.Provincia = String.Empty
                        IndirizzoInt.Citta = cmbLocalita.Text
                    End If

                    IndirizzoInt.IdRubrica = VoceRub.IdRub
                    'IndirizzoInt.IdComune = cmbLocalita.SelectedValue
                    IndirizzoInt.Cap = txtCAP.Text
                    'IndirizzoInt.Citta = ComuneScelto.Comune
                    'IndirizzoInt.IdProvincia = ComuneScelto.ProvinciaSel.ID
                    IndirizzoInt.Indirizzo = txtIndirizzo.Text
                    IndirizzoInt.Destinatario = txtDestinatario.Text
                    IndirizzoInt.Telefono = txtTel.Text
                    IndirizzoInt.Nome = txtRiferimento.Text
                    IndirizzoInt.Predefinito = chkPredefinito.Checked
                    IndirizzoInt.Status = chkDisattiva.Checked
                    IndirizzoInt.IdNazione = cmbNazione.SelectedValue
                    Dim IdIndirizzoInt As Integer = IndirizzoInt.Save()

                    IndirizzoOnline.IdUt = VoceRub.IdUtOnline
                    IndirizzoOnline.IdComune = IndirizzoInt.IdComune 'cmbLocalita.SelectedValue
                    IndirizzoOnline.Cap = IndirizzoInt.Cap 'txtCAP.Text
                    IndirizzoOnline.Citta = IndirizzoInt.Citta 'ComuneScelto.Comune
                    IndirizzoOnline.IdProvincia = IndirizzoInt.IdProvincia 'ComuneScelto.ProvinciaSel.ID
                    IndirizzoOnline.Indirizzo = IndirizzoInt.Indirizzo 'txtIndirizzo.Text
                    IndirizzoOnline.Destinatario = IndirizzoInt.Destinatario 'txtDestinatario.Text
                    IndirizzoOnline.Telefono = IndirizzoInt.Telefono 'txtTel.Text
                    IndirizzoOnline.Nome = IndirizzoInt.Nome 'txtRiferimento.Text
                    IndirizzoOnline.Predefinito = IndirizzoInt.Predefinito 'chkPredefinito.Checked
                    IndirizzoOnline.Status = IndirizzoInt.Status 'chkDisattiva.Checked
                    IndirizzoOnline.IdNazione = IndirizzoInt.IdNazione 'cmbNazione.SelectedValue

                    If IndirizzoOnline.IdIndirizzo = 0 Then
                        IndirizzoOnline.IdIndirizzoInt = IdIndirizzoInt
                        IndirizzoOnline.Save()
                        IndirizzoInt.IdIndOnline = IndirizzoOnline.IdIndirizzo
                        IndirizzoInt.Save()
                    Else
                        IndirizzoOnline.Save()
                    End If

                    tb.TransactionCommit()
                    tbO.TransactionCommit()

                Catch ex As Exception
                    tb.TransactionRollBack()
                    tbO.TransactionRollBack()
                    MessageBox.Show("Errore durante il salvataggio: " & ex.Message)
                End Try
            End Using
        End Using

        _Ris = 1

        Close()

    End Sub

    Private Function ModuloValido() As Boolean
        Dim ris As Boolean = True

        If txtRiferimento.Text.Trim.Length < 2 Then
            ris = False
        End If

        If txtRiferimento.Text.Trim.Length = 0 Then
            ris = False
        End If

        If txtIndirizzo.Text.Trim.Length = 0 Then
            ris = False
        End If

        If cmbNazione.SelectedValue = FormerLib.FormerConst.Culture.IdItalia Then
            If txtCAP.Text.Length <> 5 Then ris = False
            If cmbLocalita.SelectedIndex = 0 Then ris = False
        Else
            If txtCAP.Text.Length = 0 Then ris = False
            If cmbLocalita.Text = String.Empty Then ris = False
        End If

        Return ris
    End Function

    Private Function GlsCheckAddress(ByVal Provincia As String,
                                     ByVal Cap As String,
                                     ByVal Localita As String,
                                     ByVal Indirizzo As String,
                                     ByVal IdNazione As Integer) As Boolean
        Dim Ris As RisValidazioneIndirizzo = Nothing

        Try
            Ris = FormerWebLabeling.MgrWebLabelingGls.CheckAddress(Provincia, Cap, Localita, Indirizzo, IdNazione)
        Catch ex As Exception

        End Try

        Return Ris.Valido

    End Function

    Private Sub chkDisattiva_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisattiva.CheckedChanged
        If chkDisattiva.Checked Then
            chkPredefinito.Checked = False
            chkPredefinito.Enabled = False
        Else
            chkPredefinito.Enabled = True
        End If
    End Sub

    Private Sub chkPredefinito_CheckedChanged(sender As Object, e As EventArgs) Handles chkPredefinito.CheckedChanged
        If chkPredefinito.Checked Then
            chkDisattiva.Checked = False
            chkDisattiva.Enabled = False
        Else
            chkDisattiva.Enabled = True
        End If
    End Sub

    Private Sub lnkFermoDeposito_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFermoDeposito.LinkClicked
        If MessageBox.Show("Sicuro di voler assegnare questo indirizzo a un FERMO DEPOSITO?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            txtRiferimento.Text = "FERMO DEPOSITO"
            txtIndirizzo.Text = "FERMO DEPOSITO"
        End If
    End Sub

    Private Sub pctCheck_Click(sender As Object, e As EventArgs) Handles pctCheck.Click
        Cursor = Cursors.WaitCursor
        Try

            Dim ris As RisValidazioneIndirizzo

            If cmbNazione.SelectedValue = FormerLib.FormerConst.Culture.IdItalia Then
                Dim ComuneScelto As ComuneInElenco = Nothing
                If Not cmbLocalita.SelectedItem Is Nothing Then
                    ComuneScelto = cmbLocalita.SelectedItem
                Else
                    ComuneScelto = New ComuneInElenco
                End If

                ris = FormerWebLabeling.MgrWebLabelingGls.CheckAddress(ComuneScelto.Provincia,
                                                                   txtCAP.Text,
                                                                   ComuneScelto.Comune,
                                                                   txtIndirizzo.Text,
                                                                   cmbNazione.SelectedValue)

                If ris.Valido Then
                    MessageBox.Show("L'indirizzo inserito ha superato CORRETTAMENTE la validazione GLS")
                Else
                    Dim MessaggioErrore As String = String.Empty

                    MessaggioErrore = "L'indirizzo inserito NON ha superato la validazione GLS. Informazioni supplementari: " & ris.Messaggio
                    If ris.ListaIndirizziSuggeriti.Count Then
                        MessaggioErrore &= ControlChars.NewLine & ControlChars.NewLine & "Suggerimenti: "

                        For Each IndirizzoSing In ris.ListaIndirizziSuggeriti
                            MessaggioErrore &= IndirizzoSing & ControlChars.NewLine
                        Next

                    End If
                    MessageBox.Show(MessaggioErrore)

                End If
            Else
                MessageBox.Show("Non è possibile validare indirizzi ESTERI")
            End If


        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nel tentativo di validazione dell'indirizzo con GLS")
        End Try
        Cursor = Cursors.Default
    End Sub

End Class