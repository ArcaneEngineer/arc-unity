using UnityEngine;
using System;
using System.Collections;

//Node serves 2 purposes:
//-Creates hierarchical structure for application. Any Node may contain either a view, a ctrl, both, or neither (a purely organisational/"structural" node).
//-Allows phased execution of of Ctrl vs. View logic to occur, with the assistance of Core which runs all Ctrls first. 
namespace Arc
{
	public sealed class Node : MonoBehaviour
	{
		public View view;
		public Ctrl ctrl;

		void Awake() //like the Ctor - all Awakes are called before all Starts, each frame
		{
			Debug.Log("Awake " +this.gameObject.name);
			
			ctrl = GetComponent<Ctrl>();
			view = GetComponent<View>();
			
			if (ctrl != null)
			{
				ctrl.node = this;
				BondCtrl();
				ctrl.Awak();
			}
			
			//NB views initialise themselves? - using Unity's standard framework approaches.
			if (view != null)
			{
				view.node = this;
				//set children?
			}
		}
		
		void Start() //typically used in Unity for combining / accessing objects created through Awake()
		{
			Debug.Log("Start "+this.gameObject.name);
			if (ctrl != null)
				ctrl.Init();
		}
		
		void OnEnable()
		{
			Debug.Log("OnEnable "+this.gameObject.name);
			if (ctrl != null)
				ctrl.Resm();
		}
		
		void OnDisable()
		{
			Debug.Log("OnDisable "+this.gameObject.name);
			if (ctrl != null)
				ctrl.Susp();
		}
		
		void Update()
		{
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