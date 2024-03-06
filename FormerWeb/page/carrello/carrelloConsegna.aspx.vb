Imports FormerDALWeb
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

Public Class pCarrelloConsegna
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Carrello consegna"
        If UtenteConnesso.UtenteAutorizato Then

            Dim UrlProdottoEnviroment As String = UtenteConnesso.UrlIframe & "/carrelloStp3"
            Dim Eviroment As Boolean = UtenteConnesso.Eviroment

            'If Eviroment Then
            '    UrlProdottoEnviroment = "https://react.tipografiaformertest.it:6060/#/carrelloStp3"
            'Else
            '    UrlProdottoEnviroment = "http://localhost:5173/#/carrelloStp3"
            'End If

            IframecarreloStp3.Text = "<iframe id='carrelloStp3' style='width:100%; height: 100vh;border: none;' src=" & UrlProdottoEnviroment & " ></iframe>"
        Else
            If Carrello.Ordini.Count = 0 Then Response.Redirect("/carrello")

            If Not IsPostBack Then

                CaricaCorriere()
                CaricaIndirizzi()
                VisualizzaDataOrdini()
                VisualizzaInfoCorr()

                If Carrello.EmailTracciamento.Length Then txtTrace.Text = Carrello.EmailTracciamento

            End If
        End If




    End Sub

    Public Function lblOggiDomani() As String
        Dim ris As String = String.Empty

        If Now.Hour < 18 Then
            ris = "oggi"
        Else
            ris = "domani"
        End If

        Return ris
    End Function

    Public Function lblCountDown() As String
        Dim ris As String = String.Empty
        Dim DataRif As New Date(Now.Year, Now.Month, Now.Day, 18, 0, 0)

        If Now.Hour >= 18 Then DataRif = DataRif.AddDays(1)

        ris = DateDiff(DateInterval.Hour, Now, DataRif)

        If ris <> "0" Then
            ris &= " ore e "
        Else
            ris = ""
        End If

        ris &= (60 - Now.Minute) & " minuti"

        Return ris
    End Function

    Private Function GetCap() As String

        Dim ris As String = String.Empty

        If CInt(rdoCorr.SelectedValue) = enTipoCorriere.ConTariffa Then

            If ddlIndirizzo.SelectedValue Then
                Dim I As New Indirizzo
                I.Read(ddlIndirizzo.SelectedValue)
                ris = I.Cap
            Else
                ris = UtenteConnesso.Utente.Cap
            End If

        End If

        Return ris

    End Function

    Private Sub RicalcolaDataOrdini()
        'qui devo Calcolare la data 

        Dim LCorr As New List(Of ICorriereBusiness)
        Using mgrC As New CorrieriWDAO
            LCorr = mgrC.GetListaCorrieri
        End Using

        Dim CorrScelto As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(CInt(rdoCorr.SelectedValue))

        Dim I As New Indirizzo

        'qui ci va il cap selezionato 
        Dim C As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(CorrScelto, LCorr, GetCap, FormerWebApp.NonPrendereInConsiderazioneCorriereFormer)
        Dim CorrDaUsare As New CorriereW
        CorrDaUsare.Read(C.IdCorriere)

        For Each O As ProdottoInCarrello In Carrello.Ordini
            O.Corriere = CorrDaUsare
            Dim listaLavB As New List(Of ILavorazioneB)

            For Each L As LavorazioneW In O.LavorazioniIncluse
                listaLavB.Add(L)
            Next

            Dim DateConsegna As RisDataConsegna = MgrDataConsegna.CalcolaDateConsegna(O.P, C, listaLavB)
            Select Case O.TipoConsegna
                Case enTipoConsegna.Fast
                    O.Quando = "F" & DateConsegna.DataFast.ToString("ddMMyyyy")
                Case enTipoConsegna.Normale
                    O.Quando = "N" & DateConsegna.DataNormale.ToString("ddMMyyyy")
                Case enTipoConsegna.Slow
                    O.Quando = "S" & DateConsegna.DataSlow.ToString("ddMMyyyy")
            End Select

        Next

        VisualizzaDataOrdini()

    End Sub

    Private Sub CaricaCorriere()

        rdoCorr.Items.Clear()

        Dim l As List(Of MetodoConsegna) = MgrMetodiConsegna.Corrieri

        For Each Corr As MetodoConsegna In l
            Dim UsaCorriere As Boolean = True
            If Corr.OnlyAutorized Then
                If Corr.IdMetodoConsegna <> UtenteConnesso.Utente.IdCorriereDef Then
                    UsaCorriere = False
                End If
            End If
            If UsaCorriere Then
                Dim singC As New ListItem

                Dim Descr As String = "<div class=""TipoCorriere""><img src=""/img/pixel.gif""> <b style=""font-size:14px;"">" & Corr.Descrizione.ToUpper & "</b>, <br><i>" & Corr.Label & "</i>;</div>"

                singC.Text = Descr
                singC.Value = Corr.IdMetodoConsegna
                'If UtenteConnesso.Utente.IdCorriereDef = Corr.IdMetodoConsegna Then
            
                Dim IdModelloConsegnaScelto As Integer = Carrello.IdMetodoConsegnaScelto

                If IdModelloConsegnaScelto <> -1 Then
                    If IdModelloConsegnaScelto = Corr.IdMetodoConsegna Then
                        singC.Selected = True
                    End If

                Else
                    If UtenteConnesso.Utente.IdCorriereDef = Corr.IdMetodoConsegna Then
                        singC.Selected = True
                    End If
                End If

            rdoCorr.Items.Add(singC)
            End If
        Next

        'ddlCorriere.Attributes("onChange") = "SetQuandoDefault();"

    End Sub

    Private Sub CaricaIndirizzi()

        If CInt(rdoCorr.SelectedValue) = enTipoCorriere.ConTariffa Then
            pnlSelectIndirizzo.Visible = True
            pnlIndRitiro.Visible = False

            ddlIndirizzo.Items.Clear()

            Dim l As New ListItem
            Dim lst As List(Of Indirizzo) = Nothing

            Using Mgr As New IndirizziDAO
                lst = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "citta"}, _
                                                         New LUNA.LunaSearchParameter("Idut", UtenteConnesso.IdUtente), _
                                                         New LUNA.LunaSearchParameter("Status", CInt(enStato.Attivo)))
            End Using

            Dim PrimoInd As String = UtenteConnesso.Utente.Nominativo & ", " & UtenteConnesso.Utente.Indirizzo & " - " & UtenteConnesso.Utente.Cap & " " & UtenteConnesso.Utente.Citta & " (" & UtenteConnesso.Utente.Provincia & ")"

            If lst.Find(Function(x) x.Predefinito = True) Is Nothing Then
                PrimoInd &= " (predefinito)"
            End If

            l.Text = PrimoInd
            l.Value = 0

            ddlIndirizzo.Items.Add(l)

            For Each I As Indirizzo In lst
                l = New ListItem
                l.Text = I.Nome & ": " & I.Riassunto
                l.Value = I.IdIndirizzo

                If I.Predefinito Then
                    l.Text &= " (predefinito)"

                End If

                ddlIndirizzo.Items.Add(l)
            Next


            ddlIndirizzo.SelectedValue = Carrello.IdIndirizzoScelto
        Else
            pnlSelectIndirizzo.Visible = False
            pnlIndRitiro.Visible = True

        End If
    End Sub

    Private Sub VisualizzaDataOrdini()

        lblDataCons.Text = Carrello.DataConsegnaStr

    End Sub

    Private Sub rdoCorr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdoCorr.SelectedIndexChanged

        CaricaIndirizzi()
        RicalcolaDataOrdini()
        VisualizzaInfoCorr()

    End Sub

    Private Sub VisualizzaInfoCorr()
        Dim Ris As String = "(Peso complessivo " & Carrello.Peso & " kg &#177;)"

        If rdoCorr.SelectedValue = enTipoCorriere.ConTariffa Then
            'qui mostro anche chi e' il corriere che il programma decide di mandare

            Dim CorrScelto As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(CInt(rdoCorr.SelectedValue))

            Dim LCorr As New List(Of ICorriereBusiness)
            Using mgrC As New CorrieriWDAO
                LCorr = mgrC.GetListaCorrieri
            End Using

            'qui ci va il cap selezionato 
            Dim C As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(CorrScelto, LCorr, GetCap, FormerWebApp.NonPrendereInConsiderazioneCorriereFormer)
            Ris = "Il corriere che le consegnerà il suo ordine è <b>" & C.Descrizione & "</b> " & Ris
            If C.IdCorriere <> enCorriere.TipografiaFormer AndAlso C.IdCorriere <> enCorriere.TipografiaFormerFuoriRaccordo Then
                pnlTrace.Visible = True
            Else
                txtTrace.Text = String.Empty
                pnlTrace.Visible = False
            End If

        Else
            Ris = "La merce potrà essere ritirata presso la nostra sede di Roma " & Ris
            txtTrace.Text = String.Empty
            pnlTrace.Visible = False
        End If

        lblInfoCorr.Text = Ris

    End Sub

    Private Sub ddlIndirizzo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlIndirizzo.SelectedIndexChanged
        Carrello.IdIndirizzoScelto = ddlIndirizzo.SelectedValue
        RicalcolaDataOrdini()
        VisualizzaInfoCorr()
    End Sub

    Private Sub lnkMiaMail_Click(sender As Object, e As EventArgs) Handles lnkMiaMail.Click

        txtTrace.Text = UtenteConnesso.Utente.Email

    End Sub

    Private Sub btnScegliPagamento_Click(sender As Object, e As EventArgs) Handles btnScegliPagamento.Click

        Dim OkTrace As Boolean = True

        Dim EmailAddr As String = txtTrace.Text.Trim

        If EmailAddr.Length Then
            If FormerHelper.Mail.IsValidEmailAddress(txtTrace.Text) = False Then
                OkTrace = False
            End If
        End If

        If OkTrace Then

            Carrello.EmailTracciamento = EmailAddr
            Response.Redirect("/carrello-pagamento")
        Else
            lblErrEmail.Visible = True
        End If
        

    End Sub
End Class