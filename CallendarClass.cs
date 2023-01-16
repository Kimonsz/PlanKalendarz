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

        public static void AddEventViewModel(string name)
        {
            events.Add(new Event(name));
        }
        
        public static List<String> GetEventsList()
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

    }
}
