using System.Collections.Generic;

namespace Chronicle.Managers
{
    public interface ISagaSeeker
    {
        IEnumerable<ISagaAction<TMessage>> Seek<TMessage>();
    }
}
