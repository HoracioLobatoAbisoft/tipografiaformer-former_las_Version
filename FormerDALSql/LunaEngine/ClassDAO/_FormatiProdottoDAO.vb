#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 03/02/2021 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of FormatoProdotto object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _FormatiProdottoDAO
	Inherits LUNA.LunaBaseClassDAO(Of FormatoProdotto)

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
	'''Read from DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return a FormatoProdotto object
	''' </returns>
	Public Overrides Function Read(Id as integer) as FormatoProdotto
		Dim cls as new FormatoProdotto

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Td_formatoprodotto WHERE IdFormProd = " & Id
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
	'''Save on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as FormatoProdotto) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdFormProd = 0 Then
							sql = "INSERT INTO Td_formatoprodotto ("
							sql &= " DescrizioneEstesa,"
							sql &= " Formato,"
							sql &= " IdCatFormatoProdotto,"
							sql &= " IdFormCarta,"
							sql &= " ImgRif,"
							sql &= " IsLastra,"
							sql &= " IsRotolo,"
							sql &= " Larghezza,"
							sql &= " Lunghezza,"
							sql &= " NomeAlbero,"
							sql &= " numfacc,"
							sql &= " Orientabile,"
							sql &= " Orientamento,"
							sql &= " PdfTemplate,"
							sql &= " PdfTemplate3d,"
							sql &= " ProdottoFinito,"
							sql &= " Sigla"
							sql &= ") VALUES ("
							sql &= " @DescrizioneEstesa,"
							sql &= " @Formato,"
							sql &= " @IdCatFormatoProdotto,"
							sql &= " @IdFormCarta,"
							sql &= " @ImgRif,"
							sql &= " @IsLastra,"
							sql &= " @IsRotolo,"
							sql &= " @Larghezza,"
							sql &= " @Lunghezza,"
							sql &= " @NomeAlbero,"
							sql &= " @numfacc,"
							sql &= " @Orientabile,"
							sql &= " @Orientamento,"
							sql &= " @PdfTemplate,"
							sql &= " @PdfTemplate3d,"
							sql &= " @ProdottoFinito,"
							sql &= " @Sigla"
							sql &= ")"
						Else
							sql = "UPDATE Td_formatoprodotto SET "
							If cls.WhatIsChanged.DescrizioneEstesa Then sql &= "DescrizioneEstesa = @DescrizioneEstesa,"
							If cls.WhatIsChanged.Formato Then sql &= "Formato = @Formato,"
							If cls.WhatIsChanged.IdCatFormatoProdotto Then sql &= "IdCatFormatoProdotto = @IdCatFormatoProdotto,"
							If cls.WhatIsChanged.IdFormCarta Then sql &= "IdFormCarta = @IdFormCarta,"
							If cls.WhatIsChanged.ImgRif Then sql &= "ImgRif = @ImgRif,"
							If cls.WhatIsChanged.IsLastra Then sql &= "IsLastra = @IsLastra,"
							If cls.WhatIsChanged.IsRotolo Then sql &= "IsRotolo = @IsRotolo,"
							If cls.WhatIsChanged.Larghezza Then sql &= "Larghezza = @Larghezza,"
							If cls.WhatIsChanged.Lunghezza Then sql &= "Lunghezza = @Lunghezza,"
							If cls.WhatIsChanged.NomeAlbero Then sql &= "NomeAlbero = @NomeAlbero,"
							If cls.WhatIsChanged.numfacc Then sql &= "numfacc = @numfacc,"
							If cls.WhatIsChanged.Orientabile Then sql &= "Orientabile = @Orientabile,"
							If cls.WhatIsChanged.Orientamento Then sql &= "Orientamento = @Orientamento,"
							If cls.WhatIsChanged.PdfTemplate Then sql &= "PdfTemplate = @PdfTemplate,"
							If cls.WhatIsChanged.PdfTemplate3d Then sql &= "PdfTemplate3d = @PdfTemplate3d,"
							If cls.WhatIsChanged.ProdottoFinito Then sql &= "ProdottoFinito = @ProdottoFinito,"
							If cls.WhatIsChanged.Sigla Then sql &= "Sigla = @Sigla"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdFormProd= " & cls.IdFormProd
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.DescrizioneEstesa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DescrizioneEstesa"
							p.Value = cls.DescrizioneEstesa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Formato Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Formato"
							p.Value = cls.Formato
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdCatFormatoProdotto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdCatFormatoProdotto"
							p.Value = cls.IdCatFormatoProdotto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdFormCarta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFormCarta"
							p.Value = cls.IdFormCarta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgRif"
							p.Value = cls.ImgRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IsLastra Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IsLastra"
							p.Value = cls.IsLastra
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IsRotolo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IsRotolo"
							p.Value = cls.IsRotolo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Larghezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Larghezza"
							p.Value = cls.Larghezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Lunghezza Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Lunghezza"
							p.Value = cls.Lunghezza
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NomeAlbero Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NomeAlbero"
							p.Value = cls.NomeAlbero
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.numfacc Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@numfacc"
							p.Value = cls.numfacc
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Orientabile Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Orientabile"
							p.Value = cls.Orientabile
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Orientamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Orientamento"
							p.Value = cls.Orientamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PdfTemplate Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PdfTemplate"
							p.Value = cls.PdfTemplate
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PdfTemplate3d Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PdfTemplate3d"
							p.Value = cls.PdfTemplate3d
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ProdottoFinito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ProdottoFinito"
							p.Value = cls.ProdottoFinito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Sigla Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Sigla"
							p.Value = cls.Sigla
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdFormProd=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdFormProd = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdFormProd
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdFormProd
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
				'Dim Sql As String = "UPDATE Td_formatoprodotto SET DELETED=True "
				Dim Sql As String = "DELETE FROM Td_formatoprodotto"
				Sql &= " WHERE IdFormProd = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Td_formatoprodotto. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Td_formatoprodotto. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as FormatoProdotto, Optional ByRef ListaObj as List (of FormatoProdotto) = Nothing)
		DestroyPermanently (obj.IdFormProd)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FormatoProdotto
		Dim ris As FormatoProdotto = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of FormatoProdotto) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return first of FormatoProdotto
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FormatoProdotto
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return first of FormatoProdotto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FormatoProdotto
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table FormatoProdotto
	''' </summary>
	''' <returns>
	'''Return first of FormatoProdotto
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As FormatoProdotto
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of FormatoProdotto
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoProdotto)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of FormatoProdotto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoProdotto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of FormatoProdotto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoProdotto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of FormatoProdotto
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoProdotto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of FormatoProdotto
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of FormatoProdotto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return a list of FormatoProdotto
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of FormatoProdotto)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Td_formatoprodotto by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of FormatoProdotto by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of FormatoProdotto)
		Dim Ls As New List(Of FormatoProdotto)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of FormatoProdotto)
		Dim Ls As New List(Of FormatoProdotto)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Td_formatoprodotto" 
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
	'''Return all record on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return all record in list of FormatoProdotto
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of FormatoProdotto)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return all record in list of FormatoProdotto
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of FormatoProdotto)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Td_formatoprodotto
	''' </summary>
	''' <returns>
	'''Return all record in list of FormatoProdotto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of FormatoProdotto)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of FormatoProdotto)
		Dim Ls As List(Of FormatoProdotto)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Td_formatoprodotto" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of FormatoProdotto)
		Dim Ls As New List(Of FormatoProdotto)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  FormatoProdotto() With {.IdFormProd = 0 ,.DescrizioneEstesa = "" ,.Formato = "" ,.IdCatFormatoProdotto = 0 ,.IdFormCarta = 0 ,.ImgRif = "" ,.IsLastra = 0 ,.IsRotolo = 0 ,.Larghezza = 0 ,.Lunghezza = 0 ,.NomeAlbero = "" ,.numfacc = 0 ,.Orientabile = 0 ,.Orientamento = 0 ,.PdfTemplate = "" ,.PdfTemplate3d = "" ,.ProdottoFinito = False ,.Sigla = ""  })
					While myReader.Read
						Dim classe as new FormatoProdotto(CType(myReader, IDataRecord))
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