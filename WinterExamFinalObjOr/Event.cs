using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterExamFinalObjOr
{
    internal class Event: IComparable<Event>
    {
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public List<Ticket> Tickets { get; set; }
        public enum TypeOfEvent {Music,Comedy,Theatre}
        
        
        public int CompareTo(Event other)
        {
            int dateComparison = this.EventDate.CompareTo(other.EventDate);
            if (this.EventDate == other.EventDate)
            {
                return this.Name.CompareTo(other.Name);
            }
            return dateComparison;
        }

    }
}
