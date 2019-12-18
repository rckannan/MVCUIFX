using RithV.FX.EntityDTO;
using RithV.FX.WebAPI.Models;

namespace RithV.FX.WebAPI.Infra.Security
{
    public interface IMembershipInfoProviders
    {
        ValidUserContext ValidateUser(string username, string password, string userdata);

        bool ValidateUser(string username, string password, out UserDetail detail);


        //User GetSingleUser(string user);

        //User GetSingleUser(Int64 key);

    }
}