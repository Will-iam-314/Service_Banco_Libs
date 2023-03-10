namespace BK.Usuario.Dominio
{
    public interface IDocument<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }

    public interface IDocument : IDocument<Guid>
    {
    }
}
