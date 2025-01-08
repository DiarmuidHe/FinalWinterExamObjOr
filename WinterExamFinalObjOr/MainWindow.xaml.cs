using System.Security.Principal;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static WinterExamFinalObjOr.Event;
/*
 * 
 * 
 * 
 */
namespace WinterExamFinalObjOr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Event> events = new List<Event>();
        List<Ticket> tickets = new List<Ticket>();  
        List<Event> filterEvents = new List<Event>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Event e1 = new Event()
            {
                Name = "Oasis Croke Park",
                EventDate = new DateTime(2025, 06, 20),
                EventType = TypeOfEvent.Music
            };
            Event e2 = new Event()
            {
                Name = "Electric Picnic",
                EventDate = new DateTime(2025, 08, 20),
                EventType = TypeOfEvent.Music,
            };
            Ticket t1 = new Ticket()
            {
                Name = "Early Bird",
                Price = 100m,
                AvailableTickets = 100
            };
            Ticket t2 = new Ticket()
            {
                Name = "Platinium",
                Price = 150m,
                AvailableTickets = 100
            };
            VIPTicket vip1 = new VIPTicket()
            {
                Name = "Ticket and Hotel Package",
                Price = 150m,
                AdditionalCost = 100m,
                AdditionalExtras = "4* hotel",
                AvailableTickets = 100

            };
            VIPTicket vip2 = new VIPTicket()
            {
                Name = "Weekend Ticket",
                Price = 200m,
                AdditionalCost = 100m,
                AdditionalExtras = "with camping",
                AvailableTickets = 100
            };
            events.Add(e2);
            events.Add(e1);
            

            events.Sort();
            lbxEvents.ItemsSource = events;

            tickets.Add(t1);
            tickets.Add(t2);
            tickets.Add(vip1);
            tickets.Add(vip2);
            lbxTickets.ItemsSource = tickets;

        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {

            Ticket selected = lbxTickets.SelectedItem as Ticket;
            
            if (selected != null)
            {
                if (int.TryParse(tbxNumberOfTickets.Text, out int amountWanted))
                {
                    tickets.Remove(selected);
                    if (!selected.CheckIfTicketsAvailable(amountWanted))
                    {
                        MessageBox.Show("Invalid ticket ticket amount, please enter a different ticket amount");

                    }
                    tickets.Add(selected);
                    lbxTickets.ItemsSource = tickets;
                }
                else
                {
                    MessageBox.Show("Invalid ticket number, please enter a number");
                }
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            filterEvents.Clear();
            if (tbxSearch.Text != null)
            {
                for (int i = 0; i < events.Count; i++)
                {

                    if (tbxSearch.Text.ToLower() == events[i].Name.ToLower())
                    {
                        filterEvents.Add(events[i]);

                    }
                }
                lbxEvents.ItemsSource = filterEvents;
            }

        }
    }
}