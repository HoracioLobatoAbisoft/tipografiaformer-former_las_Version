Imports System.IO
Imports FormerConfig
Imports FormerDALSql

Public Class MgrOrdiniAcquisto

    Public Shared Sub Stampa(O As OrdineAcquisto)

        Dim Buffer As String = String.Empty

        Buffer &= "<h2>Ordine di acquisto</h2>"
        Buffer &= "Ordine effettuato da <b>" & O.OperatoreStr & "</b> il <b>" & O.DataMov & "</b><br><br>"

        Dim IdlastForn As Integer = 0

        For Each R As MovimentoMagazzino In O.Richieste
            If R.IdForn <> IdlastForn Then
                Buffer &= "<h3>" & R.FornitoreStr & "</h3>"
                IdlastForn = R.IdForn
            End If
            Buffer &= "<li>" & R.Riassunto
        Next

        Dim Path As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".htm")

        Using w As New StreamWriter(Path)
            w.Write(Buffer)
        End Using

        Using f As New frmStampa
            f.Carica(Path)
        End Using

    End Sub

End Class
