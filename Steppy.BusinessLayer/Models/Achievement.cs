using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steppy.BusinessLayer.Models
{
    [Table]
    public class Achievement : PropertyChangedBase
    {
        public Achievement()
        {
            
        }

        public Achievement(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Description { get; set; }

        //public Predicate Rule { get; set; }

        [Column]
        public bool IsUnlocked { get; set; }
    }

    public class LifetimeStats
    {
    }
}
