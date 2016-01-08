using UnityEngine;
using System.Collections;

public class Slash : MonoBehaviour {
	
	private GameObject player;
	private float destoroytime = 0.2f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		//rigidbody2Dコンポーネントを取得
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		//rigidbody2D.velocity = new Vector2 (speed * player.transform.localScale.x, rigidbody2D.velocity.y);
		Vector2 temp = transform.localScale;
		temp.x = player.transform.localScale.x;
		transform.localScale = temp;
		//0.2秒後に消滅
		Destroy(gameObject, destoroytime);
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
	}
}
