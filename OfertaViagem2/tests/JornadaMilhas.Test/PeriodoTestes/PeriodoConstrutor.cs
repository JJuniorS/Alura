using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.PeriodoTestes
{
    public class PeriodoConstrutor
    {
        [Fact]
        public void RetornaErroSeDataInicialMaiorQueFinal()
        {
            var dataInicial = DateTime.Now;
            var dataFinal = dataInicial.AddDays(-1);

            var periodo = new Periodo(dataInicial, dataFinal);

            Assert.Equal("Data de ida não pode ser maior que a data de volta.", periodo.Erros.Sumario.Replace("\r\n", ""));
        }
    }
}
