
// This file was generated automatically for the PocketBase Application Acme (http://localhost:8090)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient.Orm.Filters;

namespace PocketBaseClient.BlazorPocket.Models
{
    public partial class User
    {
        public class Filters : ItemAuthBaseFilters
        {

            /// <summary> Gets a Filter to Query data over the 'name' field in PocketBase </summary>
            public FieldFilterText Name => new FieldFilterText("name");

            /// <summary> Gets a Filter to Query data over the 'avatar' field in PocketBase </summary>
            public FieldFilterText Avatar => new FieldFilterText("avatar");


        }
    }
}
