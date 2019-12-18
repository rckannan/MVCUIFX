using System;

namespace RithV.FX.Entity
{
    public class tblAPIUser : IVersionedObjectModel
    {
        public virtual Int64 Key { get; set; }
        public virtual string fldUserName { get; set; }
        public virtual string fldPassword { get; set; }
        public virtual bool fldActiveUser { get; set; } = true;
        public virtual DateTime fldLastUpdatedOn { get; set; }
        public virtual byte[] Version { get; set; }
    }


}
