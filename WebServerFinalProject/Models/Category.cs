using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebServerFinalProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }  // Primary Key
        public string Name { get; set; }

        // Navigation properties
        public ICollection<Recipe> Recipes { get; set; }
    }
}