using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Assessment.App.Models
    {
    public class Player
        {
        [Key]
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        }
    }
