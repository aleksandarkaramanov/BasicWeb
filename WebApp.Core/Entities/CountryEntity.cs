using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp.Core.Entities
{
    public class CountryEntity
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;

        [JsonIgnore]
        public List<ContactEntity>? Contacts { get; set; }
    
    }
}
