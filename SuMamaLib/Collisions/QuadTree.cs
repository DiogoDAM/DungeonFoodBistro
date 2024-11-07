using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuMamaLib.Collisions
{
	public class QuadTree
	{
		private int _maxOfObjects;
		private int _maxLevels;
		private int _level;
		private List<ICollisor> _collisorsList;
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

		public bool Insert(ICollisor collisor)
		{
			if(collisor == null) throw new NullReferenceException();

			if(_bounds.Intersects(collisor.Bounds))
			{
				if(_collisorsList.Count < _maxOfObjects)
				{
					_collisorsList.Add(collisor);
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
					if(tl.Insert(collisor)) return true;
					if(tr.Insert(collisor)) return true;
					if(bl.Insert(collisor)) return true;
					if(br.Insert(collisor)) return true;
				}
			}

			return false;
		}
		
		public bool Remove(ICollisor collisor)
		{
			if(collisor == null) throw new NullReferenceException();

			if(_bounds.Intersects(collisor.Bounds))
			{
				if(_collisorsList.Contains(collisor))
				{
					_collisorsList.Remove(collisor);
					return true;
				}
				else
				{
					if(!_isLeaf)
					{
						if(tl.Remove(collisor)) return true;
						if(tr.Remove(collisor)) return true;
						if(bl.Remove(collisor)) return true;
						if(br.Remove(collisor)) return true;
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

		public List<ICollisor> Query(ICollisor range, List<ICollisor> found)
		{
			if(range == null) throw new NullReferenceException();

			if(_bounds.Intersects(range.Bounds))
			{
				foreach(ICollisor collisor in _collisorsList)
				{
					if(range.CheckCollision(collisor))
					{
						found.Add(collisor);
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
