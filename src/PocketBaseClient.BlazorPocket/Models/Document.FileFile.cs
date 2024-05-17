
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
using PocketBaseClient.Orm.Structures;

namespace PocketBaseClient.BlazorPocket.Models
{
    public partial class Document
    {
        public class FileFile : FieldFileBase
        {

            /// <inheritdoc />
            public override long? MaxSize => 5242880;

            public FileFile() : base("file", owner: null) { }

            public FileFile(Document? document) : base("file", document) { }

        }
    }
}
