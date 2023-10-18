#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 02/05/2019 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of VoceFattura object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _VociFatturaDAO
	Inherits LUNA.LunaBaseClassDAO(Of VoceFattura)

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
	'''Read from DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return a VoceFattura object
	''' </returns>
	Public Overrides Function Read(Id as integer) as VoceFattura
		Dim cls as new VoceFattura

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_vocifat WHERE IdVoceFat = " & Id
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
	'''Save on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as VoceFattura) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdVoceFat = 0 Then
							sql = "INSERT INTO T_vocifat ("
							sql &= " Codice,"
							sql &= " Custom,"
							sql &= " Descrizione,"
							sql &= " IdDoc,"
							sql &= " IdOrd,"
							sql &= " IdRigaOriginale,"
							sql &= " Importo,"
							sql &= " ImportoSing,"
							sql &= " Iva,"
							sql &= " Qta"
							sql &= ") VALUES ("
							sql &= " @Codice,"
							sql &= " @Custom,"
							sql &= " @Descrizione,"
							sql &= " @IdDoc,"
							sql &= " @IdOrd,"
							sql &= " @IdRigaOriginale,"
							sql &= " @Importo,"
							sql &= " @ImportoSing,"
							sql &= " @Iva,"
							sql &= " @Qta"
							sql &= ")"
						Else
							sql = "UPDATE T_vocifat SET "
							If cls.WhatIsChanged.Codice Then sql &= "Codice = @Codice,"
							If cls.WhatIsChanged.Custom Then sql &= "Custom = @Custom,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.IdDoc Then sql &= "IdDoc = @IdDoc,"
							If cls.WhatIsChanged.IdOrd Then sql &= "IdOrd = @IdOrd,"
							If cls.WhatIsChanged.IdRigaOriginale Then sql &= "IdRigaOriginale = @IdRigaOriginale,"
							If cls.WhatIsChanged.Importo Then sql &= "Importo = @Importo,"
							If cls.WhatIsChanged.ImportoSing Then sql &= "ImportoSing = @ImportoSing,"
							If cls.WhatIsChanged.Iva Then sql &= "Iva = @Iva,"
							If cls.WhatIsChanged.Qta Then sql &= "Qta = @Qta"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdVoceFat= " & cls.IdVoceFat
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Codice Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Codice"
							p.Value = cls.Codice
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Custom Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Custom"
							p.Value = cls.Custom
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdDoc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdDoc"
							p.Value = cls.IdDoc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdOrd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdOrd"
							p.Value = cls.IdOrd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRigaOriginale Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRigaOriginale"
							p.Value = cls.IdRigaOriginale
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Importo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Importo"
							p.Value = cls.Importo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoSing Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoSing"
							p.Value = cls.ImportoSing
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Iva Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Iva"
							p.Value = cls.Iva
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Qta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Qta"
							p.Value = cls.Qta
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdVoceFat=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdVoceFat = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdVoceFat
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdVoceFat
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
				'Dim Sql As String = "UPDATE T_vocifat SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_vocifat"
				Sql &= " WHERE IdVoceFat = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_vocifat. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_vocifat. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as VoceFattura, Optional ByRef ListaObj as List (of VoceFattura) = Nothing)
		DestroyPermanently (obj.IdVoceFat)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceFattura
		Dim ris As VoceFattura = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of VoceFattura) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return first of VoceFattura
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceFattura
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return first of VoceFattura
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceFattura
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table VoceFattura
	''' </summary>
	''' <returns>
	'''Return first of VoceFattura
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As VoceFattura
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return a list of VoceFattura
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceFattura)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return a list of VoceFattura
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceFattura)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return a list of VoceFattura
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceFattura)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return a list of VoceFattura
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceFattura)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return a list of VoceFattura
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of VoceFattura)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return a list of VoceFattura
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of VoceFattura)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_vocifat by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of VoceFattura by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of VoceFattura)
		Dim Ls As New List(Of VoceFattura)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of VoceFattura)
		Dim Ls As New List(Of VoceFattura)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_vocifat" 
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
	'''Return all record on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceFattura
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of VoceFattura)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceFattura
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of VoceFattura)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_vocifat
	''' </summary>
	''' <returns>
	'''Return all record in list of VoceFattura
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of VoceFattura)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of VoceFattura)
		Dim Ls As List(Of VoceFattura)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_vocifat" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of VoceFattura)
		Dim Ls As New List(Of VoceFattura)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  VoceFattura() With {.IdVoceFat = 0 ,.Codice = "" ,.Custom = 0 ,.Descrizione = EmptyItemDescription,.IdDoc = 0 ,.IdOrd = 0 ,.IdRigaOriginale = 0 ,.Importo = 0 ,.ImportoSing = 0 ,.Iva = 0 ,.Qta = 0  })
					While myReader.Read
						Dim classe as new VoceFattura(CType(myReader, IDataRecord))
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