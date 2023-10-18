#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of TipoPagamentoW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _TipiPagamentiWDAO
	Inherits LUNA.LunaBaseClassDAO(Of TipoPagamentoW)

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
	'''Read from DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return a TipoPagamentoW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as TipoPagamentoW
		Dim cls as new TipoPagamentoW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Td_tipopagamenti WHERE IdTipoPagam = " & Id
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
	'''Save on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as TipoPagamentoW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdTipoPagam = 0 Then
							sql = "INSERT INTO Td_tipopagamenti ("
							sql &= " Descrizione,"
							sql &= " ggToAdd,"
							sql &= " ImgWeb,"
							sql &= " ImportoMaggiorazione,"
							sql &= " ImportoMassimoPagabile,"
							sql &= " ModoPagam,"
							sql &= " OrdOnline,"
							sql &= " PeriodoPagam,"
							sql &= " TipoPagam"
							sql &= ") VALUES ("
							sql &= " @Descrizione,"
							sql &= " @ggToAdd,"
							sql &= " @ImgWeb,"
							sql &= " @ImportoMaggiorazione,"
							sql &= " @ImportoMassimoPagabile,"
							sql &= " @ModoPagam,"
							sql &= " @OrdOnline,"
							sql &= " @PeriodoPagam,"
							sql &= " @TipoPagam"
							sql &= ")"
						Else
							sql = "UPDATE Td_tipopagamenti SET "
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.ggToAdd Then sql &= "ggToAdd = @ggToAdd,"
							If cls.WhatIsChanged.ImgWeb Then sql &= "ImgWeb = @ImgWeb,"
							If cls.WhatIsChanged.ImportoMaggiorazione Then sql &= "ImportoMaggiorazione = @ImportoMaggiorazione,"
							If cls.WhatIsChanged.ImportoMassimoPagabile Then sql &= "ImportoMassimoPagabile = @ImportoMassimoPagabile,"
							If cls.WhatIsChanged.ModoPagam Then sql &= "ModoPagam = @ModoPagam,"
							If cls.WhatIsChanged.OrdOnline Then sql &= "OrdOnline = @OrdOnline,"
							If cls.WhatIsChanged.PeriodoPagam Then sql &= "PeriodoPagam = @PeriodoPagam,"
							If cls.WhatIsChanged.TipoPagam Then sql &= "TipoPagam = @TipoPagam"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdTipoPagam= " & cls.IdTipoPagam
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ggToAdd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ggToAdd"
							p.Value = cls.ggToAdd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgWeb Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgWeb"
							p.Value = cls.ImgWeb
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoMaggiorazione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoMaggiorazione"
							p.Value = cls.ImportoMaggiorazione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImportoMassimoPagabile Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImportoMassimoPagabile"
							p.Value = cls.ImportoMassimoPagabile
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ModoPagam Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ModoPagam"
							p.Value = cls.ModoPagam
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.OrdOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@OrdOnline"
							p.Value = cls.OrdOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PeriodoPagam Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PeriodoPagam"
							p.Value = cls.PeriodoPagam
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoPagam Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoPagam"
							p.Value = cls.TipoPagam
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdTipoPagam=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdTipoPagam = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdTipoPagam
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdTipoPagam
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
				'Dim Sql As String = "UPDATE Td_tipopagamenti SET DELETED=True "
				Dim Sql As String = "DELETE FROM Td_tipopagamenti"
				Sql &= " WHERE IdTipoPagam = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Td_tipopagamenti. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Td_tipopagamenti. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as TipoPagamentoW, Optional ByRef ListaObj as List (of TipoPagamentoW) = Nothing)
		DestroyPermanently (obj.IdTipoPagam)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoPagamentoW
		Dim ris As TipoPagamentoW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of TipoPagamentoW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return first of TipoPagamentoW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoPagamentoW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return first of TipoPagamentoW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoPagamentoW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table TipoPagamentoW
	''' </summary>
	''' <returns>
	'''Return first of TipoPagamentoW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As TipoPagamentoW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return a list of TipoPagamentoW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoPagamentoW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return a list of TipoPagamentoW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoPagamentoW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return a list of TipoPagamentoW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoPagamentoW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return a list of TipoPagamentoW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoPagamentoW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return a list of TipoPagamentoW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of TipoPagamentoW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return a list of TipoPagamentoW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of TipoPagamentoW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_tipopagamenti by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of TipoPagamentoW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of TipoPagamentoW)
		Dim Ls As New List(Of TipoPagamentoW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of TipoPagamentoW)
		Dim Ls As New List(Of TipoPagamentoW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Td_tipopagamenti" 
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
	'''Return all record on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoPagamentoW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of TipoPagamentoW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoPagamentoW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of TipoPagamentoW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Td_tipopagamenti
	''' </summary>
	''' <returns>
	'''Return all record in list of TipoPagamentoW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of TipoPagamentoW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of TipoPagamentoW)
		Dim Ls As List(Of TipoPagamentoW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Td_tipopagamenti" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of TipoPagamentoW)
		Dim Ls As New List(Of TipoPagamentoW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  TipoPagamentoW() With {.IdTipoPagam = 0 ,.Descrizione = EmptyItemDescription,.ggToAdd = 0 ,.ImgWeb = "" ,.ImportoMaggiorazione = 0 ,.ImportoMassimoPagabile = 0 ,.ModoPagam = "" ,.OrdOnline = 0 ,.PeriodoPagam = 0 ,.TipoPagam = ""  })
					While myReader.Read
						Dim classe as new TipoPagamentoW(CType(myReader, IDataRecord))
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