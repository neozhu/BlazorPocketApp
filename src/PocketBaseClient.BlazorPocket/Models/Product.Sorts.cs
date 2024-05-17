
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
    public partial class Product
    {
        public class Sorts : ItemBaseSorts
        {

            /// <summary>Makes a SortCommand to Order by the 'name' field</summary>
            public SortCommand Name => new SortCommand("name");

            /// <summary>Makes a SortCommand to Order by the 'spec' field</summary>
            public SortCommand Spec => new SortCommand("spec");

            /// <summary>Makes a SortCommand to Order by the 'description' field</summary>
            public SortCommand Description => new SortCommand("description");

            /// <summary>Makes a SortCommand to Order by the 'unit' field</summary>
            public SortCommand Unit => new SortCommand("unit");

            /// <summary>Makes a SortCommand to Order by the 'price' field</summary>
            public SortCommand Price => new SortCommand("price");

            /// <summary>Makes a SortCommand to Order by the 'currency' field</summary>
            public SortCommand Currency => new SortCommand("currency");


        }
    }
}
