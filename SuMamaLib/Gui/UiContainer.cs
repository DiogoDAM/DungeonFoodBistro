using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuMamaLib.Utils.Interfaces;

namespace SuMamaLib.Gui
{
	public abstract class UiContainer : IDisposableObject
	{
		protected List<UiComponent> _components;
		
		public Vector2 Position;
		public int Width, Height;

        public bool Disposed { get; protected set; }

        public UiContainer()
		{
			_components = new();
		}

		public UiContainer(Vector2 pos, int w, int h)
		{
			_components = new();
			Position = pos;
			Width = w;
			Height = h;
		}

		public virtual void Update()
		{
			if(Disposed) return;

			foreach(var component in _components)
			{
				component.Update();
			}
		}

		public virtual void Draw()
		{
			if(Disposed) return;

			foreach(var component in _components)
			{
				component.Draw();
			}
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
				if(!Disposed)
				{
					foreach(var component in _components)
					{
						component.Dispose();
					}
					Disposed = true;
				}
			}
		}
    }
}
