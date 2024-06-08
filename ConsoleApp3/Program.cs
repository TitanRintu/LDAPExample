using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
             
            try
            {
                string ldapHost = "AlchemistStudio";
                //sdd it into app settings
                // integrate into app as discussed
                // create a desktop app MAUI or react JS ./ Web API/ 
                //Environment.Get
                int ldapPort = 389;
                string password = "password123";
                string loginDN = "uid=user.0,ou=People,dc=example,dc=com";
                //string searchBase = "ou=People";
                //string searchFilter = "objectClass=inetOrgPerson";
                try
                {
                    LdapConnection connection = new LdapConnection();
                    Console.WriteLine("Connecting to {0}",ldapHost);
                    connection.Connect(ldapHost,ldapPort);
                    connection.Bind(loginDN, password);
                    //Console.WriteLine(GetEmailAddressFromActiveDirectoryUserName("theal"));
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        public static string GetEmailAddressFromActiveDirectoryUserName(string adUserName)
        {
            string email = string.Empty;
            if (!string.IsNullOrEmpty(adUserName))
            {
                using (var pctx = new PrincipalContext(ContextType.Domain))
                {
                    using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, IdentityType.UserPrincipalName, "theal"))
                    {
                        return !string.IsNullOrEmpty(up?.EmailAddress) ? up.EmailAddress : string.Empty;
                    }
                }
            }
            return email;
        }
    }
}
