namespace RithV.FX.Entity
{
    public class UserMapper : VersionedClassMap<tblUser>
    {
        public UserMapper()
        {
            Table("main.tblUser");
            Id(x => x.Key, "fldUser_ID");
            Map(x => x.fldUserName, "fldUserName").Not.Nullable();
            Map(x => x.fldPassword, "fldPassword").Not.Nullable();
            Map(x => x.fldFullUserName, "fldFullUserName").Not.Nullable();
            Map(x => x.fldFailedAttempt, "fldFailedAttempt").Not.Nullable();
            Map(x => x.fldEmailAddress, "fldEmailAddress").Not.Nullable();
            Map(x => x.fldActiveUser, "fldActiveUser").Not.Nullable();
            Map(x => x.fldUserType, "fldUserType").Not.Nullable();
            Map(x => x.fldForceChangePassword, "fldForceChangePassword").Not.Nullable();
            Map(x => x.fldPasswordLastUpdated, "fldPasswordLastUpdated").Not.Nullable();
            //Map(x => x.fldLastUpdated, "fldLastUpdated").Not.Nullable();
        }
    }
}