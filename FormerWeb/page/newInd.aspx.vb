Imports FormerDALWeb
Imports FormerLib

Public Class pnewInd
    Inherits FormerSecurePage
    Private PathArrivo As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CaricaNazioni()
            If Not Request.UrlReferrer Is Nothing Then
                Dim PathArrivo As String = Request.UrlReferrer.AbsolutePath
                ViewState.Add("PathArrivo", PathArrivo)

            End If

        End If

    End Sub

    Private Sub CaricaNazioni()
        Dim l As List(Of Nazione)
        l = MgrNazioni.GetLista

        ddlNazione.DataSource = l
        ddlNazione.DataValueField = LFM.Nazione.IdNazione.Name
        ddlNazione.DataTextField = LFM.Nazione.Nazione.Name
        ddlNazione.DataBind()
    End Sub

    Private Sub SalvaIndirizzo()
        If ModuloValido() Then
            pnlErrore.Visible = False

            Using ComuneScelto As New ComuneInElenco
                If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
                    ComuneScelto.Read(ddlCitta.SelectedValue)
                End If

                Using indirizzo As New Indirizzo
                    indirizzo.IdUt = UtenteConnesso.IdUtente
                    'indirizzo.IdComune = ddlCitta.SelectedValue
                    'indirizzo.Cap = txtCAP.Text
                    'indirizzo.Citta = ComuneScelto.Comune
                    'indirizzo.IdProvincia = ComuneScelto.ProvinciaSel.ID
                    indirizzo.Indirizzo = txtIndirizzo.Text
                    indirizzo.Nome = txtNome.Text
                    indirizzo.Destinatario = txtDestinatario.Text
                    indirizzo.Telefono = txtTelefono.Text
                    indirizzo.IdNazione = ddlNazione.SelectedValue

                    If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
                        indirizzo.IdComune = ComuneScelto.IDCap
                        indirizzo.IdProvincia = ComuneScelto.ProvinciaSel.ID
                        'indirizzo.Provincia = ComuneScelto.Provincia
                        indirizzo.Citta = ComuneScelto.Comune
                        indirizzo.Cap = txtCAP.Text
                    Else
                        indirizzo.Cap = FormerConst.Culture.CapEstero
                        indirizzo.Citta = txtLocalita.Text
                    End If

                    indirizzo.Save()
                End Using
            End Using
            Dim UrlRef As String = "/indirizzi-spedizione"

            If Not ViewState("PathArrivo") Is Nothing Then

                UrlRef = ViewState("PathArrivo")

            End If

            Response.Redirect(UrlRef)
        Else
            pnlErrore.Visible = True
        End If
    End Sub
    Private Function ModuloValido() As Boolean
        Dim ris As Boolean = True

        If txtNome.Text.Trim.Length < 2 Then
            ris = False
        End If

        If txtDestinatario.Text.Trim.Length = 0 Then
            ris = False
        End If

        If txtNome.Text.Trim.Length = 0 Then
            ris = False
        End If

        If txtIndirizzo.Text.Trim.Length = 0 Then
            ris = False
        End If

        If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
            If txtCAP.Text.Trim.Length = 0 Then
                ris = False
            ElseIf Not IsNumeric(txtCAP.Text) Then
                ris = False
            End If

            If ddlCitta.Items.Count <> 0 AndAlso ddlCitta.SelectedValue = 0 Then
                ris = False
            ElseIf ddlCitta.Items.Count = 0 Then
                ris = False
            End If
        Else
            If txtLocalita.Text.Trim.Length = 0 Then
                ris = False
            End If
        End If



        Return ris
    End Function

    Private Sub txtCAP_TextChanged(sender As Object, e As EventArgs) Handles txtCAP.TextChanged

        If txtCAP.Text.Trim.Length = 5 Then
            'qui ho 5 caratteri, se sono tutti numeri provo a cercare le localita e il resto
            Dim CapScelto As String = txtCAP.Text
            If IsNumeric(CapScelto) Then
                If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
                    CaricaLocalita(CapScelto)
                End If
            End If
        End If

    End Sub

    Private Sub CaricaLocalita(Cap As String)
        Dim IdComune As Integer = 0
        Using Mgr As New ElencoComuniDAO
            Dim l As List(Of ComuneInElenco) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Comune", .AddEmptyItem = True}, New LUNA.LunaSearchParameter("CAP", Cap))
            If l.Count Then
                ddlCitta.DataTextField = "Riassunto"
                ddlCitta.DataValueField = "IdCap"
                ddlCitta.DataSource = l
                ddlCitta.DataBind()
            Else
                ddlCitta.Items.Clear()
            End If
        End Using
    End Sub

    Private Sub lnkSave_Click(sender As Object, e As EventArgs) Handles lnkSave.Click
        SalvaIndirizzo()
    End Sub


    Private Sub HlnkFermoDeposito_Click(sender As Object, e As EventArgs) Handles HlnkFermoDeposito.Click

        txtIndirizzo.Text = "FERMO DEPOSITO"
        txtNome.Text = "FERMO DEPOSITO"
        txtIndirizzo.Enabled = False
        txtNome.Enabled = False

    End Sub

    Private Sub ddlNazione_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlNazione.SelectedIndexChanged

        txtCAP.Text = String.Empty
        txtLocalita.Text = String.Empty
        ddlCitta.DataSource = Nothing
        ddlCitta.DataBind()

        If ddlNazione.SelectedValue = FormerConst.Culture.IdItalia Then
            pnlLocalitaIT.Visible = True
            pnlLocalitaNonIT.Visible = False
        Else
            pnlLocalitaIT.Visible = False
            pnlLocalitaNonIT.Visible = True
        End If

        'txtPrefisso.Text = MgrNazioni.GetLista().Find(Function(x) x.IdNazione = ddlNazione.SelectedValue).Code

    End Sub
End Class