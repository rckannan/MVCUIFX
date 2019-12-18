using System;
using System.ComponentModel.DataAnnotations;

namespace RithV.FX.EntityDTO.Security
{
    public class Roles : IDtoObjectModel
    {
        [Key]
        public virtual Int64 Key { get; set; }

        [Required(ErrorMessage = "Role name should not be empty.")]
        [StringLength(250)]
        public virtual string fldRole { get; set; }

        [StringLength(250)]
        public virtual string fldDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime fldLastUpdatedOn { get; set; }

        public Roles()
        {
            fldLastUpdatedOn = DateTime.Now;
        }
    }
}