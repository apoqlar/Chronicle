using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chronicle.Persistence
{
    public class InMemorySagaLog : ISagaLog
    {
        private readonly Dictionary<SagaId, List<ISagaLogData>> _sagaLog = [];

        public Task<IEnumerable<ISagaLogData>> ReadAsync(SagaId id)
            => Task.FromResult(_sagaLog.TryGetValue(id, out var value) ? (IEnumerable<ISagaLogData>)value : []);

        public async Task WriteAsync(ISagaLogData message)
        {
            if (!_sagaLog.TryGetValue(message.Id, out var log))
                _sagaLog[message.Id] = log = [];
            log.Add(message);
            await Task.CompletedTask;
        }
    }
}
