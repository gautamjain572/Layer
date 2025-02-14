using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.DatabaseModels;
using RepositoryLayer.DataContext;
using RepositoryLayer.ManagerEFCorePowerTools;
using GetAllSkillsResult = RepositoryLayer.DatabaseModels.GetAllSkillsResult;

namespace RepositoryLayer.Interfaces
{
    public interface IInternDataRL
    {
        Task<List<GetAllInternsResult>> GetAllInternsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetAllSkillsResult>> GetAllSkillsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);

        // post api
        Task<int> InsertInternAsync(string? intern_name, decimal? salary, string? email, string? mobile_number, DateTime? joining_date, bool? internship_status, decimal? gpa, int? perfomance_rating, int? working_hours, long? study_field_id, OutputParameter<bool?> isInternAdded, OutputParameter<string> internAddedStatus, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        // delete api
        Task<int> SoftDeleteAsync(long? intern_id, OutputParameter<bool?> isInterndeleted, OutputParameter<string> interndeletedStatus, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
