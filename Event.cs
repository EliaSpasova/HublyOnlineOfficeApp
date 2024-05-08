using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HublyProject.authenticate;

namespace HublyProject
{
    public class Event
    {
        public int eventID { get; set; }
        public int userID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime eventDate { get; set; }
        public string Location { get; set; }
        public string Privacy { get; set; }
    }
}
