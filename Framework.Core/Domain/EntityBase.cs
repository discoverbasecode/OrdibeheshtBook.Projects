namespace Framework.Core.Domain;

public class EntityBase
{
    public long Id { get; protected set; }

    public string UserCreation { get; set; }
    public DateTime CreationDate { get; private set; } = DateTime.Now;

    public string UserUpdate { get; set; }
    public DateTime UpdateDate { get; set; }

    public string UserRemove { get; set; }
    public bool IsRemove { get; set; }
    public DateTime RemoveDate { get; set; }


}