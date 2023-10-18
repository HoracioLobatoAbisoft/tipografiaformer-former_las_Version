#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 29/12/2017 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of FiltroMarketing object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _FiltriMarketingDAO
	Inherits LUNA.LunaBaseClassDAO(Of FiltroMarketing)

	''' <summary>
	'''New() create an istance of this class. Use default DB Connection
	''' </summary>
	Public Sub New()
		MyBase.New()
	End Sub

	''' <summary>
	'''New() create an istance of this class and specify an OPENED DB connection
	''' </summary>
	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	''' <summary>
	'''Read from DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return a FiltroMarketing object
	''' </returns>
	Public Overrides Function Read(Id as integer) as FiltroMarketing
		Dim cls as new FiltroMarketing

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_filtromarketing WHERE IdFiltroMarketing = " & Id
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader
					myReader.Read()
					If myReader.HasRows Then
						cls.FillFromDataRecord(CType(myReader, IDataRecord))	
					End If
					myReader.Close()
				End Using
			End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return cls
	End Function

	''' <summary>
	'''Save on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as FiltroMarketing) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdFiltroMarketing = 0 Then
							sql = "INSERT INTO T_filtromarketing ("
							sql &= " Cap,"
							sql &= " CategoriaMarketing,"
							sql &= " chkAgosto,"
							sql &= " chkAprile,"
							sql &= " chkDicembre,"
							sql &= " chkFebbraio,"
							sql &= " chkGennaio,"
							sql &= " chkGiugno,"
							sql &= " chkLuglio,"
							sql &= " chkMaggio,"
							sql &= " chkMarzo,"
							sql &= " chkNovembre,"
							sql &= " chkOttobre,"
							sql &= " chkSettembre,"
							sql &= " Citta,"
							sql &= " HannoAcqAlmenoUn,"
							sql &= " IdGruppo,"
							sql &= " InseritiDa,"
							sql &= " Nome,"
							sql &= " NonHannoMaiAcqUn,"
							sql &= " NonHannoMaiSpeso,"
							sql &= " Ricorsiva,"
							sql &= " SpesaNelPeriodo,"
							sql &= " SpesaNelPeriodoMaggioreDi,"
							sql &= " SpesaNelPeriodoMinoreDi,"
							sql &= " Stato,"
							sql &= " tag,"
							sql &= " Tipo,"
							sql &= " TipoFiltro,"
							sql &= " TipoOrigine"
							sql &= ") VALUES ("
							sql &= " @Cap,"
							sql &= " @CategoriaMarketing,"
							sql &= " @chkAgosto,"
							sql &= " @chkAprile,"
							sql &= " @chkDicembre,"
							sql &= " @chkFebbraio,"
							sql &= " @chkGennaio,"
							sql &= " @chkGiugno,"
							sql &= " @chkLuglio,"
							sql &= " @chkMaggio,"
							sql &= " @chkMarzo,"
							sql &= " @chkNovembre,"
							sql &= " @chkOttobre,"
							sql &= " @chkSettembre,"
							sql &= " @Citta,"
							sql &= " @HannoAcqAlmenoUn,"
							sql &= " @IdGruppo,"
							sql &= " @InseritiDa,"
							sql &= " @Nome,"
							sql &= " @NonHannoMaiAcqUn,"
							sql &= " @NonHannoMaiSpeso,"
							sql &= " @Ricorsiva,"
							sql &= " @SpesaNelPeriodo,"
							sql &= " @SpesaNelPeriodoMaggioreDi,"
							sql &= " @SpesaNelPeriodoMinoreDi,"
							sql &= " @Stato,"
							sql &= " @tag,"
							sql &= " @Tipo,"
							sql &= " @TipoFiltro,"
							sql &= " @TipoOrigine"
							sql &= ")"
						Else
							sql = "UPDATE T_filtromarketing SET "
							If cls.WhatIsChanged.Cap Then sql &= "Cap = @Cap,"
							If cls.WhatIsChanged.CategoriaMarketing Then sql &= "CategoriaMarketing = @CategoriaMarketing,"
							If cls.WhatIsChanged.chkAgosto Then sql &= "chkAgosto = @chkAgosto,"
							If cls.WhatIsChanged.chkAprile Then sql &= "chkAprile = @chkAprile,"
							If cls.WhatIsChanged.chkDicembre Then sql &= "chkDicembre = @chkDicembre,"
							If cls.WhatIsChanged.chkFebbraio Then sql &= "chkFebbraio = @chkFebbraio,"
							If cls.WhatIsChanged.chkGennaio Then sql &= "chkGennaio = @chkGennaio,"
							If cls.WhatIsChanged.chkGiugno Then sql &= "chkGiugno = @chkGiugno,"
							If cls.WhatIsChanged.chkLuglio Then sql &= "chkLuglio = @chkLuglio,"
							If cls.WhatIsChanged.chkMaggio Then sql &= "chkMaggio = @chkMaggio,"
							If cls.WhatIsChanged.chkMarzo Then sql &= "chkMarzo = @chkMarzo,"
							If cls.WhatIsChanged.chkNovembre Then sql &= "chkNovembre = @chkNovembre,"
							If cls.WhatIsChanged.chkOttobre Then sql &= "chkOttobre = @chkOttobre,"
							If cls.WhatIsChanged.chkSettembre Then sql &= "chkSettembre = @chkSettembre,"
							If cls.WhatIsChanged.Citta Then sql &= "Citta = @Citta,"
							If cls.WhatIsChanged.HannoAcqAlmenoUn Then sql &= "HannoAcqAlmenoUn = @HannoAcqAlmenoUn,"
							If cls.WhatIsChanged.IdGruppo Then sql &= "IdGruppo = @IdGruppo,"
							If cls.WhatIsChanged.InseritiDa Then sql &= "InseritiDa = @InseritiDa,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome,"
							If cls.WhatIsChanged.NonHannoMaiAcqUn Then sql &= "NonHannoMaiAcqUn = @NonHannoMaiAcqUn,"
							If cls.WhatIsChanged.NonHannoMaiSpeso Then sql &= "NonHannoMaiSpeso = @NonHannoMaiSpeso,"
							If cls.WhatIsChanged.Ricorsiva Then sql &= "Ricorsiva = @Ricorsiva,"
							If cls.WhatIsChanged.SpesaNelPeriodo Then sql &= "SpesaNelPeriodo = @SpesaNelPeriodo,"
							If cls.WhatIsChanged.SpesaNelPeriodoMaggioreDi Then sql &= "SpesaNelPeriodoMaggioreDi = @SpesaNelPeriodoMaggioreDi,"
							If cls.WhatIsChanged.SpesaNelPeriodoMinoreDi Then sql &= "SpesaNelPeriodoMinoreDi = @SpesaNelPeriodoMinoreDi,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.tag Then sql &= "tag = @tag,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo,"
							If cls.WhatIsChanged.TipoFiltro Then sql &= "TipoFiltro = @TipoFiltro,"
							If cls.WhatIsChanged.TipoOrigine Then sql &= "TipoOrigine = @TipoOrigine"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdFiltroMarketing= " & cls.IdFiltroMarketing
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Cap"
						p.Value = cls.Cap
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@CategoriaMarketing"
						p.Value = cls.CategoriaMarketing
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkAgosto"
						p.Value = cls.chkAgosto
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkAprile"
						p.Value = cls.chkAprile
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkDicembre"
						p.Value = cls.chkDicembre
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkFebbraio"
						p.Value = cls.chkFebbraio
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkGennaio"
						p.Value = cls.chkGennaio
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkGiugno"
						p.Value = cls.chkGiugno
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkLuglio"
						p.Value = cls.chkLuglio
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkMaggio"
						p.Value = cls.chkMaggio
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkMarzo"
						p.Value = cls.chkMarzo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkNovembre"
						p.Value = cls.chkNovembre
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkOttobre"
						p.Value = cls.chkOttobre
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@chkSettembre"
						p.Value = cls.chkSettembre
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Citta"
						p.Value = cls.Citta
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@HannoAcqAlmenoUn"
						p.Value = cls.HannoAcqAlmenoUn
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdGruppo"
						p.Value = cls.IdGruppo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@InseritiDa"
						p.Value = cls.InseritiDa
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Nome"
						p.Value = cls.Nome
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NonHannoMaiAcqUn"
						p.Value = cls.NonHannoMaiAcqUn
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NonHannoMaiSpeso"
						p.Value = cls.NonHannoMaiSpeso
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Ricorsiva"
						p.Value = cls.Ricorsiva
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@SpesaNelPeriodo"
						p.Value = cls.SpesaNelPeriodo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@SpesaNelPeriodoMaggioreDi"
						p.Value = cls.SpesaNelPeriodoMaggioreDi
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@SpesaNelPeriodoMinoreDi"
						p.Value = cls.SpesaNelPeriodoMinoreDi
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Stato"
						p.Value = cls.Stato
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@tag"
						p.Value = cls.tag
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Tipo"
						p.Value = cls.Tipo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TipoFiltro"
						p.Value = cls.TipoFiltro
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TipoOrigine"
						p.Value = cls.TipoOrigine
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdFiltroMarketing=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdFiltroMarketing = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdFiltroMarketing
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdFiltroMarketing
			End If
		Else
			throw new ApplicationException("Object data is not valid")
		End If
		Return Ris
	End Function

	Private Sub DestroyPermanently(Id as integer) 
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.Connection = _cn

				'******IMPORTANT: You can use this commented instruction to make a logical delete .
				'******Replace DELETED Field with your logic deleted field name.
				'Dim Sql As String = "UPDATE T_filtromarketing SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_filtromarketing"
				Sql &= " WHERE IdFiltroMarketing = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_filtromarketing. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_filtromarketing. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as FiltroMarketing, Optional ByRef ListaObj as List (of FiltroMarketing) = Nothing)
		DestroyPermanently (obj.IdFiltroMarketing)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FiltroMarketing
		Dim ris As FiltroMarketing = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of FiltroMarketing) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return first of FiltroMarketing
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FiltroMarketing
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return first of FiltroMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FiltroMarketing
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table FiltroMarketing
	''' </summary>
	''' <returns>
	'''Return first of FiltroMarketing
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FiltroMarketing
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return a list of FiltroMarketing
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FiltroMarketing)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return a list of FiltroMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FiltroMarketing)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return a list of FiltroMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FiltroMarketing)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return a list of FiltroMarketing
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FiltroMarketing)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return a list of FiltroMarketing
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FiltroMarketing)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return a list of FiltroMarketing
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of FiltroMarketing)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_filtromarketing by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of FiltroMarketing by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of FiltroMarketing)
		Dim Ls As New List(Of FiltroMarketing)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of FiltroMarketing)
		Dim Ls As New List(Of FiltroMarketing)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_filtromarketing" 
			For Each Par As LUNA.LunaSearchParameter In Parameter
				If Not Par Is Nothing Then
					If Sql.IndexOf("WHERE") = -1 Then Sql &= " WHERE " Else Sql &=  " " & Par.LogicOperatorStr & " "
					sql &= Par.FieldName & " " & Par.SqlOperator
					If Par.SqlOperator.ToUpper.IndexOf("IN") <> -1 Then
						sql &= " " & ApIn(Par.Value)
					Else
						sql &= " " & Ap(Par.Value)
					End If
				End if
			Next

			If SearchOption.OrderBy.Length Then Sql &= " ORDER BY " & SearchOption.OrderBy

			Ls = GetData(sql, SearchOption.AddEmptyItem)

		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function

	''' <summary>
	'''Return all record on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return all record in list of FiltroMarketing
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of FiltroMarketing)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return all record in list of FiltroMarketing
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of FiltroMarketing)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_filtromarketing
	''' </summary>
	''' <returns>
	'''Return all record in list of FiltroMarketing
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of FiltroMarketing)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of FiltroMarketing)
		Dim Ls As List(Of FiltroMarketing)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_filtromarketing" 
			If OrderByField.Length Then
				Sql &= " ORDER BY " & OrderByField
			End If
			Ls = GetData(Sql,AddEmptyItem)

		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function

	Protected Overridable Property EmptyItemDescription As String = "Selezionare una voce"

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of FiltroMarketing)
		Dim Ls As New List(Of FiltroMarketing)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  FiltroMarketing() With {.IdFiltroMarketing = 0 ,.Cap = "" ,.CategoriaMarketing = 0 ,.chkAgosto = 0 ,.chkAprile = 0 ,.chkDicembre = 0 ,.chkFebbraio = 0 ,.chkGennaio = 0 ,.chkGiugno = 0 ,.chkLuglio = 0 ,.chkMaggio = 0 ,.chkMarzo = 0 ,.chkNovembre = 0 ,.chkOttobre = 0 ,.chkSettembre = 0 ,.Citta = "" ,.HannoAcqAlmenoUn = 0 ,.IdGruppo = 0 ,.InseritiDa = 0 ,.Nome = "" ,.NonHannoMaiAcqUn = 0 ,.NonHannoMaiSpeso = 0 ,.Ricorsiva = 0 ,.SpesaNelPeriodo = 0 ,.SpesaNelPeriodoMaggioreDi = 0 ,.SpesaNelPeriodoMinoreDi = 0 ,.Stato = 0 ,.tag = "" ,.Tipo = 0 ,.TipoFiltro = 0 ,.TipoOrigine = 0  })
					While myReader.Read
						Dim classe as new FiltroMarketing(CType(myReader, IDataRecord))
						Ls.Add(classe)
					End While
					myReader.Close()
				End Using
			End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
End Class