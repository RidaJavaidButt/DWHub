using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DWHub.Models
{
    public class Watch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public int Price { get; set; }

        [ForeignKey("WatchCompany")]
        public int CompanyID { get; set; }
        public virtual Company WatchCompany{get;set;}
        [NotMapped]
        public List<Company> Companies { get; set; }

    }
}
