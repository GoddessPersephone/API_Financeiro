using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notificacoes
{
    public class Notification
    {
        public Notification()
        {
            notificacoes = new List<Notification>();
        }
        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string mensagem { get; set; }

        [NotMapped]
        public List<Notification> notificacoes;

        public bool ValidarPRopriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(nomePropriedade) || string.IsNullOrWhiteSpace(valor))
            {
                notificacoes.Add(new Notification
                {
                    mensagem = "Campo obrigatorio!"
                                                  ,
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
    }
}