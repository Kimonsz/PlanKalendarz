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
