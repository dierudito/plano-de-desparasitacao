using System.Collections.Generic;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class TratamentoDoDiaDoProtocoloDaLuaViewModel
    {
        public DiaProtocoloLuaViewModel DiaProtocolo { get; set; }
        public IList<RemedioParaAdministrarViewModel> RemedioParaAdministrar { get; set; }
    }
}