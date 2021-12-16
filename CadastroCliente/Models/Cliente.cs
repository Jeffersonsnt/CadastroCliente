namespace CadastroCliente.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public long Cpf { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }

    }
}
