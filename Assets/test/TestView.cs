using UnityEngine;

public class TestView : Arc.View
{
	public TestModel test { get {return modelUntyped as TestModel;} }
	
	//public override void Start() 		{}
	public override void Initialise() 	{Debug.Log("view.Init name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	public override void Update() 		{Debug.Log("view.Updt name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	//public override void LateInitialise(){}
	public override void LateUpdate() 	{}
}