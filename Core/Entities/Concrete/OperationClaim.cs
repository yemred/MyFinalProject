using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    // Yetkileri Tutan tablomuz. Admin, Edidör gibi
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
