using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RithV.FX.EntityDTO.Security
{
    public class WebParts : IDtoObjectModel
    {
        [Key]
        public virtual long Key { get; set; }

        public virtual string fldDisplayName { get; set; }

        public virtual string fldAction { get; set; }

        public virtual string fldController { get; set; }

        public virtual string fldIconName { get; set; }

        public virtual string fldParam { get; set; }

        public virtual long fldParant_ID { get; set; }

        public virtual IList<WebParts> fldWebPart { get; set; }

        public virtual DateTime fldLastUpdatedOn { get; set; }

        public virtual bool fldisParent { get; set; }

        public virtual long fldUser_ID { get; set; }

        public virtual long fldRole_ID { get; set; }

        //public virtual Users fldUser { get; set; }

        //public virtual Roles fldRole { get; set; }

    }
}