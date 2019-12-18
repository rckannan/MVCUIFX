using System;
using System.Security.Principal;

namespace RithV.FX.WebAPI.Models
{
    public class ValidUserContext
    {
        public virtual IPrincipal Principal { get; set; }
        //public virtual UserWithRoles User { get; set; }
        public virtual DateTime SessionOpenTime { get; set; }
        public virtual DateTime SessionLastUpdated { get; set; }
        public virtual string IPAddress { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}