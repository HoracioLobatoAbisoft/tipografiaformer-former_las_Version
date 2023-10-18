Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerLib

Public Class MGROrdiniInGriglia

    Public Function GetGriglia(Lista As List(Of OrdineWeb)) As List(Of OrdineInGriglia)

        Dim Ris As New List(Of OrdineInGriglia)

        For Each O As OrdineWeb In Lista
            Dim Og As New OrdineInGriglia(O)
            Ris.Add(Og)
        Next

        Return Ris

    End Function


End Class

Public Class OrdineInGriglia

    Public Sub New(O As OrdineWeb)
        _O = O
    End Sub

    Private _O As OrdineWeb = Nothing
    Public ReadOnly Property O As OrdineWeb
        Get
            Return _O
        End Get
    End Property

    Public ReadOnly Property DataIns As String
        Get
            Return _O.DataIns.ToString("dd/MM/yyyy")
        End Get
    End Property

    Private _Stato As String = String.Empty
    Public Property Stato As String
        Get
            If _Stato.Length = 0 Then
                _Stato = FormerEnumHelper.StatoOrdineString(_O.Stato, True, O.IdCorriere)
            End If
            Return _Stato

        End Get
        Set(value As String)
            _Stato = value
        End Set

    End Property

    Public ReadOnly Property IdOrdine As String
        Get
            Dim Ris As String = "Non ancora disponibile"
            If _O.IdOrdineInt Then
                Ris = _O.IdOrdineInt
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property Prodotto As String
        Get
            Return _O.Riassunto

        End Get
    End Property

    Public ReadOnly Property ColoreStato As System.Drawing.Color
        Get
            Return FormerColori.GetColoreStatoOrdine(_O.Stato)
        End Get
    End Property

    Public ReadOnly Property Importo As String
        Get
            Return "€ " & FormerHelper.Stringhe.FormattaPrezzo(_O.PrezzoCalcolatoNetto)
        End Get
    End Property

    Public ReadOnly Property Anteprima As String
        Get
            Return _O.AnteprimaWeb
        End Get
    End Property

End Class
