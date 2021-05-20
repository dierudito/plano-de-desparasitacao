using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DM.Desparasitacao.Application.ViewModels
{
    public enum UnidadeViewModel : byte
    {
        [Description("Miligrama")] [Display(Name = "Miligrama")] Mg = 1,
        [Description("Comprimido")] [Display(Name = "Comprimidos")] Comprimido,
        [Description("Micrograma")] [Display(Name = "Micrograma")] Mcg,
        [Description("Colher de Sopa")] [Display(Name = "Colher de Sopa")] ColherSopa,
        [Description("Colher Rasa")] [Display(Name = "Colher Rasa")] ColherRasa,
        [Description("Gota")] [Display(Name = "Gota")] Gota,
        [Description("Xícara")] [Display(Name = "Xícara")] Xicara
    }
}