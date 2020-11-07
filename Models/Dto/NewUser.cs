namespace backend.Models.Dto
{
    public class NewUser
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}