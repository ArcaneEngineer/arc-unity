using UnityEngine;
using System.Collections;

//Node serves 2 purposes:
//-Creates hierarchical structure for application. Any Node may contain either a view, a ctrl, both, or neither (a purely organisational/"structural" node).
//-Allows phased execution of of Ctrl vs. View logic to occur, with the assistance of Core which runs all Ctrls first. 
namespace Arc
{
	public sealed class Node : MonoBehaviour
	{
		public View view;// = new TestView();
		public Ctrl ctrl;// = new TestCtrl(); //DEV, remove ctor when implementing this (abstract) class
		
		public bool initialiseOnStart = false;
		
		void Awake() //DEV? just to read gameObject name
		{
			Debug.Log("AWAKE " +this.gameObject.name);
			
			ctrl = GetComponent<Ctrl>();
			view = GetComponent<View>();
			
			if (ctrl != null)
			{
				ctrl.node = this;
				BondCtrl();
				if (!ctrl.initialiseOnStart)
					ctrl.Init();
			}
			
			//NB views initialise themselves?
			if (view != null)
			{
				view.node = this;
				//if (!view.initialiseOnStart)
				//	view.Init();
			}
		}
		
		void Start() //acts as the view init, along with Awake()? - this would require the ctrl init to have been called first, so that model is in order.
		{
			Debug.Log("START "+this.gameObject.name);
			if (ctrl != null)
				if (ctrl.initialiseOnStart)
					ctrl.Init();
			//if (view.initialiseOnStart)
			//	view.Initialise();
		}
		
		void Update()
		{
			//view._Update();
		}
		
		//"Bonding" refers to the parent-child linkage process.
		//cache the ctrl member of each child GameObject's Node, in this (parent) Node's ctrl.
		//this avoids us having to let Ctrl have access to the Node.
		public void BondCtrl()
		{
			Debug.Log("BondCtrl"+gameObject.name);
			
			//set parent - bond upward - this is used when building into existing tree
			if (transform.parent != null)
			{
				Node node = transform.parent.GetComponent<Node>();
				if (node != null) //TODO we could even search up the tree, here.
				{
					ctrl.parent = node.ctrl;
					ctrl.parent.children.Add(ctrl);
				}
			}
			//TODO bond upward beyond ctrl'less nodes (if these are to be allowed)
		}
	}
}