using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GetStartedWithMobileServices.TodoItemsWP.Resources;
using GetStartedWithMobileServices.TodoItemsWP.ViewModels;
using GetStartedWithMobileServices.Model;
using System.Threading;

namespace TodoItemsWP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();

            // Set the data context of the LongListSelector control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as TodoItem).Number, UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            appBarButton.Click += appBarButton_Click;
            ApplicationBar.Buttons.Add(appBarButton);
        }

        private void appBarButton_Click(object sender, EventArgs e)
        {
            int lastNumber = 0;
            foreach (var todoItem in App.ViewModel.Items)
            {
                if (lastNumber < todoItem.Number)
                {
                    lastNumber = todoItem.Number;
                }
            }
            var newTodoItem = NewItemControl.GetTodoItem();
            newTodoItem.Number = lastNumber + 1;
            App.ViewModel.Items.Add(newTodoItem);
            NewItemControl.ClearFields();

            MainPivot.SelectedIndex = 0;
            MainLongListSelector.ScrollTo(newTodoItem);
        }

        private void MainPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pivot p = sender as Pivot;
            ApplicationBar.Mode = p.SelectedIndex == 1 ? ApplicationBarMode.Default : ApplicationBarMode.Minimized;
        }
    }
}