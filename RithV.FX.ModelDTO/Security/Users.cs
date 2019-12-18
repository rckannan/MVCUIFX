using System;
using System.ComponentModel.DataAnnotations;

namespace RithV.FX.EntityDTO.Security
{
    public class Users : IDtoObjectModel
    {
        [Key]
        public virtual Int64 Key { get; set; }
        [Required(ErrorMessage = "User name should not be empty")]
        [StringLength(250, ErrorMessage = "User name is too long to accept")]
        [Display(Name = "User Name")]
        public virtual string fldUserName { get; set; }
        public virtual string fldPassword { get; set; }

        [Required(ErrorMessage = "Full User name should not be empty")]
        [StringLength(250, ErrorMessage = "Full User name is too long to accept")]
        [Display(Name = "Full User Name")]
        public virtual string fldFullUserName { get; set; }
        public virtual int fldFailedAttempt { get; set; }

        [Required(ErrorMessage = "Email should not be empty")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public virtual string fldEmailAddress { get; set; }

        [Display(Name = "Active")]
        public virtual bool fldActiveUser { get; set; } = true;
        public virtual bool fldForceChangePassword { get; set; }
        public virtual DateTime fldPasswordLastUpdated { get; set; }
        //public virtual DateTime fldLastUpdated { get; set; } 
    }

    public class LoginModel
    {
        [Display(Name = "User name"), Required]
        public string UserName
        {
            get;
            set;
        }
        [DataType(DataType.Password), Display(Name = "Password"), Required]
        public string Password
        {
            get;
            set;
        }
        [Display(Name = "Remember me?")]
        public bool RememberMe
        {
            get;
            set;
        }
    }

    public class LoginModelWoPass
    {
        [Display(Name = "User name"), Required]
        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

    }

    public class Token
    {
        public Token(string userId, string fromIp, string dt)
        {
            UserId = userId;
            IP = fromIp;
            dateTime = dt;
        }

        public Token(string userId, string fromIp)
        {
            UserId = userId;
            IP = fromIp;
            dateTime = DateTime.Now.ToString("ddMMMyyyhhmmss");
        }

        private string UserId { get; set; }
        private string IP { get; set; }
        private string dateTime { get; set; }

        public string Encrypt()
        {
            return Encryption64.EncryptToBase64String(this.ToString());
        }

        public override string ToString()
        {
            return String.Format("Id~{0}^IP~{1}^Dt~{2}", this.UserId, this.IP, this.dateTime);
        }

        public static Token Decrypt(string encryptedToken)
        {
            var decrypt = Encryption64.DecryptFromBase64String(encryptedToken);
            var splittedarray = decrypt.Split('^');
            string id = string.Empty;
            string ip = string.Empty;
            string dt = string.Empty;
            foreach (var itm in splittedarray)
            {
                if (itm.Substring(0, 2) == "Id")
                {
                    id = itm.Replace("Id~", "");
                }
                else if (itm.Substring(0, 2) == "IP")
                {
                    ip = itm.Replace("IP~", "");
                }
                else if (itm.Substring(0, 2) == "Dt")
                {
                    dt = itm.Replace("Dt~", "");
                }
            }
            return new Token(id, ip, dt);
        }
    }
}
