using Psicologia.Domain.Services.Bairro;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Services.Bairro;

public class BairroAppService
{
    private readonly DataContext _context;
    private readonly BairroService _bairroService;

    public BairroAppService(
        DataContext context,
        BairroService bairroService)
    {
        _context = context;
        _bairroService = bairroService;
    }

    public bool VerificarSeBairroExiste(string nomeBairro)
    {
        // Recupera todos os bairros, ou possivelmente uma lista filtrada se isso for aceitável em termos de desempenho
        var bairros = _context.Bairros.ToList();

        // Usa o serviço de domínio para verificar se o bairro existe
        return _bairroService.BairroExiste(
            new BairroComNomeEspecificacao(nomeBairro),
            bairros);
    }
}
