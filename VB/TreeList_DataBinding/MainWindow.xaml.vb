Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace TreeList_DataBinding

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub
    End Class

    Public Enum SummaryItemType
        Max
        Count
        Average
    End Enum

    Public Class ViewModel
        Inherits ViewModelBase

        Public Sub New()
            SourceList = GetStaff()
            SummaryList = New ObservableCollection(Of SummaryTask) From {New SummaryTask(NameOf(Employee.Statistics), SummaryItemType.Max), New SummaryTask(NameOf(Employee.Statistics), SummaryItemType.Average), New SummaryTask(NameOf(Employee.Department), SummaryItemType.Count)}
        End Sub

        Public Property SourceList As ObservableCollection(Of Employee)

        Public ReadOnly Property SummaryList As ObservableCollection(Of SummaryTask)
    End Class

    Public Class SummaryTask
        Inherits BindableBase

        Public Sub New(ByVal fieldName As String, ByVal type As SummaryItemType)
            Me.FieldName = fieldName
            Me.Type = type
        End Sub

        Public Property FieldName As String

        Public Property Type As SummaryItemType
    End Class
End Namespace
