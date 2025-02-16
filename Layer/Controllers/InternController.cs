using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;
using CommonLayer.OutputResponce;
using CommonLayer.InternModels;

namespace Layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InternController : ControllerBase
    {

        public IInternBL _internsBL;

        public InternController(IInternBL internsBL)
        {
            _internsBL = internsBL;
        }

        //from repo
        [HttpGet("get-xp-data")]
        public async Task<Responce<List<InternsOfXPIndia>>> GetInternXPData()
        {
            Responce<List<InternsOfXPIndia>> responce = await _internsBL.GetInternsOfXPIndia();
            return responce;
        }

        [HttpGet("get-skill-data")]
        public async Task<Responce<List<Skills>>> GetSkillXPData()
        {
            Responce<List<Skills>>  skills  = await _internsBL.GetSkills();
            return skills;
        }

        [HttpPost("add-intern")]
        public async Task<Responce<object>> AddInternToXPIndia(InternsOfXPIndia internsOfXPIndia)
        {
            Responce<object> creationResponce = await _internsBL.AddIntern(internsOfXPIndia);
            return creationResponce;
        }

        [HttpDelete("remove-intern")]
        public async Task<Responce<object>> RemoveInternFromXPIndia(long? internId)
        {
            Responce<object> deleteResponce = await _internsBL.RemoveIntern(internId);
            return deleteResponce;
        }

        [HttpPut("assign-skill")]
        public async Task<Responce<object>> AssignSkillsToIntern(long? internId, string skillIds)
        {
            Responce<object> assignSkillResponce = await _internsBL.AssignSkillsToIntern(internId, skillIds);
            return assignSkillResponce;
        }

        [HttpGet("get-study-fields")]
        public async Task<Responce<List<StudyFields>>> GetStudyFields()
        {
            Responce<List<StudyFields>> studyFields = await _internsBL.GetStudyFields();
            return studyFields;
        }

        // old code
        //[HttpPost("get-bank-detail")]
        //public BankAccountResponse ApplicationForBank(BankAccountDetails bankAccountDetails)
        //{
        //    BankAccountResponse bankAccountResponse = new BankAccountResponse();
        //    return bankAccountResponse;
        //}
        //[HttpGet("get-intern-data")]
        //public InternsResponce GetInternData()
        //{
        //    InternsResponce internsResponce = new InternsResponce();
        //    internsResponce = _internsBL.GetInternsData();
        //    return internsResponce;
        //}
        //[HttpGet("get-intern-id")]
        //public InternsResponce GetInternsDeatilsById(long? internId)
        //{
        //    InternsResponce internsResponce = new InternsResponce();
        //    internsResponce = _internsBL.GetInternsDeatilsById(internId);
        //    return internsResponce;
        //}
        //[HttpGet("get-date-check-dependencyLifeCycle")]
        //public DateTime GetDateTime()
        //{
        //    DateTime dateTime = _internsBL.GetDateTime();
        //    DateTime dateTime2 = _internsBL.GetDateTime();
        //    return dateTime;
        //}
        //1. Retrieve All Interns
        //[HttpGet("all")]
        //public List<Intern> GetAllInterns()
        //{
        //    return interns;
        //}
        //// 2. Retrieve Intern by ID
        //[HttpGet("byId")]
        //public IActionResult GetInternById(int id)
        //{
        //    var intern = interns.FirstOrDefault(i => i.Id == id);
        //    if (intern == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(intern);
        //}
        //// 3. Filter Interns by Field of Study
        //[HttpGet("byFieldOfStudy")]
        //public List<Intern> GetInternsByFieldOfStudy(string field)
        //{
        //    return interns.Where(i => i.FieldOfStudy.Equals(field, StringComparison.OrdinalIgnoreCase)).ToList();
        //}
        //// 4. Retrieve Active Interns
        //[HttpGet("active")]
        //public List<Intern> GetActiveInterns()
        //{
        //    return interns.Where(i => i.InternshipStatus.Equals("Active", StringComparison.OrdinalIgnoreCase)).ToList();
        //}
        //// 5. Retrieve Top Performers
        //[HttpGet("topPerformers")]
        //public List<Intern> GetTopPerformers()
        //{
        //    return interns.Where(i => i.PerformanceRating >= 8).ToList();
        //}
        //// 6. Filter Interns by Joining Date Range
        //[HttpGet("byJoiningDateRange")]
        //public List<Intern> GetInternsByJoiningDateRange(DateTime start, DateTime end)
        //{
        //    return interns.Where(i => i.JoiningDate >= start && i.JoiningDate <= end).ToList();
        //}
        //// 7. Retrieve Interns by Supervisor
        //[HttpGet("bySupervisor")]
        //public List<Intern> GetInternsBySupervisor(string name)
        //{
        //    return interns.Where(i => i.Supervisor.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        //}
        //// 8. Filter Interns by Skills
        //[HttpGet("bySkill")]
        //public List<Intern> GetInternsBySkill(string skill)
        //{
        //    return interns.Where(i => i.Skills.Contains(skill, StringComparer.OrdinalIgnoreCase)).ToList();
        //}
        //// 9. Retrieve Interns with High GPA
        //[HttpGet("byGPA")]
        //public List<Intern> GetInternsByGPA(double threshold)
        //{
        //    return interns.Where(i => i.GPA >= threshold).ToList();
        //}
        //// 10. Count Interns by Department
        //[HttpGet("countByDepartment")]
        //public IActionResult GetInternCountByDepartment()
        //{
        //    var countByDepartment = interns.GroupBy(i => i.Department).ToDictionary(g => g.Key, g => g.Count());
        //    return Ok(countByDepartment);
        //}


    }
}
