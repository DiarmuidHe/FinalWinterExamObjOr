using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterExamFinalObjOr
{
    public class Ticket
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }

        public bool CheckIfTicketsAvailable(int amountWanted)
        {
            if (AvailableTickets >= amountWanted)
            {
                AvailableTickets -= amountWanted;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"{Name} - {Price.ToString("c")}[AVAILABLE - {AvailableTickets}]";
        }
    }
}
