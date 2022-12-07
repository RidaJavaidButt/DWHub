using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DWHub.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public string Location { get; set; }

        [ForeignKey("CompanyOwner")]
        public int CompanyOwnerId { get; set; }
        public virtual CompanyOwner CompanyOwner{ get; set; }
        
        public List<Watch> Watches { get; set; }

    }
}
