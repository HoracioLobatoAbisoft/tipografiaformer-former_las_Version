#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 28/04/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum


''' <summary>
'''DAO Class for table T_coupon
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CouponWDAO
    Inherits _CouponWDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function CheckCoupon(CodiceCoupon As String) As Boolean
        Dim ris As Boolean = True

        If CodiceCoupon.Length Then
            If CodiceCoupon.IndexOf(" ") = -1 Then
                For Each c As String In CodiceCoupon
                    If Char.IsLetterOrDigit(c) = False AndAlso c <> "-" Then
                        ris = False
                    End If
                Next
            Else
                ris = False
            End If
        Else
            ris = False
        End If


        Return ris
    End Function

    Public Function GetCodiceCoupon(PrefissoPrev As String, IdUtente As Integer) As String
        Dim Ris As String = String.Empty

        Dim Random As New Random
        Randomize()

        Do
            Dim ProxCoupon As Integer = Random.Next(1000, 9999999)
            Dim CodeToTry As String = PrefissoPrev & "-" & IdUtente & "-" & ProxCoupon

            If Find(New LUNA.LunaSearchParameter("Codice", CodeToTry)) Is Nothing Then
                Ris = CodeToTry
            End If

        Loop Until Ris.Length > 0

        Return Ris
    End Function

    Public Function ListaCouponAttivi(IdUtenteConnesso As Integer,
                                      SoloSpecifici As Boolean) As List(Of CouponW)

        Dim ris As List(Of CouponW) = Nothing
        Dim risFinale As New List(Of CouponW)

        Dim ListaId As String = String.Empty

        If SoloSpecifici Then
            ListaId = "(" & IdUtenteConnesso & ")"
        Else
            ListaId = "(0," & IdUtenteConnesso & ")"
        End If

        ris = FindAll(New LUNA.LunaSearchParameter("Stato", enStato.Attivo),
                                                     New LUNA.LunaSearchParameter("datediff(""d"",DataInizioValidita,getdate())", 0, ">="),
                                                     New LUNA.LunaSearchParameter("datediff(""d"",DataFineValidita,getdate())", 0, "<="),
                                                     New LUNA.LunaSearchParameter("Riservato", ListaId, " IN "))
        'ris = GetData("SELECT  * FROM T_coupon WHERE Stato  =   0  and Riservato  IN  (0," & IdUtenteConnesso & ")")
        'ris = ris.FindAll(Function(x) x.DataInizioValidita <= Now.Date And x.DataFineValidita >= Now.Date)
        'ris = GetData("SELECT  * FROM T_coupon WHERE Stato  =   0  And datainiziovalidita <= getdate() and datafinevalidita >= getdate() and Riservato  IN  (0," & IdUtenteConnesso & ")")


        'MESSA PER PRENDERE IN CONSIDERAZIONE SOLO I COUPON CHE NON SONO STATI GIA UTILIZZATI
        For Each singCoupon As CouponW In ris
            Using mgr As New OrdiniWebDAO
                Dim l As List(Of OrdineWeb) = mgr.FindAll(New LUNA.LunaSearchParameter("IdCoupon", singCoupon.IdCoupon),
                                                          New LUNA.LunaSearchParameter("IdUt", IdUtenteConnesso))

                If l.Count = 0 Then
                    risFinale.Add(singCoupon)
                End If

            End Using
        Next

        Return risFinale

    End Function

    Public Function TotaleCouponUtilizzati(IdCoupon As Integer, IdUt As Integer) As Integer
        Dim ris As Integer = 0

        Using mgr As New CouponLogDAO
            Dim l As List(Of CouponLog) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CouponLog.IdUt, IdUt),
                                                       New LUNA.LunaSearchParameter(LFM.CouponLog.IdCoupon, IdCoupon))

            ris = l.Count
        End Using

        Return ris
    End Function

End Class