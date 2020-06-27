using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Model
{
   public class Error:IdentityBase
    {

        public Error()
        {
            this.ErrorDate=DateTime.Now;
            this.ChangedOn=DateTime.Now;
            this.CreatedOn=DateTime.Now;
            this.CreatedBy="monitor@arteconarte.com";
            this.ChangedBy="monitor@arteconarte.com";


        }

        public string UserId { get; set;}
        public Nullable<System.DateTime> ErrorDate { get; set;}
        public string IpAddress { get; set;}
        public string UserAgent { get; set;}
        public string Exception { get; set;}
        public string Message { get; set;}
        public string Everything { get; set;}
        public string HttpReferer { get; set;}
        public string PathAndQuery { get; set;}
    }
}
