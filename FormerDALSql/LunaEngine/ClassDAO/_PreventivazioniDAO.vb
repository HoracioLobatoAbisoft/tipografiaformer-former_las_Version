#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 27/01/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Preventivazione object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _PreventivazioniDAO
	Inherits LUNA.LunaBaseClassDAO(Of Preventivazione)

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
	'''Read from DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return a Preventivazione object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Preventivazione
		Dim cls as new Preventivazione

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_preventivazione WHERE IdPrev = " & Id
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
	'''Save on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Preventivazione) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdPrev = 0 Then
							sql = "INSERT INTO T_preventivazione ("
							sql &= " Descrizione,"
							sql &= " DescrizioneEstesa,"
							sql &= " DispOnline,"
							sql &= " ggFast,"
							sql &= " ggNorm,"
							sql &= " ggSlow,"
							sql &= " GoogleDescr,"
							sql &= " GraficaPerFacciata,"
							sql &= " GruppoVariante,"
							sql &= " IdColoreStampaDefault,"
							sql &= " IdFunzionePack,"
							sql &= " IdMacchinario,"
							sql &= " IdMacchinarioTaglio,"
							sql &= " IdPluginToUse,"
							sql &= " IdReparto,"
							sql &= " ImgRif,"
							sql &= " ImgSito,"
							sql &= " Linguetta,"
							sql &= " NascondiAlbero,"
							sql &= " PercCoupon,"
							sql &= " PercFast,"
							sql &= " PercSlow,"
							sql &= " Prefisso,"
							sql &= " RicaricoPubblico,"
							sql &= " SaltaCS,"
							sql &= " SaltaFP,"
							sql &= " SaltaTC,"
							sql &= " TipoProd,"
							sql &= " UrlVideo"
							sql &= ") VALUES ("
							sql &= " @Descrizione,"
							sql &= " @DescrizioneEstesa,"
							sql &= " @DispOnline,"
							sql &= " @ggFast,"
							sql &= " @ggNorm,"
							sql &= " @ggSlow,"
							sql &= " @GoogleDescr,"
							sql &= " @GraficaPerFacciata,"
							sql &= " @GruppoVariante,"
							sql &= " @IdColoreStampaDefault,"
							sql &= " @IdFunzionePack,"
							sql &= " @IdMacchinario,"
							sql &= " @IdMacchinarioTaglio,"
							sql &= " @IdPluginToUse,"
							sql &= " @IdReparto,"
							sql &= " @ImgRif,"
							sql &= " @ImgSito,"
							sql &= " @Linguetta,"
							sql &= " @NascondiAlbero,"
							sql &= " @PercCoupon,"
							sql &= " @PercFast,"
							sql &= " @PercSlow,"
							sql &= " @Prefisso,"
							sql &= " @RicaricoPubblico,"
							sql &= " @SaltaCS,"
							sql &= " @SaltaFP,"
							sql &= " @SaltaTC,"
							sql &= " @TipoProd,"
							sql &= " @UrlVideo"
							sql &= ")"
						Else
							sql = "UPDATE T_preventivazione SET "
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.DescrizioneEstesa Then sql &= "DescrizioneEstesa = @DescrizioneEstesa,"
							If cls.WhatIsChanged.DispOnline Then sql &= "DispOnline = @DispOnline,"
							If cls.WhatIsChanged.ggFast Then sql &= "ggFast = @ggFast,"
							If cls.WhatIsChanged.ggNorm Then sql &= "ggNorm = @ggNorm,"
							If cls.WhatIsChanged.ggSlow Then sql &= "ggSlow = @ggSlow,"
							If cls.WhatIsChanged.GoogleDescr Then sql &= "GoogleDescr = @GoogleDescr,"
							If cls.WhatIsChanged.GraficaPerFacciata Then sql &= "GraficaPerFacciata = @GraficaPerFacciata,"
							If cls.WhatIsChanged.GruppoVariante Then sql &= "GruppoVariante = @GruppoVariante,"
							If cls.WhatIsChanged.IdColoreStampaDefault Then sql &= "IdColoreStampaDefault = @IdColoreStampaDefault,"
							If cls.WhatIsChanged.IdFunzionePack Then sql &= "IdFunzionePack = @IdFunzionePack,"
							If cls.WhatIsChanged.IdMacchinario Then sql &= "IdMacchinario = @IdMacchinario,"
							If cls.WhatIsChanged.IdMacchinarioTaglio Then sql &= "IdMacchinarioTaglio = @IdMacchinarioTaglio,"
							If cls.WhatIsChanged.IdPluginToUse Then sql &= "IdPluginToUse = @IdPluginToUse,"
							If cls.WhatIsChanged.IdReparto Then sql &= "IdReparto = @IdReparto,"
							If cls.WhatIsChanged.ImgRif Then sql &= "ImgRif = @ImgRif,"
							If cls.WhatIsChanged.ImgSito Then sql &= "ImgSito = @ImgSito,"
							If cls.WhatIsChanged.Linguetta Then sql &= "Linguetta = @Linguetta,"
							If cls.WhatIsChanged.NascondiAlbero Then sql &= "NascondiAlbero = @NascondiAlbero,"
							If cls.WhatIsChanged.PercCoupon Then sql &= "PercCoupon = @PercCoupon,"
							If cls.WhatIsChanged.PercFast Then sql &= "PercFast = @PercFast,"
							If cls.WhatIsChanged.PercSlow Then sql &= "PercSlow = @PercSlow,"
							If cls.WhatIsChanged.Prefisso Then sql &= "Prefisso = @Prefisso,"
							If cls.WhatIsChanged.RicaricoPubblico Then sql &= "RicaricoPubblico = @RicaricoPubblico,"
							If cls.WhatIsChanged.SaltaCS Then sql &= "SaltaCS = @SaltaCS,"
							If cls.WhatIsChanged.SaltaFP Then sql &= "SaltaFP = @SaltaFP,"
							If cls.WhatIsChanged.SaltaTC Then sql &= "SaltaTC = @SaltaTC,"
							If cls.WhatIsChanged.TipoProd Then sql &= "TipoProd = @TipoProd,"
							If cls.WhatIsChanged.UrlVideo Then sql &= "UrlVideo = @UrlVideo"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdPrev= " & cls.IdPrev
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DescrizioneEstesa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DescrizioneEstesa"
							p.Value = cls.DescrizioneEstesa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DispOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DispOnline"
							p.Value = cls.DispOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ggFast Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ggFast"
							p.Value = cls.ggFast
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ggNorm Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ggNorm"
							p.Value = cls.ggNorm
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ggSlow Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ggSlow"
							p.Value = cls.ggSlow
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GoogleDescr Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GoogleDescr"
							p.Value = cls.GoogleDescr
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GraficaPerFacciata Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GraficaPerFacciata"
							p.Value = cls.GraficaPerFacciata
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.GruppoVariante Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@GruppoVariante"
							p.Value = cls.GruppoVariante
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdColoreStampaDefault Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdColoreStampaDefault"
							p.Value = cls.IdColoreStampaDefault
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdFunzionePack Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdFunzionePack"
							p.Value = cls.IdFunzionePack
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinario Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinario"
							p.Value = cls.IdMacchinario
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdMacchinarioTaglio Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdMacchinarioTaglio"
							p.Value = cls.IdMacchinarioTaglio
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdPluginToUse Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdPluginToUse"
							p.Value = cls.IdPluginToUse
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdReparto Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdReparto"
							p.Value = cls.IdReparto
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgRif"
							p.Value = cls.ImgRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgSito Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgSito"
							p.Value = cls.ImgSito
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Linguetta Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Linguetta"
							p.Value = cls.Linguetta
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.NascondiAlbero Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@NascondiAlbero"
							p.Value = cls.NascondiAlbero
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercCoupon Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercCoupon"
							p.Value = cls.PercCoupon
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercFast Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercFast"
							p.Value = cls.PercFast
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercSlow Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercSlow"
							p.Value = cls.PercSlow
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Prefisso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Prefisso"
							p.Value = cls.Prefisso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.RicaricoPubblico Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@RicaricoPubblico"
							p.Value = cls.RicaricoPubblico
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SaltaCS Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SaltaCS"
							p.Value = cls.SaltaCS
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SaltaFP Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SaltaFP"
							p.Value = cls.SaltaFP
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.SaltaTC Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@SaltaTC"
							p.Value = cls.SaltaTC
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoProd Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoProd"
							p.Value = cls.TipoProd
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.UrlVideo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@UrlVideo"
							p.Value = cls.UrlVideo
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdPrev=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdPrev = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdPrev
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdPrev
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
				'Dim Sql As String = "UPDATE T_preventivazione SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_preventivazione"
				Sql &= " WHERE IdPrev = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_preventivazione. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_preventivazione. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Preventivazione, Optional ByRef ListaObj as List (of Preventivazione) = Nothing)
		DestroyPermanently (obj.IdPrev)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Preventivazione
		Dim ris As Preventivazione = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Preventivazione) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return first of Preventivazione
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Preventivazione
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return first of Preventivazione
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Preventivazione
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Preventivazione
	''' </summary>
	''' <returns>
	'''Return first of Preventivazione
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Preventivazione
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return a list of Preventivazione
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivazione)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return a list of Preventivazione
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivazione)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return a list of Preventivazione
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivazione)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return a list of Preventivazione
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivazione)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return a list of Preventivazione
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivazione)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return a list of Preventivazione
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Preventivazione)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivazione by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Preventivazione by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Preventivazione)
		Dim Ls As New List(Of Preventivazione)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Preventivazione)
		Dim Ls As New List(Of Preventivazione)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_preventivazione" 
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
	'''Return all record on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return all record in list of Preventivazione
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Preventivazione)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return all record in list of Preventivazione
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Preventivazione)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_preventivazione
	''' </summary>
	''' <returns>
	'''Return all record in list of Preventivazione
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Preventivazione)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Preventivazione)
		Dim Ls As List(Of Preventivazione)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_preventivazione" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Preventivazione)
		Dim Ls As New List(Of Preventivazione)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Preventivazione() With {.IdPrev = 0 ,.Descrizione = EmptyItemDescription,.DescrizioneEstesa = "" ,.DispOnline = False ,.ggFast = 0 ,.ggNorm = 0 ,.ggSlow = 0 ,.GoogleDescr = "" ,.GraficaPerFacciata = 0 ,.GruppoVariante = 0 ,.IdColoreStampaDefault = 0 ,.IdFunzionePack = 0 ,.IdMacchinario = 0 ,.IdMacchinarioTaglio = 0 ,.IdPluginToUse = 0 ,.IdReparto = 0 ,.ImgRif = "" ,.ImgSito = "" ,.Linguetta = 0 ,.NascondiAlbero = 0 ,.PercCoupon = 0 ,.PercFast = 0 ,.PercSlow = 0 ,.Prefisso = "" ,.RicaricoPubblico = 0 ,.SaltaCS = 0 ,.SaltaFP = 0 ,.SaltaTC = 0 ,.TipoProd = 0 ,.UrlVideo = ""  })
					While myReader.Read
						Dim classe as new Preventivazione(CType(myReader, IDataRecord))
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