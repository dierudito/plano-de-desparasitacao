using System;
using System.ComponentModel.DataAnnotations;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class RemedioViewModel
    {
        public RemedioViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public UnidadeViewModel Unidade { get; set; }
    }
}