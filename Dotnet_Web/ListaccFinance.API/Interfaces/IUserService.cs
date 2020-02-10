using System.Threading.Tasks;
using ListaccFinance.API.Data.Model;
using ListaccFinance.API.ViewModels;

namespace ListaccFinance.API.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(RegisterModel reg);
    }
}