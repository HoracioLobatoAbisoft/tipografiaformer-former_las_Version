Imports System.IO
Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class pFatture
    Inherits FormerSecurePage

    Private Sub myFormer_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim lF As New List(Of Consegna)

            Dim ListaAnni As String = String.Empty

            Dim Start As Integer = Now.Date.Year

            For i As Integer = Start To Start - 2 Step -1
                ListaAnni &= i & ","
            Next

            ListaAnni = "(" & ListaAnni.TrimEnd(",") & ")"

            'New LUNA.LunaSearchParameter("datediff(""d"",DataInserimento,GetDate())", 365, "<=")

            Using mgr As New ConsegneDAO
                'UtenteConnesso.IdUtente),
                Dim l As List(Of Consegna) = mgr.FindAll("DataInserimento Desc,Giorno Desc",
                                                     New LUNA.LunaSearchParameter(LFM.Consegna.IdUt, UtenteConnesso.IdUtente),
                                                     New LUNA.LunaSearchParameter("year(dataInserimento)", ListaAnni, "IN"),
                                                     New LUNA.LunaSearchParameter(LFM.Consegna.IdStatoConsegna, "(" & enStatoConsegna.InConsegna & "," & enStatoConsegna.Consegnata & ")", " IN "))

                l = l.FindAll(Function(x) x.ListaOrdini.Count > 0)

                For Each singCons As Consegna In l
                    'qui vedo se è presente il file pdf 
                    Dim Path As String = FormerWebApp.PathConsegne & singCons.IdConsegna & "\"

                    Dim Dire As New DirectoryInfo(Path)
                    If singCons.IdConsegnaInt Then
                        If Directory.Exists(Path) Then
                            Dim lFile As FileInfo() = Dire.GetFiles("*.pdf")
                            If lFile.Count Then
                                Dim F As FileInfo = lFile(0)
                                Dim PosizionePunto As Integer = F.Name.IndexOf(".")
                                Dim AnnoDocumento As Integer = F.Name.Substring(0, 4)
                                Dim NumeroDocumento As Integer = F.Name.Substring(5, PosizionePunto - 4)

                                singCons.Tag = NumeroDocumento & "-" & AnnoDocumento
                                lF.Add(singCons)
                            End If
                        End If
                    End If
                Next

            End Using

            If lF.Count = 0 Then lblNoFatture.Visible = True

            rptFatture.DataSource = lF
            rptFatture.DataBind()

        End If

    End Sub

    Private Sub rptFatture_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptFatture.ItemCommand
        If e.CommandName = "scarica" Then
            Dim path As String = "/scarica-documento-fiscale/" & FormerLib.FormerHelper.Security.CriptaID(e.CommandArgument)

            Response.Redirect(path)
        End If
    End Sub
End Class