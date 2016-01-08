using UnityEngine;
using System.Collections;

public class SubMp : MonoBehaviour {

	RectTransform rt;
	public MpScript MpScript;
	
	void Start () {
		rt = GetComponent<RectTransform>();
	}
	public void Mpgain(int mpg){
		//RectTransformのサイズを取得し、プラスにする
		rt.sizeDelta += new Vector2 (mpg,0);
		//最大値を越えたら、消える
		if(rt.sizeDelta.x > 160f){
			rt.sizeDelta = new Vector2 (0.01f,19f);
			MpScript.MpStock(50);
		}
	}
}
