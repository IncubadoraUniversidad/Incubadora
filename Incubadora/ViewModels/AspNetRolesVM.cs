using System.ComponentModel.DataAnnotations;

namespace Incubadora.ViewModels
{
    public class AspNetRolesVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}