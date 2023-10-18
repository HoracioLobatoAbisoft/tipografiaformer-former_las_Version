Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig

Friend Class frmConsegnaPercorso
    'Inherits baseFormInternaRedim

    Private _Ris As Integer = 0

    Private Function NormalizzaIndirizzo(Indirizzo As String) As String

        Dim ris As String = Indirizzo

        ris = ris.Replace("-", " ")
        Dim NewRis As String = String.Empty
        For Each sing As Char In ris
            If Char.IsLetterOrDigit(sing) Or sing = " " Then
                NewRis &= sing
            End If
        Next
        NewRis = NewRis.Replace(" ", "%20")
        'ris = System.Web.HttpUtility.UrlEncode(ris)

        Return NewRis

    End Function
    Private _Path As String = String.Empty

    Friend Function Carica(Indirizzo As String, Optional withPercorso As Boolean = True) As Integer

        If withPercorso Then
            _Path = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")

            Dim buffer As String = "<html><head></head><body><iframe width=""100%"" height=""100%"" frameborder=""0"" style=""border:0"" src=""https://www.google.com/maps/embed/v1/directions?#PERCORSO#&key=AIzaSyDn9ra2X_TwY0JVcl6ORFs8C5xWLYYGj64""></iframe></body></html>"

            'origin=Via%20Vincenzo%20Tieri%2C%20Roma%2C%20RM%2C%20Italia&destination=Via%20Vincenzo%20Tieri%2C%20Roma&waypoints=via%20Cassia%201900%20Roma|via%20del%20corso%20143%20Roma|via%20o.persiani%2012%20roma|via%20Trapani%2012%20Ladispoli
            Dim PercorsoCalcolato As String = "origin=" & NormalizzaIndirizzo("Via Cassia 2010 Roma") & "&destination=" & NormalizzaIndirizzo(Indirizzo)

            buffer = buffer.Replace("#PERCORSO#", PercorsoCalcolato)
            Using w As New StreamWriter(_Path)

                w.Write(buffer)

            End Using
        Else
            _Path = "https://www.google.it/maps/places/" & NormalizzaIndirizzo(Indirizzo)
        End If

        webPercorso.Navigate(_Path)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub MostraConsegne(lst As List(Of ConsegnaRicerca))

        Cursor = Cursors.WaitCursor

        Dim PathVuoto As String = "about:" & NormalizzaIndirizzo("Non ci sono consegne da visualizzare")
        Dim TrovateConsegne As Boolean = False

        If lst.Count Then
            Dim PathFolder As String = "C:\temp\"
            FormerHelper.File.CreateLongPath(PathFolder)
            _Path = PathFolder & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")

            Dim buffer As String = "<html><head></head><body><iframe width=""100%"" height=""100%"" frameborder=""0"" style=""border:0"" src=""https://www.google.com/maps/embed/v1/directions?#PERCORSO#&key=AIzaSyDn9ra2X_TwY0JVcl6ORFs8C5xWLYYGj64""></iframe></body></html>"
            Dim IdLavorati As String = ","

            'origin=Via%20Vincenzo%20Tieri%2C%20Roma%2C%20RM%2C%20Italia&destination=Via%20Vincenzo%20Tieri%2C%20Roma&waypoints=via%20Cassia%201900%20Roma|via%20del%20corso%20143%20Roma|via%20o.persiani%2012%20roma|via%20Trapani%2012%20Ladispoli
            Dim PercorsoCalcolato As String = "origin=" & NormalizzaIndirizzo("Via Cassia 2010 Roma") & "&destination=" & NormalizzaIndirizzo("Via Cassia 2010 Roma") & "&waypoints="
            Dim lScremata As List(Of ConsegnaRicerca) = lst.FindAll(Function(x) x.DisponibilePerIlPlanning = True And (x.IdCorr = enCorriere.TipografiaFormer Or x.IdCorr = enCorriere.TipografiaFormerFuoriRaccordo))
            For Each singCons In lScremata
                If IdLavorati.IndexOf("," & singCons.IdCons & ",") = -1 Then
                    IdLavorati &= singCons.IdCons & ","
                    'If singCons.DisponibilePerIlPlanning And (singCons.IdCorr = enCorriere.TipografiaFormer Or singCons.IdCorr = enCorriere.TipografiaFormerFuoriRaccordo) Then
                    Dim IndSing As String = singCons.IndirizzoStr(False)
                    If IndSing.StartsWith("Predef. ") Then
                        IndSing = IndSing.Substring(8)
                    End If
                    PercorsoCalcolato &= NormalizzaIndirizzo(IndSing) & "|"
                    TrovateConsegne = True
                    'End If
                End If
            Next

            PercorsoCalcolato = PercorsoCalcolato.TrimEnd("|")

            buffer = buffer.Replace("#PERCORSO#", PercorsoCalcolato)
            Using w As New StreamWriter(_Path)

                w.Write(buffer)

            End Using
        End If

        If TrovateConsegne = False Then
            _Path = PathVuoto
            lnkChrome.Enabled = False
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub CaricaConsegne(lst As List(Of ConsegnaRicerca))

        chkConsegne.Items.Clear()
        Dim lScremata As List(Of ConsegnaRicerca) = lst.FindAll(Function(x) x.DisponibilePerIlPlanning = True And (x.IdCorr = enCorriere.TipografiaFormer Or x.IdCorr = enCorriere.TipografiaFormerFuoriRaccordo))
        Dim IdLavorati As String = String.Empty
        For Each singC In lScremata
            If IdLavorati.IndexOf("," & singC.IdCons & ",") = -1 Then
                IdLavorati &= singC.IdCons & ","
                chkConsegne.Items.Add(singC, True)
            End If
        Next

    End Sub

    Friend Function Carica(lst As List(Of ConsegnaRicerca)) As Integer

        CaricaConsegne(lst)

        MostraConsegne(lst)

        webPercorso.Navigate(_Path)

        ShowDialog()

        Return _Ris

    End Function

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

    Private Sub lnkChrome_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkChrome.LinkClicked

        FormerLib.FormerHelper.Web.OpenWithChrome(_Path)

        Close()

    End Sub

    Private Sub chkConsegne_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chkConsegne.ItemCheck

        Dim lst As New List(Of ConsegnaRicerca)

        For Each item In chkConsegne.CheckedItems
            lst.Add(item)
        Next

        MostraConsegne(lst)

        webPercorso.Navigate(_Path)

    End Sub

    Private Sub lnkGiu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGiu.LinkClicked

        If Not chkConsegne.SelectedItem Is Nothing Then

            Dim indice As Integer = chkConsegne.SelectedIndex

            If (indice + 1) < chkConsegne.Items.Count Then
                Dim c As ConsegnaRicerca = chkConsegne.SelectedItem

                chkConsegne.Items.RemoveAt(indice)
                chkConsegne.Items.Insert(indice + 1, c)
                chkConsegne.SetItemChecked(indice + 1, True)
                chkConsegne.SelectedIndex = indice + 1

            End If

        End If

    End Sub

    Private Sub lnkSu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSu.LinkClicked
        If Not chkConsegne.SelectedItem Is Nothing Then

            Dim indice As Integer = chkConsegne.SelectedIndex

            If (indice - 1) >= 0 Then
                Dim c As ConsegnaRicerca = chkConsegne.SelectedItem

                chkConsegne.Items.RemoveAt(indice)
                chkConsegne.Items.Insert(indice - 1, c)
                chkConsegne.SetItemChecked(indice - 1, True)
                chkConsegne.SelectedIndex = indice - 1
            End If

        End If

    End Sub

End Class