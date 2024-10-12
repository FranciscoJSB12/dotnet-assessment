using dot_net_assessment.Models;

namespace dot_net_assessment.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
