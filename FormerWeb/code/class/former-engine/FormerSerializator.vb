Imports FormerDALWeb
Public Class FormerSerializator

    Public Shared Function GetSerializeBuffer(Obj) As String

        Dim ris As String = String.Empty

        Dim objType As Type = Obj.GetType()
        ris &= "<" & objType.Name & ">" & ControlChars.NewLine

        For Each P As System.Reflection.PropertyInfo In Obj.GetType.GetProperties
            Try
                Dim PropValue As Object = P.GetValue(Obj, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
                ris &= "<" & P.Name & ">"
                If TypeOf (PropValue) Is IEnumerable(Of LUNA.LunaBaseClassEntity) Then
                    For Each SingO In PropValue
                        ris &= ControlChars.NewLine & GetSerializeBuffer(SingO) & ControlChars.NewLine
                    Next
                Else
                    ris &= PropValue.ToString()
                End If
                ris &= "</" & P.Name & ">" & ControlChars.NewLine
            Catch ex As Exception

            End Try
        Next
        ris &= "</" & objType.Name & ">" & ControlChars.NewLine
        Return ris

    End Function

End Class
