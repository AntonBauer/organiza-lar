using GeneralDomain.Entities;

namespace OrganizaLar.Domain.Materials;

public record MaterialId : Id<long>
{
    private MaterialId(long value) : base(value) { }

    public static MaterialId CreateFrom(long value) =>
        new(value);

    public static MaterialId CreateNew() =>
        new(default(long));
}
