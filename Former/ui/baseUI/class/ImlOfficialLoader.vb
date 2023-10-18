Imports System.Windows.Forms

Public Class ImlOfficialLoader

    Public Shared Sub Load(ByRef Iml As ImageList)

        '        Iml.Images.Add(My.Resources.checkmark1.ToString, My.Resources.checkmark1)
        Try

            If Iml.Images.Count = 0 Then
                Dim L As New List(Of DictionaryEntry)

                Using ResourceSet As Resources.ResourceSet = My.Resources.ResourceManager.GetResourceSet(Globalization.CultureInfo.CurrentCulture, True, True)
                    For Each Dict As DictionaryEntry In ResourceSet.OfType(Of Object)
                        If TypeOf (Dict.Value) Is Drawing.Image Then
                            If Dict.Key.ToString.StartsWith("_") Then
                                L.Add(Dict)
                            End If
                        End If
                    Next
                End Using

                'qui le ordino
                L.Sort(Function(x, y) x.Key.ToString.CompareTo(y.Key.ToString))
                For Each R In L
                    Iml.Images.Add(StrConv(R.Key.ToString.Substring(1), VbStrConv.ProperCase), R.Value)
                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

End Class
