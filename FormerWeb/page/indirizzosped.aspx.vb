Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface

Public Class pIndirizzoSpedizione
    Inherits FormerSecurePage

    Private Sub CaricaCorriere()

        'Dim L As List(Of CorriereW) = Nothing
        'Using C As New CorrieriWDAO
        '    L = C.FindAll("IdCorriere", New LUNA.LunaSearchParameter("DisponibileOnline", 1))

        'End Using

        'For Each Corr As CorriereW In L

        '    Dim singC As New ListItem

        '    Dim Descr As String = "<b class=""blue"">" & Corr.Descrizione.ToUpper & "</b>, <i style=""font-size:10px;"">" & Corr.Label & "</i>;"

        '    singC.Text = Descr
        '    singC.Value = Corr.IdCorriere
        '    If UtenteConnesso.Utente.IdCorriereDef = Corr.IdCorriere Then
        '        singC.Selected = True

        '    End If
        '    rdoCorr.Items.Add(singC)
        'Next

        'lblCorrPred.Text = UtenteConnesso.Utente.Corriere.Descrizione

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

                Dim Descr As String = "<b class=""blue"">" & Corr.Descrizione.ToUpper & "</b>, <i style=""font-size:10px;"">" & Corr.Label & "</i>;"

                singC.Text = Descr
                singC.Value = Corr.IdMetodoConsegna
                If UtenteConnesso.Utente.IdCorriereDef = Corr.IdMetodoConsegna Then
                    singC.Selected = True

                End If
                rdoCorr.Items.Add(singC)
            End If
        Next

        lblCorrPred.Text = UtenteConnesso.Utente.Corriere.Descrizione


    End Sub

    Private Sub myFormer_Load(sender As Object, e As EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Indirizzi e Corriere"
        If Not IsPostBack Then
            CaricaCorriere()
            CaricaIndirizzi()
        End If

    End Sub

    Private Sub CaricaIndirizzi()

        Using Mgr As New IndirizziDAO

            'qui creo un indirizzo con quello messo in registrazione
            Dim TrovatoPredef As Boolean = False

            Dim lst As List(Of Indirizzo) = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "citta"},
                                                     New LUNA.LunaSearchParameter(LFM.Indirizzo.IdUt, UtenteConnesso.IdUtente),
                                                     New LUNA.LunaSearchParameter(LFM.Indirizzo.Status, CInt(enStato.Attivo)))

            If Not lst.Find(Function(x) x.Predefinito = True) Is Nothing Then
                TrovatoPredef = True
            End If

            Dim IBase As New Indirizzo

            IBase.IdIndirizzo = 0
            If UtenteConnesso.Utente.TipoRub = enTipoRubrica.Cliente Then
                IBase.Nome = "Principale"
            Else
                IBase.Nome = "Sede Legale"
            End If
            IBase.IdProvincia = UtenteConnesso.Utente.IdProvincia
            IBase.IdComune = UtenteConnesso.Utente.IdComune
            IBase.Cap = UtenteConnesso.Utente.Cap
            IBase.Citta = UtenteConnesso.Utente.Citta
            IBase.Destinatario = UtenteConnesso.Nominativo
            IBase.Indirizzo = UtenteConnesso.Utente.Indirizzo
            IBase.Predefinito = Not TrovatoPredef
            IBase.IdNazione = UtenteConnesso.Utente.IdNazione

            lst.Add(IBase)

            lst.Sort(Function(x, y) y.Predefinito.CompareTo(x.Predefinito))

            rptInd.DataSource = lst

            rptInd.DataBind()
        End Using
    End Sub

    Private Sub SalvaSpedizioneDefault()
        'UtenteConnesso.Utente.IndirizzoSped = txtIndirizzo.Text
        'UtenteConnesso.Utente.CittaSped = txtCitta.Text
        'UtenteConnesso.Utente.CapSped = txtCap.Text

        UtenteConnesso.Utente.IdCorriereDef = rdoCorr.SelectedValue
        'UtenteConnesso.Utente.LastUpdate = Now
        UtenteConnesso.Utente.Save()
        Response.Redirect("/indirizzi-spedizione")
    End Sub

    Private Sub rptInd_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptInd.ItemCommand
        Dim Indirizzi As New IndirizziDAO
        Dim IdIndirizzo = e.CommandArgument
        Select Case e.CommandName
            Case "DelInd"
                Indirizzi.EliminaIndirizzo(UtenteConnesso.IdUtente, IdIndirizzo)
            Case "Pred"
                Indirizzi.RendiPredefinito(UtenteConnesso.IdUtente, IdIndirizzo)
            Case "AnnP"
                Indirizzi.RendiPredefinito(UtenteConnesso.IdUtente, 0)
        End Select
        Response.Redirect("/indirizzi-spedizione")
    End Sub

    Private Sub lnkModCorriere_Click(sender As Object, e As EventArgs) Handles lnkModCorriere.Click
        SalvaSpedizioneDefault()
    End Sub

End Class