using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Details { get; set; }
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string  CreatedBy { get; set; }

    }
}
