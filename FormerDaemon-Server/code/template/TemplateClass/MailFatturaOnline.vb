Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class MailFatturaOnline

        Private _C As Consegna
        Public Property C As Consegna
            Get
                Return _C
            End Get
            Set(value As Consegna)
                _C = value
            End Set
        End Property

        Public Function GetUrlPDF() As String
            Dim ris As String = String.Empty

            ris = "https://www.tipografiaformer.it/scarica-documento-fiscale/" & FormerLib.FormerHelper.Security.CriptaID(C.IdConsegnaInt)

            Return ris
        End Function

    End Class

End Namespace
