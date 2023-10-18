Imports System.IO
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucAmministrazioneContabilita
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()
        CaricaCombo()

    End Sub

    Private Sub CaricaCombo()
        Dim lAnni As New List(Of cEnum)

        For i As Integer = 2019 To Now.Year
            Dim anno As New cEnum(i, i)
            lAnni.Add(anno)
        Next

        cmbAnno.ValueMember = "Id"
        cmbAnno.DisplayMember = "Descrizione"
        cmbAnno.DataSource = lAnni

        MgrControl.SelectIndexCombo(cmbAnno, Now.Year)

        Dim lMesi As New List(Of cEnum)

        For i As Integer = 1 To 12
            Dim anno As New cEnum(i, FormerLib.FormerHelper.Calendario.MeseToString(i))
            lMesi.Add(anno)
        Next

        cmbMese.ValueMember = "Id"
        cmbMese.DisplayMember = "Descrizione"
        cmbMese.DataSource = lMesi

        MgrControl.SelectIndexCombo(cmbMese, Now.Month)

    End Sub

    Private Sub lnkStampaBilancio_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampaBilancio.LinkClicked
        ParentFormEx.Sottofondo()
        Using f As New frmContabilitaBilancio
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()
    End Sub
    Private Function ReportPrimaNota(MeseScelto As Integer, AnnoScelto As Integer) As String

        Dim ris As String = String.Empty

        Dim sql As String = "select * from ("
        sql &= " Select p.* from t_pagamenti p inner join t_contabricavi r on p.idfat = r.idricavo where p.tipo= " & enTipoVoceContab.VoceVendita & " and year(p.datapag) = " & AnnoScelto & " and month(p.datapag) = " & MeseScelto
        sql &= " union select p.* from t_pagamenti p inner join  t_contabcosti c on p.idfat= c.idcosto where p.tipo =  " & enTipoVoceContab.VoceAcquisto & " and year(p.datapag) = " & AnnoScelto & " and month(p.datapag) = " & MeseScelto
        sql &= " )a "
        sql &= "order by datapag"

        Dim Buffer As String = String.Empty

        Using mgr As New PagamentiDAO
            Dim l As List(Of Pagamento) = mgr.GetBySQL(sql)
            Dim Saldo As Decimal = 0

            Buffer &= "<font face=arial size=1><table border=1>"
            Buffer &= "<tr>"
            Buffer &= "<td><b>DATA</b></td>"
            Buffer &= "<td><b>RIFERIMENTO</b></td>"
            Buffer &= "<td><b>DOCUMENTO</b></td>"
            Buffer &= "<td><b>NOTE</b></td>"
            Buffer &= "<td><b>TIPO</b></td>"
            Buffer &= "<td><b>ENTRATE</b></td><td><b>USCITE</b></td>"

            Buffer &= "<td><b>SALDO</b></td>"
            Buffer &= "</tr>"
            For Each voce In l
                Dim ProcessaPagamento As Boolean = True
                If voce.Tipo = enTipoVoceContab.VoceAcquisto Then
                    ' lascio la if solo per memoria ma i costi li valuto tutti 
                    If voce.CostoRif.IdAzienda <> MgrAziende.IdAziende.AziendaSrl Then
                        ProcessaPagamento = False
                    End If
                ElseIf voce.Tipo = enTipoVoceContab.VoceVendita Then
                    If voce.IdFat Then
                        If voce.RicavoRif.IdAzienda <> MgrAziende.IdAziende.AziendaSrl Or
                           voce.RicavoRif.Tipo = enTipoDocumento.Preventivo Then
                            ProcessaPagamento = False
                        End If
                    ElseIf voce.IdConsegna Then
                        If voce.ConsegnaRif.IdAziendaForzata = MgrAziende.IdAziende.AziendaSnc Then
                            ProcessaPagamento = False
                        End If
                    Else
                        ProcessaPagamento = False
                    End If

                End If

                If ProcessaPagamento Then
                    Buffer &= "<tr>"
                    Buffer &= "<td>" & voce.DataPag.ToString("dd/MM/yyyy") & "</td>"
                    Buffer &= "<td>" & voce.ClienteNominativo & "</td>"
                    Buffer &= "<td>" & voce.TipoDocStr & " " & voce.NumeroDocStr & "</td>"
                    Buffer &= "<td>" & voce.NotePag & "</td>"
                    Buffer &= "<td>" & voce.TipoPagamentoStr & "</td>"
                    If voce.Tipo = enTipoVoceContab.VoceVendita Then
                        Buffer &= "<td>" & voce.ImportoStr & "</td><td>&nbsp;</td>"
                        Saldo += voce.Importo
                    Else
                        Buffer &= "<td>&nbsp;</td><td>" & voce.ImportoStr & "</td>"
                        Saldo -= voce.Importo
                    End If
                    Buffer &= "<td>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Saldo) & "</td>"
                    Buffer &= "</tr>"
                End If

            Next
            Buffer &= "</table>"
        End Using

        ris = FormerConfig.FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")

        Using w As New StreamWriter(ris)
            w.Write(Buffer)
        End Using

        Return ris

    End Function
    Private Sub lnkStampaConteggi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampaConteggi.LinkClicked

        If MessageBox.Show("Vuoi stampare il Report Conteggi Mensili IVA?", "Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ParentFormEx.Sottofondo()
            Using f As New frmContabilitaBilancio
                f.Carica(enTipoReportEconomico.ReportIVA)
            End Using
            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub lnkStampaFlussi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampaFlussi.LinkClicked

        If MessageBox.Show("Vuoi stampare il Report dei flussi mensili?", "Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim ris As String = MgrReport.ReportFlussiMensili()
            If ris.Length Then
                ParentFormEx.Sottofondo()

                Using f As New frmStampa
                    f.Carica(ris)
                End Using
                ParentFormEx.Sottofondo()
            Else
                MessageBox.Show("Si è verificato un errore nella creazione del report")
            End If
            'Dim Anno As String = InputBox("Inserisci l'anno di cui vuoi generare il report flussi", "Report Flussi", Now.Year)

            'If Anno.Length AndAlso IsNumeric(Anno) And Anno > 2000 Then
            '    Dim ris As String = MgrReport.ReportFlussiMensili(Anno)
            '    If ris.Length Then
            '        ParentFormEx.Sottofondo()

            '        Using f As New frmStampa
            '            f.Carica(ris)
            '        End Using
            '        ParentFormEx.Sottofondo()
            '    Else
            '        MessageBox.Show("Si è verificato un errore nella creazione del report")
            '    End If
            'End If

        End If
    End Sub

    Private Sub lnkStampaDocEmessiIncassati_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampaDocEmessiIncassati.LinkClicked
        If MessageBox.Show("Vuoi stampare il Report dei Documenti Emessi e Incassati Mensili?", "Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim Anno As String = InputBox("Inserisci l'anno di cui vuoi generare il report flussi", "Report Flussi", Now.Year)

            If Anno.Length AndAlso IsNumeric(Anno) AndAlso Anno > 2000 Then
                Dim ris As String = MgrReport.ReportDocumentiMensiliEmessiIncassati(Anno)
                If ris.Length Then
                    ParentFormEx.Sottofondo()

                    Using f As New frmStampa
                        f.Carica(ris)
                    End Using
                    ParentFormEx.Sottofondo()
                Else
                    MessageBox.Show("Si è verificato un errore nella creazione del report")
                End If
            End If

        End If
    End Sub

    Private Sub lnkInventarioMagazzino_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkInventarioMagazzino.LinkClicked
        ParentFormEx.Sottofondo()
        Using f As New frmContabilitaBilancio
            f.Carica(enTipoReportEconomico.InventarioMagazzino)
        End Using
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkPrimaNota_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrimaNota.LinkClicked
        ParentFormEx.Sottofondo()
        Using f As New frmStampa
            f.Carica(ReportPrimaNota(cmbMese.SelectedValue, cmbAnno.SelectedValue))
        End Using
        ParentFormEx.Sottofondo()


    End Sub
End Class
