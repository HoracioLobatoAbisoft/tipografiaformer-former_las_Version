'Imports FormerDALSql
'Imports FormerLib.FormerEnum

Imports System.Drawing

Public Class ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.BackColor = Color.White

        'ImlOfficialLoader.Load(imlOfficial16)
        'ImlOfficialLoader.Load(imlOfficial26)

    End Sub

    Public ReadOnly Property ParentFormEx As FormerLib.IFormWithSottofondo
        Get
            Return Me.ParentForm 'DirectCast(Me.ParentForm, baseFormInterna)
        End Get
    End Property

End Class
