using ModelLayer.DTO.Request;
using ModelLayer.Entities;

namespace RepositaryLayer.Interface
{
    public interface IUserRL
    {
        public bool createUser(User entity);
        User login(string userEmail);
    }
}
