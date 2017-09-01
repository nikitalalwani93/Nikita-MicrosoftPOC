using System;
using System.Collections.Generic;
using UIKit;
using Foundation;
using System.Collections.ObjectModel;

namespace ToDoListFinalPOC
{
    public partial class MasterViewController : UITableViewController
    {
        ObservableCollection<ToDoItem> todoItems;


        protected MasterViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "To-Do";
            NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;

            todoItems = new ObservableCollection<ToDoItem>
            {
            };

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (todoItems != null)
            {
                TableView.Source = new TableViewDataSource(this.TableView,todoItems,this);
            }
        }

        partial void UIBarButtonItem292_Activated(UIBarButtonItem sender)
        {
            AddTask();
        }

         public void AddTask()
        {
            // Do Something
            UITextField field = null;

            var AlertController = UIAlertController.Create("Add your to-do item", "", UIAlertControllerStyle.Alert);
            AlertController.AddTextField((textField) => {
                field = textField;
                field.Text = textField.Text;
                field.KeyboardType = UIKeyboardType.Default;
                field.ReturnKeyType = UIReturnKeyType.Done;
            });

            //Add Action
            var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => Console.WriteLine("Cancel"));
            //OK Action
            var okayAction = UIAlertAction.Create("OK", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {
                var newItem = new ToDoItem();
                newItem.task = field.Text;
                todoItems.Add(newItem);
                TableView.ReloadData();
            });
            AlertController.AddAction(cancelAction);
            AlertController.AddAction(okayAction);

            // Present Alert
            PresentViewController(AlertController, true, null);
        }

        public void EditTask(int rowItem) {
            UITextField field = null;

            var AlertController = UIAlertController.Create("Add your to-do item", "", UIAlertControllerStyle.Alert);
            AlertController.AddTextField((textField) => {
                field = textField;
               
                field.Text = todoItems[rowItem].task;
                field.KeyboardType = UIKeyboardType.Default;
                field.ReturnKeyType = UIReturnKeyType.Done;
            });

            //Add Action
            var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => Console.WriteLine("Cancel"));
            //OK Action
            var okayAction = UIAlertAction.Create("OK", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {
                todoItems[rowItem].task = field.Text;
                TableView.ReloadData();
            });
            AlertController.AddAction(cancelAction);
            AlertController.AddAction(okayAction);

            // Present Alert
            PresentViewController(AlertController, true, null);
        }

        public void DeleteTask(int rowItem) 
        {
            todoItems.RemoveAt(rowItem);
            TableView.ReloadData();
        }
    }
}
