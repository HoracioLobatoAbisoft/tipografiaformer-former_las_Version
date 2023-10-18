Public Class ScopertoMese

    Public ReadOnly Property Mese As String
        Get
            Dim Ris As String = _MeseRif.Substring(0, 4)
            Ris = Ris & " " & FormerLib.FormerHelper.Calendario.MeseToString(_MeseRif.Substring(4)).Substring(0, 3)
            Return Ris
        End Get
    End Property

    Public Property MeseRif As String = String.Empty
    Public Property Scoperto As Decimal = 0

End Class
