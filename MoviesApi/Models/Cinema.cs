using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(70, ErrorMessage = "Name length must be up to 70 characters.")]
        public string Name { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Guid AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
