using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSG.Service.Models
{

    public class Users
    {
        //ID primaria de la tabla Users Autoincremental
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "El campo FirstName es requerido"), MaxLength(50)]
        [Column(TypeName="varchar(50)")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El campo no puede contener números.")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El campo no puede contener números.")]
        public string SecundName { get; set; }

        [Required(ErrorMessage = "El campo FirstLastName es requerido"), MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El campo no puede contener números.")]
        public string FirstLastName { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El campo no puede contener números.")]
        public string SecundLastName { get; set; }

        [Required(ErrorMessage = "El campo BirthDate es requerido")]
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El campo Salary es requerido")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El campo debe ser mayor a 0")]
        public decimal Salary { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModificationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

    }
}
