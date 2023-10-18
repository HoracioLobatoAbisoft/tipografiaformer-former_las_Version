#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_pagamenti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Pagamento
    Inherits _Pagamento
    Implements IPagamento

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"

    Private _TipoPagamento As TipoPagamento = Nothing
    Public ReadOnly Property TipoPagamento As TipoPagamento
        Get
            If _TipoPagamento Is Nothing Then
                If IdTipoPagamento Then
                    _TipoPagamento = New TipoPagamento
                    _TipoPagamento.Read(IdTipoPagamento)
                End If
            End If
            Return _TipoPagamento
        End Get
    End Property

    Public Overrides Property Importo() As Decimal
        Get
            Return FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(MyBase.Importo, 2)
        End Get
        Set(value As Decimal)
            MyBase.Importo = value
        End Set
    End Property

    Public ReadOnly Property DescrizioneDocumento As String
        Get
            Dim ris As String = String.Empty

            If Tipo = enTipoVoceContab.VoceAcquisto Then
                Using voce As New Costo
                    voce.Read(IdFat)
                    ris = voce.Descrizione
                End Using

            ElseIf Tipo = enTipoVoceContab.VoceVendita Then
                Using voce As New Ricavo
                    voce.Read(IdFat)
                    ris = voce.Descrizione.Replace("Documento ordini:", String.Empty)
                End Using
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoPagamentoStr As String
        Get
            Dim ris As String = "-"
            If Not TipoPagamento Is Nothing Then
                ris = TipoPagamento.TipoPagam
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property RiferitoA As String
        Get
            Dim ris As String = String.Empty

            If Tipo = enTipoVoceContab.VoceAcquisto Then
                Using voce As New Costo
                    voce.Read(IdFat)
                    ris = voce.TipoStr
                End Using

            ElseIf Tipo = enTipoVoceContab.VoceVendita Then

                If IdFat Then
                    Using voce As New Ricavo
                        voce.Read(IdFat)
                        ris = voce.TipoStr
                    End Using
                ElseIf IdConsegna Then
                    ris = "Consegna"
                End If
            End If

            Return ris
        End Get
    End Property

    Private _CostoRif As Costo = Nothing
    Public ReadOnly Property CostoRif As Costo
        Get
            If _CostoRif Is Nothing Then
                If Tipo = enTipoVoceContab.VoceAcquisto Then
                    _CostoRif = New Costo
                    _CostoRif.Read(IdFat)
                End If
            End If
            Return _CostoRif
        End Get
    End Property

    Private _RicavoRif As Ricavo = Nothing
    Public ReadOnly Property RicavoRif As Ricavo
        Get
            If _RicavoRif Is Nothing Then
                If Tipo = enTipoVoceContab.VoceVendita AndAlso IdFat <> 0 Then
                    _RicavoRif = New Ricavo
                    _RicavoRif.Read(IdFat)
                End If
            End If
            Return _RicavoRif
        End Get
    End Property


    Private _ConsegnaRif As ConsegnaProgrammata = Nothing
    Public ReadOnly Property ConsegnaRif As ConsegnaProgrammata
        Get
            If _ConsegnaRif Is Nothing Then
                If IdConsegna Then
                    _ConsegnaRif = New ConsegnaProgrammata
                    _ConsegnaRif.Read(IdConsegna)
                End If
            End If
            Return _ConsegnaRif
        End Get
    End Property

    Public ReadOnly Property TipoDocStr As String
        Get
            Dim ris As String = String.Empty

            If Tipo = enTipoVoceContab.VoceAcquisto Then
                Using voce As New Costo
                    voce.Read(IdFat)
                    ris = voce.TipoDocStr
                End Using

            ElseIf Tipo = enTipoVoceContab.VoceVendita Then
                If IdFat Then
                    Using voce As New Ricavo
                        voce.Read(IdFat)
                        ris = voce.TipoDocStr
                    End Using
                ElseIf IdConsegna Then
                    ris = "ORDINE ONLINE " & IdConsegna
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property NumeroDocStr As String
        Get
            Dim ris As String = String.Empty

            If Tipo = enTipoVoceContab.VoceAcquisto Then
                Using voce As New Costo
                    voce.Read(IdFat)
                    ris = voce.Numero 'voce.AnnoStr & "-" & voce.Numero
                End Using

            ElseIf Tipo = enTipoVoceContab.VoceVendita Then
                If IdFat Then
                    Using voce As New Ricavo
                        voce.Read(IdFat)
                        ris = voce.AnnoRiferimento & "-" & voce.Numero
                    End Using
                ElseIf IdConsegna Then
                    ris = IdConsegna
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property ImportoStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Importo)
        End Get
    End Property

    Public ReadOnly Property ClienteNominativo As String
        Get
            Return Cliente.RagSocNome
        End Get
    End Property

    Private _Cliente As VoceRubrica = Nothing
    Public ReadOnly Property Cliente As VoceRubrica
        Get
            If _Cliente Is Nothing Then
                _Cliente = New VoceRubrica
                _Cliente.Read(IdRub)
            End If
            Return _Cliente
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IPagamento.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IPagamento.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IPagamento.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_pagamenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPagamento
    Inherits _IPagamento

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface