using UnityEngine;
using System.Collections;

public class Enemy1Script : MonoBehaviour {

	Rigidbody2D rigidbody2D;
	public int speed = 0;	//移動速度
	public int attackPoint = 50;	//攻撃力
	public int exp = 50;		//経験値
	public HPScript HPScript;
	public doragon doragon;
	
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		//火に当たったら消える
		if (col.tag == "fire") {
			//Destroy(gameObject);
		}
		//噛みつかれたらdoragonの経験値を増やし消える
		if (col.tag == "bite") {
			doragon.doragonexp(exp);
			//Destroy(gameObject);
		}
		
	}
	//playerに当たったらHPを減らす
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			HPScript.HPDown(attackPoint);
		}
	}
}
