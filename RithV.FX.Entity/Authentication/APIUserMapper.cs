namespace RithV.FX.Entity.Authentication
{
    public class ApiUserMapper : VersionedClassMap<tblAPIUser>
    {
        public ApiUserMapper()
        {
            Table("main.tblAPIUser");
            Id(x => x.Key, "fldAPIUser_ID");
            Map(x => x.fldUserName, "fldUserName").Not.Nullable();
            Map(x => x.fldPassword, "fldPassword").Not.Nullable();
            Map(x => x.fldActiveUser, "fldActiveUser").Not.Nullable();
            Map(x => x.fldLastUpdatedOn, "fldLastUpdatedOn").Not.Nullable();
        }
    }
}