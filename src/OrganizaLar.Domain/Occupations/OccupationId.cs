using GeneralDomain.Entities;

namespace OrganizaLar.Domain.Occupations;

public record OccupationId : Id<Guid>
{
    private OccupationId(Guid value) : base(value) { }

    public static OccupationId CreateFrom(Guid value) =>
        new(value);

    public static OccupationId CreateNew() =>
        new(Guid.NewGuid());
}
