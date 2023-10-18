Imports FormerLib

Public Class frmMain

    Private Const NomeProcesso As String = "FormerDaemon-Server"
    Private Const PathDemone As String = "C:\Former-Daemon\Server\FormerDaemon-Server.exe"

    'Public udp As System.Net.Sockets.UdpClient = Nothing

    Private WithEvents _P As Process = Nothing

    Public Sub AvviaDemone()


        Try

            _P = New Process

            _P.StartInfo.FileName = PathDemone
            _P.Start()

            btnStart.Enabled = False
            btnStop.Enabled = True

            'tmrStato.Start()
        Catch ex As Exception

        End Try

    End Sub

    'Public Sub Errore() Handles _P.ErrorDataReceived

    '    MessageBox.Show("errore")

    'End Sub

    'Public Sub AreDisposed() Handles _P.Disposed

    '    MessageBox.Show("disposed")

    'End Sub


    'Public Sub AreExited() Handles _P.Exited

    '    MessageBox.Show("exited")

    'End Sub

    Public Sub StopDemone()


        Try
                If Not _P Is Nothing Then
                    _P.CloseMainWindow()
                    _P.Dispose()
                    _P = Nothing
                End If
            Catch ex As Exception

            End Try

            Try
                Dim p() As Process
                p = Process.GetProcessesByName(NomeProcesso)

                For i As Integer = 0 To p.Count - 1
                    Dim r As Process = p(i)
                    Try
                        r.CloseMainWindow()
                    Catch ex As Exception

                    End Try

                    Try
                        r.Close()
                    Catch ex As Exception

                    End Try

                    Try
                        r.Dispose()
                    Catch ex As Exception

                    End Try

                    r = Nothing
                Next

                p = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            btnStart.Enabled = True
            btnStop.Enabled = False

    End Sub

    'Public Sub Start()

    '    Dim p() As Process

    '    p = Process.GetProcessesByName(txtNomeProcesso.Text)
    '    If p.Count > 0 Then
    '        ' Process is running
    '        lblRis.Text = p.Count
    '    Else
    '        ' Process is not running
    '        lblRis.Text = 0
    '    End If

    'End Sub

    Private Sub ntfIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ntfIcon.MouseDoubleClick

        WindowState = FormWindowState.Normal

        AppActivate("FormerDaemon-Launcher")

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        AvviaDemone()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If MessageBox.Show("Confermi la chiusura del demone?", "Chiusura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            StopDemone()
        End If
    End Sub

    Private Sub tmrProc_Tick(sender As Object, e As EventArgs) Handles tmrProc.Tick

        tmrProc.Stop()

        Dim Counter As String = "-"
        Dim CounterInt As Integer = 0
        Try
            Dim p() As Process

            p = Process.GetProcessesByName(NomeProcesso)
            CounterInt = p.Count
            Counter = CounterInt
            p = Nothing
        Catch ex As Exception

        End Try
        lblCountProc.Text = "Processi attivi: " & Counter

        If CounterInt = 0 Then
            icoDemone.BackColor = Color.Red

            If chkMantieniAttivo.Checked Then
                'qui devo lanciarlo 
                AvviaDemone()
            End If

        Else
            icoDemone.BackColor = Color.LightGreen
        End If

        tmrProc.Start()

        'If chkMantieniAttivo.Checked Then
        '    If CounterInt = 0 AndAlso _P Is Nothing Then
        '        AvviaDemone()
        '    End If
        'Else
        '    tmrProc.Start()
        'End If

        '    If p.Count > 0 Then
        '        ' Process is running
        '        lblRis.Text = p.Count
        '    Else
        '        ' Process is not running
        '        lblRis.Text = 0
        '    End If

    End Sub

    Private Sub Carica()

        AvviaDemone()

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Carica()
    End Sub


End Class
