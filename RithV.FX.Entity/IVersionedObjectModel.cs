using System;

namespace RithV.FX.Entity
{
    public interface IVersionedObjectModel
    {
        Int64 Key { get; set; }

        byte[] Version { get; set; }
    }


}