Imports System.IO

Public Class FormerSerializator

    Public Shared Function SystemSerializer(Obj As Object, path As String)

        Dim x As New System.Xml.Serialization.XmlSerializer(Obj.GetType)

        Dim w As New StreamWriter(path)
        x.Serialize(w, Obj)
        w.Close()

    End Function


    Public Shared Function SerializeObjectToFile(Obj As Object,
                                                 Path As String) As Integer
        Dim ris As Integer = 0

        Dim buffer As String = GetSerializeBuffer(Obj)

        Try
            FormerHelper.File.CreateLongPath(Path)
        Catch ex As Exception

        End Try

        Using w As New StreamWriter(Path)
            w.Write(buffer)
        End Using

        Return ris
    End Function

    Private Shared Function GetTab(TabLevel As Integer) As String
        Dim ris As String = String.Empty
        If TabLevel Then
            For i As Integer = 1 To TabLevel
                ris &= ControlChars.Tab
            Next
        End If
        Return ris
    End Function

    Public Shared Function GetSerializeBuffer(Obj As Object,
                                               Optional TabLevel As Integer = 0) As String

        Dim ris As String = String.Empty

        Dim objType As Type = Obj.GetType()
        ris &= GetTab(TabLevel) & "<" & objType.Name & ">" & ControlChars.NewLine

        For Each P As System.Reflection.PropertyInfo In Obj.GetType.GetProperties
            Try
                Dim PropValue As Object = P.GetValue(Obj, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
                ris &= GetTab(TabLevel + 1) & "<" & P.Name & ">"
                If TypeOf (PropValue) Is IEnumerable(Of Object) Then
                    ris &= ControlChars.NewLine
                    For Each SingO In PropValue
                        ris &= GetSerializeBuffer(SingO, TabLevel + 1) & ControlChars.NewLine
                    Next
                    ris &= GetTab(TabLevel + 1) & "</" & P.Name & ">" & ControlChars.NewLine
                Else
                    ris &= PropValue.ToString() & "</" & P.Name & ">" & ControlChars.NewLine
                End If
            Catch ex As Exception

            End Try
        Next
        ris &= GetTab(TabLevel) & "</" & objType.Name & ">" & ControlChars.NewLine
        Return ris

    End Function

End Class
