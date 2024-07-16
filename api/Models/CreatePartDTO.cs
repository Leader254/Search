using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class CreatePartDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PartNum { get; set; }
        public string Company { get; set; }
        public string SerialNumber { get; set; }
        public string SNStatus { get; set; }
        public string CustID { get; set; }
        public string PartDescription { get; set; }
    }
}
