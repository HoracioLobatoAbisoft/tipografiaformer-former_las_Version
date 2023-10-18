Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucRepartoWeb
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Event SelezioneCambiata()

    Public Property SelezionaStampaOffset As Boolean
        Get
            Return chkStampaOffset.Checked
        End Get
        Set(value As Boolean)
            chkStampaOffset.Checked = value
        End Set
    End Property

    Public Property SelezionaStampaDigitale As Boolean
        Get
            Return chkStampaDigitale.Checked
        End Get
        Set(value As Boolean)
            chkStampaDigitale.Checked = value
        End Set
    End Property

    Public Property SelezionaPackaging As Boolean
        Get
            Return chkPackaging.Checked
        End Get
        Set(value As Boolean)
            chkPackaging.Checked = value
        End Set
    End Property

    Public Property SelezionaEtichette As Boolean
        Get
            Return chkEtichette.Checked
        End Get
        Set(value As Boolean)
            chkEtichette.Checked = value
        End Set
    End Property

    Public Property SelezionaRicamo As Boolean
        Get
            Return chkRicamo.Checked
        End Get
        Set(value As Boolean)
            chkRicamo.Checked = value
        End Set
    End Property

    Public ReadOnly Property RepartiSelezionatiStr() As String
        Get
            Dim ris As String = String.Empty

            If chkStampaOffset.Checked Then
                ris = enRepartoWeb.StampaOffset & ","
            End If

            If chkStampaDigitale.Checked Then
                ris &= enRepartoWeb.StampaDigitale & ","
            End If

            If chkPackaging.Checked Then
                ris &= enRepartoWeb.Packaging & ","
            End If

            If chkRicamo.Checked Then
                ris &= enRepartoWeb.Ricamo & ","
            End If

            If chkEtichette.Checked Then
                ris &= enRepartoWeb.Etichette
            End If

            ris = ris.TrimEnd(",")

            If ris.Length = 0 Then
                ris = 0
            End If

            ris = "(" & ris & ")"

            Return ris
        End Get
    End Property

    Private Sub chkStampaOffset_CheckedChanged(sender As Object, e As EventArgs) Handles chkStampaOffset.CheckedChanged,
                                                                                        chkEtichette.CheckedChanged,
                                                                                        chkRicamo.CheckedChanged,
                                                                                        chkStampaDigitale.CheckedChanged,
                                                                                        chkPackaging.CheckedChanged

        If sender.focused Then
            RaiseEvent SelezioneCambiata()
        End If

    End Sub
End Class
