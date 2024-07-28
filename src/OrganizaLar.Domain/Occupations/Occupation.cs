using CSharpFunctionalExtensions;
using GeneralDomain.Entities;
using OrganizaLar.Domain.Locations;
using OrganizaLar.Domain.Materials;

namespace OrganizaLar.Domain.Occupations;

public sealed class Occupation : Entity<OccupationId, Guid>
{
    public Material Material { get; }
    public Location Location { get; }

    private Occupation(OccupationId id, Material material, Location location) : base(id) =>
        (Material, Location) = (material, location);

    public static Result<Occupation> Create(Material material, Location location) =>
        Result.Success(new Occupation(OccupationId.CreateNew(),
                                      material,
                                      location));
}
