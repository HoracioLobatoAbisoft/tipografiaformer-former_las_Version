Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class FogliWizard
        Public Property IdPrev As Integer = 0

        Public Property IdColoriStampa As Integer = 0

        Public Property IdFormatoProdotto As Integer = 0

        Public Property IdTipoCarta As Integer = 0

        Public Property NFogli As Integer = 0

        Public Property NFogliVis As Integer = 0

        Public Property UrlPrecedente As String = String.Empty

        Public Property LabelFogli As String = String.Empty

        Public ReadOnly Property NomeInUrl As String
            Get
                Dim ris As String = String.Empty

                ris = NFogliVis & "_" & LabelFogli

                Return ris
            End Get
        End Property

        Public ReadOnly Property IsConsigliato As Boolean
            Get
                Dim ris As Boolean = False

                Return ris
            End Get
        End Property

        Public ReadOnly Property Descrizione As String
            Get
                Dim ris As String = String.Empty
                ris = NFogliVis & " " & LabelFogli

                Return ris
            End Get
        End Property

        Public Function GetImgListino() As String
            Dim ris As String = String.Empty

            ris = "/img/img" & LabelFogli & ".png"
            
            Return ris
        End Function

    End Class

End Namespace