
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
        public class Filters : ItemBaseFilters
        {

            /// <summary> Gets a Filter to Query data over the 'name' field in PocketBase </summary>
            public FieldFilterText Name => new FieldFilterText("name");

            /// <summary> Gets a Filter to Query data over the 'spec' field in PocketBase </summary>
            public FieldFilterText Spec => new FieldFilterText("spec");

            /// <summary> Gets a Filter to Query data over the 'description' field in PocketBase </summary>
            public FieldFilterText Description => new FieldFilterText("description");

            /// <summary> Gets a Filter to Query data over the 'unit' field in PocketBase </summary>
            public FieldFilterEnum<UnitEnum> Unit => new FieldFilterEnum<UnitEnum>("unit");

            /// <summary> Gets a Filter to Query data over the 'price' field in PocketBase </summary>
            public FieldFilterNumber Price => new FieldFilterNumber("price");

            /// <summary> Gets a Filter to Query data over the 'currency' field in PocketBase </summary>
            public FieldFilterEnum<CurrencyEnum> Currency => new FieldFilterEnum<CurrencyEnum>("currency");


        }
    }
}
