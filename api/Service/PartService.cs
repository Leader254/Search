using api.Context;
using api.Models;
using api.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.Service
{
    public class PartService : IPartInterface
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PartService> _logger;

        public PartService(AppDbContext context, ILogger<PartService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<PartDTO>> GetAllPartsAsync()
        {
            try
            {
                var parts = await _context.PartsSerial.Select(x => new PartDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartNum = x.PartNum,
                    Company = x.Company,
                    PartDescription = x.PartDescription,
                    SerialNumber = x.SerialNumber,
                    SNStatus = x.SNStatus,
                    CustID = x.CustID
                }).ToListAsync();

                _logger.LogInformation("Retrieved all parts successfully.");
                return parts;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occured while trying to get the parts", ex);
            }
        }

        public async Task<IEnumerable<PartDTO>> GetPartBySerialNumberAsync(string serialNo)
        {
            try
            {
                List<PartDTO> parts;

                // .AnyAsync => Asynchronously determines whether any element of a sequence satisfies a condition.
                var isPartialMatch = await _context.PartsSerial
                    .AnyAsync(p => p.SerialNumber.StartsWith(serialNo) && p.SerialNumber.Length != serialNo.Length);

                if (isPartialMatch)
                {
                    parts = await _context.PartsSerial
                        .Where(p => p.SerialNumber.StartsWith(serialNo))
                        .Select(p => new PartDTO
                        {
                            Id = p.Id,
                            Name = p.Name,
                            PartNum = p.PartNum,
                            Company = p.Company,
                            PartDescription = p.PartDescription,
                            SerialNumber = p.SerialNumber,
                            SNStatus = p.SNStatus,
                            CustID = p.CustID
                        })
                        .ToListAsync();

                    if (!parts.Any())
                    {
                        _logger.LogWarning("No parts found with serial number starting with {SerialNo}.", serialNo);
                        throw new KeyNotFoundException($"No parts found with serial number starting with {serialNo}.");
                    }
                }
                else
                {
                    var part = await _context.PartsSerial
                        .Where(p => p.SerialNumber == serialNo)
                        .Select(p => new PartDTO
                        {
                            Id = p.Id,
                            Name = p.Name,
                            PartNum = p.PartNum,
                            Company = p.Company,
                            PartDescription = p.PartDescription,
                            SerialNumber = p.SerialNumber,
                            SNStatus = p.SNStatus,
                            CustID = p.CustID
                        })
                        .FirstOrDefaultAsync();

                    if (part == null)
                    {
                        _logger.LogWarning("Part with serial number {SerialNo} not found.", serialNo);
                        throw new KeyNotFoundException($"Part with serial number {serialNo} not found.");
                    }

                    parts = new List<PartDTO> { part };
                }

                _logger.LogInformation("Retrieved parts with serial number {SerialNo} successfully.", serialNo);
                return parts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the part by serial number.");
                throw new ApplicationException("An error occurred while getting the part by serial number.", ex);
            }
        }

    }
}
