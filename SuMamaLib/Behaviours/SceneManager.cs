using System;
using System.Collections.Generic;

namespace SuMamaLib.Behaviours
{
	public static class SceneManager
	{
		private static List<Scene> _scenesList = new();
		public static int CurrentScene { get; private set; }

		public static int ScenesCount { get { return _scenesList.Count; } }

		public static void Update()
		{
			_scenesList[CurrentScene].Update();
		}

		public static void Draw()
		{
			_scenesList[CurrentScene].Draw();
		}

		public static void AddScene(Scene scene)
		{
			if(scene == null){ throw new NullReferenceException(); }
			_scenesList.Add(scene);
			if(_scenesList.Count == 1)
			{ 
				CurrentScene = 0; 
				_scenesList[CurrentScene].Enter();
			}
		}

		public static void RemoveScene(Scene scene)
		{
			if(scene == null){ throw new NullReferenceException(); }
			var removedScene = _scenesList.Find(s => s.Equals(scene));
			removedScene.Dispose();
			_scenesList.Remove(scene);
		}

		public static void SwitchScene(Scene scene)
		{
			if(scene == null){ throw new NullReferenceException(); }
			if(!_scenesList.Contains(scene)) { throw new Exception(); }

			_scenesList[CurrentScene].Exit();
			CurrentScene = _scenesList.IndexOf(scene);
			_scenesList[CurrentScene].Enter();
		}

		public static void SwitchScene(int index)
		{
			_scenesList[CurrentScene].Exit();
			CurrentScene = index;
			_scenesList[CurrentScene].Enter();
		}


		public static void NextScene()
		{
			_scenesList[CurrentScene].Exit();
			CurrentScene++;
			_scenesList[CurrentScene].Enter();
		}

		public static void AddObject(GameObject obj)
		{
			if(obj == null) { throw new NullReferenceException(); }
			_scenesList[CurrentScene].AddObject(obj);
		}

		public static void InstantiateObject(GameObject obj)
		{
			if(obj == null) { throw new NullReferenceException(); }
			_scenesList[CurrentScene].InstantiateObject(obj);
		}

		public static void RemoveObject(GameObject obj)
		{
			if(obj == null) { throw new NullReferenceException(); }
			_scenesList[CurrentScene].RemoveObject(obj);
		}

		public static void DestroyObject(GameObject obj)
		{
			if(obj == null) { throw new NullReferenceException(); }
			_scenesList[CurrentScene].DestroyObject(obj);
		}

		public static T GetObject<T>(int layer)
		{
			return _scenesList[CurrentScene].GetObject<T>(layer);
		}

	}
}
