using System.Collections.Generic;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class ProtocoloLuaTratamentoViewModel
    {
        public ProtocoloLuaViewModel ProtocoloLua { get; set; }
        public FaseDaLuaViewModel FaseDaLua { get; set; }
        public IList<TratamentoDoDiaDoProtocoloDaLuaViewModel> DiasDoProtocolo { get; set; }
    }
}