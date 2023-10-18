Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucListinoGruppoVariante
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Private _ListinoBaseRif As ListinoBase = Nothing

    Private ReadOnly Property ListinoBaseRif As ListinoBase
        Get
            If _ListinoBaseRif Is Nothing Then
                _ListinoBaseRif = New ListinoBase
                _ListinoBaseRif.Read(IdListinoBase)
            End If
            Return _ListinoBaseRif
        End Get
    End Property

    Private Sub CaricaCS()

        Dim CSValido As Boolean = False

        If ListinoBaseRif.IdColoreStampa = enColoriStampa.ColoriFronteRetro Then
            grpColoreStampa.Enabled = True
            lblSecondoColore.Text = "SOLO FRONTE"
            txtVarPercCS.Enabled = True
            chkSecondoColore.Enabled = True
            CSValido = True
            txtVarPercCS.Text = 0

        ElseIf ListinoBaseRif.IdColoreStampa = enColoriStampa.ColoriSoloFronte Then
            grpColoreStampa.Enabled = True
            lblSecondoColore.Text = "FRONTE RETRO"
            txtVarPercCS.Enabled = False
            chkSecondoColore.Enabled = True
            txtVarPercCS.Text = 0
            CSValido = True
        Else
            lblSecondoColore.Text = "-"
            chkSecondoColore.Enabled = False
            chkSecondoColore.Checked = False
            grpColoreStampa.Enabled = False
            txtVarPercCS.Text = 0
        End If

        If CSValido Then
            Using mgr As New GruppiVariantiRifDAO
                Dim ls As List(Of GruppoVarianteRif) = mgr.FindAll(New LUNA.LSP(LFM.GruppoVarianteRif.IdListinoBase, IdListinoBase),
                                                                    New LUNA.LSP(LFM.GruppoVarianteRif.TipoRiferimento, enTipoOggettoListino.ColoreStampa))

                If ls.Count Then
                    'qui ho un salvataggio
                    Dim var As GruppoVarianteRif = ls(0)

                    chkSecondoColore.Checked = True
                    grpColoreStampa.Enabled = True

                    If var.IdRiferimento = enColoriStampa.ColoriFronteRetro Then
                        lblSecondoColore.Text = "FRONTE RETRO"
                        txtVarPercCS.Enabled = False
                        txtVarPercCS.Text = 0
                    ElseIf var.IdRiferimento = enColoriStampa.ColoriSoloFronte Then
                        lblSecondoColore.Text = "SOLO FRONTE"
                        txtVarPercCS.Enabled = True
                        txtVarPercCS.Text = var.PercDiminuzione
                    End If

                End If


            End Using
        End If

    End Sub


    Private Sub CaricaTC()
        Using mgr As New GruppiVariantiRifDAO
            Dim ls As List(Of GruppoVarianteRif) = mgr.FindAll(New LUNA.LSP(LFM.GruppoVarianteRif.IdListinoBase, IdListinoBase),
                                                                New LUNA.LSP(LFM.GruppoVarianteRif.TipoRiferimento, enTipoOggettoListino.TipoCarta))

            Dim l As New List(Of TipoCarta)

            For Each voce In ls

                Dim tc As New TipoCarta
                tc.Read(voce.IdRiferimento)
                tc.PercVariazioneSuVariante = voce.PercDiminuzione
                l.Add(tc)

            Next

            dgTipologie.AutoGenerateColumns = False
            dgTipologie.DataSource = l

        End Using
    End Sub

    Private Sub CaricaLav()

        Using mgr As New GruppiVariantiRifDAO
            Dim ls As List(Of GruppoVarianteRif) = mgr.FindAll(New LUNA.LSP(LFM.GruppoVarianteRif.IdListinoBase, IdListinoBase),
                                                                New LUNA.LSP(LFM.GruppoVarianteRif.TipoRiferimento, enTipoOggettoListino.CatLav))

            Dim l As New List(Of CatLav)

            For Each voce In ls

                Dim tc As New CatLav
                tc.Read(voce.IdRiferimento)
                l.Add(tc)

            Next

            lstLav.DataSource = l
            lstLav.DisplayMember = "Riassunto"
            lstLav.ValueMember = "IdCatLav"

        End Using

    End Sub

    Public Sub SaveVarianti()
        'dopo il salvataggio del LB chiamo SaveVarianti
        ListinoBaseRif.Refresh()

        Using mgr As New GruppiVariantiRifDAO

            mgr.DeleteByParam(IdListinoBase, enTipoOggettoListino.ColoreStampa)

        End Using

        If chkSecondoColore.Checked Then

            If ListinoBaseRif.IdColoreStampa = enColoriStampa.ColoriFronteRetro Then

                Using var As New GruppoVarianteRif
                    var.IdListinoBase = IdListinoBase
                    var.IdRiferimento = enColoriStampa.ColoriSoloFronte
                    var.TipoRiferimento = enTipoOggettoListino.ColoreStampa
                    var.PercDiminuzione = txtVarPercCS.Text
                    var.Save()
                End Using

            ElseIf ListinoBaseRif.IdColoreStampa = enColoriStampa.ColoriSoloFronte Then
                Using var As New GruppoVarianteRif
                    var.IdListinoBase = IdListinoBase
                    var.IdRiferimento = enColoriStampa.ColoriFronteRetro
                    var.TipoRiferimento = enTipoOggettoListino.ColoreStampa
                    var.PercDiminuzione = 0
                    var.Save()
                End Using

            End If
        End If

        'salvocs

    End Sub
    Public Sub CaricaVarianti()

        CaricaCS()

        CaricaTC()

        CaricaLav()

    End Sub

    Private Sub lnkAddFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFormato.LinkClicked
        ParentFormEx.Sottofondo()

        Dim ris As RisSelectTipoCarta = Nothing
        Using f As New frmSelectTipoCarta
            ris = f.Carica(IdListinoBase)
        End Using

        If Not ris Is Nothing AndAlso ris.IdTipoCarta <> 0 Then

            'controllo che non esista gia una combinazione per questo listino base con questo tipo carta

            Dim l As List(Of ListinoBase) = Nothing
            Using mgr As New ListinoBaseDAO
                l = mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdFormProd, ListinoBaseRif.IdFormProd),
                                New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, ris.IdTipoCarta),
                                New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, ListinoBaseRif.IdColoreStampa),
                                New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0),
                                New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))
            End Using

            If l.Count = 0 Then
                Using v As New GruppoVarianteRif
                    v.IdListinoBase = IdListinoBase
                    v.IdRiferimento = ris.IdTipoCarta
                    v.PercDiminuzione = ris.PercCambiamento
                    v.TipoRiferimento = enTipoOggettoListino.TipoCarta
                    v.Save()
                End Using
            Else
                MessageBox.Show("Esiste già un listinobase per questa variante. Impossibile inserirla")
            End If


            CaricaTC()
        End If

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub EliminaVoceLav()
        If lstLav.SelectedItems.Count Then

            If MessageBox.Show("Confermi l'eliminazione della variante con categoria lavorazione selezionata?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim v As CatLav = lstLav.SelectedItems(0) '.DataBoundItem

                Using Mgr As New GruppiVariantiRifDAO
                    Mgr.DeleteByParam(IdListinoBase, enTipoOggettoListino.CatLav, v.IdCatLav)
                End Using
                CaricaLav()
            End If

        End If
    End Sub

    Private Sub EliminaVoceTC()
        If dgTipologie.SelectedRows.Count Then

            If MessageBox.Show("Confermi l'eliminazione della variante con tipocarta selezionata?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim v As TipoCarta = dgTipologie.SelectedRows(0).DataBoundItem

                Using Mgr As New GruppiVariantiRifDAO
                    Mgr.DeleteByParam(IdListinoBase, enTipoOggettoListino.TipoCarta, v.IdTipoCarta)
                End Using
                CaricaTC()
            End If

        End If
    End Sub

    Private Sub ModificaVoceTC()
        If dgTipologie.SelectedRows.Count Then

            'If MessageBox.Show("Confermi l'eliminazione della variante con tipocarta selezionata?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim v As TipoCarta = dgTipologie.SelectedRows(0).DataBoundItem

                Using Mgr As New GruppiVariantiRifDAO

                    Dim ls As List(Of GruppoVarianteRif) = Mgr.FindAll(New LUNA.LSP(LFM.GruppoVarianteRif.IdListinoBase, IdListinoBase),
                                                                       New LUNA.LSP(LFM.GruppoVarianteRif.TipoRiferimento, enTipoOggettoListino.TipoCarta),
                                                                       New LUNA.LSP(LFM.GruppoVarianteRif.IdRiferimento, v.IdTipoCarta))

                If ls.Count Then

                    Dim G As GruppoVarianteRif = ls(0)
                    Dim ris As String = InputBox("Inserisci la percentuale di adattamento", "Modifica Percentuale di adattamento", G.PercDiminuzione)

                    If ris.Length AndAlso IsNumeric(ris) Then
                        G.PercDiminuzione = ris
                        G.Save()
                    End If

                End If

                '       Mgr.DeleteByParam(IdListinoBase, enTipoOggettoListino.TipoCarta, v.IdTipoCarta)
            End Using
                CaricaTC()
            'End If

        End If
    End Sub

    Private Sub lnkDelFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelFormato.LinkClicked
        EliminaVoceTC()
    End Sub

    Private Sub dgFormatoMacchina_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub


    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked

        CaricaTC()

    End Sub

    Private _IdListinoBase As Integer = 0

    Public Property IdListinoBase As Integer
        Get
            Return _IdListinoBase
        End Get
        Set(value As Integer)
            _IdListinoBase = value
            Try
                'CaricaVarianti()
            Catch ex As Exception

            End Try
        End Set
    End Property

    Private Sub lnkAggiornaLav_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiornaLav.LinkClicked
        CaricaLav()
    End Sub

    Private Sub lnkAddLav_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddLav.LinkClicked
        ParentFormEx.Sottofondo()

        Dim ris As Integer = 0
        Using f As New frmSelectCatLav
            ris = f.Carica(IdListinoBase)
        End Using

        If ris Then

            Using v As New GruppoVarianteRif
                v.IdListinoBase = IdListinoBase
                v.IdRiferimento = ris
                v.TipoRiferimento = enTipoOggettoListino.CatLav
                v.Save()
            End Using

            CaricaLav()
        End If

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkDelLav_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelLav.LinkClicked
        EliminaVoceLav()
    End Sub

    Private Sub lnkModifPerc_Click(sender As Object, e As EventArgs) Handles lnkModifPerc.Click
        ModificaVoceTC()
    End Sub
End Class
