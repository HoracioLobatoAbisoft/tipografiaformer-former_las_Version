Imports System.IO
Imports System.Drawing

Public Class pGallery
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CaricaFoto()
        End If

    End Sub

    Private Sub CaricaFoto()

        Dim l As New List(Of imgGallery)
        Dim d As New DirectoryInfo("D:\lavoro\Former\FormerWeb\listino\foto")
        Dim dList As List(Of DirectoryInfo)

        dList = d.GetDirectories.ToList

        Dim LatoLungo As Integer = 240

        For Each singdir In dList
            For Each f As FileInfo In singdir.GetFiles
                Try
                    Dim Img As New imgGallery

                    Img.FullName = f.FullName
                    Img.Url = "/listino/foto/" & singdir.Name & "/" & f.Name

                    Using realImg As Image = Image.FromFile(f.FullName)
                        'If realImg.Width < realImg.Height Then
                        '    'stretta e lunga
                        '    Img.Height = LatoLungo
                        '    Img.Width = CInt((LatoLungo * realImg.Width) / realImg.Height)
                        'ElseIf realImg.Width > realImg.Height Then
                        'larga e bassa
                        Img.Height = CInt((LatoLungo * realImg.Height) / realImg.Width)
                        Img.Width = LatoLungo
                        'Else
                        ''quadrata
                        'Img.Height = LatoLungo
                        'Img.Width = LatoLungo
                        'End If
                    End Using

                    l.Add(Img)
                Catch ex As Exception

                End Try

            Next
        Next

        rptImg.DataSource = l
        rptImg.DataBind()

    End Sub

End Class