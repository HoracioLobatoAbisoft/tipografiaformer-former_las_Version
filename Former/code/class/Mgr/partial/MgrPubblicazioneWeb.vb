Imports System.Data.SqlClient
Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FW = FormerDALWeb
Imports FormerBusinessLogicInterface
Imports FormerConfig
Imports FormerBusinessLogic

Public Class MgrPubblicazioneWeb
    Inherits FormerBusinessLogic.MgrPubblicazioneWeb

    Public Shared Function PubblicaFile(ByRef frmPubbl As Form, Server As ServerSito) As Integer

        Dim ris As Integer = 0

        'prima elimino tutti i file inutili 
        'Dim RisCheck As String = String.Empty
        Dim Direc As New DirectoryInfo(FormerPath.PathListinoImg)
        'For Each f As FileInfo In Direc.GetFiles("*.png")
        '    If IsFileUsed(f.Name) = False Then

        '        'RisCheck &= f.Name & ControlChars.NewLine
        '        Try
        '            FileIO.FileSystem.DeleteFile(f.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        '        Catch ex As Exception

        '        End Try
        '    End If
        'Next

        Dim Ftp As New FTPclient(Server.FTPHost,
                                 Server.FTPLogin,
                                 Server.FTPPwd)
        'immagini
        Try

            'prendo tutti i file in pathimglistino che sono modificati o nuovi dopo quella data e li copio 

            Dim D As New DirectoryInfo(FormerPath.PathListinoImg)

            For Each f As FileInfo In D.GetFiles("*.png")

                Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, Server.DataUltimaPubbl, f.CreationTime)
                ' Dim IntervalloDallaModifica As Long = DateDiff(DateInterval.Second, DataRif, f.LastAccessTime)
                Dim PathRemotoFile As String = "tipografiaformer.it/listino/img/" & f.Name
                If IntervalloDallaCreazione > 0 Then 'Or IntervalloDallaModifica > 0 Then

                    'qui lo devo pubblicare
                    MgrIO.FtpTransfer(frmPubbl, Ftp, f.FullName, PathRemotoFile, enTipoOpFTP.Upload)

                End If

            Next

            For Each f As FileInfo In D.GetFiles("*.jpg")

                Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, Server.DataUltimaPubbl, f.CreationTime)
                ' Dim IntervalloDallaModifica As Long = DateDiff(DateInterval.Second, DataRif, f.LastAccessTime)
                Dim PathRemotoFile As String = "tipografiaformer.it/listino/img/" & f.Name
                If IntervalloDallaCreazione > 0 Then 'Or IntervalloDallaModifica > 0 Then

                    'qui lo devo pubblicare
                    MgrIO.FtpTransfer(frmPubbl, Ftp, f.FullName, PathRemotoFile, enTipoOpFTP.Upload)

                End If

            Next



        Catch ex As Exception
            ris = 1
        End Try

        'template
        Try
            Dim D As New DirectoryInfo(FormerPath.PathListinoTemplate)

            For Each f As FileInfo In D.GetFiles("*.pdf")

                Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, Server.DataUltimaPubbl, f.CreationTime)
                ' Dim IntervalloDallaModifica As Long = DateDiff(DateInterval.Second, DataRif, f.LastAccessTime)

                If IntervalloDallaCreazione > 0 Then 'Or IntervalloDallaModifica > 0 Then
                    Dim PathRemotoFile As String = "tipografiaformer.it/listino/template/" & f.Name
                    Dim PathRemotoFilePreview As String = "tipografiaformer.it/listino/template/" & f.Name & ".jpg"
                    Dim PathPreview As String = FormerPath.PathListinoTemplate & f.Name & ".jpg"

                    Try
                        'qui potrebbe andare in errore per determinati pdf 
                        FormerHelper.PDF.GetPdfThumbnail(f.FullName, PathPreview)
                    Catch ex As Exception

                    End Try
                    MgrIO.FtpTransfer(frmPubbl, Ftp, f.FullName, PathRemotoFile, enTipoOpFTP.Upload)
                    If File.Exists(PathPreview) Then MgrIO.FtpTransfer(frmPubbl, Ftp, PathPreview, PathRemotoFilePreview, enTipoOpFTP.Upload)
                End If

            Next

        Catch ex As Exception

        End Try

        'foto hd
        'prima di pubblicare le foto sincronizzo le cartelle delle foto hd con quelle dei listini base generati
        'e pubblico di ogni cartella solo quelli generati e non i sorgenti

        Using mgr As New ListinoBaseDAO
            Dim l As List(Of ListinoBase) = mgr.FindAll(New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0))

            For Each singLb In l
                For Each lb In singLb.ListiniBaseFigli
                    Dim pathStart As String = FormerPath.PathListinoFoto & singLb.IdListinoBase
                    Dim pathEnd As String = FormerPath.PathListinoFoto & lb.IdListinoBase
                    FormerHelper.File.CreateLongPath(pathEnd & "\")
                    Dim dSoon As New DirectoryInfo(pathEnd)
                    For Each singfile In dSoon.GetFiles
                        Try
                            File.Delete(singfile.FullName)
                        Catch ex As Exception

                        End Try
                    Next
                    If Directory.Exists(pathStart) Then
                        Dim d As New DirectoryInfo(pathStart)
                        For Each f In d.GetFiles
                            If f.Extension.ToLower = ".jpg" OrElse f.Extension.ToLower = ".png" Then
                                'file da copiare

                                If File.Exists(pathEnd & "\" & f.Name) = False Then
                                    File.Copy(pathStart & "\" & f.Name, pathEnd & "\" & f.Name)
                                End If
                            End If
                        Next
                    End If
                Next
            Next

        End Using

        Try
            Dim BufferFotoHDScartate As String = String.Empty
            Dim D As New DirectoryInfo(FormerPath.PathListinoFoto)
            'qui devo ciclare per ogni cartella
            For Each DiNt As DirectoryInfo In D.GetDirectories()

                Dim IdLB As Integer = DiNt.Name

                Using lb As New ListinoBase
                    lb.Read(IdLB)
                    If lb.IdListinoBaseSource <> 0 Then

                        Dim PathRemotoDir As String = "tipografiaformer.it/listino/foto/" & DiNt.Name
                        Dim ListaFileOnline As New List(Of String)

                        For Each f As FileInfo In DiNt.GetFiles("*.*")

                            If f.Extension.ToLower = ".jpg" Or f.Extension.ToLower = ".png" Then

                                If f.Length < 200000 Then

                                    Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, Server.DataUltimaPubbl, f.CreationTime)
                                    ' Dim IntervalloDallaModifica As Long = DateDiff(DateInterval.Second, DataRif, f.LastAccessTime)

                                    Dim NomeNormalizzato As String = FormerHelper.Web.NormalizzaNomeFile(f.Name)
                                    Dim PathFileFotoHD As String = f.DirectoryName
                                    Dim PathNormalizzato As String = PathFileFotoHD & "\" & NomeNormalizzato

                                    If PathNormalizzato <> f.FullName Then
                                        FileSystem.Rename(f.FullName, PathNormalizzato)
                                    End If

                                    ListaFileOnline.Add(NomeNormalizzato)

                                    Dim PathRemotoFile As String = "tipografiaformer.it/listino/foto/" & DiNt.Name & "/" & NomeNormalizzato

                                    Try
                                        If Ftp.FtpFileExists(PathRemotoFile) = False Then
                                            Try
                                                Ftp.FtpCreateDirectory(PathRemotoDir)
                                            Catch ex As Exception

                                            End Try

                                            MgrIO.FtpTransfer(frmPubbl, Ftp, PathNormalizzato, PathRemotoFile, enTipoOpFTP.Upload)

                                        End If
                                    Catch ex As Exception

                                    End Try




                                    'If IntervalloDallaCreazione > 0 Then 'Or IntervalloDallaModifica > 0 Then
                                    '    Try
                                    '        Ftp.FtpCreateDirectory(PathRemotoDir)
                                    '    Catch ex As Exception

                                    '    End Try
                                    '    MgrIO.FtpTransfer(frmPubbl, Ftp, f.FullName, PathRemotoFile, enTipoOpFTP.Upload)
                                    'End If

                                Else

                                    BufferFotoHDScartate &= "La foto '" & f.FullName & "' del peso di " & f.Length & " byte è stata scartata nella pubblicazione." & ControlChars.NewLine

                                End If

                            End If
                        Next

                        Try
                            Dim x As FTPdirectory = Ftp.ListDirectoryDetail("/" & PathRemotoDir)

                            For Each ss As FTPfileInfo In x.GetFiles

                                '                                    Dim NomeNormalizzato As String = FormerHelper.Web.NormalizzaNomeFile(f.Name)
                                Dim PathInterno As String = FormerPath.PathListinoFoto & DiNt.Name & "\" & FormerHelper.Web.NormalizzaNomeFile(ss.Filename)

                                If File.Exists(PathInterno) = False Then
                                    Try
                                        Dim PathRemoto As String = ss.Path & "/" & ss.Filename

                                        Ftp.FtpDelete(PathRemoto)
                                    Catch ex As Exception

                                    End Try
                                End If

                            Next
                        Catch ex As Exception

                        End Try

                        'Dim ListaFile As Collections.Generic.List(Of String)
                        'ListaFile = Ftp.ListDirectory("/" & PathRemotoDir)
                        'For Each FileRemoto As String In ListaFile
                        '    If FileRemoto.ToLower.EndsWith("jpg") Or FileRemoto.ToLower.EndsWith("png") Then
                        '        If File.Exists(DiNt.FullName & "\" & FileRemoto) = False Then
                        '            Ftp.FtpDelete(ss.FullName)
                        '            Ftp.FtpDelete("/" & PathRemotoDir & "/" & FileRemoto)
                        '        End If
                        '    End If
                        'Next

                    End If
                End Using



            Next

            If BufferFotoHDScartate.Length Then

                Dim NomeTxtTemp As String = FormerPath.PathTempLocale & FormerHelper.File.GetNomeFileTemp(".txt")

                Using w As New StreamWriter(NomeTxtTemp)

                    w.Write(BufferFotoHDScartate)

                End Using

                FormerHelper.File.ShellExtended(NomeTxtTemp)


            End If
        Catch ex As Exception

        End Try

        Ftp = Nothing

        Return ris

    End Function

    'Private Shared ConnessioneRemota As SqlConnection
    'Private Shared _ConnLocale As SqlConnection
    'Private Shared _WebTrans As SqlTransaction

    'Public Shared Function FixPercentualiAdattamentoPrePubblicazione() As Integer
    '    Dim TotFixed As Integer = 0
    '    Using mgr As New ListinoBaseDAO
    '        Dim l As List(Of ListinoBase) = mgr.GetAll()

    '        For Each Lb As ListinoBase In l

    '            Lb.CaricaLavorazioni()
    '            Lb.NumFacciate = Lb.FaccMin
    '            Dim Altezza As Integer = 0
    '            Dim Larghezza As Integer = 0
    '            If Lb.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
    '                Altezza = 100
    '                Larghezza = 100
    '            End If

    '            Dim Ris As RisListinoBase = MgrPreventivazioneB.CalcolaListinoBase(Lb,
    '                                                   Lb.LavorazioniBaseB,
    '                                                   Nothing,
    '                                                   Altezza,
    '                                                   Larghezza,
    '                                                   True)

    '            Dim Val1 As Decimal = Lb.v1 - Ris.PrezzoLavObbl1
    '            Dim Val2 As Decimal = Lb.v2 - Ris.PrezzoLavObbl2
    '            Dim Val3 As Decimal = Lb.v3 - Ris.PrezzoLavObbl3
    '            Dim Val4 As Decimal = Lb.v4 - Ris.PrezzoLavObbl4
    '            Dim Val5 As Decimal = Lb.v5 - Ris.PrezzoLavObbl5
    '            Dim Val6 As Decimal = Lb.v6 - Ris.PrezzoLavObbl6

    '            Dim p1 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val1, Ris.PrezzoRivCalc1)
    '            Dim p2 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val2, Ris.PrezzoRivCalc2)
    '            Dim p3 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val3, Ris.PrezzoRivCalc3)
    '            Dim p4 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val4, Ris.PrezzoRivCalc4)
    '            Dim p5 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val5, Ris.PrezzoRivCalc5)
    '            Dim p6 As Single = MgrPreventivazioneB.CalcolaPercScarto(Val6, Ris.PrezzoRivCalc6)

    '            Dim Anomalia As Boolean = False
    '            If p1 <> Lb.p1 Then
    '                Anomalia = True
    '            End If
    '            If p2 <> Lb.p2 Then
    '                Anomalia = True
    '            End If
    '            If p3 <> Lb.p3 Then
    '                Anomalia = True
    '            End If
    '            If p4 <> Lb.p4 Then
    '                Anomalia = True
    '            End If
    '            If p5 <> Lb.p5 Then
    '                Anomalia = True
    '            End If
    '            If p6 <> Lb.p6 Then
    '                Anomalia = True
    '            End If

    '            If Anomalia Then
    '                TotFixed += 1

    '                Lb.p1 = p1
    '                Lb.p2 = p2
    '                Lb.p3 = p3
    '                Lb.p4 = p4
    '                Lb.p5 = p5
    '                Lb.p6 = p6
    '                Lb.Save()

    '            End If
    '        Next
    '    End Using

    '    Return TotFixed
    'End Function

    'Private Shared Sub RipulisciPath(TabOrig As String, Optional NomeCampo As String = "imgRif")

    '    Dim SqlC As New SqlCommand("UPDATE " & TabOrig & " SET " & NomeCampo & " = REVERSE(SUBSTRING(REVERSE(" & NomeCampo & "),0,CHARINDEX('\',REVERSE(" & NomeCampo & "))))", ConnessioneRemota)
    '    If UsaTrans Then SqlC.Transaction = _WebTrans
    '    SqlC.ExecuteNonQuery()
    '    SqlC.Dispose()

    'End Sub

    'Private Shared Sub PulisciListiniBozza()

    '    Using SqlC As New SqlCommand("DELETE FROM T_ListinoBase WHERE IdPrev = 0 ", ConnessioneRemota)
    '        If UsaTrans Then SqlC.Transaction = _WebTrans
    '        SqlC.ExecuteNonQuery()
    '    End Using

    'End Sub

    'Private Shared Sub PulisciListiniDisattivati()

    '    Using SqlC As New SqlCommand("DELETE FROM T_ListinoBase WHERE Disattivo <> 0 ", ConnessioneRemota)
    '        If UsaTrans Then SqlC.Transaction = _WebTrans
    '        SqlC.ExecuteNonQuery()
    '    End Using

    'End Sub

    'Private Shared Sub ReplicaTabella(TabOrig As String, Optional TabDest As String = "")
    '    Try
    '        If TabDest.Length = 0 Then TabDest = TabOrig
    '        Dim dbCommand As New SqlCommand("SELECT * FROM " & TabOrig, _ConnLocale)
    '        Dim dr As SqlDataReader = dbCommand.ExecuteReader

    '        Dim SqlC As New SqlCommand("DELETE FROM " & TabDest, ConnessioneRemota)
    '        If UsaTrans Then SqlC.Transaction = _WebTrans
    '        SqlC.ExecuteNonQuery()
    '        SqlC.Dispose()
    '        Try
    '            Using cs As SqlCommand = New SqlCommand("SET IDENTITY_INSERT " & TabDest & " ON", ConnessioneRemota)
    '                If UsaTrans Then cs.Transaction = _WebTrans
    '                cs.ExecuteNonQuery()

    '                cs.Dispose()
    '            End Using
    '        Catch ex As Exception

    '        End Try

    '        Dim bulkCopy As SqlBulkCopy

    '        If UsaTrans Then
    '            bulkCopy = New SqlBulkCopy(ConnessioneRemota, SqlBulkCopyOptions.KeepIdentity, _WebTrans)
    '        Else
    '            bulkCopy = New SqlBulkCopy(ConnessioneRemota.ConnectionString, SqlBulkCopyOptions.KeepIdentity)
    '        End If

    '        bulkCopy.DestinationTableName = TabDest

    '        bulkCopy.WriteToServer(dr)
    '        dr.Close()
    '        dbCommand.Dispose()

    '        Try
    '            Dim cs = New SqlCommand("SET IDENTITY_INSERT " & TabDest & " OFF", ConnessioneRemota)
    '            If UsaTrans Then cs.Transaction = _WebTrans
    '            cs.ExecuteNonQuery()

    '            cs.Dispose()
    '            cs = Nothing

    '        Catch ex As Exception

    '        End Try

    '        bulkCopy.Close()
    '    Catch ex As Exception
    '        Throw New ApplicationException(TabOrig, ex)
    '    End Try


    'End Sub

    'Private Shared LastConnectionString As String = String.Empty

    'Public Shared Function ApriConnessioneRemota(Server As ServerSito) As Integer
    '    Dim ris As Integer = 0
    '    Try
    '        Dim UseThisString As String = String.Empty
    '        If Not Server Is Nothing Then
    '            UseThisString = Server.SQLConnectionString
    '            LastConnectionString = Server.SQLConnectionString
    '        Else
    '            UseThisString = LastConnectionString
    '        End If
    '        ConnessioneRemota = New SqlConnection(UseThisString) 'destination connection
    '        ConnessioneRemota.Open()
    '    Catch ex As Exception
    '        MessageBox.Show("ERRORE: " & ex.Message)
    '        ris = 1
    '    End Try
    '    Return ris
    'End Function

    'Public Shared Sub ChiudiConnessioneRemota()
    '    Try
    '        ConnessioneRemota.Close()
    '        ConnessioneRemota.Dispose()
    '        ConnessioneRemota = Nothing
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Public Shared Function RiControllaListiniBase(Optional IdListinoBaseSpecifico As Integer = 0) As Integer
    '    Dim RisModificati As Integer = 0
    '    Using mgr As New ListinoBaseDAO

    '        Dim p As LUNA.LunaSearchParameter = Nothing

    '        If IdListinoBaseSpecifico Then
    '            p = New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBase, IdListinoBaseSpecifico)
    '        End If

    '        Dim l As List(Of ListinoBase) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.VMotoreCalcolo, MgrPreventivazioneB.VMotoreCalcolo, "<>"),
    '                                                    p)

    '        'qui ho tutti i listinibase non compatibili
    '        For Each lb As ListinoBase In l

    '            'qui devo ricalcolare le percentuali di ricarico di ogni quantità
    '            lb.CaricaLavorazioni()
    '            lb.NumFacciate = lb.FaccMin

    '            Dim V1 As Single = lb.p1
    '            Dim V2 As Single = lb.p2
    '            Dim V3 As Single = lb.p3
    '            Dim V4 As Single = lb.p4
    '            Dim V5 As Single = lb.p5
    '            Dim V6 As Single = lb.p6

    '            Dim ris As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(lb,
    '                                                                          lb.LavorazioniBaseB)

    '            If lb.p1 <> V1 OrElse
    '               lb.p2 <> V2 OrElse
    '               lb.p3 <> V3 OrElse
    '               lb.p4 <> V4 OrElse
    '               lb.p5 <> V5 OrElse
    '               lb.p6 <> V6 Then

    '                RisModificati += 1

    '            End If

    '            lb.VMotoreCalcolo = MgrPreventivazioneB.VMotoreCalcolo
    '            lb.Save()

    '        Next

    '    End Using
    '    Return RisModificati
    'End Function

    'Public Shared Function ListaImgTemporaneeInUso() As List(Of FileTemporaneoInUso)

    '    Dim ris As New List(Of FileTemporaneoInUso)

    '    Dim LPRif As New LUNA.LunaSearchParameter(LFM.Preventivazione.ImgRif, "%" & FormerConst.PrefissoFileListinoTemp & "%", "like")

    '    Using mgr As New PreventivazioniDAO
    '        Dim l As List(Of Preventivazione) = mgr.FindAll(LPRif)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Descrizione = singRis.Descrizione
    '            ft.Path = singRis.ImgRif
    '            ft.TipoOggettoListino = enTipoOggettoListino.Preventivazione
    '            ft.IdRif = singRis.IdPrev
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New LavorazioniDAO
    '        Dim l As List(Of Lavorazione) = mgr.FindAll(LPRif)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Path = singRis.ImgRif
    '            ft.Descrizione = singRis.Descrizione
    '            ft.TipoOggettoListino = enTipoOggettoListino.Lavorazione
    '            ft.IdRif = singRis.IdLavoro
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New MacchinariDAO
    '        Dim l As List(Of Macchinario) = mgr.FindAll(LPRif)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Path = singRis.ImgRif
    '            ft.Descrizione = singRis.Descrizione
    '            ft.TipoOggettoListino = enTipoOggettoListino.Macchinario
    '            ft.IdRif = singRis.IdMacchinario
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New CatProdDAO
    '        Dim LPCat As New LUNA.LunaSearchParameter(LFM.CatProd.ImgCat, "%" & FormerConst.PrefissoFileListinoTemp & "%", "like")
    '        Dim l As List(Of CatProd) = mgr.FindAll(LPCat)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Path = singRis.ImgCat
    '            ft.Descrizione = singRis.Descrizione
    '            ft.TipoOggettoListino = enTipoOggettoListino.CatProd
    '            ft.IdRif = singRis.IdCatProd
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New ColoriStampaDAO
    '        Dim l As List(Of ColoreStampa) = mgr.FindAll(LPRif)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Path = singRis.imgrif
    '            ft.Descrizione = singRis.Descrizione
    '            ft.TipoOggettoListino = enTipoOggettoListino.ColoreStampa
    '            ft.IdRif = singRis.IdColoreStampa
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New FormatiProdottoDAO
    '        Dim l As List(Of FormatoProdotto) = mgr.FindAll(LPRif)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Path = singRis.ImgRif
    '            ft.Descrizione = singRis.Formato
    '            ft.TipoOggettoListino = enTipoOggettoListino.FormatoProdotto
    '            ft.IdRif = singRis.IdFormProd
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New TipiCartaDAO
    '        Dim l As List(Of TipoCarta) = mgr.FindAll(LPRif)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Path = singRis.ImgRif
    '            ft.Descrizione = singRis.Tipologia
    '            ft.TipoOggettoListino = enTipoOggettoListino.TipoCarta
    '            ft.IdRif = singRis.IdTipoCarta
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New CategorieFustelleDAO
    '        Dim l As List(Of CategoriaFustella) = mgr.FindAll(LPRif)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Path = singRis.ImgRif
    '            ft.Descrizione = singRis.Categoria
    '            ft.TipoOggettoListino = enTipoOggettoListino.CategoriaFustella
    '            ft.IdRif = singRis.IdCatFustella
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New TipoFustelleDAO
    '        Dim l As List(Of TipoFustella) = mgr.FindAll(LPRif)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Path = singRis.ImgRif
    '            ft.Descrizione = singRis.Riassunto
    '            ft.TipoOggettoListino = enTipoOggettoListino.TipoFustella
    '            ft.IdRif = singRis.IdCatFustella
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New CatLavDAO
    '        Dim LPCat As New LUNA.LunaSearchParameter(LFM.CatLav.FileLavNonSelezionata, "%" & FormerConst.PrefissoFileListinoTemp & "%", "like")
    '        Dim l As List(Of CatLav) = mgr.FindAll(LPCat)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Descrizione = singRis.Descrizione
    '            ft.Path = singRis.FileLavNonSelezionata
    '            ft.TipoOggettoListino = enTipoOggettoListino.CatLav
    '            ft.IdRif = singRis.IdCatLav
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Using mgr As New CatFormatoProdottoDAO
    '        Dim l As List(Of CatFormatoProdotto) = mgr.FindAll(LPRif)

    '        For Each singRis In l
    '            Dim ft As New FileTemporaneoInUso
    '            ft.Path = singRis.ImgRif
    '            ft.Descrizione = singRis.Nome
    '            ft.TipoOggettoListino = enTipoOggettoListino.CatFormatoProdotto
    '            ft.IdRif = singRis.IdCatFormatoProdotto
    '            ris.Add(ft)
    '        Next
    '    End Using

    '    Return ris

    'End Function


    'Private Shared Function IsFileUsed(Path As String) As Boolean
    '    'T_LISTINOBASE()
    '    't_preventivazione()
    '    'T_LAVORI()
    '    'T_MACCHINARI()
    '    'Td_CatPROD()
    '    'Td_Coloristampa()
    '    'Td_formatoProdotto()
    '    'Td_tipocarta()
    '    Dim ris As Boolean = False

    '    Dim LPSito As New LUNA.LunaSearchParameter("ImgSito", "%" & Path, "like")
    '    Dim LPRif As New LUNA.LunaSearchParameter("ImgRif", "%" & Path, "like")

    '    Using mgr As New ListinoBaseDAO
    '        Dim l As List(Of ListinoBase) = mgr.FindAll(LPSito)
    '        If l.Count Then ris = True
    '    End Using

    '    If ris = False Then
    '        Using mgr As New PreventivazioniDAO
    '            Dim l As List(Of Preventivazione) = mgr.FindAll(LPSito)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New PreventivazioniDAO
    '            Dim l As List(Of Preventivazione) = mgr.FindAll(LPRif)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New LavorazioniDAO
    '            Dim l As List(Of Lavorazione) = mgr.FindAll(LPRif)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New MacchinariDAO
    '            Dim l As List(Of Macchinario) = mgr.FindAll(LPRif)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Dim LPCat As New LUNA.LunaSearchParameter(LFM.CatProd.ImgCat, "%" & Path, "like")
    '        Using mgr As New CatProdDAO
    '            Dim l As List(Of CatProd) = mgr.FindAll(LPCat)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New ColoriStampaDAO
    '            Dim l As List(Of ColoreStampa) = mgr.FindAll(LPRif)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New FormatiProdottoDAO
    '            Dim l As List(Of FormatoProdotto) = mgr.FindAll(LPRif)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New TipiCartaDAO
    '            Dim l As List(Of TipoCarta) = mgr.FindAll(LPRif)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New CategorieFustelleDAO
    '            Dim l As List(Of CategoriaFustella) = mgr.FindAll(LPRif)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New TipoFustelleDAO
    '            Dim l As List(Of TipoFustella) = mgr.FindAll(LPRif)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New CatLavDAO
    '            Dim LPCat As New LUNA.LunaSearchParameter(LFM.CatLav.FileLavNonSelezionata, "%" & Path, "like")
    '            Dim l As List(Of CatLav) = mgr.FindAll(LPCat)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Dim LPCat As New LUNA.LunaSearchParameter(LFM.Lavorazione.ImgZoom, "%" & Path, "like")
    '        Using mgr As New LavorazioniDAO
    '            Dim l As List(Of Lavorazione) = mgr.FindAll(LPCat)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    If ris = False Then
    '        Using mgr As New CatFormatoProdottoDAO
    '            Dim l As List(Of CatFormatoProdotto) = mgr.FindAll(LPRif)
    '            If l.Count Then ris = True
    '        End Using
    '    End If

    '    Return ris
    'End Function



    'Private Shared UsaTrans As Boolean = True

    'Public Shared Sub ResettaLastUpdate()

    '    Using mgr As New ListinoBaseDAO
    '        mgr.ResetLastUpdate()
    '    End Using

    'End Sub

    'Public Shared Function PubblicaIndiciRicerca(Optional SoloSuQuestiListini As List(Of ListinoBase) = Nothing) As Integer

    '    Dim ris As Integer = 0
    '    'prima elimino tutti gli indici presenti
    '    'poi ciclo per ognuno dei listini base e creo per ognuno un indice calcolando i prezzi

    '    'Using tb As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox()
    '    Try
    '        'tb.TransactionBegin()

    '        If ConnessioneRemota Is Nothing OrElse ConnessioneRemota.State <> ConnectionState.Open Then
    '            ApriConnessioneRemota(Nothing)
    '        End If

    '        Using Imgr As New FW.IndiciRicercaDAO(ConnessioneRemota)

    '            If SoloSuQuestiListini Is Nothing Then
    '                Imgr.DeleteAll()
    '            Else
    '                For Each lb As ListinoBase In SoloSuQuestiListini
    '                    Imgr.DeleteByIdListinoBase(lb.IdListinoBase)
    '                Next

    '            End If

    '            Dim l As List(Of ListinoBase) = Nothing
    '            Using mgr As New ListinoBaseDAO()
    '                l = mgr.ListiniUtilizzabili

    '                If Not SoloSuQuestiListini Is Nothing Then
    '                    l = l.FindAll(Function(x) SoloSuQuestiListini.FindAll(Function(z) z.IdListinoBase = x.IdListinoBase).Count)
    '                End If

    '                For Each Lb As ListinoBase In l

    '                    Lb.CaricaLavorazioni()

    '                    'qui creo l'indice
    '                    Dim I As New FW.IndiceRicerca()
    '                    I.NomeListino = Lb.Nome
    '                    I.IdListinoBase = Lb.IdListinoBase
    '                    I.IdPrev = Lb.IdPrev
    '                    I.InEvidenza = Lb.InEvidenza
    '                    I.PercCoupon = Lb.Preventivazione.PercCoupon
    '                    I.ProdottoFinito = IIf(Lb.FormatoProdotto.ProdottoFinito, enSiNo.Si, enSiNo.No)

    '                    'per il prezzo prendo sempre la percentuale normal
    '                    'per le quantita cerco le tre piu vendute se ci sono
    '                    'se non ci sono prendo prima seconda e terza nel listino base
    '                    Dim QtaToCalc As Integer() = {0, 0, 0}
    '                    Dim TotOrdini As Integer = 0

    '                    If Lb.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then

    '                        QtaToCalc(0) = 500
    '                        QtaToCalc(1) = 1000
    '                        QtaToCalc(2) = 5000

    '                    Else
    '                        QtaToCalc(0) = Lb.qta1
    '                        QtaToCalc(1) = Lb.qta2
    '                        QtaToCalc(2) = Lb.qta3

    '                        'qui trovo le quantita piu vendute del prodotto
    '                        'If Lb.IdListinoBase = 254 Then Stop
    '                        Using mgrO As New OrdiniDAO
    '                            mgrO.QtaPiuVendutaListinoBase(QtaToCalc, Lb.IdListinoBase)
    '                            TotOrdini = mgrO.NumeroTotaleOrdiniListinoBase(Lb.IdListinoBase)
    '                        End Using

    '                        Array.Sort(QtaToCalc)

    '                    End If

    '                    I.Qta1 = QtaToCalc(0)
    '                    I.Qta2 = QtaToCalc(1)
    '                    I.Qta3 = QtaToCalc(2)

    '                    Dim R As RisPrezzoIntermedio = CalcolaPrezzi(Lb, I.Qta1)

    '                    I.Prezzo1Riv = Math.Round(R.PrezzoRiv * FormerPricingHelper.PercentualeNormale)
    '                    I.Prezzo1 = Math.Round(R.PrezzoPubbl * FormerPricingHelper.PercentualeNormale)

    '                    R = CalcolaPrezzi(Lb, I.Qta2)
    '                    I.Prezzo2Riv = Math.Round(R.PrezzoRiv * FormerPricingHelper.PercentualeNormale)
    '                    I.Prezzo2 = Math.Round(R.PrezzoPubbl * FormerPricingHelper.PercentualeNormale)

    '                    R = CalcolaPrezzi(Lb, I.Qta3)
    '                    I.Prezzo3Riv = Math.Round(R.PrezzoRiv * FormerPricingHelper.PercentualeNormale)
    '                    I.Prezzo3 = Math.Round(R.PrezzoPubbl * FormerPricingHelper.PercentualeNormale)
    '                    I.TotOrdini = TotOrdini

    '                    Imgr.Save(I)
    '                Next
    '            End Using
    '        End Using
    '        'tb.TransactionCommit()
    '    Catch ex As Exception
    '        'tb.TransactionRollBack()

    '        ManageError(ex)
    '        ris = 1
    '    End Try
    '    'End Using

    'End Function

    'Private Shared Function CalcolaPrezzi(L As ListinoBase,
    '                                      Qta As Single) As RisPrezzoIntermedio
    '    'Dim QtaRichiesta As Integer = Convert.ToInt32(ddlQta.SelectedValue)

    '    Dim listaBaseB As List(Of ILavorazioneB) = L.LavorazioniBaseB

    '    'Dim _Risultato As RisultatoListinoBase
    '    '_Risultato = MgrPreventivazioneB.CalcolaPrezzi(L, listaBaseB, , False)

    '    'Dim R As RisultatoPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoIntermedio(Qta,
    '    '                                                                                 L,
    '    '                                                                                 _Risultato)
    '    L.NumFacciate = L.FaccMin

    '    Dim R As RisPrezzoIntermedio = Nothing

    '    If L.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
    '        Dim QtaRichiesta As Single = 0
    '        Dim QtaSecondaria As Integer = 0

    '        Dim LatoFisso As Integer = (L.FormatoProdotto.FormatoCarta.Larghezza * 10)
    '        Dim LatoRiferimento As Single = Math.Sqrt(FormerLib.FormerConst.EtichetteCmQuadri.CmQuadriEsempio)

    '        QtaSecondaria = ((LatoRiferimento * LatoRiferimento)) * Qta
    '        QtaRichiesta = MgrCalcoliTecnici.CalcolaCmQuadri(LatoRiferimento,
    '                                                                        LatoRiferimento,
    '                                                                        enTipoOrientamento.Orizzontale,
    '                                                                        LatoFisso,
    '                                                                        QtaRichiesta)
    '        R = MgrPreventivazioneB.CalcolaPrezzoFinale(L, Qta, listaBaseB, QtaSecondaria,, False,, LatoRiferimento, LatoRiferimento)

    '    Else
    '        R = MgrPreventivazioneB.CalcolaPrezzoFinale(L, Qta, listaBaseB,,, False)
    '    End If

    '    Return R

    'End Function

    'Public Shared Function AggiornaParametriListinoPDF() As Integer
    '    Dim ris As Integer = 0

    '    Try
    '        '_ConnLocale = LUNA.LunaContext.Connection

    '        If ConnessioneRemota Is Nothing OrElse ConnessioneRemota.State <> ConnectionState.Open Then
    '            ApriConnessioneRemota(Nothing)
    '        End If

    '        Using mgrV As New FW.ParamListiniDAO(ConnessioneRemota)

    '            mgrV.DeleteAll()

    '            Using mgr As New ParamListiniDAO
    '                Dim l As List(Of ParamListino) = mgr.GetAll()

    '                For Each Par As ParamListino In l
    '                    'esplicito la connessione remota

    '                    Dim parW As New FW.ParamListino
    '                    parW.IdUt = 0
    '                    parW.IdPrev = Par.IdPrev
    '                    parW.Qta1 = Par.Qta1
    '                    parW.Qta2 = Par.Qta2
    '                    parW.Qta3 = Par.Qta3
    '                    parW.Qta4 = Par.Qta4
    '                    parW.Qta5 = Par.Qta5
    '                    mgrV.Save(parW)

    '                Next

    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        ManageError(ex)
    '        ris = 1
    '    End Try

    '    Return ris
    'End Function

    'Public Shared Function Pubblica() As Integer
    '    Dim ris As Integer = 0
    '    Try
    '        'Dim strConn As String = Postazione.StrConnWeb

    '        'ConnessioneRemota = New SqlConnection(strConn) 'destination connection
    '        _ConnLocale = LUNA.LunaContext.Connection  ' source connection
    '        ' ConnessioneRemota.Open()

    '        If UsaTrans Then _WebTrans = ConnessioneRemota.BeginTransaction()
    '        'qui ho le connessioni aperte 
    '        ReplicaTabella("T_Curvaatt")
    '        ReplicaTabella("T_ListinoBase")
    '        ReplicaTabella("T_Preventivazione")
    '        ReplicaTabella("Td_Formato")
    '        ReplicaTabella("Td_FormatoCarta")
    '        ReplicaTabella("Td_FormatoProdotto")
    '        ReplicaTabella("Td_TipoCarta")
    '        ReplicaTabella("Td_ColoriStampa")
    '        ReplicaTabella("T_lavori")
    '        ReplicaTabella("Tr_LavPrev")
    '        ReplicaTabella("Tr_Resa")
    '        ReplicaTabella("T_Macchinari")
    '        ReplicaTabella("Td_CatLav")
    '        ReplicaTabella("T_Corriere")
    '        ReplicaTabella("T_PrezziLavoro")
    '        ReplicaTabella("Tr_CartaComposta")
    '        ReplicaTabella("Tr_PrevListino")
    '        ReplicaTabella("Glossario")
    '        ReplicaTabella("T_TipoFustella")
    '        ReplicaTabella("Td_TipoPagamenti")
    '        ReplicaTabella("T_CapCorr")
    '        ReplicaTabella("Td_CatFustelle")
    '        ReplicaTabella("Tr_CatTipoFustella")
    '        ReplicaTabella("ModelliCubetti")
    '        ReplicaTabella("T_Omaggi")
    '        ReplicaTabella("TD_CatFormatoProdotto")
    '        ReplicaTabella("TR_DefaultFormatoPrev")
    '        ReplicaTabella("T_CatVirtuali")
    '        ReplicaTabella("Tr_catvlistini")
    '        ReplicaTabella("Tr_FormatoMacchinario")
    '        ReplicaTabella("T_GruppiVarianti")
    '        ReplicaTabella("Tr_GruppoVarianteRif")

    '        PulisciListiniBozza()

    '        PulisciListiniDisattivati()

    '        'qui ripulisco i path da Postazione.PathImgListino
    '        RipulisciPath("T_Preventivazione")
    '        RipulisciPath("T_Preventivazione", "imgSito")
    '        RipulisciPath("T_ListinoBase", "imgSito")
    '        RipulisciPath("Td_FormatoProdotto")
    '        RipulisciPath("Td_FormatoProdotto", "PdfTemplate")
    '        RipulisciPath("Td_FormatoProdotto", "PdfTemplate3D")
    '        RipulisciPath("Td_TipoCarta")
    '        RipulisciPath("Td_ColoriStampa")
    '        RipulisciPath("T_lavori")
    '        RipulisciPath("T_TipoFustella")
    '        RipulisciPath("Td_CatFustelle")
    '        RipulisciPath("TD_CatLav", "FileLavNonSelezionata")
    '        RipulisciPath("T_Lavori", "ImgZoom")
    '        RipulisciPath("T_TipoFustella", "TemplatePDF")
    '        RipulisciPath("Td_CatFormatoProdotto")
    '        RipulisciPath("T_Macchinari")

    '        If UsaTrans Then _WebTrans.Commit()

    '    Catch ex As Exception
    '        If Not _WebTrans Is Nothing Then
    '            _WebTrans.Rollback()
    '        End If

    '        ManageError(ex)
    '        ris = 1
    '    Finally

    '        'ConnessioneRemota.Close()
    '    End Try
    '    Return ris

    'End Function

End Class
