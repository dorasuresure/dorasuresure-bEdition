using UnityEngine;
using System.Collections;
//すり抜ける床1号
//playerTransformでplayerの位置を検出しオブジェクトより下ならCollider2Dを消す
//playerTransformを読み込まなくなったと思われる
public class ColliderController : MonoBehaviour
{
	Transform playerTransform;
	//下キー(K)を押す
	bool isDownKey = false;
	
	void Start ()
	{	
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		StartCoroutine ("EndofTime");
	}
	
	void FixedUpdate ()
	{
		float f = playerTransform.position.y + 0.1f;
		if (f <= 0) {
			collider2D.enabled = false;
		} else {
			Debug.Log("上");
			if(isDownKey)	return;
			collider2D.enabled = true;
		}
		if (Input.GetKey (KeyCode.K)) {
			isDownKey = true;
			collider2D.enabled = false;
			StartCoroutine("EndofTime");
		}
	}
	
	IEnumerator EndofTime()
	{
		yield return new WaitForSeconds(1.0f);
		isDownKey = false;
	}
}