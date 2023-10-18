Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ituoipreventivi
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'qui devo caricare solo i coupon in corso di validita sia riservati che pubblici con il totale di volte usabili e il totale di volte gia usati



        End If

    End Sub


End Class