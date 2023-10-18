Public Class baseFormUsbResponsive
    ' Inherits frmBaseForm
    Private _Ris As Integer

    Public Event ChiaveUSBConnessa()
    Public Event ChiaveUSBDisconnessa()

    Private WM_DEVICECHANGE As Integer = &H219
    Public Enum WM_DEVICECHANGE_WPPARAMS As Integer
        DBT_CONFIGCHANGECANCELED = &H19
        DBT_CONFIGCHANGED = &H18
        DBT_CUSTOMEVENT = &H8006
        DBT_DEVICEARRIVAL = &H8000
        DBT_DEVICEQUERYREMOVE = &H8001
        DBT_DEVICEQUERYREMOVEFAILED = &H8002
        DBT_DEVICEREMOVECOMPLETE = &H8004
        DBT_DEVICEREMOVEPENDING = &H8003
        DBT_DEVICETYPESPECIFIC = &H8005
        DBT_DEVNODES_CHANGED = &H7
        DBT_QUERYCHANGECONFIG = &H17
        DBT_USERDEFINED = &HFFFF
    End Enum

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try
            If m.Msg = WM_DEVICECHANGE Then
                Select Case m.WParam
                    Case WM_DEVICECHANGE_WPPARAMS.DBT_DEVICEARRIVAL
                        RaiseEvent ChiaveUSBConnessa()
                    Case WM_DEVICECHANGE_WPPARAMS.DBT_DEVICEREMOVECOMPLETE
                        RaiseEvent ChiaveUSBDisconnessa()
                End Select
            End If
            MyBase.WndProc(m)
        Catch ex As Exception

        End Try

    End Sub

    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Try
    '        If m.Msg = WM_DEVICECHANGE Then
    '            Select Case m.WParam
    '                Case WM_DEVICECHANGE_WPPARAMS.DBT_DEVICEARRIVAL
    '                    RaiseEvent ChiaveUSBConnessa()
    '                Case WM_DEVICECHANGE_WPPARAMS.DBT_DEVICEREMOVECOMPLETE
    '                    RaiseEvent ChiaveUSBDisconnessa()
    '            End Select
    '        End If
    '        MyBase.WndProc(m)
    '    Catch ex As Exception

    '    End Try

    'End Sub

End Class