
// This file was generated automatically for the PocketBase Application Acme (http://localhost:8090)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient.Orm;
using PocketBaseClient.Orm.Filters;
using PocketBaseClient.Services;

namespace PocketBaseClient.BlazorPocket.Models
{
    public partial class CollectionDocuments : CollectionBase<Document>
    {
        /// <inheritdoc />
        public override string Id => "6prava2a3trini6";

        /// <inheritdoc />
        public override string Name => "documents";

        /// <inheritdoc />
        public override bool System => false;

        /// <summary> Contructor: The Collection 'documents' </summary>
        /// <param name="context">The DataService for the collection</param>
        internal CollectionDocuments(DataServiceBase context) : base(context) { }

        /// <summary> Query data at PocketBase, defining a Filter over collection 'documents' </summary>
        public CollectionQuery<CollectionDocuments, Document.Sorts, Document> Filter(Func<Document.Filters, FilterCommand> filter)
            => new CollectionQuery<CollectionDocuments, Document.Sorts, Document>(this, filter(new Document.Filters()));

        /// <summary> Query all data at PocketBase, over collection 'documents' </summary>
        public CollectionQuery<CollectionDocuments, Document.Sorts, Document> All()
            => new CollectionQuery<CollectionDocuments, Document.Sorts, Document>(this, null);

    }
}
