using System.Threading.Tasks;

namespace Chronicle
{
    public interface ISagaStateRepository
    {
        Task<ISagaState> ReadAsync(SagaId id);
        Task WriteAsync(ISagaState state);
    }
}
