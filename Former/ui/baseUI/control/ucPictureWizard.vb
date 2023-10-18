Public Class ucPictureWizard

    Public ReadOnly Property ParentFormEx As FormerLib.IFormWithSottofondo
        Get
            Return Me.ParentForm 'DirectCast(Me.ParentForm, baseFormInterna)
        End Get
    End Property

    Public Property PrefissoDaApplicare As String = String.Empty

    Private Sub lnkImporta_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkImporta.LinkClicked
        Dim Ris As String = String.Empty

        ParentFormEx.Sottofondo()
        Using f As New frmOpenIMG
            f.PrefissoDaApplicare = PrefissoDaApplicare
            Ris = f.Carica(ImgWidth, ImgHeight)
        End Using
        ParentFormEx.Sottofondo()

        If Ris.Length Then

            If Not RifTextBoxPath Is Nothing Then
                RifTextBoxPath.Text = Ris
            End If

            If Not RifPictureBox Is Nothing Then
                Try
                    RifPictureBox.Image = Image.FromFile(Ris)
                Catch ex As Exception

                End Try

            End If

        End If
    End Sub

    Public Property RifTextBoxPath As TextBox
    Public Property RifPictureBox As PictureBox

    Public Property ImgWidth As Integer = 128
    Public Property ImgHeight As Integer = 128

End Class
