Imports System.ComponentModel
Imports System.Drawing.Design

Public Class ucInfoBox

    <Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design", GetType(UITypeEditor))>
    Public Property HelpText As String
        Get
            Return lblHelp.Text
        End Get
        Set(value As String)
            lblHelp.Text = value
        End Set
    End Property

End Class
