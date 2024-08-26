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
        public User User { get; set; }
        public Exercise Exercise { get; set; }
    }
}
