Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogic
Imports FormerConfig

Friend Class frmMonitorOperatore

    Private _ListaLavori As List(Of LavoroAperto)
    Private _IndiceCorrente As Integer = 0
    Private _IndiceCorrenteLabel As Integer = 0
    Friend Function Carica() As Integer

        AggiornaOrario()
        AggiornaMonitor()
        AggiornaLavoriInCoda()
        AggiornaLavorazioniAperte()
        tmrOraCorrente.Enabled = True
        Show()

        'Return _Ris

    End Function

    Private Sub AggiornaLavoriInCoda()
        dgLavoriInCoda.Rows.Clear()
        Try
            Using Cm As New CommesseDAO
                Dim Cl As List(Of Commessa) = Cm.FindAll(New LUNA.LunaSearchParameter(LFM.Commessa.Stato, CInt(enStatoCommessa.Pronto)))

                For Each C As Commessa In Cl

                    Dim R As DataGridViewRow = New DataGridViewRow
                    R.CreateCells(dgLavoriInCoda)

                    Dim ImgPreview As Image
                    Dim ImgNew As Image = Nothing
                    Try
                        ImgPreview = Image.FromFile(FormerPathCreator.GetAnteprima(C))
                        ImgNew = New Bitmap(ImgPreview, New Size(75, 50))
                    Catch Fex As FileLoadException
                        ImgNew = Nothing
                    Catch ex As Exception
                        ImgNew = Nothing
                    End Try

                    R.Cells(0).Value = ImgNew

                    R.Cells(1).Value = "Stampa su Com " & C.IdCom
                    dgLavoriInCoda.Rows.Add(R)

                Next
            End Using
            Using cMgr As New LavLogDAO
                Dim Lst As List(Of LavLog) = cMgr.ElencoFinituraCommessa

                For Each Lav As LavLog In Lst
                    If Lav.DataOraInizio = Date.MinValue Then
                        Dim R As DataGridViewRow = New DataGridViewRow
                        R.CreateCells(dgLavoriInCoda)

                        Dim ImgPreview As Image
                        Dim ImgNew As Image = Nothing
                        Try
                            ImgPreview = Image.FromFile(FormerPathCreator.GetAnteprima(Lav.CommessaRiferimento))
                            ImgNew = New Bitmap(ImgPreview, New Size(75, 50))
                        Catch Fex As FileLoadException
                            ImgNew = Nothing
                        Catch ex As Exception
                            ImgNew = Nothing
                        End Try

                        R.Cells(0).Value = ImgNew

                        R.Cells(1).Value = Lav.Descrizione & " su " & Lav.IdCom
                        dgLavoriInCoda.Rows.Add(R)
                    End If

                Next

                Dim LstO As List(Of LavLog) = cMgr.ElencoFinituraOrdine
                For Each Lav As LavLog In LstO
                    If Lav.DataOraInizio = Date.MinValue Then
                        Dim R As DataGridViewRow = New DataGridViewRow
                        R.CreateCells(dgLavoriInCoda)

                        Dim ImgPreview As Image
                        Dim ImgNew As Image = Nothing
                        Try
                            ImgPreview = Image.FromFile(Lav.OrdineRiferimento.FilePath)
                            ImgNew = New Bitmap(ImgPreview, New Size(75, 50))
                        Catch Fex As FileLoadException
                            ImgNew = Nothing
                        Catch ex As Exception
                            ImgNew = Nothing
                        End Try

                        R.Cells(0).Value = ImgNew

                        R.Cells(1).Value = Lav.Descrizione & " su " & Lav.IdOrd
                        dgLavoriInCoda.Rows.Add(R)
                    End If

                Next
            End Using
        Catch ex As Exception

        End Try
        lblLavorazDisp.Text = "Lavori In Coda: " & dgLavoriInCoda.Rows.Count

    End Sub

    Private Sub AggiornaLavorazioniAperte()
        DgLavoriAperti.Rows.Clear()
        Try

            For Each L As LavoroAperto In _ListaLavori
                Dim R As DataGridViewRow = New DataGridViewRow
                R.CreateCells(DgLavoriAperti)

                Dim ImgPreview As Image
                Dim ImgNew As Image = Nothing
                Try
                    ImgPreview = Image.FromFile(L.PathImg)
                    ImgNew = New Bitmap(ImgPreview, New Size(75, 50))
                Catch Fex As FileLoadException
                    ImgNew = Nothing
                Catch ex As Exception
                    ImgNew = Nothing
                End Try

                R.Cells(0).Value = ImgNew

                R.Cells(1).Value = L.Login.ToUpper() & " " & L.DescrizioneBreve
                DgLavoriAperti.Rows.Add(R)
            Next


        Catch ex As Exception

        End Try

    End Sub

    Private Sub tmrOper_Tick(sender As Object, e As EventArgs) Handles tmrOper.Tick

        AggiornaMonitor()
        AggiornaLavorazioniAperte()
        AggiornaLavoriInCoda()


    End Sub

    Private Sub AggiornaMonitor()

        tmrOper.Enabled = False
        tmrAnteprima.Enabled = False
        tmrLabel.Enabled = False
        Try
            _ListaLavori = New List(Of LavoroAperto)
            Dim StrUt As String = ","
            Dim TestoOperatori As String = ""

            'qui carico quelli in stampa 
            Using Cm As New CommesseDAO
                Dim Cl As List(Of Commessa) = Cm.FindAll(New LUNA.LunaSearchParameter(LFM.Commessa.Stato, CInt(enStatoCommessa.Stampa)))

                For Each C As Commessa In Cl
                    Using CC As New CronoCommesseDAO
                        Dim L As List(Of CronoCommessa) = CC.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DATACRONOINIZIO DESC"},
                                                                     New LUNA.LunaSearchParameter(LFM.CronoCommessa.IdCom, C.IdCom))
                        If L.Count Then

                            'qui devoinserire i controlli sullo stato dell'ordine

                            Dim O As New Utente
                            O.Read(L(0).IdOperatore)
                            'prima di inserirlo devo controllare lo stato di un qualsiasi ordine

                            Dim Lst As List(Of Ordine) = Nothing

                            Using mgr As New OrdiniDAO
                                Lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, C.IdCom))
                            End Using
                            'almeno un ordine ci deve sempre essere
                            Dim Ord As Ordine = Lst(0)
                            If Ord.Stato = enStatoOrdine.StampaInizio Then
                                Dim A As New LavoroAperto
                                A.IdUt = O.IdUt
                                A.IdLavoro = C.IdCom
                                A.Login = O.Login
                                A.Tipo = enTipoVoceOrdineCommessa.Commessa
                                A.DataOraInizio = C.DataCambioStato

                                TestoOperatori = "Stampa su Com " & C.IdCom
                                A.LoginOperatore = O.Login.ToUpper
                                A.PathImg = FormerPathCreator.GetAnteprima(C)
                                A.DescrizioneBreve = TestoOperatori

                                _ListaLavori.Add(A)
                                If StrUt.IndexOf("," & O.IdUt & ",") = -1 Then
                                    StrUt &= O.IdUt & ","

                                End If
                            End If
                            Ord = Nothing



                        End If
                    End Using
                Next
            End Using

            Using LD As New LavLogDAO
                Dim LL As List(Of LavLog) = LD.ElencoLavoriAperti() 'Find(New LUNA.LunaSearchParameter("DataOraFine", String.Empty))
                _IndiceCorrente = 0
                CambiaAnteprima()
                CambiaLabelAnteprima()

                'calcolo il testo degli operatori 

                'OPERATORE: SCARICO -
                'OPERATORE: {Lavorazione} su Commessa/Ordine {Id} - 


                For Each L As LavLog In LL


                    If StrUt.IndexOf("," & L.IdUt & ",") = -1 Then
                        StrUt &= L.IdUt & ","
                    End If

                    Dim O As New Utente
                    O.Read(L.IdUt)

                    Dim TestoRif As String = ""
                    Dim LavoroAperto As New LavoroAperto
                    LavoroAperto.IdUt = L.IdUt
                    LavoroAperto.Login = L.Utente.Login
                    LavoroAperto.DataOraInizio = L.DataOraInizio
                    LavoroAperto.DataOraFine = L.DataOraFine
                    If L.IdOrd Then
                        TestoRif = "Ord " & L.IdOrd
                        LavoroAperto.IdLavoro = L.IdOrd
                        LavoroAperto.Tipo = FormerEnum.enTipoVoceOrdineCommessa.Ordine
                        Dim Ord As New Ordine
                        Ord.Read(L.IdOrd)
                        LavoroAperto.PathImg = Ord.FilePath
                        Ord = Nothing

                    Else
                        TestoRif = "Com " & L.IdCom
                        LavoroAperto.IdLavoro = L.IdCom
                        LavoroAperto.Tipo = FormerEnum.enTipoVoceOrdineCommessa.Commessa
                        Dim Com As New Commessa
                        Com.Read(L.IdCom)
                        LavoroAperto.PathImg = FormerPathCreator.GetAnteprima(Com)
                        Com = Nothing
                    End If

                    TestoRif = L.Descrizione & " su " & TestoRif

                    LavoroAperto.LoginOperatore = O.Login.ToUpper
                    LavoroAperto.DescrizioneBreve = TestoRif

                    _ListaLavori.Add(LavoroAperto)

                Next
            End Using
            Dim OpNotWork As String = ""
            If StrUt.Length > 1 Then
                StrUt = StrUt.Substring(1).TrimEnd(",")

                Using UM As New UtentiDAO

                    Dim Ul As List(Of Utente) = UM.NonInElenco(StrUt)

                    For Each U As Utente In Ul
                        OpNotWork &= U.Login.ToUpper & ", "
                    Next
                End Using
            End If

            If OpNotWork.Length Then

                OpNotWork = OpNotWork.TrimEnd(" ")
                OpNotWork = OpNotWork.TrimEnd(",")

                lblNotWork.Text = "OPERATORI LIBERI: " & OpNotWork
            Else
                lblNotWork.Text = "OPERATORI LIBERI: Nessuno"
            End If

            'lblAvvisoScorrevole.PowerOff()
            'lblAvvisoScorrevole.Text = TestoOperatori
            'lblAvvisoScorrevole.PowerOn()

            lblLavAperte.Text = "Lavorazioni Aperte: " & _ListaLavori.Count
        Catch ex As Exception

        End Try

        tmrLabel.Enabled = True
        tmrOper.Enabled = True
        tmrAnteprima.Enabled = True

    End Sub

    Private Sub tmrAnteprima_Tick(sender As Object, e As EventArgs) Handles tmrAnteprima.Tick
        CambiaAnteprima()
    End Sub

    Private Sub CambiaLabelAnteprima()

        'gira ogni tot secondi e cambia l'anteprima sullo strato in basso
        Try
            If (_IndiceCorrenteLabel + 1) > _ListaLavori.Count Then
                _IndiceCorrenteLabel = 0
            End If
            Dim L As LavoroAperto = _ListaLavori(_IndiceCorrenteLabel)


            If L.Tipo = FormerEnum.enTipoVoceOrdineCommessa.Commessa Then

                Dim C As New Commessa
                C.Read(L.IdLavoro)

                If C.Stato = enStatoCommessa.Stampa Then
                    lblReparto.Text = "STAMPA"
                    lblReparto.BackColor = FormerColori.ColoreStatoCommessaStampa
                Else

                    lblReparto.Text = "FINITURA SU COMMESSA"
                    lblReparto.BackColor = FormerColori.ColoreStatoCommessaFinituraSuCommessa

                End If
                Try
                    pctAnteprima.Image = Image.FromFile(L.PathImg)
                Catch ex As Exception
                    pctAnteprima.Image = Nothing
                End Try

            Else
                lblReparto.Text = "FINITURA SU PRODOTTO"
                lblReparto.BackColor = FormerColori.ColoreStatoCommessaFinituraSuProdotti
                Try
                    pctAnteprima.Image = Image.FromFile(L.PathImg)
                Catch ex As Exception
                    pctAnteprima.Image = Nothing
                End Try

            End If

            lblDettAnteprima.Text = L.DescrizioneBreve
            lblOperatAnte.Text = L.LoginOperatore
            _IndiceCorrenteLabel += 1
        Catch ex As Exception

        End Try



    End Sub

    Private Sub CambiaAnteprima()
        Try
            If (_IndiceCorrente + 1) > _ListaLavori.Count Then
                _IndiceCorrente = 0
            End If
            Dim L As LavoroAperto = _ListaLavori(_IndiceCorrente)
            Dim Mess As String = ""
            Mess = " - Lavorazione iniziata da " & L.Login & " il " & L.DataOraInizio
            If L.DataOraFine <> Date.MinValue Then Mess &= " e  chiusa il " & L.DataOraFine

            Dim bufferHTML As String = ""
            If L.Tipo = FormerEnum.enTipoVoceOrdineCommessa.Commessa Then
                Dim C As New Commessa
                C.Read(L.IdLavoro)
                bufferHTML = C.CreaRiepilogo
                Mess = "COMMESSA " & C.IdCom & Mess

            Else
                Dim O As New Ordine
                O.Read(L.IdLavoro)
                bufferHTML = O.CreaRiepilogo
                Mess = "ORDINE " & O.IdOrd & Mess

            End If
            lblOperatore.Text = Mess
            Dim Sr As StreamWriter, PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")
            Sr = New System.IO.StreamWriter(PathFileStampa, False)

            Sr.Write(bufferHTML)

            Sr.Close()

            webMonitor.Navigate(PathFileStampa)

            _IndiceCorrente += 1
        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmMonitorOperatore_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub tmrOraCorrente_Tick(sender As Object, e As EventArgs) Handles tmrOraCorrente.Tick
        AggiornaOrario()
    End Sub

    Private Sub lblTime_Click(sender As Object, e As EventArgs) Handles lblTime.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
    Private Sub AggiornaOrario()
        lblTime.Text = Now.ToString("HH:mm")
    End Sub

    Private Sub tmrLabel_Tick(sender As Object, e As EventArgs) Handles tmrLabel.Tick
        CambiaLabelAnteprima()
    End Sub
End Class