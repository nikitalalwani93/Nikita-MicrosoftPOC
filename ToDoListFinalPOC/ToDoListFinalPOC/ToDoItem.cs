using System;
using Foundation;
using UIKit;

namespace ToDoListFinalPOC
{
    public class ToDoItem
    {
        public ToDoItem()
        {
        }
        public int id { get; set; }
        public string task { get; set; }
        public bool completed { get; set; }
    }
}
