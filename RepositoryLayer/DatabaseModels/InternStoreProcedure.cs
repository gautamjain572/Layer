using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DatabaseModels
{
    public partial class GetAllInternsResult
    {
        public long intern_id { get; set; }
        public string intern_name { get; set; }
        [Column("salary", TypeName = "decimal(18,2)")]
        public decimal? salary { get; set; }
        public string email { get; set; }
        public string mobile_number { get; set; }
        public DateTime? joining_date { get; set; }
        public bool? internship_status { get; set; }
        [Column("gpa", TypeName = "decimal(18,2)")]
        public decimal? gpa { get; set; }
        public int? perfomance_rating { get; set; }
        public int? working_hours { get; set; }
        public long? study_field_id { get; set; }
    }

    public partial class GetAllSkillsResult
    {
        public long skill_id { get; set; }
        public string skill_name { get; set; }
    }
}
