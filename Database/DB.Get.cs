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
        public enum GetMethod
        {
            Username, //Used for users
            Title, //Used for packs
            GUID, //Universal
            ID, //Universal
        }

        public static User? GetUser(GetMethod method, string input)
        {
            List<User> tempUsers = null;

            switch (method)
            {
                case GetMethod.Username:
                case GetMethod.Title:
                    tempUsers = Users.Query().Where(x => x.username == input.ToLower()).ToList();
                    if (tempUsers.Count == 1) return tempUsers[0];
                    return null;

                case GetMethod.GUID:
                    tempUsers = Users.Query().Where(x => x.guid == input.ToLower()).ToList();
                    if (tempUsers.Count == 1) return tempUsers[0];
                    return null;
            }

            return null;
        }

        public static Pack? GetPack(GetMethod method, string input)
        {
            List<Pack> tempPacks = null;

            switch (method)
            {
                case GetMethod.Title:
                case GetMethod.Username:
                    tempPacks = Packs.Query().Where(x => x.title == input.ToLower()).ToList();
                    if (tempPacks.Count == 1) return tempPacks[0];
                    return null;

                case GetMethod.GUID:
                    tempPacks = Packs.Query().Where(x => x.guid == input.ToLower()).ToList();
                    if (tempPacks.Count == 1) return tempPacks[0];
                    return null;

                case GetMethod.ID:

                    if (!int.TryParse(input, out int id)) return null;
                    tempPacks = Packs.Query().Where(x => x.id == id).ToList();
                    if (tempPacks.Count == 1) return tempPacks[0];
                    return null;
            }

            return null;
        }

        public static List<Pack> GetPacks(string query)
        {
            var packs = Packs.Query().Where(x => x.title.ToLower().Contains(query.ToLower())).ToList();

            if (packs.Count == 0) return null;
            return packs;
        }
    }
}
