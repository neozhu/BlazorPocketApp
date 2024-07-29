using BlazorPocket.Shared.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorPocket.Shared.Dto;
/// <summary>
/// Represents the data transfer object for a product.
/// </summary>
public class ProductDto
{
    #region Field Properties

    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the product.
    /// </summary>
    [Display(Name = nameof(SharedResources.Created), ResourceType = typeof(SharedResources))]
    public DateTime? Created { get; set; }

    /// <summary>
    /// Gets or sets the last updated date of the product.
    /// </summary>
    [Display(Name = nameof(SharedResources.Updated), ResourceType = typeof(SharedResources))]
    public DateTime? Updated { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    [Display(Name = nameof(SharedResources.ProductName), ResourceType = typeof(SharedResources))]
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.ProductNameRequired))]
    [MaxLength(100, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.ProductNameMaxLength))]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the specification of the product.
    /// </summary>
    [Display(Name = nameof(SharedResources.Spec), ResourceType = typeof(SharedResources))]
    [MaxLength(20, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.SpecMaxLength))]
    public string? Spec { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    [Display(Name = nameof(SharedResources.Description), ResourceType = typeof(SharedResources))]
    [MaxLength(500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.DescriptionMaxLength))]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the unit of the product.
    /// </summary>
    [Display(Name = nameof(SharedResources.Unit), ResourceType = typeof(SharedResources))]
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.UnitRequired))]
    public UnitDto Unit { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    [Display(Name = nameof(SharedResources.Price), ResourceType = typeof(SharedResources))]
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.PriceRequired))]
    [Range(0, double.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.PriceRange))]
    public float? Price { get; set; }

    /// <summary>
    /// Gets or sets the currency of the product price.
    /// </summary>
    [Display(Name = nameof(SharedResources.Currency), ResourceType = typeof(SharedResources))]
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = nameof(SharedResources.CurrencyRequired))]
    public CurrencyDto? Currency { get; set; }

    #endregion Field Properties



    public enum CurrencyDto
    {
        [Description("USD")]
        USD,

        [Description("EUR")]
        EUR,

        [Description("CNY")]
        CNY,


    }

    public enum UnitDto
    {
        [Description("Packages")]
        Packages,

        [Description("Box")]
        Box,

        [Description("Pallet")]
        Pallet,

        [Description("Carton")]
        Carton,

        [Description("Drum")]
        Drum,


    }
}
