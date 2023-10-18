
Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class OrdineInSoluzione
    Implements ICloneable

    Public Property NumeroOrdiniDaLavorareStessoIdRub As Integer = 0

    Private _SpaziUsati As Integer = 0
    Public ReadOnly Property SpaziUsati As Integer
        Get
            'If _SpaziUsati = 0 Then
            _SpaziUsati = QtaOrdine / TiratoA
            'End If
            Return _SpaziUsati
            'Dim ris As Integer = 0
            'If _SpaziUsati = 0 Then

            'TODO:RIMETTERE COME RIGA SUCCESSIVA
            'ris = Ordine.Qta / TiratoA
            'ris = QtaOrdine / TiratoA
            'End If
            'Return ris
        End Get
    End Property

    Public ReadOnly Property QtaOrdine As Integer
        Get
            Dim Ris As Integer = 1
            If Not Ordine Is Nothing Then
                If Not Ordine.Prodotto Is Nothing Then
                    Ris = Ordine.QtaOrdine 'Ordine.Prodotto.NumPezzi'MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO

                    'qui devo vedere nel caso dei blocchi e a sto punto anche delle riviste di beccare il numero giusto di pagine
                    Dim NFogli As Integer = Ordine.NFogli
                    If NFogli = 0 Then NFogli = 1
                    Ris = Ris * NFogli

                    'qui devo vedere se la carta è composta

                    If Ordine.ListinoBase.TipoCarta.TipoCarta = enTipoCarta.Composta Then
                        Dim NFogliCartaComposta As Integer = 0
                        For Each singTC As ComposizioneCarta In Ordine.ListinoBase.TipoCarta.ComposizioniCarta

                            NFogliCartaComposta += singTC.NumFogli

                        Next
                        'modifica fatta con Andrea per errore di calcolo nei blocchi di carta chimica
                        'Ris = Ris * NFogliCartaComposta

                    End If

                End If
            End If
            Return Ris
        End Get
    End Property
    Public ReadOnly Property IDTipoCartaRif As Integer
        Get
            Dim ris As Integer = 0
            If Ordine.ForzaIdTipoCarta Then
                ris = Ordine.ForzaIdTipoCarta
            Else
                ris = Ordine.ListinoBase.IdTipoCarta
            End If
            Return ris
        End Get
    End Property
    Public ReadOnly Property IDFormatoProdottoRif As Integer
        Get
            Dim ris As Integer = 0
            If Ordine.ForzaIdFormatoProdotto Then
                ris = Ordine.ForzaIdFormatoProdotto
            Else
                ris = Ordine.ListinoBase.IdFormProd
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property IDFormatoCartaRif As Integer
        Get
            Dim ris As Integer = Ordine.ListinoBase.FormatoProdotto.IdFormCarta

            If Ordine.ListinoBase.ForzatoIdFormCarta Then
                ris = Ordine.ListinoBase.ForzatoIdFormCarta
            End If

            Return ris
        End Get
    End Property

    Private _TiratoA As Integer = 0
    Public Property TiratoA As Integer
        Get
            Return _TiratoA
        End Get
        Set(value As Integer)
            _TiratoA = value
        End Set
    End Property

    Public Property Ordine As OrdineRicerca = Nothing

    Public Sub Rielabora(TiratoA As Integer)
        _TiratoA = TiratoA
        '_SpaziUsati = QtaOrdine / TiratoA
    End Sub

    Public ReadOnly Property Prioritario As Boolean
        Get
            Dim Ris As Boolean = False
            If Ordine.ConsegnaAssociata.Giorno <> Date.MinValue Then
                'Dim Interv As Integer = DateDiff(DateInterval.Day, Now.Date, Ordine.DataPrevConsegna.Date)
                Dim Interv As Integer = DateDiff(DateInterval.Day, Now.Date, Ordine.DataConsProgr.Date)
                If Interv < 2 Then
                    Ris = True
                End If
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property IdOrd As Integer
        Get
            Return Ordine.IdOrd
        End Get
    End Property

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class