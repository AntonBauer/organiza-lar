using GeneralDomain.Entities;

namespace OrganizaLar.Domain.Locations;

public record LocationId : Id<Guid>
{
    private LocationId(Guid value) : base(value) { }

    public static LocationId CreateFrom(Guid value) =>
        new(value);

    public static LocationId CreateNew() =>
        new(Guid.NewGuid());
}
