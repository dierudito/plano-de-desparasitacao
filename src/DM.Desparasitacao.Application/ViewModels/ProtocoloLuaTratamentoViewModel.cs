using System.Collections.Generic;
using System.Web.Mvc;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class ProtocoloLuaTratamentoViewModel
    {
        public ProtocoloLuaViewModel ProtocoloLua { get; set; }
        public TratamentoDoDiaDoProtocoloDaLuaViewModel DiaDoProtocolo { get; set; }
        public IList<TratamentoDoDiaDoProtocoloDaLuaViewModel> DiasDoProtocolo { get; set; }
        public SelectList RemediosSelectList { get; set; }
        public void InstanciaSelectListsRemedio(IList<RemedioViewModel> remedios)
        {
            RemediosSelectList = new SelectList(remedios, "Id", "Nome", 
                DiaDoProtocolo.RemedioParaAdministrar.Remedio != null ? DiaDoProtocolo.RemedioParaAdministrar.Remedio.Nome : null);
        }
    }
}