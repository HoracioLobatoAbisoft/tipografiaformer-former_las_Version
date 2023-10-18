Imports FormerLib.FormerEnum

Public Class MgrComandiRemoti
    Public Shared Function Crea(Optional IdCom As Integer = 0,
                         Optional IdOrd As Integer = 0,
                         Optional IdUt As Integer = 0,
                         Optional TipoOperazione As enTipoComandoRemoto = enTipoComandoRemoto.NonSpecificato) As RisCreazioneComandoRemoto
        Dim ris As RisCreazioneComandoRemoto

        Using CR As New ComandoRemoto
            CR.IdCom = IdCom
            CR.IdOrd = IdOrd
            CR.IdUt = IdUt
            CR.TipoOperazione = TipoOperazione
            CR.Stato = enStatoComandoRemoto.Inserito
            CR.Save()

            Using crL As New ComandoRemotoLog
                crL.IdCM = CR.IdCM
                crL.Quando = Now
                crL.IdOperazioneRemota = enStatoComandoRemoto.Inserito
                crL.Save()
            End Using
        End Using

        Return ris
    End Function
End Class
