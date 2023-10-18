Imports FormerBusinessLogicInterface

Public MustInherit Class RisultatoPlugin
    Public Property NomeInUrl As String = String.Empty
    Public Property BufferSVG As String = String.Empty
End Class

Public Class RisultatoPluginMisurePersonalizzate
    Inherits RisultatoPlugin
    Implements IRisultatoPlugin

    Public Property Base As Integer = 0 Implements IRisultatoPlugin.Base
    Public Property Profondita As Integer = 0 Implements IRisultatoPlugin.Profondita
    Public Property Altezza As Integer = 0 Implements IRisultatoPlugin.Altezza

    Public Property IdFormatoProdottoScelto As Integer = 0 Implements IRisultatoPlugin.IdFormatoProdottoScelto

    'Public Property IdListinoBase As Integer = 0

End Class


Public Class RisultatoPluginPackaging
    Inherits RisultatoPlugin
    Implements IRisultatoPlugin

    Public Property Base As Integer = 0 Implements IRisultatoPlugin.Base
    Public Property Profondita As Integer = 0 Implements IRisultatoPlugin.Profondita
    Public Property Altezza As Integer = 0 Implements IRisultatoPlugin.Altezza

    Public Property IdFormatoProdottoScelto As Integer = 0 Implements IRisultatoPlugin.IdFormatoProdottoScelto

    Public Property IdTipoFustella As Integer = 0


End Class

Public Class RisultatoPluginEtichette
    Inherits RisultatoPlugin
    Implements IRisultatoPlugin

    Public Property Base As Integer = 0 Implements IRisultatoPlugin.Base
    Public Property Altezza As Integer = 0 Implements IRisultatoPlugin.Altezza

    Public Property Categoria As String = String.Empty

    Public Property IdFormatoProdottoScelto As Integer = 0 Implements IRisultatoPlugin.IdFormatoProdottoScelto

    Public Property IdTipoFustella As Integer = 0

    Public Property ImgFustellaScelta As String = String.Empty

    Public Property Profondita As Integer Implements IRisultatoPlugin.Profondita
        Get
            Return -1
        End Get
        Set(value As Integer)
            'Throw New NotImplementedException()
        End Set
    End Property
End Class