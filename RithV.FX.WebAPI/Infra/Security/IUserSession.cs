using System;
using System.Security.Claims;

namespace RithV.FX.WebAPI.Infra.Security
{
    public interface IUserSession
    {
        Guid UserId { get; }
        string UserName { get; }
        string Email { get; }
    }

    public class UserSession : IUserSession
    {
        public UserSession(ClaimsPrincipal claims)
        {
            UserId = Guid.Parse(claims.FindFirst(ClaimTypes.Sid).Value);
            UserName = claims.FindFirst(ClaimTypes.Name).Value;
            Email = claims.FindFirst(ClaimTypes.Email).Value;
        }

        public Guid UserId { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }
    }

    public class Status
    {
        public bool Successeded { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }

    //public class Token
    //{
    //    public Token(string userId, string fromIp, string dt)
    //    {
    //        UserId = userId;
    //        IP = fromIp;
    //        dateTime = dt;
    //    }

    //    public Token(string userId, string fromIp)
    //    {
    //        UserId = userId;
    //        IP = fromIp;
    //        dateTime = DateTime.Now.ToString("ddMMMyyyhhmmss");
    //    }

    //    private string UserId { get; set; }
    //    private string IP { get; set; }
    //    private string dateTime { get; set; }

    //    public string Encrypt()
    //    {
    //        return Encryption64.EncryptToBase64String(this.ToString());
    //    }

    //    public override string ToString()
    //    {
    //        return String.Format("Id~{0}^IP~{1}^Dt~{2}", this.UserId, this.IP, this.dateTime);
    //    }

    //    public static Token Decrypt(string encryptedToken)
    //    {
    //        var decrypt = Encryption64.DecryptFromBase64String(encryptedToken);
    //        var splittedarray = decrypt.Split('^');
    //        string id = string.Empty;
    //        string ip = string.Empty;
    //        string dt = string.Empty;
    //        foreach (var itm in splittedarray)
    //        {
    //            if (itm.Substring(0, 2) == "Id")
    //            {
    //                id = itm.Replace("Id~", "");
    //            }
    //            else if (itm.Substring(0, 2) == "IP")
    //            {
    //                ip = itm.Replace("IP~", "");
    //            }
    //            else if (itm.Substring(0, 2) == "Dt")
    //            {
    //                dt = itm.Replace("Dt~", "");
    //            }
    //        }
    //        return new Token(id, ip, dt);
    //    }
    //}

    //public class CryptographyHelper
    //{
    //    public X509Certificate2 GetX509Certificate(string subjectName)
    //    {
    //        var certificateStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    //        certificateStore.Open(OpenFlags.ReadOnly);
    //        X509Certificate2 certificate;

    //        try
    //        {
    //            certificate = certificateStore.Certificates.OfType<X509Certificate2>().
    //                                                            FirstOrDefault(cert => cert.SubjectName.Name.Equals(subjectName, StringComparison.OrdinalIgnoreCase));
    //        }
    //        finally
    //        {
    //            certificateStore.Close();
    //        }

    //        if (certificate == null)
    //            throw new Exception(String.Format("Certificate '{0}' not found.", subjectName));

    //        return certificate;
    //    }

    //    public string Encrypt(X509Certificate2 certificate, string plainToken)
    //    {
    //        var cryptoProvidor = (RSACryptoServiceProvider)certificate.PublicKey.Key;
    //        byte[] encryptedTokenBytes = cryptoProvidor.Encrypt(Encoding.UTF8.GetBytes(plainToken), true);
    //        return Convert.ToBase64String(encryptedTokenBytes);
    //    }

    //    public string Decrypt(X509Certificate2 certificate, string encryptedToken)
    //    {
    //        var cryptoProvidor = (RSACryptoServiceProvider)certificate.PrivateKey;
    //        byte[] decryptedTokenBytes = cryptoProvidor.Decrypt(Convert.FromBase64String(encryptedToken), true);

    //        return Encoding.UTF8.GetString(decryptedTokenBytes);
    //    }
    //}
}