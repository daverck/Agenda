Public Class ChiffreEventArgs
    Inherits System.EventArgs
    Private m_Realize, m_Total As Long

    Public Sub New(ByVal ValRealise As Long, ByVal ValTotal As Long)
        Me.m_Realize = ValRealise
        Me.m_Total = ValTotal
    End Sub

    Public ReadOnly Property Total() As Long
        Get
            Return Me.m_Total
        End Get
    End Property

    Public ReadOnly Property Realise() As Long
        Get
            Return Me.m_Realize
        End Get
    End Property

End Class
