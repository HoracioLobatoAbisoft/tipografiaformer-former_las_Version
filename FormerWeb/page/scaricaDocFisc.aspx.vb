Imports FormerLib
Imports FormerDALWeb
Imports System.IO

Public Class pScaricaDocFisc
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim FileTrovato As Boolean = False
        Dim PathFisico As String = String.Empty
        Dim NomeFile As String = String.Empty

        Try
            Dim Chiave As String = Convert.ToString(Page.RouteData.Values("chiave"))
            Dim IdConsegnaInt As Integer = FormerLib.FormerHelper.Security.DecriptaID(Chiave)

            If IdConsegnaInt Then

                Dim C As Consegna = Nothing

                Using mgr As New ConsegneDAO
                    C = mgr.Find(New LUNA.LunaSearchParameter(LFM.Consegna.IdConsegnaInt, IdConsegnaInt))
                End Using

                If Not C Is Nothing Then

                    'qui prendo l'id della consegna online 
                    pathfisico = FormerWebApp.PathConsegne & C.IdConsegna & "\"
                    Dim Dire As New DirectoryInfo(PathFisico)
                    Dim lF As FileInfo() = Dire.GetFiles("*.pdf")

                    'prendo il primo file se c'e'
                    If lF.Length Then
                        NomeFile = lF(0).Name
                        PathFisico &= NomeFile
                        FileTrovato = True
                    End If

                End If

                'Response.Write(IdConsegnaInt)
            End If

        Catch ex As Exception

        End Try

        If FileTrovato Then
            Response.ContentType = "application/pdf"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" & NomeFile)
            Response.TransmitFile(PathFisico)
            Response.End()
        Else
            Response.Redirect("/")
        End If

    End Sub

End Class