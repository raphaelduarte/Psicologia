namespace Psicologia.Domain.Commands.Endereco.Logradouro
{
    public class CreateLogradouroCommand
    {
        public CreateLogradouroCommand() { }

        public CreateLogradouroCommand(string logradouroName)
        {
            LogradouroName = logradouroName;
            
        }
        public string LogradouroName { get; private set; }
    }
}
