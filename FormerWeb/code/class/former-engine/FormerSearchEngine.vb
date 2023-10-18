Imports FormerDALWeb
Imports System.Web

Public Class FormerSearchEngine

    Public Shared Function EncryptRichiesta(InKeywords As String) As String

        Dim ris As String = InKeywords.Replace(" ", "-")
        ris = HttpContext.Current.Server.HtmlEncode(ris)
        Return ris

    End Function

    Public Shared Function DecryptRichiesta(InKeywords As String) As String

        Dim ris As String = String.Empty
        If Not InKeywords Is Nothing AndAlso InKeywords.Length Then
            InKeywords = InKeywords.Trim
            ris = InKeywords.Replace("-", " ")
            ris = HttpContext.Current.Server.HtmlDecode(ris)
        End If
        Return ris

    End Function

    Private Shared Function CercaSenzaUltimoCar(lSource As List(Of IndiceRicerca), lParz As List(Of IndiceRicerca)) As List(Of IndiceRicerca)

        Dim lTemp As List(Of IndiceRicerca) = Nothing
        Dim lRis As New List(Of IndiceRicerca)

        Dim KeywordsSenzaLastChar As String = PKeywords

        If PKeywords.Length > 2 Then

            KeywordsSenzaLastChar = PKeywords.Substring(0, PKeywords.Length - 1)

            Dim singKSenzaLastChar As String() = KeywordsSenzaLastChar.Split(" ")

            'INIZIA CON PAROLA CHIAVE ESATTA
            lTemp = lSource.FindAll(Function(x) x.NomeListino.ToLower.IndexOf(KeywordsSenzaLastChar) = 0)
            For Each singRis As IndiceRicerca In lTemp
                If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing _
                    And lParz.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                    singRis.EsattezzaRisultato = 690
                    lRis.Add(singRis)
                End If
            Next

            'PAROLA CHIAVE CONTENUTA NEL TITOLO
            lTemp = lSource.FindAll(Function(x) x.NomeListino.ToLower.IndexOf(KeywordsSenzaLastChar) <> -1)
            For Each singRis As IndiceRicerca In lTemp
                If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing _
                    And lParz.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                    singRis.EsattezzaRisultato = 300 + singRis.KeywordTrovate
                    lRis.Add(singRis)
                End If
            Next

            'PIU PAROLE CHIAVI CI SONO PIU PRENDE PUNTI
            SetMoreInsideTitleWOC(lSource)
            lTemp = lSource.FindAll(Function(x) x.KeywordTrovate > 0)
            For Each singRis As IndiceRicerca In lTemp
                If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                    singRis.EsattezzaRisultato = 300 + singRis.KeywordTrovate
                    lRis.Add(singRis)
                End If
            Next

            'ALMENO UNA DELLE PAROLE CHIAVI INIZIA IL TITOLO
            lTemp = lSource.FindAll(AddressOf OneStartTitleWOC)
            For Each singRis As IndiceRicerca In lTemp
                If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing _
                    And lParz.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                    singRis.EsattezzaRisultato = 190
                    lRis.Add(singRis)
                End If
            Next

            'ALMENO UNA DELLE PAROLE CHIAVI CONTENUTE NEL TITOLO 
            lTemp = lSource.FindAll(AddressOf OneInsideTitleWOC)
            For Each singRis As IndiceRicerca In lTemp
                If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing _
                    And lParz.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                    singRis.EsattezzaRisultato = 90
                    lRis.Add(singRis)
                End If
            Next

        End If

        Return lRis

    End Function

    Private Shared Function CercaNellaDescrizione(lSource As List(Of IndiceRicerca), lParz As List(Of IndiceRicerca)) As List(Of IndiceRicerca)

        Dim lTemp As List(Of IndiceRicerca) = Nothing
        Dim lRis As New List(Of IndiceRicerca)

        'PAROLA CHIAVE CONTENUTA NEL TITOLO
        lTemp = lSource.FindAll(Function(x) x.ListinoBase.DescrSito.ToLower.IndexOf(PKeywords) <> -1)
        For Each singRis As IndiceRicerca In lTemp
            If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing _
                    And lParz.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                singRis.EsattezzaRisultato = 480
                lRis.Add(singRis)
            End If
        Next

        'TUTTE LE PAROLE CHIAVI CONTENUTE NEL TITOLO
        lTemp = lSource.FindAll(AddressOf AllInsideDescription)
        For Each singRis As IndiceRicerca In lTemp
            If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing _
                    And lParz.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                singRis.EsattezzaRisultato = 380
                lRis.Add(singRis)
            End If
        Next

        'ALMENO UNA DELLE PAROLE CHIAVI CONTENUTE NEL TITOLO 
        lTemp = lSource.FindAll(AddressOf OneInsideTitle)
        For Each singRis As IndiceRicerca In lTemp
            If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing _
                    And lParz.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                singRis.EsattezzaRisultato = 80
                lRis.Add(singRis)
            End If
        Next

        Return lRis

    End Function

    Private Shared _Pkeywords As String = String.Empty
    Protected Shared ReadOnly Property PKeywords As String
        Get
            Return _Pkeywords
        End Get
    End Property

    Protected Shared ReadOnly Property PSingKeywords As String()
        Get
            Return PKeywords.Split(" ")
        End Get
    End Property

    Protected Shared ReadOnly Property KeywordsDaIgnorare() As String
        Get
            Return ",di,a,da,in,con,su,per,tra,fra,"
        End Get
    End Property

    Private Shared Function CercaNelTitolo(lSource As List(Of IndiceRicerca)) As List(Of IndiceRicerca)

        Dim lTemp As List(Of IndiceRicerca) = Nothing
        Dim lRis As New List(Of IndiceRicerca)

        'PAROLA CHIAVE ESATTA
        lTemp = lSource.FindAll(Function(x) x.NomeListino.ToLower = PKeywords)
        For Each singRis As IndiceRicerca In lTemp
            singRis.EsattezzaRisultato = 1000
            lRis.Add(singRis)
        Next

        'INIZIA CON PAROLA CHIAVE ESATTA
        lTemp = lSource.FindAll(Function(x) x.NomeListino.ToLower.IndexOf(PKeywords) = 0)
        For Each singRis As IndiceRicerca In lTemp
            If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                singRis.EsattezzaRisultato = 900
                lRis.Add(singRis)
            End If
        Next

        'PAROLA CHIAVE CONTENUTA NEL TITOLO
        lTemp = lSource.FindAll(Function(x) x.NomeListino.ToLower.IndexOf(PKeywords) <> -1)
        For Each singRis As IndiceRicerca In lTemp
            If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                singRis.EsattezzaRisultato = 700
                lRis.Add(singRis)
            End If
        Next

        'TUTTE LE PAROLE CHIAVI CONTENUTE NEL TITOLO
        lTemp = lSource.FindAll(AddressOf AllInsideTitle)
        For Each singRis As IndiceRicerca In lTemp
            If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                singRis.EsattezzaRisultato = 400
                lRis.Add(singRis)
            End If
        Next

        'PIU PAROLE CHIAVI CI SONO PIU PRENDE PUNTI
        SetMoreInsideTitle(lSource)
        lTemp = lSource.FindAll(Function(x) x.KeywordTrovate > 0)
        For Each singRis As IndiceRicerca In lTemp
            If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                singRis.EsattezzaRisultato = 300 + singRis.KeywordTrovate
                lRis.Add(singRis)
            End If
        Next

        'ALMENO UNA DELLE PAROLE CHIAVI INIZIA IL TITOLO
        lTemp = lSource.FindAll(AddressOf OneStartTitle)
        For Each singRis As IndiceRicerca In lTemp
            If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                singRis.EsattezzaRisultato = 200
                lRis.Add(singRis)
            End If
        Next

        'ALMENO UNA DELLE PAROLE CHIAVI CONTENUTE NEL TITOLO 
        lTemp = lSource.FindAll(AddressOf OneInsideTitle)
        For Each singRis As IndiceRicerca In lTemp
            If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then
                singRis.EsattezzaRisultato = 100
                lRis.Add(singRis)
            End If
        Next

        Return lRis

    End Function

    Private Shared Function AllInsideDescription(x As IndiceRicerca)
        Dim ris As Integer = 0
        Dim TrovateTutte As Integer = -1
        For Each singKey As String In PSingKeywords
            If KeywordsDaIgnorare.IndexOf(singKey) = -1 Then
                If x.ListinoBase.DescrSito.ToLower.IndexOf(singKey) = -1 Then
                    TrovateTutte = 0
                    Exit For
                Else
                    If TrovateTutte <> 0 Then TrovateTutte = 1
                End If
            End If
        Next
        If TrovateTutte = 1 Then ris = 1
        Return ris
    End Function

    Private Shared Function SetMoreInsideTitle(ByRef l As List(Of IndiceRicerca))
        Dim ris As Integer = 0
        For Each ind As IndiceRicerca In l
            ind.KeywordTrovate = 0
            For Each singKey As String In PSingKeywords
                If KeywordsDaIgnorare.IndexOf(singKey) = -1 Then
                    If ind.NomeListino.ToLower.IndexOf(singKey) <> -1 Then
                        ind.KeywordTrovate += singKey.Length
                    End If
                End If
            Next
        Next
        Return ris
    End Function

    Private Shared Function SetMoreInsideTitleWOC(ByRef l As List(Of IndiceRicerca))
        Dim ris As Integer = 0
        For Each ind As IndiceRicerca In l
            ind.KeywordTrovate = 0
            For Each singKey As String In PSingKeywords
                If KeywordsDaIgnorare.IndexOf(singKey) = -1 Then
                    If singKey.Length > 2 Then
                        Dim singkeyWOC As String = singKey.Substring(0, singKey.Length - 1)
                        If ind.NomeListino.ToLower.IndexOf(singkeyWOC) <> -1 Then
                            ind.KeywordTrovate += singkeyWOC.Length
                        End If
                    End If
                End If
            Next
        Next
        Return ris
    End Function

    Private Shared Function AllInsideTitle(x As IndiceRicerca)
        Dim ris As Integer = 0
        Dim TrovateTutte As Integer = -1
        For Each singKey As String In PSingKeywords
            If KeywordsDaIgnorare.IndexOf(singKey) = -1 Then
                If x.NomeListino.ToLower.IndexOf(singKey) = -1 Then
                    TrovateTutte = 0
                    Exit For
                Else
                    If TrovateTutte <> 0 Then TrovateTutte = 1
                End If
            End If
        Next
        If TrovateTutte = 1 Then ris = 1
        Return ris
    End Function

    Private Shared Function OneInsideTitleWOC(x As IndiceRicerca)
        Dim ris As Integer = 0
        For Each singKey As String In PSingKeywords
            If KeywordsDaIgnorare.IndexOf(singKey) = -1 Then
                If singKey.Length > 2 Then
                    Dim singkeyWOC As String = singKey.Substring(0, singKey.Length - 1)
                    If x.NomeListino.ToLower.IndexOf(singkeyWOC) <> -1 Then
                        ris = 1
                        Exit For
                    End If
                End If
            End If
        Next
        Return ris
    End Function

    Private Shared Function OneStartTitleWOC(x As IndiceRicerca)
        Dim ris As Integer = 0
        For Each singKey As String In PSingKeywords
            If KeywordsDaIgnorare.IndexOf(singKey) = -1 Then
                If singKey.Length > 2 Then
                    Dim singkeyWOC As String = singKey.Substring(0, singKey.Length - 1)
                    If x.NomeListino.ToLower.IndexOf(singkeyWOC) = 0 Then
                        ris = 1
                        Exit For
                    End If
                End If
            End If
        Next
        Return ris
    End Function

    Private Shared Function OneInsideDescription(x As IndiceRicerca)
        Dim ris As Integer = 0
        For Each singKey As String In PSingKeywords
            If KeywordsDaIgnorare.IndexOf(singKey) = -1 Then
                If x.ListinoBase.DescrSito.ToLower.IndexOf(singKey) <> -1 Then
                    ris = 1
                    Exit For
                End If
            End If
        Next
        Return ris
    End Function

    Private Shared Function OneInsideTitle(x As IndiceRicerca)
        Dim ris As Integer = 0
        For Each singKey As String In PSingKeywords
            If KeywordsDaIgnorare.IndexOf(singKey) = -1 Then
                If x.NomeListino.ToLower.IndexOf(singKey) <> -1 Then
                    ris = 1
                    Exit For
                End If
            End If
        Next
        Return ris
    End Function

    Private Shared Function OneStartTitle(x As IndiceRicerca)
        Dim ris As Integer = 0
        For Each singKey As String In PSingKeywords
            If KeywordsDaIgnorare.IndexOf(singKey) = -1 Then
                If x.NomeListino.ToLower.IndexOf(singKey) = 0 Then
                    ris = 1
                    Exit For
                End If
            End If
        Next
        Return ris
    End Function

    Public Shared Function Cerca(KeywordsInserite As String) As IEnumerable(Of IndiceRicerca)

        Dim lSource As List(Of IndiceRicerca) = Nothing
        Dim lRis As New List(Of IndiceRicerca)

        _Pkeywords = KeywordsInserite.ToLower

        If KeywordsInserite.Length > 1 Then
            Using mgr As New IndiciRicercaDAO

                Dim lP As New List(Of LUNA.LunaSearchParameter)
                Dim lTemp As List(Of IndiceRicerca) = Nothing

                If PSingKeywords.Count Then

                    lSource = mgr.GetAll("")

                    lTemp = CercaNelTitolo(lSource)
                    For Each singRis As IndiceRicerca In lTemp
                        lRis.Add(singRis.Clone)
                    Next

                    'If lTemp.Count = 0 Then
                    'qui provo con la funzione con un solo carattere in meno per keyword
                    lTemp = CercaSenzaUltimoCar(lSource, lTemp)
                    'End If

                    For Each singRis As IndiceRicerca In lTemp
                        If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then lRis.Add(singRis.Clone)
                    Next

                    lTemp = CercaNellaDescrizione(lSource, lTemp)

                    For Each singRis As IndiceRicerca In lTemp
                        If lRis.Find(Function(x) x.IdIndiceRicerca = singRis.IdIndiceRicerca) Is Nothing Then lRis.Add(singRis.Clone)
                    Next

                    lRis.Sort(AddressOf Sort)
                End If
            End Using
        End If

        Dim query = From p In lRis.Take(100)

        Return query

    End Function

    Private Shared Function Sort(ByVal x As IndiceRicerca, ByVal y As IndiceRicerca) As Integer
        Dim result As Integer = y.EsattezzaRisultato.CompareTo(x.EsattezzaRisultato)
        If result = 0 Then result = x.Prezzo1Riv.CompareTo(y.Prezzo1Riv)

        Return result
    End Function

End Class
