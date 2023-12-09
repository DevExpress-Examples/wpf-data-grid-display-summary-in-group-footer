Imports DevExpress.Xpf.Data
Imports DevExpress.Xpf.Grid
Imports System.Windows
Imports System.Windows.Controls

Namespace GroupFootersWPF

    Public Class GroupFooter
        Inherits Control

        Public Shared ReadOnly GroupRowDataProperty As DependencyProperty = DependencyProperty.Register("GroupRowData", GetType(MyGroupRowData), GetType(GroupFooter), New PropertyMetadata(CType(Nothing, PropertyChangedCallback)))

        Public Shared ReadOnly RowHandleProperty As DependencyProperty = DependencyProperty.Register("RowHandle", GetType(RowHandle), GetType(GroupFooter), New PropertyMetadata(New RowHandle(DataControlBase.InvalidRowHandle), Sub(d, e) CType(d, GroupFooter).RefreshContent()))

        Public Sub New()
            DefaultStyleKey = GetType(GroupFooter)
        End Sub

        Public Property GroupRowData As MyGroupRowData
            Get
                Return CType(GetValue(GroupRowDataProperty), MyGroupRowData)
            End Get

            Set(ByVal value As MyGroupRowData)
                SetValue(GroupRowDataProperty, value)
            End Set
        End Property

        Public Property RowHandle As RowHandle
            Get
                Return CType(GetValue(RowHandleProperty), RowHandle)
            End Get

            Set(ByVal value As RowHandle)
                SetValue(RowHandleProperty, value)
            End Set
        End Property

        Public ReadOnly Property View As MyTableView
            Get
                Return If(DataContext Is Nothing, Nothing, CType(CType(DataContext, RowData).View, MyTableView))
            End Get
        End Property

        Public Overrides Sub OnApplyTemplate()
            MyBase.OnApplyTemplate()
            RefreshContent()
        End Sub

        Public Function IsLastRowInGroup(ByVal groupRowHandle As Integer) As Boolean
            Dim gridControl As GridControl = TryCast(View.DataControl, GridControl)
            If Not gridControl.IsValidRowHandle(groupRowHandle) Then Return False
            Dim childrenCount As Integer = gridControl.GetChildRowCount(groupRowHandle)
            Dim lastRowHandle As Integer = gridControl.GetChildRowHandle(groupRowHandle, childrenCount - 1)
            Return gridControl.GetRowVisibleIndexByHandle(lastRowHandle) <= gridControl.GetRowVisibleIndexByHandle(RowHandle.Value)
        End Function

        Public Sub RefreshContent()
            If View Is Nothing Then Return
            Dim groupRowHandle As RowHandle = GetParentRowHandle()
            View.AddToCacheGroupFooter(Me)
            UpdateVisibility(groupRowHandle)
            If Visibility = Visibility.Collapsed Then Return
            UpdateGroupFooterSummaryContent(groupRowHandle)
            UpdateOffset()
        End Sub

        Private Sub UpdateOffset()
            Dim offset As Double = View.LeftGroupAreaIndent * CType(View.DataControl, GridControl).GroupCount
            Margin = New Thickness(-offset, 0, 0, 0)
        End Sub

        Private Sub UpdateGroupFooterSummaryContent(ByVal groupRowHandle As RowHandle)
            If GroupRowData Is Nothing Then
                GroupRowData = View.CreateGroupRowData(groupRowHandle)
            Else
                View.UpdateGroupRowData(GroupRowData, groupRowHandle)
            End If
        End Sub

        Private Function GetParentRowHandle() As RowHandle
            Return New RowHandle(CType(View.DataControl, GridControl).GetParentRowHandle(RowHandle.Value))
        End Function

        Private Sub UpdateVisibility(ByVal groupRowHandle As RowHandle)
            Visibility = If(IsLastRowInGroup(groupRowHandle.Value), Visibility.Visible, Visibility.Collapsed)
        End Sub
    End Class
End Namespace
