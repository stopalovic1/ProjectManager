using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Library.Tables
{
    [Table("ContractType")]
    public class ContractType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; }
    }
}
