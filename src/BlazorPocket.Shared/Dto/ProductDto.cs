using BlazorPocket.Shared.Resources;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static PocketBaseClient.BlazorPocket.Models.Product;

namespace BlazorPocket.Shared.Dto
{
    public class ProductDto
    {
        #region Field Properties
        public string? Id { get; set; }
        [Display(Name = nameof(SharedResources.Created), ResourceType = typeof(SharedResources))]
        public DateTime? Created { get; set; }
        [Display(Name = nameof(SharedResources.Updated), ResourceType = typeof(SharedResources))]
        public DateTime? Updated { get; set; }
        [Display(Name = nameof(SharedResources.ProductName), ResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.ProductNameRequired))]
        [MaxLength(100, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.ProductNameMaxLength))]
        public string? Name { get; set; }

        [Display(Name = nameof(SharedResources.Spec), ResourceType = typeof(SharedResources))]
        [MaxLength(20, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.SpecMaxLength))]
        public string? Spec { get; set; }

        [Display(Name = nameof(SharedResources.Description), ResourceType = typeof(SharedResources))]
        [MaxLength(500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.DescriptionMaxLength))]
        public string? Description { get; set; }

        [Display(Name = nameof(SharedResources.Unit), ResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.UnitRequired))]
        public UnitEnum Unit { get; set; }

        [Display(Name = nameof(SharedResources.Price), ResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.PriceRequired))]
        [Range(0, double.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.PriceRange))]
        public float? Price { get; set; }

        [Display(Name = nameof(SharedResources.Currency), ResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.CurrencyRequired))]
        public CurrencyEnum? Currency { get; set; }

        #endregion Field Properties
    }
}
