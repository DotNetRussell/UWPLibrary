using BasecodeLibrary.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SandboxUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private FilterableContentListItem _SelectedItemDC;


        public FilterableContentListItem SelectedItemDC
        {
            get { return _SelectedItemDC; }
            set { _SelectedItemDC = value; OnPropertyChanged("SelectedItemDC"); }
        }

        public ObservableCollection<FilterableContentListItem> items { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            items = new ObservableCollection<FilterableContentListItem>();
            this.DataContext = this;

            for (int x = 0; x < 50; x++)
            {
                BuildFilterableItems("Item "+x, String.Empty, String.Empty, new object(), new Uri(@"http://sadmoment.com/wp-content/uploads/2013/10/Cat-Breading-Is-Out-Cat-Pizza-Heads-Are-In_408x408.jpg"), new Point(100, 100));
            }            
        }

        private void BuildFilterableItems(string t, string sd, string d, object dobj, Uri i, Point id) 
        {
            FilterableContentListItem item = new FilterableContentListItem()
            {
                ContentTitle = t,
                ContentShortDescription = sd,
                Details = d,
                DataObject = dobj,
                ImageURI = i,
                ImageDimensions = id
            };
            items.Add(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            popup.ShowPopup();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            feedback.ShowPopup();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            rate.ShowPopup();
        }
    }
}
