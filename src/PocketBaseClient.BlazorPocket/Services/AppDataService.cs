
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
using PocketBaseClient.BlazorPocket.Models;

namespace PocketBaseClient.BlazorPocket.Services
{
    public partial class AppDataService : DataServiceBase
    {
        #region Collections
        /// <summary> Collection 'users' in PocketBase </summary>
        public CollectionUsers UsersCollection { get; }
        /// <summary> Collection 'products' in PocketBase </summary>
        public CollectionProducts ProductsCollection { get; }
        /// <summary> Collection 'documents' in PocketBase </summary>
        public CollectionDocuments DocumentsCollection { get; }

        /// <inheritdoc />
        protected override void RegisterCollections()
        {
            RegisterCollection(typeof(PocketBaseClient.BlazorPocket.Models.User), UsersCollection);
            RegisterCollection(typeof(PocketBaseClient.BlazorPocket.Models.Product), ProductsCollection);
            RegisterCollection(typeof(PocketBaseClient.BlazorPocket.Models.Document), DocumentsCollection);
        }
        #endregion Collections

        #region Constructor
        public AppDataService(PocketBaseClientApplication app) : base(app)
        {
            // Collections
            UsersCollection = new CollectionUsers(this);
            ProductsCollection = new CollectionProducts(this);
            DocumentsCollection = new CollectionDocuments(this);

            RegisterCollections();
        }
        #endregion Constructor
    }
}
