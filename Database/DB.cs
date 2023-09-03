using LiteDB;
using Models;

namespace Database
{
    public partial class DB
    {
        public static LiteDatabase D;
        public static ILiteCollection<User> Users;
        public static ILiteCollection<Pack> Packs;

        public static void Initialize(string file, string password, bool shared = true)
        {
            string dbInit = $"Filename={file}";

            if (password != "") dbInit += $";Password={password}";
            if (shared) dbInit += $";connection=shared";

            D = new LiteDatabase(dbInit);

            Users = D.GetCollection<User>("users");
            Packs = D.GetCollection<Pack>("packs");

            Logger.DebugLog($"Database {dbInit} initialized");
        }

        public static long Now()
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}