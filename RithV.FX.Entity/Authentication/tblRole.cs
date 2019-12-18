using System;

namespace RithV.FX.Entity
{
    public class tblRole : IVersionedObjectModel
    {
        public virtual Int64 Key { get; set; }
        public virtual string fldRole { get; set; }
        public virtual string fldDescription { get; set; }
        public virtual DateTime fldLastUpdatedOn { get; set; }
        public virtual byte[] Version { get; set; }
    }

    public class RoleMapper : VersionedClassMap<tblRole>
    {
        public RoleMapper()
        {
            Table("main.tblRole");
            Id(x => x.Key, "fldRole_ID");
            Map(x => x.fldRole, "fldRole").Not.Nullable();
            Map(x => x.fldDescription, "fldDescription").Not.Nullable();
            Map(x => x.fldLastUpdatedOn, "fldLastUpdatedOn").Not.Nullable();
        }
    }
}