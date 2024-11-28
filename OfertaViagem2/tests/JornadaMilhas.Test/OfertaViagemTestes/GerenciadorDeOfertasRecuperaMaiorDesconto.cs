using Bogus;
using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test.OfertaViagemTestes
{
    public class GerenciadorDeOfertasRecuperaMaiorDesconto
    {
        [Fact]
        public void RetornaOfertaNulaQuandoListaVazia()
        {
            //arrange
            var list = new List<OfertaViagem>();
            var gerenciador = new GerenciadorDeOfertas(list);
            Func<OfertaViagem, bool> filtro = _ => _.Rota.Destino.Equals("São Paulo");

            //act
            var oferta = gerenciador.RecuperaMaiorDesconto(filtro);

            //assert
            Assert.Null(oferta);
        }

        [Fact]
        public void RetornaOfertaEspecificaQuandoDestinoSPEDesconto40()
        {
            //arrange
            var rota = new Rota("Curitiba", "São Paulo");
            var fakePeriodo = new Faker<Periodo>().CustomInstantiator(f =>
            {
                DateTime dataInicio = f.Date.Soon();
                return new Periodo(dataInicio, dataInicio.AddDays(30));
            });

            var fakeOferta = new Faker<OfertaViagem>()
                .CustomInstantiator(_ => new OfertaViagem(rota, fakePeriodo.Generate(), 100 * _.Random.Int(1, 100)))
                .RuleFor(_ => _.Desconto, f => 40)
                .RuleFor(_ => _.Ativa, f => true);

            var ofertaEscolhida = new OfertaViagem(rota, fakePeriodo.Generate(), 80)
            {
                Desconto = 40,
                Ativa = true
            };

            var ofertaInativa = new OfertaViagem(rota, fakePeriodo.Generate(), 70)
            {
                Desconto = 40,
                Ativa = false
            };

            var list = fakeOferta.Generate(200);
            list.Add(ofertaEscolhida);
            list.Add(ofertaInativa);

            var gerenciador = new GerenciadorDeOfertas(list);
            Func<OfertaViagem, bool> filtro = _ => _.Rota.Destino.Equals("São Paulo") && _.Ativa == true;
            var precoEsperado = 40;

            //act
            var oferta = gerenciador.RecuperaMaiorDesconto(filtro);

            //assert
            Assert.NotNull(oferta);
            Assert.Equal(precoEsperado, oferta.Preco);
        }
    }
}
