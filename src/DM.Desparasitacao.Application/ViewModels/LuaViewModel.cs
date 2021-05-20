using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DM.Desparasitacao.Application.ViewModels
{
    public enum LuaViewModel : byte
    {
        [Description("Lua Cheia")] [Display(Name = "Lua Cheia")] Cheia = 1,
        [Description("Lua Minguante")] [Display(Name = "Lua Minguante")] Minguante,
        [Description("Lua Nova")] [Display(Name = "Lua Nova")] Nova,
        [Description("Lua Crescente")] [Display(Name = "Lua Crescente")] Crescente
    }
}