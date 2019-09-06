using System;

namespace TesteFullStackPleno.Core.Entities
{
    public class Comportamento : EntidadeBase
    {
        protected Comportamento()
        {

        }

        public Comportamento(string ip, string nome, string browser, string parametros)
        {
            Ip = ip;
            Nome = nome;
            Browser = browser;
            Parametros = parametros;
            Id = Guid.NewGuid();
        }

        public string Ip { get; private set; }
        public string Nome { get; private set; }
        public string Browser { get; private set; }
        public string Parametros { get; private set; }
    }
}
