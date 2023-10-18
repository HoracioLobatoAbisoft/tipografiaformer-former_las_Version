Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MotoreCalcoloSoluzioni

    Public Shared Event AggiornamentoStato(Messaggio As String)

    Private Shared Sub HandlerMotore(Messaggio As String)
        RaiseEvent AggiornamentoStato(Messaggio)
    End Sub

    Public Shared Function ProponiSoluzioni(ByVal listOrd As List(Of OrdineRicerca),
                                     ParamSoluzione As ParametriCreazioneSoluzione) As List(Of Soluzione)


        Dim ris As List(Of Soluzione) = Nothing

        If ParamSoluzione.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreStabile Then
            ris = MotoreCalcolo5.ProponiSoluzioni(listOrd, ParamSoluzione)
        ElseIf ParamSoluzione.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreBeta Then
            AddHandler MotoreCalcolo7.AggiornamentoStato, AddressOf HandlerMotore
            ris = MotoreCalcolo7.ProponiSoluzioni(listOrd, ParamSoluzione)
            RemoveHandler MotoreCalcolo7.AggiornamentoStato, AddressOf HandlerMotore
        End If

        Return ris

    End Function

End Class
