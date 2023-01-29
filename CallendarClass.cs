using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanKalendarz.ViewModels;

namespace PlanKalendarz
{
    public static class CallendarClass
    {
        static List<Event> events = new();
        public static List<Event> activeEvents = new();

        public static void AddEventViewModel(string name)
        {
            events.Add(new Event(name));
        }

        public static void AddEventViewModel(string name, bool notes, bool checklist)
        {
            //string name, bool notes, bool checklist,bool notifybefore,string notifyDay, string notifyHour,string notifyMinute
            events.Add(new Event(name, notes, checklist));
        }

        public static void AddEventViewModel(string name,bool notes,bool checklist,bool notifybefore, string notifyDay, string notifyHour, string notifyMinute)
        {
            //string name, bool notes, bool checklist,bool notifybefore,string notifyDay, string notifyHour,string notifyMinute
            events.Add(new Event(name,notes,checklist,notifybefore,notifyDay,notifyHour,notifyMinute));
        }

        public static List<String> GetEventsListName()
        {
            List<String> m = new();
            foreach (Event x in events)
            {
                m.Add(x.Name);
            }
            return m;
        }

        public static void DeleteEventByName(string name)
        {
            foreach(Event x in events)
            {
                if(x.Name.Equals(name))
                {
                    events.Remove(x);
                    break;
                }
            }
        }

        public static Event GetEventByName(string name)
        {
            foreach (Event x in events)
            {
                if (x.Name.Equals(name))
                {
                    return x;
                }
            }
            return null;
        }

    }
}
