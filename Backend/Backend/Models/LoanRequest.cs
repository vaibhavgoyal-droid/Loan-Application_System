using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class LoanRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int loanrequestId { get; set; }
        public int loanAmount { get; set; }

        public int loanTenure { get; set; }

        public int salary { get; set; }

        public string propertyAddress { get; set; }

        public int userId { get; set; }

        public string status { get; set; }
    }
}
