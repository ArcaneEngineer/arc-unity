using UnityEngine;
using System;
using System.Collections.Generic;

//Add Arc.Core to Script Execution Order above default time (and probably before everything else, since Ctrl logic should always run before any/all render related).
//This is also why this class can't be merged into Node!
namespace Arc
{
	//A top level behaviour that:
	//-kicks off all Nodes. It should *never* be SetActive(false).
	//-Runs all Ctrls, before Views are Update()d by Unity, as this is set to run before default time in Unity's Script Execution Order.
	//-(TODO) creates the scene graph from config
	public sealed class Core : MonoBehaviour
	{
		//there need only be one - it can kick off all the rest in a hierarchy
		public List<GameObject> initialActivations; //in order
		private List<Ctrl> ctrlsToRun = new List<Ctrl>(); //in order - switch to Debug mode in inspector to see this.
		
		
		public void Awake()
		{
			Debug.Log("AWAKE - CORE");
			
			ActivateChildren(this.gameObject, false);
			ActivateInitial();
		}
		
		public static void ActivateChildren(GameObject gameObject, bool state, bool recurse = true)
		{
			foreach (Transform childTransform in gameObject.transform)
			{
				Node node = childTransform.gameObject.GetComponent<Node>();
				if (node != null)
				{
					childTransform.gameObject.SetActive(state);
					//NOTE: due to the conditional above, we do not recurse through any GameObject that is a non-Node!
					if (recurse)
						ActivateChildren(childTransform.gameObject, state, recurse);
				}
			}
		}
		
		public void ActivateInitial()
		{
			foreach (GameObject go in initialActivations)
			{
				go.SetActive(true);
				Ctrl ctrl = go.GetComponent<Ctrl>();
				if (ctrl != null)
					ctrlsToRun.Add(ctrl);
			}
		}
		
		void Update ()
		{
			Debug.Log("---START FRAME---"+Time.time);
			
			foreach (Transform child in gameObject.transform)
			{
				//GameObject newChild = new GameObject("_null");
				Node node = child.GetComponent<Node>();
				if (node.gameObject.activeSelf)
					if  (node.ctrl != null)
						(node.ctrl as Ctrl)._Updt();
			}
			if (Input.GetKeyDown("space"))
			{
				AddChildTest();
			}
		}
		
		//TODO move out, DEV testing
		public GameObject testPrefab;
		
		private void AddChildTest()
		{
			Debug.Log("ADD---------------------------------");
			var test = GameObject.Instantiate(testPrefab);
			//test.transform.SetParent(transform);
			test.transform.SetParent(gameObject.transform.GetChild(0));
			test.SetActive(true);
		}
	}
}
