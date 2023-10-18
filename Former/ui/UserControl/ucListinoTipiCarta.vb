Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucListinoTipiCarta
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        CaricaCombo()

    End Sub

    'Public Sub CaricaDati()

    '    CaricaCombo()
    '    CaricaTipoCarta()

    'End Sub

    Private Sub CaricaCombo()
        Try
            Using t As New TipiCartaDAO
                cmbFinitura.DataSource = t.ListaFiniture(True)
            End Using

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbFinitura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFinitura.SelectedIndexChanged
        If sender.focused Then CaricaTipoCarta()
    End Sub

    Public Function ObbligaRisorseIncodaNonAssociate()

        chkOnlyOrder.Checked = True
        chkNoRisorse.Checked = True
        chkOnlyOrder.Enabled = False
        chkNoRisorse.Enabled = False

    End Function

    Private Sub CaricaTipoCarta()

        Dim mgr As New TipiCartaDAO

        Dim l As List(Of TipoCartaEx) = mgr.ListaTipi(cmbFinitura.Text,
                                                      chkOnlyOrder.Checked,
                                                      chkNoRisorse.Checked)
        dgTipologie.AutoGenerateColumns = False
        dgTipologie.DataSource = l

    End Sub

    Private Sub lnkAddTipol_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddTipol.LinkClicked
        ParentFormEx.Sottofondo()

        Dim f As New frmListinoTipoCarta

        Dim ris As Integer = f.Carica()
        f = Nothing

        If ris Then
            CaricaTipoCarta()
        End If

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkModTipol_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModTipol.LinkClicked
        ModificaTipologiaCarta()
    End Sub

    Private Sub DuplicaTipoCarta()

        If dgTipologie.SelectedRows.Count Then

            Dim v As TipoCartaEx = dgTipologie.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi la duplicazione del tipo di carta '" & v.Tipologia & "'?", "Duplicazione Tipo Carta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim tc As New TipoCarta
                tc.Read(v.IdTipoCarta)
                tc.IdTipoCarta = 0
                tc.Tipologia &= " Copia"
                tc.Sigla &= "-Copia"

                If tc.IsValid Then
                    tc.Save()
                    CaricaTipoCarta()
                Else
                    MessageBox.Show("Duplicazione non effettuata! Ci sono dei dati nel oggetto selezionato per la duplicazione che non sono validi.")
                End If

            End If
        Else
            MessageBox.Show("Selezionare la Tipologia di Carta")
        End If

    End Sub

    Private Sub EliminaTipoCarta()

        If dgTipologie.SelectedRows.Count Then

            Dim v As TipoCartaEx = dgTipologie.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi l'eliminazione del tipo di carta '" & v.Tipologia & "'?", "Eliminazione Tipo Carta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Using mgrL As New ListinoBaseDAO
                    Dim L As List(Of ListinoBase) = mgrL.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdTipoCarta, v.IdTipoCarta),
                                                                 New LUNA.LunaSearchParameter(LFM.ListinoBase.IdTipoCartaCop, v.IdTipoCarta, , LUNA.enLogicOperator.enOR),
                                                                 New LUNA.LunaSearchParameter(LFM.ListinoBase.IdTipoCartaDorso, v.IdTipoCarta, , LUNA.enLogicOperator.enOR))
                    If L.Count = 0 Then
                        'qui devo controllare se collegate ad alcune risorse e in caso avvisare 
                        Using mgrR As New RisorseDAO
                            Dim lR As List(Of Risorsa) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.Risorsa.IdTipoCarta, v.IdTipoCarta))

                            If lR.Count = 0 Then
                                Using mgr As New TipiCartaDAO
                                    mgr.Delete(v.IdTipoCarta)
                                    CaricaTipoCarta()
                                End Using
                            Else
                                Dim buffer As String = String.Empty
                                For Each singR In lR
                                    buffer &= singR.Descrizione & ", "
                                Next

                                buffer = buffer.TrimEnd(" ", ",")

                                MessageBox.Show("Il tipo carta non e' eliminabile perche collegato alle seguenti risorse di magazzino: " & buffer)
                            End If

                        End Using

                    Else
                        Dim buffer As String = String.Empty
                        For Each singL In L
                            buffer &= singL.NomeEx & ", "
                        Next

                        buffer = buffer.TrimEnd(" ", ",")

                        MessageBox.Show("Il tipo carta non e' eliminabile perche utilizzato nei seguenti listini base: " & buffer)
                    End If
                End Using
            End If
        Else
            MessageBox.Show("Selezionare la Tipologia di Carta")
        End If

    End Sub

    Private Sub ModificaTipologiaCarta()
        If dgTipologie.SelectedRows.Count Then

            Dim v As TipoCartaEx = dgTipologie.SelectedRows(0).DataBoundItem

            Dim IdRif As Integer = 0
            IdRif = v.IdTipoCarta
            ParentFormEx.Sottofondo()

            Dim Ris As Integer = 0, x As New frmListinoTipoCarta
            Ris = x.Carica(IdRif)
            If Ris Then CaricaTipoCarta()
            x = Nothing
            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("Selezionare la Tipologia di Carta")
        End If
    End Sub

    Private Sub lnkDelTipol_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelTipol.LinkClicked
        EliminaTipoCarta()
    End Sub

    Private Sub dgTipologie_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTipologie.CellContentClick

    End Sub

    Private Sub dgTipologie_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTipologie.CellDoubleClick
        ModificaTipologiaCarta()
    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click

        CaricaTipoCarta()

    End Sub

    Private Sub lnkDuplica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDuplica.LinkClicked
        DuplicaTipoCarta()
    End Sub

End Class
