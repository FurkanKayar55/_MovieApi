using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Stats
    {
        public int movieId { get; set; }
        public int watchDurationMs { get; set; }
    }
}
