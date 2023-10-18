#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.8.1.27156 
'Author: Diego Lunadei
'Date: 28/01/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table T_rubricag
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class VociRubGDAO
    Inherits _VociRubGDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    'qui mi scrivo i metodi di ricerca globali che restituiscono oggetti di interfaccia IVoceRubricaG
    'sta leggermente fuori posto ma non mi va di ricreare tutta la struttura base per il dao senza motivo


    Public Function GetAllVoceRubG(Optional G As Gruppo = Nothing) As IEnumerable(Of IVoceRubricaG)

        Dim lRis As New List(Of IVoceRubricaG)

        Dim l As List(Of VoceRubrica)

        If G Is Nothing Then
            G = New Gruppo
            G.TipoOrigine = enOrigineContatto.Tutto
        End If

        If G.TipoOrigine = enOrigineContatto.Rubrica OrElse G.TipoOrigine = enOrigineContatto.Tutto Then
            Using mgr As New VociRubricaDAO
                l = mgr.FindAll(New LUNA.LunaSearchParameter("NoEmail", enSiNo.Si, "<>"),
                            New LUNA.LunaSearchParameter("Email", FormerLib.FormerConst.EmailNonDisponibile, "<>"),
                            New LUNA.LunaSearchParameter("Email", String.Empty, "<>"))
            End Using

            For Each v As VoceRubrica In l
                'prima controllo che la mail non sia gia in ilista e che sia formalmente valida 
                If lRis.FindAll(Function(x) x.EmailG = v.EmailG).Count = 0 Then
                    If FormerLib.FormerHelper.Mail.IsValidEmailAddress(v.EmailG) Then
                        lRis.Add(v)
                    End If
                End If
            Next
        End If

        If G.TipoOrigine = enOrigineContatto.Marketing OrElse G.TipoOrigine = enOrigineContatto.Tutto Then
            Dim lm As List(Of VoceRubricaMarketing)
            Using mgr As New VoceRubricaMarketingDAO
                lm = mgr.FindAll(New LUNA.LunaSearchParameter("NoEmail", enSiNo.Si, "<>"),
                                 New LUNA.LunaSearchParameter("Email", String.Empty, "<>"),
                                 New LUNA.LunaSearchParameter("Disattivo", enSiNo.Si, "<>"))
            End Using


            For Each vm As VoceRubricaMarketing In lm
                If lRis.FindAll(Function(x) x.EmailG = vm.EmailG).Count = 0 Then
                    If FormerLib.FormerHelper.Mail.IsValidEmailAddress(vm.EmailG) Then
                        lRis.Add(vm)
                    End If
                End If
            Next
        End If

        Return lRis

    End Function

    Public Function ApplicaFiltro(ByVal L As IEnumerable(Of IVoceRubricaG),
                                  G As Gruppo,
                                  Optional F As FiltroMarketing = Nothing,
                                  Optional EscludiGiaFatti As Boolean = False) As IEnumerable(Of IVoceRubricaG)

        Dim lRis As List(Of IVoceRubricaG) = L

        If G.TipoOrigine Then
            If G.TipoOrigine = enOrigineContatto.Marketing Then
                lRis = lRis.FindAll(Function(x) x.ProvenienzaVoce = "M")
            ElseIf G.TipoOrigine = enOrigineContatto.Rubrica Then
                lRis = lRis.FindAll(Function(x) x.ProvenienzaVoce <> "M")
            End If
        End If

        If G.RagSoc.Length Then
            lRis = lRis.FindAll(Function(x) x.NominativoG.ToLower.IndexOf(G.RagSoc.ToLower) <> -1)
        End If

        If G.Tipo Then
            lRis = lRis.FindAll(Function(x) x.Tipo = G.Tipo)
        End If

        If G.Citta.Length Then
            lRis = lRis.FindAll(Function(x) x.Citta.ToLower = G.Citta.ToLower)
        End If

        If G.Cap.Length Then
            lRis = lRis.FindAll(Function(x) x.Cap = G.Cap)
        End If

        If G.CategoriaMarketing Then
            lRis = lRis.FindAll(Function(x) x.IdCategoriaMarketing = G.CategoriaMarketing)
        End If

        If G.InseritiDa Then
            lRis = lRis.FindAll(Function(x) DateDiff(DateInterval.Month, x.DataInserimento, Now) <= G.InseritiDa)
        End If

        If G.HannoAcqAlmenoUn Then
            lRis = lRis.FindAll(Function(x) x.HannoAcquistatoAlmenoUnaVoltaUn(G.HannoAcqAlmenoUn) = True)
        End If

        If G.NonHannoMaiAcqUn Then
            lRis = lRis.FindAll(Function(x) x.NonHannoMaiAcquistatoUn(G.NonHannoMaiAcqUn) = True)
        End If

        If G.IdCorrierePredefinito Then
            lRis = lRis.FindAll(Function(x) x.IdCorrierePredefinito = G.IdCorrierePredefinito)
        End If

        'qui manca spesa nel periodo selezionato
        If G.SpesaNelPeriodo Then
            If G.SpesaNelPeriodoMaggioreDi Then
                lRis = lRis.FindAll(Function(x) x.SpesaComplessivaNelPeriodo(G.SpesaNelPeriodo) >= G.SpesaNelPeriodoMaggioreDi)
            ElseIf G.SpesaNelPeriodoMinoreDi Then
                lRis = lRis.FindAll(Function(x) x.SpesaComplessivaNelPeriodo(G.SpesaNelPeriodo) <= G.SpesaNelPeriodoMinoreDi)
            End If
        End If

        If G.NonHannoMaiSpeso Then
            lRis = lRis.FindAll(Function(x) x.NonHannoMaiSpeso = True)
        End If

        If G.SoloRegistratiDalSito Then
            lRis = lRis.FindAll(Function(x) x.Sorgente = "W")
        End If

        If G.RegistratiDal <> Date.MinValue Then
            lRis = lRis.FindAll(Function(x) DateDiff(DateInterval.Day, G.RegistratiDal, x.DataInserimento) > 0)
        End If

        If G.tag.Length Then
            lRis = lRis.FindAll(Function(x) x.Tag.ToLower.IndexOf(G.tag.ToLower) <> -1)
        End If

        If G.NonHannoSpesoDal <> Date.MinValue Then
            lRis = lRis.FindAll(Function(x) x.ListaOrdini.FindAll(Function(z) DateDiff(DateInterval.Day, G.NonHannoSpesoDal, z.DataIns) >= 0 And DateDiff(DateInterval.Day, z.DataIns, G.NonHannoSpesoAl) > 0).Count = 0)
        End If

        If G.HannoSpesoDal <> Date.MinValue Then
            lRis = lRis.FindAll(Function(x) x.ListaOrdini.FindAll(Function(z) DateDiff(DateInterval.Day, G.HannoSpesoDal, z.DataIns) >= 0 And DateDiff(DateInterval.Day, z.DataIns, G.HannoSpesoAl) > 0).Count <> 0)
        End If

        If Not F Is Nothing Then
            If EscludiGiaFatti Then
                Dim lRisNew As New List(Of IVoceRubricaG)
                'qui devo escludere dai risultati della lista quelli che hanno gia eseguito questo filtro per questo mese
                For Each singV As IVoceRubricaG In lRis

                    Using mgr As New LogMarketingDAO
                        If mgr.Find(New LUNA.LunaSearchParameter("IdRubG", singV.IdRubG),
                                    New LUNA.LunaSearchParameter("IdFm", F.IdFiltroMarketing),
                                    New LUNA.LunaSearchParameter("month(DataIns)", Now.Month),
                                    New LUNA.LunaSearchParameter("year(DataIns)", Now.Year)) Is Nothing Then
                            lRisNew.Add(singV)
                        End If
                    End Using

                Next
                lRis.Clear()
                lRis.AddRange(lRisNew)
            End If
        End If

        lRis.Sort(AddressOf Comparer)

        Return lRis

    End Function

    Private Function Comparer(ByVal x As IVoceRubricaG, ByVal y As IVoceRubricaG) As Integer
        Dim result As Integer = y.ProvenienzaVoce.CompareTo(x.ProvenienzaVoce)
        If result = 0 Then result = x.NominativoG.CompareTo(y.NominativoG)

        Return result
    End Function

    <Obsolete("This method is deprecated, use the version with Gruppo in parameter too.")>
    Public Function ApplicaFiltro(ByVal L As IEnumerable(Of IVoceRubricaG),
                                  F As FiltroMarketing,
                                  Optional EscludiGiaFatti As Boolean = False) As IEnumerable(Of IVoceRubricaG)
        Dim lRis As List(Of IVoceRubricaG) = Nothing
        Using G As New Gruppo
            G.Read(F.IdGruppo)
            lRis = ApplicaFiltro(L, G, F, EscludiGiaFatti)
        End Using
        Return lRis

        'Dim lRis As List(Of IVoceRubricaG) = L

        'If F.Citta.Length Then
        '    lRis = lRis.FindAll(Function(x) x.Citta.ToLower = F.Citta.ToLower)
        'End If

        'If F.Cap.Length Then
        '    lRis = lRis.FindAll(Function(x) x.Cap = F.Cap)
        'End If

        'If F.CategoriaMarketing Then
        '    lRis = lRis.FindAll(Function(x) x.IdCategoriaMarketing = F.CategoriaMarketing)
        'End If

        'If F.Tipo Then
        '    lRis = lRis.FindAll(Function(x) x.Tipo = F.Tipo)
        'End If

        'If F.TipoOrigine Then
        '    If F.TipoOrigine = enOrigineContatto.Marketing Then
        '        lRis = lRis.FindAll(Function(x) x.ProvenienzaVoce = "M")
        '    ElseIf F.TipoOrigine = enOrigineContatto.Rubrica Then
        '        lRis = lRis.FindAll(Function(x) x.ProvenienzaVoce = "R")
        '    End If
        'End If

        'If F.InseritiDa Then
        '    lRis = lRis.FindAll(Function(x) DateDiff(DateInterval.Month, x.DataInserimento, Now) <= F.InseritiDa)
        'End If

        'If F.HannoAcqAlmenoUn Then
        '    lRis = lRis.FindAll(Function(x) x.HannoAcquistatoAlmenoUnaVoltaUn(F.HannoAcqAlmenoUn) = True)
        'End If

        'If F.NonHannoMaiAcqUn Then
        '    lRis = lRis.FindAll(Function(x) x.NonHannoMaiAcquistatoUn(F.NonHannoMaiAcqUn) = True)
        'End If

        ''qui manca spesa nel periodo selezionato
        'If F.SpesaNelPeriodo Then
        '    If F.SpesaNelPeriodoMaggioreDi Then
        '        lRis = lRis.FindAll(Function(x) x.SpesaComplessivaNelPeriodo(F.SpesaNelPeriodo) >= F.SpesaNelPeriodoMaggioreDi)
        '    ElseIf F.SpesaNelPeriodoMinoreDi Then
        '        lRis = lRis.FindAll(Function(x) x.SpesaComplessivaNelPeriodo(F.SpesaNelPeriodo) <= F.SpesaNelPeriodoMinoreDi)
        '    End If
        'End If

        'If F.NonHannoMaiSpeso Then
        '    lRis = lRis.FindAll(Function(x) x.NonHannoMaiSpeso = True)
        'End If

        'If F.tag.Length Then
        '    lRis = lRis.FindAll(Function(x) x.Tag.ToLower.IndexOf(F.tag.ToLower) <> -1)
        'End If

        'If EscludiGiaFatti Then
        '    Dim lRisNew As New List(Of IVoceRubricaG)
        '    'qui devo escludere dai risultati della lista quelli che hanno gia eseguito questo filtro per questo mese
        '    For Each singV As IVoceRubricaG In lRis

        '        Using mgr As New LogMarketingDAO
        '            If mgr.Find(New LUNA.LunaSearchParameter("IdRubG", singV.IdRubG), _
        '                        New LUNA.LunaSearchParameter("IdFm", F.IdFiltroMarketing), _
        '                        New LUNA.LunaSearchParameter("month(DataIns)", Now.Month), _
        '                        New LUNA.LunaSearchParameter("year(DataIns)", Now.Year)) Is Nothing Then
        '                lRisNew.Add(singV)
        '            End If
        '        End Using

        '    Next
        '    lRis.Clear()
        '    lRis.AddRange(lRisNew)
        'End If

        'Return lRis

    End Function

End Class