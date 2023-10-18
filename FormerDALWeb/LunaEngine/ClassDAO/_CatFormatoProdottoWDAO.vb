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
'''This class manage persistency on db of CatFormatoProdottoW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _CatFormatoProdottoWDAO
	Inherits LUNA.LunaBaseClassDAO(Of CatFormatoProdottoW)

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
	'''Read from DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return a CatFormatoProdottoW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as CatFormatoProdottoW
		Dim cls as new CatFormatoProdottoW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Td_catformatoprodotto WHERE IdCatFormatoProdotto = " & Id
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
	'''Save on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as CatFormatoProdottoW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCatFormatoProdotto = 0 Then
							sql = "INSERT INTO Td_catformatoprodotto ("
							sql &= " DescrizioneEstesa,"
							sql &= " ImgRif,"
							sql &= " Nome"
							sql &= ") VALUES ("
							sql &= " @DescrizioneEstesa,"
							sql &= " @ImgRif,"
							sql &= " @Nome"
							sql &= ")"
						Else
							sql = "UPDATE Td_catformatoprodotto SET "
							If cls.WhatIsChanged.DescrizioneEstesa Then sql &= "DescrizioneEstesa = @DescrizioneEstesa,"
							If cls.WhatIsChanged.ImgRif Then sql &= "ImgRif = @ImgRif,"
							If cls.WhatIsChanged.Nome Then sql &= "Nome = @Nome"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCatFormatoProdotto= " & cls.IdCatFormatoProdotto
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.DescrizioneEstesa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DescrizioneEstesa"
							p.Value = cls.DescrizioneEstesa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgRif"
							p.Value = cls.ImgRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Nome Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Nome"
							p.Value = cls.Nome
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCatFormatoProdotto=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCatFormatoProdotto = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCatFormatoProdotto
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCatFormatoProdotto
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
				'Dim Sql As String = "UPDATE Td_catformatoprodotto SET DELETED=True "
				Dim Sql As String = "DELETE FROM Td_catformatoprodotto"
				Sql &= " WHERE IdCatFormatoProdotto = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Td_catformatoprodotto. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Td_catformatoprodotto. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as CatFormatoProdottoW, Optional ByRef ListaObj as List (of CatFormatoProdottoW) = Nothing)
		DestroyPermanently (obj.IdCatFormatoProdotto)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CatFormatoProdottoW
		Dim ris As CatFormatoProdottoW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of CatFormatoProdottoW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return first of CatFormatoProdottoW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CatFormatoProdottoW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return first of CatFormatoProdottoW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CatFormatoProdottoW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table CatFormatoProdottoW
	''' </summary>
	''' <returns>
	'''Return first of CatFormatoProdottoW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As CatFormatoProdottoW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of CatFormatoProdottoW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatFormatoProdottoW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of CatFormatoProdottoW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatFormatoProdottoW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of CatFormatoProdottoW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatFormatoProdottoW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of CatFormatoProdottoW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatFormatoProdottoW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of CatFormatoProdottoW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of CatFormatoProdottoW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of CatFormatoProdottoW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of CatFormatoProdottoW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_catformatoprodotto by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of CatFormatoProdottoW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of CatFormatoProdottoW)
		Dim Ls As New List(Of CatFormatoProdottoW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of CatFormatoProdottoW)
		Dim Ls As New List(Of CatFormatoProdottoW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Td_catformatoprodotto" 
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
	'''Return all record on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return all record in list of CatFormatoProdottoW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of CatFormatoProdottoW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return all record in list of CatFormatoProdottoW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CatFormatoProdottoW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Td_catformatoprodotto
	''' </summary>
	''' <returns>
	'''Return all record in list of CatFormatoProdottoW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of CatFormatoProdottoW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CatFormatoProdottoW)
		Dim Ls As List(Of CatFormatoProdottoW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Td_catformatoprodotto" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of CatFormatoProdottoW)
		Dim Ls As New List(Of CatFormatoProdottoW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  CatFormatoProdottoW() With {.IdCatFormatoProdotto = 0 ,.DescrizioneEstesa = "" ,.ImgRif = "" ,.Nome = ""  })
					While myReader.Read
						Dim classe as new CatFormatoProdottoW(CType(myReader, IDataRecord))
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