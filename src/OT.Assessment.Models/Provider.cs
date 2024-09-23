using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Assessment.App.Models
    {
    public class Provider
        {
        public string ProviderName { get; set; }
        public Guid PoviderId { get; set; }= Guid.NewGuid();
        [Key]
        public int Id { get;set; }
        }
    }
