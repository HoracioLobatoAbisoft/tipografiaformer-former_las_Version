Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerBusinessLogic

Public Class ucOrdiniAdmin
    Inherits ucFormerUserControl

    Private _IdRub As Integer = 0
    Public Property IdRub As Integer
        Get
            Return _IdRub
        End Get
        Set(value As Integer)
            _IdRub = value
        End Set
    End Property

    Public Sub Carica()

        CaricaAlbero()

    End Sub

    Private Sub CaricaAlbero()

        tvOrdini.Nodes.Clear()

        Dim N As New TreeNode
        N.Name = "1"
        N.BackColor = Color.Red
        N.ForeColor = Color.White
        N.Text = "Preinserito/Registrato"
        tvOrdini.Nodes.Add(N)

        Dim N2 As New TreeNode
        N2.Name = "2"
        N2.BackColor = Color.Green
        N2.ForeColor = Color.White
        N2.Text = "Registrato su Com./In stampa/In Lavorazione/Pronto per la consegna"
        tvOrdini.Nodes.Add(N2)

        'qui carico gli ordini 

        Using oC As New cOrdiniColl
            Dim dt As DataTable = oC.Lista(, enStatoOrdine.Preinserito & "," & enStatoOrdine.Registrato, , True)

            For Each dr As DataRow In dt.Rows

                N.Nodes.Add("O" & dr("Ord"), "Ord. " & dr("Ord") & " - " & dr("data"), 0, 0)

            Next
        End Using
        tvOrdini.ExpandAll()

    End Sub

    Private Sub tvOrdini_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvOrdini.NodeMouseClick
        Dim Node As TreeNode = e.Node
        If Node.Name.StartsWith("1") = False And Node.Name.StartsWith("2") = False Then
            Dim IdO As Integer = Node.Name.Substring(1)
            Dim O As New Ordine
            O.Read(IdO)
            Try
                pctPreviewO.Image = Image.FromFile(O.FilePath)
            Catch ex As Exception

            End Try

            Dim C As New Commessa
            C.Read(O.IdCom)
            Try
                pctPreviewC.Image = Image.FromFile(FormerPathCreator.GetAnteprima(C))
            Catch ex As Exception

            End Try

        End If
    End Sub
End Class
