Imports System.Collections.ObjectModel

Public Class ListEx
    Inherits List(Of OrdineInSoluzione)
    Private _Firma As String = String.Empty
    Public ReadOnly Property Firma As String
        Get
            If _Firma = String.Empty Then
                Dim Tmp As String = String.Empty
                Sort(Function(x, y) x.SpaziUsati.CompareTo(y.SpaziUsati))
                For Each a As OrdineInSoluzione In MyBase.ToList

                    Tmp &= a.SpaziUsati & "-"

                Next
                _Firma = Tmp.TrimEnd("-")
            End If
            Return _Firma
        End Get
    End Property

End Class
