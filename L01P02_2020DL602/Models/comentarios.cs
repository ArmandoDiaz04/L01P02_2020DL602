using static L01P02_2020DL602.Models.usuarios;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L01P02_2020DL602.Models
{
    public class comentarios
    {
        
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int comentarioId { get; set; }

            [ForeignKey("Publicacion")]
            public int publicacionId { get; set; }

            public string comentario { get; set; }

            [ForeignKey("Usuario")]
            public int usuarioId { get; set; }
        }

    }

