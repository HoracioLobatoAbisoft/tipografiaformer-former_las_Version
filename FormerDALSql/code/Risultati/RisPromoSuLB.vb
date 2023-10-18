Imports System.Drawing
Imports FormerLib.FormerEnum

Public Class RisPromoSuLB

    Public Sub New()

    End Sub

    Public Sub New(Lb As ListinoBase)
        _ListinoBase = Lb
        IdListinoBase = _ListinoBase.IdListinoBase
    End Sub
    Public ReadOnly Property StatoPromoAutomaticoStr As String
        Get
            Return ListinoBase.StatoPromoAutomaticoStr
        End Get
    End Property
    Public ReadOnly Property CounterDayPromo As Integer
        Get
            Return ListinoBase.CounterDayPromo
        End Get
    End Property

    Public ReadOnly Property ListinoBaseStr As String
        Get
            Return ListinoBase.NomeEx
        End Get
    End Property

    Private _PubblicatoStr As String = String.Empty
    Public ReadOnly Property PubblicatoStr As String
        Get
            If _PubblicatoStr = String.Empty Then
                Using Mgr As New PromoDAO
                    Dim l As List(Of Promo) = Mgr.FindAll(New LUNA.LSP(LFM.Promo.Automatico, enSiNo.Si),
                                                      New LUNA.LSP(LFM.Promo.Stato, enStato.Attivo),
                                                      New LUNA.LSP(LFM.Promo.IdListinoBase, IdListinoBase))

                    If l.Count Then
                        _PubblicatoStr = "SI"
                    Else
                        _PubblicatoStr = "No"
                    End If

                End Using

            End If

            Return _PubblicatoStr
        End Get
    End Property

    Public ReadOnly Property ImgRif As Image
        Get
            Dim Ris As Image = Nothing
            If IdListinoBase Then

                Select Case ListinoBase.PrendiIcoDa
                    Case enPrendiIcoDa.Preventivazione
                        Ris = ListinoBase.Preventivazione.Img
                    Case enPrendiIcoDa.FormatoProdotto
                        Ris = ListinoBase.ImgFp48
                    Case enPrendiIcoDa.ColoreDiStampa
                        Ris = ListinoBase.ImgCs48
                    Case enPrendiIcoDa.TipoCarta
                        Ris = ListinoBase.ImgTc48
                End Select
            End If

            'If Ris Is Nothing Then Ris = New Bitmap(My.Resources.no_image, 75, 50)

            Return Ris
        End Get
    End Property
    Public Property IdListinoBase As Integer = 0

    Public Property FatturatoMensileTotale As Decimal = 0
    Public Property FatturatoMensileConPromo As Decimal = 0

    Private _ListinoBase As ListinoBase = Nothing
    Public ReadOnly Property ListinoBase As ListinoBase
        Get
            If _ListinoBase Is Nothing Then
                _ListinoBase = New ListinoBase
                _ListinoBase.Read(IdListinoBase)
            End If
            Return _ListinoBase
        End Get
    End Property

    Public ReadOnly Property PercPromo As Integer
        Get
            Dim ris As Integer = 0

            ris = ListinoBase.PercPromoAutomatico

            Return ris
        End Get
    End Property

    Public ReadOnly Property PercLimite As Integer
        Get
            Dim ris As Integer = 0

            ris = ListinoBase.PercMaxPromoFatturato

            Return ris
        End Get
    End Property


    Public ReadOnly Property PercentualeSuFatturato As Single
        Get
            Dim ris As Single = 0

            Try
                ris = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((FatturatoMensileConPromo * 100) / FatturatoMensileTotale, 2)
            Catch ex As Exception

            End Try


            Return ris
        End Get
    End Property

End Class
