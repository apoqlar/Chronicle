using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chronicle.Persistence
{
    public class InMemorySagaStateRepository : ISagaStateRepository
    {
        private readonly Dictionary<SagaId, ISagaState> _repository = [];

        public Task<ISagaState> ReadAsync(SagaId id) 
            => Task.FromResult(_repository.TryGetValue(id, out var value) ? value : null);

        public async Task WriteAsync(ISagaState state)
        {
            _repository[state.Id] = state;
            await Task.CompletedTask;
        }
    }
}
