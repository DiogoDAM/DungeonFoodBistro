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
		private List<ICollisor> _collisorsList;
		private Rectangle _bounds;
		private QuadTree lt, rt, lb, rb;

		public QuadTree(Rectangle bounds, int maxObjects, int maxLevels, int level=0)
		{
			_maxOfObjects = maxObjects;
			_maxLevels = maxLevels;
			_level = level;
			_collisorsList = new();
			_bounds = bounds;
		}

		public void Insert(ICollisor collisor)
		{
		}

		public void DivideTree()
		{
		}

		public List<ICollisor> Query(ICollisor collisor, List<ICollisor> collidersConsulted)
		{
			return collidersConsulted;
		}

	}
}
