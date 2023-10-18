#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 23/03/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Indiciricerca
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _IndiceRicerca
	Inherits LUNA.LunaBaseClassEntity
	Implements _IIndiceRicerca
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IIndiceRicerca.FillFromDataRecord
		IdIndiceRicerca = myRecord("IdIndiceRicerca")
		IdListinoBase = myRecord("IdListinoBase")
		IdPrev = myRecord("IdPrev")
		InEvidenza = myRecord("InEvidenza")
		if not myRecord("NomeListino") is DBNull.Value then NomeListino = myRecord("NomeListino")
		PercCoupon = myRecord("PercCoupon")
		if not myRecord("Prezzo1") is DBNull.Value then Prezzo1 = myRecord("Prezzo1")
		if not myRecord("Prezzo1Riv") is DBNull.Value then Prezzo1Riv = myRecord("Prezzo1Riv")
		if not myRecord("Prezzo2") is DBNull.Value then Prezzo2 = myRecord("Prezzo2")
		if not myRecord("Prezzo2Riv") is DBNull.Value then Prezzo2Riv = myRecord("Prezzo2Riv")
		if not myRecord("Prezzo3") is DBNull.Value then Prezzo3 = myRecord("Prezzo3")
		if not myRecord("Prezzo3Riv") is DBNull.Value then Prezzo3Riv = myRecord("Prezzo3Riv")
		ProdottoFinito = myRecord("ProdottoFinito")
		Qta1 = myRecord("Qta1")
		Qta2 = myRecord("Qta2")
		Qta3 = myRecord("Qta3")
		TotOrdini = myRecord("TotOrdini")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of IndiceRicerca)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(IndiciRicercaDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of IndiceRicerca))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdIndiceRicerca As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPrev As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property InEvidenza As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property NomeListino As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercCoupon As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo1Riv As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo2Riv As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Prezzo3Riv As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ProdottoFinito As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta1 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta2 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Qta3 As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property TotOrdini As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdIndiceRicerca = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPrev = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.InEvidenza = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.NomeListino = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercCoupon = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo1Riv = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo2Riv = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Prezzo3Riv = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ProdottoFinito = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta1 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta2 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Qta3 = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.TotOrdini = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdIndiceRicerca as integer  = 0 
	Public Overridable Property IdIndiceRicerca() as integer  Implements _IIndiceRicerca.IdIndiceRicerca
		Get
			Return _IdIndiceRicerca
		End Get
		Set (byval value as integer)
			If _IdIndiceRicerca <> value Then
				IsChanged = True
				WhatIsChanged.IdIndiceRicerca = True
				_IdIndiceRicerca = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IIndiceRicerca.IdListinoBase
		Get
			Return _IdListinoBase
		End Get
		Set (byval value as integer)
			If _IdListinoBase <> value Then
				IsChanged = True
				WhatIsChanged.IdListinoBase = True
				_IdListinoBase = value
			End If
		End Set
	End property 

	Protected _IdPrev as integer  = 0 
	Public Overridable Property IdPrev() as integer  Implements _IIndiceRicerca.IdPrev
		Get
			Return _IdPrev
		End Get
		Set (byval value as integer)
			If _IdPrev <> value Then
				IsChanged = True
				WhatIsChanged.IdPrev = True
				_IdPrev = value
			End If
		End Set
	End property 

	Protected _InEvidenza as integer  = 0 
	Public Overridable Property InEvidenza() as integer  Implements _IIndiceRicerca.InEvidenza
		Get
			Return _InEvidenza
		End Get
		Set (byval value as integer)
			If _InEvidenza <> value Then
				IsChanged = True
				WhatIsChanged.InEvidenza = True
				_InEvidenza = value
			End If
		End Set
	End property 

	Protected _NomeListino as string  = "" 
	Public Overridable Property NomeListino() as string  Implements _IIndiceRicerca.NomeListino
		Get
			Return _NomeListino
		End Get
		Set (byval value as string)
			If _NomeListino <> value Then
				IsChanged = True
				WhatIsChanged.NomeListino = True
				_NomeListino = value
			End If
		End Set
	End property 

	Protected _PercCoupon as integer  = 0 
	Public Overridable Property PercCoupon() as integer  Implements _IIndiceRicerca.PercCoupon
		Get
			Return _PercCoupon
		End Get
		Set (byval value as integer)
			If _PercCoupon <> value Then
				IsChanged = True
				WhatIsChanged.PercCoupon = True
				_PercCoupon = value
			End If
		End Set
	End property 

	Protected _Prezzo1 as decimal  = 0 
	Public Overridable Property Prezzo1() as decimal  Implements _IIndiceRicerca.Prezzo1
		Get
			Return _Prezzo1
		End Get
		Set (byval value as decimal)
			If _Prezzo1 <> value Then
				IsChanged = True
				WhatIsChanged.Prezzo1 = True
				_Prezzo1 = value
			End If
		End Set
	End property 

	Protected _Prezzo1Riv as decimal  = 0 
	Public Overridable Property Prezzo1Riv() as decimal  Implements _IIndiceRicerca.Prezzo1Riv
		Get
			Return _Prezzo1Riv
		End Get
		Set (byval value as decimal)
			If _Prezzo1Riv <> value Then
				IsChanged = True
				WhatIsChanged.Prezzo1Riv = True
				_Prezzo1Riv = value
			End If
		End Set
	End property 

	Protected _Prezzo2 as decimal  = 0 
	Public Overridable Property Prezzo2() as decimal  Implements _IIndiceRicerca.Prezzo2
		Get
			Return _Prezzo2
		End Get
		Set (byval value as decimal)
			If _Prezzo2 <> value Then
				IsChanged = True
				WhatIsChanged.Prezzo2 = True
				_Prezzo2 = value
			End If
		End Set
	End property 

	Protected _Prezzo2Riv as decimal  = 0 
	Public Overridable Property Prezzo2Riv() as decimal  Implements _IIndiceRicerca.Prezzo2Riv
		Get
			Return _Prezzo2Riv
		End Get
		Set (byval value as decimal)
			If _Prezzo2Riv <> value Then
				IsChanged = True
				WhatIsChanged.Prezzo2Riv = True
				_Prezzo2Riv = value
			End If
		End Set
	End property 

	Protected _Prezzo3 as decimal  = 0 
	Public Overridable Property Prezzo3() as decimal  Implements _IIndiceRicerca.Prezzo3
		Get
			Return _Prezzo3
		End Get
		Set (byval value as decimal)
			If _Prezzo3 <> value Then
				IsChanged = True
				WhatIsChanged.Prezzo3 = True
				_Prezzo3 = value
			End If
		End Set
	End property 

	Protected _Prezzo3Riv as decimal  = 0 
	Public Overridable Property Prezzo3Riv() as decimal  Implements _IIndiceRicerca.Prezzo3Riv
		Get
			Return _Prezzo3Riv
		End Get
		Set (byval value as decimal)
			If _Prezzo3Riv <> value Then
				IsChanged = True
				WhatIsChanged.Prezzo3Riv = True
				_Prezzo3Riv = value
			End If
		End Set
	End property 

	Protected _ProdottoFinito as integer  = 0 
	Public Overridable Property ProdottoFinito() as integer  Implements _IIndiceRicerca.ProdottoFinito
		Get
			Return _ProdottoFinito
		End Get
		Set (byval value as integer)
			If _ProdottoFinito <> value Then
				IsChanged = True
				WhatIsChanged.ProdottoFinito = True
				_ProdottoFinito = value
			End If
		End Set
	End property 

	Protected _Qta1 as integer  = 0 
	Public Overridable Property Qta1() as integer  Implements _IIndiceRicerca.Qta1
		Get
			Return _Qta1
		End Get
		Set (byval value as integer)
			If _Qta1 <> value Then
				IsChanged = True
				WhatIsChanged.Qta1 = True
				_Qta1 = value
			End If
		End Set
	End property 

	Protected _Qta2 as integer  = 0 
	Public Overridable Property Qta2() as integer  Implements _IIndiceRicerca.Qta2
		Get
			Return _Qta2
		End Get
		Set (byval value as integer)
			If _Qta2 <> value Then
				IsChanged = True
				WhatIsChanged.Qta2 = True
				_Qta2 = value
			End If
		End Set
	End property 

	Protected _Qta3 as integer  = 0 
	Public Overridable Property Qta3() as integer  Implements _IIndiceRicerca.Qta3
		Get
			Return _Qta3
		End Get
		Set (byval value as integer)
			If _Qta3 <> value Then
				IsChanged = True
				WhatIsChanged.Qta3 = True
				_Qta3 = value
			End If
		End Set
	End property 

	Protected _TotOrdini as integer  = 0 
	Public Overridable Property TotOrdini() as integer  Implements _IIndiceRicerca.TotOrdini
		Get
			Return _TotOrdini
		End Get
		Set (byval value as integer)
			If _TotOrdini <> value Then
				IsChanged = True
				WhatIsChanged.TotOrdini = True
				_TotOrdini = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an IndiceRicerca from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As IndiceRicerca = Manager.Read(Id)
				_IdIndiceRicerca = int.IdIndiceRicerca
				_IdListinoBase = int.IdListinoBase
				_IdPrev = int.IdPrev
				_InEvidenza = int.InEvidenza
				_NomeListino = int.NomeListino
				_PercCoupon = int.PercCoupon
				_Prezzo1 = int.Prezzo1
				_Prezzo1Riv = int.Prezzo1Riv
				_Prezzo2 = int.Prezzo2
				_Prezzo2Riv = int.Prezzo2Riv
				_Prezzo3 = int.Prezzo3
				_Prezzo3Riv = int.Prezzo3Riv
				_ProdottoFinito = int.ProdottoFinito
				_Qta1 = int.Qta1
				_Qta2 = int.Qta2
				_Qta3 = int.Qta3
				_TotOrdini = int.TotOrdini
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an IndiceRicerca on DB.
	''' </summary>
	''' <returns>
	'''Return Id insert in DB if all ok, 0 if error
	''' </returns>
	Public Overridable Function Save() As Integer
		'Return the id Inserted
		Dim Ris As Integer = 0
		Try
			Using Manager
				Ris = Manager.Save(Me)
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ris
	End Function

	Protected Function InternalIsValid() As Boolean
		Dim Ris As Boolean = True
		if _NomeListino.Length > 255 then Ris = False

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Indiciricerca
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IIndiceRicerca

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdIndiceRicerca() as integer
	Property IdListinoBase() as integer
	Property IdPrev() as integer
	Property InEvidenza() as integer
	Property NomeListino() as string
	Property PercCoupon() as integer
	Property Prezzo1() as decimal
	Property Prezzo1Riv() as decimal
	Property Prezzo2() as decimal
	Property Prezzo2Riv() as decimal
	Property Prezzo3() as decimal
	Property Prezzo3Riv() as decimal
	Property ProdottoFinito() as integer
	Property Qta1() as integer
	Property Qta2() as integer
	Property Qta3() as integer
	Property TotOrdini() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class IndiceRicerca
		Public Shared ReadOnly Property IdIndiceRicerca As New LUNA.LunaFieldName("IdIndiceRicerca")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdPrev As New LUNA.LunaFieldName("IdPrev")
		Public Shared ReadOnly Property InEvidenza As New LUNA.LunaFieldName("InEvidenza")
		Public Shared ReadOnly Property NomeListino As New LUNA.LunaFieldName("NomeListino")
		Public Shared ReadOnly Property PercCoupon As New LUNA.LunaFieldName("PercCoupon")
		Public Shared ReadOnly Property Prezzo1 As New LUNA.LunaFieldName("Prezzo1")
		Public Shared ReadOnly Property Prezzo1Riv As New LUNA.LunaFieldName("Prezzo1Riv")
		Public Shared ReadOnly Property Prezzo2 As New LUNA.LunaFieldName("Prezzo2")
		Public Shared ReadOnly Property Prezzo2Riv As New LUNA.LunaFieldName("Prezzo2Riv")
		Public Shared ReadOnly Property Prezzo3 As New LUNA.LunaFieldName("Prezzo3")
		Public Shared ReadOnly Property Prezzo3Riv As New LUNA.LunaFieldName("Prezzo3Riv")
		Public Shared ReadOnly Property ProdottoFinito As New LUNA.LunaFieldName("ProdottoFinito")
		Public Shared ReadOnly Property Qta1 As New LUNA.LunaFieldName("Qta1")
		Public Shared ReadOnly Property Qta2 As New LUNA.LunaFieldName("Qta2")
		Public Shared ReadOnly Property Qta3 As New LUNA.LunaFieldName("Qta3")
		Public Shared ReadOnly Property TotOrdini As New LUNA.LunaFieldName("TotOrdini")
	End Class

End Class