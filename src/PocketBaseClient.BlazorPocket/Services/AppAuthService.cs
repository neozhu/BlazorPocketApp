
// This file was generated automatically for the PocketBase Application Acme (http://localhost:8090)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient;
using PocketBaseClient.Services;
using PocketBaseClient.Orm;
using PocketBaseClient.BlazorPocket.Models;

namespace PocketBaseClient.BlazorPocket.Services
{
    public partial class AppAuthService : AuthServiceBase
    {
        #region Auth Collections
        /// <summary> Auth for Collection 'users' in PocketBase </summary>
        public AuthCollectionService<User> User => (AppDataService.GetCollection<User>() as CollectionAuthBase<User>)!.Auth;
        #endregion Auth Collections

        #region Constructor
        public AppAuthService(PocketBaseClientApplication app) : base(app) { }
        #endregion Constructor
    }
}
