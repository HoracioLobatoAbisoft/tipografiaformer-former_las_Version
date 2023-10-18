Imports System.IO
Imports FormerDALSql

Public Class ucAnteprimaLavoro
    Private _Ord As New Ordine
    Private _Com As New Commessa

    Public ReadOnly Property IdOrd As Integer
        Get
            Dim Ris As Integer = 0
            If Not _Ord Is Nothing Then Ris = _Ord.IdOrd
            Return Ris
        End Get
    End Property

    Public ReadOnly Property IdCom As Integer
        Get
            Dim Ris As Integer = 0
            If Not _Com Is Nothing Then Ris = _Com.IdCom
            Return Ris
        End Get
    End Property

    Public Sub Mostra(Posizione As Point,
                      Optional Ord As Ordine = Nothing,
                      Optional Com As Commessa = Nothing)

        Try

            If Not Ord Is Nothing Then
                If _Ord Is Nothing Then _Ord = New Ordine
                If Ord.IdOrd = 0 Then Exit Sub
                If _Ord.IdOrd <> Ord.IdOrd Then
                    lnkTit.Text = "Ordine " & Ord.IdOrd & " del " & Ord.DataInsStr
                    lblRiga3.Text = "Consegna Prevista: " & Ord.DataConsPrevShort
                    Using mO As New VociRubricaDAO
                        Dim Scoperto As Decimal = mO.CalcolaScopertoOld(Ord.VoceRubrica)
                        'lblRiga2.Text = Ord.VoceRubrica.RagSoc & IIf(Scoperto, " (-" & FormattaPrezzo(Scoperto) & ")", "") & " - tel. " & Ord.VoceRubrica.Tel
                        lblRiga2.Text = Ord.VoceRubrica.RagSocNome & " - tel. " & Ord.VoceRubrica.Tel
                        lblRiga1.Text = "Stato: " & Ord.StatoStr
                        lblRiga1.BackColor = Ord.StatoColore
                        If File.Exists(Ord.FilePath) Then
                            pct.Image = Image.FromFile(Ord.FilePath)
                        End If
                        lblNote.Text = Ord.Annotazioni
                    End Using
                End If
            ElseIf Not Com Is Nothing Then
                'MARCO: AGGIUNTA RIGA SEGUENTE, PERCHE' ALTRIMENTI VA IN ECCEZIONE (GESTITA) PASSANDO DA UNA TAB DEL GESTIONALE ALL'ALTRO
                '(RIFERIMENTO A UN OGGETTO NON IMPOSTATO SU UN'ISTANZA DI OGGETTO) E IL TOOLTIP NON FUNZIONA PIU'
                If _Com Is Nothing Then _Com = New Commessa
                If Com.IdCom = 0 Then Exit Sub
                If _Com.IdCom <> Com.IdCom And Com.IdCom <> 0 Then
                    lnkTit.Text = "Commessa " & Com.IdCom & " del " & Com.DataStr
                    lblRiga1.Text = "Stato: " & Com.StatoStr
                    lblRiga1.BackColor = Color.Transparent
                    lblRiga2.Text = ""
                    lblRiga3.Text = ""
                    If File.Exists(FormerPathCreator.GetAnteprima(Com)) Then
                        pct.Image = Image.FromFile(FormerPathCreator.GetAnteprima(Com))
                    End If
                    lblNote.Text = Com.Annotazioni
                End If
            End If

            _Ord = Ord
            _Com = Com

            Dim PosizioneX As Integer = 0
            Dim PosizioneY As Integer = 0

            'la visualizzo

            'Dim p As System.Drawing.Point = Cursor.Position
            'MARCO: COMMENTATO QUANTO SEGUE
            'If Screen.PrimaryScreen.WorkingArea.Size.Height > Posizione.Y + (Height / 2) Then
            '    PosizioneY = Posizione.Y - IIf(Posizione.Y < (Height / 2), 0, (Height / 2))
            'Else
            '    PosizioneY = Screen.PrimaryScreen.WorkingArea.Size.Height - (Height) - 50
            'End If

            'If Screen.PrimaryScreen.WorkingArea.Size.Width < (Posizione.X + Width) Then
            '    PosizioneX = Posizione.X - Width - 50
            'Else
            '    PosizioneX = Posizione.X + 50
            'End If
            'MARCO: RIGHE SEGUENTI SOSTITUISCONO QUANTO COMMENTATO SOPRA, PER POSIZIONARE
            'IL TOOLTIP IN CORRISPONDENZA DEL PUNTATORE DEL MOUSE

            If Screen.PrimaryScreen.WorkingArea.Size.Height > (Posizione.Y + Height) Then
                PosizioneY = Posizione.Y
            Else
                PosizioneY = Posizione.Y - Height
            End If

            If Screen.PrimaryScreen.WorkingArea.Size.Width < (Posizione.X + Width) Then
                PosizioneX = Posizione.X - Width
            Else
                PosizioneX = Posizione.X
            End If

            '_AnteOrd.Left = p.X + 50
            '_AnteOrd.BringToFront()
            '_AnteOrd.Visible = True

            AnteprimaLavoro.Left = PosizioneX + 5
            AnteprimaLavoro.Top = PosizioneY + 5

            'AnteprimaLavoro.Top = Posizione.Y + 120

            'AnteprimaLavoro.BringToFront()
            AnteprimaLavoro.Visible = True
            AnteprimaLavoro.Parent = FormPrincipale
            AnteprimaLavoro.BringToFront()
            AnteprimaLavoro.Show()

            'Refresh()

            'attivo il timer di chiusura automatica
            'tmrClose.Enabled = True
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Nascondi()

        AnteprimaLavoro.Visible = False

    End Sub

    Public Sub New()
        'Visible = False
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        'If LUNA.LunaContext.TotConnAttive Then
        '            Parent = FormPrincipale
        'End if 
        'AddHandler lblNote.MouseEnter, SpegniTimer()
        'AddHandler lblRiga1.MouseEnter, SpegniTimer()
        'AddHandler lblRiga2.MouseEnter, SpegniTimer()
        'AddHandler lblRiga3.MouseEnter, SpegniTimer()
        'AddHandler lnkTit.MouseEnter, SpegniTimer()
        'AddHandler lblNoteTit.MouseEnter, SpegniTimer()
        'AddHandler pct.MouseHover, SpegniTimer()

        'End If
        Visible = False
    End Sub

    Public Event ClickAnteprima()

    Private Sub pct_Click(sender As System.Object, e As System.EventArgs) Handles pct.Click
        RaiseEvent ClickAnteprima()
    End Sub

    Private Sub lblIdCom_Click(sender As System.Object, e As System.EventArgs)
        RaiseEvent ClickAnteprima()
    End Sub

    'Private Sub tmrClose_Tick(sender As System.Object, e As System.EventArgs) Handles tmrClose.Tick

    '    Visible = False

    'End Sub

    Private Sub ucAntepLavoro_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        'SpegniTimer()
    End Sub

    Private Sub ucAntepLavoro_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        'AccendiTimer()
    End Sub
    'Private Function SpegniTimer()
    '    tmrClose.Enabled = False
    'End Function
    'Private Function AccendiTimer()
    '    tmrClose.Enabled = True
    'End Function

    Private Sub lnkTit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTit.LinkClicked
        If Not _Ord Is Nothing Then
            ParentFormEx.Sottofondo()
            Using f As New frmOrdine
                f.Carica(_Ord.IdOrd)
            End Using
            ParentFormEx.Sottofondo()
        ElseIf Not _Com Is Nothing Then
            ParentFormEx.Sottofondo()
            Using f As New frmCommessa
                f.Carica(_Com.IdCom)
            End Using
            ParentFormEx.Sottofondo()
        End If
    End Sub

    Private Sub pctClose_Click(sender As Object, e As EventArgs) Handles pctClose.Click
        Visible = False
    End Sub
End Class
