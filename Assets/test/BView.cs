using Arc;
using UnityEngine;
using UnityEngine.UI;

public class BView : Arc.View
{
	public Toggle toggle;
	public Node cNode;
	
	public override void Init() 	{}
	void Start()
	//
	{Debug.Log("view.Init name="+ (gameObject != null ? gameObject.name : "<anon>"));      toggle.onValueChanged.AddListener((x) => Invoke("MyFunction", 1f));
 }
 private void MyFunction() {
     cNode.gameObject.SetActive(!cNode.gameObject.activeSelf);
 }
	public override void Updt() 		{Debug.Log("view.Updt name="+ (gameObject != null ? gameObject.name : "<anon>"));}
	//public override void InitLate(){}
	public override void UpdtLate() 	{}
	public override void Awak(){}
	
	//user-implemented: keep list of Ctrls / states we need to drive this View
	public BCtrl bCtrl; //optional, since we can easily grab it off this View's own node (these sit together on the BNode)
}