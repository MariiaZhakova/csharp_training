using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allEmails;
        private string allPhones;
        private string infoFromEditForm;

        public ContactData(string firstname)
        {
            Firstname = firstname;

        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;

        }

        public ContactData()
        {
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname and lastname = " + Firstname + " " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if(Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
        public string Middlename { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        [JsonIgnore]
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }


        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

            return Regex.Replace(phone, "[- ()]", "") + "\r\n";
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Replace(" ", "") + "\r\n";
        }

        [JsonIgnore]
        public string EditFormInToString
        {
            get
            {
                if (infoFromEditForm != null)
                {
                    return infoFromEditForm;
                }
                else
                {
                    infoFromEditForm = "";

                    if (Firstname != "")
                    { infoFromEditForm = infoFromEditForm + Firstname; }


                    if (Lastname != "")
                    {
                        if (infoFromEditForm == "")
                        {
                            infoFromEditForm = Lastname;
                        }
                        else
                        {
                            infoFromEditForm = infoFromEditForm + " " + Lastname;
                        }
                    }

                    if (Address != "")
                    {
                        if (infoFromEditForm == "")
                        {
                            infoFromEditForm = Address;
                        }
                        else
                        {
                            infoFromEditForm = infoFromEditForm + "\r\n" + Address;
                        }
                    }


                    if ((infoFromEditForm != "") && (HomePhone != "" || MobilePhone != "" || WorkPhone != ""))
                    {
                        infoFromEditForm = infoFromEditForm + "\r\n";
                    }

                    if (HomePhone != "")
                    {
                        if (infoFromEditForm == "")
                        {
                            infoFromEditForm = "H: " + HomePhone;
                        }
                        else
                        {
                            infoFromEditForm = infoFromEditForm + "\r\nH: " + HomePhone;
                        }
                    }

                    if (MobilePhone != "")
                    {
                        if (infoFromEditForm == "")
                        {
                            infoFromEditForm = "M: " + MobilePhone;
                        }
                        else
                        {
                            infoFromEditForm = infoFromEditForm + "\r\nM: " + MobilePhone;
                        }
                    }

                    if (WorkPhone != "")
                    {
                        if (infoFromEditForm == "")
                        {
                            infoFromEditForm = "W: " + WorkPhone;
                        }
                        else
                        {
                            infoFromEditForm = infoFromEditForm + "\r\nW: " + WorkPhone;
                        }
                    }

                    if ((infoFromEditForm != "") && (Email != "" || Email2 != "" || Email3 != ""))
                    {
                        infoFromEditForm = infoFromEditForm + "\r\n";
                    }

                    if (Email != "")
                    {
                        if (infoFromEditForm == "")
                        {
                            infoFromEditForm = Email;
                        }
                        else
                        {
                            infoFromEditForm = infoFromEditForm + "\r\n" + Email;
                        }
                    }

                    if (Email2 != "")
                    {
                        if (infoFromEditForm == "")
                        {
                            infoFromEditForm = Email2;
                        }
                        else
                        {
                            infoFromEditForm = infoFromEditForm + "\r\n" + Email2;
                        }
                    }

                    if (Email3 != "")
                    {
                        if (infoFromEditForm == "")
                        {
                            infoFromEditForm = Email3;
                        }
                        else
                        {
                            infoFromEditForm = infoFromEditForm + "\r\n" + Email3;
                        }
                    }

                    return infoFromEditForm;
                }
                }
            set
            {
               
            }
        }
       
        public string Fax { get; set; }
        public string Homepage { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }

    }
}