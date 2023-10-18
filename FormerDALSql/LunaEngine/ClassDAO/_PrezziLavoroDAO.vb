#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 27/04/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of PrezzoLavoro object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _PrezziLavoroDAO
	Inherits LUNA.LunaBaseClassDAO(Of PrezzoLavoro)

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
	'''Read from DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return a PrezzoLavoro object
	''' </returns>
	Public Overrides Function Read(Id as integer) as PrezzoLavoro
		Dim cls as new PrezzoLavoro

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_prezzilavoro WHERE IdLavPrezzo = " & Id
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
	'''Save on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as PrezzoLavoro) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdLavPrezzo = 0 Then
							sql = "INSERT INTO T_prezzilavoro ("
							sql &= " IdFormProd,"
							sql &= " IdLavoro,"
							sql &= " Prezzo,"
							sql &= " Prezzo2,"
							sql &= " PrezzoMin,"
							sql &= " PrezzoMin2,"
							sql &= " PrezzoOltre,"
							sql &= " PrezzoOltre2,"
							sql &= " QtaRif,"
							sql &= " TipoGrandezza"
							sql &= ") VALUES ("
							sql &= " @IdFormProd,"
							sql &= " @IdLavoro,"
							sql &= " @Prezzo,"
							sql &= " @Prezzo2,"
							sql &= " @PrezzoMin,"
							sql &= " @PrezzoMin2,"
							sql &= " @PrezzoOltre,"
							sql &= " @PrezzoOltre2,"
							sql &= " @QtaRif,"
							sql &= " @TipoGrandezza"
							sql &= ")"
						Else
							sql = "UPDATE T_prezzilavoro SET "
							If cls.WhatIsChanged.IdFormProd Then sql &= "IdFormProd = @IdFormProd,"
							If cls.WhatIsChanged.IdLavoro Then sql &= "IdLavoro = @IdLavoro,"
							If cls.WhatIsChanged.Prezzo Then sql &= "Prezzo = @Prezzo,"
							If cls.WhatIsChanged.Prezzo2 Then sql &= "Prezzo2 = @Prezzo2,"
							If cls.WhatIsChanged.PrezzoMin Then sql &= "PrezzoMin = @PrezzoMin,"
							If cls.WhatIsChanged.PrezzoMin2 Then sql &= "PrezzoMin2 = @PrezzoMin2,"
							If cls.WhatIsChanged.PrezzoOltre Then sql &= "PrezzoOltre = @PrezzoOltre,"
							If cls.WhatIsChanged.PrezzoOltre2 Then sql &= "PrezzoOltre2 = @PrezzoOltre2,"
							If cls.WhatIsChanged.QtaRif Then sql &= "QtaRif = @QtaRif,"
							If cls.WhatIsChanged.TipoGrandezza Then sql &= "TipoGrandezza = @TipoGrandezza"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdLavPrezzo= " & cls.IdLavPrezzo
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IdFormProd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFormProd"
							p.Value = cls.IdFormProd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdLavoro Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdLavoro"
							p.Value = cls.IdLavoro
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo"
							p.Value = cls.Prezzo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prezzo2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prezzo2"
							p.Value = cls.Prezzo2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoMin Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoMin"
							p.Value = cls.PrezzoMin
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoMin2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoMin2"
							p.Value = cls.PrezzoMin2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoOltre Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoOltre"
							p.Value = cls.PrezzoOltre
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoOltre2 Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoOltre2"
							p.Value = cls.PrezzoOltre2
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.QtaRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@QtaRif"
							p.Value = cls.QtaRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoGrandezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoGrandezza"
							p.Value = cls.TipoGrandezza
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdLavPrezzo=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdLavPrezzo = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdLavPrezzo
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdLavPrezzo
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
				'Dim Sql As String = "UPDATE T_prezzilavoro SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_prezzilavoro"
				Sql &= " WHERE IdLavPrezzo = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_prezzilavoro. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_prezzilavoro. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as PrezzoLavoro, Optional ByRef ListaObj as List (of PrezzoLavoro) = Nothing)
		DestroyPermanently (obj.IdLavPrezzo)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PrezzoLavoro
		Dim ris As PrezzoLavoro = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of PrezzoLavoro) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return first of PrezzoLavoro
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PrezzoLavoro
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return first of PrezzoLavoro
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PrezzoLavoro
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table PrezzoLavoro
	''' </summary>
	''' <returns>
	'''Return first of PrezzoLavoro
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PrezzoLavoro
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return a list of PrezzoLavoro
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PrezzoLavoro)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return a list of PrezzoLavoro
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PrezzoLavoro)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return a list of PrezzoLavoro
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PrezzoLavoro)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return a list of PrezzoLavoro
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PrezzoLavoro)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return a list of PrezzoLavoro
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PrezzoLavoro)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return a list of PrezzoLavoro
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of PrezzoLavoro)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prezzilavoro by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of PrezzoLavoro by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of PrezzoLavoro)
		Dim Ls As New List(Of PrezzoLavoro)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of PrezzoLavoro)
		Dim Ls As New List(Of PrezzoLavoro)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_prezzilavoro" 
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
	'''Return all record on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return all record in list of PrezzoLavoro
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of PrezzoLavoro)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return all record in list of PrezzoLavoro
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of PrezzoLavoro)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_prezzilavoro
	''' </summary>
	''' <returns>
	'''Return all record in list of PrezzoLavoro
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of PrezzoLavoro)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of PrezzoLavoro)
		Dim Ls As List(Of PrezzoLavoro)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_prezzilavoro" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of PrezzoLavoro)
		Dim Ls As New List(Of PrezzoLavoro)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  PrezzoLavoro() With {.IdLavPrezzo = 0 ,.IdFormProd = 0 ,.IdLavoro = 0 ,.Prezzo = 0 ,.Prezzo2 = 0 ,.PrezzoMin = 0 ,.PrezzoMin2 = 0 ,.PrezzoOltre = 0 ,.PrezzoOltre2 = 0 ,.QtaRif = 0 ,.TipoGrandezza = 0  })
					While myReader.Read
						Dim classe as new PrezzoLavoro(CType(myReader, IDataRecord))
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