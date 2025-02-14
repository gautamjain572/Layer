using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.InternModels;
using CommonLayer.OutputResponce;
using RepositoryLayer.Interfaces;
using RepositoryLayer.ManagerEFCorePowerTools;

namespace BusinessLayer.Services
{
    public class InternsBL : IInternBL
    {

        public IInternDataRL _internDataRL;
       
        public InternsBL(IInternDataRL internDataRL)
        {
            _internDataRL = internDataRL;
        }

        public async Task<Responce<List<InternsOfXPIndia>>> GetInternsOfXPIndia()
        {
            Responce<List<InternsOfXPIndia>> responce = new Responce<List<InternsOfXPIndia>>();
            try
            {
                // to get the intrns data via repo from db (relevant interface)
                var internsData = await _internDataRL.GetAllInternsAsync();
                responce.Suceess = true;
                //check if data is there
                if (internsData.Count() > 0)
                {
                    //if yes, then map the data to the our created model lis, InternsOfXPIndia
                    List<InternsOfXPIndia> internsOfXPIndias = new List<InternsOfXPIndia>();
                    // itrate over the data and map it to the model
                    for (int i = 0; i < internsData.Count(); i++)
                    {
                        // currenent data variable
                        var data = internsData[i];  // just like internsData.ElementAt(i);
                        // create a object of InternsOfXPIndia and map the data to it current itration intrem
                        InternsOfXPIndia internsOfXPIndia = new InternsOfXPIndia()
                        {
                            InternId = data.intern_id,
                            InternName = data.intern_name,
                            Salary = data.salary,
                            Email = data.email,
                            PhoneNumber = data.mobile_number,
                            JoiningDate = data.joining_date,
                            InternshipStatus = data.internship_status,
                            GPA = data.gpa,
                            PerformanceRating = data.perfomance_rating,
                            WorkingHours = data.working_hours,
                            StudyFieldId = data.study_field_id
                        };
                        // add the created object into the list
                        internsOfXPIndias.Add(internsOfXPIndia);
                    }
                    responce.Data = internsOfXPIndias;
                    responce.Message = "Interns Data Fetched Successfully";
                }
            }
            catch (Exception ex)
            {
                responce.Suceess = false;
                responce.Message = ex.Message;
                //return outputResponceXP;
            }
            return responce;
        }

        public async Task<Responce<List<Skills>>> GetSkills()
        {
            Responce<List<Skills>> responce = new Responce<List<Skills>>();
            try
            {
                List<Skills> skills = new List<Skills>();
                var skillsData = await _internDataRL.GetAllSkillsAsync();

                long noOfSkills = skillsData.Count();
                for (int i = 0; i < noOfSkills; i++)
                {
                    var currentItration = skillsData[i];
                    Skills skill = new Skills()
                    {
                        SkillId = currentItration.skill_id,
                        SkillName = currentItration.skill_name
                    };
                    skills.Add(skill);
                }
                responce.Suceess = true;
                responce.Message = "Skills Data Fetched Successfully";
                responce.Data = skills;
            }
            catch (Exception ex)
            {
                //return outputResponceXP;
                responce.Suceess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        // post api
        public async Task<Responce<object>> AddIntern(InternsOfXPIndia internsOfXPIndia)
        {
            Responce<object> creationResponce = new Responce<object>();
            try
            {
                string errormessage = ValidateInternData(internsOfXPIndia);
                if (string.IsNullOrEmpty(errormessage))
                {
                    // for output parameters
                    OutputParameter<bool?> isInternAdded = new OutputParameter<bool?>();
                    OutputParameter<string> internAddedStatus = new OutputParameter<string>();

                    await _internDataRL.InsertInternAsync(internsOfXPIndia.InternName, internsOfXPIndia.Salary, internsOfXPIndia.Email, internsOfXPIndia.PhoneNumber, internsOfXPIndia.JoiningDate, true, internsOfXPIndia.GPA, internsOfXPIndia.PerformanceRating, internsOfXPIndia.WorkingHours, internsOfXPIndia.StudyFieldId, isInternAdded, internAddedStatus);

                    creationResponce.Suceess = isInternAdded.Value ?? false; // if null then false
                    creationResponce.Message = internAddedStatus.Value;
                }
                else
                {
                    creationResponce.Suceess = false;
                    creationResponce.Message = errormessage;
                }
            }
            catch (Exception ex)
            {
                creationResponce.Suceess = false;
                creationResponce.Message = ex.Message;
            }
            return creationResponce;
        }
        // this method is not used in the controller used by addIntern
        private string ValidateInternData(InternsOfXPIndia internsOfXPIndia)
        {
            string message = string.Empty; // string.Empty` is better than `""`

            if (string.IsNullOrEmpty(internsOfXPIndia.InternName)) return "Intern Name Cannot be empty";
            if (internsOfXPIndia.Salary <  0) return "Salary Cannot be empty";
            if (string.IsNullOrEmpty(internsOfXPIndia.Email)) return "Email Cannot be empty";
            if (string.IsNullOrEmpty(internsOfXPIndia.PhoneNumber)) return "Mobile Number Cannot be empty";
            if (internsOfXPIndia.GPA < 0) return "GPA Cannot be empty";
            if (internsOfXPIndia.PerformanceRating < 0) return "Performance Rating Cannot be empty";
            if (internsOfXPIndia.WorkingHours < 0) return "Working Hours Cannot be empty";

            return message;
        }

        // delete api
        public async Task<Responce<object>> RemoveIntern(long? id)
        {
            Responce<object> deleteResponce = new Responce<object>();
            try
            {
                if (id == null)
                {
                    deleteResponce.Suceess = false;
                    deleteResponce.Message = "Intern Id Cannot be null";
                }
                else
                {
                    OutputParameter<bool?> isInternDeleted = new OutputParameter<bool?>();
                    OutputParameter<string> internDeletedStatus = new OutputParameter<string>();
                    await _internDataRL.SoftDeleteAsync(id.Value, isInternDeleted, internDeletedStatus);
                    deleteResponce.Suceess = isInternDeleted.Value ?? false;
                    deleteResponce.Message = internDeletedStatus.Value;
                }
            }
            catch (Exception ex)
            {
                deleteResponce.Suceess = false;
                deleteResponce.Message = ex.Message;
            }
            return deleteResponce;
        }
    }
}
