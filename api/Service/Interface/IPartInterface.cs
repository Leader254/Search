using api.Models;

namespace api.Service.Interface
{
    public interface IPartInterface
    {
        Task<IEnumerable<PartDTO>> GetAllPartsAsync();
        Task<IEnumerable<PartDTO>> GetPartBySerialNumberAsync(string serialNo);
    }
}
