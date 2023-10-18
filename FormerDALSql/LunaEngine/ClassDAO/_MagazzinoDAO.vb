#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 26/02/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of MovimentoMagazzino object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _MagazzinoDAO
	Inherits LUNA.LunaBaseClassDAO(Of MovimentoMagazzino)

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
	'''Read from DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return a MovimentoMagazzino object
	''' </returns>
	Public Overrides Function Read(Id as integer) as MovimentoMagazzino
		Dim cls as new MovimentoMagazzino

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_magaz WHERE IdCarMag = " & Id
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
	'''Save on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as MovimentoMagazzino) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCarMag = 0 Then
							sql = "INSERT INTO T_magaz ("
							sql &= " CodiceForn,"
							sql &= " DataMov,"
							sql &= " DescrForn,"
							sql &= " IdCaricoMagazzino,"
							sql &= " IdCom,"
							sql &= " IdFat,"
							sql &= " IdForn,"
							sql &= " IdOrdineAcquisto,"
							sql &= " IdRis,"
							sql &= " IdUt,"
							sql &= " IdVoceCosto,"
							sql &= " Nota,"
							sql &= " Prezzo,"
							sql &= " PrezzoUnit,"
							sql &= " Qta,"
							sql &= " TipoMov,"
							sql &= " Urgenza"
							sql &= ") VALUES ("
							sql &= " @CodiceForn,"
							sql &= " @DataMov,"
							sql &= " @DescrForn,"
							sql &= " @IdCaricoMagazzino,"
							sql &= " @IdCom,"
							sql &= " @IdFat,"
							sql &= " @IdForn,"
							sql &= " @IdOrdineAcquisto,"
							sql &= " @IdRis,"
							sql &= " @IdUt,"
							sql &= " @IdVoceCosto,"
							sql &= " @Nota,"
							sql &= " @Prezzo,"
							sql &= " @PrezzoUnit,"
							sql &= " @Qta,"
							sql &= " @TipoMov,"
							sql &= " @Urgenza"
							sql &= ")"
						Else
							sql = "UPDATE T_magaz SET "
							If cls.WhatIsChanged.CodiceForn Then sql &= "CodiceForn = @CodiceForn,"
							If cls.WhatIsChanged.DataMov Then sql &= "DataMov = @DataMov,"
							If cls.WhatIsChanged.DescrForn Then sql &= "DescrForn = @DescrForn,"
							If cls.WhatIsChanged.IdCaricoMagazzino Then sql &= "IdCaricoMagazzino = @IdCaricoMagazzino,"
							If cls.WhatIsChanged.IdCom Then sql &= "IdCom = @IdCom,"
							If cls.WhatIsChanged.IdFat Then sql &= "IdFat = @IdFat,"
							If cls.WhatIsChanged.IdForn Then sql &= "IdForn = @IdForn,"
							If cls.WhatIsChanged.IdOrdineAcquisto Then sql &= "IdOrdineAcquisto = @IdOrdineAcquisto,"
							If cls.WhatIsChanged.IdRis Then sql &= "IdRis = @IdRis,"
							If cls.WhatIsChanged.IdUt Then sql &= "IdUt = @IdUt,"
							If cls.WhatIsChanged.IdVoceCosto Then sql &= "IdVoceCosto = @IdVoceCosto,"
							If cls.WhatIsChanged.Nota Then sql &= "Nota = @Nota,"
							If cls.WhatIsChanged.Prezzo Then sql &= "Prezzo = @Prezzo,"
							If cls.WhatIsChanged.PrezzoUnit Then sql &= "PrezzoUnit = @PrezzoUnit,"
							If cls.WhatIsChanged.Qta Then sql &= "Qta = @Qta,"
							If cls.WhatIsChanged.TipoMov Then sql &= "TipoMov = @TipoMov,"
							If cls.WhatIsChanged.Urgenza Then sql &= "Urgenza = @Urgenza"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCarMag= " & cls.IdCarMag
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.CodiceForn Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CodiceForn"
							p.Value = cls.CodiceForn
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataMov Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataMov"
							p.DbType = DbType.DateTime
							If cls.DataMov <> Date.MinValue Then
								p.Value = cls.DataMov
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DescrForn Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DescrForn"
							p.Value = cls.DescrForn
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCaricoMagazzino Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCaricoMagazzino"
							p.Value = cls.IdCaricoMagazzino
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCom"
							p.Value = cls.IdCom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdFat Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFat"
							p.Value = cls.IdFat
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdForn Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdForn"
							p.Value = cls.IdForn
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOrdineAcquisto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOrdineAcquisto"
							p.Value = cls.IdOrdineAcquisto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRis Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRis"
							p.Value = cls.IdRis
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUt Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUt"
							p.Value = cls.IdUt
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdVoceCosto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdVoceCosto"
							p.Value = cls.IdVoceCosto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nota Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nota"
							p.Value = cls.Nota
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo"
							p.Value = cls.Prezzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoUnit Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoUnit"
							p.Value = cls.PrezzoUnit
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Qta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Qta"
							p.Value = cls.Qta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoMov Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoMov"
							p.Value = cls.TipoMov
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Urgenza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Urgenza"
							p.Value = cls.Urgenza
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCarMag=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCarMag = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCarMag
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCarMag
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
				'Dim Sql As String = "UPDATE T_magaz SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_magaz"
				Sql &= " WHERE IdCarMag = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_magaz. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_magaz. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as MovimentoMagazzino, Optional ByRef ListaObj as List (of MovimentoMagazzino) = Nothing)
		DestroyPermanently (obj.IdCarMag)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As MovimentoMagazzino
		Dim ris As MovimentoMagazzino = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of MovimentoMagazzino) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return first of MovimentoMagazzino
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As MovimentoMagazzino
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return first of MovimentoMagazzino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As MovimentoMagazzino
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table MovimentoMagazzino
	''' </summary>
	''' <returns>
	'''Return first of MovimentoMagazzino
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As MovimentoMagazzino
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return a list of MovimentoMagazzino
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MovimentoMagazzino)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return a list of MovimentoMagazzino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MovimentoMagazzino)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return a list of MovimentoMagazzino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MovimentoMagazzino)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return a list of MovimentoMagazzino
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MovimentoMagazzino)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return a list of MovimentoMagazzino
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MovimentoMagazzino)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return a list of MovimentoMagazzino
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of MovimentoMagazzino)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_magaz by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of MovimentoMagazzino by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of MovimentoMagazzino)
		Dim Ls As New List(Of MovimentoMagazzino)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of MovimentoMagazzino)
		Dim Ls As New List(Of MovimentoMagazzino)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_magaz" 
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
	'''Return all record on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return all record in list of MovimentoMagazzino
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of MovimentoMagazzino)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return all record in list of MovimentoMagazzino
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of MovimentoMagazzino)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_magaz
	''' </summary>
	''' <returns>
	'''Return all record in list of MovimentoMagazzino
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of MovimentoMagazzino)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of MovimentoMagazzino)
		Dim Ls As List(Of MovimentoMagazzino)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_magaz" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of MovimentoMagazzino)
		Dim Ls As New List(Of MovimentoMagazzino)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  MovimentoMagazzino() With {.IdCarMag = 0 ,.CodiceForn = "" ,.DataMov = Nothing ,.DescrForn = "" ,.IdCaricoMagazzino = 0 ,.IdCom = 0 ,.IdFat = 0 ,.IdForn = 0 ,.IdOrdineAcquisto = 0 ,.IdRis = 0 ,.IdUt = 0 ,.IdVoceCosto = 0 ,.Nota = "" ,.Prezzo = 0 ,.PrezzoUnit = 0 ,.Qta = 0 ,.TipoMov = 0 ,.Urgenza = 0  })
					While myReader.Read
						Dim classe as new MovimentoMagazzino(CType(myReader, IDataRecord))
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