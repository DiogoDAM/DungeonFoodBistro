using System;
using System.Collections.Generic;
using System.Linq;

namespace SuMamaLib.Behaviours
{
	public class Scene : IDisposable
	{
		protected List<List<GameObject>> _objectsList;

		protected bool _disposed;

		public Scene()
		{
			_objectsList = new();
		}

		public virtual void Start()
		{
			foreach(var layer in _objectsList)
			{
				foreach(var obj in layer)
				{
					obj.Start();
				}
			}
		}

		public virtual void Update()
		{
			foreach(var layer in _objectsList)
			{
				foreach(var obj in layer)
				{
					obj.Update();
				}
			}
		}

		public virtual void Draw()
		{
			foreach(var layer in _objectsList)
			{
				foreach(var obj in layer)
				{
					obj.Draw();
				}
			}
		}

		public virtual void Enter()
		{
			Start();
		}

		public virtual void Exit()
		{
		}

		public void AddObject(GameObject obj)
		{
			if(obj == null){ throw new NullReferenceException(); }
			_objectsList[obj.Layer].Add(obj);
		}

		public void InstantiateObject(GameObject obj)
		{
			throw new NotImplementedException();
		}

		public void RemoveObject(GameObject obj)
		{
			if(obj == null){ throw new NullReferenceException(); }
			if(!_objectsList[obj.Layer].Contains(obj)){ return; }
			_objectsList[obj.Layer].Remove(obj);
		}

		public void DestroyObject(GameObject obj)
		{
			if(obj == null){ throw new NullReferenceException(); }
			if(!_objectsList[obj.Layer].Contains(obj)){ return; }
			_objectsList[obj.Layer].Find(o => o.Equals(obj)).Dispose();
			_objectsList[obj.Layer].Remove(obj);
		}

		public T GetObject<T>(int layer)
		{
			return _objectsList[layer].OfType<T>().FirstOrDefault();
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
					_objectsList.ForEach(layer => layer.ForEach(obj => obj.Dispose()));
					_objectsList = null;

					_disposed = true;
				}
			}
		}
    }
}
