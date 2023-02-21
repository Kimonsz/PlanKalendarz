using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanKalendarz
{
    public class ChecklistItem
    {
        private string checklistItemName;
        private bool isChecked;

        public string ChecklistItemName { get => checklistItemName; set => checklistItemName = value; }
        public bool IsChecked { get => isChecked; set => isChecked = value; }

        public ChecklistItem()
        { }

        public ChecklistItem(string x)
        {
            this.ChecklistItemName = x;
            IsChecked=false;
        }

        public void SetCheclistNames(string x)
        {
            this.ChecklistItemName = x;
            IsChecked = false;
        }
    }
}
