using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Assessment.App.Models
    {
    public class Game
        {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        }
    }
