using System;

namespace RithV.FX.Entity
{
    public class tblRoletoWebPart : IVersionedObjectModel
    {
        public virtual long Key { get; set; }

        public virtual long fldRole_ID { get; set; }

        public virtual long fldWebpart_ID { get; set; }

        public virtual DateTime fldLastUpdatedOn { get; set; }

        public virtual tblRole fldRole { get; set; }

        public virtual tblWebPart fldWebPart { get; set; }

        public virtual DateTime fldLastUpdated { get; set; }

        public virtual byte[] Version { get; set; }
    }


    public class RoletoWebPartMapper : VersionedClassMap<tblRoletoWebPart>
    {
        public RoletoWebPartMapper()
        {
            Table("main.tblRoletoWebPart");
            Id(x => x.Key, "fldRoletoWebPart_ID");
            Map(x => x.fldRole_ID, "fldRole_ID").Not.Nullable();
            Map(x => x.fldWebpart_ID, "fldWebPart_ID").Not.Nullable();
            Map(x => x.fldLastUpdatedOn, "fldLastUpdatedOn").Not.Nullable();

            References(x => x.fldWebPart, "fldWebPart_ID").Not.LazyLoad().Nullable().Not.Insert().Not.Update();
            References(x => x.fldRole, "fldRole_ID").Not.LazyLoad().Nullable().Not.Insert().Not.Update();
        }
    }
}