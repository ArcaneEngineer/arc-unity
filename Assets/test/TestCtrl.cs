using UnityEngine;

public class TestCtrl : Arc.Ctrl
{	
	//public override void Start() 		{}
	public override void Initialise() 	{Debug.Log("ctrl.Init name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	public override void Update_() 		{Debug.Log("ctrl.Updt name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	//public override void LateInitialise(){}
	public override void LateUpdate_() 	{}
	
	public int a = 7;
	public string b = "hello";
}