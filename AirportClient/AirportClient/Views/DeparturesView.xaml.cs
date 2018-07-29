using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AirportClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public  partial class DeparturesView : Page
    {
        public DeparturesView()
        {
            this.InitializeComponent();
        }
        protected void SelectItem(object sender, RoutedEventArgs e)
        {
            var grid = (Grid)this.FindName("detailGrid");
            if (grid.Visibility == Visibility.Collapsed)
                grid.Visibility = Visibility.Visible;
            else { }
        }

        protected void NewForm(object sender, RoutedEventArgs e)
        {
            var grid = (Grid)this.FindName("detailGrid");
            if (grid.Visibility == Visibility.Collapsed)
                grid.Visibility = Visibility.Visible;
            else { }
        }
    }
}
