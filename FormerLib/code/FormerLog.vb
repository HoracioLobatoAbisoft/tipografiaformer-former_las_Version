Imports System.IO
Imports System.Xml.Linq
Imports FormerConfig
Imports FormerLib.FormerEnum

Public Class FormerLog

    Private Shared _PathLogOrdini As String = ""
    Private Shared _PathLogOrdiniInvalidati As String = ""
    Private Shared _PathLogRubrica As String = ""
    Private Shared _PathLogConsegne As String = ""
    Private Shared _PathLogPostazioni As String = ""

    Shared Sub New()
        _PathLogOrdini = FormerPath.PathLog
        _PathLogOrdiniInvalidati = FormerPath.PathLogInvalidati
        _PathLogRubrica = FormerPath.PathLogRubrica
        _PathLogConsegne = FormerPath.PathLogConsegne
        _PathLogPostazioni = FormerPath.PathLogPostazioni
    End Sub

    Public Shared Sub RegistraAccessoPostazione(UtenteConnesso As String,
                                                Versione As String,
                                                Optional UsbLogin As Boolean = False)

        If FormerConfig.FConfiguration.Debug.DisabilitaLog = False Then
            Try
                If Not _PathLogPostazioni Is Nothing AndAlso _PathLogPostazioni.Length Then
                    'PathLog &= Now.Date.ToString("yyyyMMdd") & ".log.txt"
                    Dim NomeMacchina As String = System.Environment.MachineName
                    Dim Path As String = _PathLogPostazioni & NomeMacchina & ".log.txt"
                    Dim BufferLog As String = Now.ToString("dd/MM/yyyy HH:mm.ss") & ";" & Versione & ";" & UtenteConnesso & IIf(UsbLogin, " - FORMERKEY", String.Empty)
                    Using W As New StreamWriter(Path, False)
                        W.WriteLine(BufferLog)
                    End Using
                End If

            Catch ex As Exception

            End Try
        End If



    End Sub

    Public Shared Sub ScriviRispostaGLS(IdCons As Integer,
                                        Risposta As XElement)

        If FormerConfig.FConfiguration.Debug.DisabilitaLog = False Then
            Try
                If Not _PathLogConsegne Is Nothing AndAlso _PathLogConsegne.Length Then
                    'PathLog &= Now.Date.ToString("yyyyMMdd") & ".log.txt"

                    Dim Path As String = _PathLogConsegne & IdCons & "\" & IdCons & ".glsresponse." & Now.ToString("yyyyMMddhhmmss") & ".txt"
                    FormerHelper.File.CreateLongPath(Path)
                    Using W As New StreamWriter(Path, True)
                        W.WriteLine(Risposta)
                    End Using
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Public Shared Sub ScriviVoceOrdineInvalidato(IdOrd As Integer, Testo As String, Cliente As String)
        If FormerConfig.FConfiguration.Debug.DisabilitaLog = False Then
            'registra una voce di log da qualche parte 
            Try

                If Not _PathLogOrdiniInvalidati Is Nothing AndAlso _PathLogOrdiniInvalidati.Length Then
                    'PathLog &= Now.Date.ToString("yyyyMMdd") & ".log.txt"

                    Dim Path As String = _PathLogOrdiniInvalidati & IdOrd & "\"
                    'creo una cartella dove salvare tutto quello che e' stato rifiutato
                    FormerHelper.File.CreateLongPath(Path)
                    Path &= IdOrd & ".log.txt"

                    Dim BufferLog As String = Now.ToString("dd/MM/yyyy HH:mm.ss") & ControlChars.NewLine & "********************" & ControlChars.NewLine & Cliente & ControlChars.NewLine & "********************" & ControlChars.NewLine & Testo & ControlChars.NewLine & "********************" & ControlChars.NewLine
                    Using W As New StreamWriter(Path, True)
                        W.WriteLine(BufferLog)
                    End Using
                End If

            Catch ex As Exception
                'in caso di errore non fa niente, non dovrebbe succedere e se succede perdiamo una voce di log non importa ma non deve interferire
                'con l'azione principale
            End Try
        End If

    End Sub

    <Obsolete("This method is deprecated, use MgrLogOperativi")>
    Public Shared Sub ScriviVoceConsegna(IdCons As Integer,
                                         Testo As String,
                                         DataRiferimento As Date,
                                         Optional IdOperatore As Integer = 0,
                                         Optional Chiamata1 As String = "",
                                         Optional Chiamata2 As String = "")

        If FormerConfig.FConfiguration.Debug.DisabilitaLog = False Then
            'registra una voce di log da qualche parte 
            Try
                Dim ChiamataDa As String = Chiamata1 & " - " & Chiamata2

                'Try
                '    Dim stackTrace As New Diagnostics.StackTrace
                '    Dim f As StackFrame = stackTrace.GetFrames(1)
                '    Dim m As System.Reflection.MethodBase = f.GetMethod
                '    ChiamataDa = m.ReflectedType.FullName & "." & m.Name

                '    'provo a prendere la chiamata anche prima

                '    Dim fPr As StackFrame = stackTrace.GetFrames(2)
                '    Dim mPr As System.Reflection.MethodBase = fPr.GetMethod
                '    ChiamataDa = mPr.ReflectedType.FullName & "." & mPr.Name & " - " & ChiamataDa
                'Catch ex As Exception

                'End Try

                If Not _PathLogConsegne Is Nothing AndAlso _PathLogConsegne.Length Then
                    'PathLog &= Now.Date.ToString("yyyyMMdd") & ".log.txt"

                    Dim Path As String = _PathLogConsegne & IdCons & "\" & IdCons & ".log.txt"
                    FormerHelper.File.CreateLongPath(Path)
                    Dim BufferLog As String = DataRiferimento.ToString("dd/MM/yyyy HH:mm.ss") & " - " & Testo & IIf(ChiamataDa.Length, " (Chiamata da " & ChiamataDa & ")", String.Empty)

                    If IdOperatore Then
                        BufferLog &= " - OPERATORE " & IdOperatore
                    End If

                    'My.Computer.FileSystem.WriteAllText(Path, BufferLog, True)
                    Using W As New StreamWriter(Path, True)
                        W.WriteLine(BufferLog)
                    End Using
                End If

            Catch ex As Exception

            End Try
        End If


    End Sub

    <Obsolete("This method is deprecated, use MgrLogOperativi")>
    Public Shared Sub ScriviVoceOrdine(IdOrd As Integer,
                                       Testo As String,
                                       DataRiferimento As Date,
                                       Optional Chiamata1 As String = "",
                                       Optional Chiamata2 As String = "")

        If FormerConfig.FConfiguration.Debug.DisabilitaLog = False Then
            'registra una voce di log da qualche parte 
            Try
                Dim ChiamataDa As String = Chiamata1 & " - " & Chiamata2

                'Try
                '    Dim stackTrace As New Diagnostics.StackTrace
                '    Dim f As StackFrame = stackTrace.GetFrames(1)
                '    Dim m As System.Reflection.MethodBase = f.GetMethod
                '    ChiamataDa = m.ReflectedType.FullName & "." & m.Name

                '    'provo a prendere la chiamata anche prima

                '    Dim fPr As StackFrame = stackTrace.GetFrames(2)
                '    Dim mPr As System.Reflection.MethodBase = fPr.GetMethod
                '    ChiamataDa = mPr.ReflectedType.FullName & "." & mPr.Name & " - " & ChiamataDa
                'Catch ex As Exception

                'End Try

                If Not _PathLogOrdini Is Nothing AndAlso _PathLogOrdini.Length Then
                    'PathLog &= Now.Date.ToString("yyyyMMdd") & ".log.txt"

                    Dim Path As String = _PathLogOrdini & IdOrd & "\"

                    FormerHelper.File.CreateLongPath(Path)

                    Path &= IdOrd & ".log.txt"

                    Dim BufferLog As String = DataRiferimento.ToString("dd/MM/yyyy HH:mm.ss") & " - " & Testo & IIf(ChiamataDa.Length, " (Chiamata da " & ChiamataDa & ")", String.Empty)
                    Using W As New StreamWriter(Path, True)
                        W.WriteLine(BufferLog)
                    End Using
                End If

            Catch ex As Exception
                'in caso di errore non fa niente, non dovrebbe succedere e se succede perdiamo una voce di log non importa ma non deve interferire
                'con l'azione principale
            End Try
        End If


    End Sub

    Public Shared Sub ScriviVoceRubrica(IdRub As Integer,
                                        Testo As String)
        If FormerConfig.FConfiguration.Debug.DisabilitaLog = False Then
            'registra una voce di log da qualche parte 
            Try
                If Not _PathLogRubrica Is Nothing AndAlso _PathLogRubrica.Length Then
                    'PathLog &= Now.Date.ToString("yyyyMMdd") & ".log.txt"

                    Dim Path As String = _PathLogRubrica & IdRub & ".log.txt"
                    Dim BufferLog As String = "************************* " & ControlChars.NewLine & " MODIFICA DEL " & Now.ToString("dd/MM/yyyy HH:mm.ss") & ControlChars.NewLine
                    BufferLog &= "*************************" & ControlChars.NewLine
                    BufferLog &= Testo & ControlChars.NewLine

                    Dim BufferExist As String = String.Empty
                    If FileIO.FileSystem.FileExists(Path) Then
                        Using R As New StreamReader(Path)
                            BufferExist = R.ReadToEnd
                        End Using
                    End If

                    Using W As New StreamWriter(Path)
                        W.WriteLine(BufferLog & BufferExist)
                    End Using
                End If

            Catch ex As Exception
                'in caso di errore non fa niente, non dovrebbe succedere e se succede perdiamo una voce di log non importa ma non deve interferire
                'con l'azione principale
            End Try
        End If

    End Sub

End Class
