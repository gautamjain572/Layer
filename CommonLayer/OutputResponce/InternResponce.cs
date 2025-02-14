using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.InternModels;

namespace CommonLayer.OutputResponce
{
    //public class OutputResponceXP
    //{
    //    public bool Suceess { get; set; } = false;
    //    public string Message { get; set; }
    //    public List<InternsOfXPIndia>? InternsOfXPIndia { get; set; } = new List<InternsOfXPIndia>();
    //}

    //public class CreationResponce
    //{
    //    public bool Suceess { get; set; } = false;
    //    public string Message { get; set; }
    //}

    //public class DeleteResponce
    //{
    //    public bool Suceess { get; set; } = false;
    //    public string Message { get; set; }
    //}

    //generic responce for all apis
    public class Responce<T>
    {
        public bool Suceess { get; set; } = false;
        public string Message { get; set; }
        public T? Data { get; set; }
    }

}
