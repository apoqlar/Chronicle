using System.Threading.Tasks;

namespace Chronicle.Managers
{
    public interface ISagaInitializer
    {
        Task<(bool isInitialized, ISagaState state)> TryInitializeAsync<TMessage>(ISaga saga, SagaId id, TMessage _);
    }
}
