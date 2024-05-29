using api.Interfaces.MQSocial;

namespace api.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
