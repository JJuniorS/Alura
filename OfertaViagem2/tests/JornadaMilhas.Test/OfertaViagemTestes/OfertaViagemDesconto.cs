using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.OfertaViagemTestes
{
    public class OfertaViagemDesconto
    {
        [Fact]
        public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
        {
            Rota rota = new Rota("Origem", "Destino");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
            double preco = 250.00;
            double desconto = 50.00;
            double valorEsperadoComDesconto = preco - desconto;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
            oferta.Desconto = 50;
            Assert.Equal(valorEsperadoComDesconto, oferta.Preco);
        }

        [Theory]
        [InlineData(120, 70)]
        [InlineData(100, 70)]
        public void RetornaDescontoMaximoQuandoValorDescontoMaiorQuePrecoOuIgual(double desconto, double precoComDesconto)
        {
            Rota rota = new Rota("Origem", "Destino");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
            double preco = 100;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
            oferta.Desconto = desconto;
            Assert.Equal(precoComDesconto, oferta.Preco);
        }

        [Fact]
        public void RetornaPrecoNormalCasoDescontoNegativo()
        {
            Rota rota = new Rota("Origem", "Destino");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
            double preco = 100.00;
            double desconto = -50;
            double valorEsperadoComDesconto = 100.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
            oferta.Desconto = desconto;
            Assert.Equal(valorEsperadoComDesconto, oferta.Preco);
        }
    }
}
