Imports FormerLib.FormerEnum

Public Interface IVoceRubricaG

    ReadOnly Property IdRubG As Integer

    ReadOnly Property IdRubRif As Integer

    ReadOnly Property ProvenienzaVoce As String

    ReadOnly Property ProvenienzaVoceExt As String

    ReadOnly Property Sorgente As String

    ReadOnly Property NominativoG As String

    ReadOnly Property NomeDiBattesimo As String

    ReadOnly Property IdCategoriaMarketing As Integer

    ReadOnly Property Tipo As Integer

    ReadOnly Property Indirizzo As String

    ReadOnly Property Citta As String

    ReadOnly Property Cap As String

    ReadOnly Property EmailG As String

    ReadOnly Property DataInserimento As Date

    ReadOnly Property HannoAcquistatoAlmenoUnaVoltaUn(IdPreventivazione As Integer) As Boolean

    ReadOnly Property NonHannoMaiAcquistatoUn(IdPreventivazione As Integer) As Boolean

    ReadOnly Property SpesaComplessivaNelPeriodo(Periodo As enPeriodoRiferimento) As Integer

    ReadOnly Property NonHannoMaiSpeso As Boolean

    ReadOnly Property Tag As String

    Property DataUltimoInvioNewsletter As Date

    ReadOnly Property IdCorrierePredefinito As Integer

    ReadOnly Property ListaOrdini As List(Of Ordine)

End Interface
