using UnityEngine;
using System;
using System.Collections.Generic;

namespace Arc
{
	public abstract class Ctrl : MonoBehaviour//Updater
	{
		//bool updating; ///< Should this have update() called on it every frame?
		//bool initialised; ///< True after first initialise of the owner instance. If re- initialise is required, manually reset this to false.
		//bool suspended; ///< An alternative to suspending the whole containing Node, we can instead set this on an individual Updater.

		public Node node; //Node holding this.
		public abstract void Init(); //called by Node.Start
		public abstract void Awak(); //called by Node.Awake - Unity only
		public abstract void Resm(); //called by Node.OnEnable
		public abstract void Susp(); //called by Node.OnDisable
		public abstract void Updt(); //called by Core.Update before recursing children Ctrl.Updts
		public abstract void UpdtLate(); //called by Core.Update after recursing children Ctrl.Updts
		//public abstract void InitLate();
		//public abstract void Dispose();
		//public abstract void Start(); //starts ctrl updating - caused by SetActive(true)
		//public abstract void Stop(); //stops ctrl updating - contains SetActive(false)
		//public abstract void Suspend();
		//public abstract void Resume();

		//parent may be used during init to attach to parent / add to parent lists etc.; and also during update.
		//this ensures that even for late additions, we can accommodate both child and parent's need to "bond".
		public Ctrl parent = null;
		public List<Ctrl> children = new List<Ctrl>();
		
		/*
		public void _Init()
		{
			Init();
			
			foreach (Ctrl child in children) 
			{
				child.Initialise();
			}
			
			InitLate();
		}
		*/
		public void _Updt()
		{
			Updt(); //postorder DFS
			
			foreach (Ctrl child in children) 
			{
				child._Updt();
			}
			
			UpdtLate(); //preorder DFS
		}
	}
}