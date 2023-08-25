using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Application
{
    public class ApplicationUpdate_Pass_Object:Application_Pass_Object
    {
        public int id { get; set; }
        public int status_id { get; set; }

    }
}
