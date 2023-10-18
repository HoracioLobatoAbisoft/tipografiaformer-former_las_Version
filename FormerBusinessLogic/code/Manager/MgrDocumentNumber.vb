Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class MgrDocumentNumber

    Public Shared Function GetNextNumber(IdAzienda As Integer,
                                         TipoDoc As enTipoDocumento) As Integer

        Dim NumeroDoc As Integer = 0
        Using mRic As New RicaviDAO
            NumeroDoc = mRic.GetNextNumeroDoc(IdAzienda, TipoDoc, 0)
        End Using
        Return NumeroDoc

    End Function

    Public Shared Function GetNextNumberByYear(IdAzienda As Integer,
                                               TipoDoc As enTipoDocumento, Anno As Integer) As Integer

        Dim NumeroDoc As Integer = 0
        Using mRic As New RicaviDAO
            NumeroDoc = mRic.GetNextNumeroDoc(IdAzienda, TipoDoc, Anno)
        End Using
        Return NumeroDoc

    End Function

    Public Shared Function GetNumberError(Optional AnnoRif As Integer = 0) As String
        Dim ris As String = String.Empty

        Using mgr As New RicaviDAO

            Dim pAnno As LUNA.LunaSearchParameter = Nothing

            If AnnoRif Then
                pAnno = New LUNA.LunaSearchParameter("Year(dataricavo)", AnnoRif)
            End If

            For j As Integer = 1 To 2
                Dim IdAzienda As Integer = j
                Dim BufferAzienda As String = String.Empty

                Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Year(dataricavo) DESC,numero DESC"},
                                                                   New LUNA.LunaSearchParameter(LFM.Ricavo.IdAzienda, IdAzienda),
                                                                   pAnno,
                                                                   New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.NotaDiCredito & "," & enTipoDocumento.FatturaRiepilogativa & ")", "IN"))

                Dim Differenza As Integer = 0
                Dim LastNum As Integer = 0
                Dim LastYear As Integer = 0

                For Each R As Ricavo In l
                    If LastYear <> R.DataRicavo.Year Then
                        LastNum = 0
                        LastYear = R.DataRicavo.Year
                    End If

                    If LastNum = 0 Then
                        LastNum = R.Numero
                    Else
                        Differenza = LastNum - R.Numero

                        If Differenza = 0 Then
                            'numero duplicato
                            BufferAzienda &= "NUMERO DUPLICATO: " & R.DataRicavo.Year & "-" & R.Numero & ControlChars.NewLine
                        ElseIf Differenza > 1 Then
                            'numero mancante 
                            For i = LastNum - 1 To R.Numero + 1 Step -1
                                BufferAzienda &= "NUMERO MANCANTE: " & R.DataRicavo.Year & "-" & i & ControlChars.NewLine
                            Next
                        End If
                        LastNum = R.Numero
                    End If
                Next
                If BufferAzienda.Length Then
                    Using a As New Azienda
                        a.Read(IdAzienda)
                        BufferAzienda = "***" & a.RagioneSociale & "***" & ControlChars.NewLine & BufferAzienda
                    End Using
                End If

                ris &= BufferAzienda
            Next

        End Using

        Return ris
    End Function

End Class
