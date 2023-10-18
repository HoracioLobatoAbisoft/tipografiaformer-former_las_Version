#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 19/03/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerBusinessLogicInterface

''' <summary>
'''DAO Class for table T_tipofustella
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class TipiFustellaWDAO
    Inherits _TipiFustellaWDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function FustelleCompatibili(P As PreventivazioneW,
                                        Base As Integer,
                                        Profondita As Integer,
                                        Altezza As Integer,
                                        lst As List(Of TipoFustellaW),
                                        BrowserCompatibileSVG As Boolean) As List(Of TipoFustellaW)

        Dim DiffMax As Integer = 5
        Dim ris As New List(Of TipoFustellaW)

        For Each F As TipoFustellaW In lst
            Dim Compatibile As Boolean = True
            If Profondita Then
                If Math.Abs(F.Profondita - Profondita) > DiffMax Then
                    Compatibile = False
                End If
            End If
            If Altezza Then
                If Math.Abs(F.Altezza - Altezza) > DiffMax Then
                    Compatibile = False
                End If
            End If
            If Base Then
                If Math.Abs(F.Base - Base) > DiffMax Then
                    Compatibile = False
                End If
            End If
            If Compatibile Then
                F.FillSVG(P, BrowserCompatibileSVG)

                'Dim mgr As New MgrPackagingDraw
                'Dim Buffer As String = String.Empty
                'Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P, F.Altezza, F.Base, F.Profondita)
                'If FormerWebApp.BrowserCompatibileSVG Then
                '    Buffer = Rsteso.BufferSVG
                'Else
                '    Buffer = "<img src=""" & P.GetImgMisure & """ class=""svgRend"">"
                'End If
                'F.RisultatoStesoAltezza = Rsteso.Heigth
                'F.RisultatoStesoBase = Rsteso.Width
                'F.SvgRender = Buffer
                ris.Add(F)
            End If
        Next

        Dim AggiungiPersonalizzata As Boolean = False

        If Profondita <> 0 Then
            If ris.FindAll(Function(x) x.Profondita = Profondita).Count = 0 Then
                AggiungiPersonalizzata = True
            End If
        End If

        If AggiungiPersonalizzata = False AndAlso Altezza <> 0 Then
            If ris.FindAll(Function(x) x.Altezza = Altezza).Count = 0 Then
                AggiungiPersonalizzata = True
            End If
        End If

        If AggiungiPersonalizzata = False AndAlso Base <> 0 Then
            If ris.FindAll(Function(x) x.Base = Base).Count = 0 Then
                AggiungiPersonalizzata = True
            End If
        End If

        'prima di aggiuyngere la personalizzata se ho tuitti e tre i valori vedo se entra
        If AggiungiPersonalizzata AndAlso (Base <> 0 And Altezza <> 0 And Profondita <> 0) Then
            Dim r As RisPackaging = MgrPluginPackaging.GetListiniBaseCompatibili(P, Altezza, Base, Profondita)

            If r.ListiniBase.Count = 0 Then
                AggiungiPersonalizzata = False
            End If

        End If

        If AggiungiPersonalizzata Then
            Dim F As New TipoFustellaW
            F.Profondita = Profondita
            F.Base = Base
            F.Altezza = Altezza

            F.FillSVG(P, BrowserCompatibileSVG)
            'Dim Buffer As String = String.Empty
            'If Base <> 0 And Altezza <> 0 And Profondita <> 0 Then
            '    Dim Rsteso As RisultatoSVGSteso = MgrPackagingDraw.GetSvgPackagingSteso(P, F.Altezza, F.Base, F.Profondita)
            '    If FormerWebApp.BrowserCompatibileSVG Then
            '        Buffer = Rsteso.BufferSVG
            '    Else
            '        Buffer = "<img src=""" & P.GetImgMisure & """ class=""svgRend"">"
            '    End If
            '    F.RisultatoStesoAltezza = Rsteso.Heigth
            '    F.RisultatoStesoBase = Rsteso.Width
            'Else
            '    Buffer = "<img src=""" & P.GetImgMisure & """ class=""svgRend"">"
            'End If

            'F.SvgRender = Buffer
            ris.Add(F)
        End If

        'ora qui ho tutte le compatibili, le ordini sempre per base che e' il primo parametro
        ris.Sort(AddressOf ComparerTipoFustella)

        Return ris

    End Function

    Private Function ComparerTipoFustella(ByVal x As TipoFustellaW, ByVal y As TipoFustellaW) As Integer
        Dim result As Integer = x.IdTipoFustella.CompareTo(y.IdTipoFustella)
        If result = 0 Then result = x.Base.CompareTo(y.Base)
        If result = 0 Then result = x.Profondita.CompareTo(y.Profondita)
        If result = 0 Then result = x.Altezza.CompareTo(y.Altezza)
        Return result
    End Function

    Public Function GetValoreMinAltezza() As Integer
        Dim ris As Integer = 0

        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand

                myCommand.CommandText = "SELECT min(altezza) as ris FROM T_tipofustella where Profondita = 0 "
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader

                    myReader.Read()
                    If myReader.HasRows Then
                        ris = myReader("ris")
                    End If
                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try


        Return ris
    End Function

    Public Function GetValoreMinBase() As Integer
        Dim ris As Integer = 0

        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand

                myCommand.CommandText = "SELECT min(base) as ris FROM T_tipofustella where Profondita = 0 "
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader

                    myReader.Read()
                    If myReader.HasRows Then
                        ris = myReader("ris")
                    End If
                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try


        Return ris
    End Function

End Class