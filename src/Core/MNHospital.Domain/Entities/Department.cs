
namespace MNHospital.Domain.Entities;

public class Department : BaseEntity, IEntity
{
    public Guid Id { get; set; }
    public string? Name{ get; set; }
}
