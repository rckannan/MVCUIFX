using Newtonsoft.Json;
using System;
using System.IO;

namespace RithV.FX.EntityDTO
{
    public class UserDetail
    {
        public Int64 UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime UserSession { get; set; }

        public override string ToString()
        {
            var serializer = new JsonSerializer();
            using (var stream = new StringWriter())
            {
                serializer.Serialize(stream, this);
                return stream.ToString();
            }
        }

        public static UserDetail FromString(string userContextData)
        {
            var serializer = new JsonSerializer();
            return serializer.Deserialize<UserDetail>(new JsonTextReader(new StringReader(userContextData)));

        }
    }
}
