 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DatabaseModels;
using RepositoryLayer.DataContext;
using RepositoryLayer.Interfaces;
using RepositoryLayer.ManagerEFCorePowerTools;
using GetAllSkillsResult = RepositoryLayer.DatabaseModels.GetAllSkillsResult;

namespace RepositoryLayer.Services
{
    public class InternDataRL : IInternDataRL
    {
        public InternDataContext _internDataContext;

        public InternDataRL(InternDataContext internDataContext)
        {
            _internDataContext = internDataContext;
        }

        public virtual async Task<List<GetAllInternsResult>> GetAllInternsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _internDataContext.SqlQueryAsync<GetAllInternsResult>("EXEC @returnValue = [dbo].[GetAllInterns]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetAllSkillsResult>> GetAllSkillsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _internDataContext.SqlQueryAsync<GetAllSkillsResult>("EXEC @returnValue = [dbo].[GetAllSkills]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        //post api
        public virtual async Task<int> InsertInternAsync(string? intern_name, decimal? salary, string? email, string? mobile_number, DateTime? joining_date, bool? internship_status, decimal? gpa, int? perfomance_rating, int? working_hours, long? study_field_id, OutputParameter<bool?> isInternAdded, OutputParameter<string> internAddedStatus, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterisInternAdded = new SqlParameter
            {
                ParameterName = "isInternAdded",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = isInternAdded?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Bit,
            };
            var parameterinternAddedStatus = new SqlParameter
            {
                ParameterName = "internAddedStatus",
                Size = 400,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = internAddedStatus?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "intern_name",
                    Size = 500,
                    Value = intern_name ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "salary",
                    Precision = 18,
                    Scale = 2,
                    Value = salary ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
                },
                new SqlParameter
                {
                    ParameterName = "email",
                    Size = 500,
                    Value = email ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "mobile_number",
                    Size = 20,
                    Value = mobile_number ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "joining_date",
                    Value = joining_date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "internship_status",
                    Value = internship_status ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Bit,
                },
                new SqlParameter
                {
                    ParameterName = "gpa",
                    Precision = 18,
                    Scale = 2,
                    Value = gpa ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
                },
                new SqlParameter
                {
                    ParameterName = "perfomance_rating",
                    Value = perfomance_rating ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "working_hours",
                    Value = working_hours ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "study_field_id",
                    Value = study_field_id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.BigInt,
                },
                parameterisInternAdded,
                parameterinternAddedStatus,
                parameterreturnValue,
            };
            var _ = await _internDataContext.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[InsertIntern] @intern_name = @intern_name, @salary = @salary, @email = @email, @mobile_number = @mobile_number, @joining_date = @joining_date, @internship_status = @internship_status, @gpa = @gpa, @perfomance_rating = @perfomance_rating, @working_hours = @working_hours, @study_field_id = @study_field_id, @isInternAdded = @isInternAdded OUTPUT, @internAddedStatus = @internAddedStatus OUTPUT", sqlParameters, cancellationToken);

            isInternAdded?.SetValue(parameterisInternAdded.Value);
            internAddedStatus?.SetValue(parameterinternAddedStatus.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        //delete api
        public virtual async Task<int> SoftDeleteAsync(long? intern_id, OutputParameter<bool?> isInterndeleted, OutputParameter<string> interndeletedStatus, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterisInterndeleted = new SqlParameter
            {
                ParameterName = "isInterndeleted",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = isInterndeleted?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Bit,
            };
            var parameterinterndeletedStatus = new SqlParameter
            {
                ParameterName = "interndeletedStatus",
                Size = 400,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = interndeletedStatus?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "intern_id",
                    Value = intern_id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.BigInt,
                },
                parameterisInterndeleted,
                parameterinterndeletedStatus,
                parameterreturnValue,
            };
            var _ = await _internDataContext.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[SoftDelete] @intern_id = @intern_id, @isInterndeleted = @isInterndeleted OUTPUT, @interndeletedStatus = @interndeletedStatus OUTPUT", sqlParameters, cancellationToken);

            isInterndeleted?.SetValue(parameterisInterndeleted.Value);
            interndeletedStatus?.SetValue(parameterinterndeletedStatus.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

    }
}
