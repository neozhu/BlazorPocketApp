
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
using pocketbase_csharp_sdk.Models;
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
    public partial class User : ItemAuthBase
    {
        #region Collection
        private static CollectionBase? _Collection = null;
        /// <inheritdoc />
        [JsonIgnore]
        public override CollectionBase Collection => _Collection ??= DataServiceBase.GetCollection<User>()!;
        #endregion Collection

        #region Field Properties
        private string? _Name = null;
        /// <summary> Maps to 'name' field in PocketBase </summary>
        [JsonPropertyName("name")]
        [PocketBaseField(id: "users_name", name: "name", required: false, system: false, unique: false, type: "text")]
        [Display(Name = "Name")]
        public string? Name { get => Get(() => _Name); set => Set(value, ref _Name); }

        private AvatarFile? _Avatar = null;
        /// <summary> Maps to 'avatar' field in PocketBase </summary>
        [JsonPropertyName("avatar")]
        [PocketBaseField(id: "users_avatar", name: "avatar", required: false, system: false, unique: false, type: "file")]
        [Display(Name = "Avatar")]
        [JsonInclude]
        [MimeTypes("image/jpeg,image/png,image/svg+xml,image/gif,image/webp", ErrorMessage = "Only MIME Types accepted: 'image/jpeg,image/png,image/svg+xml,image/gif,image/webp'")]
        [JsonConverter(typeof(FileConverter<AvatarFile>))]
        public AvatarFile Avatar { get => Get(() => _Avatar ??= new AvatarFile(this)); private set => Set(value, ref _Avatar); }

        #endregion Field Properties

        /// <inheritdoc />
        public override void UpdateWith(ItemBase itemBase)
        {
            // Do not Update with this instance
            if (ReferenceEquals(this, itemBase)) return;

            base.UpdateWith(itemBase);

            if (itemBase is User item)
            {
                Name = item.Name;
                Avatar = item.Avatar;

            }
        }

        #region Constructors

        public User() : base()
        {
        }

        [JsonConstructor]
        public User(string? id, DateTime? created, DateTime? updated, MailAddress? email, bool? emailVisibility, string? username, bool? verified, string? name, AvatarFile @avatar)
            : base(id, name, created, updated, email, emailVisibility, username, verified)
        {
            this.Name = name;
            this.Avatar = @avatar;

            AddInternal(this);
        }
        #endregion

        /// <inheritdoc />
        protected override IEnumerable<FieldFileBase?> RelatedFiles 
            => base.RelatedFiles.Union(new List<FieldFileBase?>() { Avatar });

        #region Collection
        public static CollectionUsers GetCollection() 
            => (CollectionUsers)DataServiceBase.GetCollection<User>()!;
        #endregion Collection

        public static async Task<User?> GetByIdAsync(string id, bool reload = false)
            => await GetCollection().GetByIdAsync(id, reload);

        public static User? GetById(string id, bool reload = false)
            => GetCollection().GetById(id, reload);


        
    }
}
