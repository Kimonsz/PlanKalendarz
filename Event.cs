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
        List<ChecklistItem> eventChecklist;
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
            foreach (string x in eventChecklist)
                this.eventChecklist.Add(new ChecklistItem(x));
            this.eventNotes = eventNotes;
            this.eventCyclesNumber = eventCyclesNumber;
        }

        public Event(Event x, DateTime data) //copying contructor with date (to add active event)
        {
            name = x.name;
            eventTime = data;
            eventReminder = x.eventReminder;
            eventChecklist = x.eventChecklist;
            eventNotes = x.eventNotes;
            eventCyclesNumber = x.eventCyclesNumber;
            notifyHour = x.notifyHour;
            notifyDay = x.notifyDay;
            notifyMinute = x.notifyMinute;
            notes = x.notes;
            checklist  = x.checklist;
            notifyBefore = x.notifyBefore;
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

        public Event(string name, bool? notInfo, DateTime pickedDate, string notifyDay, string notifyHour, string notifyMinute, List<string> checklist, string note)
        {
            this.name = name;
            this.notifyBefore = notInfo;
            this.eventTime = pickedDate;
            this.eventChecklist = new();

            //set notify info
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

            //set checklist
            if (checklist != null)
            {
                foreach (string x in checklist)
                    this.eventChecklist.Add(new ChecklistItem(x));
            }
            else
                this.eventChecklist = new();

            eventNotes = new();
            if(note!=null)
                eventNotes.Add(note);


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
        public List<ChecklistItem> EventChecklist { get => eventChecklist; set => eventChecklist = value; }

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
