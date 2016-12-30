using UnityEngine;
using System;
using System.Collections.Generic;

namespace Arc
{
	public abstract class View : MonoBehaviour//Updater
	{
		public Node node; //Node holding this.
		
		//bool updating; ///< Should this have update() called on it every frame?
		//bool initialised; ///< True after first initialise of the owner instance. If re- initialise is required, manually reset this to false.
		//bool suspended; ///< An alternative to suspending the whole containing Node, we can instead set this on an individual Updater.
		
		/*
		public abstract void Awak(); //called by View.Awake
		public abstract void Init(); //called by View.Start
		//public abstract void Resm(); //called when GameObject s
		//public abstract void Susp(); //called by Node.OnDisable
		public abstract void Updt();
		public abstract void UpdtLate(); //UpdatePost();
		//public abstract void Start();
		//public abstract void Stop();
		//public abstract void Suspend();
		//public abstract void Resume();
		//public abstract void LateInitialise();
		//public abstract void Dispose();
		
		//parent may be used during init to attach to parent / add to parent lists etc.; and also during update.
		//this ensures that even for late additions, we can accommodate both child and parent's need to "bond".
		public View parent = null;
		public List<View> children = new List<View>();
		*/
		/*
		public void _Init()
		{
			Init();
			
			foreach (View child in children) 
			{
				child.Initialise();
			}
			
			InitLate();
		}
		*/
		/*
		public void _Updt()
		{
			Updt(); //postorder DFS
			
			foreach (View child in children) 
			{
				child._Updt();
			}
			
			UpdtLate(); //preorder DFS
			
		}
		*/
	}
}