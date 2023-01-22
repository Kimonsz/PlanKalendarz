using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanKalendarz
{
    class Event
    {
        String name;
        DateTime eventTime;
        DateTime eventReminder;
        List<String> eventChecklist;
        List<String> eventNotes;
        int eventCyclesNumber;
        int notifyHour;
        int notifyDay;
        int notifyMinute;
        bool notes;
        bool checklist;
        bool notifyBefore;      //false=przed   true=po


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
        public DateTime EventReminder 
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
    }
}
