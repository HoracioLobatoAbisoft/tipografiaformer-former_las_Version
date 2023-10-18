Imports FormerDALSql
Imports FormerLib.FormerEnum
Public Class ucAnteprimaOperatore
    Inherits ucFormerUserControl

    'Private _Com As Commessa

    'Friend Property Com() As Commessa
    '    Get
    '        Return _Com
    '    End Get
    '    Set(ByVal value As Commessa)
    '        _Com = value
    '    End Set
    'End Property

    'Public Sub Carica(ByVal IdCom As Integer)

    '    Dim x As New Commessa
    '    x.Read(IdCom)
    '    _Com = x

    '    CreaAnteprima()

    'End Sub

    'Friend Sub Carica(ByVal Com As Commessa)

    '    _Com = Com

    '    CreaAnteprima()

    'End Sub

    'Private Sub CreaAnteprima()

    '    Try

    '        If Not _Com Is Nothing Then

    '            CreaRiepilogoCom(_Com, WebPreview, enTipoAnteprima.Breve)
    '            System.Threading.Thread.Sleep(100)
    '            Application.DoEvents()

    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Sub

    Public Sub CaricaDatiAccessori(Optional IdOrd As Integer = 0,
                                   Optional IdCom As Integer = 0)

        CaricaAvanzamento(IdOrd, IdCom)

        CaricaMessaggi(IdOrd, IdCom)

        If IdCom Then

            If tbMain.TabPages.Contains(tpModelloCommessa) = False Then
                tbMain.TabPages.Insert(1, tpModelloCommessa)
            End If
            CaricaModelloCommessa(IdCom)
        Else
            tbMain.TabPages.Remove(tpModelloCommessa)
            'tpModelloCommessa.Visible = False
        End If

    End Sub

    Private Sub CaricaModelloCommessa(IdCom As Integer)

        Using c As New Commessa
            c.Read(IdCom)

            If c.ModelloCommessa.Anteprima.Length Then
                Try
                    pctFronte.Image = Image.FromFile(c.ModelloCommessa.Anteprima)
                Catch ex As Exception

                End Try
            Else
                pctFronte.Image = Nothing
            End If

            If c.ModelloCommessa.AnteprimaR.Length Then
                lblRetro.Visible = True
                Try
                    pctRetro.Image = Image.FromFile(c.ModelloCommessa.AnteprimaR)
                Catch ex As Exception

                End Try
            Else
                lblRetro.Visible = False
                pctRetro.Image = Nothing
            End If

        End Using

    End Sub

    Private Sub CaricaAvanzamento(Optional IdOrd As Integer = 0,
                                  Optional IdCom As Integer = 0)

        Dim l As List(Of LavLog) = Nothing

        If IdOrd Then
            'UcAllegati.Carica(, IdOrd)
            Using O As New Ordine()
                O.Read(IdOrd)
                Using mgr As New LavLogDAO
                    If O.IdCom Then
                        l = mgr.FindAll(LFM.LavLog.Ordine,
                                        New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, O.IdCom),
                                        New LUNA.LunaSearchParameter(LFM.LavLog.DataOraFine, Nothing, " IS "))
                    Else
                        l = New List(Of LavLog)
                    End If

                    Dim lord As List(Of LavLog) = mgr.FindAll(LFM.LavLog.Ordine,
                                                              New LUNA.LunaSearchParameter(LFM.LavLog.IdOrd, IdOrd),
                                                              New LUNA.LunaSearchParameter(LFM.LavLog.DataOraFine, Nothing, " IS "))

                    For Each singLL In lord
                        l.Add(singLL)
                    Next

                End Using
            End Using

        ElseIf IdCom Then
            Using mgr As New LavLogDAO
                l = mgr.FindAll(LFM.LavLog.Ordine,
                                New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, IdCom),
                                New LUNA.LunaSearchParameter(LFM.LavLog.DataOraFine, Nothing, " IS "))

            End Using
        End If

        DgLavori.AutoGenerateColumns = False
        DgLavori.DataSource = l

    End Sub

    Private Sub CaricaMessaggi(Optional IdOrd As Integer = 0, Optional IdCom As Integer = 0)

        If IdOrd Then
            UcAllegati.Carica(, IdOrd)

        ElseIf IdCom Then
            UcAllegati.Carica(IdCom)
        End If

    End Sub

    Public ReadOnly Property WebPrew() As System.Windows.Forms.WebBrowser
        Get
            Return WebPreview
        End Get
    End Property

End Class
