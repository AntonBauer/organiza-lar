using GeneralDomain.Entities;

namespace OrganizaLar.Domain.Locations;

public record LocationId : Id<long>
{
    private LocationId(long value) : base(value) { }

    public static LocationId CreateFrom(long value) =>
        new(value);

    public static LocationId CreateNew() =>
        new(default(long));
}
