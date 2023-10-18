Public Class MgrImballo

    Public Shared Function NumColliDaSoluzione(IdOrd As Integer,
                                               ByRef frmRif As FormerLib.IFormWithSottofondo,
                                               Optional QtaForzataCubetti As Integer = 0) As Integer

        Dim ris As Integer = 0

        Using f As New frmMagazzinoSoluzioneImballo
            frmRif.Sottofondo()
            ris = f.Carica(IdOrd, QtaForzataCubetti)
            frmRif.Sottofondo()
        End Using

        Return ris

    End Function

    Public Shared Function CalcolaSoluzione(Qta As Integer,
                                            Cubetto As Cubetto,
                                            Optional QtaForzataCubetti As Integer = 0) As List(Of SoluzioneImballo)

        Dim SoluzioneImballo As SoluzioneImballo = Nothing
        Dim ListaSoluzioni As New List(Of SoluzioneImballo)

        Dim NumeroCubetti As Integer = Math.Ceiling(Qta / Cubetto.NumeroPezzi)

        If QtaForzataCubetti Then NumeroCubetti = QtaForzataCubetti

        Dim Scatole As New ScatoleDisponibili(Cubetto)

        For Each TipoDiScatola As TipoScatola In Scatole.ScatoleDisponibili
            'qui dentro gia ho tutte le varie soluzioni possibili praticamente 
            SoluzioneImballo = New SoluzioneImballo
            SoluzioneImballo.NumeroCubetti = NumeroCubetti
            SoluzioneImballo.TipoScatola = TipoDiScatola.Clone
            SoluzioneImballo.Cubetto = Cubetto

            SoluzioneImballo.CalcolaScatoleReali()

            ListaSoluzioni.Add(SoluzioneImballo)
        Next

        'in listasoluzioni ho tutte le possibili soluzioni, ora scelgo quella che usa meno scatole e a parita di scatola quella che spreca meno spazio

        'meno scatole possibile 
        ' a parita di scatole prendo la scatola piu piccola
        ' se invece la seconda soluzione non ha lo stesso numero di scatole 

        ListaSoluzioni.Sort(AddressOf Comparer)

        'qui ho gia scelto le soluzioni ora le livello

        LivellaSoluzioni(ListaSoluzioni)

        Return ListaSoluzioni

    End Function

    Private Shared Sub LivellaSoluzioni(ListaSoluzioni As List(Of SoluzioneImballo))

        'qui devo livellare gli oggetti nelle scatole se possibile

        For Each s As SoluzioneImballo In ListaSoluzioni
            If s.Cubetto.NumeroPezzi = 1 Then

                Dim TotalePezzi As Integer = s.NumeroCubetti
                Dim GiustiPerScat As Integer = Math.Ceiling(TotalePezzi / s.NumeroScatole)
                Dim PezziTotale As Integer = 0
                For Each scat As ScatolaProposta In s.Scatole
                    Dim PezziScatola As Integer = scat.Cubetti.Count
                    Do Until scat.Cubetti.Count = GiustiPerScat Or (PezziScatola + PezziTotale = s.NumeroCubetti)
                        If scat.Cubetti.Count < GiustiPerScat Then
                            If PezziScatola + PezziTotale + 1 <= s.NumeroCubetti Then scat.Cubetti.Add(s.Cubetto.Clone)

                        Else
                            scat.Cubetti.RemoveAt(0)
                        End If
                        PezziScatola = scat.Cubetti.Count
                    Loop
                    PezziTotale += PezziScatola
                Next
            End If
        Next


    End Sub

    Private Shared Function Comparer(ByVal x As SoluzioneImballo,
                                     ByVal y As SoluzioneImballo) As Integer

        'Dim Result As Integer = y.TutteScatolePiene.CompareTo(x.TutteScatolePiene)
        'If Result = 0 Then Result = x.NumeroScatole.CompareTo(y.NumeroScatole)
        'If result = 0 Then result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        Dim Result As Integer = x.TipoScatola.Custom.CompareTo(y.TipoScatola.Custom)
        If Result = 0 Then Result = x.NumeroScatole.CompareTo(y.NumeroScatole)
        If Result = 0 Then Result = x.TipoScatola.Volume.CompareTo(y.TipoScatola.Volume)
        If Result = 0 Then Result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        'Dim Result As Integer = x.Selezionatore.CompareTo(y.Selezionatore)
        ''If Result = 0 Then Result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        Return Result

    End Function

End Class
