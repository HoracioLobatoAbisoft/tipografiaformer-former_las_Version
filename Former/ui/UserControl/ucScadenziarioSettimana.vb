Imports FormerDALSql
Imports FormerLib.FormerEnum
Public Class ucScadenziarioSettimana
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Clear()
        tvwScadenze.Nodes.Clear()
        lblSettimana.Text = String.Empty
    End Sub

    Private _DataRifStart As Date = Date.Now
    Private _DataRifEnd As Date = Date.Now

    Private _TipoVoci As enTipoVoceContab
    Public Sub Carica(ByVal DataRif As Date,
                      TipoVoci As enTipoVoceContab)
        _TipoVoci = TipoVoci
        _DataRifStart = DataRif
        _DataRifEnd = _DataRifStart.AddDays(6)

        If _DataRifEnd.Month <> _DataRifStart.Month Then
            'puo verificarsi l'ultima settimana
            _DataRifEnd = New Date(_DataRifStart.Year, _DataRifStart.Month, DateTime.DaysInMonth(_DataRifStart.Year, _DataRifStart.Month))
        End If

        lblSettimana.Text = _DataRifStart.ToString("dddd dd MMM") & "-" & _DataRifEnd.ToString("dddd dd MMM")

        If TipoVoci = enTipoVoceContab.VoceAcquisto Then
            'qui vedere cosa si devere fare se e' un acquisto 

            Dim pDataIn As New LUNA.LunaSearchParameter(LFM.Costo.DataPrevPagam, _DataRifStart, ">=", LUNA.enLogicOperator.enAND)
            Dim pDataFin As New LUNA.LunaSearchParameter(LFM.Costo.DataPrevPagam, _DataRifEnd, "<=", LUNA.enLogicOperator.enAND)
            Dim pStato As New LUNA.LunaSearchParameter(LFM.Costo.IdStato, CInt(enStatoDocumentoFiscale.PagatoInteramente), "<>", LUNA.enLogicOperator.enAND)
            Dim pTipo As New LUNA.LunaSearchParameter(LFM.Costo.Tipo, CInt(enTipoDocumento.DDT), "<>")

            Dim Lst As List(Of Costo) = Nothing
            Using mgr As New CostiDAO
                Lst = mgr.FindAll(LFM.Costo.DataPrevPagam, pDataIn, pDataFin, pStato, pTipo)
            End Using

            Dim NumClienti As Integer = 0
            Dim TotImporti As Decimal = 0

            For Each C As Costo In Lst
                If C.PagatoInteramente = False Then
                    Dim ChiaveRub As String = "C" & C.IdRub
                    Dim Nodes() As TreeNode = tvwScadenze.Nodes.Find(ChiaveRub, False)
                    Dim NodoPadre As TreeNode
                    TotImporti += C.TotaleAncoraDaPagare
                    If Nodes.Count = 0 Then
                        NumClienti += 1
                        NodoPadre = New TreeNode
                        Dim cli As New VoceRubrica
                        cli.Read(C.IdRub)
                        'NodoPadre.Text = cli.RagSoc
                        NodoPadre.Name = ChiaveRub

                        Dim tdc As New TotaleDocumentiCliente
                        tdc.RagSoc = cli.RagSocNome
                        NodoPadre.Tag = tdc
                        NodoPadre.SelectedImageIndex = 0
                        NodoPadre.ImageIndex = 0
                        tvwScadenze.Nodes.Add(NodoPadre)
                    Else
                        NodoPadre = tvwScadenze.Nodes(ChiaveRub)
                    End If
                    Dim ggScaduti As Integer = DateDiff(DateInterval.Day, Now, C.DataPrevPagam)
                    Dim NodoR As New TreeNode
                    NodoR.Name = "R" & C.IdCosto
                    NodoR.Text = "(" & ggScaduti & "gg) " & FormerLib.FormerEnum.FormerEnumHelper.TipoDocumentoFiscaleStr(C.Tipo) & " " & C.Numero & " del " & C.DataRif & " " & C.TotaleStr & "€ scade il " & C.DataPrevPagam
                    If ggScaduti > 0 Then
                        NodoR.BackColor = Color.GreenYellow
                    End If

                    'Dim tp As New TipoPagamento
                    'tp.Read(C.Idpagamento)
                    'Select Case tp.ModoPagam
                    '    Case "A"
                    '        NodoR.SelectedImageIndex = 1
                    '        NodoR.ImageIndex = 1
                    '    Case "B"
                    '        NodoR.SelectedImageIndex = 2
                    '        NodoR.ImageIndex = 2
                    '    Case Else
                    '        NodoR.SelectedImageIndex = 3
                    '        NodoR.ImageIndex = 3
                    'End Select

                    Dim Dc As New DocumentoCliente
                    Dc.Totale = C.TotaleAncoraDaPagare
                    DirectCast(NodoPadre.Tag, TotaleDocumentiCliente).Add(Dc)
                    RicalcolaNodoPadre(NodoPadre)
                    tvwScadenze.Nodes(ChiaveRub).Nodes.Add(NodoR)
                End If

            Next

            TotImporti = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotImporti, 2)

            lblRiassunto.Text = "Clienti: " & NumClienti & ", Importo Totale: " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotImporti) & "€"

        Else
            'voci di vendita

            Dim pDataIn As New LUNA.LunaSearchParameter(LFM.Ricavo.Dataprevpagam, _DataRifStart, ">=", LUNA.enLogicOperator.enAND)
            Dim pDataFin As New LUNA.LunaSearchParameter(LFM.Ricavo.Dataprevpagam, _DataRifEnd, "<=", LUNA.enLogicOperator.enAND)
            Dim pStato As New LUNA.LunaSearchParameter(LFM.Ricavo.idstato, CInt(enStatoDocumentoFiscale.PagatoInteramente), "<>", LUNA.enLogicOperator.enAND)
            Dim pTipo As New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, CInt(enTipoDocumento.DDT), "<>")

            Dim Lst As List(Of Ricavo) = Nothing
            Using mgr As New RicaviDAO
                Lst = mgr.FindAll(LFM.Ricavo.Dataprevpagam, pDataIn, pDataFin, pStato, pTipo)
            End Using

            Dim NumClienti As Integer = 0
            Dim TotImporti As Decimal = 0

            For Each R As Ricavo In Lst
                If R.PagatoInteramente = False Then
                    Dim ChiaveRub As String = "C" & R.IdRub
                    Dim Nodes() As TreeNode = tvwScadenze.Nodes.Find(ChiaveRub, False)
                    Dim NodoPadre As TreeNode
                    TotImporti += R.TotaleAncoraDaPagare
                    If Nodes.Count = 0 Then
                        NumClienti += 1
                        NodoPadre = New TreeNode
                        Dim cli As New VoceRubrica
                        cli.Read(R.IdRub)
                        'NodoPadre.Text = cli.RagSoc
                        NodoPadre.Name = ChiaveRub

                        Dim tdc As New TotaleDocumentiCliente
                        tdc.RagSoc = cli.RagSocNome
                        NodoPadre.Tag = tdc
                        NodoPadre.SelectedImageIndex = 0
                        NodoPadre.ImageIndex = 0
                        tvwScadenze.Nodes.Add(NodoPadre)
                    Else
                        NodoPadre = tvwScadenze.Nodes(ChiaveRub)
                    End If
                    Dim ggScaduti As Integer = DateDiff(DateInterval.Day, Now, R.Dataprevpagam)
                    Dim NodoR As New TreeNode
                    NodoR.Name = "R" & R.IdRicavo
                    NodoR.Text = "(" & ggScaduti & "gg) " & FormerLib.FormerEnum.FormerEnumHelper.TipoDocumentoFiscaleStr(R.Tipo) & " " & R.Numero & " del " & R.DataRif & " " & R.TotaleStr & "€ scade il " & R.Dataprevpagam
                    If ggScaduti > 0 Then
                        NodoR.BackColor = Color.GreenYellow
                    End If
                    Dim tp As New TipoPagamento
                    tp.Read(R.Idpagamento)
                    Select Case tp.ModoPagam
                        Case "A"
                            NodoR.SelectedImageIndex = 1
                            NodoR.ImageIndex = 1
                        Case "B"
                            NodoR.SelectedImageIndex = 2
                            NodoR.ImageIndex = 2
                        Case Else
                            NodoR.SelectedImageIndex = 3
                            NodoR.ImageIndex = 3
                    End Select

                    Dim Dc As New DocumentoCliente
                    Dc.Totale = R.TotaleAncoraDaPagare
                    DirectCast(NodoPadre.Tag, TotaleDocumentiCliente).Add(Dc)
                    RicalcolaNodoPadre(NodoPadre)
                    tvwScadenze.Nodes(ChiaveRub).Nodes.Add(NodoR)
                End If

            Next

            TotImporti = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotImporti, 2)

            lblRiassunto.Text = "Clienti: " & NumClienti & ", Importo Totale: " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotImporti) & "€"

        End If

    End Sub
    Private Function FormattaLunghezza(StrIniz As String, Lunghezza As Integer, Optional Carattere As String = "", Optional DirezioneInvertita As Boolean = False) As String
        Dim strNew As String = StrIniz
        For I As Integer = strNew.Length To Lunghezza
            If DirezioneInvertita Then
                strNew = strNew & Carattere
            Else
                strNew = Carattere & strNew
            End If

        Next

        Return strNew

    End Function
    Private Sub RicalcolaNodoPadre(N As TreeNode)

        Dim Tdc As TotaleDocumentiCliente = N.Tag
        Dim NumDoc As Integer = 0
        Dim TotaleDoc As Decimal = 0
        For Each D As DocumentoCliente In Tdc
            TotaleDoc += D.Totale
            NumDoc += 1
        Next

        N.Text = FormattaLunghezza(Strings.Left(Tdc.RagSoc, 20) & " (" & NumDoc & ") ", 25, " ", True) & FormattaLunghezza(FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotaleDoc), 8, " ") & "€"

    End Sub

    Private Sub tvwScadenze_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwScadenze.NodeMouseClick
        Dim Node As TreeNode = e.Node
        Dim IdRif As Integer = Node.Name.Substring(1)
        If Node.Name.StartsWith("C") Then
            _IdClienteSelezionato = IdRif
            RaiseEvent ClienteSelezionato(Me)
        Else
            _IdClienteSelezionato = 0
        End If
    End Sub

    Private Sub tvwScadenze_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwScadenze.NodeMouseDoubleClick

        Dim Node As TreeNode = e.Node
        Dim IdRif As Integer = Node.Name.Substring(1)
        ParentFormEx.Sottofondo()
        If Node.Name.StartsWith("C") Then
            'cliente
            Dim f As New frmVoceRubrica
            f.Carica(IdRif)
            f = Nothing
        Else

            If _TipoVoci = enTipoVoceContab.VoceAcquisto Then
                'ricavo
                Using C As New Costo
                    C.Read(IdRif)
                    If C.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                        Using f As New frmContabilitaFatturaRiepilogativaCosto
                            f.Carica(IdRif)
                        End Using
                    Else
                        Using f As New frmContabilitaCosto
                            f.Carica(IdRif)
                        End Using
                    End If

                End Using
            Else
                'ricavo
                Using R As New Ricavo
                    R.Read(IdRif)
                    If R.Tipo = enTipoDocumento.Fattura Or R.Tipo = enTipoDocumento.Preventivo Then
                        Using f As New frmContabilitaRicavo
                            f.Carica(IdRif, enTipoVoceContab.VoceVendita)
                        End Using
                    ElseIf R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                        Using f As New frmContabilitaFatturaRiepilogativaRicavo
                            f.Carica(IdRif)
                        End Using
                    End If
                End Using
            End If
        End If
        ParentFormEx.Sottofondo()
    End Sub

    Public Event ClienteSelezionato(sender As Object)
    Private _IdClienteSelezionato As Integer = 0
    Public ReadOnly Property IdClienteSelezionato As Integer
        Get
            Return _IdClienteSelezionato
        End Get
    End Property

    Private Sub tvwScadenze_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwScadenze.AfterSelect

    End Sub
End Class