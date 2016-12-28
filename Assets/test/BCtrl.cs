using UnityEngine;

public class BCtrl : Arc.Ctrl
{	
	//public override void Start() 		{}
	public override void Init() 	{Debug.Log("ctrl.Init name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	public override void Updt() 		{Debug.Log("ctrl.Updt name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	//public override void InitLate(){}
	public override void UpdtLate() 	{}
	
	public int ace = 7;
	public string eyeball = "hello";
}