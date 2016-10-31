using UnityEngine;
using System;
using System.Collections.Generic;

//Add Arc.Core to Script Execution Order above default time (and probably before everything else, since Ctrl logic should always run before any/all render related).

namespace Arc
{
	//A top level behaviour that:
	//-kicks off all Nodes. It should *never* be SetActive(false).
	//-Runs all Ctrls, before Views are Update()d by Unity, as this is set to run before default time in Unity's Script Execution Order.
	//-(TODO) creates the scene graph from config
	public sealed class Core : MonoBehaviour
	{
		public void Awake()
		{
			//Debug.Log("AWAKE - CTRL CORE");
			
			//_Initialise();
			//gameObject.SetActive(true); //even though this is already active, it recurses through the rest.
		}
		
		public void _Initialise()
		{
			//Debug.Log("_Initialise");
			
			//node.ctrl.model = model;
			
			foreach (Transform childTF in gameObject.transform)
			{
				//GameObject newChild = new GameObject("_null");
				Node node = childTF.GetComponent<Node>();
				(node.ctrl as Ctrl)._Initialise();
				childTF.gameObject.SetActive(true);
				break;
			}
			
			//node.gameObject.SetActive(true);
		}
		
		void Update ()
		{
			Debug.Log("---START FRAME---"+Time.time);
			
			foreach (Transform child in gameObject.transform)
			{
				//GameObject newChild = new GameObject("_null");
				Node node = child.GetComponent<Node>();
				if (node.gameObject.activeSelf)
					(node.ctrl as Ctrl)._Update();
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
