using GeneralDomain.Entities;

namespace OrganizaLar.Domain.Materials;

public record MaterialId : Id<Guid>
{
    private MaterialId(Guid value) : base(value) { }

    public static MaterialId CreateFrom(Guid value) =>
        new(value);

    public static MaterialId CreateNew() =>
        new(Guid.NewGuid());
}
