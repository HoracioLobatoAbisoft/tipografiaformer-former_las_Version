Imports FormerLib.FormerEnum

Public Class MgrPluginPackaging

    Private Shared Function FunzioneECMA1(Pre As IPreventivazioneB,
                                    H As Integer,
                                    B As Integer,
                                    P As Integer) As FormatoSteso
        'CALCOLA IL FORMATO STESO PER GLI ASTUCCI STANDARD ECMA A20.20.03.01
        Dim Ris As New FormatoSteso

        Ris.Base = (B * 2) + (P * 2) + Pre.Linguetta
        Ris.Altezza = H + (P * 2) + (Pre.Linguetta * 2)

        Return Ris

    End Function

    Private Shared _ValoreMinAltezza As Integer = 40
    Private Shared _ValoreMinBase As Integer = 20
    Private Shared _ValoreMinProfondita As Integer = 14

    Public Shared Function GetMinimoAltezza(Pre As IPreventivazioneB) As Integer
        Dim ris As Integer = 0
        If Pre.IdFunzionePack = enFunzionePackaging.FunzioneECMA3 Then
            ris = 100
        Else
            ris = _ValoreMinAltezza
        End If

        Return ris
    End Function

    Public Shared Function GetMinimoBase(Pre As IPreventivazioneB) As Integer
        Dim ris As Integer = 0
        If Pre.IdFunzionePack = enFunzionePackaging.FunzioneECMA3 Then
            ris = 70
        Else
            ris = _ValoreMinBase
        End If
        Return ris
    End Function

    Public Shared Function GetMinimoProfondita(Pre As IPreventivazioneB) As Integer
        Dim ris As Integer = 0

        If Pre.IdFunzionePack = enFunzionePackaging.FunzioneECMA3 Then
            ris = 20
        Else
            ris = _ValoreMinProfondita
        End If

        Return ris
    End Function

    Public Shared Function GetProfonditaCalcolataPackagingCuscino(Pre As IPreventivazioneB,
                                                                  Base As Integer) As Integer
        Dim ris As Integer = 0

        If Base Then
            ris = Math.Ceiling((Base * 30) / 100)
        End If

        Dim MinimoProfondita As Integer = GetMinimoProfondita(Pre)
        If ris < MinimoProfondita Then
            ris = MinimoProfondita
        Else
            ris = ArrotondaA5mm(ris)
        End If
        Return ris
    End Function

    Public Shared Function ArrotondaA5mm(ValoreIniziale As Integer) As Integer

        Dim ris As Integer = 0

        If ValoreIniziale Then
            ris = (ValoreIniziale \ 10) * 10
        End If

        Return ris

    End Function

    Public Shared Function ArrotondaA10mm(ValoreIniziale As Integer) As Integer

        Dim ris As Integer = ValoreIniziale
        ris = Math.Ceiling(ris / 10) * 10
        Return ris

    End Function

    Private Shared Function FunzioneECMA2(Pre As IPreventivazioneB,
                                H As Integer,
                                B As Integer,
                                P As Integer) As FormatoSteso
        'CALCOLA IL FORMATO STESO PER GLI ASTUCCI STANDARD ECMA A20.21.03.03
        Dim Ris As New FormatoSteso

        Ris.Base = (B * 2) + (P * 2) + Pre.Linguetta
        Ris.Altezza = H + (P * 2.7) + (Pre.Linguetta * 2)

        Return Ris

    End Function

    Private Shared Function FunzioneECMA3(Pre As IPreventivazioneB,
                                H As Integer,
                                B As Integer,
                                P As Integer) As FormatoSteso
        'CALCOLA IL FORMATO STESO PER GLI ASTUCCI STANDARD ECMA A20.21.03.03
        Dim Ris As New FormatoSteso

        Ris.Base = B + P
        Ris.Altezza = (H * 2) + Pre.Linguetta

        Return Ris

    End Function
    Private Shared Function FunzioneECMA4(Pre As IPreventivazioneB,
                                    H As Integer,
                                    B As Integer,
                                    P As Integer) As FormatoSteso
        'CALCOLA IL FORMATO STESO PER GLI ASTUCCI STANDARD ECMA A20.55.03.01
        Dim Ris As New FormatoSteso

        Ris.Base = (B * 2) + (P * 2) + Pre.Linguetta
        Ris.Altezza = H + (P * 2) + (Pre.Linguetta * 2)

        Return Ris

    End Function

    Public Shared Function GetNomeStandardECMA(IdFunzionePackaging As enFunzionePackaging) As String
        Dim ris As String = String.Empty

        Select Case IdFunzionePackaging
            Case enFunzionePackaging.FunzioneECMA1
                ris = "A20.20.03.01"
            Case enFunzionePackaging.FunzioneECMA2
                ris = "A20.21.03.03"
            Case enFunzionePackaging.FunzioneECMA3
                ris = "F70.01.00.00"
            Case enFunzionePackaging.FunzioneECMA4
                ris = "A20.55.03.01"

        End Select

        Return ris

    End Function

    Public Shared Function GetListiniBaseCompatibili(Pre As IPreventivazioneB,
                                    H As Integer,
                                    B As Integer,
                                    P As Integer) As RisPackaging

        'puo tornare anche nothing se nessuno dei formatiprodotto va bene per queste misure

        Dim ris As New RisPackaging

        Dim Fs As FormatoSteso = Nothing
        Dim IdFunzToUse As Integer = Pre.IdFunzionePack
        If IdFunzToUse = 0 Then IdFunzToUse = enFunzionePackaging.FunzioneECMA1

        ris.FunzioneEcma = IdFunzToUse

        Select Case IdFunzToUse

            Case enFunzionePackaging.FunzioneECMA1
                Fs = FunzioneECMA1(Pre, H, B, P)
            Case enFunzionePackaging.FunzioneECMA2
                Fs = FunzioneECMA2(Pre, H, B, P)
            Case enFunzionePackaging.FunzioneECMA3
                Fs = FunzioneECMA3(Pre, H, B, P)
            Case enFunzionePackaging.FunzioneECMA4
                Fs = FunzioneECMA4(Pre, H, B, P)
        End Select

        If Not Fs Is Nothing Then
            ris.FormatoSteso = Fs
            'qui cerco nella lista dei formatiprodotto quelli in cui entra mettendo prima quello che si adatta meglio e cosi via
            For Each lb As IListinoBaseB In Pre.ListiniBase
                If (Fs.Altezza <= (lb.FormatoCarta.Altezza * 10) And Fs.Base <= (lb.FormatoCarta.Larghezza * 10)) Or
                    (Fs.Base <= (lb.FormatoCarta.Altezza * 10) And Fs.Altezza <= (lb.FormatoCarta.Larghezza * 10)) Then
                    ris.ListiniBase.Add(lb)
                End If
            Next

        End If

        ris.ListiniBase.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))

        Return ris
    End Function

End Class
