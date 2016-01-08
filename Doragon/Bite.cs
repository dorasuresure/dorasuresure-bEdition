using UnityEngine;
using System.Collections;

public class Bite : MonoBehaviour {

	private GameObject Doragon;
	private float destoroytime = 0.4f;
	// Use this for initialization
	void Start () {
		Doragon = GameObject.FindWithTag("Doragon");
		//rigidbody2Dコンポーネントを取得
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		Vector2 temp = transform.localScale;
		temp.x = Doragon.transform.localScale.x;
		transform.localScale = temp;
		//1秒後に消滅
		Destroy(gameObject, destoroytime);
	}
	//敵に当たると消える
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
	}
}
