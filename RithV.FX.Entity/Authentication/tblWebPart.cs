using System;
using System.Collections.Generic;

namespace RithV.FX.Entity
{
    public class tblWebPart : IVersionedObjectModel
    {
        public virtual long Key { get; set; }

        public virtual string fldDisplayName { get; set; }

        public virtual string fldAction { get; set; }

        public virtual string fldController { get; set; }

        public virtual string fldIconName { get; set; }

        public virtual string fldParam { get; set; }

        public virtual long fldParant_ID { get; set; }

        public virtual IList<tblWebPart> fldWebPart { get; set; }

        public virtual DateTime fldLastUpdatedOn { get; set; }

        public virtual DateTime fldLastUpdated { get; set; }

        public virtual bool fldisParent { get; set; }

        public virtual byte[] Version { get; set; }

        public virtual long fldUser_ID { get; set; }

        public virtual long fldRole_ID { get; set; }

        //public virtual tblUser fldUser { get; set; }

        //public virtual tblRole fldRole { get; set; }

    }

    public class WebPartMapper : VersionedClassMap<tblWebPart>
    {
        public WebPartMapper()
        {
            //Table("main.tblWebPart");
            Table("main.vwMenuList");
            Id(x => x.Key, "fldWebpart_ID");
            Map(x => x.fldDisplayName, "fldDisplayName").Not.Nullable();
            Map(x => x.fldAction, "fldAction").Not.Nullable();
            Map(x => x.fldController, "fldController").Not.Nullable();
            Map(x => x.fldIconName, "fldIconName").Not.Nullable();
            Map(x => x.fldParam, "fldParam").Not.Nullable();
            Map(x => x.fldParant_ID, "fldParant_ID").Not.Nullable();
            Map(x => x.fldisParent, "fldisParent").Not.Nullable();
            Map(x => x.fldLastUpdatedOn, "fldLastUpdatedOn").Not.Nullable();
            //References(x => x.fldWebPart).Column("fldWebPart"); 
            HasMany(x => x.fldWebPart).KeyColumn("fldParant_ID").Inverse().Cascade.None().Not.LazyLoad();

            Map(x => x.fldRole_ID, "fldRole_ID").Not.Nullable();
            Map(x => x.fldUser_ID, "fldUser_ID").Not.Nullable();
            //References(x => x.fldUser, "fldUser_ID").Not.LazyLoad().Nullable().Not.Insert().Not.Update();
            //References(x => x.fldRole, "fldRole_ID").Not.LazyLoad().Nullable().Not.Insert().Not.Update();
        }
    }
}