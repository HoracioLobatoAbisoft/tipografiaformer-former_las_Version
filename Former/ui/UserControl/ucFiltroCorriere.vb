Imports FormerLib.FormerEnum
Imports FormerLib

Public Class ucFiltroCorriere
    Inherits ucFormerUserControl

    Public ReadOnly Property CorriereSelezionato As String
        Get
            Dim CorriereSelezionatoStr = String.Empty
            Dim x As cEnum = cmbCorriere.SelectedItem

            Select Case x.Id
                Case 0
                    CorriereSelezionatoStr = String.Empty
                Case enCorriere.GLS
                    CorriereSelezionatoStr = enCorriere.GLS & ", " & enCorriere.PortoAssegnatoGLS & ", " & enCorriere.GLSIsole
                Case enCorriere.Bartolini
                    CorriereSelezionatoStr = enCorriere.Bartolini & ", " & enCorriere.PortoAssegnatoBartolini
            End Select

            Return CorriereSelezionatoStr
        End Get

    End Property

    Public Property CorriereSelezionatoEnum As Integer
        Get
            Dim ris As Integer = 0

            Dim valoreSel As cEnum = cmbCorriere.SelectedItem
            ris = valoreSel.Id

            Return ris
        End Get
        Set(value As Integer)
            MgrControl.SelectIndexComboEnum(cmbCorriere, value)
        End Set
    End Property

    Private Sub CaricaCorrieri()

        Dim L As New List(Of cEnum)
        Dim x As New cEnum

        'x.Id = 0
        'x.Descrizione = "Nessuno"

        'L.Add(x)

        x = New cEnum
        x.Id = 0
        x.Descrizione = "Tutti i Corrieri"

        L.Add(x)

        x = New cEnum
        x.Id = enCorriere.GLS
        x.Descrizione = "Corriere GLS"

        L.Add(x)

        x = New cEnum
        x.Id = enCorriere.Bartolini
        x.Descrizione = "Corriere Bartolini"

        L.Add(x)

        cmbCorriere.DataSource = L

        'cmbCorriere.SelectedValue = _CorriereSelezionato

    End Sub

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        BackColor = Color.White
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        CaricaCorrieri()

    End Sub

    Public Event SelezionatoCorriere(sender As Object)

    Private Sub cmbCorriere_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCorriere.SelectedIndexChanged
        RaiseEvent SelezionatoCorriere(sender)
    End Sub

    Public Sub SelezionaCorriere(C As enCorriere)
        MgrControl.SelectIndexComboEnum(cmbCorriere, C)
    End Sub

End Class
