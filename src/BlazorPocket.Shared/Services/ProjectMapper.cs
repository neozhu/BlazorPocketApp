using BlazorPocket.Shared.Dto;
using PocketBaseClient.BlazorPocket.Models;
using Riok.Mapperly.Abstractions;


namespace BlazorPocket.Shared.Services;

[Mapper]
public static partial class ProjectMapper
{
    public static partial ProductDto MapProduct(Product product);
    [MapperIgnoreSource(nameof(ProductDto.Id))]
    [MapperIgnoreSource(nameof(ProductDto.Created))]
    [MapperIgnoreSource(nameof(ProductDto.Updated))]
    public static partial Product MapProductDto(ProductDto productDto);
    [MapperIgnoreSource(nameof(ProductDto.Id))]
    [MapperIgnoreSource(nameof(ProductDto.Created))]
    [MapperIgnoreSource(nameof(ProductDto.Updated))]
    public static partial void ApplyUpdate(ProductDto productDto,Product product);
    public static partial IEnumerable<ProductDto> ProjectToDto(IEnumerable<Product> q);
}

