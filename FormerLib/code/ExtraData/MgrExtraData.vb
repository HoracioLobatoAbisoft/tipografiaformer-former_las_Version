Imports FormerLib.FormerEnum
Public Class MgrExtraData

    Public Enum enExtraData As Integer
        Categoria = 1
        CalcolaSoloSuFacciata = 2
        MargineBordomm = 3
    End Enum

    Public Shared Function GetExtraDataEnum(Tipo As String) As enExtraData
        Dim ris As String = String.Empty

        Select Case Tipo
            Case "Categoria"
                ris = enExtraData.Categoria
            Case "CalcolaSoloSuFacciata"
                ris = enExtraData.CalcolaSoloSuFacciata
            Case "MargineBordomm"
                ris = enExtraData.MargineBordomm
        End Select

        Return ris
    End Function

    Public Shared Function GetExtraDataKey(Tipo As enExtraData) As String
        Dim ris As String = String.Empty

        Select Case Tipo
            Case enExtraData.Categoria
                ris = "Categoria"
            Case enExtraData.CalcolaSoloSuFacciata
                ris = "CalcolaSoloSuFacciata"
            Case enExtraData.MargineBordomm
                ris = "MargineBordomm"
        End Select

        Return ris
    End Function

    Public Shared Function GetExtraDataType(Tipo As enExtraData) As Type
        Dim ris As Type = Nothing

        Select Case Tipo
            Case enExtraData.Categoria
                ris = GetType(String)
            Case enExtraData.CalcolaSoloSuFacciata
                ris = GetType(FormerEnum.enSiNo)
            Case enExtraData.MargineBordomm
                ris = GetType(Integer)
        End Select

        Return ris
    End Function

    Public Shared Function GetExtraData(Buffer As String) As List(Of ExtraData)
        Dim l As New List(Of ExtraData)
        If Buffer.Length Then
            For Each coppia As String In Buffer.Split(";")
                If coppia.Length Then
                    Dim Chiave As String = coppia.Substring(0, coppia.IndexOf(":"))
                    Dim Valore As String = coppia.Substring(coppia.IndexOf(":") + 1)
                    Dim E As New ExtraData
                    E.Chiave = Chiave
                    E.Valore = Valore
                    l.Add(E)
                End If

            Next
        End If
        Return l
    End Function

    Public Shared Function GetAll() As List(Of ExtraData)
        Dim l As New List(Of ExtraData)

        Dim items = System.Enum.GetValues(GetType(enExtraData))
        Dim item As String
        For Each item In items
            Dim ed As New ExtraData
            ed.Chiave = GetExtraDataKey(item)
            l.Add(ed)
        Next

        Return l
    End Function


End Class
