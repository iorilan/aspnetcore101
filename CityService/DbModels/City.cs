using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CityService.DbModels
{
    public class City
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string StateCode  { get; set; }
        public string PostalCode { get; set; }
    }
}
