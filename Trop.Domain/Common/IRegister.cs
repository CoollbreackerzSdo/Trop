namespace Trop.Domain.Common;

public interface IRegister
{
    DateOnly RegisterDateAtUtc { get; }
    TimeOnly RegisterTimeAtUtc { get; }
}