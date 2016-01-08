using UnityEngine;
using System.Collections;
//すり抜ける床2号
//Treggerに当たったらCollider2Dを消す
public class BoxController : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
		collider2D.enabled = false;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Player"){
		collider2D.enabled = true;
		}
	}
}
