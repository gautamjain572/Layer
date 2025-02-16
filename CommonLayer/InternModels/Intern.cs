using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.InternModels
{
    public class InternsOfXPIndia
    {
        public long? InternId { get; set; }
        public string? InternName { get; set; }
        public decimal? Salary { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? JoiningDate { get; set; }
        public bool? InternshipStatus { get; set; }
        public decimal? GPA { get; set; }
        public int? PerformanceRating { get; set; }
        public int? WorkingHours { get; set; }
        public long? StudyFieldId { get; set; }
    }

    public class  Skills 
    {
        public long? SkillId { get; set; }
        public string? SkillName { get; set; }
    }

    public class StudyFields
    {
        public long? studyFeildId { get; set; }
        public string? StudyFeildName { get; set; }
    }

}


