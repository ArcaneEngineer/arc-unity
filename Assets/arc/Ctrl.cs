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
		public bool initialiseOnStart;
		public object modelUntyped;
		public Node node; //Node holding this.
		
		//public abstract void Start(); //starts ctrl updating - caused by SetActive(true)
		//public abstract void Stop(); //stops ctrl updating - contains SetActive(false)
		public abstract void Initialise();
		//public abstract void LateInitialise();
		//public abstract void Dispose();
		public abstract void Update_();
		public abstract void LateUpdate_(); //UpdatePost();
		//public abstract void Suspend();
		//public abstract void Resume();
		//public void DoNothing();
		
		//parent may be used during init to attach to parent / add to parent lists etc.; and also during update.
		//this ensures that even for late additions, we can accommodate both child and parent's need to "bond".
		public Ctrl parent = null;
		public List<Ctrl> children = new List<Ctrl>();
		
		public void _Initialise()
		{
			Initialise();
			/*
			foreach (Ctrl child in children) 
			{
				child.Initialise();
			}
			*/
			//LateInit();
		}
		
		public void _Update()
		{
			Update_(); //postorder DFS
			
			foreach (Ctrl child in children) 
			{
				child._Update();
			}
			
			LateUpdate_(); //preorder DFS
		}
	}
}