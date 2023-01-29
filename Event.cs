using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanKalendarz
{
    public class Event
    {
        String name;
        DateTime eventTime;
        private DateTime eventReminder;
        List<String> eventChecklist;
        List<String> eventNotes;
        int eventCyclesNumber;
        int notifyHour;
        int notifyDay;
        int notifyMinute;
        bool notes;
        bool checklist;
        bool? notifyBefore;      // false=przed   true=po
                                 // 0=NULL -1=False 1=True


        public Event(string name, DateTime eventTime, DateTime eventReminder, List<string> eventChecklist, List<string> eventNotes, int eventCyclesNumber)
        {
            this.name = name;
            this.eventTime = eventTime;
            this.eventReminder = eventReminder;
            this.eventChecklist = eventChecklist;
            this.eventNotes = eventNotes;
            this.eventCyclesNumber = eventCyclesNumber;
        }

        public Event(string name)
        {
            this.name = name;
        }

        public Event(string name, bool notes, bool checklist)
        {
            this.name = name;
            this.notes = notes;
            this.checklist = checklist;

        }

        //most commonly used constructor (In AddEventView)
        public Event(string name, bool notes, bool checklist,bool notifybefore,string notifyDay, string notifyHour,string notifyMinute)
        {
            this.name = name;
            this.notes = notes;
            this.checklist = checklist;
            this.notifyBefore = notifybefore;

            if (!string.IsNullOrEmpty(notifyDay))
                this.notifyDay = Convert.ToInt32(notifyDay);
            else
                this.notifyDay = 0;

            if (!string.IsNullOrEmpty(notifyHour))
                this.notifyHour = Convert.ToInt32(notifyHour);
            else
                this.notifyHour = 0;

            if (!string.IsNullOrEmpty(notifyMinute))
                this.notifyMinute = Convert.ToInt32(notifyMinute);
            else
                this.notifyMinute = 0;

        }
        public string GetNotificationDate(DateTime choosenTime)
        {
            this.SetNotificationDate(choosenTime);

            return eventReminder.ToString();
        }
        public void SetNotificationDate(DateTime choosenTime)
        {
            DateTime currentDate = DateTime.Now;
            int currentYear = currentDate.Year;
            int currentMonth = currentDate.Month;

            int notInfo = this.GetNotifyInfo();
            // false=przed   true=po
            // 0=NULL -1=False 1=True

            if (notInfo != 0)   //add or substract from choosen date set before time of notification
            {
                if (notInfo == -1)
                {
                    this.eventReminder = choosenTime.Subtract(new TimeSpan(this.notifyDay, this.notifyHour, this.notifyMinute, 0));
;                }
                else
                {
                    this.eventReminder = choosenTime.Add(new TimeSpan(this.notifyDay, this.notifyHour, this.notifyMinute, 0));
                }
            }
        }

        public string Name 
        { 
            get => name;
            set => name = value; 
        }
        public DateTime EventTime 
        { 
            get => eventTime; 
            set => eventTime = value; 
        }
        private DateTime EventReminder 
        {
            get => eventReminder; 
            set => eventReminder = value; 
        }
        public List<string> EventChecklist 
        { 
            get => eventChecklist; 
            set => eventChecklist = value; 
        }
        public List<string> EventNotes 
        { 
            get => eventNotes; 
            set => eventNotes = value; 
        }
        public int EventCyclesNumber 
        { 
            get => eventCyclesNumber; 
            set => eventCyclesNumber = value; 
        }
        public int GetNotifyInfo() 
        {
            // 0=NULL -1=False 1=True
            if (this.notifyBefore == null)
            {
                return 0;
            }
            else if (this.notifyBefore == true)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
