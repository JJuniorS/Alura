using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-10", 0, false)]
        [InlineData("Origem Test", "Destiny Test", "2024-01-01", "2024-01-10", 250, true)]
        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dtIda, string dtVolta, double preco, bool validacao)
        {
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dtIda), DateTime.Parse(dtVolta));
            OfertaViagem offer = new OfertaViagem(rota, periodo, preco);

            Assert.Equal(validacao, offer.EhValido);
        }


        [Fact]
        public void RetornaMsgDeErroQuandoRotaForNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double price = 100.00;
            OfertaViagem offer = new OfertaViagem(rota, periodo, price);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", offer.Erros.Sumario);
            Assert.False(offer.EhValido);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-250)]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorOuIgualAZero(double preco)
        {
            //arrange
            Rota rota = new Rota("Origem", "Destino");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));

            //act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }
    }
}