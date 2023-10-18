#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 04/06/2018 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Promo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _PromoW
	Inherits LUNA.LunaBaseClassEntity
	Implements _IPromoW
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IPromoW.FillFromDataRecord
		IdPromo = myRecord("IdPromo")
		if not myRecord("Automatico") is DBNull.Value then Automatico = myRecord("Automatico")
		DataFineValidita = myRecord("DataFineValidita")
		IdListinoBase = myRecord("IdListinoBase")
		IdPromoInt = myRecord("IdPromoInt")
		Percentuale = myRecord("Percentuale")
		QtaSpecifica = myRecord("QtaSpecifica")
		Stato = myRecord("Stato")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of PromoW)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(PromoWDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of PromoW))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdPromo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Automatico As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property DataFineValidita As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdListinoBase As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdPromoInt As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Percentuale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property QtaSpecifica As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Stato As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdPromo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Automatico = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.DataFineValidita = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdListinoBase = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdPromoInt = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Percentuale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.QtaSpecifica = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Stato = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdPromo as integer  = 0 
	Public Overridable Property IdPromo() as integer  Implements _IPromoW.IdPromo
		Get
			Return _IdPromo
		End Get
		Set (byval value as integer)
			If _IdPromo <> value Then
				IsChanged = True
				WhatIsChanged.IdPromo = True
				_IdPromo = value
			End If
		End Set
	End property 

	Protected _Automatico as integer  = 0 
	Public Overridable Property Automatico() as integer  Implements _IPromoW.Automatico
		Get
			Return _Automatico
		End Get
		Set (byval value as integer)
			If _Automatico <> value Then
				IsChanged = True
				WhatIsChanged.Automatico = True
				_Automatico = value
			End If
		End Set
	End property 

	Protected _DataFineValidita as DateTime  = Nothing 
	Public Overridable Property DataFineValidita() as DateTime  Implements _IPromoW.DataFineValidita
		Get
			Return _DataFineValidita
		End Get
		Set (byval value as DateTime)
			If _DataFineValidita <> value Then
				IsChanged = True
				WhatIsChanged.DataFineValidita = True
				_DataFineValidita = value
			End If
		End Set
	End property 

	Protected _IdListinoBase as integer  = 0 
	Public Overridable Property IdListinoBase() as integer  Implements _IPromoW.IdListinoBase
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

	Protected _IdPromoInt as integer  = 0 
	Public Overridable Property IdPromoInt() as integer  Implements _IPromoW.IdPromoInt
		Get
			Return _IdPromoInt
		End Get
		Set (byval value as integer)
			If _IdPromoInt <> value Then
				IsChanged = True
				WhatIsChanged.IdPromoInt = True
				_IdPromoInt = value
			End If
		End Set
	End property 

	Protected _Percentuale as integer  = 0 
	Public Overridable Property Percentuale() as integer  Implements _IPromoW.Percentuale
		Get
			Return _Percentuale
		End Get
		Set (byval value as integer)
			If _Percentuale <> value Then
				IsChanged = True
				WhatIsChanged.Percentuale = True
				_Percentuale = value
			End If
		End Set
	End property 

	Protected _QtaSpecifica as integer  = 0 
	Public Overridable Property QtaSpecifica() as integer  Implements _IPromoW.QtaSpecifica
		Get
			Return _QtaSpecifica
		End Get
		Set (byval value as integer)
			If _QtaSpecifica <> value Then
				IsChanged = True
				WhatIsChanged.QtaSpecifica = True
				_QtaSpecifica = value
			End If
		End Set
	End property 

	Protected _Stato as integer  = 0 
	Public Overridable Property Stato() as integer  Implements _IPromoW.Stato
		Get
			Return _Stato
		End Get
		Set (byval value as integer)
			If _Stato <> value Then
				IsChanged = True
				WhatIsChanged.Stato = True
				_Stato = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an PromoW from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As PromoW = Manager.Read(Id)
				_IdPromo = int.IdPromo
				_Automatico = int.Automatico
				_DataFineValidita = int.DataFineValidita
				_IdListinoBase = int.IdListinoBase
				_IdPromoInt = int.IdPromoInt
				_Percentuale = int.Percentuale
				_QtaSpecifica = int.QtaSpecifica
				_Stato = int.Stato
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an PromoW on DB.
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

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Promo
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IPromoW

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdPromo() as integer
	Property Automatico() as integer
	Property DataFineValidita() as DateTime
	Property IdListinoBase() as integer
	Property IdPromoInt() as integer
	Property Percentuale() as integer
	Property QtaSpecifica() as integer
	Property Stato() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class PromoW
		Public Shared ReadOnly Property IdPromo As New LUNA.LunaFieldName("IdPromo")
		Public Shared ReadOnly Property Automatico As New LUNA.LunaFieldName("Automatico")
		Public Shared ReadOnly Property DataFineValidita As New LUNA.LunaFieldName("DataFineValidita")
		Public Shared ReadOnly Property IdListinoBase As New LUNA.LunaFieldName("IdListinoBase")
		Public Shared ReadOnly Property IdPromoInt As New LUNA.LunaFieldName("IdPromoInt")
		Public Shared ReadOnly Property Percentuale As New LUNA.LunaFieldName("Percentuale")
		Public Shared ReadOnly Property QtaSpecifica As New LUNA.LunaFieldName("QtaSpecifica")
		Public Shared ReadOnly Property Stato As New LUNA.LunaFieldName("Stato")
	End Class

End Class