Imports System.Reflection
Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class MgrRegoleCalcolo

    Private Const _PESO_CostoOrdine As Integer = 5
    Private Const _PESO_PercentualeCompletamento As Integer = 30 '2
    Private Const _PESO_ConPiuOrdiniTiratiAlGiusto As Integer = 30 '2
    Private Const _PESO_NumeroOrdineContenutiMaggiore As Integer = 30
    Private Const _PESO_NumeroFormatiContenutiMaggiore As Integer = 30
    Private Const _PESO_AreaStampataMaggiore As Integer = 30
    Private Const _PESO_NumeroSpaziContenutiNelModelloCommessaMaggiore As Integer = 5
    Private Const _PESO_TotaleUrgenzaMaggiore As Integer = 30 '2
    Private Const _PESO_NumeroClientiContenutiMinore As Integer = 10
    Private Const _PESO_TiraturaOttimale As Integer = 30
    Private Const _PESO_MacchinarioIdealePerProdotto As Integer = 60

    Private Shared Function GetKey(M As MethodBase) As String
        Dim ris As String = String.Empty
        Dim t As Type = M.DeclaringType
        ris = M.Name.Substring(4)
        Return ris
    End Function

    Public Shared ReadOnly Property PESO_CostoOrdine As Integer
        Get
            Dim ris As Integer = _PESO_CostoOrdine

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_PercentualeCompletamento As Integer
        Get
            Dim ris As Integer = _PESO_PercentualeCompletamento

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_ConPiuOrdiniTiratiAlGiusto As Integer
        Get
            Dim ris As Integer = _PESO_ConPiuOrdiniTiratiAlGiusto

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_NumeroOrdineContenutiMaggiore As Integer
        Get
            Dim ris As Integer = _PESO_NumeroOrdineContenutiMaggiore

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_NumeroFormatiContenutiMaggiore As Integer
        Get
            Dim ris As Integer = _PESO_NumeroFormatiContenutiMaggiore

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_AreaStampataMaggiore As Integer
        Get
            Dim ris As Integer = _PESO_AreaStampataMaggiore

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_NumeroSpaziContenutiNelModelloCommessaMaggiore As Integer
        Get
            Dim ris As Integer = _PESO_NumeroSpaziContenutiNelModelloCommessaMaggiore

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_TotaleUrgenzaMaggiore As Integer
        Get
            Dim ris As Integer = _PESO_TotaleUrgenzaMaggiore

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_NumeroClientiContenutiMinore As Integer
        Get
            Dim ris As Integer = _PESO_NumeroClientiContenutiMinore

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_TiraturaOttimale As Integer
        Get
            Dim ris As Integer = _PESO_TiraturaOttimale

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared ReadOnly Property PESO_MacchinarioIdealePerProdotto As Integer
        Get
            Dim ris As Integer = _PESO_MacchinarioIdealePerProdotto

            Using Mgr As New RegoleCalcoloDAO
                Dim l As List(Of RegolaCalcolo) = Mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", GetKey(MethodInfo.GetCurrentMethod())),
                                                              New LUNA.LunaSearchParameter("Stato", enStato.Attivo))
                If l.Count Then
                    Using R As RegolaCalcolo = l(0)
                        ris = R.Valore
                    End Using
                End If
            End Using

            Return ris
        End Get
    End Property

    Public Shared Function ExistRegola(O As OrdineInSoluzione,
                                       ChiaveRegola As String) As Boolean
        Dim ris As Boolean = False
        'qui controllo se esiste una regola e se l'ordine la soddisfa
        Select Case ChiaveRegola
            Case ChiaveRegolaUtente.OkConQtaSuperioreA
                'qui controllo se per questo tipo di ordine esiste una regola che per una data quantita va bene tutto
                Using mgr As New RegoleCalcoloDAO
                    Dim l As List(Of RegolaCalcolo) = mgr.FindAll(New LUNA.LunaSearchParameter("Chiave", ChiaveRegola),
                                                                  New LUNA.LunaSearchParameter("Stato", enStato.Attivo),
                                                                  New LUNA.LunaSearchParameter("IdListinoBase", "(0," & O.Ordine.IdListinoBase & ")", "IN"))

                    For Each R As RegolaCalcolo In l
                        If O.QtaOrdine >= R.Valore Then
                            ris = True
                            Exit For
                        End If
                    Next
                End Using

        End Select
        Return ris
    End Function

    Public Class ChiaveRegolaUtente
        Public Shared ReadOnly Property OkConQtaSuperioreA As String = "OkConQtaSuperioreA"

    End Class

    Public Class ExtraData
        Public Shared ReadOnly Property ForzaMacchinarioA As String = "ForzaMacchinarioA"
    End Class

End Class
