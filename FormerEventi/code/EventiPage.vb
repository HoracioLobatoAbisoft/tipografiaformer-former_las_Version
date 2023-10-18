Public Class EventiPage
    Inherits System.Web.UI.Page

    Private Sub EventiPage_Load(sender As Object, e As EventArgs) Handles Me.Load

        'CHECK DATE
        Dim Val As String = ConfigurationManager.AppSettings("DataInizioEvento")
        Dim ValData() As String = Val.Split(".")
        Dim DataInizio As New Date(ValData(2), ValData(1), ValData(0))
        Val = ConfigurationManager.AppSettings("DataFineEvento")
        ValData = Val.Split(".")
        Dim DataFine As New Date(ValData(2), ValData(1), ValData(0))

        Dim GoHome As Boolean = False
        Dim Temp As Integer = DateDiff(DateInterval.Day, DataInizio, Now.Date)
        Dim Temp2 As Integer = DateDiff(DateInterval.Day, DataFine, Now.Date)

        If Temp < 0 OrElse Temp2 > 0 Then
            GoHome = True
        End If

        If GoHome Then
            Response.Redirect("https://www.tipografiaformer.it")
        End If

    End Sub
End Class
