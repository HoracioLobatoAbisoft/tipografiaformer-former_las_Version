#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 24/04/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient


''' <summary>
'''DAO Class for table T_coupon
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CouponDAO
	Inherits _CouponDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function GetCodiceCoupon(Optional PrefissoPrev As String = "", Optional IdUtente As Integer = 0) As String
        Dim Ris As String = String.Empty

        Dim Random As New Random
        Randomize()

        Do
            Dim ProxCoupon As Integer = Random.Next(1000, 9999999)
            Dim CodeToTry As String = ""

            If PrefissoPrev.Length Then
                CodeToTry = PrefissoPrev & "-"
            Else
                CodeToTry = "COUPON-"
            End If

            If IdUtente Then
                CodeToTry &= IdUtente & "-"
            End If

            CodeToTry &= ProxCoupon

            If Find(New LUNA.LunaSearchParameter("Codice", CodeToTry)) Is Nothing Then
                Ris = CodeToTry
            End If

        Loop Until Ris.Length > 0

        Return Ris
    End Function

End Class