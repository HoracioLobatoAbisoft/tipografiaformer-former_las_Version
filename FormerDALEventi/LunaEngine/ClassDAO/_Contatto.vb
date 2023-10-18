#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.9.11 
'Author: Diego Lunadei
'Date: 26/09/2017 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Contatti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _Contatto
	Inherits LUNA.LunaBaseClassEntity
    Implements _IContatto
'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IContatto.FillFromDataRecord
     IdContatto = myRecord("IdContatto")
    		if not myRecord("RagSoc") is DBNull.Value then RagSoc = myRecord("RagSoc")
    		if not myRecord("Nominativo") is DBNull.Value then Nominativo = myRecord("Nominativo")
    		if not myRecord("Email") is DBNull.Value then Email = myRecord("Email")
    		if not myRecord("Cellulare") is DBNull.Value then Cellulare = myRecord("Cellulare")
    		if not myRecord("DataIns") is DBNull.Value then DataIns = myRecord("DataIns")
    		if not myRecord("Tag") is DBNull.Value then Tag = myRecord("Tag")
       
	 ResetIsChanged()
End Sub

Private Property Manager As LUNA.ILunaBaseClassDAO(Of Contatto)
    Get
        If _Mgr Is Nothing Then
            Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
            If _MgrType Is Nothing Then _MgrType = GetType(ContattiDAO)
            _Mgr = Activator.CreateInstance(_MgrType)
        End If
        Return _Mgr
    End Get
    Set(value As LUNA.ILunaBaseClassDAO(Of Contatto))
        _Mgr = value
    End Set
End Property

#Region "Database Field Map"

Public Class WhatIsChanged

	Public Shared Property IdContatto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
	Public Shared Property RagSoc As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
	Public Shared Property Nominativo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
	Public Shared Property Email As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
	Public Shared Property Cellulare As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
	Public Shared Property DataIns As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
	Public Shared Property Tag As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

End Class

Public Sub ResetIsChanged()

	IsChanged = False
	WhatIsChanged.IdContatto = LUNA.LunaContext.WriteAllFieldEveryTime 
	WhatIsChanged.RagSoc = LUNA.LunaContext.WriteAllFieldEveryTime 
	WhatIsChanged.Nominativo = LUNA.LunaContext.WriteAllFieldEveryTime 
	WhatIsChanged.Email = LUNA.LunaContext.WriteAllFieldEveryTime 
	WhatIsChanged.Cellulare = LUNA.LunaContext.WriteAllFieldEveryTime 
	WhatIsChanged.DataIns = LUNA.LunaContext.WriteAllFieldEveryTime 
	WhatIsChanged.Tag = LUNA.LunaContext.WriteAllFieldEveryTime 

End Sub

Protected _IdContatto as integer  = 0 
Public Overridable Property IdContatto() as integer  Implements _IContatto.IdContatto
    Get
	    Return _IdContatto
    End Get
    Set (byval value as integer)
	    If _IdContatto <> value Then
	        IsChanged = True
			WhatIsChanged.IdContatto = True
	        _IdContatto = value
	    End If
    End Set
End property 

Protected _RagSoc as string  = "" 
Public Overridable Property RagSoc() as string  Implements _IContatto.RagSoc
    Get
	    Return _RagSoc
    End Get
    Set (byval value as string)
	    If _RagSoc <> value Then
	        IsChanged = True
			WhatIsChanged.RagSoc = True
	        _RagSoc = value
	    End If
    End Set
End property 

Protected _Nominativo as string  = "" 
Public Overridable Property Nominativo() as string  Implements _IContatto.Nominativo
    Get
	    Return _Nominativo
    End Get
    Set (byval value as string)
	    If _Nominativo <> value Then
	        IsChanged = True
			WhatIsChanged.Nominativo = True
	        _Nominativo = value
	    End If
    End Set
End property 

Protected _Email as string  = "" 
Public Overridable Property Email() as string  Implements _IContatto.Email
    Get
	    Return _Email
    End Get
    Set (byval value as string)
	    If _Email <> value Then
	        IsChanged = True
			WhatIsChanged.Email = True
	        _Email = value
	    End If
    End Set
End property 

Protected _Cellulare as string  = "" 
Public Overridable Property Cellulare() as string  Implements _IContatto.Cellulare
    Get
	    Return _Cellulare
    End Get
    Set (byval value as string)
	    If _Cellulare <> value Then
	        IsChanged = True
			WhatIsChanged.Cellulare = True
	        _Cellulare = value
	    End If
    End Set
End property 

Protected _DataIns as string  = "" 
Public Overridable Property DataIns() as string  Implements _IContatto.DataIns
    Get
	    Return _DataIns
    End Get
    Set (byval value as string)
	    If _DataIns <> value Then
	        IsChanged = True
			WhatIsChanged.DataIns = True
	        _DataIns = value
	    End If
    End Set
End property 

Protected _Tag as string  = "" 
Public Overridable Property Tag() as string  Implements _IContatto.Tag
    Get
	    Return _Tag
    End Get
    Set (byval value as string)
	    If _Tag <> value Then
	        IsChanged = True
			WhatIsChanged.Tag = True
	        _Tag = value
	    End If
    End Set
End property 


#End Region

#Region "Method"
''' <summary>
'''This method read an Contatto from DB.
''' </summary>
''' <returns>
'''Return 0 if all ok, 1 if error
''' </returns>
Public Overridable Function Read(Id As Integer) As Integer
    'Return 0 if all ok
    Dim Ris As Integer = 0
    Try
	    Using Manager
	        Dim int As Contatto = Manager.Read(Id)
                    _IdContatto = int.IdContatto
                    _RagSoc = int.RagSoc
                    _Nominativo = int.Nominativo
                    _Email = int.Email
                    _Cellulare = int.Cellulare
                    _DataIns = int.DataIns
                    _Tag = int.Tag
        	    End Using
        Manager = nothing
    Catch ex As Exception
	    ManageError(ex)
	    Ris = 1
    End Try
    Return Ris
End Function

''' <summary>
'''This method save an Contatto on DB.
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
	  if _RagSoc.Length > 255 then Ris = False
  if _Nominativo.Length > 255 then Ris = False
  if _Email.Length > 255 then Ris = False
  if _Cellulare.Length > 255 then Ris = False
  if _DataIns.Length > 255 then Ris = False
  if _Tag.Length > 255 then Ris = False

	Return Ris
End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table Contatti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IContatto

Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

    
    Property IdContatto() as integer

    
    Property RagSoc() as string

    
    Property Nominativo() as string

    
    Property Email() as string

    
    Property Cellulare() as string

    
    Property DataIns() as string

    
    Property Tag() as string

    
#End Region

End Interface