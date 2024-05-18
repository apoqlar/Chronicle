using System;

namespace Chronicle
{
    public readonly struct SagaId(Guid id)
    {
        public Guid Id => id;

        public static implicit operator Guid(SagaId sagaId) => sagaId.Id;
        public static implicit operator SagaId(Guid sagaId) => new(sagaId);

        public static bool operator ==(SagaId lhs, SagaId rhs) => lhs.Id == rhs.Id;
        public static bool operator !=(SagaId lhs, SagaId rhs) => !(lhs == rhs);

        public static SagaId NewSagaId() => new(Guid.NewGuid());
        public static SagaId FromString(string str) =>
            Guid.TryParse(str, out var guid) ? guid :
            throw new ChronicleException("String for SagaId must be GUID.");

        public override string ToString() => Id.ToString();
        public override bool Equals(object obj) => obj is SagaId other && this == other;
        public override int GetHashCode() => Id.GetHashCode();
    }
}
