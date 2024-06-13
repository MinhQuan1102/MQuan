using api.Entities;
using System.Text.RegularExpressions;

namespace api.Interfaces.MQSocial
{
    public interface IGroupRepository
    {
        void CreateGroup(Group group);
        void AddUserToGroup(Group group, User user);
        void DeleteUserFromGroup(Group group, User user);

    }
}
