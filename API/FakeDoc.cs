namespace Pegglution
{
    //Fake documentation for the API
    public partial class API
    {
        /// <summary>
        /// Used to get something
        /// </summary>
        /// <param name="what">
        /// "pack", "user"
        /// </param>
        /// <param name="method">
        /// "id", "guid", "title", "username"
        /// </param>
        /// <param name="query">
        /// (id:int) "69", (guid:string) "41dac94f-8c70-42fb-a1ab-990c03579747", (title:string) "My Awesome Levels", (username:string) "CoolUser420"
        /// </param>
        /// <example>
        /// curl -X GET "/api/get/pack/id/1"
        /// </example>
        public static void get(string what, string method, string query) { }

        /// <summary>
        /// Post new pack data. Requires API token
        /// </summary>
        public static void post() { }
    }
}
