using System;
using SuMamaLib.Behaviours.Interfaces;

namespace SuMamaLib.Behaviours
{
    public class GameObject : IDraw, IUpdate, IDisposable
    {
		public int Layer;

		protected bool _disposed = false;

		public GameObject()
		{
			Layer = 0;
		}

		public virtual void Start()
		{
		}

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
        }

        public void Dispose()
        {
			Dispose(true);
			GC.SuppressFinalize(this);
        }

		protected void Dispose(bool disposable)
		{
			if(disposable)
			{
				if(!_disposed)
				{
					_disposed = true;
				}
			}
		}
    }
}
