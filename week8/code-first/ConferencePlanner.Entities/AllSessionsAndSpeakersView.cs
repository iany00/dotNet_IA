using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConferencePlanner.Entities
{
    public class AllSessionsAndSpeakersView
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        public virtual DateTimeOffset? StartTime { get; set; }
    }
}
