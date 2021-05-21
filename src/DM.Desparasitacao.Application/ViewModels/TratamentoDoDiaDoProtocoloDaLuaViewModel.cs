using System.Collections.Generic;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class TratamentoDoDiaDoProtocoloDaLuaViewModel
    {
        public DiaProtocoloLuaViewModel DiaProtocolo { get; set; }
        public RemedioParaAdministrarViewModel RemedioParaAdministrar { get; set; }
        public IList<RemedioParaAdministrarViewModel> RemediosParaAdministrar { get; set; }
    }
}