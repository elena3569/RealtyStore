using realtyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace realtyStore.Providers
{
    public class CuctomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (RealtyContext db = new RealtyContext())
            {
                myUser user = db.Users.FirstOrDefault(u => u.LogIn == username);
                if (user != null && user.RoleId != null)
                {
                    Role role = db.Roles.Find(user.RoleId);
                    if (role != null)
                    {
                        roles = new string[] { role.Name };
                    }
                }
                return roles;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (RealtyContext db = new RealtyContext())
            {
                myUser user = db.Users.FirstOrDefault(u => u.LogIn == username);

                if (user != null && user.RoleId != null)
                {
                    Role role = db.Roles.Find(user.RoleId);
                    if (role != null && role.Name == roleName)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}