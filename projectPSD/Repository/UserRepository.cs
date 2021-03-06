﻿using ProjectPSD.Factory;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class UserRepository
    {
        private static DatabaseEnt db = new DatabaseEnt();

        public static void insertNewUser(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static List<Users> getUsers()
        {
            return (from i in db.Users
                    select i).ToList();
        }

        public Users getLoginUser(String email, String pass)
        {
            Users targetUser = db.Users.Where(i => i.Email.Equals(email) && i.Password.Equals(pass)).FirstOrDefault();
            return (targetUser);
        }

        public static void toggleRole(int id)
        {
            Users u = db.Users.Where(i => i.ID.Equals(id)).FirstOrDefault();

            if(u == null)
            {
                return;
            }
            else
            {
                if (u.RoleID.Equals(2))
                {
                    u.RoleID = 1;
                    db.SaveChanges();
                }
                else
                {
                    u.RoleID = 2;
                    db.SaveChanges();
                }
            }
        }

        public static void toggleStatus(int id)
        {
            Users u = db.Users.Where(i => i.ID.Equals(id)).FirstOrDefault();

            if (u == null)
            {
                return;
            }
            else
            {
                if (u.Status.Equals("Active"))
                {
                    u.Status = "Blocked";
                    db.SaveChanges();
                }
                else
                {
                    u.Status = "Active";
                    db.SaveChanges();
                }
            }
        }

        public static void updateUsers(int id, Dictionary<String, String> updateInputs)
        {
            Users u = (from i in db.Users
                          where i.ID == id
                          select i).FirstOrDefault();
            u.Email = updateInputs["email"];
            u.Name = updateInputs["name"];
            u.Gender = updateInputs["gender"];
            db.SaveChanges();
        }

        public static void updatePass(int id, String newPassword)
        {
            Users u = (from i in db.Users
                       where i.ID == id
                       select i).FirstOrDefault();
            u.Password = newPassword;
            db.SaveChanges();
        }

        public String getPassById(int id)
        {
            Users targetUser = db.Users.Where(i => i.ID.Equals(id)).FirstOrDefault();
            String tempPass = targetUser.Password;
            return (tempPass);
        }
    }
}