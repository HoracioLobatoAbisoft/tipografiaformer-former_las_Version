#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 12/03/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of CheckMassivo object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _CheckMassiviDAO
	Inherits LUNA.LunaBaseClassDAO(Of CheckMassivo)

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
	'''Read from DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return a CheckMassivo object
	''' </returns>
	Public Overrides Function Read(Id as integer) as CheckMassivo
		Dim cls as new CheckMassivo

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_checkmassivi WHERE IdCheckMassivo = " & Id
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
	'''Save on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as CheckMassivo) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCheckMassivo = 0 Then
							sql = "INSERT INTO T_checkmassivi ("
							sql &= " AnnoRiferimento,"
							sql &= " FileInputPath,"
							sql &= " FileOutputPath,"
							sql &= " IdAzienda,"
							sql &= " IdUtStep1,"
							sql &= " IdUtStep2,"
							sql &= " MeseRiferimento,"
							sql &= " QuandoStep1,"
							sql &= " QuandoStep2,"
							sql &= " Stato,"
							sql &= " TipoCheck"
							sql &= ") VALUES ("
							sql &= " @AnnoRiferimento,"
							sql &= " @FileInputPath,"
							sql &= " @FileOutputPath,"
							sql &= " @IdAzienda,"
							sql &= " @IdUtStep1,"
							sql &= " @IdUtStep2,"
							sql &= " @MeseRiferimento,"
							sql &= " @QuandoStep1,"
							sql &= " @QuandoStep2,"
							sql &= " @Stato,"
							sql &= " @TipoCheck"
							sql &= ")"
						Else
							sql = "UPDATE T_checkmassivi SET "
							If cls.WhatIsChanged.AnnoRiferimento Then sql &= "AnnoRiferimento = @AnnoRiferimento,"
							If cls.WhatIsChanged.FileInputPath Then sql &= "FileInputPath = @FileInputPath,"
							If cls.WhatIsChanged.FileOutputPath Then sql &= "FileOutputPath = @FileOutputPath,"
							If cls.WhatIsChanged.IdAzienda Then sql &= "IdAzienda = @IdAzienda,"
							If cls.WhatIsChanged.IdUtStep1 Then sql &= "IdUtStep1 = @IdUtStep1,"
							If cls.WhatIsChanged.IdUtStep2 Then sql &= "IdUtStep2 = @IdUtStep2,"
							If cls.WhatIsChanged.MeseRiferimento Then sql &= "MeseRiferimento = @MeseRiferimento,"
							If cls.WhatIsChanged.QuandoStep1 Then sql &= "QuandoStep1 = @QuandoStep1,"
							If cls.WhatIsChanged.QuandoStep2 Then sql &= "QuandoStep2 = @QuandoStep2,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.TipoCheck Then sql &= "TipoCheck = @TipoCheck"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCheckMassivo= " & cls.IdCheckMassivo
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.AnnoRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AnnoRiferimento"
							p.Value = cls.AnnoRiferimento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FileInputPath Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FileInputPath"
							p.Value = cls.FileInputPath
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.FileOutputPath Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@FileOutputPath"
							p.Value = cls.FileOutputPath
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdAzienda Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdAzienda"
							p.Value = cls.IdAzienda
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUtStep1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUtStep1"
							p.Value = cls.IdUtStep1
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUtStep2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUtStep2"
							p.Value = cls.IdUtStep2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MeseRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MeseRiferimento"
							p.Value = cls.MeseRiferimento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.QuandoStep1 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@QuandoStep1"
							p.DbType = DbType.DateTime
							If cls.QuandoStep1 <> Date.MinValue Then
								p.Value = cls.QuandoStep1
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.QuandoStep2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@QuandoStep2"
							p.DbType = DbType.DateTime
							If cls.QuandoStep2 <> Date.MinValue Then
								p.Value = cls.QuandoStep2
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoCheck Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoCheck"
							p.Value = cls.TipoCheck
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCheckMassivo=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCheckMassivo = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCheckMassivo
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCheckMassivo
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
				'Dim Sql As String = "UPDATE T_checkmassivi SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_checkmassivi"
				Sql &= " WHERE IdCheckMassivo = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_checkmassivi. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_checkmassivi. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as CheckMassivo, Optional ByRef ListaObj as List (of CheckMassivo) = Nothing)
		DestroyPermanently (obj.IdCheckMassivo)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CheckMassivo
		Dim ris As CheckMassivo = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of CheckMassivo) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return first of CheckMassivo
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CheckMassivo
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return first of CheckMassivo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CheckMassivo
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table CheckMassivo
	''' </summary>
	''' <returns>
	'''Return first of CheckMassivo
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CheckMassivo
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return a list of CheckMassivo
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CheckMassivo)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return a list of CheckMassivo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CheckMassivo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return a list of CheckMassivo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CheckMassivo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return a list of CheckMassivo
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CheckMassivo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return a list of CheckMassivo
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CheckMassivo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return a list of CheckMassivo
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of CheckMassivo)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_checkmassivi by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of CheckMassivo by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of CheckMassivo)
		Dim Ls As New List(Of CheckMassivo)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of CheckMassivo)
		Dim Ls As New List(Of CheckMassivo)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_checkmassivi" 
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
	'''Return all record on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return all record in list of CheckMassivo
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of CheckMassivo)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return all record in list of CheckMassivo
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CheckMassivo)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_checkmassivi
	''' </summary>
	''' <returns>
	'''Return all record in list of CheckMassivo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CheckMassivo)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CheckMassivo)
		Dim Ls As List(Of CheckMassivo)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_checkmassivi" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CheckMassivo)
		Dim Ls As New List(Of CheckMassivo)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  CheckMassivo() With {.IdCheckMassivo = 0 ,.AnnoRiferimento = 0 ,.FileInputPath = "" ,.FileOutputPath = "" ,.IdAzienda = 0 ,.IdUtStep1 = 0 ,.IdUtStep2 = 0 ,.MeseRiferimento = 0 ,.QuandoStep1 = Nothing ,.QuandoStep2 = Nothing ,.Stato = 0 ,.TipoCheck = 0  })
					While myReader.Read
						Dim classe as new CheckMassivo(CType(myReader, IDataRecord))
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