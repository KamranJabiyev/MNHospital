namespace MNHospital.Domain.Entities;

public abstract class BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
