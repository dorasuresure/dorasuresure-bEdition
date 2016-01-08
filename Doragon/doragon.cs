using UnityEngine;
using System.Collections;

public class doragon : MonoBehaviour {

	public float speed = 4f; //左右移動速度
	public float fry = 2f;//上下移動速度
	public float fireRate = 0.5f;//攻撃間隔
	private float nextfire = 0.0f;//fireRateを入れるよう
	public LayerMask groundLayer;//地面に接しているかのレイヤーを入れる
	public GameObject Fire;//攻撃の火を入れる
	public GameObject Bite;//噛みつきエフェクトを入れる
	private int sumexp; //合計経験値
	private Rigidbody2D rigidbody2D;//rigidbody2Dを定義
	//private Animator anim;//Animatorを定義
	private bool isGrounded;//当たっているかの判定
	private Renderer renderer;

	void Start () {
		//各コンポーネントをキャッシュしておく
		//anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		renderer = GetComponent<Renderer> ();
	}
		public void doragonexp(int dexp){
		sumexp += dexp;
		Debug.Log(sumexp);
	}

	void Update ()
	{
		//左キー: -1、右キー: 1、上キー: 1、下キー: -1
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		//左か右を入力したら
		if (x != 0) {
			//入力方向へ移動
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
			//localScale.xを-1にすると画像が反転する
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
		} else {
			//横移動の速度を0にしてピタッと止まるようにする
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
		}

		if (y != 0) {
			//入力方向へ移動
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, y * fry);
		} else {
			//横移動の速度を0にしてピタッと止まるようにする
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x ,0);
		}
		//カメラの座標取得
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
		Vector2 pos = transform.position;
		//カメラの左右に出ないようにする
		pos.x = Mathf.Clamp (pos.x ,min.x + 0.5f,max.x);
		transform.position = pos;
        /*if (Input.GetKey(KeyCode.Joystick1Button0) && Time.time > nextfire)
        {
			nextfire = Time.time + fireRate;
			Instantiate(Fire, transform.position + new Vector3(0f,0f,0f), transform.rotation);
		}*/
		//Zを押して火を噴く
		//expが100以上なら火を二つ吐く
		if (Input.GetKey (KeyCode.Z)&&Time.time > nextfire && sumexp >= 100) {
			nextfire = Time.time + fireRate;
			Instantiate(Fire, transform.position + new Vector3(0f,0.5f,0f), transform.rotation);
			Instantiate(Fire, transform.position + new Vector3(0f,-0.5f,0f), transform.rotation);
			//火を一つ吐く
		}else if(Input.GetKey (KeyCode.Z)&&Time.time > nextfire){
			nextfire = Time.time + fireRate;
			Instantiate(Fire, transform.position + new Vector3(0f,0f,0f), transform.rotation);
		}
		//Vを押して噛みつき攻撃
		if (Input.GetKey (KeyCode.V)&&Time.time > nextfire) {
			nextfire = Time.time + fireRate;
			Instantiate(Bite, transform.position + new Vector3(2f *transform.localScale.x,0f,0f), transform.rotation);
		}
	}
	//妖精に当たったらダメージコルーチンへ
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Fairy") {
            StartCoroutine("DoragonDamage");
		}
	}
	//点滅するコルーチン
	IEnumerator DoragonDamage()
	{
		gameObject.layer = LayerMask.NameToLayer("DoragonDamage");
		//10roope
        Debug.Log("DDamege");
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
		gameObject.layer = LayerMask.NameToLayer("Doragon");

	}
}

