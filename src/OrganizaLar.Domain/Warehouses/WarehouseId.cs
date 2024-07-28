using GeneralDomain.Entities;

namespace OrganizaLar.Domain.Warehouses;

public record WarehouseId : Id<long>
{
    private WarehouseId(long value) : base(value) { }

    public static WarehouseId CreateFrom(long value) =>
        new(value);

    public static WarehouseId CreateNew() =>
        new(default(long));
}
