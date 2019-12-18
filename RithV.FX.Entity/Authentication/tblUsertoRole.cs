using System;

namespace RithV.FX.Entity
{
    public class tblUsertoRole : IVersionedObjectModel
    {
        public virtual long Key { get; set; }

        public virtual long fldUser_ID { get; set; }

        public virtual long fldRole_ID { get; set; }

        public virtual DateTime fldLastUpdatedOn { get; set; }

        public virtual tblUser fldUser { get; set; }

        public virtual tblRole fldRole { get; set; }

        //public virtual long fldWebPart_ID { get; set; }

        //public virtual IList<tblWebPart> fldWebPart { get; set; }

        public virtual byte[] Version { get; set; }

    }

    public class UsertoRoleMapper : VersionedClassMap<tblUsertoRole>
    {
        public UsertoRoleMapper()
        {
            Table("main.tblUsertoRole");
            Id(x => x.Key, "fldUsertoRole_ID");
            Map(x => x.fldRole_ID, "fldRole_ID").Not.Nullable();
            Map(x => x.fldUser_ID, "fldUser_ID").Not.Nullable();
            Map(x => x.fldLastUpdatedOn, "fldLastUpdatedOn").Not.Nullable();
            References(x => x.fldUser, "fldUser_ID").Not.LazyLoad().Nullable().Not.Insert().Not.Update();
            References(x => x.fldRole, "fldRole_ID").Not.LazyLoad().Nullable().Not.Insert().Not.Update();

            //Join("main.tblRoletoWebPart", part =>
            //{ 
            //    part.KeyColumn("fldRole_ID"); 
            //    part.Map(x => x.fldWebPart_ID, "fldWebPart_ID"); 
            //});

            //Join("main.tblWebPart", part =>
            //{
            //    part.KeyColumn("fldWebPart_ID");
            //    Map(x => x.fldWebPart, "fldWebPart_ID");

            //});
        }
    }
}