using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp.Core.Entities
{
    public class CompanyEntity
    {
        [Key]
        [JsonIgnore]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        //Доколку треба да се вклучи при GET
        [JsonPropertyName("companyId")]
        public int GetCompanyIdForGetResponse => this.CompanyId;
        [JsonIgnore]
        public List<ContactEntity>? Contacts { get; set; }
    }

}
