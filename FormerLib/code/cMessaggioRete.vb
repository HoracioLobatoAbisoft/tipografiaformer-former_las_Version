Public Class MessaggioDiReteInterno

    'IL MESS è TIPO ALL@C3409253719
    'IL MESS è TIPO ALL@C3409253719@DIEGO
    Public Sub New(MessaggioCodificato As String)

        If MessaggioCodificato.Length Then
            Dim PosizDuePunti As Integer = MessaggioCodificato.IndexOf("@")

            If PosizDuePunti <> -1 Then
                TipoMess = MessaggioCodificato.Substring(PosizDuePunti + 1, 1)
                Dest = MessaggioCodificato.Substring(0, PosizDuePunti)
                Testo = MessaggioCodificato.Substring(PosizDuePunti + 2)
                Valido = True

                Dim PosizDuePuntiMitt As Integer = MessaggioCodificato.IndexOf("@", PosizDuePunti + 1)

                If PosizDuePuntiMitt <> -1 Then
                    Testo = MessaggioCodificato.Substring(PosizDuePunti + 2, PosizDuePuntiMitt - PosizDuePunti - 2)
                    Mittente = MessaggioCodificato.Substring(PosizDuePuntiMitt + 1)
                End If

            End If

        End If

    End Sub

    Public Property Valido As Boolean = False

    Public Property TipoMess As String = String.Empty

    Public Property Dest As String = String.Empty

    Public Property Testo As String = String.Empty

    Public Property Mittente As String = String.Empty

    Public Property Postazione As String = String.Empty

End Class
