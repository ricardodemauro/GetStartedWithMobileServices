﻿using System;
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
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GetStartedWithMobileServices
{
    /// <summary>
    /// Represents a todo item.
    /// </summary>
    public class TodoItem
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }

    public class UndoneCountResult
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public sealed partial class MainPage : Page
    {
        // TODO: Comment out the following line that defined the in-memory collection. 
        //private ObservableCollection<TodoItem> items = new ObservableCollection<TodoItem>();

        //// TODO: Uncomment the following lines that defines the Mobile Servies table.
        //// TODO: Replace yourClient with the MobileServiceClient instance added to 
        //// the App.xaml.cs file when connecting to your service.
        private MobileServiceCollection<TodoItem, TodoItem> items;
        private IMobileServiceTable<TodoItem> todoTable =
            App.myawesomemobileserviceRDMOClient.GetTable<TodoItem>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        void ButtonCompleteAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void ButtonUndoneCount_Click(object sender, RoutedEventArgs e)
        {
            string message;
            try
            {
                // Asynchronously call the custom API using the POST method. 
                var result = await App.myawesomemobileserviceRDMOClient
                    .InvokeApiAsync<UndoneCountResult>("UndoneCount",
                    System.Net.Http.HttpMethod.Get, null);
                message = result.Count + " item(s) undone.";
                RefreshTodoItems();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                message = ex.Message;
            }

            var dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();
        }

        private async void InsertTodoItem(TodoItem todoItem)
        {
            // TODO: Delete or comment the following statement; Mobile Services auto-generates the ID. 
            //       You can also leave this line if you want to generate your own unique id values.

            //// This code inserts a new TodoItem into the database. When the operation completes 
            //// and Mobile Services has assigned an Id, the item is added to the CollectionView 
            //// TODO: Mark this method as "async" and uncomment the following statement. 
            await todoTable.InsertAsync(todoItem);

            items.Add(todoItem);
        }

        private async void RefreshTodoItems()
        {
            //// TODO #1: Mark this method as "async" and uncomment the following statment 
            //// that defines a simple query for all items.  
            //items = await todoTable.ToCollectionAsync(); 

            //// TODO #2: More advanced query that filters out completed items.  
            items = await todoTable
               .Where(todoItem => todoItem.Complete == false)
               .ToCollectionAsync();

            ListItems.ItemsSource = items;
        }

        private async void UpdateCheckedTodoItem(TodoItem item)
        {
            //// This code takes a freshly completed TodoItem and updates the database. When the MobileService  
            //// responds, the item is removed from the list. 
            //// TODO: Mark this method as "async" and uncomment the following statement 
            await todoTable.UpdateAsync(item);
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTodoItems();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var todoItem = new TodoItem { Text = TextInput.Text };
            InsertTodoItem(todoItem);
        }

        private void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            TodoItem item = cb.DataContext as TodoItem;
            UpdateCheckedTodoItem(item);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshTodoItems();
        }
    }

}
