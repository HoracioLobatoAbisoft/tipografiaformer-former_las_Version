Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucProduzione


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        tabProduzione.ItemSize = New Size(100, 40)


    End Sub

    Public Function Carica() As Integer

        Dim ris As Integer = 0

        UcOrdiniAnteprima.Inizializza()

        UcProduzioneOffset.Carica()
        UcProduzioneDigitale.Carica()
        UcProduzionePackaging.Carica()
        UcProduzioneRicamo.Carica()
        UcProduzioneEtichette.Carica()

        tabProduzione.SelectedTab = tpOffSet

        Return ris

    End Function

    Delegate Sub SetTextCallback(testo As String, ByRef txt As TabPage)

    Private Sub SetText(ByVal testo As String, ByRef txt As TabPage)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        Try
            If txt.InvokeRequired Then
                Dim d As New SetTextCallback(AddressOf SetText)
                Me.Invoke(d, New Object() {testo, txt})
            Else
                txt.Text = testo
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Function CommesseInCoda()
        Dim ris As Integer = 0

        Dim SingRis As Integer = 0

        SingRis = UcProduzioneVerify.OrdiniInCoda()

        SetText("Da Verificare (" & SingRis & ")", tpVerify)

        SingRis = UcProduzioneOffset.CommesseInCoda()

        SetText("Stampa Offset (" & SingRis & ")", tpOffSet)

        'tpOffSet.Text = tpOffSet.Tag & " (" & SingRis & ")"

        ris += SingRis

        SingRis = UcProduzioneDigitale.CommesseInCoda()
        SetText("Stampa Digitale (" & SingRis & ")", tpDigitale)
        'tpDigitale.Text = tpDigitale.Tag & " (" & SingRis & ")"

        ris += SingRis

        SingRis = UcProduzionePackaging.CommesseInCoda()
        SetText("Packaging (" & SingRis & ")", tpPackaging)
        'tpPackaging.Text = tpPackaging.Tag & " (" & SingRis & ")"

        ris += SingRis

        SingRis = UcProduzioneRicamo.CommesseInCoda()
        SetText("Ricamo (" & SingRis & ")", tpRicamo)
        'tpRicamo.Text = tpRicamo.Tag & " (" & SingRis & ")"

        ris += SingRis

        SingRis = UcProduzioneEtichette.CommesseInCoda()
        SetText("Etichette (" & SingRis & ")", tpEtichette)
        'tpEtichette.Text = tpEtichette.Tag & " (" & SingRis & ")"

        ris += SingRis

        Return ris
    End Function

    Private Sub UcCommesseModelli_ModelloCommessaSelezionato() Handles UcCommesseModelli.ModelloCommessaSelezionato

        If UcCommesseModelli.IdModelloCommessa Then

            Cursor.Current = Cursors.WaitCursor

            Dim x As New ModelloCommessa
            x.Read(UcCommesseModelli.IdModelloCommessa)

            UcOrdiniAnteprima.Carica(x)
            'UcOrdineDett.Carica(x)
            x = Nothing
            Cursor.Current = Cursors.Default

        End If

    End Sub

    Private Sub UcProduzioneOffset_CommessaSelezionata(sender As Object) Handles UcProduzioneOffset.CommessaSelezionata,
                                                                                 UcProduzioneEtichette.CommessaSelezionata,
                                                                                 UcProduzioneDigitale.CommessaSelezionata,
                                                                                 UcProduzionePackaging.CommessaSelezionata,
                                                                                 UcProduzioneRicamo.CommessaSelezionata

        If sender.IdComSel Then

            Cursor.Current = Cursors.WaitCursor

            Using x As New Commessa
                x.Read(sender.IdComSel)

                UcOrdiniAnteprima.Carica(x)
                'UcOrdineDett.Carica(x)
            End Using
            Cursor.Current = Cursors.Default

        End If

    End Sub

    Private Sub UcProduzioneOffset_ModelloCommessaSelezionato() Handles UcProduzioneOffset.ModelloCommessaSelezionato
        If UcProduzioneOffset.IdModelloCommessaSel Then

            Cursor.Current = Cursors.WaitCursor

            Dim x As New ModelloCommessa
            x.Read(UcProduzioneOffset.IdModelloCommessaSel)

            UcOrdiniAnteprima.Carica(x)
            'UcOrdineDett.Carica(x)
            x = Nothing
            Cursor.Current = Cursors.Default

        End If
    End Sub

    Private Sub UcProduzioneOffset_OrdineSelezionato() Handles UcProduzioneOffset.OrdineSelezionato

        If UcProduzioneOffset.IdOrdSel Then

            Cursor.Current = Cursors.WaitCursor

            Using x As New Ordine
                x.Read(UcProduzioneOffset.IdOrdSel)

                UcOrdiniAnteprima.Carica(x)
                'UcOrdineDett.Carica(x)
            End Using
            Cursor.Current = Cursors.Default

        End If

    End Sub

    Private Sub UcProduzioneOffset_SelezionatoFormatoCarta(IdFormatoCarta As Integer) Handles UcProduzioneOffset.SelezionatoFormatoCarta

        UcCommesseModelli.CaricaByIdFormatoCarta(IdFormatoCarta)
        tabProduzione.SelectedTab = tpModelliCommessa

    End Sub

    Private Sub UcProduzioneOffset_SelezionatoFormatoProdotto(IdFormatoProdotto As Integer) Handles UcProduzioneOffset.SelezionatoFormatoProdotto
        UcCommesseModelli.CaricaByIdFormatoProdotto(IdFormatoProdotto)
        tabProduzione.SelectedTab = tpModelliCommessa
    End Sub

    Private Sub UcProduzioneVerify_OrdineSelezionato() Handles UcProduzioneVerify.OrdineSelezionato
        If UcProduzioneVerify.IdOrdSel Then

            Cursor.Current = Cursors.WaitCursor

            Using x As New Ordine
                x.Read(UcProduzioneVerify.IdOrdSel)

                UcOrdiniAnteprima.Carica(x)
            End Using
            'UcOrdineDett.Carica(x)
            Cursor.Current = Cursors.Default

        End If
    End Sub

    Private Sub UcProduzioneOffset_SelezionatoOrdinePerModello(IdFormatoProdotto As Integer, IdColoreStampa As Integer) Handles UcProduzioneOffset.SelezionatoOrdinePerModello
        UcCommesseModelli.CaricaByIdFormatoProdotto(IdFormatoProdotto, IdColoreStampa)
        tabProduzione.SelectedTab = tpModelliCommessa
    End Sub

End Class
