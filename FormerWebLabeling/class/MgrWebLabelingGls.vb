Imports FormerWebLabeling.GlsWS
Imports FormerWebLabeling.GlsCheckAddress
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerLib
Imports FormerConfig
Imports FormerWebLabeling.GlsWS2

Public Class MgrWebLabelingGls

    Public Shared ReadOnly Property SedeGls As String
        Get
            Return FConfiguration.Gls.Sede
        End Get
    End Property
    Public Shared ReadOnly Property CodiceClienteGls As String
        Get
            Return FConfiguration.Gls.CodiceCliente
        End Get
    End Property
    Public Shared ReadOnly Property PasswordGls As String
        Get
            Return FConfiguration.Gls.Password
        End Get
    End Property
    Public Shared ReadOnly Property CodiceContrattoGls As String
        Get
            Return FConfiguration.Gls.CodiceContratto
        End Get
    End Property

    Public Shared Function IsCorriereGls(Corriere As Corriere) As Boolean
        Dim ris As Boolean = True
        If Corriere.IdCorriere <> enCorriere.GLS And
            Corriere.IdCorriere <> enCorriere.PortoAssegnatoGLS And
            Corriere.IdCorriere <> enCorriere.GLSIsole Then
            ris = False
        End If
        Return ris
    End Function

    Public Shared Function GetSegnaCollo(Consegna As ConsegnaProgrammata,
                                         ContatoreProgressivo As Integer) As SegnaCollo

        Dim Pt As New My.Templates.ParcelTemplate
        Pt.Consegna = Consegna
        Pt.NumeroCollo = ContatoreProgressivo
        ContatoreProgressivo = Consegna.IdCons & ContatoreProgressivo
        Pt.ContatoreProgressivo = ContatoreProgressivo
        Dim Buffer As String = "<Info><SedeGls>" & SedeGls & "</SedeGls><CodiceClienteGls>" & CodiceClienteGls & "</CodiceClienteGls><PasswordClienteGls>" &
                               PasswordGls & "</PasswordClienteGls>" & Pt.TransformText & "</Info>"

        Dim ris As SegnaCollo = Nothing
        Dim Err As String = String.Empty

        Try
            Using GlsWsFormer As IlsWebServiceSoapClient = New IlsWebServiceSoapClient("IlsWebServiceSoap12")

                Dim XmlResponse As XElement = XElement.Load(GlsWsFormer.AddParcel(Buffer).CreateNavigator().ReadSubtree())

                FormerLog.ScriviRispostaGLS(Consegna.IdCons, XmlResponse)

                If XmlResponse.Name = "DescrizioneErrore" Then
                    Err = XmlResponse.Value
                    Throw New Exception(Err)
                Else
                    ris = New SegnaCollo
                    ris.bda = XmlResponse.<Parcel>.<bda>.Value
                    ris.CittaDestinatario = XmlResponse.<Parcel>.<CittaDestinatario>.Value
                    ris.CodiceZona = XmlResponse.<Parcel>.<CodiceZona>.Value
                    ris.ContatoreProgressivo = XmlResponse.<Parcel>.<ContatoreProgressivo>.Value
                    ris.DataSpedizione = XmlResponse.<Parcel>.<DataSpedizione>.Value
                    ris.DenominazioneDestinatario = XmlResponse.<Parcel>.<DenominazioneDestinatario>.Value
                    ris.DenominazioneMittente = XmlResponse.<Parcel>.<DenominazioneMittente>.Value
                    ris.DescrizioneCSM1 = XmlResponse.<Parcel>.<DescrizioneCSM1>.Value
                    ris.DescrizioneCSM2 = XmlResponse.<Parcel>.<DescrizioneCSM2>.Value
                    ris.DescrizioneSedeDestino = XmlResponse.<Parcel>.<DescrizioneSedeDestino>.Value
                    ris.DescrizioneTipoPorto = XmlResponse.<Parcel>.<DescrizioneTipoPorto>.Value
                    ris.ImportoAssegnato = XmlResponse.<Parcel>.<ImportoAssegnato>.Value
                    ris.ImportoCassegno = XmlResponse.<Parcel>.<ImportoCassegno>.Value
                    ris.IndirizzoDestinatario = XmlResponse.<Parcel>.<IndirizzoDestinatario>.Value
                    ris.NoteSpedizione = XmlResponse.<Parcel>.<NoteSpedizione>.Value
                    ris.NumeroSpedizione = XmlResponse.<Parcel>.<NumeroSpedizione>.Value
                    ris.PdfLabel = ConvertiPdfLabel(XmlResponse.<Parcel>.<PdfLabel>.Value)
                    ris.Percorso1 = XmlResponse.<Parcel>.<Percorso1>.Value
                    ris.Percorso2 = XmlResponse.<Parcel>.<Percorso2>.Value
                    ris.Percorso3 = XmlResponse.<Parcel>.<Percorso3>.Value
                    ris.PesoSpedizione = XmlResponse.<Parcel>.<PesoSpedizione>.Value
                    ris.ProgressivoCollo = XmlResponse.<Parcel>.<ProgressivoCollo>.Value
                    ris.ProvinciaDestinatario = XmlResponse.<Parcel>.<ProvinciaDestinatario>.Value
                    ris.RapportoPesoVolume = XmlResponse.<Parcel>.<RapportoPesoVolume>.Value
                    ris.reverse = XmlResponse.<Parcel>.<reverse>.Value
                    ris.RiferimentiCliente = XmlResponse.<Parcel>.<RiferimentiCliente>.Value
                    ris.SiglaCSM = XmlResponse.<Parcel>.<SiglaCSM>.Value
                    ris.SiglaMittente = XmlResponse.<Parcel>.<SiglaMittente>.Value
                    ris.SiglaSedeDestino = XmlResponse.<Parcel>.<SiglaSedeDestino>.Value
                    ris.sprinter = XmlResponse.<Parcel>.<sprinter>.Value
                    ris.TelefonoSede = XmlResponse.<Parcel>.<TelefonoSede>.Value
                    ris.TipoCollo = XmlResponse.<Parcel>.<TipoCollo>.Value
                    ris.TotaleColli = XmlResponse.<Parcel>.<TotaleColli>.Value
                    ris.TotaleImportodaIncassare = XmlResponse.<Parcel>.<TotaleImportodaIncassare>.Value
                    ris.Zpl = XmlResponse.<Parcel>.<Zpl>.Value
                    If ris.NumeroSpedizione = "999999999" Or ris.NumeroSpedizione = String.Empty Then
                        Err = XmlResponse.<Parcel>.<NoteSpedizione>.Value
                        Throw New Exception(Err)
                    End If
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ris
    End Function

    Private Shared Function ConvertiPdfLabel(PdfLabel As String) As MemoryStream
        Dim ris As MemoryStream = Nothing

        If Not PdfLabel Is Nothing Then
            Dim Pdf As Byte() = Convert.FromBase64String(PdfLabel)
            ris = New MemoryStream(Pdf)
        End If

        Return ris
    End Function

    Public Shared Function GetEtichettaPdf(ContatoreProgressivo As Integer) As MemoryStream

        Dim ris As MemoryStream = Nothing
        Try
            Using GlsWsFormer As IlsWebServiceSoapClient = New IlsWebServiceSoapClient("IlsWebServiceSoap12")
                Dim Pdf As Byte() = GlsWsFormer.GetPdf(SedeGls, CodiceClienteGls, PasswordGls, CodiceContrattoGls, ContatoreProgressivo)
                ris = New MemoryStream(Pdf)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return ris

    End Function

    Public Shared Function GetEtichettaZpl(ContatoreProgressivo As Integer) As String

        Dim ris As String = Nothing
        Try
            Using GlsWsFormer As IlsWebServiceSoapClient = New IlsWebServiceSoapClient("IlsWebServiceSoap12")
                Dim XmlResponse As XElement = XElement.Load(GlsWsFormer.GetZpl(SedeGls, CodiceClienteGls, PasswordGls, CodiceContrattoGls, ContatoreProgressivo).CreateNavigator().ReadSubtree())
                ris = XmlResponse.Value
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return ris

    End Function

    Public Shared Function TrasmettiSpedizioniGls(Consegne As List(Of ConsegnaProgrammata)) As String

        Dim ris As String = String.Empty
        Dim Buffer As String = String.Empty
        Dim IdConsOld As Integer = 0

        For Each Consegna As ConsegnaProgrammata In Consegne
            Dim Pt As New My.Templates.ParcelTemplate
            If IdConsOld <> Consegna.IdCons Then
                Pt.NumeroCollo = 1
                IdConsOld = Consegna.IdCons
            Else
                Pt.NumeroCollo = 0
            End If

            Pt.Consegna = Consegna
            Buffer += Pt.TransformText
        Next

        Buffer = "<Info><SedeGls>" & SedeGls & "</SedeGls><CodiceClienteGls>" & CodiceClienteGls & "</CodiceClienteGls><PasswordClienteGls>" &
                               PasswordGls & "</PasswordClienteGls>" & Buffer & "</Info>"
        Try
            Using GlsWsFormer As IlsWebServiceSoapClient = New IlsWebServiceSoapClient("IlsWebServiceSoap12")
                Dim XmlResponse As XElement = XElement.Load(GlsWsFormer.CloseWorkDay(Buffer).CreateNavigator().ReadSubtree())
                ris = XmlResponse.Value
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return ris

    End Function

    Public Shared Function EliminaSpedizione(CodTrack As String) As String

        Dim ris As String = String.Empty
        Try
            Using GlsWsFormer As IlsWebServiceSoapClient = New IlsWebServiceSoapClient("IlsWebServiceSoap12")
                Dim XmlResponse As XElement = XElement.Load(GlsWsFormer.DeleteSped(SedeGls, CodiceClienteGls, PasswordGls, CodTrack).CreateNavigator().ReadSubtree())
                ris = XmlResponse.Value
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return ris

    End Function

    Public Shared Function CheckAddress(ByVal Provincia As String,
                                        ByVal Cap As String,
                                        ByVal Localita As String,
                                        ByVal Indirizzo As String,
                                        ByVal IdNazione As Integer) As RisValidazioneIndirizzo

        Dim ris As New RisValidazioneIndirizzo
        If IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
            Try
                Using GlsCheckAddressSecure As wsCheckAddressSoapClient = New wsCheckAddressSoapClient("wsCheckAddressSoap121")
                    Dim XmlResponse As XElement = XElement.Load(GlsCheckAddressSecure.CheckAddress(SedeGls, CodiceClienteGls, PasswordGls, Provincia, Cap, Localita, Indirizzo).CreateNavigator().ReadSubtree())
                    ris.XmlResponse = XmlResponse.Value
                    ris.Esito = XmlResponse.<Esito>.Value
                    If ris.Esito = "Destinazione corretta." Then
                        ris.Valido = True
                    Else
                        'riempio gli indirizzi suggeriti

                        For Each singI In XmlResponse.<Address>
                            ris.ListaIndirizziSuggeriti.Add(singI.<Indirizzo>.Value & " - " & singI.<Comune>.Value & " (" & singI.<SiglaProvincia>.Value & ")")

                        Next

                    End If
                End Using
            Catch ex As Exception
                'Throw ex
            End Try
        Else
            ris.Valido = True
        End If

        Return ris

    End Function

    'Public Shared Function CheckAddress(ByVal Provincia As String,
    '                                    ByVal Cap As String,
    '                                    ByVal Localita As String,
    '                                    ByVal Indirizzo As String) As Boolean

    '    Dim ris As Boolean = False
    '    Try
    '        Using GlsCheckAddressSecure As wsCheckAddressSoapClient = New wsCheckAddressSoapClient("wsCheckAddressSoap12")
    '            Dim XmlResponse As XElement = XElement.Load(GlsCheckAddressSecure.CheckAddress(SedeGls, CodiceClienteGls, PasswordGls, Provincia, Cap, Localita, Indirizzo).CreateNavigator().ReadSubtree())
    '            If XmlResponse.<Esito>.Value = "Destinazione corretta." Then
    '                ris = True
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        'Throw ex
    '    End Try

    '    Return ris

    'End Function

End Class
