Imports FormerDALSql
Imports FormerBusinessLogic
Imports FormerLib.FormerEnum

Friend Class frmListinoPromoAutomatico
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0

    Private Sub CaricaCombo()

        Using mgr As New ListinoBaseDAO

            Dim L As List(Of ListinoBase) = mgr.GetNotInPromo(enTipoListiniBase.Produzione)

            L = L.FindAll(Function(x) x.Preventivazione.ggSlow <> 0)

            L.Sort(AddressOf FormerListSorter.ListiniBaseSorter.SortRepartoDescrizione)

            If _IdListinoBase Then
                Dim lb As New ListinoBase
                lb.Read(_IdListinoBase)
                L.Add(lb)
            End If

            cmbLB.ValueMember = "IdListinoBase"
            cmbLB.DisplayMember = "Nome"
            cmbLB.DataSource = L 'mgr.GetAll(LFM.ListinoBase.Nome)

            'qui devo caricare quelli non usati all'interno dei promo automatici


        End Using

    End Sub

    Private _IdListinoBase As Integer = 0

    Friend Function Carica(Optional IdListinoBase As Integer = 0,
                           Optional PercPromo As Integer = 0,
                           Optional FromNormale As Boolean = False) As Integer

        _IdListinoBase = IdListinoBase

        CaricaCombo()
        If FromNormale Then
            Using l As New ListinoBase
                l.Read(_IdListinoBase)

                txtPercFatturatoMax.Text = l.PercMaxPromoFatturato
                txtPercPromo.Text = PercPromo
                MgrControl.SelectIndexCombo(cmbLB, _IdListinoBase)
                chkAttivo.Checked = True
                cmbLB.Enabled = False
            End Using
        Else
            If _IdListinoBase Then
                Using l As New ListinoBase
                    l.Read(_IdListinoBase)

                    txtPercFatturatoMax.Text = l.PercMaxPromoFatturato
                    txtPercPromo.Text = l.PercPromoAutomatico
                    MgrControl.SelectIndexCombo(cmbLB, _IdListinoBase)
                    If l.AttivaPromoAutomatico = enSiNo.Si Then
                        chkAttivo.Checked = True
                    End If
                    cmbLB.Enabled = False
                End Using
            Else
                chkAttivo.Checked = True
            End If
        End If

        ShowDialog()

        Return _Ris

    End Function

    'Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    Dim x As Char = vbCr
    '    If e.KeyChar = x Then
    '        e.Handled = True
    '        SendKeys.Send(vbTab)

    '    End If
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi i dati inseriti?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            'If txtPercPromo.Value = 0 Or txtPercFatturatoMax.Value = 0 Then
            '    MessageBox.Show("Impostare entrambe le percentuali")
            'Else

            If (txtPercPromo.Value = 0 And txtPercFatturatoMax.Value = 0) Or (txtPercPromo.Value <> 0 And txtPercFatturatoMax.Value <> 0) Then
                Using Lb As New ListinoBase

                    If _IdListinoBase Then
                        Lb.Read(_IdListinoBase)
                    Else
                        Lb.Read(cmbLB.SelectedValue)
                    End If
                    Lb.CaricaLavorazioni()

                    'leggo lo stato attuale del promo
                    'se attivo 
                    Dim VecchioStato As Integer = Lb.AttivaPromoAutomatico

                    Lb.PercPromoAutomatico = txtPercPromo.Text
                    Lb.PercMaxPromoFatturato = txtPercFatturatoMax.Text
                    Lb.AttivaPromoAutomatico = IIf(chkAttivo.Checked, enSiNo.Si, enSiNo.No)

                    If Lb.AttivaPromoAutomatico = enSiNo.No Then
                        Lb.CounterDayPromo = 0
                    End If

                    Lb.Save()

                    If VecchioStato = enSiNo.No And Lb.AttivaPromoAutomatico = enSiNo.Si Then
                        'qui resetto i contatori di tutti i promo cosi rivanno in bilanciamento
                        Using mgr As New ListinoBaseDAO
                            mgr.ResetCounterDayPromo()
                        End Using
                    End If

                End Using
                _Ris = 1
                Close()

            Else
                MessageBox.Show("Le percentuali non sono congruenti")
            End If


            'End If

        End If

    End Sub

    Private Sub txtPercPromo_TextChanged(sender As Object, e As EventArgs) Handles txtPercPromo.TextChanged
        If txtPercPromo.Value = 0 Then txtPercFatturatoMax.Text = 0
    End Sub

    'Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

    '    If MessageBox.Show("Confermi l'inserimento dell'offerta nel template?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '        'qui controllo se c'e' gia e avviso 

    '        Dim OkDoppioni As Boolean = True
    '        Using mgr As New ListinoBaseSuTemplateDAO
    '            Dim l As List(Of ListinoBaseSuTemplate) = mgr.FindAll(New LUNA.LunaSearchParameter("IdListinoBase", cmbLB.SelectedValue),
    '                                                                  New LUNA.LunaSearchParameter("IdTmOff", _IdTmOff))
    '            If l.Count Then
    '                Dim qta As String = String.Empty

    '                For Each sing In l
    '                    qta &= sing.Qta & ";"
    '                Next

    '                If MessageBox.Show("Questo ListinoBase e' stato già inserito in questo Filtro Marketing con quantità " & qta & " confermi il salvataggio?", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
    '                    OkDoppioni = False
    '                End If

    '            End If
    '        End Using

    '        If OkDoppioni Then


    '            Close()
    '        End If

    '    End If

    'End Sub

End Class