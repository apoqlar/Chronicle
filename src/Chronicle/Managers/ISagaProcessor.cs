using System.Threading.Tasks;

namespace Chronicle.Managers
{
    public interface ISagaProcessor
    {
        Task ProcessAsync<TMessage>(ISaga saga, TMessage message, ISagaState state,
            ISagaContext context) where TMessage : class;
    }
}
