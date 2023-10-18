#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/11/2018 
#End Region




Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table T_gruppivarianti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class GruppoVariante
    Inherits _GruppoVariante
    Implements IGruppoVariante

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdGruppoVariante() As Integer
        Get
            Return MyBase.IdGruppoVariante
        End Get
        Set(ByVal value As Integer)
            MyBase.IdGruppoVariante = value
        End Set
    End Property


    Public Overrides Property Nome() As String
        Get
            Return MyBase.Nome
        End Get
        Set(ByVal value As String)
            MyBase.Nome = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Private _ListaPrev As List(Of Preventivazione) = Nothing
    Public ReadOnly Property ListaPrev As List(Of Preventivazione)
        Get
            If _ListaPrev Is Nothing Then

                Using mgr As New PreventivazioniDAO
                    _ListaPrev = mgr.FindAll(LFM.Preventivazione.Descrizione,
                                             New LUNA.LunaSearchParameter(LFM.Preventivazione.GruppoVariante, IdGruppoVariante))
                End Using

            End If
            Return _ListaPrev

        End Get
    End Property

    Private _ListaTC As List(Of TipoCarta) = Nothing
    Public ReadOnly Property ListaTC As List(Of TipoCarta)
        Get
            If _ListaTC Is Nothing Then
                _ListaTC = New List(Of TipoCarta)
                Using mgr As New GruppiVariantiRifDAO
                    Dim l As List(Of GruppoVarianteRif) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.GruppoVarianteRif.IdGruppoVariante, IdGruppoVariante),
                                                                      New LUNA.LunaSearchParameter(LFM.GruppoVarianteRif.TipoRiferimento, enTipoOggettoListino.TipoCarta))

                    For Each vartc In l
                        Dim tc As New TipoCarta
                        tc.Read(vartc.IdRiferimento)
                        _ListaTC.Add(tc)
                    Next
                    _ListaTC.Sort(AddressOf FormerListSorter.TipoCartaSorter.SortFinituraNome)
                End Using

            End If
            Return _ListaTC

        End Get
    End Property

    Private _ListaCatLav As List(Of CatLav) = Nothing
    Public ReadOnly Property ListaCatLav As List(Of CatLav)
        Get
            If _ListaCatLav Is Nothing Then
                _ListaCatLav = New List(Of CatLav)
                Using mgr As New GruppiVariantiRifDAO
                    Dim l As List(Of GruppoVarianteRif) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.GruppoVarianteRif.IdGruppoVariante, IdGruppoVariante),
                                                                      New LUNA.LunaSearchParameter(LFM.GruppoVarianteRif.TipoRiferimento, enTipoOggettoListino.CatLav))

                    For Each vartc In l
                        Dim cl As New CatLav
                        cl.Read(vartc.IdRiferimento)
                        _ListaCatLav.Add(cl)
                    Next
                    _ListaCatLav.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))
                End Using

            End If
            Return _ListaCatLav

        End Get
    End Property

    ReadOnly Property PreventivazioniIncluseStr As String
        Get
            Dim ris As String = String.Empty

            For Each P As Preventivazione In ListaPrev
                ris &= P.Descrizione & "; "
            Next

            Return ris
        End Get
    End Property

    ReadOnly Property TipiCartaInclusiStr As String
        Get
            Dim ris As String = String.Empty

            For Each TC As TipoCarta In ListaTC
                ris &= TC.Tipologia & "; "
            Next

            Return ris
        End Get
    End Property

    ReadOnly Property LavorazioniIncluseStr As String
        Get
            Dim ris As String = String.Empty

            For Each P As CatLav In ListaCatLav
                ris &= P.Descrizione & "; "
            Next

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IGruppoVariante.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IGruppoVariante.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IGruppoVariante.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table T_gruppivarianti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IGruppoVariante
    Inherits _IGruppoVariante

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface