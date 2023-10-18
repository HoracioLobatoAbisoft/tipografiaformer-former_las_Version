#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 28/11/2018 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of PreventivoMail object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _PreventiviMailDAO
	Inherits LUNA.LunaBaseClassDAO(Of PreventivoMail)

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
	'''Read from DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return a PreventivoMail object
	''' </returns>
	Public Overrides Function Read(Id as integer) as PreventivoMail
		Dim cls as new PreventivoMail

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Mailpreventivi WHERE IdMailPreventivo = " & Id
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
	'''Save on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as PreventivoMail) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdMailPreventivo = 0 Then
							sql = "INSERT INTO Mailpreventivi ("
							sql &= " DalSito,"
							sql &= " DataDel,"
							sql &= " DataRif,"
							sql &= " GuidMail,"
							sql &= " IdMailRif,"
							sql &= " IdRub,"
							sql &= " IdUtDel,"
							sql &= " IdUtFormer,"
							sql &= " Letto,"
							sql &= " Mittente,"
							sql &= " PrezzoSuggerito,"
							sql &= " Stato,"
							sql &= " Testo,"
							sql &= " TipoMail,"
							sql &= " Titolo"
							sql &= ") VALUES ("
							sql &= " @DalSito,"
							sql &= " @DataDel,"
							sql &= " @DataRif,"
							sql &= " @GuidMail,"
							sql &= " @IdMailRif,"
							sql &= " @IdRub,"
							sql &= " @IdUtDel,"
							sql &= " @IdUtFormer,"
							sql &= " @Letto,"
							sql &= " @Mittente,"
							sql &= " @PrezzoSuggerito,"
							sql &= " @Stato,"
							sql &= " @Testo,"
							sql &= " @TipoMail,"
							sql &= " @Titolo"
							sql &= ")"
						Else
							sql = "UPDATE Mailpreventivi SET "
							If cls.WhatIsChanged.DalSito Then sql &= "DalSito = @DalSito,"
							If cls.WhatIsChanged.DataDel Then sql &= "DataDel = @DataDel,"
							If cls.WhatIsChanged.DataRif Then sql &= "DataRif = @DataRif,"
							If cls.WhatIsChanged.GuidMail Then sql &= "GuidMail = @GuidMail,"
							If cls.WhatIsChanged.IdMailRif Then sql &= "IdMailRif = @IdMailRif,"
							If cls.WhatIsChanged.IdRub Then sql &= "IdRub = @IdRub,"
							If cls.WhatIsChanged.IdUtDel Then sql &= "IdUtDel = @IdUtDel,"
							If cls.WhatIsChanged.IdUtFormer Then sql &= "IdUtFormer = @IdUtFormer,"
							If cls.WhatIsChanged.Letto Then sql &= "Letto = @Letto,"
							If cls.WhatIsChanged.Mittente Then sql &= "Mittente = @Mittente,"
							If cls.WhatIsChanged.PrezzoSuggerito Then sql &= "PrezzoSuggerito = @PrezzoSuggerito,"
							If cls.WhatIsChanged.Stato Then sql &= "Stato = @Stato,"
							If cls.WhatIsChanged.Testo Then sql &= "Testo = @Testo,"
							If cls.WhatIsChanged.TipoMail Then sql &= "TipoMail = @TipoMail,"
							If cls.WhatIsChanged.Titolo Then sql &= "Titolo = @Titolo"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdMailPreventivo= " & cls.IdMailPreventivo
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.DalSito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DalSito"
							p.Value = cls.DalSito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataDel Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataDel"
							p.DbType = DbType.DateTime
							If cls.DataDel <> Date.MinValue Then
								p.Value = cls.DataDel
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DataRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DataRif"
							p.DbType = DbType.DateTime
							If cls.DataRif <> Date.MinValue Then
								p.Value = cls.DataRif
							Else
								p.Value = DBNull.Value
							End If  
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GuidMail Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GuidMail"
							p.Value = cls.GuidMail
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMailRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMailRif"
							p.Value = cls.IdMailRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRub Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRub"
							p.Value = cls.IdRub
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUtDel Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUtDel"
							p.Value = cls.IdUtDel
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdUtFormer Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdUtFormer"
							p.Value = cls.IdUtFormer
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Letto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Letto"
							p.Value = cls.Letto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Mittente Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Mittente"
							p.Value = cls.Mittente
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PrezzoSuggerito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PrezzoSuggerito"
							p.Value = cls.PrezzoSuggerito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Stato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Stato"
							p.Value = cls.Stato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Testo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Testo"
							p.Value = cls.Testo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoMail Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoMail"
							p.Value = cls.TipoMail
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Titolo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Titolo"
							p.Value = cls.Titolo
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdMailPreventivo=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdMailPreventivo = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdMailPreventivo
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdMailPreventivo
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
				'Dim Sql As String = "UPDATE Mailpreventivi SET DELETED=True "
				Dim Sql As String = "DELETE FROM Mailpreventivi"
				Sql &= " WHERE IdMailPreventivo = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Mailpreventivi. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Mailpreventivi. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as PreventivoMail, Optional ByRef ListaObj as List (of PreventivoMail) = Nothing)
		DestroyPermanently (obj.IdMailPreventivo)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PreventivoMail
		Dim ris As PreventivoMail = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of PreventivoMail) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return first of PreventivoMail
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PreventivoMail
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return first of PreventivoMail
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PreventivoMail
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table PreventivoMail
	''' </summary>
	''' <returns>
	'''Return first of PreventivoMail
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As PreventivoMail
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return a list of PreventivoMail
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PreventivoMail)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return a list of PreventivoMail
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PreventivoMail)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return a list of PreventivoMail
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PreventivoMail)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return a list of PreventivoMail
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PreventivoMail)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return a list of PreventivoMail
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of PreventivoMail)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return a list of PreventivoMail
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of PreventivoMail)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Mailpreventivi by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of PreventivoMail by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of PreventivoMail)
		Dim Ls As New List(Of PreventivoMail)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of PreventivoMail)
		Dim Ls As New List(Of PreventivoMail)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Mailpreventivi" 
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
	'''Return all record on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return all record in list of PreventivoMail
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of PreventivoMail)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return all record in list of PreventivoMail
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of PreventivoMail)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Mailpreventivi
	''' </summary>
	''' <returns>
	'''Return all record in list of PreventivoMail
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of PreventivoMail)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of PreventivoMail)
		Dim Ls As List(Of PreventivoMail)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Mailpreventivi" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of PreventivoMail)
		Dim Ls As New List(Of PreventivoMail)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  PreventivoMail() With {.IdMailPreventivo = 0 ,.DalSito = 0 ,.DataDel = Nothing ,.DataRif = Nothing ,.GuidMail = "" ,.IdMailRif = 0 ,.IdRub = 0 ,.IdUtDel = 0 ,.IdUtFormer = 0 ,.Letto = 0 ,.Mittente = "" ,.PrezzoSuggerito = 0 ,.Stato = 0 ,.Testo = "" ,.TipoMail = 0 ,.Titolo = ""  })
					While myReader.Read
						Dim classe as new PreventivoMail(CType(myReader, IDataRecord))
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