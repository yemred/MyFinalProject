using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{

    // Hangi Kullanıcının Hangi Calim'e sahip olduğunu gösteren tablo. ( Hangi Kullanıcının hangi yetkileri var )
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
