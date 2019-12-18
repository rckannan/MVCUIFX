using System;

namespace RithV.FX.Entity
{
    public class tblUser : IVersionedObjectModel
    {
        public virtual Int64 Key { get; set; }
        public virtual string fldUserName { get; set; }
        public virtual string fldPassword { get; set; }
        public virtual string fldFullUserName { get; set; }
        public virtual int fldFailedAttempt { get; set; }
        public virtual string fldEmailAddress { get; set; }
        public virtual bool fldActiveUser { get; set; } = true;
        public virtual bool fldForceChangePassword { get; set; }
        public virtual DateTime fldPasswordLastUpdated { get; set; }
        //public virtual DateTime  fldLastUpdated { get; set; } 
        public virtual byte[] Version { get; set; }

        public virtual Int16 fldUserType { get; set; }
    }

}
