using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L01P02_2020DL602.Models
{
    public class usuarios
    {
       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int usuarioId { get; set; }

            [ForeignKey("Rol")]
            public int rolId { get; set; }

            [Required]
            [StringLength(50)]
            public string nombreUsuario { get; set; }

            [Required]
            [StringLength(50)]
            public string clave { get; set; }

            [Required]
            [StringLength(100)]
            public string Nombre { get; set; }

            [Required]
            [StringLength(100)]
            public string apellido { get; set; }
        }
    }











