using UnityEngine;
using System.Collections;

public class fairy1Script : MonoBehaviour {

	Rigidbody2D rigidbody2D;
	public float EnemyHp = 30;	//敵のHP
	public int speed = -3;	//移動力
	public int attackPoint = 50;	//攻撃力
	public int MpUp = 50;	//倒した時増えるMP
	public HPScript HPScript;
	public SubMp SubMp;
	
	
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		rigidbody2D.velocity = new Vector2 (0f, rigidbody2D.velocity.y);
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Doragon") {
			HPScript.HPDown(attackPoint);
		}
	}
	//*注意2ヒットするため改善の余地あり
	//理由キャラにコライダーが二つあるから
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Slash") {
			//SubMpメッソドを呼び出す引数はgainMp
			SubMp.Mpgain(MpUp);
			StartCoroutine("Damage");
			//Destroy(gameObject);
		}
		if (col.tag == "mahou"){
			StartCoroutine("Damage");
			//Destroy(gameObject);
		}
	}	
	IEnumerator Damage()
	{
		gameObject.layer = LayerMask.NameToLayer("FairyDamage");
		//10roope
		int count = 10;
		while (count > 0) {
			//toumei
			renderer.material.color = new Color (1,1,1,0);
			//0.05matu
			yield return new WaitForSeconds(0.05f);
			renderer.material.color = new Color(1,1,1,1);
			//0.05matu
			yield return new WaitForSeconds(0.05f);
			count--;
		}
		//LAYER->Player
		gameObject.layer = LayerMask.NameToLayer("Fairy");
	}
}
