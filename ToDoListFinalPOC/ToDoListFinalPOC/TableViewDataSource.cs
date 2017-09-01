                            using System;
                            using UIKit;
                            using Foundation;
                            using System.Collections.Generic;
                            using System.Collections.ObjectModel;

                            namespace ToDoListFinalPOC
                            {
                                public class TableViewDataSource : UITableViewSource
                                {
                                    ObservableCollection<ToDoItem> todoItems;
                                    string cellIdentifier = "taskcell";
                                    public MasterViewController controller;


                                    public TableViewDataSource(UITableView tableView,ObservableCollection<ToDoItem> taskItem,MasterViewController ctrl)
                                    {
                                        todoItems = taskItem;
                                        controller = ctrl;
                                    }

                                    public override nint RowsInSection(UITableView tableview, nint section)
                                    {
                                        return todoItems.Count;
                                    }

                                    public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
                                    {
                                        UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
                                        cell.TextLabel.Text = todoItems[indexPath.Row].task;
                                        cell.TextLabel.Font = UIFont.FromName("Helvetica", 20f);
                                        return cell;
                                    }

                                    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
                                    {
                                        var cell = tableView.CellAt(indexPath);

                                      if (cell.Accessory == UITableViewCellAccessory.None)
                                        {
                                         cell.Accessory = UITableViewCellAccessory.Checkmark;
                                        } else {
                                         cell.Accessory = UITableViewCellAccessory.None;
                                      }

                                    }

                                    public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
                                    {
                                        return true; 
                                    }

                                    public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
                                    {
                                        UITableViewRowAction deleteButton = UITableViewRowAction.Create(
                                           UITableViewRowActionStyle.Default,
                                           "Delete",
                                           delegate {
                                            controller.DeleteTask(indexPath.Row);               
                                        });
                                        UITableViewRowAction editButton = UITableViewRowAction.Create(
                                            UITableViewRowActionStyle.Default,
                                            "Edit",
                                            delegate {
                                            controller.EditTask(indexPath.Row);
                                            });
                                         editButton.BackgroundColor = UIColor.LightGray;

                                        return new UITableViewRowAction[] { deleteButton,editButton };
                                    }

                                }
                            }


