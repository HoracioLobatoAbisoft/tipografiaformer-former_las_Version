Imports System.IO

Public Class MgrAziende

    Public Enum IdAziende
        AziendaSnc = 1
        AziendaSrl
    End Enum
    Public Shared Function GetSiglaStr(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "SNC"
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "SRL"
        End If

        Return ris
    End Function

    Public Shared Function GetAziendaStr(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "Former snc"
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "Former srl"
        End If

        Return ris
    End Function

    Public Shared Function GetREA(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "852451"
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "1559314"
        End If

        Return ris
    End Function

    Public Shared Function GetIBAN(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "IT55A0623005089000063379643" '"IT08N0881239091000000034090"
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "IT11H0878739091000000034748" '"IT05Q0881239091000000034748"
        End If

        Return ris
    End Function

    'Public Shared Function GetABI(IdAzienda As Integer) As String
    '    Dim ris As String = String.Empty

    '    If IdAzienda = IdAziende.AziendaSnc Then
    '        ris = "852451"
    '    ElseIf IdAzienda = IdAziende.AziendaSrl Then
    '        ris = "1559314"
    '    End If

    '    Return ris
    'End Function

    'Public Shared Function GetCAB(IdAzienda As Integer) As String
    '    Dim ris As String = String.Empty

    '    If IdAzienda = IdAziende.AziendaSnc Then
    '        ris = "852451"
    '    ElseIf IdAzienda = IdAziende.AziendaSrl Then
    '        ris = "1559314"
    '    End If

    '    Return ris
    'End Function

    Public Shared Function GetBIC(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "ICRAITRRMK0"
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "ICRAITRRLV0"
        End If

        Return ris
    End Function

    Public Shared Function GetCAP(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "00123"
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "00123"
        End If

        Return ris
    End Function

    Public Shared Function GetIndirizzo(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "Via Agostino Scali, 52"
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "Via Cassia, 2010"
        End If

        Return ris

    End Function

    Public Shared Function GetNCivico(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "2010"
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "2010"
        End If

        Return ris
    End Function

    Public Shared Sub SavePECSDI(IdAzienda As Integer, NewPecSDI As String)

        Dim PathSdi As String = "nextsdi" & IdAzienda & ".txt"
        PathSdi = FormerConfig.FormerPath.PathFattureFE & PathSdi
        Try
            Using w As New StreamWriter(PathSdi)
                w.Write(NewPecSDI)
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function GetPECSDI(Idazienda As Integer) As String

        Dim ris As String = String.Empty

        If Idazienda = IdAziende.AziendaSnc Then
            ris = "sdi01@pec.fatturapa.it"
        ElseIf Idazienda = IdAziende.AziendaSrl Then
            ris = "sdi20@pec.fatturapa.it"
        End If

        Try
            Dim PathSdi As String = "nextsdi" & Idazienda & ".txt"
            PathSdi = FormerConfig.FormerPath.PathFattureFE & PathSdi
            Dim NuovaPec As String = String.Empty
            Using r As New StreamReader(PathSdi)
                NuovaPec = r.ReadToEnd
            End Using
            ris = NuovaPec.Trim
        Catch ex As Exception

        End Try

        Return ris

    End Function

    Public Shared Function GetPEC(Idazienda As Integer) As String

        Dim ris As String = String.Empty

        If Idazienda = IdAziende.AziendaSnc Then
            ris = "formersnc@pec.it"
        ElseIf Idazienda = IdAziende.AziendaSrl Then
            ris = "tipografiaformer@pec.it"
        End If

        Return ris

    End Function

    Public Shared Function GetPECPassword(Idazienda As Integer) As String

        Dim ris As String = String.Empty

        If Idazienda = IdAziende.AziendaSnc Then
            ris = "gl99YhpoCl30!"
        ElseIf Idazienda = IdAziende.AziendaSrl Then
            ris = "Z19gh5tt9!"
        End If

        Return ris

    End Function

    Public Shared Function GetRagioneSociale(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "Former snc di Duca Antonio & c."
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "Tipografia Former srl"
        End If

        Return ris
    End Function

    Public Shared Function GetPartitaIva(IdAzienda As Integer) As String
        Dim ris As String = String.Empty

        If IdAzienda = IdAziende.AziendaSnc Then
            ris = "05200481009"
        ElseIf IdAzienda = IdAziende.AziendaSrl Then
            ris = "14974961006"
        End If

        Return ris
    End Function
End Class
