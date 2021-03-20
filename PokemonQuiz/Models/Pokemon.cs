using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonQuiz.Models
{
    public class Pokemon
    {
        [Key]
        public int PokemonId { get; set; }

        [Required]
        [StringLength(14)]
        public string Name { get; set; }

        [StringLength(14)]
        public string EvolutionName { get; set; }

        [StringLength(20)]
        public string EvolutionMethod { get; set; }

        [Required]
        [StringLength(10)]
        public string Type1 { get; set; }

        [StringLength(10)]
        public string Type2 { get; set; }

        public virtual string DisplayName
        {
            get
            {
                return char.ToUpper(Name[0]) + Name.Substring(1);
            }
        }
    }
}
