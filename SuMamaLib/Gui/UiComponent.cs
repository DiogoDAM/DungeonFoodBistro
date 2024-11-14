using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Interfaces;

namespace SuMamaLib.Gui
{
	public abstract class UiComponent : IDisposableObject
	{
		protected List<UiComponent> _children;
		protected UiComponent _parent;

		public Transform Transform;
		public Color Color;
		public SpriteEffects SpriteEffect;
		public float Depth;
		public Vector2 Origin;

        public bool Disposed { get; protected set; }

        public UiComponent()
		{
			Transform = new();
			Color = Color.White;
			SpriteEffect = SpriteEffects.None;
			Depth = 0f;
			Origin = Vector2.Zero;
			_children = new();
		}

        public UiComponent(UiComponent parent)
		{
			Transform = new();
			Color = Color.White;
			SpriteEffect = SpriteEffects.None;
			Depth = 0f;
			Origin = Vector2.Zero;
			_children = new();
			_parent = parent;
		}

		public virtual void Update()
		{
			foreach(var child in _children)
			{
				child.Update();
			}
		}

		public virtual void Draw()
		{
			foreach(var child in _children)
			{
				child.Draw();
			}
		}

		public void AddChild(UiComponent child)
		{
			if(child == null) throw new NullReferenceException();

			_children.Add(child);
		}

		public void RemoveChild(UiComponent child)
		{
			if(child == null) throw new NullReferenceException();

			_children.Remove(child);
		}

		public T GetChild<T>()
		{
			return _children.OfType<T>().FirstOrDefault();
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
					Transform = null;
					Disposed = true;
				}
			}
		}

    }
}
