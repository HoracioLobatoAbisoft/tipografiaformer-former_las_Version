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
Public Class GruppoVarianteW
    Inherits _GruppoVarianteW
    Implements IGruppoVarianteW

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

    Public Function GetListinibyGruppoVariante() As List(Of ListinoBaseW)

        Dim sql As String = "select l.* from t_listinobase l, T_preventivazione p where l.idprev = p.idprev and p.gruppovariante = " & IdGruppoVariante

        sql &= " union select * from t_listinobase where idlistinobase in (select idlistinobase from Tr_PrevListino where idpreventivazione in(select idprev from t_preventivazione where gruppovariante = " & IdGruppoVariante & "))"

        sql &= " order by idprev "
        Dim ris As List(Of ListinoBaseW) = Nothing
        Using mgr As New ListinoBaseWDAO
            ris = mgr.GetBySQL(sql)
        End Using
        Return ris

    End Function


    Public Function GetTipiCartabyGruppoVariante() As List(Of TipoCartaW)
        Dim ris As New List(Of TipoCartaW)

        Using mgr As New GruppiVariantiRifWDAO
            Dim l As List(Of GruppoVarianteRifW) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.GruppoVarianteRifW.IdGruppoVariante, IdGruppoVariante),
                                                               New LUNA.LunaSearchParameter(LFM.GruppoVarianteRifW.TipoRiferimento, enTipoOggettoListino.TipoCarta))

            For Each O In l
                Dim tc As New TipoCartaW
                tc.Read(O.IdRiferimento)
                ris.Add(tc)
            Next

        End Using

        Return ris

    End Function

    Public Function GeCatLavbyGruppoVariante() As List(Of CatLavW)
        Dim ris As New List(Of CatLavW)

        Using mgr As New GruppiVariantiRifWDAO
            Dim l As List(Of GruppoVarianteRifW) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.GruppoVarianteRifW.IdGruppoVariante, IdGruppoVariante),
                                                               New LUNA.LunaSearchParameter(LFM.GruppoVarianteRifW.TipoRiferimento, enTipoOggettoListino.CatLav))

            For Each O In l
                Dim tc As New CatLavW
                tc.Read(O.IdRiferimento)
                ris.Add(tc)
            Next

        End Using

        Return ris

    End Function

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IGruppoVarianteW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IGruppoVarianteW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IGruppoVarianteW.Save
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

Public Interface IGruppoVarianteW
    Inherits _IGruppoVarianteW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface