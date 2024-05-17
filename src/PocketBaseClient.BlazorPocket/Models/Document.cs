
// This file was generated automatically for the PocketBase Application Acme (http://localhost:8090)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using pocketbase_csharp_sdk.Json;
using PocketBaseClient.Orm;
using PocketBaseClient.Orm.Attributes;
using PocketBaseClient.Orm.Json;
using PocketBaseClient.Orm.Validators;
using PocketBaseClient.Services;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PocketBaseClient.BlazorPocket.Models
{
    public partial class Document : ItemBase
    {
        #region Collection
        private static CollectionBase? _Collection = null;
        /// <inheritdoc />
        [JsonIgnore]
        public override CollectionBase Collection => _Collection ??= DataServiceBase.GetCollection<Document>()!;
        #endregion Collection

        #region Field Properties
        private string? _Name = null;
        /// <summary> Maps to 'name' field in PocketBase </summary>
        [JsonPropertyName("name")]
        [PocketBaseField(id: "jj7clypc", name: "name", required: false, system: false, unique: false, type: "text")]
        [Display(Name = "Name")]
        public string? Name { get => Get(() => _Name); set => Set(value, ref _Name); }

        private FileFile? _File = null;
        /// <summary> Maps to 'file' field in PocketBase </summary>
        [JsonPropertyName("file")]
        [PocketBaseField(id: "3npbikro", name: "file", required: false, system: false, unique: false, type: "file")]
        [Display(Name = "File")]
        [JsonInclude]
        [JsonConverter(typeof(FileConverter<FileFile>))]
        public FileFile File { get => Get(() => _File ??= new FileFile(this)); private set => Set(value, ref _File); }

        private User? _Owner = null;
        /// <summary> Maps to 'owner' field in PocketBase </summary>
        [JsonPropertyName("owner")]
        [PocketBaseField(id: "xwejmhh8", name: "owner", required: false, system: false, unique: false, type: "relation")]
        [Display(Name = "Owner")]
        [JsonConverter(typeof(RelationConverter<User>))]
        public User? Owner { get => Get(() => _Owner); set => Set(value, ref _Owner); }

        #endregion Field Properties

        /// <inheritdoc />
        public override void UpdateWith(ItemBase itemBase)
        {
            // Do not Update with this instance
            if (ReferenceEquals(this, itemBase)) return;

            base.UpdateWith(itemBase);

            if (itemBase is Document item)
            {
                Name = item.Name;
                File = item.File;
                Owner = item.Owner;

            }
        }

        #region Constructors

        public Document() : base()
        {
        }

        [JsonConstructor]
        public Document(string? id, DateTime? created, DateTime? updated, string? @name, FileFile @file, User? @owner)
            : base(id, created, updated)
        {
            this.Name = @name;
            this.File = @file;
            this.Owner = @owner;

            AddInternal(this);
        }
        #endregion

        /// <inheritdoc />
        protected override IEnumerable<ItemBase?> RelatedItems 
            => base.RelatedItems.Union(new List<ItemBase?>() { Owner });

        /// <inheritdoc />
        protected override IEnumerable<FieldFileBase?> RelatedFiles 
            => base.RelatedFiles.Union(new List<FieldFileBase?>() { File });

        #region Collection
        public static CollectionDocuments GetCollection() 
            => (CollectionDocuments)DataServiceBase.GetCollection<Document>()!;
        #endregion Collection

        public static async Task<Document?> GetByIdAsync(string id, bool reload = false)
            => await GetCollection().GetByIdAsync(id, reload);

        public static Document? GetById(string id, bool reload = false)
            => GetCollection().GetById(id, reload);
    }
}
