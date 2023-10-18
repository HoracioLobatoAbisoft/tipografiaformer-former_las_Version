Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Data

Public Class ucComboRubrica
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
        mainCombo.ListElement.BackColor = Color.White
        mainCombo.ListElement.AlternatingItemColor = FormerLib.FormerColori.ColoreAmbienteGrigioChiarissimo
        mainCombo.ListElement.EnableAlternatingItemColor = True
        mainCombo.DropDownListElement.DropDownHeight = 300
        mainCombo.DropDownListElement.ArrowButton.Fill.BackColor = FormerLib.FormerColori.ColoreAmbienteVerde
        mainCombo.DropDownListElement.EnableHighlight = True

    End Sub

    Public Sub Reset()
        mainCombo.SelectedIndex = 0
    End Sub

    Public Event SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs)

    Private Sub CaricaDati()
        Using mgr As New VociRubricaDAO

            Try
                RemoveHandler mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.ListElement.VisualItemFormatting, AddressOf VisualListItemFormatting
            Catch ex As Exception

            End Try

            Dim l As List(Of VoceRubrica) = mgr.ListaCombo(_TipoVoci, _ShowAll, _ListaSpecifica,,,, _SoloDisponibiliOnline)

            'l.Sort(Function(x, y) x.RagSocNome.CompareTo(y.RagSocNome))

            If _ConId Then
                mainCombo.DisplayMember = "NominativoConId"
            Else
                mainCombo.DisplayMember = "Nominativo"
            End If

            mainCombo.ValueMember = LFM.VoceRubrica.IdRub.Name
            mainCombo.DropDownListElement.AutoCompleteMode = AutoCompleteMode.Suggest
            'mainCombo.DropDownListElement.AutoCompleteSuggest.SuggestMode .LimitToList = True
            mainCombo.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains
            mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.DropDownHeight = 300
            mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.EnableHighlight = True
            mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.HighlightColor = Color.Yellow
            mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.ListElement.EnableAlternatingItemColor = True
            mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.ListElement.BackColor = Color.White
            mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.ListElement.AlternatingItemColor = FormerLib.FormerColori.ColoreAmbienteGrigioChiarissimo
            'mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.ListElement.HighlightColor = Color.Red
            'mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.ListElement.EnableHighlight = True

            mainCombo.DataSource = l

            'AddHandler mainCombo.DropDownListElement.ListElement.VisualItemFormatting, AddressOf VisualListItemFormatting
            AddHandler mainCombo.DropDownListElement.AutoCompleteSuggest.DropDownList.ListElement.VisualItemFormatting, AddressOf VisualListItemFormatting

        End Using
    End Sub

    Private _TipoVoci As enTipoRubrica
    Private _ShowAll As Boolean
    Private _ListaSpecifica As String = ""
    Private _SoloDisponibiliOnline As Boolean
    Private _ConId As Boolean = False
    Public Sub Carica(TipoVoci As enTipoRubrica,
                      Optional ShowAll As Boolean = False,
                      Optional ListaSpecifica As String = "",
                      Optional SoloDisponibiliOnline As Boolean = False,
                      Optional ConId As Boolean = False)
        _ConId = ConId
        _TipoVoci = TipoVoci
        _ShowAll = ShowAll
        _ListaSpecifica = ListaSpecifica
        _SoloDisponibiliOnline = SoloDisponibiliOnline
        CaricaDati()

    End Sub

    Private Sub mainCombo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles mainCombo.SelectedIndexChanged
        sender.focus
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub

    Private Sub VisualListItemFormatting(sender As Object, args As VisualItemFormattingEventArgs)

        Dim testo As String = mainCombo.Text.ToLower
        Dim TestoAttuale As String = args.VisualItem.Text.ToLower

        'qui devo ripulire i tag html 

        Dim TagChiusuraSpan As String = "</span>"
        Dim TagAperturaSpan As String = "<span style=\""background-color:" & FormerLib.FormerColori.GetColoreToHtml(FormerLib.FormerColori.ColoreAmbienteVerde) & ";\"">"

        Dim TagAperturaHtml As String = "<html>"
        Dim TagChiusuraHtml As String = "</html>"

        If TestoAttuale.Contains(testo) Then

            Dim posizione As Integer = TestoAttuale.IndexOf(testo)
            If TestoAttuale.Length > posizione + testo.Length Then
                Dim nuovotesto As String = args.VisualItem.Text.Insert(posizione + testo.Length, TagChiusuraSpan)
                nuovotesto = nuovotesto.Insert(posizione, tagaperturaspan)
                nuovotesto = "<html>" & nuovotesto & "</html>"
                args.VisualItem.Tag = args.VisualItem.Text
                args.VisualItem.Text = nuovotesto
            Else
                If Not args.VisualItem.Tag Is Nothing Then
                    args.VisualItem.Text = args.VisualItem.Tag
                End If
            End If

        End If

    End Sub

    'Private Sub mainCombo_VisualListItemFormatting(sender As Object, args As VisualItemFormattingEventArgs) Handles mainCombo.VisualListItemFormatting

    '    Try
    '        Dim text As String = mainCombo.Text

    '        If args.VisualItem.Text.Contains(text) Then

    '            args.VisualItem.BackColor = Color.Red
    '        Else
    '            args.VisualItem.BackColor = Color.Yellow

    '            'Dim index As Integer = args.VisualItem.Text.IndexOf(text)

    '            'If args.VisualItem.Text.Length > index + text.Length Then
    '            '    Dim newText As String = args.VisualItem.Text.Insert(index + text.Length, "</b>")
    '            '    newText = newText.Insert(index, "<b>")
    '            '    newText = "<html>" & newText & "</html>"
    '            '    args.VisualItem.Text = newText
    '            'End If
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Public ReadOnly Property RubSelezionato As VoceRubrica
        Get
            Dim ris As VoceRubrica = Nothing

            Try
                ris = mainCombo.SelectedItem.DataBoundItem
            Catch ex As Exception

            End Try

            Return ris
        End Get
    End Property

    Public Property IdRubSelezionato As Integer
        Get
            Dim Ris As Integer = 0
            Try
                Ris = mainCombo.SelectedValue
            Catch ex As Exception

            End Try


            Return Ris
        End Get
        Set(value As Integer)
            Try
                mainCombo.SelectedValue = value
            Catch ex As Exception

            End Try
        End Set
    End Property

    Private Sub pctRefresh_Click(sender As Object, e As EventArgs) Handles pctRefresh.Click
        If mainCombo.Enabled Then
            Cursor.Current = Cursors.WaitCursor
            CaricaDati()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub mainCombo_EnabledChanged(sender As Object, e As EventArgs) Handles mainCombo.EnabledChanged
        pctRefresh.Enabled = mainCombo.Enabled
    End Sub




End Class
