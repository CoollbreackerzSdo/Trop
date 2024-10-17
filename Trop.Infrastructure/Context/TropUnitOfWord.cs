using Trop.Application.Common.Repository;

namespace Trop.Infrastructure.Context;

public class TropUnitOfWord : IUnitOfWord
{
    public TropUnitOfWord(TropContext context)
    {
        _context = context;
        UserRepository = new UserRepository(_context);
    }
    public Task SaveChangesAsync(CancellationToken token) => _context.SaveChangesAsync(token);
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // TODO: eliminar el estado administrado (objetos administrados)
                _context.Dispose();
            }

            // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
            // TODO: establecer los campos grandes como NULL
            _disposedValue = true;
        }
    }

    // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
    // ~TropUnitOfWord()
    // {
    //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public IUserRepository UserRepository { get; }
    private readonly TropContext _context;
    private bool _disposedValue;
}