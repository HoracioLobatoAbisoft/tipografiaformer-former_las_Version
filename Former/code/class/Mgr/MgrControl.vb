Imports FormerBusinessLogicInterface
Imports FormerLib
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class MgrControl

    Public Shared Sub InizializeCollapsiblePanel(ByRef Panel As RadCollapsiblePanel)

        Panel.ControlsContainer.PanelContainer.BorderStyle = BorderStyle.None
        Panel.ControlsContainer.PanelElement.Border.Visibility = ElementVisibility.Collapsed

    End Sub

    Public Shared Sub ShowTooltipMqFromCm(ByRef txt As ucNumericTextBox, ByRef TT As ToolTip)

        Dim Ris As Single = 0

        Try

            Dim cm As Integer = txt.Value

            Ris = MgrCalcoliTecnici.CalcolaML(cm)
            Dim Messaggio As String = String.Empty
            If Ris Then
                Messaggio = Ris.ToString("#.00") & " Metri lineari"
            End If

            TT.SetToolTip(txt, Messaggio)
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub InizializeGridview(ByRef Griglia As RadGridView,
                                         Optional WithSearch As Boolean = False,
                                         Optional WithAlternateColor As Boolean = True)
        Try
            If WithSearch Then
                Griglia.MasterView.TableSearchRow.AutomaticallySelectFirstResult = False
                Griglia.MasterView.TableSearchRow.ShowCloseButton = False
            Else
                Griglia.MasterView.TableSearchRow.IsVisible = False
            End If

            If WithAlternateColor Then
                Griglia.TableElement.AlternatingRowColor = Color.FromArgb(241, 241, 241)
                Griglia.EnableAlternatingRowColor = True
            Else
                Griglia.EnableAlternatingRowColor = False
            End If
            Griglia.TableElement.HighlightColor = Color.FromArgb(214, 224, 61)
            Griglia.TableElement.SearchHighlightColor = Color.FromArgb(255, 128, 0)
            'Griglia.TableElement.BorderHighlightColor = Color.FromArgb(214, 224, 61)
            'Griglia.TableElement.EnableBorderHighlight = False

            'Griglia.TableElement.CurrentCell.BackColor = Color.FromArgb(214, 224, 61)

            Griglia.AllowAddNewRow = False
            Griglia.AllowDeleteRow = False
            Griglia.ShowGroupPanel = False
            Griglia.AutoGenerateColumns = False

            AddHandler Griglia.RowFormatting, AddressOf RigaSelezionata

        Catch ex As Exception

        End Try


    End Sub

    Private Shared Sub RigaSelezionata(sender As Object,
                                       e As RowFormattingEventArgs)

        If e.RowElement.IsSelected Then
            e.RowElement.BackColor = FormerColori.ColoreAmbienteVerde
        Else
            e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
        End If

    End Sub

    Public Shared Sub AutoAdattaDimensioni(ByRef Splitter As SplitContainer,
                                           NodiMatt As Integer,
                                           NodiPom As Integer)
        Try

            If NodiMatt = 0 Then NodiMatt = 1
            If NodiPom = 0 Then NodiPom = 1

            Dim PercSplit As Integer = Math.Round((NodiMatt * 100) / (NodiMatt + NodiPom))
            If PercSplit < 10 Then PercSplit = 20

            Dim AlteSplit As Integer = Math.Round((Splitter.Height) * PercSplit / 100)

            If AlteSplit < Splitter.Panel1MinSize Then AlteSplit = Splitter.Panel1MinSize
            Splitter.SplitterDistance = AlteSplit
        Catch ex As Exception

        End Try
    End Sub

    <Obsolete("This method is deprecated, use ucCTRNumericTextbox instead.")>
    Public Shared Sub ControlloNumerico(ByRef sender As Object,
                                 ByRef e As System.Windows.Forms.KeyPressEventArgs,
                                 Optional ByVal OnlyInteger As Boolean = False,
                                 Optional ByVal AccettaNegativi As Boolean = False)
        Dim x As Char = vbBack

        Dim pun As Char = ","
        Dim Punto As Char = "."
        Dim Meno As Char = "-"

        If e.KeyChar = Punto Then e.KeyChar = pun
        'qui controllo ctrl+C e ctrl+v
        If (Asc(e.KeyChar) <> 3 And Asc(e.KeyChar) <> 22) Then
            If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> x And e.KeyChar <> pun Then
                If AccettaNegativi Then
                    If e.KeyChar = Meno Then
                        If sender.text.indexOf("-") <> -1 Then
                            e.Handled = True
                        End If
                    Else
                        e.Handled = True
                    End If
                Else
                    e.Handled = True
                End If
            Else
                If (e.KeyChar = pun And sender.Text.IndexOf(",") <> -1) Or (e.KeyChar = pun And OnlyInteger = True) Then
                    e.Handled = True
                End If
            End If
        Else
            'valido i dati in memoria
            Dim valMem As Decimal = 0
            Try
                valMem = Clipboard.GetText

                If IsNumeric(valMem) = False Then
                    e.Handled = True
                End If
            Catch ex As Exception
                e.Handled = True
            End Try
        End If

        'Library.ControlloNumerico(sender,
        '                e,
        '                OnlyInteger,
        '                AccettaNegativi)

        'Dim x As Char = vbBack

        'Dim pun As Char = ","
        'Dim Punto As Char = "."
        'Dim Meno As Char = "-"

        'If e.KeyChar = Punto Then e.KeyChar = pun
        ''qui controllo ctrl+C e ctrl+v
        'If (Asc(e.KeyChar) <> 3 And Asc(e.KeyChar) <> 22) Then
        '    If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> x And e.KeyChar <> pun Then
        '        If AccettaNegativi Then
        '            If e.KeyChar = Meno Then

        '                If sender.text.indexOf("-") <> -1 Then
        '                    e.Handled = True
        '                End If
        '            Else
        '                e.Handled = True
        '            End If
        '        Else
        '            e.Handled = True
        '        End If
        '    Else

        '        If (e.KeyChar = pun And sender.Text.IndexOf(",") <> -1) Or (e.KeyChar = pun And OnlyInteger = True) Then
        '            e.Handled = True
        '        End If
        '    End If
        'Else
        '    'valido i dati in memoria
        '    Dim valMem As Decimal = 0
        '    Try
        '        valMem = Clipboard.GetText

        '        If IsNumeric(valMem) = False Then
        '            e.Handled = True
        '        End If
        '    Catch ex As Exception
        '        e.Handled = True
        '    End Try

        'End If

    End Sub

    Public Shared Function SelectIndexCombo(ByRef combo As ucComboWithImage,
                                            ByVal Valore As Integer) As Integer
        If IsDBNull(Valore) OrElse Valore = 0 Then SelectIndexCombo = -1
        combo.SelectedValue = Valore
        Return combo.SelectedIndex
    End Function

    Public Shared Function SelectIndexCombo(ByRef combo As ComboBox,
                                            ByVal Valore As Integer) As Integer
        If IsDBNull(Valore) OrElse Valore = 0 Then SelectIndexCombo = -1
        combo.SelectedValue = Valore
        Return combo.SelectedIndex
    End Function

    Public Shared Function SelectIndexComboValore(ByRef combo As ComboBox, ByVal valore As String)
        If IsDBNull(valore) OrElse valore.Length = 0 Then SelectIndexComboValore = -1
        combo.SelectedValue = valore
        Return -1
    End Function

    Public Shared Function SelectIndexComboTesto(ByRef combo As ComboBox, ByVal valore As String)
        If IsDBNull(valore) OrElse valore.Length = 0 Then SelectIndexComboTesto = -1
        combo.SelectedText = valore
        Return -1
    End Function

    Public Shared Sub SelectIndexComboEnum(ByRef combo As ComboBox,
                                           ByVal valore As String)
        Dim Index As Integer = 0
        For Each item As cEnum In combo.Items

            If item.Id = valore Then
                combo.SelectedIndex = Index
                Exit For
            End If
            Index += 1
        Next
    End Sub

    Public Shared Function SelectIndexCombo(ByRef combo As ComboBox,
                                            ByVal Valore As String) As Integer
        If IsDBNull(Valore) OrElse Valore.Trim = "" Then SelectIndexCombo = -1

        For I As Integer = 0 To combo.Items.Count - 1
            combo.SelectedIndex = I
            If combo.Items(I).ToString = Valore Then
                Return I
                Exit For
            End If
        Next
        Return -1
    End Function

End Class
