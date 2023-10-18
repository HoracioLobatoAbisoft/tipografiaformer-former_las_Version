Imports System.Data.SqlClient
Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FW = FormerDALWeb
Imports FormerBusinessLogicInterface
Imports FormerConfig
Imports FormerError

Public Class MgrPubblicazioneWeb

    Private Shared ConnessioneRemota As SqlConnection
    Private Shared _ConnLocale As SqlConnection
    Private Shared _WebTrans As SqlTransaction

    Public Shared Function FixPercentualiAdattamentoPrePubblicazione() As Integer
        Dim TotFixed As Integer = 0
        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.GetAll()

            For Each Lb As ListinoBase In l

                Lb.CaricaLavorazioni()
                Lb.NumFacciate = Lb.FaccMin
                Dim Altezza As Integer = 0
                Dim Larghezza As Integer = 0
                If Lb.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                    Altezza = 100
                    Larghezza = 100
                End If

                Dim Ris As RisListinoBase = MgrPreventivazioneB.CalcolaListinoBase(Lb,
                                                       Lb.LavorazioniBaseB,
                                                       Nothing,
                                                       Altezza,
                                                       Larghezza,
                                                       True)

                Dim Val1 As Decimal = Lb.v1 - Ris.PrezzoLavObbl1
                Dim Val2 As Decimal = Lb.v2 - Ris.PrezzoLavObbl2
                Dim Val3 As Decimal = Lb.v3 - Ris.PrezzoLavObbl3
                Dim Val4 As Decimal = Lb.v4 - Ris.PrezzoLavObbl4
                Dim Val5 As Decimal = Lb.v5 - Ris.PrezzoLavObbl5
                Dim Val6 As Decimal = Lb.v6 - Ris.PrezzoLavObbl6

                Dim p1 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val1, Ris.PrezzoRivCalc1)
                Dim p2 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val2, Ris.PrezzoRivCalc2)
                Dim p3 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val3, Ris.PrezzoRivCalc3)
                Dim p4 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val4, Ris.PrezzoRivCalc4)
                Dim p5 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val5, Ris.PrezzoRivCalc5)
                Dim p6 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val6, Ris.PrezzoRivCalc6)

                Dim Anomalia As Boolean = False
                If p1 <> Lb.p1 Then
                    Anomalia = True
                End If
                If p2 <> Lb.p2 Then
                    Anomalia = True
                End If
                If p3 <> Lb.p3 Then
                    Anomalia = True
                End If
                If p4 <> Lb.p4 Then
                    Anomalia = True
                End If
                If p5 <> Lb.p5 Then
                    Anomalia = True
                End If
                If p6 <> Lb.p6 Then
                    Anomalia = True
                End If

                If Anomalia Then
                    TotFixed += 1

                    Lb.p1 = p1
                    Lb.p2 = p2
                    Lb.p3 = p3
                    Lb.p4 = p4
                    Lb.p5 = p5
                    Lb.p6 = p6
                    Lb.Save()

                End If
            Next
        End Using

        Return TotFixed
    End Function

    Private Shared Sub RipulisciPath(TabOrig As String, Optional NomeCampo As String = "imgRif")

        Dim SqlC As New SqlCommand("UPDATE " & TabOrig & " SET " & NomeCampo & " = REVERSE(SUBSTRING(REVERSE(" & NomeCampo & "),0,CHARINDEX('\',REVERSE(" & NomeCampo & "))))", ConnessioneRemota)
        If UsaTrans Then SqlC.Transaction = _WebTrans
        SqlC.ExecuteNonQuery()
        SqlC.Dispose()

    End Sub

    Private Shared Sub PulisciListiniBozza()

        Using SqlC As New SqlCommand("DELETE FROM T_ListinoBase WHERE IdPrev = 0 ", ConnessioneRemota)
            If UsaTrans Then SqlC.Transaction = _WebTrans
            SqlC.ExecuteNonQuery()
        End Using

    End Sub

    Private Shared Sub PulisciListiniDisattivati()

        Using SqlC As New SqlCommand("DELETE FROM T_ListinoBase WHERE Disattivo = " & enSiNo.Si, ConnessioneRemota)
            If UsaTrans Then SqlC.Transaction = _WebTrans
            SqlC.ExecuteNonQuery()
        End Using

    End Sub

    Private Shared Sub PulisciListiniSorgente()

        Using SqlC As New SqlCommand("DELETE FROM T_ListinoBase WHERE IdListinobaseSource = 0 ", ConnessioneRemota)
            If UsaTrans Then SqlC.Transaction = _WebTrans
            SqlC.ExecuteNonQuery()
        End Using

    End Sub


    Private Shared Sub ReplicaTabella(TabOrig As String, Optional TabDest As String = "")
        Try
            If TabDest.Length = 0 Then TabDest = TabOrig
            Dim dbCommand As New SqlCommand("SELECT * FROM " & TabOrig, _ConnLocale)
            Dim dr As SqlDataReader = dbCommand.ExecuteReader

            Dim SqlC As New SqlCommand("DELETE FROM " & TabDest, ConnessioneRemota)
            If UsaTrans Then SqlC.Transaction = _WebTrans
            SqlC.ExecuteNonQuery()
            SqlC.Dispose()
            Try
                Using cs As SqlCommand = New SqlCommand("SET IDENTITY_INSERT " & TabDest & " ON", ConnessioneRemota)
                    If UsaTrans Then cs.Transaction = _WebTrans
                    cs.ExecuteNonQuery()

                    cs.Dispose()
                End Using
            Catch ex As Exception

            End Try

            Dim bulkCopy As SqlBulkCopy

            If UsaTrans Then
                bulkCopy = New SqlBulkCopy(ConnessioneRemota, SqlBulkCopyOptions.KeepIdentity, _WebTrans)
            Else
                bulkCopy = New SqlBulkCopy(ConnessioneRemota.ConnectionString, SqlBulkCopyOptions.KeepIdentity)
            End If

            bulkCopy.DestinationTableName = TabDest

            bulkCopy.WriteToServer(dr)
            dr.Close()
            dbCommand.Dispose()

            Try
                Dim cs = New SqlCommand("SET IDENTITY_INSERT " & TabDest & " OFF", ConnessioneRemota)
                If UsaTrans Then cs.Transaction = _WebTrans
                cs.ExecuteNonQuery()

                cs.Dispose()
                cs = Nothing

            Catch ex As Exception

            End Try

            bulkCopy.Close()
        Catch ex As Exception
            Throw New ApplicationException(TabOrig, ex)
        End Try


    End Sub

    Private Shared LastConnectionString As String = String.Empty

    Public Shared Function ApriConnessioneRemota(Server As ServerSito) As Integer
        Dim ris As Integer = 0
        Try
            Dim UseThisString As String = String.Empty
            If Not Server Is Nothing Then
                UseThisString = Server.SQLConnectionString
                LastConnectionString = Server.SQLConnectionString
            Else
                UseThisString = LastConnectionString
            End If
            ConnessioneRemota = New SqlConnection(UseThisString) 'destination connection
            ConnessioneRemota.Open()
        Catch ex As Exception
            'MessageBox.Show("ERRORE: " & ex.Message)
            ris = 1
        End Try
        Return ris
    End Function

    Public Shared Sub ChiudiConnessioneRemota()
        Try
            ConnessioneRemota.Close()
            ConnessioneRemota.Dispose()
            ConnessioneRemota = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function RiControllaListiniBase(Optional IdListinoBaseSpecifico As Integer = 0) As Integer
        Dim RisModificati As Integer = 0
        Using mgr As New ListinoBaseDAO

            Dim p As LUNA.LunaSearchParameter = Nothing

            If IdListinoBaseSpecifico Then
                p = New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBase, IdListinoBaseSpecifico)
            End If

            Dim soloSource As New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0)
            Dim soloAtt As New LUNA.LunaSearchParameter(LFM.ListinoBase.Disattivo, enSiNo.No)

            Dim l As List(Of ListinoBase) = mgr.FindAll(soloSource, soloAtt, p) 'FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.VMotoreCalcolo, MgrPreventivazioneB.VMotoreCalcolo, "<>"),            p)

            'qui ho tutti i listinibase non compatibili
            For Each lb As ListinoBase In l

                'qui devo ricalcolare le percentuali di ricarico di ogni quantità
                lb.CaricaLavorazioni()
                lb.NumFacciate = lb.FaccMin

                Dim V1 As Single = lb.p1
                Dim V2 As Single = lb.p2
                Dim V3 As Single = lb.p3
                Dim V4 As Single = lb.p4
                Dim V5 As Single = lb.p5
                Dim V6 As Single = lb.p6

                Dim ris As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(lb,
                                                                              lb.LavorazioniBaseB)

                If lb.p1 <> V1 OrElse
                   lb.p2 <> V2 OrElse
                   lb.p3 <> V3 OrElse
                   lb.p4 <> V4 OrElse
                   lb.p5 <> V5 OrElse
                   lb.p6 <> V6 Then

                    RisModificati += 1

                    lb.VMotoreCalcolo = MgrPreventivazioneB.VMotoreCalcolo
                    lb.Save()
                End If
            Next

        End Using
        Return RisModificati
    End Function

    Public Shared Function ListaImgTemporaneeInUso() As List(Of FileTemporaneoInUso)

        Dim ris As New List(Of FileTemporaneoInUso)

        Dim LPRif As New LUNA.LunaSearchParameter(LFM.Preventivazione.ImgRif, "%" & FormerConst.PrefissoFileListinoTemp & "%", "like")

        Using mgr As New PreventivazioniDAO
            Dim l As List(Of Preventivazione) = mgr.FindAll(LPRif)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Descrizione = singRis.Descrizione
                ft.Path = singRis.ImgRif
                ft.TipoOggettoListino = enTipoOggettoListino.Preventivazione
                ft.IdRif = singRis.IdPrev
                ris.Add(ft)
            Next
        End Using

        Using mgr As New LavorazioniDAO
            Dim l As List(Of Lavorazione) = mgr.FindAll(LPRif)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Path = singRis.ImgRif
                ft.Descrizione = singRis.Descrizione
                ft.TipoOggettoListino = enTipoOggettoListino.Lavorazione
                ft.IdRif = singRis.IdLavoro
                ris.Add(ft)
            Next
        End Using

        Using mgr As New MacchinariDAO
            Dim l As List(Of Macchinario) = mgr.FindAll(LPRif)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Path = singRis.ImgRif
                ft.Descrizione = singRis.Descrizione
                ft.TipoOggettoListino = enTipoOggettoListino.Macchinario
                ft.IdRif = singRis.IdMacchinario
                ris.Add(ft)
            Next
        End Using

        Using mgr As New CatProdDAO
            Dim LPCat As New LUNA.LunaSearchParameter(LFM.CatProd.ImgCat, "%" & FormerConst.PrefissoFileListinoTemp & "%", "like")
            Dim l As List(Of CatProd) = mgr.FindAll(LPCat)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Path = singRis.ImgCat
                ft.Descrizione = singRis.Descrizione
                ft.TipoOggettoListino = enTipoOggettoListino.CatProd
                ft.IdRif = singRis.IdCatProd
                ris.Add(ft)
            Next
        End Using

        Using mgr As New ColoriStampaDAO
            Dim l As List(Of ColoreStampa) = mgr.FindAll(LPRif)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Path = singRis.imgrif
                ft.Descrizione = singRis.Descrizione
                ft.TipoOggettoListino = enTipoOggettoListino.ColoreStampa
                ft.IdRif = singRis.IdColoreStampa
                ris.Add(ft)
            Next
        End Using

        Using mgr As New FormatiProdottoDAO
            Dim l As List(Of FormatoProdotto) = mgr.FindAll(LPRif)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Path = singRis.ImgRif
                ft.Descrizione = singRis.Formato
                ft.TipoOggettoListino = enTipoOggettoListino.FormatoProdotto
                ft.IdRif = singRis.IdFormProd
                ris.Add(ft)
            Next
        End Using

        Using mgr As New TipiCartaDAO
            Dim l As List(Of TipoCarta) = mgr.FindAll(LPRif)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Path = singRis.ImgRif
                ft.Descrizione = singRis.Tipologia
                ft.TipoOggettoListino = enTipoOggettoListino.TipoCarta
                ft.IdRif = singRis.IdTipoCarta
                ris.Add(ft)
            Next
        End Using

        Using mgr As New CategorieFustelleDAO
            Dim l As List(Of CategoriaFustella) = mgr.FindAll(LPRif)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Path = singRis.ImgRif
                ft.Descrizione = singRis.Categoria
                ft.TipoOggettoListino = enTipoOggettoListino.CategoriaFustella
                ft.IdRif = singRis.IdCatFustella
                ris.Add(ft)
            Next
        End Using

        Using mgr As New TipoFustelleDAO
            Dim l As List(Of TipoFustella) = mgr.FindAll(LPRif)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Path = singRis.ImgRif
                ft.Descrizione = singRis.Riassunto
                ft.TipoOggettoListino = enTipoOggettoListino.TipoFustella
                ft.IdRif = singRis.IdCatFustella
                ris.Add(ft)
            Next
        End Using

        Using mgr As New CatLavDAO
            Dim LPCat As New LUNA.LunaSearchParameter(LFM.CatLav.FileLavNonSelezionata, "%" & FormerConst.PrefissoFileListinoTemp & "%", "like")
            Dim l As List(Of CatLav) = mgr.FindAll(LPCat)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Descrizione = singRis.Descrizione
                ft.Path = singRis.FileLavNonSelezionata
                ft.TipoOggettoListino = enTipoOggettoListino.CatLav
                ft.IdRif = singRis.IdCatLav
                ris.Add(ft)
            Next
        End Using

        Using mgr As New CatFormatoProdottoDAO
            Dim l As List(Of CatFormatoProdotto) = mgr.FindAll(LPRif)

            For Each singRis In l
                Dim ft As New FileTemporaneoInUso
                ft.Path = singRis.ImgRif
                ft.Descrizione = singRis.Nome
                ft.TipoOggettoListino = enTipoOggettoListino.CatFormatoProdotto
                ft.IdRif = singRis.IdCatFormatoProdotto
                ris.Add(ft)
            Next
        End Using

        Return ris

    End Function

    Protected Shared Function IsFileUsed(Path As String) As Boolean
        'T_LISTINOBASE()
        't_preventivazione()
        'T_LAVORI()
        'T_MACCHINARI()
        'Td_CatPROD()
        'Td_Coloristampa()
        'Td_formatoProdotto()
        'Td_tipocarta()
        Dim ris As Boolean = False

        Dim LPSito As New LUNA.LunaSearchParameter("ImgSito", "%" & Path, "like")
        Dim LPRif As New LUNA.LunaSearchParameter("ImgRif", "%" & Path, "like")

        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.FindAll(LPSito)
            If l.Count Then ris = True
        End Using

        If ris = False Then
            Using mgr As New PreventivazioniDAO
                Dim l As List(Of Preventivazione) = mgr.FindAll(LPSito)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New PreventivazioniDAO
                Dim l As List(Of Preventivazione) = mgr.FindAll(LPRif)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New LavorazioniDAO
                Dim l As List(Of Lavorazione) = mgr.FindAll(LPRif)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New MacchinariDAO
                Dim l As List(Of Macchinario) = mgr.FindAll(LPRif)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Dim LPCat As New LUNA.LunaSearchParameter(LFM.CatProd.ImgCat, "%" & Path, "like")
            Using mgr As New CatProdDAO
                Dim l As List(Of CatProd) = mgr.FindAll(LPCat)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New ColoriStampaDAO
                Dim l As List(Of ColoreStampa) = mgr.FindAll(LPRif)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New FormatiProdottoDAO
                Dim l As List(Of FormatoProdotto) = mgr.FindAll(LPRif)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New TipiCartaDAO
                Dim l As List(Of TipoCarta) = mgr.FindAll(LPRif)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New CategorieFustelleDAO
                Dim l As List(Of CategoriaFustella) = mgr.FindAll(LPRif)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New TipoFustelleDAO
                Dim l As List(Of TipoFustella) = mgr.FindAll(LPRif)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New CatLavDAO
                Dim LPCat As New LUNA.LunaSearchParameter(LFM.CatLav.FileLavNonSelezionata, "%" & Path, "like")
                Dim l As List(Of CatLav) = mgr.FindAll(LPCat)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Dim LPCat As New LUNA.LunaSearchParameter(LFM.Lavorazione.ImgZoom, "%" & Path, "like")
            Using mgr As New LavorazioniDAO
                Dim l As List(Of Lavorazione) = mgr.FindAll(LPCat)
                If l.Count Then ris = True
            End Using
        End If

        If ris = False Then
            Using mgr As New CatFormatoProdottoDAO
                Dim l As List(Of CatFormatoProdotto) = mgr.FindAll(LPRif)
                If l.Count Then ris = True
            End Using
        End If

        Return ris
    End Function

    'Public Shared Function PubblicaFile(ByRef frmPubbl As Form,
    '                                    Server As ServerSito) As Integer

    '    Dim ris As Integer = 0

    '    'prima elimino tutti i file inutili 
    '    'Dim RisCheck As String = String.Empty
    '    Dim Direc As New DirectoryInfo(FormerPath.PathListinoImg)
    '    For Each f As FileInfo In Direc.GetFiles("*.png")
    '        If IsFileUsed(f.Name) = False Then

    '            'RisCheck &= f.Name & ControlChars.NewLine
    '            Try
    '                FileIO.FileSystem.DeleteFile(f.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
    '            Catch ex As Exception

    '            End Try
    '        End If
    '    Next

    '    Dim Ftp As New FTPclient(Server.FTPHost,
    '                             Server.FTPLogin,
    '                             Server.FTPPwd)
    '    'immagini
    '    Try

    '        'prendo tutti i file in pathimglistino che sono modificati o nuovi dopo quella data e li copio 

    '        Dim D As New DirectoryInfo(FormerPath.PathListinoImg)

    '        For Each f As FileInfo In D.GetFiles("*.png")

    '            Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, Server.DataUltimaPubbl, f.CreationTime)
    '            ' Dim IntervalloDallaModifica As Long = DateDiff(DateInterval.Second, DataRif, f.LastAccessTime)
    '            Dim PathRemotoFile As String = "tipografiaformer.it/listino/img/" & f.Name
    '            If IntervalloDallaCreazione > 0 Then 'Or IntervalloDallaModifica > 0 Then

    '                'qui lo devo pubblicare
    '                MgrIO.FtpTransfer(frmPubbl, Ftp, f.FullName, PathRemotoFile, enTipoOpFTP.Upload)

    '            End If

    '        Next

    '    Catch ex As Exception
    '        ris = 1
    '    End Try

    '    'template
    '    Try
    '        Dim D As New DirectoryInfo(FormerPath.PathListinoTemplate)

    '        For Each f As FileInfo In D.GetFiles("*.pdf")

    '            Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, Server.DataUltimaPubbl, f.CreationTime)
    '            ' Dim IntervalloDallaModifica As Long = DateDiff(DateInterval.Second, DataRif, f.LastAccessTime)

    '            If IntervalloDallaCreazione > 0 Then 'Or IntervalloDallaModifica > 0 Then
    '                Dim PathRemotoFile As String = "tipografiaformer.it/listino/template/" & f.Name
    '                Dim PathRemotoFilePreview As String = "tipografiaformer.it/listino/template/" & f.Name & ".jpg"
    '                Dim PathPreview As String = FormerPath.PathListinoTemplate & f.Name & ".jpg"

    '                Try
    '                    'qui potrebbe andare in errore per determinati pdf 
    '                    FormerHelper.PDF.GetPdfThumbnail(f.FullName, PathPreview)
    '                Catch ex As Exception

    '                End Try
    '                MgrIO.FtpTransfer(frmPubbl, Ftp, f.FullName, PathRemotoFile, enTipoOpFTP.Upload)
    '                If File.Exists(PathPreview) Then MgrIO.FtpTransfer(frmPubbl, Ftp, PathPreview, PathRemotoFilePreview, enTipoOpFTP.Upload)
    '            End If

    '        Next

    '    Catch ex As Exception

    '    End Try

    '    'foto hd
    '    Try
    '        Dim BufferFotoHDScartate As String = String.Empty
    '        Dim D As New DirectoryInfo(FormerPath.PathListinoFoto)
    '        'qui devo ciclare per ogni cartella
    '        For Each DiNt As DirectoryInfo In D.GetDirectories()
    '            Dim PathRemotoDir As String = "tipografiaformer.it/listino/foto/" & DiNt.Name
    '            Dim ListaFileOnline As New List(Of String)

    '            For Each f As FileInfo In DiNt.GetFiles("*.*")

    '                If f.Extension.ToLower = ".jpg" Or f.Extension.ToLower = ".png" Then

    '                    If f.Length < 200000 Then

    '                        Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, Server.DataUltimaPubbl, f.CreationTime)
    '                        ' Dim IntervalloDallaModifica As Long = DateDiff(DateInterval.Second, DataRif, f.LastAccessTime)

    '                        Dim NomeNormalizzato As String = FormerHelper.Web.NormalizzaNomeFile(f.Name)
    '                        ListaFileOnline.Add(NomeNormalizzato)

    '                        Dim PathRemotoFile As String = "tipografiaformer.it/listino/foto/" & DiNt.Name & "/" & NomeNormalizzato

    '                        Try
    '                            If Ftp.FtpFileExists(PathRemotoFile) = False Then
    '                                Try
    '                                    Ftp.FtpCreateDirectory(PathRemotoDir)
    '                                Catch ex As Exception

    '                                End Try

    '                                MgrIO.FtpTransfer(frmPubbl, Ftp, f.FullName, PathRemotoFile, enTipoOpFTP.Upload)

    '                            End If
    '                        Catch ex As Exception

    '                        End Try

    '                        Dim x As FTPdirectory = Ftp.ListDirectoryDetail("/" & PathRemotoDir)

    '                        For Each ss As FTPfileInfo In x.GetFiles

    '                            Dim PathInterno As String = FormerPath.PathListinoFoto & DiNt.Name & "\" & ss.Filename

    '                            If File.Exists(PathInterno) = False Then
    '                                Try
    '                                    Ftp.FtpDelete(ss.FullName)
    '                                Catch ex As Exception

    '                                End Try
    '                            End If

    '                        Next

    '                        'If IntervalloDallaCreazione > 0 Then 'Or IntervalloDallaModifica > 0 Then
    '                        '    Try
    '                        '        Ftp.FtpCreateDirectory(PathRemotoDir)
    '                        '    Catch ex As Exception

    '                        '    End Try
    '                        '    MgrIO.FtpTransfer(frmPubbl, Ftp, f.FullName, PathRemotoFile, enTipoOpFTP.Upload)
    '                        'End If

    '                    Else

    '                        BufferFotoHDScartate &= "La foto '" & f.FullName & "' del peso di " & f.Length & " byte è stata scartata nella pubblicazione." & ControlChars.NewLine

    '                    End If

    '                End If
    '            Next

    '            'Dim ListaFile As Collections.Generic.List(Of String)
    '            'ListaFile = Ftp.ListDirectory("/" & PathRemotoDir)
    '            'For Each FileRemoto As String In ListaFile
    '            '    If FileRemoto.ToLower.EndsWith("jpg") Or FileRemoto.ToLower.EndsWith("png") Then
    '            '        If File.Exists(DiNt.FullName & "\" & FileRemoto) = False Then
    '            '            Ftp.FtpDelete(ss.FullName)
    '            '            Ftp.FtpDelete("/" & PathRemotoDir & "/" & FileRemoto)
    '            '        End If
    '            '    End If
    '            'Next
    '        Next
    '        If BufferFotoHDScartate.Length Then

    '            Dim NomeTxtTemp As String = FormerPath.PathTempLocale & FormerHelper.File.GetNomeFileTemp(".txt")

    '            Using w As New StreamWriter(NomeTxtTemp)

    '                w.Write(BufferFotoHDScartate)

    '            End Using

    '            FormerHelper.File.ShellExtended(NomeTxtTemp)


    '        End If
    '    Catch ex As Exception

    '    End Try

    '    Ftp = Nothing

    '    Return ris

    'End Function

    Private Shared UsaTrans As Boolean = True

    Public Shared Sub ResettaLastUpdate()

        Using mgr As New ListinoBaseDAO
            mgr.ResetLastUpdate(False)
        End Using

    End Sub

    Public Shared Function PubblicaIndiciRicerca(Optional SoloSuQuestiListini As List(Of ListinoBase) = Nothing) As Integer

        Dim ris As Integer = 0
        'prima elimino tutti gli indici presenti
        'poi ciclo per ognuno dei listini base e creo per ognuno un indice calcolando i prezzi

        'Using tb As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox()
        Try
            'tb.TransactionBegin()

            If ConnessioneRemota Is Nothing OrElse ConnessioneRemota.State <> Data.ConnectionState.Open Then
                ApriConnessioneRemota(Nothing)
            End If

            Using Imgr As New FW.IndiciRicercaDAO(ConnessioneRemota)

                If SoloSuQuestiListini Is Nothing Then
                    Imgr.DeleteAll()
                Else
                    For Each lb As ListinoBase In SoloSuQuestiListini
                        Imgr.DeleteByIdListinoBase(lb.IdListinoBase)
                    Next
                End If

                Dim l As List(Of ListinoBase) = Nothing
                Using mgr As New ListinoBaseDAO()
                    l = mgr.ListiniUtilizzabili(enTipoListiniBase.Produzione)

                    If Not SoloSuQuestiListini Is Nothing Then
                        l = l.FindAll(Function(x) SoloSuQuestiListini.FindAll(Function(z) z.IdListinoBase = x.IdListinoBase).Count)
                    End If

                    For Each Lb As ListinoBase In l

                        Lb.CaricaLavorazioni()

                        'qui creo l'indice
                        Dim I As New FW.IndiceRicerca()
                        I.NomeListino = Lb.Nome
                        I.IdListinoBase = Lb.IdListinoBase
                        I.IdPrev = Lb.IdPrev
                        I.InEvidenza = Lb.InEvidenza
                        I.PercCoupon = Lb.Preventivazione.PercCoupon
                        I.ProdottoFinito = IIf(Lb.FormatoProdotto.ProdottoFinito, enSiNo.Si, enSiNo.No)

                        'per il prezzo prendo sempre la percentuale normal
                        'per le quantita cerco le tre piu vendute se ci sono
                        'se non ci sono prendo prima seconda e terza nel listino base
                        Dim QtaToCalc As Integer() = {0, 0, 0}
                        Dim TotOrdini As Integer = 0

                        If Lb.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then

                            QtaToCalc(0) = 500
                            QtaToCalc(1) = 1000
                            QtaToCalc(2) = 5000

                        Else
                            QtaToCalc(0) = Lb.qta1
                            QtaToCalc(1) = Lb.qta2
                            QtaToCalc(2) = Lb.qta3

                            'qui trovo le quantita piu vendute del prodotto
                            'If Lb.IdListinoBase = 254 Then Stop
                            Using mgrO As New OrdiniDAO
                                mgrO.QtaPiuVendutaListinoBase(QtaToCalc, Lb.IdListinoBase)
                                TotOrdini = mgrO.NumeroTotaleOrdiniListinoBase(Lb.IdListinoBase)
                            End Using

                            Array.Sort(QtaToCalc)

                        End If

                        I.Qta1 = QtaToCalc(0)
                        I.Qta2 = QtaToCalc(1)
                        I.Qta3 = QtaToCalc(2)

                        Dim R As RisPrezzoIntermedio = CalcolaPrezzi(Lb, I.Qta1)

                        I.Prezzo1Riv = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(R.PrezzoRiv * MgrPercentualiDay.PercentualeNormale)
                        I.Prezzo1 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(R.PrezzoPubbl * MgrPercentualiDay.PercentualeNormale)

                        R = CalcolaPrezzi(Lb, I.Qta2)
                        I.Prezzo2Riv = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(R.PrezzoRiv * MgrPercentualiDay.PercentualeNormale)
                        I.Prezzo2 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(R.PrezzoPubbl * MgrPercentualiDay.PercentualeNormale)

                        R = CalcolaPrezzi(Lb, I.Qta3)
                        I.Prezzo3Riv = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(R.PrezzoRiv * MgrPercentualiDay.PercentualeNormale)
                        I.Prezzo3 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(R.PrezzoPubbl * MgrPercentualiDay.PercentualeNormale)
                        I.TotOrdini = TotOrdini

                        Imgr.Save(I)
                    Next
                End Using
            End Using
            'tb.TransactionCommit()
        Catch ex As Exception
            'tb.TransactionRollBack()

            MgrError.ManageError(ex)
            ris = 1
        End Try
        'End Using

    End Function

    Private Shared Function CalcolaPrezzi(L As ListinoBase,
                                          Qta As Single) As RisPrezzoIntermedio
        'Dim QtaRichiesta As Integer = Convert.ToInt32(ddlQta.SelectedValue)

        Dim listaBaseB As List(Of ILavorazioneB) = L.LavorazioniBaseB

        'Dim _Risultato As RisultatoListinoBase
        '_Risultato = MgrPreventivazioneB.CalcolaPrezzi(L, listaBaseB, , False)

        'Dim R As RisultatoPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoIntermedio(Qta,
        '                                                                                 L,
        '                                                                                 _Risultato)
        L.NumFacciate = L.FaccMin

        Dim R As RisPrezzoIntermedio = Nothing

        If L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            Dim QtaRichiesta As Single = 0
            Dim QtaSecondaria As Integer = 0

            Dim LatoFisso As Integer = (L.FormatoProdotto.FormatoCarta.Larghezza * 10)
            Dim LatoRiferimento As Single = Math.Sqrt(FormerLib.FormerConst.ProdottiCaratteristiche.EtichetteCmQuadri.CmQuadriEsempio)

            QtaSecondaria = ((LatoRiferimento * LatoRiferimento)) * Qta
            QtaRichiesta = MgrCalcoliTecnici.CalcolaCmQuadri(LatoRiferimento,
                                                                            LatoRiferimento,
                                                                            enTipoOrientamento.Orizzontale,
                                                                            LatoFisso,
                                                                            QtaRichiesta)
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(L, Qta, listaBaseB, QtaSecondaria,, False,, LatoRiferimento, LatoRiferimento)

        Else
            R = MgrPreventivazioneB.CalcolaPrezzoFinale(L, Qta, listaBaseB,,, False)
        End If

        Return R

    End Function

    Public Shared Function AggiornaParametriListinoPDF() As Integer
        Dim ris As Integer = 0

        Try
            '_ConnLocale = LUNA.LunaContext.Connection

            If ConnessioneRemota Is Nothing OrElse ConnessioneRemota.State <> Data.ConnectionState.Open Then
                ApriConnessioneRemota(Nothing)
            End If

            Using mgrV As New FW.ParamListiniDAO(ConnessioneRemota)

                mgrV.DeleteAll()

                Using mgr As New ParamListiniDAO
                    Dim l As List(Of ParamListino) = mgr.GetAll()

                    For Each Par As ParamListino In l
                        'esplicito la connessione remota

                        Dim parW As New FW.ParamListino
                        parW.IdUt = 0
                        parW.IdPrev = Par.IdPrev
                        parW.Qta1 = Par.Qta1
                        parW.Qta2 = Par.Qta2
                        parW.Qta3 = Par.Qta3
                        parW.Qta4 = Par.Qta4
                        parW.Qta5 = Par.Qta5
                        mgrV.Save(parW)

                    Next

                End Using
            End Using
        Catch ex As Exception
            MgrError.ManageError(ex)
            ris = 1
        End Try

        Return ris
    End Function

    Public Shared Function GeneraListiniProduzione() As Integer
        Dim ris As Integer = 0

        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

            Try
                tb.TransactionBegin()
                Using Mgr As New ListinoBaseDAO

                    Dim ListaIdLBGenerati As New List(Of Integer)

                    'disattivo gli eliminati
                    Dim lElim As List(Of ListinoBase) = Mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                                    New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.Si))
                    For Each voce In lElim
                        For Each lb As ListinoBase In voce.ListiniBaseFigli
                            If lb.Disattivo <> enSiNo.Si Then
                                Mgr.DeleteOrDeactivate(lb.IdListinoBase)
                            End If
                        Next
                    Next

                    'elimino tutti i prevlink
                    'elimino i catv
                    'elimino i lavprev

                    Using mgrP As New PrevLinkListinoDAO
                        mgrP.DeleteAllLbProduzione()
                    End Using

                    Using mgrP As New CatVirtualiDAO
                        mgrP.DeleteAllLbProduzione()
                    End Using

                    Using mgrP As New LavorazioniDAO
                        mgrP.DeleteAllLbProduzione()
                    End Using
                    Dim l As List(Of ListinoBase) = Mgr.GetListiniBaseSource()

                    For Each singLb As ListinoBase In l
                        singLb.CaricaLavorazioni()

                        Dim Combinazioni As New List(Of String)

                        Dim CombinazionePrincipale As String = "0#" & singLb.IdFormProd & "#" & singLb.IdTipoCarta & "#" & singLb.IdColoreStampa

                        Combinazioni.Add(CombinazionePrincipale)

                        Dim VarianteCS As GruppoVarianteRif = singLb.ListaVarianti.Find(Function(x) x.TipoRiferimento = enTipoOggettoListino.ColoreStampa)

                        If Not VarianteCS Is Nothing Then
                            'aggiungo la variante principale
                            Dim CombinazioneCorrente As String = VarianteCS.IdRiferimento & "#" & singLb.IdFormProd & "#" & singLb.IdTipoCarta & "#" & VarianteCS.IdRiferimento

                            Dim ltent As List(Of ListinoBase) = Mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdFormProd, singLb.IdFormProd),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, singLb.IdTipoCarta),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, VarianteCS.IdRiferimento),
                                                                            New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))

                            If ltent.Count = 0 Then
                                'qui posso aggiungere la combinazione
                                If Combinazioni.FindAll(Function(x) x = CombinazioneCorrente).Count = 0 Then Combinazioni.Add(CombinazioneCorrente)
                            End If

                        End If

                        For Each var In singLb.ListaVarianti.FindAll(Function(x) x.TipoRiferimento = enTipoOggettoListino.TipoCarta)

                            Dim CombinazioneCorrente As String = singLb.IdColoreStampa & "#" & singLb.IdFormProd & "#" & var.IdRiferimento & "#" & singLb.IdColoreStampa

                            'ora vedo se esitono gia
                            Dim ltent As List(Of ListinoBase) = Mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdFormProd, singLb.IdFormProd),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, var.IdRiferimento),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, singLb.IdColoreStampa),
                                                                            New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))

                            If ltent.Count = 0 Then
                                'qui posso aggiungere la combinazione
                                If Combinazioni.FindAll(Function(x) x = CombinazioneCorrente).Count = 0 Then Combinazioni.Add(CombinazioneCorrente)
                            End If

                            If Not VarianteCS Is Nothing Then
                                ltent = Mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0),
                                                    New LUNA.LSP(LFM.ListinoBase.IdFormProd, singLb.IdFormProd),
                                                    New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, var.IdRiferimento),
                                                    New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, VarianteCS.IdRiferimento),
                                                    New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))
                                If ltent.Count = 0 Then
                                    CombinazioneCorrente = VarianteCS.IdRiferimento & "#" & singLb.IdFormProd & "#" & var.IdRiferimento & "#" & VarianteCS.IdRiferimento
                                    If Combinazioni.FindAll(Function(x) x = CombinazioneCorrente).Count = 0 Then Combinazioni.Add(CombinazioneCorrente)
                                End If
                            End If
                        Next

                        Combinazioni.Sort(Function(x, y) x.CompareTo(y))

                        For Each combinazione In Combinazioni
                            'qui ogni combinazione va valutata se esiste gia o devo crearla

                            'If singLb.IdListinoBase = 1239 Then Stop


                            Dim Valori() As String = combinazione.Split("#")

                            Dim Ordine As Integer = Valori(0)
                            Dim IdFP As Integer = Valori(1)
                            Dim IdTC As Integer = Valori(2)
                            Dim IdCS As Integer = Valori(3)

                            Dim lRis As List(Of ListinoBase) = Mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, singLb.IdListinoBase),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdFormProd, IdFP),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, IdTC),
                                                                            New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, IdCS),
                                                                            New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))

                            Dim LBCombin As ListinoBase = Nothing
                            Dim NuovoNome As String = String.Empty

                            Dim IsVariante As Boolean = False

                            If lRis.Count Then
                                'lo aggiorno
                                Dim IdOldLB As Integer = 0
                                LBCombin = lRis(0)
                                IdOldLB = LBCombin.IdListinoBase
                                Dim PercPromoAutomatico As Integer = LBCombin.PercPromoAutomatico
                                Dim PercMaxFatturato As Integer = LBCombin.PercMaxPromoFatturato
                                Dim AttivaPromoAutomatico As Integer = LBCombin.AttivaPromoAutomatico
                                Dim CounterDayPromo As Integer = LBCombin.CounterDayPromo
                                LBCombin = singLb.Clone
                                LBCombin.IdListinoBase = IdOldLB
                                LBCombin.PercPromoAutomatico = PercPromoAutomatico
                                LBCombin.PercMaxPromoFatturato = PercMaxFatturato
                                LBCombin.AttivaPromoAutomatico = AttivaPromoAutomatico
                                LBCombin.CounterDayPromo = CounterDayPromo

                            Else
                                'lo creo
                                LBCombin = singLb.Clone
                                LBCombin.IdListinoBase = 0
                            End If

                            LBCombin.IdListinoBaseSource = singLb.IdListinoBase

                            If singLb.IdTipoCarta <> IdTC OrElse
                               singLb.IdColoreStampa <> IdCS Then
                                'qui sono in una combinazione variante

                                LBCombin.IsFormerChoice = enSiNo.No
                                IsVariante = True
                            End If

                            LBCombin.IdTipoCarta = IdTC
                            LBCombin.IdColoreStampa = IdCS

                            If IsVariante Then
                                'qui vado a rigenerare il nome
                                Using tc As New TipoCarta
                                    tc.Read(IdTC)
                                    NuovoNome = singLb.PrefissoVarianti & " " & tc.Grammi & "gr " & IIf(tc.Finitura.Length, tc.Finitura & " ", "")
                                End Using

                                Using cs As New ColoreStampa
                                    cs.Read(IdCS)
                                    NuovoNome &= cs.Descrizione
                                End Using

                                LBCombin.Nome = NuovoNome
                                LBCombin.NomeInterno = NuovoNome

                                LBCombin.Save()

                                If singLb.IdColoreStampa = IdCS Then
                                    'combinazione completata
                                    'calcolo i prezzi bloccando la percentuale
                                    'ricalcolo la percentuale e salvo

                                    LBCombin.NumFacciate = LBCombin.FaccMin

                                    Dim RisLB As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(LBCombin,
                                                                                  LBCombin.LavorazioniBaseB,
                                                                                  ,
                                                                                  False)

                                    'qui vedo cosa fare 
                                    LBCombin.v1 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale1, 0)
                                    LBCombin.v2 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale2, 0)
                                    LBCombin.v3 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale3, 0)
                                    LBCombin.v4 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale4, 0)
                                    LBCombin.v5 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale5, 0)
                                    LBCombin.v6 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale6, 0)

                                    Dim VarianteTC As GruppoVarianteRif = singLb.ListaVarianti.Find(Function(x) x.TipoRiferimento = enTipoOggettoListino.TipoCarta And x.IdRiferimento = IdTC)

                                    If Not VarianteTC Is Nothing Then

                                        If VarianteTC.PercDiminuzione Then
                                            'applico la percdiminuzione al prezzo e ricalcolo 
                                            Dim ValRif1 As Decimal = LBCombin.v1
                                            Dim ValRif2 As Decimal = LBCombin.v2
                                            Dim ValRif3 As Decimal = LBCombin.v3
                                            Dim ValRif4 As Decimal = LBCombin.v4
                                            Dim ValRif5 As Decimal = LBCombin.v5
                                            Dim ValRif6 As Decimal = LBCombin.v6

                                            LBCombin.v1 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif1 + (ValRif1 * VarianteTC.PercDiminuzione / 100), 0)
                                            LBCombin.v2 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif2 + (ValRif2 * VarianteTC.PercDiminuzione / 100), 0)
                                            LBCombin.v3 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif3 + (ValRif3 * VarianteTC.PercDiminuzione / 100), 0)
                                            LBCombin.v4 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif4 + (ValRif4 * VarianteTC.PercDiminuzione / 100), 0)
                                            LBCombin.v5 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif5 + (ValRif5 * VarianteTC.PercDiminuzione / 100), 0)
                                            LBCombin.v6 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif6 + (ValRif6 * VarianteTC.PercDiminuzione / 100), 0)

                                            Dim RisLBTC As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(LBCombin,
                                                                                 LBCombin.LavorazioniBaseB)

                                            'qui vedo cosa fare 
                                            LBCombin.p1 = RisLBTC.P1
                                            LBCombin.p2 = RisLBTC.P2
                                            LBCombin.p3 = RisLBTC.P3
                                            LBCombin.p4 = RisLBTC.P4
                                            LBCombin.p5 = RisLBTC.P5
                                            LBCombin.p6 = RisLBTC.P6

                                        End If

                                    End If

                                    LBCombin.Save()

                                Else

                                    'qui è diverso il colore di stampa devo vedere quale e' il destinazione
                                    If VarianteCS.IdRiferimento = enColoriStampa.ColoriFronteRetro Then 'AndAlso VarianteCS.PercDiminuzione Then

                                        LBCombin.NumFacciate = LBCombin.FaccMin

                                        Dim RisLB As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(LBCombin,
                                                                                  LBCombin.LavorazioniBaseB,
                                                                                  ,
                                                                                  False)

                                        'qui vedo cosa fare 
                                        LBCombin.v1 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale1, 0)
                                        LBCombin.v2 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale2, 0)
                                        LBCombin.v3 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale3, 0)
                                        LBCombin.v4 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale4, 0)
                                        LBCombin.v5 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale5, 0)
                                        LBCombin.v6 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(RisLB.PrezzoRivFinale6, 0)

                                        Dim VarianteTC As GruppoVarianteRif = singLb.ListaVarianti.Find(Function(x) x.TipoRiferimento = enTipoOggettoListino.TipoCarta And x.IdRiferimento = IdTC)

                                        If Not VarianteTC Is Nothing Then
                                            If VarianteTC.PercDiminuzione Then
                                                Dim ValRif1 As Decimal = LBCombin.v1
                                                Dim ValRif2 As Decimal = LBCombin.v2
                                                Dim ValRif3 As Decimal = LBCombin.v3
                                                Dim ValRif4 As Decimal = LBCombin.v4
                                                Dim ValRif5 As Decimal = LBCombin.v5
                                                Dim ValRif6 As Decimal = LBCombin.v6

                                                LBCombin.v1 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif1 + (ValRif1 * VarianteTC.PercDiminuzione / 100), 0)
                                                LBCombin.v2 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif2 + (ValRif2 * VarianteTC.PercDiminuzione / 100), 0)
                                                LBCombin.v3 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif3 + (ValRif3 * VarianteTC.PercDiminuzione / 100), 0)
                                                LBCombin.v4 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif4 + (ValRif4 * VarianteTC.PercDiminuzione / 100), 0)
                                                LBCombin.v5 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif5 + (ValRif5 * VarianteTC.PercDiminuzione / 100), 0)
                                                LBCombin.v6 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif6 + (ValRif6 * VarianteTC.PercDiminuzione / 100), 0)

                                                Dim RisLBTC As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(LBCombin,
                                                                                     LBCombin.LavorazioniBaseB)

                                                'qui vedo cosa fare 
                                                LBCombin.p1 = RisLBTC.P1
                                                LBCombin.p2 = RisLBTC.P2
                                                LBCombin.p3 = RisLBTC.P3
                                                LBCombin.p4 = RisLBTC.P4
                                                LBCombin.p5 = RisLBTC.P5
                                                LBCombin.p6 = RisLBTC.P6
                                            End If
                                        End If

                                        LBCombin.Save()

                                    ElseIf VarianteCS.IdRiferimento = enColoriStampa.ColoriSoloFronte Then 'AndAlso VarianteCS.PercDiminuzione Then

                                        Dim ValRif1 As Decimal = LBCombin.v1
                                        Dim ValRif2 As Decimal = LBCombin.v2
                                        Dim ValRif3 As Decimal = LBCombin.v3
                                        Dim ValRif4 As Decimal = LBCombin.v4
                                        Dim ValRif5 As Decimal = LBCombin.v5
                                        Dim ValRif6 As Decimal = LBCombin.v6

                                        If IdTC <> singLb.IdTipoCarta Then
                                            'qui e' una variante completa non solo quella di partenza
                                            'cerco la variante indicata
                                            Dim lRif As List(Of ListinoBase) = Mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, singLb.IdListinoBase),
                                                                                            New LUNA.LSP(LFM.ListinoBase.IdFormProd, IdFP),
                                                                                            New LUNA.LSP(LFM.ListinoBase.IdTipoCarta, IdTC),
                                                                                            New LUNA.LSP(LFM.ListinoBase.IdColoreStampa, enColoriStampa.ColoriFronteRetro),
                                                                                            New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No))

                                            If lRif.Count Then
                                                Dim LBrif As ListinoBase = lRif(0)
                                                ValRif1 = LBrif.v1
                                                ValRif2 = LBrif.v2
                                                ValRif3 = LBrif.v3
                                                ValRif4 = LBrif.v4
                                                ValRif5 = LBrif.v5
                                                ValRif6 = LBrif.v6

                                            End If


                                        End If


                                        LBCombin.NumFacciate = LBCombin.FaccMin

                                        LBCombin.v1 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif1 - (ValRif1 * VarianteCS.PercDiminuzione / 100), 0)
                                        LBCombin.v2 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif2 - (ValRif2 * VarianteCS.PercDiminuzione / 100), 0)
                                        LBCombin.v3 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif3 - (ValRif3 * VarianteCS.PercDiminuzione / 100), 0)
                                        LBCombin.v4 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif4 - (ValRif4 * VarianteCS.PercDiminuzione / 100), 0)
                                        LBCombin.v5 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif5 - (ValRif5 * VarianteCS.PercDiminuzione / 100), 0)
                                        LBCombin.v6 = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(ValRif6 - (ValRif6 * VarianteCS.PercDiminuzione / 100), 0)

                                        Dim RisLB As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(LBCombin,
                                                                                  LBCombin.LavorazioniBaseB)

                                        'qui vedo cosa fare 
                                        LBCombin.p1 = RisLB.P1
                                        LBCombin.p2 = RisLB.P2
                                        LBCombin.p3 = RisLB.P3
                                        LBCombin.p4 = RisLB.P4
                                        LBCombin.p5 = RisLB.P5
                                        LBCombin.p6 = RisLB.P6

                                        LBCombin.Save()

                                    End If
                                End If
                            Else
                                LBCombin.Save()
                            End If

                            ListaIdLBGenerati.Add(LBCombin.IdListinoBase)

                            For Each catvirtuale In singLb.CollegamentoSuCatVirtuale
                                'le vado a spostare sul padre
                                catvirtuale.IdCatListino = 0
                                catvirtuale.IdListinoBase = LBCombin.IdListinoBase
                                catvirtuale.Save()
                            Next

                            For Each PreventivazioneLnk In singLb.LinkAPreventivazione
                                'le vado a spostare sul padre
                                PreventivazioneLnk.IdPrevListino = 0
                                PreventivazioneLnk.IdListinoBase = LBCombin.IdListinoBase
                                PreventivazioneLnk.Save()
                            Next

                            'poi genero le catvirtuali
                            'i link in preventivazione

                        Next

                    Next

                    l = Mgr.GetListiniBaseProduzione

                    For Each singlb In l
                        If ListaIdLBGenerati.FindAll(Function(x) x = singlb.IdListinoBase).Count = 0 Then
                            'qui non e' stato lavorato ne generato quindi presumo venga da una precedente generazione di cui sono state tolte le varianti 
                            Mgr.DeleteOrDeactivate(singlb.IdListinoBase)
                        End If
                    Next

                End Using
                tb.TransactionCommit()
            Catch ex As Exception
                tb.TransactionRollBack()
                ris = 1
            End Try

        End Using

        Return ris

    End Function

    Public Shared Function Pubblica(IsProduzione As Boolean,
                                    Optional GeneraLBProduzione As Boolean = True) As Integer
        Dim ris As Integer = 0
        Try
            'Dim strConn As String = Postazione.StrConnWeb

            'ConnessioneRemota = New SqlConnection(strConn) 'destination connection
            _ConnLocale = LUNA.LunaContext.Connection  ' source connection
            ' ConnessioneRemota.Open()


            'qui vado a generare i listini dalle varianti

            'If IsProduzione = False Then 'per ora solo in collaudo
            If GeneraLBProduzione Then GeneraListiniProduzione()
            'End If

            If UsaTrans Then _WebTrans = ConnessioneRemota.BeginTransaction()
            'qui ho le connessioni aperte 
            ReplicaTabella("T_Curvaatt")
            ReplicaTabella("T_ListinoBase")
            ReplicaTabella("T_Preventivazione")
            ReplicaTabella("Td_Formato")
            ReplicaTabella("Td_FormatoCarta")
            ReplicaTabella("Td_FormatoProdotto")
            ReplicaTabella("Td_TipoCarta")
            ReplicaTabella("Td_ColoriStampa")
            ReplicaTabella("T_lavori")
            ReplicaTabella("Tr_LavPrev")
            ReplicaTabella("Tr_Resa")
            ReplicaTabella("T_Macchinari")
            ReplicaTabella("Td_CatLav")
            ReplicaTabella("T_Corriere")
            ReplicaTabella("T_PrezziLavoro")
            ReplicaTabella("Tr_CartaComposta")
            ReplicaTabella("Tr_PrevListino")
            ReplicaTabella("Glossario")
            ReplicaTabella("T_TipoFustella")
            ReplicaTabella("Td_TipoPagamenti")
            ReplicaTabella("T_CapCorr")
            ReplicaTabella("Td_CatFustelle")
            ReplicaTabella("Tr_CatTipoFustella")
            ReplicaTabella("ModelliCubetti")
            ReplicaTabella("T_Omaggi")
            ReplicaTabella("TD_CatFormatoProdotto")
            ReplicaTabella("TR_DefaultFormatoPrev")
            ReplicaTabella("T_CatVirtuali")
            ReplicaTabella("Tr_catvlistini")
            ReplicaTabella("Tr_FormatoMacchinario")

            'If IsProduzione = False Then
            '                ReplicaTabella("T_GruppiVarianti")
            ReplicaTabella("Tr_GruppoVarianteRif")
            'End If
            ReplicaTabella("T_GruppiLBConsigliati")
            ReplicaTabella("T_GruppiLBLogici")

            PulisciListiniBozza()

            PulisciListiniSorgente()

            'If IsProduzione = False Then
            'PulisciListiniDisattivati()
            'End If

            'qui ripulisco i path da Postazione.PathImgListino
            RipulisciPath("T_Preventivazione")
            RipulisciPath("T_Preventivazione", "imgSito")
            RipulisciPath("T_ListinoBase", "imgSito")
            RipulisciPath("Td_FormatoProdotto")
            RipulisciPath("Td_FormatoProdotto", "PdfTemplate")
            RipulisciPath("Td_FormatoProdotto", "PdfTemplate3D")
            RipulisciPath("Td_TipoCarta")
            RipulisciPath("Td_ColoriStampa")
            RipulisciPath("T_lavori")
            RipulisciPath("T_TipoFustella")
            RipulisciPath("Td_CatFustelle")
            RipulisciPath("TD_CatLav", "FileLavNonSelezionata")
            RipulisciPath("T_Lavori", "ImgZoom")
            RipulisciPath("T_TipoFustella", "TemplatePDF")
            RipulisciPath("Td_CatFormatoProdotto")
            RipulisciPath("T_Macchinari")
            RipulisciPath("T_Macchinari", "imgBig")

            If UsaTrans Then _WebTrans.Commit()

        Catch ex As Exception
            If Not _WebTrans Is Nothing Then
                _WebTrans.Rollback()
            End If

            MgrError.ManageError(ex)
            ris = 1
        Finally

            'ConnessioneRemota.Close()
        End Try
        Return ris

    End Function

    Public Function getlistinibaseProduzione() As List(Of IListinoBaseB)
        Dim ris As New List(Of IListinoBaseB)



        Return ris
    End Function

End Class
