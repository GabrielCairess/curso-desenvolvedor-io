using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MInhaDemoMvc.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength(maximumLength: 60, MinimumLength = 3, ErrorMessage = "O Título precisa ter entre 3 e 60 caracteres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Data de Lançamento é obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage = "Gênero em formato inválido.")]
        [Display(Name = "Gênero")]
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "O Gênero deve ter entre 3 e 60 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        [Range(minimum: 1, maximum: 1000, ErrorMessage = "O valor deve ser de 1,00 a 1000,00")]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo avaiação é obrigatório.")]
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Somente números")]
        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }
    }
}
