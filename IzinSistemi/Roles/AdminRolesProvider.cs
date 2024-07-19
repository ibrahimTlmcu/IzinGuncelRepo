using IzinSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Security;

namespace IzinSistemi.Roles
{
    public class AdminRolesProvider : RoleProvider
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
            using (DBIzinTakipEntities db = new DBIzinTakipEntities())
            {
                var admin = db.Admin.FirstOrDefault(x => x.KullanıcıAdı == username);
                if (admin != null)
                {
                    return new string[] { admin.Yetki };
                }

                var personel = db.Personel.FirstOrDefault(x => x.KullanıcıAdı == username);
                if (personel != null)
                {
                    return new string[] { personel.Yetki };
                }

                // Kullanıcı adı ne Admin ne de Personel tablosunda bulunamazsa boş bir dizi döndürüyoruz.
                return new string[] { };
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
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