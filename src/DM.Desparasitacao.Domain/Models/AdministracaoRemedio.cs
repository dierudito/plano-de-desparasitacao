using System;

namespace DM.Desparasitacao.Domain.Models
{
    public class AdministracaoRemedio : Entity
    {
        public Guid RemedioId { get; set; }
        public virtual Remedio Remedio { get; set; }
        public Horario Horario { get; set; }
        public Guid AdministracaoRemedioCorrelacaoId { get; set; }
        public virtual AdministracaoRemedio AdministracaoRemedioFilho { get; set; }
        public decimal Dose { get; set; }
        public Guid DiaProtocoloLuaId { get; set; }
        public virtual DiaProtocoloLua DiaProtocoloLua { get; set; }
        public override bool EhValido()
        {
            return true;
        }
    }
}