using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Opg1_cases
{
    internal class Account
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool createUser(string username, string pass)
        {

            User user = new User(username, pass, null);
            if (PassStrong(user) && !UserNameExist(user))
            {
                SaveUser(user);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool Login(string username, string pass)
        {
            List<User> users = GetUsersFromFile();
            foreach (User user in users) {
            
                if (username == user.UserName && pass == user.Password) return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public User? GetUser(string username, string pass)
        {
            List<User> users = GetUsersFromFile();
            foreach (User user in users)
            {

                if (username == user.UserName && pass == user.Password) return user;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool PassStrong(User user)
        {
            string pass = user.Password;
            if (pass.Length < 12) return false;
            if (char.IsDigit(pass[0])) return false;
            if (char.IsDigit(pass[pass.Length-1])) return false;
            if (pass.Contains(" ")) return false;
            if (user.UserName.ToLower() == pass.ToLower()) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newUser"></param>
        public void UpdateUserInFile(User user, User newUser)
        {
            List<User> users = GetUsersFromFile();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName == newUser.UserName)
                {
                    users.RemoveAt(i);
                }
                
            }

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(@"C:\Users\hjalet\Desktop\data.json", json);

            SaveUser(newUser); 

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public bool PassUsedBefore(User user, string newPass)
        {
            foreach(string k in user.UsedPassword)
            {
                if(k.ToLower() == newPass.ToLower()) return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void SaveUser(User user) 
        {
            List<User> users = GetUsersFromFile();
            users.Add(user);

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(@"C:\Users\hjalet\Desktop\data.json", json);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UserNameExist(User user)
        {
            string path = @"C:\Users\hjalet\Desktop\data.json";
            List<User> users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));

            foreach (User k in users)
            {
                if (k.UserName.ToLower() == user.UserName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUsersFromFile()
        {
            string json = File.ReadAllText(@"C:\Users\hjalet\Desktop\data.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }

    }


}

