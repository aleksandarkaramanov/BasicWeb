using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp.Core.Entities
{
    public class ContactEntity
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactName { get; set; } = null!;

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyEntity? Company { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public CountryEntity? Country { get; set; }
    }
}
