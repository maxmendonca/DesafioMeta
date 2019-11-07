using System.ComponentModel.DataAnnotations;

namespace MinhaWebApi.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo <b><i>{0}</i></b> é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O tamanho do campo <b><i>{0}</i></b> deve estar entre {2} e {1}")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo <b><i>{0}</i></b> é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O tamanho do campo <b><i>{0}</i></b> deve estar entre {2} e {1}")]
        [Display(Name = "Canal Contato")]
        public string CanalContato { get; set; }

        [Required(ErrorMessage = "O campo <b><i>{0}</i></b> é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O tamanho do campo <b><i>{0}</i></b> deve estar entre {2} e {1}")]
        [Display(Name = "Observação Contato")]
        public string ObservacaoContato { get; set; }

        [Display(Name = "Tipo Canal")]
        public TipoContato TipoContato { get; set; }

        [Display(Name = "Tipo Canal")]
        public int TipoContatoId { get; set; }

        public Contato()
        {

        }

        public Contato(int id, string nome, TipoContato tipoContato, string canalContato, string observacaoContato)
        {
            Id = id;
            Nome = nome;
            TipoContato = tipoContato;
            CanalContato = canalContato;
            ObservacaoContato = observacaoContato;
        }
    }
}
