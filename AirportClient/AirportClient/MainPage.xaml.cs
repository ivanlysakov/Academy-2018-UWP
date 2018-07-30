using AirportClient.Views;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AirportClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // по умолчанию открываем страницу home.xaml
            myFrame.Navigate(typeof(HomePage));
            TitleTextBlock.Text = "Airport";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (airplanes.IsSelected)
            {
                myFrame.Navigate(typeof(AirplanesView));
                TitleTextBlock.Text = "Airplanes";
            }
            else if (types.IsSelected)
            {
                myFrame.Navigate(typeof(AirplaneTypesView));
                TitleTextBlock.Text = "Types";
            }
            else if (pilots.IsSelected)
            {
                myFrame.Navigate(typeof(PilotsView));
                TitleTextBlock.Text = "Pilots";
            }
            else if (hostesses.IsSelected)
            {
                myFrame.Navigate(typeof(AirhostessesView));
                TitleTextBlock.Text = "Hostesses";
            }
            else if (crews.IsSelected)
            {
                myFrame.Navigate(typeof(AircrewsView));
                TitleTextBlock.Text = "Aircrews";
            }
            else if (departures.IsSelected)
            {
                myFrame.Navigate(typeof(DeparturesView));
                TitleTextBlock.Text = "Departures";
            }
            else if (flights.IsSelected)
            {
                myFrame.Navigate(typeof(FlightsView));
                TitleTextBlock.Text = "Flights";
            }
            else if (tickets.IsSelected)
            {
                myFrame.Navigate(typeof(TicketsView));
                TitleTextBlock.Text = "Tickets";
            }
            else if (home.IsSelected)
            {
                myFrame.Navigate(typeof(HomePage));
                TitleTextBlock.Text = "Home";
            }

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}
