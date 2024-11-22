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
		public int Width;
		public int Height;
		public Vector2 Position { get => Transform.Position + Offset + ((_parent != null) ? _parent.Position : Vector2.Zero); }
		public Color Color;
		public SpriteEffects SpriteEffect;
		public float Depth;
		public Vector2 Offset;
		public Vector2 Origin;

        public bool Disposed { get; protected set; }

        public UiComponent()
		{
			Transform = new();
			Color = Color.White;
			Width = 0;
			Height = 0;
			SpriteEffect = SpriteEffects.None;
			Depth = 0f;
			Offset = Vector2.Zero;
			Origin = Vector2.Zero;
			_children = new();
			_parent = null;
		}

        public UiComponent(UiComponent parent)
		{
			Transform = new();
			Color = Color.White;
			Width = 0;
			Height = 0;
			SpriteEffect = SpriteEffects.None;
			Depth = 0f;
			Origin = Vector2.Zero;
			Offset = Vector2.Zero;
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

		public void AddParent(UiComponent parent)
		{
			if(parent == null) throw new NullReferenceException();

			_parent = parent;
		}

		public void RemoveParent()
		{
			_parent = null;
		}

		public void AddChild(UiComponent child)
		{
			if(child == null) throw new NullReferenceException();

			_children.Add(child);
			child.AddParent(this);
		}

		public void RemoveChild(UiComponent child)
		{
			if(child == null) throw new NullReferenceException();

			_children.Remove(child);
			child.RemoveParent();
		}

		public void CentralizePosition()
		{
			Offset.X -= Width / 2;
			Offset.Y -= Height / 2;
		}

		public void CentralizePositionX()
		{
			Offset.X -= Width / 2;
		}

		public void CentralizePositionY()
		{
			Offset.Y -= Height / 2;
		}

		// methods to set position relative to parent
		public void CentralizeParentPosition()
		{
			if(_parent != null) 
			{
				Transform.Position = new Vector2(_parent.Width/2, _parent.Height/2);
			}
		}


		public void CentralizeParentPositionX()
		{
			if(_parent != null) 
			{
				Transform.Position.X = _parent.Width/2;
			}
		}

		public void CentralizeParentPositionY()
		{
			if(_parent != null) 
			{
				Transform.Position.Y = _parent.Height/2;
			}
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
