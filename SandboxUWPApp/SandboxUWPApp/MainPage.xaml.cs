using BasecodeLibrary.Utilities;
using Windows.UI.Xaml.Controls;

namespace SandboxUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new TestViewModel();
        }
    }

    public class TestViewModel : ViewModelBase
    {
        private string fieldOne;

        public string FieldOne
        {
            get { return fieldOne; }
            set { fieldOne = value; OnPropertyChanged("FieldOne"); }
        }

        private bool fieldTwo;

        public bool FieldTwo
        {
            get { return fieldTwo; }
            set { fieldTwo = value; OnPropertyChanged("FieldTwo"); }
        }

        private double fieldThree;

        public double FieldThree
        {
            get { return fieldThree; }
            set { fieldThree = value; OnPropertyChanged("FieldThree"); }
        }


    }
}
