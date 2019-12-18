using System;

namespace RithV.FX.Entity
{
    public interface IDatabaseValueParser
    {
        long ParseLong(object obj);
        string ParseString(object obj);
        DateTime ParseDateTime(object obj);
        byte[] ParseByteArray(object obj);

        long? ParseLongNullable(object obj);
        DateTime? ParseDateTimeNullable(object obj);
    }

    public class DatabaseValueParser : IDatabaseValueParser
    {

        public long ParseLong(object obj)
        {
            return long.Parse(obj.ToString());
        }

        public string ParseString(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return null;
            }
            return obj.ToString();
        }

        public DateTime ParseDateTime(object obj)
        {
            return DateTime.Parse(obj.ToString());
        }

        public byte[] ParseByteArray(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return null;
            }
            return (byte[])obj;
        }

        public long? ParseLongNullable(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return null;
            }
            return ParseLong(obj);
        }

        public DateTime? ParseDateTimeNullable(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return null;
            }
            return ParseDateTime(obj);
        }
    }
}