Imports FormerLib

Public Class ucRadGridView
    Inherits Telerik.WinControls.UI.RadGridView

    Public Sub New()

        'MyBase.New

        AutoScroll = True
        BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        EnableGestures = False
        Font = New System.Drawing.Font("Segoe UI", 9.0!)
        MasterTemplate.AllowAddNewRow = False
        MasterTemplate.AllowCellContextMenu = False
        MasterTemplate.AllowColumnChooser = False
        MasterTemplate.AllowColumnHeaderContextMenu = False
        MasterTemplate.AllowDeleteRow = False
        MasterTemplate.AllowDragToGroup = False
        MasterTemplate.AllowEditRow = False
        MasterTemplate.AllowRowHeaderContextMenu = False
        MasterTemplate.AllowRowResize = False
        MasterTemplate.AllowSearchRow = True
        MasterTemplate.AutoGenerateColumns = False

        MasterTemplate.EnableAlternatingRowColor = True
        MasterTemplate.EnableGrouping = False

        MasterTemplate.ShowRowHeaderColumn = False
        ShowGroupPanel = False
        ShowGroupPanelScrollbars = False
        ShowNoDataText = False

        MasterView.TableSearchRow.AutomaticallySelectFirstResult = False
        MasterView.TableSearchRow.ShowCloseButton = False
        TableElement.AlternatingRowColor = Color.FromArgb(241, 241, 241)
        ThemeName = FormerConfig.FConfiguration.Environment.TelerikTheme

    End Sub





End Class
