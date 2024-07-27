using CSharpFunctionalExtensions;
using GeneralDomain.UtilityTypes;

namespace OrganizaLar.Domain.Locations;

public sealed class Location
{
    public LocationId Id { get; }
    public NonEmptyString Name { get; }
    public string Description { get; }

    private Location(LocationId id, NonEmptyString name, string description) =>
        (Id, Name, Description) = (id, name, description);

    public static Result<Location> Create(string name, string? description) =>
        NonEmptyString.Create(name)
                      .Map(validatedName => new Location(LocationId.CreateNew(),
                                                         validatedName,
                                                         description ?? string.Empty));
}
