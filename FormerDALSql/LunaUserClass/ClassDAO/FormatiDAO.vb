#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

''' <summary>
'''DAO Class for table Td_formato
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class FormatiDAO
    Inherits _FormatiDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub GetFormatoByTpl(PathTpl As String,
                               ByRef FormatoTrovato As Formato,
                               ByRef MacchinarioTrovato As Macchinario)
        Using R As New StreamReader(PathTpl)
            Dim CounterTrovate As Integer = 0
            While R.EndOfStream = False
                Dim riga As String = R.ReadLine

                Dim Marcatore As String = "%SSiPressSheet:"
                If riga.StartsWith(Marcatore) Then
                    CounterTrovate += 1

                    If CounterTrovate = 2 Then
                        'qui devo andare a interpretare le dimensioni 
                        Dim posizStart As Integer = riga.IndexOf(" ", Marcatore.Length)
                        Dim posizMid As Integer = riga.IndexOf(" ", posizStart + 1)
                        Dim posizEnd As Integer = riga.IndexOf(" ", posizMid + 1)
                        'primo numero 

                        Dim PrimoValore As Double = riga.Substring(posizStart, posizMid - posizStart).Replace(".", ",")
                        Dim SecondoValore As Double = riga.Substring(posizMid, posizEnd - posizMid).Replace(".", ",")

                        Dim Base As Single = 0
                        Dim Altezza As Single = 0

                        Base = FormerLib.FormerHelper.PDF.TrasformaPointInMm(PrimoValore) / 10
                        Altezza = FormerLib.FormerHelper.PDF.TrasformaPointInMm(SecondoValore) / 10

                        'CERCO IL MACCHINARIO
                        posizStart = riga.IndexOf("'")
                        posizEnd = riga.IndexOf("'", posizStart + 1)

                        Dim SiglaMacchinarioTrovato As String = riga.Substring(posizStart + 1, posizEnd - posizStart - 1)

                        Dim Parole As String() = SiglaMacchinarioTrovato.Split(" ")

                        Dim NumParole As Integer = 1
                        If Parole.Length < 2 Then
                            NumParole = 0
                        End If

                        For i As Integer = 0 To NumParole

                            SiglaMacchinarioTrovato &= Parole(i) & " "

                        Next

                        Dim l As List(Of Formato) = FindAll(New LUNA.LunaSearchParameter("Larghezza", Base),
                                                            New LUNA.LunaSearchParameter("Altezza", Altezza))

                        If l.Count Then
                            'qui per ora prendo il primo anche se in realta quale devo prendere?
                            Dim ris As Formato = l(0)
                            FormatoTrovato = ris

                            Using mgr As New FormatiSuMacchinariDAO
                                Dim lForm As List(Of FormatoSuMacchinario) = mgr.FindAll(New LUNA.LunaSearchParameter("IdFormato", FormatoTrovato.IdFormato))

                                For Each FormSuMacc In lForm
                                    If FormSuMacc.Macchinario.Descrizione.StartsWith(SiglaMacchinarioTrovato) Then
                                        MacchinarioTrovato = FormSuMacc.Macchinario
                                    End If
                                Next

                            End Using

                        End If

                    End If

                End If

            End While

        End Using

        'Return ris
    End Sub

    Public Function GetbyIdFormatoProdotto(IdFormProd As Integer,
                                           Optional AddEmpty As Boolean = False) As IEnumerable(Of Formato)
        Dim Ls As New List(Of Formato)

        Using fp As New FormatoProdotto
            fp.Read(IdFormProd)

            Using mgr As New FormatiDAO
                Dim listFM As List(Of Formato) = mgr.FindAll(New LUNA.LSO() With {.OrderBy = LFM.Formato.IdMacchinario.Name, .AddEmptyItem = AddEmpty})
                For Each Formato In listFM
                    If (Formato.LarghezzaMM >= fp.FormatoCarta.LarghezzaMM AndAlso
                        Formato.AltezzaMM >= fp.FormatoCarta.AltezzaMM) Or
                        (Formato.AltezzaMM >= fp.FormatoCarta.LarghezzaMM AndAlso
                        Formato.LarghezzaMM >= fp.FormatoCarta.AltezzaMM) Then
                        Ls.Add(Formato)
                    End If
                Next
            End Using

            'Dim LarghezzaCm As Single = fp.Larghezza / 10
            'Dim AltezzaCm As Single = fp.Lunghezza / 10
            'Ls = FindAll(New LUNA.LSO() With {.OrderBy = LFM.Formato.IdMacchinario.Name, .AddEmptyItem = AddEmpty},
            '             New LUNA.LSP(LFM.Formato.Larghezza, LarghezzaCm, ">="),
            '             New LUNA.LSP(LFM.Formato.Altezza, AltezzaCm, ">="))


        End Using


        'Try
        '    Dim sql As String = "SELECT * FROM TD_FORMATO WHERE IDFORMATO IN " &
        '        "(SELECT DISTINCT IDFORMATO FROM TR_RESA WHERE IDFORMCARTA IN " &
        '        "(SELECT IDFORMCARTA from TD_FORMATOPRODOTTO WHERE IDFORMPROD = " & IdFormProd &
        '        "))"
        '    Ls = GetData(sql, AddEmpty)
        'Catch ex As Exception
        '    ManageError(ex)
        'End Try
        Return Ls
    End Function

End Class