using UnityEngine;
using System.Collections;

public class MpScript : MonoBehaviour {
	
	RectTransform rt;
	public int num = 0;
	
	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform>();
	}
	//subMpが溜まると１増える
	public void MpStock(int mps){
		rt.sizeDelta += new Vector2(mps,0);
		num++;
		//最大値を越えたら留める
		if(rt.sizeDelta.x > 200f){
			rt.sizeDelta = new Vector2(200f,50f);
		}
	}
	//playerが魔法を使うと減る
	public void MpCost(int mpc){
		rt.sizeDelta -= new Vector2(mpc,0);
		num--;
	}
}
