#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.11.31 
'Author: Diego Lunadei
'Date: 05/05/2016 
#End Region

Imports System.Data.Common
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table T_azionisottoscorta
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class AzioniSottoscortaDAO
    Inherits _AzioniSottoscortaDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function ApplicaRegolaSottoscorta(R As AzioneSottoscorta) As Integer
        Dim ris As Integer = 0
        Try
            'Applico la regola sottoscorta
            If R.Azione = enAzioneSottoScorta.RichiestaDiAcquisto Then
                'qui devo controllare che non ci sia gia una richiesta di acquisto attiva per questa risorsa



                'Using m As New Messaggio
                '    m.DataIns = Now
                '    m.Titolo = "Sottoscorta raggiunto per " & R.Risorsa.Descrizione
                '    m.Testo = "La risorsa " & R.Risorsa.Descrizione & " ha una giacenza attuale di " & R.Risorsa.Giacenza & " con una giacenza minima impostata a " & R.Risorsa.GiacenzaMin
                '    m.TipoMsg = enTipoMessaggio.Automatico
                '    m.IdMitt = 0
                '    m.IdDest = R.IdDestMessaggio
                '    m.Save()
                'End Using

            ElseIf R.Azione = enAzioneSottoScorta.RiOrdina Then

                'Using O As New Ordine

                'End Using

            End If
        Catch ex As Exception
            ris = 1
        End Try

        Return ris
    End Function

End Class