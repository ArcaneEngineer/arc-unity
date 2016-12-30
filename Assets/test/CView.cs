using UnityEngine;

public class CView : Arc.View
{
	//public override void Start() 		{}
	public override void Init() 	{Debug.Log("view.Init name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	public override void Updt() 		{Debug.Log("view.Updt name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	//public override void InitLate(){}
	public override void UpdtLate() 	{}
	public override void Awak(){}
	
	//user-implemented: keep list of Ctrls / states we need to drive this View
	public ACtrl aCtrl;
	public BCtrl bCtrl;
	
	//DEV remove? Use framework Updt instead? (inefficient if that isn't required)
	void Update()
	{
		Debug.Log("!");
	}
		
}