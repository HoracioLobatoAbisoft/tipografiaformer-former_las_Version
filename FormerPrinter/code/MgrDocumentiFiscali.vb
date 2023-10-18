Imports System.Windows.Forms
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrDocumentiFiscali
    Inherits FormerBusinessLogic.MgrDocumentiFiscali

    Public Shared Sub MessaggioModuloFattura(R As Ricavo,
                                             NumCopie As Integer)
        Dim MostraMessaggio As Boolean = False

        If MostraMessaggio Then
            If R.Tipo <> enTipoDocumento.Preventivo And R.IdAzienda = MgrAziende.IdAziende.AziendaSnc Then
                MessageBox.Show("Per la stampa del documento fiscale inserire " & NumCopie & " copie del modulo fattura " & MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSnc))
            End If
        End If

    End Sub
End Class
