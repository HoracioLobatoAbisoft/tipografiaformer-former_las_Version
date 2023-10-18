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
'''This class manage persistency on db of Gruppo object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _GruppiDAO
	Inherits LUNA.LunaBaseClassDAO(Of Gruppo)

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
	'''Read from DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return a Gruppo object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Gruppo
		Dim cls as new Gruppo

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_gruppi WHERE IdGruppo = " & Id
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
	'''Save on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Gruppo) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdGruppo = 0 Then
							sql = "INSERT INTO T_gruppi ("
							sql &= " AncheNoMail,"
							sql &= " Cap,"
							sql &= " CategoriaMarketing,"
							sql &= " Citta,"
							sql &= " DocumentiInScadenzaAl,"
							sql &= " DocumentiInScadenzaDal,"
							sql &= " HannoAcqAlmenoUn,"
							sql &= " HannoSpesoAl,"
							sql &= " HannoSpesoDal,"
							sql &= " IdCorrierePredefinito,"
							sql &= " InseritiDa,"
							sql &= " LimiteMassimoSuperato,"
							sql &= " Nome,"
							sql &= " NonHannoMaiAcqUn,"
							sql &= " NonHannoMaiSpeso,"
							sql &= " NonHannoSpesoAl,"
							sql &= " NonHannoSpesoDal,"
							sql &= " RagSoc,"
							sql &= " RegistratiDal,"
							sql &= " SoloRegistratiDalSito,"
							sql &= " SpesaNelPeriodo,"
							sql &= " SpesaNelPeriodoMaggioreDi,"
							sql &= " SpesaNelPeriodoMinoreDi,"
							sql &= " Stato,"
							sql &= " tag,"
							sql &= " Tipo,"
							sql &= " TipoFiltro,"
							sql &= " TipoOrigine"
							sql &= ") VALUES ("
							sql &= " @AncheNoMail,"
							sql &= " @Cap,"
							sql &= " @CategoriaMarketing,"
							sql &= " @Citta,"
							sql &= " @DocumentiInScadenzaAl,"
							sql &= " @DocumentiInScadenzaDal,"
							sql &= " @HannoAcqAlmenoUn,"
							sql &= " @HannoSpesoAl,"
							sql &= " @HannoSpesoDal,"
							sql &= " @IdCorrierePredefinito,"
							sql &= " @InseritiDa,"
							sql &= " @LimiteMassimoSuperato,"
							sql &= " @Nome,"
							sql &= " @NonHannoMaiAcqUn,"
							sql &= " @NonHannoMaiSpeso,"
							sql &= " @NonHannoSpesoAl,"
							sql &= " @NonHannoSpesoDal,"
							sql &= " @RagSoc,"
							sql &= " @RegistratiDal,"
							sql &= " @SoloRegistratiDalSito,"
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
							sql = "UPDATE T_gruppi SET "
							If cls.WhatIsChanged.AncheNoMail Then sql &= "AncheNoMail = @AncheNoMail,"
							If cls.WhatIsChanged.Cap Then sql &= "Cap = @Cap,"
							If cls.WhatIsChanged.CategoriaMarketing Then sql &= "CategoriaMarketing = @CategoriaMarketing,"
							If cls.WhatIsChanged.Citta Then sql &= "Citta = @Citta,"
							If cls.WhatIsChanged.DocumentiInScadenzaAl Then sql &= "DocumentiInScadenzaAl = @DocumentiInScadenzaAl,"
							If cls.WhatIsChanged.DocumentiInScadenzaDal Then sql &= "DocumentiInScadenzaDal = @DocumentiInScadenzaDal,"
							If cls.WhatIsChanged.HannoAcqAlmenoUn Then sql &= "HannoAcqAlmenoUn = @HannoAcqAlmenoUn,"
							If cls.WhatIsChanged.HannoSpesoAl Then sql &= "HannoSpesoAl = @HannoSpesoAl,"
							If cls.WhatIsChanged.HannoSpesoDal Then sql &= "HannoSpesoDal = @HannoSpesoDal,"
							If cls.WhatIsChanged.IdCorrierePredefinito Then sql &= "IdCorrierePredefinito = @IdCorrierePredefinito,"
							If cls.WhatIsChanged.InseritiDa Then sql &= "InseritiDa = @InseritiDa,"
							If cls.WhatIsChanged.LimiteMassimoSuperato Then sql &= "LimiteMassimoSuperato = @LimiteMassimoSuperato,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome,"
							If cls.WhatIsChanged.NonHannoMaiAcqUn Then sql &= "NonHannoMaiAcqUn = @NonHannoMaiAcqUn,"
							If cls.WhatIsChanged.NonHannoMaiSpeso Then sql &= "NonHannoMaiSpeso = @NonHannoMaiSpeso,"
							If cls.WhatIsChanged.NonHannoSpesoAl Then sql &= "NonHannoSpesoAl = @NonHannoSpesoAl,"
							If cls.WhatIsChanged.NonHannoSpesoDal Then sql &= "NonHannoSpesoDal = @NonHannoSpesoDal,"
							If cls.WhatIsChanged.RagSoc Then sql &= "RagSoc = @RagSoc,"
							If cls.WhatIsChanged.RegistratiDal Then sql &= "RegistratiDal = @RegistratiDal,"
							If cls.WhatIsChanged.SoloRegistratiDalSito Then sql &= "SoloRegistratiDalSito = @SoloRegistratiDalSito,"
							If cls.WhatIsChanged.SpesaNelPeriodo Then sql &= "SpesaNelPeriodo = @SpesaNelPeriodo,"
							If cls.WhatIsChanged.SpesaNelPeriodoMaggioreDi Then sql &= "SpesaNelPeriodoMaggioreDi = @SpesaNelPeriodoMaggioreDi,"
							If cls.WhatIsChanged.SpesaNelPeriodoMinoreDi Then sql &= "SpesaNelPeriodoMinoreDi = @SpesaNelPeriodoMinoreDi,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.tag Then sql &= "tag = @tag,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo,"
							If cls.WhatIsChanged.TipoFiltro Then sql &= "TipoFiltro = @TipoFiltro,"
							If cls.WhatIsChanged.TipoOrigine Then sql &= "TipoOrigine = @TipoOrigine"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdGruppo= " & cls.IdGruppo
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@AncheNoMail"
						p.Value = cls.AncheNoMail
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Cap"
						p.Value = cls.Cap
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@CategoriaMarketing"
						p.Value = cls.CategoriaMarketing
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Citta"
						p.Value = cls.Citta
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@DocumentiInScadenzaAl"
						p.DbType = DbType.DateTime
						If cls.DocumentiInScadenzaAl <> Date.MinValue Then
							p.Value = cls.DocumentiInScadenzaAl
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@DocumentiInScadenzaDal"
						p.DbType = DbType.DateTime
						If cls.DocumentiInScadenzaDal <> Date.MinValue Then
							p.Value = cls.DocumentiInScadenzaDal
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@HannoAcqAlmenoUn"
						p.Value = cls.HannoAcqAlmenoUn
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@HannoSpesoAl"
						p.DbType = DbType.DateTime
						If cls.HannoSpesoAl <> Date.MinValue Then
							p.Value = cls.HannoSpesoAl
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@HannoSpesoDal"
						p.DbType = DbType.DateTime
						If cls.HannoSpesoDal <> Date.MinValue Then
							p.Value = cls.HannoSpesoDal
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdCorrierePredefinito"
						p.Value = cls.IdCorrierePredefinito
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@InseritiDa"
						p.Value = cls.InseritiDa
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@LimiteMassimoSuperato"
						p.Value = cls.LimiteMassimoSuperato
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
						p.ParameterName = "@NonHannoSpesoAl"
						p.DbType = DbType.DateTime
						If cls.NonHannoSpesoAl <> Date.MinValue Then
							p.Value = cls.NonHannoSpesoAl
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NonHannoSpesoDal"
						p.DbType = DbType.DateTime
						If cls.NonHannoSpesoDal <> Date.MinValue Then
							p.Value = cls.NonHannoSpesoDal
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@RagSoc"
						p.Value = cls.RagSoc
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@RegistratiDal"
						p.DbType = DbType.DateTime
						If cls.RegistratiDal <> Date.MinValue Then
							p.Value = cls.RegistratiDal
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@SoloRegistratiDalSito"
						p.Value = cls.SoloRegistratiDalSito
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

		            
						If cls.IdGruppo=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdGruppo = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdGruppo
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdGruppo
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
				'Dim Sql As String = "UPDATE T_gruppi SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_gruppi"
				Sql &= " WHERE IdGruppo = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_gruppi. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_gruppi. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Gruppo, Optional ByRef ListaObj as List (of Gruppo) = Nothing)
		DestroyPermanently (obj.IdGruppo)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Gruppo
		Dim ris As Gruppo = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Gruppo) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return first of Gruppo
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Gruppo
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return first of Gruppo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Gruppo
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Gruppo
	''' </summary>
	''' <returns>
	'''Return first of Gruppo
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Gruppo
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return a list of Gruppo
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Gruppo)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return a list of Gruppo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Gruppo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return a list of Gruppo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Gruppo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return a list of Gruppo
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Gruppo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return a list of Gruppo
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Gruppo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return a list of Gruppo
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Gruppo)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_gruppi by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Gruppo by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Gruppo)
		Dim Ls As New List(Of Gruppo)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Gruppo)
		Dim Ls As New List(Of Gruppo)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_gruppi" 
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
	'''Return all record on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return all record in list of Gruppo
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Gruppo)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return all record in list of Gruppo
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Gruppo)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_gruppi
	''' </summary>
	''' <returns>
	'''Return all record in list of Gruppo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Gruppo)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Gruppo)
		Dim Ls As List(Of Gruppo)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_gruppi" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Gruppo)
		Dim Ls As New List(Of Gruppo)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Gruppo() With {.IdGruppo = 0 ,.AncheNoMail = 0 ,.Cap = "" ,.CategoriaMarketing = 0 ,.Citta = "" ,.DocumentiInScadenzaAl = Nothing ,.DocumentiInScadenzaDal = Nothing ,.HannoAcqAlmenoUn = 0 ,.HannoSpesoAl = Nothing ,.HannoSpesoDal = Nothing ,.IdCorrierePredefinito = 0 ,.InseritiDa = 0 ,.LimiteMassimoSuperato = 0 ,.Nome = "" ,.NonHannoMaiAcqUn = 0 ,.NonHannoMaiSpeso = 0 ,.NonHannoSpesoAl = Nothing ,.NonHannoSpesoDal = Nothing ,.RagSoc = "" ,.RegistratiDal = Nothing ,.SoloRegistratiDalSito = 0 ,.SpesaNelPeriodo = 0 ,.SpesaNelPeriodoMaggioreDi = 0 ,.SpesaNelPeriodoMinoreDi = 0 ,.Stato = 0 ,.tag = "" ,.Tipo = 0 ,.TipoFiltro = 0 ,.TipoOrigine = 0  })
					While myReader.Read
						Dim classe as new Gruppo(CType(myReader, IDataRecord))
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