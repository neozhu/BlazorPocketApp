
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
    public partial class CollectionProducts : CollectionBase<Product>
    {
        /// <inheritdoc />
        public override string Id => "n0jrg4z0jcpicaj";

        /// <inheritdoc />
        public override string Name => "products";

        /// <inheritdoc />
        public override bool System => false;

        /// <summary> Contructor: The Collection 'products' </summary>
        /// <param name="context">The DataService for the collection</param>
        internal CollectionProducts(DataServiceBase context) : base(context) { }

        /// <summary> Query data at PocketBase, defining a Filter over collection 'products' </summary>
        public CollectionQuery<CollectionProducts, Product.Sorts, Product> Filter(Func<Product.Filters, FilterCommand> filter)
            => new CollectionQuery<CollectionProducts, Product.Sorts, Product>(this, filter(new Product.Filters()));

        /// <summary> Query all data at PocketBase, over collection 'products' </summary>
        public CollectionQuery<CollectionProducts, Product.Sorts, Product> All()
            => new CollectionQuery<CollectionProducts, Product.Sorts, Product>(this, null);

    }
}
