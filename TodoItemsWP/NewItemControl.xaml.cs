using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GetStartedWithMobileServices.Model;

namespace GetStartedWithMobileServices.TodoItemsWP
{
    public partial class NewItemControl : UserControl
    {
        public NewItemControl()
        {
            InitializeComponent();
        }

        public TodoItem GetTodoItem()
        {
            TodoItem td = new TodoItem();
            td.Title = this.textboxTitle.Text;
            td.Description = this.textboxDescription.Text;
            return td;
        }

        public void ClearFields()
        {
            this.textboxTitle.Text = string.Empty;
            this.textboxDescription.Text = string.Empty;
        }
    }
}
