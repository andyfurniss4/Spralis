using Spralis.Web.Models;
using System.Threading.Tasks;

namespace Spralis.Web.Services
{
    public interface IAPIService
    {
        Task<string> Search(Search search);
        Task<Character> GetCharacterAsync(int characterID);
        Task<Corporation> GetCorporationAsync(int corporationId, bool getMembers = false);
    }
}
