using Database;

namespace Pegglution
{
    class Program
    {
        public static void Main( string[] args )
        {
            DB.Initialize("database.db", "pegglution");

            _ = new API();
        }
    }
}