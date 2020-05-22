using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyApi.Models
{
    public class Candy
    {
        public int CandyId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int FlavorId { get; set; }
        public DateTime DateCollected { get; set; }
        public bool Ate { get; set; }
        public int StashId { get; set; }
    }

    public class Stash
    {
        public int StashId { get; set; }
        public int CandyId { get; set; }
        public int UserId { get; set; }
    }
}
