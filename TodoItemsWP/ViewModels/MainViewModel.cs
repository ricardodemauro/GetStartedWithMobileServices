using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using GetStartedWithMobileServices.TodoItemsWP.Resources;
using GetStartedWithMobileServices.Model;

namespace GetStartedWithMobileServices.TodoItemsWP.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<TodoItem>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<TodoItem> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new TodoItem() { Number = 0, Title = "runtime one", Description = "Maecenas praesent accumsan bibendum" });
            this.Items.Add(new TodoItem() { Number = 1, Title = "runtime two", Description = "Dictumst eleifend facilisi faucibus" });
            this.Items.Add(new TodoItem() { Number = 2, Title = "runtime three", Description = "Habitant inceptos interdum lobortis" });
            this.Items.Add(new TodoItem() { Number = 3, Title = "runtime four", Description = "Nascetur pharetra placerat pulvinar" });
            this.Items.Add(new TodoItem() { Number = 4, Title = "runtime five", Description = "Maecenas praesent accumsan bibendum" });
            this.Items.Add(new TodoItem() { Number = 5, Title = "runtime six", Description = "Dictumst eleifend facilisi faucibus" });
            this.Items.Add(new TodoItem() { Number = 6, Title = "runtime seven", Description = "Habitant inceptos interdum lobortis" });
            this.Items.Add(new TodoItem() { Number = 7, Title = "runtime eight", Description = "Nascetur pharetra placerat pulvinar" });
            this.Items.Add(new TodoItem() { Number = 8, Title = "runtime nine", Description = "Maecenas praesent accumsan bibendum" });
            this.Items.Add(new TodoItem() { Number = 9, Title = "runtime ten", Description = "Dictumst eleifend facilisi faucibus" });
            this.Items.Add(new TodoItem() { Number = 10, Title = "runtime eleven", Description = "Habitant inceptos interdum lobortis" });
            this.Items.Add(new TodoItem() { Number = 11, Title = "runtime twelve", Description = "Nascetur pharetra placerat pulvinar" });
            this.Items.Add(new TodoItem() { Number = 12, Title = "runtime thirteen", Description = "Maecenas praesent accumsan bibendum" });
            this.Items.Add(new TodoItem() { Number = 13, Title = "runtime fourteen", Description = "Dictumst eleifend facilisi faucibus" });
            this.Items.Add(new TodoItem() { Number = 14, Title = "runtime fifteen", Description = "Habitant inceptos interdum lobortis" });
            this.Items.Add(new TodoItem() { Number = 15, Title = "runtime sixteen", Description = "Nascetur pharetra placerat pulvinar" });

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}