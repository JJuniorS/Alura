using JornadaMilhas.Modelos;

namespace JornadaMilhas.Test
{
    public class MusicaTest
    {
        [Fact]
        public void TestarInicializacaoMusica()
        {
            var nomeMusica = "Chevette do Jacó";
            var musica = new Musica(nomeMusica);

            Assert.Equal(nomeMusica, musica.Nome);
        }

        [Fact]
        public void TestarIdentificadorMusica()
        {
            var nomeMusica = "Chevette do Jacó";
            var musica = new Musica(nomeMusica, 1);

            Assert.Equal(1, musica.Id);
        }

        [Fact]
        public void TestarMetodoDeSaidaString()
        {
            var nomeMusica = "Chevette do Jacó";
            var id = 6;
            var musica = new Musica(nomeMusica, id);

            Assert.Equal($"Id: {id} Nome: {nomeMusica}", musica.ToString());
        }

    }
}
