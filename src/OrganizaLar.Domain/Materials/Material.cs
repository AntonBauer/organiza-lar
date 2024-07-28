using CSharpFunctionalExtensions;
using GeneralDomain.Entities;
using GeneralDomain.UtilityTypes;

namespace OrganizaLar.Domain.Materials;

public sealed class Material : Entity<MaterialId, long>
{
    public NonEmptyString Name { get; }
    public string Description { get; }

    private Material(MaterialId id, NonEmptyString name, string description) : base(id) =>
        (Name, Description) = (name, description);

    public static Result<Material> Create(string name, string? description) =>
        NonEmptyString.Create(name)
                      .Map(validatedName => new Material(MaterialId.CreateNew(),
                                                         validatedName,
                                                         description ?? string.Empty));
}
