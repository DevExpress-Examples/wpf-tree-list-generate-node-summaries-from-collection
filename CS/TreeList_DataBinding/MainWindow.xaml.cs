using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;

namespace TreeList_DataBinding {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }

    public enum SummaryItemType { Max, Count, Average }

    public class ViewModel : ViewModelBase {
        public ViewModel() {
            SourceList = Staff.GetStaff();
            SummaryList = new ObservableCollection<SummaryTask> {
                new SummaryTask(nameof(Employee.Statistics), SummaryItemType.Max),
                new SummaryTask(nameof(Employee.Statistics), SummaryItemType.Average),
                new SummaryTask(nameof(Employee.Department), SummaryItemType.Count)
            };
        }
        public ObservableCollection<Employee> SourceList { get; set; }
        public ObservableCollection<SummaryTask> SummaryList { get; }
    }

    public class SummaryTask : BindableBase {
        public SummaryTask(string fieldName, SummaryItemType type) {
            FieldName = fieldName;
            Type = type;
        }

        public string FieldName { get; set; }
        public SummaryItemType Type { get; set; }
    }
}
