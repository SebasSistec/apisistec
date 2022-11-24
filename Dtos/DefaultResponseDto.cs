using System.Diagnostics.CodeAnalysis;
namespace apisistec.Dtos
{
    public class DefaultResponseDto<T>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        [MaybeNull]
        public T? Result { get; set; } = default;
    }
}
