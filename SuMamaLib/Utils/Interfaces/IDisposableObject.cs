namespace SuMamaLib.Utils.Interfaces
{
    public interface IDisposableObject
	{
		public bool Disposed { get; }

		public void Dispose();
	}
}
