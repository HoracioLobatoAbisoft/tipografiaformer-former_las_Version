Imports FormerLib.FormerEnum

Public Class MgrLogOperativi

    Public Shared Sub ScriviVoceLog(TipoLog As enTipoVoceLog,
                                IdRif As Integer,
                                Testo As String,
                                Optional IdOperatore As Integer = 0)

        Dim Chiamata1 As String = String.Empty
        Dim Chiamata2 As String = String.Empty

        Try
            Dim stackTrace As New Diagnostics.StackTrace
            Dim f As StackFrame = stackTrace.GetFrames(2)
            Dim m As System.Reflection.MethodBase = f.GetMethod
            Chiamata2 = m.ReflectedType.FullName & "." & m.Name

            'provo a prendere la chiamata anche prima

            Dim fPr As StackFrame = stackTrace.GetFrames(3)
            Dim mPr As System.Reflection.MethodBase = fPr.GetMethod
            Chiamata1 = mPr.ReflectedType.FullName & "." & mPr.Name
        Catch ex As Exception

        End Try

        Using v As New LogOperativo

            v.IdRif = IdRif
            v.Quando = Now
            v.TipoLog = TipoLog
            v.IdOperatore = IdOperatore
            v.Buffer = Testo
            v.Chiamata1 = Chiamata1
            v.Chiamata2 = Chiamata2
            v.Save()

        End Using

    End Sub
End Class
