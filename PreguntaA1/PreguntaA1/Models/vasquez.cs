using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PreguntaA1.Models
{

    public enum Places 
    {
        Requisito1 = 10,
        Requisito2 = 20,
        Requisito3 = 30,
        Requisito4 = 40,
        Requisito5 = 50
    }
    public class vasquez
    {   
        [Key]
        public int vasquezID { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, ErrorMessage ="no cumple con los minimos o maximos caracteres requeridos", MinimumLength = 2)]
        public string Friendofvasquez { get; set; }


        [Required]
        public Places Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = " {0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cumpleaños")]
        public DateTime Birthdate { get; set; }

    }
}