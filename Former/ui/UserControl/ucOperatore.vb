Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucOperatore
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        tabOperatore.ItemSize = New Size(100, 40)

    End Sub

    Public Sub Carica()

        tabOperatore.TabPages.Clear()
        tabOperatore.TabPages.Add(tpLavoriTutti)
        tabOperatore.TabPages.Add(tpProduzione)
        tabOperatore.TabPages.Add(tpImballaggio)
        tabOperatore.TabPages.Add(tpImballaggioCorriere)
        tabOperatore.TabPages.Add(tpConsegna)
        tabOperatore.TabPages.Add(tpConfermaConsegne)

        tabOperatore.SelectedTab = tpProduzione

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then
            If PostazioneCorrente.UtenteConnesso.AbilitaRepartoImballaggio <> enSiNo.Si Then

                tabOperatore.TabPages.Remove(tpImballaggio)
                tabOperatore.TabPages.Remove(tpImballaggioCorriere)
                tabOperatore.TabPages.Remove(tpConsegna)
                tabOperatore.TabPages.Remove(tpConfermaConsegne)

            End If

            If PostazioneCorrente.UtenteConnesso.MacchinariAbilitati.Count = 0 Then
                tabOperatore.TabPages.Remove(tpProduzione)
            End If

        End If

        If Not PostazioneCorrente.UtenteConnesso Is Nothing Then

            tpProduzione.Text = "Lavori in Coda per " & PostazioneCorrente.UtenteConnesso.Login

        End If

        If tabOperatore.SelectedTab Is tpProduzione Then
            UcOperatoreProduzione.Carica()
        ElseIf tabOperatore.SelectedTab Is tpImballaggio Then
            UcOperatoreImballaggio.Carica()
        ElseIf tabOperatore.SelectedTab Is tpImballaggioCorriere Then
            UcOperatoreImballaggioCorriere.Carica()
        ElseIf tabOperatore.SelectedTab Is tpConsegna Then
            UcOperatoreConsegna.Carica()
        End If

    End Sub

    Private Sub UcOperatoreImballaggio_OrdineSelezionato(IdOrdine As Integer) Handles UcOperatoreImballaggio.OrdineSelezionato
        CreaAnteprima(, IdOrdine)
    End Sub

    Private Sub CreaAnteprima(Optional IdCom As Integer = 0,
                              Optional IdOrd As Integer = 0)

        Cursor.Current = Cursors.WaitCursor

        If IdCom Then
            Dim Com As New Commessa
            Com.Read(IdCom)

            MgrAnteprime.CreaRiepilogoCom(Com, UcCommesseAnteprimaOp.WebPrew, enTipoAnteprima.Breve)
            Com = Nothing
            UcCommesseAnteprimaOp.CaricaDatiAccessori(, IdCom)
        Else
            Dim Ord As New Ordine
            Ord.Read(IdOrd)

            MgrAnteprime.CreaRiepilogoOrd(Ord, UcCommesseAnteprimaOp.WebPrew, enTipoAnteprima.Breve)
            Ord = Nothing
            UcCommesseAnteprimaOp.CaricaDatiAccessori(IdOrd)
        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub CaricaDati()
        ' MessageBox.Show("CaricamentoDati")
        Cursor = Cursors.WaitCursor
        If tabOperatore.SelectedTab Is tpProduzione Then
            UcOperatoreProduzione.Carica()
        ElseIf tabOperatore.SelectedTab Is tpImballaggio Then
            UcOperatoreImballaggio.Carica()
        ElseIf tabOperatore.SelectedTab Is tpImballaggioCorriere Then
            UcOperatoreImballaggioCorriere.Carica()
        ElseIf tabOperatore.SelectedTab Is tpConsegna Then
            UcOperatoreConsegna.Carica()
        ElseIf tabOperatore.SelectedTab Is tpLavoriTutti Then
            UcOperatoreCodaLavori.Carica()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub tabOperatore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabOperatore.SelectedIndexChanged

        If sender.focused Then CaricaDati()

    End Sub

    Private Sub UcOperatoreProduzione_CommessaSelezionata(IdCommessa As Integer) Handles UcOperatoreProduzione.CommessaSelezionata
        CreaAnteprima(IdCommessa)
    End Sub

    Private Sub UcOperatoreProduzione_OrdineSelezionato(IdOrdine As Integer) Handles UcOperatoreProduzione.OrdineSelezionato
        CreaAnteprima(, IdOrdine)
    End Sub

    Private Sub UcOperatoreConsegna_OrdineSelezionato(IdOrdine As Integer) Handles UcOperatoreConsegna.OrdineSelezionato
        CreaAnteprima(, IdOrdine)
    End Sub

    Private Sub UcOperatoreImballaggioCorriere_OrdineSelezionato(IdOrdine As Integer) Handles UcOperatoreImballaggioCorriere.OrdineSelezionato
        CreaAnteprima(, IdOrdine)
    End Sub

    Private Sub tmrAggiornaDati_Tick(sender As Object, e As EventArgs) Handles tmrAggiornaDati.Tick
        CaricaDati()
    End Sub

    Private Sub UcOperatoreCodaLavori_CommessaSelezionata(IdCommessa As Integer) Handles UcOperatoreCodaLavori.CommessaSelezionata
        CreaAnteprima(IdCommessa)
    End Sub

    Private Sub UcOperatoreCodaLavori_OrdineSelezionato(IdOrdine As Integer) Handles UcOperatoreCodaLavori.OrdineSelezionato
        CreaAnteprima(, IdOrdine)
    End Sub

    Private Sub UcOperatoreConfermaConsegne_OrdineSelezionato(IdOrdine As Integer) Handles UcOperatoreConfermaConsegne.OrdineSelezionato
        CreaAnteprima(, IdOrdine)
    End Sub


End Class
