using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealersPortal.Models
{
    public class Assistance
    {
        [MaxLength(20)]
        [Key]
        public string Id { get; set; }
            
        [MaxLength(80)]
        public string Name { get; set; }

        public string Description { get; set; }

        [MaxLength(50)]
        public string Provider { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public DateTime? Date { get; set; }

        public bool? Synced { get; set; }        
    }
}