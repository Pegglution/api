using Database;
using Models;

namespace Pegglution
{
    public partial class API
    {
        private void Get(HttpRequest req, HttpResponse res, string method, string what, string query)
        {
            if (what != "pack" && what != "user")
            {
                res.WriteAsync(GenerateResponse(new Error("no what recognized")));
                return;
            }

            bool pack = what == "pack";
            DB.GetMethod getMethod = DB.GetMethod.ID;

            switch (method)
            {
                case "id":
                    getMethod = DB.GetMethod.ID;

                    if (!int.TryParse(query, out int id))
                    {
                        res.WriteAsync(GenerateResponse(new Error("id query was not a number")));
                        return;
                    }
                    break;

                case "guid":
                    getMethod = DB.GetMethod.GUID;
                    break;

                case "title":
                case "username":
                    if (pack) getMethod = DB.GetMethod.Title;
                    else getMethod = DB.GetMethod.Username;
                    break;

                default:
                    res.WriteAsync(GenerateResponse(new Error("no get method recognized")));
                    break;
            }

            if (pack)
            {
                if (getMethod == DB.GetMethod.Title)
                {
                    var result = DB.GetPacks(query);
                    if (result == null) res.WriteAsync(GenerateResponse(new Error("no results")));
                    else res.WriteAsync(GenerateResponse(result));
                }
                else
                {
                    var result = DB.GetPack(getMethod, query);
                    if (result == null) res.WriteAsync(GenerateResponse(new Error("no results")));
                    else res.WriteAsync(GenerateResponse(result));
                }
            }
            else
            {
                var result = DB.GetUser(getMethod, query);
                if (result == null) res.WriteAsync(GenerateResponse(new Error("no results")));
                else res.WriteAsync(GenerateResponse(result));
            }
        }
    }
}
