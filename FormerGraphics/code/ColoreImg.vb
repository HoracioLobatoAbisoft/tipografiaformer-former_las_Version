Imports System.Drawing

Public Class ColoreImg

    Public Property R As Byte = 0
    Public Property G As Byte = 0
    Public Property B As Byte = 0


    Public Punti As New List(Of Point)

    Public ReadOnly Property HtmlCode As String
        Get
            Dim ris As String = "#"

            ris &= IIf(Hex(R).Length = 1, "0" & Hex(R), Hex(R))
            ris &= IIf(Hex(G).Length = 1, "0" & Hex(G), Hex(G))
            ris &= IIf(Hex(B).Length = 1, "0" & Hex(B), Hex(B))

            Return ris
        End Get
    End Property

End Class
