using Microsoft.AspNetCore.Identity;
using System;
using TQInventory.Domin.Entities;

namespace TQInventory.Domin.Entities
{
    public class Employee 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Role { get; set; }
    }
}
