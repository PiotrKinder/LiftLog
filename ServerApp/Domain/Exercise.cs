using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Reps { get; set; }
        public bool AllowExtraSet { get; set; }
        public User User { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
