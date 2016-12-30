using UnityEngine;

public class ACtrl : Arc.Ctrl
{	
	//public override void Start() 		{}
	public override void Init() 	{Debug.Log("ctrl.Init name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	public override void Updt() 		{Debug.Log("ctrl.Updt name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	//public override void InitLate(){}
	public override void UpdtLate() 	{}
	public override void Awak(){}
	public override void Susp(){}
	public override void Resm(){}
	
	
	public int laurel = 7;
	public string hardy = "hello";
}