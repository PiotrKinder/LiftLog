using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Domain
{
    public class Statistic
    {
        public Guid Id { get; set; }
        public string DataStat {  get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Exercise")]
        public Guid ExerciseId { get; set; }
    }
}
