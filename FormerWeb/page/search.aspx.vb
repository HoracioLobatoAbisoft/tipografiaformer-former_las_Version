Imports System.Data
Imports System.Web.Script.Services
Imports System.Web.Services
Imports FormerBusinessLogic
Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class search
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("PageTitle") = "Ricerca Avanzata"

    End Sub

    Private Sub btnCerca_Click(sender As Object, e As ImageClickEventArgs) Handles btnCerca.Click

        Dim Keywords As String = txtCerca.Text.Trim

        If Keywords.Length Then
            Keywords = FormerSearchEngine.EncryptRichiesta(Keywords)

            Dim richiesta As String = "/cerca/" & Keywords

            Response.Redirect(richiesta)
        End If


    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Xml)>
    Public Shared Function cercaFunction(ByVal userText As String) As String
        Dim ris As String = String.Empty
        Try

            'qui mi dovrebbe arrivare il cerca da parte dell'utente
            Dim valoreUtente As String = userText.ToLower.Trim 'HttpContext.Current.Server.HtmlEncode(userText)

            Using tb As DataTable = New DataTable("Table")
                tb.Columns.Add("descrizione")
                tb.Columns.Add("url")
                tb.Columns.Add("img")
                tb.Columns.Add("value")

                Using mgr As New ListinoBaseWDAO

                    'Dim StringaRicerca As String = "SELECT DISTINCT * from t_listinobase WHERE disattivo <>" & enSiNo.Si & " AND nascondionline <> " & enSiNo.Si & " AND nome LIKE '%" & valoreUtente & "%' OR descrsito LIKE '%" & valoreUtente & "%' " 'ORDER by nome"
                    'Dim l As List(Of ListinoBaseW) = mgr.GetBySQL(StringaRicerca)

                    Dim l As New List(Of ListinoBaseW)

                    l.AddRange(FormerWebApp.StaticListiniBase.FindAll(Function(x) x.Nome.ToLower.IndexOf(valoreUtente) <> -1 Or x.DescrSito.ToLower.IndexOf(valoreUtente) <> -1))

                    'Dim lInd As IEnumerable(Of IndiceRicerca) = FormerSearchEngine.Cerca(valoreUtente)

                    'For Each singris In lInd
                    '    Try
                    '        l.Add(FormerWebApp.StaticListiniBase.Find(Function(x) x.IdListinoBase = singris.IdListinoBase))
                    '    Catch ex As Exception

                    '    End Try
                    'Next

                    Dim lRis As New List(Of GenericWebObject)
                    Dim LIdPrev As New List(Of Integer)

                    For Each voce In l
                        If LIdPrev.FindAll(Function(x) x = voce.IdPrev).Count = 0 Then
                            If l.FindAll(Function(x) x.IdListinoBase <> voce.IdListinoBase And x.IdPrev = voce.IdPrev).Count Then
                                'qui ci sono piu listini di questo nella preventivazione
                                'conto quanti sono 
                                Dim QuantiSono As Integer = l.FindAll(Function(x) x.IdPrev = voce.IdPrev).Count
                                Try
                                    Dim risultato As New GenericWebObject
                                    risultato.Descrizione = voce.Preventivazione.Descrizione & " (" & QuantiSono & ")"
                                    risultato.Url = FormerUrlCreator.GetUrl(voce.Preventivazione)
                                    risultato.Img = FormerWebApp.PathListinoImg & voce.Preventivazione.ImgRif
                                    'risultato.valore = userText
                                    lRis.Add(risultato)
                                    LIdPrev.Add(voce.IdPrev)
                                Catch ex As Exception

                                End Try
                            Else
                                'qui aggiungo direttamente il listinobase
                                Try
                                    Dim risultato As New GenericWebObject
                                    risultato.Descrizione = voce.Nome
                                    risultato.Url = FormerUrlCreator.GetUrl(voce.IdPrev, voce.IdFormProd, voce.IdTipoCarta, voce.IdColoreStampa)
                                    risultato.Img = FormerWebApp.PathListinoImg & voce.GetImgFormato
                                    'risultato.valore = userText
                                    lRis.Add(risultato)
                                Catch ex As Exception

                                End Try

                            End If
                        End If

                    Next

                    lRis.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))

                    For Each voce In lRis
                        Try
                            tb.Rows.Add(voce.Descrizione, voce.Url, voce.Img)
                        Catch ex As Exception

                        End Try
                    Next


                End Using

                tb.Rows.Add("Mostra tutti i risultati", "javascript:goSearch()", "/img/btnCercaSmall.png") ', userText)

                Using setR As DataSet = New DataSet("ricerca")
                    setR.Tables.Add(tb)
                    ris = setR.GetXml
                End Using

            End Using

            'Return (ds.GetXml())
        Catch ex As Exception

        End Try

        Return ris
    End Function

End Class