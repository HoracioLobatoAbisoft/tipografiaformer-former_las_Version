Imports System.Globalization
Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucScadenzarioMese
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        _Periodo = New Date(Now.Year, Now.Month, 1)
    End Sub
    'Private _DateString As String = "01/" & Now.Month.ToString("00") & "/" & Now.Year 
    Private _Periodo As Date
    'Private _DateString As String = Now.Year & "-" & Now.Month.ToString("00") & "-01"
    'Private _Periodo As Date = Date.Parse(_DateString, New CultureInfo("it-IT", False))
    Private Sub ucScadenzario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If LUNA.LunaContext.TotConnAttive Then
        '    CaricaPeriodo()
        '    CaricaScadenzeMesi()
        'End If
    End Sub

    Private Sub CaricaPeriodo()
        Cursor.Current = Cursors.WaitCursor
        Dim TipoVoce As enTipoVoceContab = enTipoVoceContab.VoceVendita
        If rdoUscite.Checked Then TipoVoce = enTipoVoceContab.VoceAcquisto
        lblMese.Text = FormerLib.FormerHelper.Calendario.MeseToString(_Periodo.ToString("MM")) & " " & _Periodo.ToString("yyyy")

        'carico le settimane
        UcScadenziarioSettimana1.Clear()
        UcScadenziarioSettimana2.Clear()
        UcScadenziarioSettimana3.Clear()
        UcScadenziarioSettimana4.Clear()
        UcScadenziarioSettimana5.Clear()

        UcScadenziarioSettimana1.Carica(_Periodo, TipoVoce)
        UcScadenziarioSettimana2.Carica(_Periodo.AddDays(7), TipoVoce)
        UcScadenziarioSettimana3.Carica(_Periodo.AddDays(14), TipoVoce)
        UcScadenziarioSettimana4.Carica(_Periodo.AddDays(21), TipoVoce)

        Dim DataUltSett As Date = _Periodo.AddDays(28)

        If _Periodo.Month = DataUltSett.Month Then
            UcScadenziarioSettimana5.Carica(_Periodo.AddDays(28), TipoVoce)
        End If
        Cursor.Current = Cursors.Default
        'carico le scadenze del periodo 

    End Sub

    Private Sub btnAvanti_Click(sender As Object, e As EventArgs) Handles btnAvanti.Click
        _Periodo = _Periodo.Date.AddMonths(1)
        CaricaPeriodo()
    End Sub

    Private Sub btnIndietro_Click(sender As Object, e As EventArgs) Handles btnIndietro.Click
        _Periodo = _Periodo.Date.AddMonths(-1)
        CaricaPeriodo()
    End Sub

    Private Sub CaricaScadenzeMesi()

        Dim lst As List(Of ScopertoMese)

        If rdoEntrate.Checked Then
            'carico le entrate 
            Using R As New RicaviDAO
                lst = R.CalcolaScopertoMesi
            End Using
        Else
            'carico le uscite
            Using R As New CostiDAO
                lst = R.CalcolaScopertoMesi
            End Using
        End If

        tvwScadenzeMese.Nodes.Clear()
        lst.Sort(Function(x As ScopertoMese, y As ScopertoMese) y.MeseRif.CompareTo(x.MeseRif))

        For Each m As ScopertoMese In lst
            Dim n As New TreeNode
            n.Tag = m.MeseRif
            n.Text = m.Mese & " " & FormattaLunghezza(FormerLib.FormerHelper.Stringhe.FormattaPrezzo(m.Scoperto), 10, " ") & "€"
            If m.MeseRif = Now.Date.Year & Now.Date.Month Then
                n.BackColor = Color.Red
            End If
            tvwScadenzeMese.Nodes.Add(n)
        Next

    End Sub

    Private Function FormattaLunghezza(StrIniz As String, Lunghezza As Integer, Optional Carattere As String = "") As String

        Dim strNew As String = StrIniz
        For I As Integer = strNew.Length To Lunghezza
            strNew = Carattere & strNew
        Next

        Return strNew

    End Function

    Private Sub tvwScadenzeMese_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwScadenzeMese.NodeMouseClick

        Dim MeseSel As String = e.Node.Tag
        Dim AnnoRif As Integer = e.Node.Tag.ToString.Substring(0, 4)
        Dim MeseRif As Integer = e.Node.Tag.ToString.Substring(4)

        _Periodo = New Date(AnnoRif, MeseRif, 1)
        CaricaPeriodo()

    End Sub

    Private Sub UcScadenziarioSettimana5_ClienteSelezionato(sender As Object) Handles UcScadenziarioSettimana5.ClienteSelezionato, _
                                                                                                            UcScadenziarioSettimana1.ClienteSelezionato, _
                                                                                                            UcScadenziarioSettimana2.ClienteSelezionato, _
                                                                                                            UcScadenziarioSettimana3.ClienteSelezionato, _
                                                                                                            UcScadenziarioSettimana4.ClienteSelezionato
        If sender.IdClienteSelezionato Then
            Using R As New VoceRubrica
                R.Read(sender.IdClienteSelezionato)
                lblClienteSel.Text = R.RagSocNome
            End Using
            UcSituazCliente.IdRub = sender.IdClienteSelezionato
            UcSituazCliente.MostraSituaz()
        End If

    End Sub

    Private Sub tabLaterale_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabLaterale.SelectedIndexChanged

        If tabLaterale.SelectedIndex = 0 Then
            Cursor.Current = Cursors.WaitCursor
            CaricaScadenzeMesi()
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub tvwScadenzeMese_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwScadenzeMese.AfterSelect

    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        CaricaPeriodo()
        CaricaScadenzeMesi()
    End Sub
End Class
