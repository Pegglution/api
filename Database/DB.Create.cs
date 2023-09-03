using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Database
{
    public partial class DB
    {
        public static bool CreateUser(string username, string password)
        {
            try
            {
                if (GetUser(GetMethod.Username, username) == null)
                {
                    User user = new User()
                    {
                        guid = NewGuid(),
                        username = username,
                        password = Security.Encrypt(password),
                        creation = Now(),
                        tokens = new List<Token>()
                    };

                    Users.Insert(user);
                    Users.EnsureIndex(x => x.id);

                    Logger.DebugLog($"New user \"{user.username}\" ({user.guid}) created");

                    return true;
                }

                Logger.DebugLog($"Unable to create user \"{username}\" (User already exists)");

                return false;
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ex.Message);

                return false;
            }
        }

        public static bool CreatePack(User user, string title, string description)
        {
            try
            {
                Pack pack = new Pack()
                {
                    guid = NewGuid(),
                    owner = user.guid,
                    title = title,
                    description = description,
                    creation = Now(),
                    updated = 0,
                    stats = new(),
                };

                Packs.Insert(pack);
                Packs.EnsureIndex(x => x.id);

                Logger.DebugLog($"New pack created ({pack.title})");

                return true;
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ex.Message);

                return false;
            }
        }

        public static bool CreateToken(User user, long expiration)
        {
            try
            {
                Token token = new()
                {
                    value = NewGuid(),
                    creation = Now(),
                    expiration = expiration
                };

                user.tokens.Add(token);

                Users.Update(user);

                Logger.DebugLog($"New api token created for {user.username}");

                return true;
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ex.Message);

                return false;
            }
        }
    }
}
