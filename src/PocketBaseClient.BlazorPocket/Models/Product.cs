
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
    public partial class Product : ItemBase
    {
        #region Collection
        private static CollectionBase? _Collection = null;
        /// <inheritdoc />
        [JsonIgnore]
        public override CollectionBase Collection => _Collection ??= DataServiceBase.GetCollection<Product>()!;
        #endregion Collection

        #region Field Properties
        private string? _Name = null;
        /// <summary> Maps to 'name' field in PocketBase </summary>
        [JsonPropertyName("name")]
        [PocketBaseField(id: "xw8xxibu", name: "name", required: true, system: false, unique: false, type: "text")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = @"Name is required")]
        public string Name { get => Get(() => _Name ??= string.Empty); set => Set(value, ref _Name); }

        private string? _Spec = null;
        /// <summary> Maps to 'spec' field in PocketBase </summary>
        [JsonPropertyName("spec")]
        [PocketBaseField(id: "s9wzpvba", name: "spec", required: false, system: false, unique: false, type: "text")]
        [Display(Name = "Spec")]
        public string? Spec { get => Get(() => _Spec); set => Set(value, ref _Spec); }

        private string? _Description = null;
        /// <summary> Maps to 'description' field in PocketBase </summary>
        [JsonPropertyName("description")]
        [PocketBaseField(id: "reu8cecz", name: "description", required: false, system: false, unique: false, type: "text")]
        [Display(Name = "Description")]
        public string? Description { get => Get(() => _Description); set => Set(value, ref _Description); }

        private UnitEnum? _Unit = null;
        /// <summary> Maps to 'unit' field in PocketBase </summary>
        [JsonPropertyName("unit")]
        [PocketBaseField(id: "tv34msy1", name: "unit", required: true, system: false, unique: false, type: "select")]
        [Display(Name = "Unit")]
        [Required(ErrorMessage = @"Unit is required")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UnitEnum Unit { get => Get(() => _Unit ??= default); set => Set(value, ref _Unit); }

        private float? _Price = null;
        /// <summary> Maps to 'price' field in PocketBase </summary>
        [JsonPropertyName("price")]
        [PocketBaseField(id: "gieggpzi", name: "price", required: false, system: false, unique: false, type: "number")]
        [Display(Name = "Price")]
        public float? Price { get => Get(() => _Price); set => Set(value, ref _Price); }

        private CurrencyEnum? _Currency = null;
        /// <summary> Maps to 'currency' field in PocketBase </summary>
        [JsonPropertyName("currency")]
        [PocketBaseField(id: "pddjipx1", name: "currency", required: false, system: false, unique: false, type: "select")]
        [Display(Name = "Currency")]
        [JsonConverter(typeof(StringNullableEnumConverter<Nullable<CurrencyEnum>>))]
        public CurrencyEnum? Currency { get => Get(() => _Currency); set => Set(value, ref _Currency); }

        #endregion Field Properties

        /// <inheritdoc />
        public override void UpdateWith(ItemBase itemBase)
        {
            // Do not Update with this instance
            if (ReferenceEquals(this, itemBase)) return;

            base.UpdateWith(itemBase);

            if (itemBase is Product item)
            {
                Name = item.Name;
                Spec = item.Spec;
                Description = item.Description;
                Unit = item.Unit;
                Price = item.Price;
                Currency = item.Currency;

            }
        }

        #region Constructors

        public Product() : base()
        {
        }

        [JsonConstructor]
        public Product(string? id, DateTime? created, DateTime? updated, string @name, string? @spec, string? @description, UnitEnum @unit, float? @price, CurrencyEnum? @currency)
            : base(id, created, updated)
        {
            this.Name = @name;
            this.Spec = @spec;
            this.Description = @description;
            this.Unit = @unit;
            this.Price = @price;
            this.Currency = @currency;

            AddInternal(this);
        }
        #endregion

        #region Collection
        public static CollectionProducts GetCollection() 
            => (CollectionProducts)DataServiceBase.GetCollection<Product>()!;
        #endregion Collection

        public static async Task<Product?> GetByIdAsync(string id, bool reload = false)
            => await GetCollection().GetByIdAsync(id, reload);

        public static Product? GetById(string id, bool reload = false)
            => GetCollection().GetById(id, reload);
    }
}
