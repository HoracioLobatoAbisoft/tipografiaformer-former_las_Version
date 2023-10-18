Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrUDP

    Public Shared Sub AnteprimaModelloCommessa(IdModello As Integer,
                                              FronteRetro As enFronteRetro)

        Dim Buffer As String = IdModello & CInt(FronteRetro)

        FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_RigeneraAnteprimaModello, Buffer)

    End Sub

    Public Shared Sub AnteprimaLavoro(IdLavoro As Integer)

        FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_RigeneraAnteprimaOrdine, IdLavoro)

    End Sub

End Class
