using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.InternModels;
using CommonLayer.OutputResponce;
using RepositoryLayer.ManagerEFCorePowerTools;

namespace BusinessLayer.Interfaces
{
    public interface IInternBL
    {
        Task<Responce<List<InternsOfXPIndia>>> GetInternsOfXPIndia();
        Task<Responce<List<Skills>>> GetSkills();
        Task<Responce<object>> AddIntern(InternsOfXPIndia internsOfXPIndia);
        Task<Responce<object>> RemoveIntern(long? id);  
    }
}
