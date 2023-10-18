Imports System.IO
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib

Public Class ucAmministrazionePreventivi

    Private _IdRub As Integer
    Public Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
        End Set
    End Property

    Public IdOrdSel As Integer

    Public Sub Carica()

        CaricaCombo()

        If _IdRub Then
            'qui devo nascondere la combo clienti
            cmbCliente.Visible = False
            lblClienti.Visible = False
            lnkCerca.Left = lblClienti.Left

        End If



    End Sub

    Private Sub CaricaCombo()

        'carico la combo dei clienti
        Using cli As New VociRubricaDAO
            cmbCliente.ValueMember = "IdRub"
            cmbCliente.DisplayMember = "Nominativo"

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, True)

            cmbRisposto.SelectedIndex = 0
        End Using
    End Sub

    Public Sub AvviaRicerca(Optional ByVal Showall As Boolean = False, Optional ByVal Row As DataGridViewRow = Nothing)
        Cursor.Current = Cursors.WaitCursor
        Using x As New PreventiviDAO


            If Showall Then

                DgOrdini.DataSource = x.Lista()

            Else

                Dim Cod As String = txtCerca.Text

                If Cod = "{inserire qui il codice}" Then

                    Cod = ""

                End If

                If cmbCliente.SelectedValue Then x.IdRub = cmbCliente.SelectedValue

                DgOrdini.DataSource = x.Lista(Cod, IIf(chkDataInsDal.Checked, dtDataInsDal.Value, Nothing), IIf(chkDataInsAl.Checked, dtDataInsAl.Value, Nothing), cmbCliente.SelectedValue, cmbRisposto.SelectedIndex)

                'RaiseEvent OrdineSelezionato()

            End If
        End Using
        'DgOrdini.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgOrdini.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgOrdini.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgOrdini.Columns(6).DefaultCellStyle.Format = "0.00"

        DgOrdini.Columns(0).Visible = False
        'DgOrdini.Columns(9).Visible = False
        DgOrdini.Columns(10).Visible = False
        'DgOrdini.Columns(11).Visible = False
        'DgOrdini.Columns(12).Visible = False
        'DgOrdini.Columns(13).Visible = False
        'DgOrdini.Columns(14).Visible = False
        'DgOrdini.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgOrdini.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        If Not Row Is Nothing Then

            Try
                Dim dr As DataGridViewRow = Row

                DgOrdini.FirstDisplayedScrollingRowIndex = Row.Index
                dr.Selected = True
            Catch ex As Exception

            End Try

        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub lnkCerca_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked
        AvviaRicerca()
    End Sub

    Private Sub txtCerca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCerca.KeyPress

        If e.KeyChar = vbCr Then

            AvviaRicerca()

        Else
            ControlloNumerico(sender, e, True)
        End If


    End Sub

    Private Sub txtCerca_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCerca.MouseClick

        If txtCerca.Text = "{inserire qui il codice}" Then

            txtCerca.Text = ""

        End If

    End Sub

    Public Event PreventivoSelezionato()

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        Sottofondo(Me.ParentForm)
        Dim Titolo As String = ""
        If _IdRub Then
            Titolo = "Ordini cliente"
        Else
            Titolo = "Lista Preventivi"
        End If
        StampaGlobale(Titolo, DgOrdini)
        Sottofondo(Me.ParentForm)
    End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Dim frmRif As New frmOrdine

        Dim Ris As Integer = 0

        Sottofondo(Me.ParentForm)
        Ris = frmRif.Carica(0, _IdRub)
        Sottofondo(Me.ParentForm)
        If Ris Then AvviaRicerca()
        frmRif.Dispose()


    End Sub

    Private Sub DgOrdini_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgOrdini.CellMouseClick

        If DgOrdini.SelectedRows.Count Then

            If e.Button = Windows.Forms.MouseButtons.Right Then
                Dim x As System.Drawing.Point = MousePosition
                contextMenuPrev.Show(x)

            End If

        End If

    End Sub

    Private Sub DgOrdini_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgOrdini.CellMouseDoubleClick


    End Sub

    'Private Sub lnkOrdMail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOrdMail.LinkClicked
    '    If MessageBox.Show("ATTENZIONE!!! La funzione di scaricamento dei preventivi non va utilizzata in quanto il DEMONE si occupa di scaricare i preventivi automaticamente. Scaricare i preventivi manualmente da qui POTREBBE CREARE GROSSI PROBLEMI e COMPROMETTERE L'INTEGRITA' DEL DATABASE. Sicuro di voler continuare?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '        Sottofondo(Me.ParentForm)
    '        Dim x As New frmCheckPrev
    '        Dim Ris As Integer

    '        Ris = x.Carica()

    '        If Ris Then AvviaRicerca()

    '        x = Nothing
    '        Sottofondo(Me.ParentForm)
    '    End If



    'End Sub

    Private Sub cmbCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbCr Then

            AvviaRicerca()

        End If
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

    End Sub

    Private Sub DgOrdini_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgOrdini.CellContentClick

        Dim IdPrevSel As Integer = 0

        IdPrevSel = DgOrdini.SelectedRows(0).Cells(0).Value

        If IdPrevSel Then
            Cursor.Current = Cursors.WaitCursor

            Dim x As New Preventivo
            x.Read(IdPrevSel)

            Dim Sr As StreamWriter, PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")
            Sr = New System.IO.StreamWriter(PathFileStampa, False)

            Sr.Write(x.CreaRiepilogoBreve)

            Sr.Close()

            UcAnteprimaPrev.Carica(PathFileStampa)
            'UcOrdineDett.Carica(x)
            x = Nothing
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub RispondiAlPreventivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RispondiAlPreventivoToolStripMenuItem.Click

        If DgOrdini.SelectedRows.Count Then

            Dim Dr As DataGridViewRow

            Dr = DgOrdini.SelectedRows(0)

            Dim IdOrd As Integer = Dr.Cells(0).Value

            Sottofondo(Me.ParentForm)
            Dim x As New frmEmailPrev
            x.Carica(IdOrd)
            x = Nothing
            Sottofondo(Me.ParentForm)
            AvviaRicerca()
        End If
    End Sub

    Private Sub CreaProdottoSuPreventivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreaProdottoSuPreventivoToolStripMenuItem.Click

        If DgOrdini.SelectedRows.Count Then

            Dim Dr As DataGridViewRow

            Dr = DgOrdini.SelectedRows(0)

            Dim IdOrd As Integer = Dr.Cells(0).Value

            Sottofondo(Me.ParentForm)
            Dim x As New frmProdotto, Prod As New Prodotto
            x.Carica(Prod, IdOrd)
            x = Nothing
            Sottofondo(Me.ParentForm)
            'AvviaRicerca()
        End If
    End Sub

    Private Sub lnkNew_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        Sottofondo(Me.ParentForm)
        Dim x As New frmPrev

        If x.Carica Then AvviaRicerca()
        Sottofondo(Me.ParentForm)
    End Sub
End Class
