using System;
using System.ComponentModel.DataAnnotations;

namespace RithV.FX.EntityDTO
{
    public interface IDtoObjectModel
    {
        [Key]
        Int64 Key { get; set; }
    }
}