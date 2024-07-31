
using System.Collections.Immutable;
using CSharpFunctionalExtensions;
using GeneralDomain.Entities;
using GeneralDomain.UtilityTypes;
using OrganizaLar.Domain.Locations;
using OrganizaLar.Domain.Materials;
using OrganizaLar.Domain.Occupations;

namespace OrganizaLar.Domain.Warehouses;

public sealed class Warehouse : Entity<WarehouseId, long>
{
    public NonEmptyString Name { get; }
    public string Description { get; }

    public ImmutableHashSet<Material> KnownMaterials { get; }
    public ImmutableHashSet<Location> Locations { get; }

    public ImmutableHashSet<Occupation> Occupations { get; private set; }

    private Warehouse(WarehouseId id,
                      NonEmptyString name,
                      string description,
                      IEnumerable<Material> knownMaterials,
                      IEnumerable<Location> locations,
                      IEnumerable<Occupation> occupations) : base(id)
    {
        Name = name;
        Description = description;
        KnownMaterials = knownMaterials.ToImmutableHashSet();
        Locations = locations.ToImmutableHashSet();
        Occupations = occupations.ToImmutableHashSet();
    }

    public static Result<Warehouse> Create(string name, string? description) =>
        NonEmptyString.Create(name)
                      .Map(validatedName => new Warehouse(WarehouseId.CreateNew(),
                                                          validatedName,
                                                          description ?? string.Empty,
                                                          [],
                                                          [],
                                                          []));

    public Result<Occupation> Put(Material material, Location location)
    {
        var occupation = Occupation.Create(material, location)
            .Tap(created => Occupations = Occupations.Add(created));

        return occupation;
    }

    public Result<Occupation> Pick(Material material, Location location)
    {
        var occupation = Result.Try(() => Occupations.Single(occupation => occupation.Location == location && occupation.Material == material));
        return occupation;
    }
}
