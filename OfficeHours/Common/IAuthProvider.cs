using System.Threading.Tasks;

namespace OfficeHours.Common
{
    interface IAuthProvider
    {
        Task<string> GetUserAccessTokenAsync();
    }
}
