using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuMamaLib.Collisions.Interfaces;

namespace SuMamaLib.Collisions
{
	public class QuadTree
	{
		private int _maxOfObjects;
		private int _maxLevels;
		private int _level;
		private List<IBody> _collisorsList;
		private Rectangle _bounds;
		private QuadTree tl, tr, bl, br;
		private bool _isLeaf;

		public QuadTree(Rectangle boundary, int maxObjects, int maxLevels, int level=0)
		{
			_maxOfObjects = maxObjects;
			_maxLevels = maxLevels;
			_level = level;
			_collisorsList = new();
			_bounds = boundary;
			_isLeaf = true;
		}

		public bool Insert(IBody body)
		{
			if(body == null) throw new NullReferenceException();

			if(_bounds.Intersects(body.Collisor.BoundingRectangle))
			{
				if(_collisorsList.Count < _maxOfObjects)
				{
					_collisorsList.Add(body);
					return true;
				}
				else
				{
					if(_isLeaf && _level < _maxLevels)
					{
						Subdivide();
					}
				}

				if(!_isLeaf)
				{
					if(tl.Insert(body)) return true;
					if(tr.Insert(body)) return true;
					if(bl.Insert(body)) return true;
					if(br.Insert(body)) return true;
				}
			}

			return false;
		}
		
		public bool Remove(IBody body)
		{
			if(body == null) throw new NullReferenceException();

			if(_bounds.Intersects(body.Collisor.BoundingRectangle))
			{
				if(_collisorsList.Contains(body))
				{
					_collisorsList.Remove(body);
					return true;
				}
				else
				{
					if(!_isLeaf)
					{
						if(tl.Remove(body)) return true;
						if(tr.Remove(body)) return true;
						if(bl.Remove(body)) return true;
						if(br.Remove(body)) return true;
					}
				}
			}

			return false;
		}

		public void Clear()
		{
			_collisorsList.Clear();

			if(!_isLeaf)
			{
				tl.Clear();
				tr.Clear();
				bl.Clear();
				br.Clear();
			}
		}

		public void Subdivide()
		{
			int x = _bounds.X; 
			int y = _bounds.Y;
			int w = _bounds.Width / 2;
			int h = _bounds.Height / 2;

			tl = new QuadTree(new Rectangle(x, y, w, h), _maxOfObjects, _maxLevels, _level++);
			tr = new QuadTree(new Rectangle(x+w, y, w, h), _maxOfObjects, _maxLevels, _level++);
			bl = new QuadTree(new Rectangle(x, y+h, w, h), _maxOfObjects, _maxLevels, _level++);
			br = new QuadTree(new Rectangle(x+w, y+h, w, h), _maxOfObjects, _maxLevels, _level++);

			_isLeaf = true;
		}

		public List<IBody> Query(IBody range, List<IBody> found)
		{
			if(range == null) throw new NullReferenceException();

			if(_bounds.Intersects(range.Collisor.BoundingRectangle))
			{
				foreach(IBody body in _collisorsList)
				{
					if(range.Collisor.BoundingRectangle.Intersects(body.Collisor.BoundingRectangle))
					{
						found.Add(body);
					}
				}

				if(!_isLeaf)
				{
					tl.Query(range, found);
					tr.Query(range, found);
					bl.Query(range, found);
					br.Query(range, found);
				}
			}


			return found;
		}

	}
}
