using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 4f; //歩くスピード
	public float JumpPower = 300;//ジャンプ力
	public float fireRate = 0.5f;//攻撃間隔
	private float nextfire = 0.0f;
	public LayerMask groundLayer;//地面に接しているかチェック
	public LayerMask AgroundLayer;//空中の"
	public GameObject mainCamera;
	public GameObject Slash;//剣攻撃
	public GameObject mahou;//魔法攻撃
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded;
	private bool isAGrounded;
	private Renderer renderer;
	public MpScript MpScript;//

	void Start () {
		//各コンポーネントをキャッシュしておく
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		renderer = GetComponent<Renderer> ();
	}

	void Update ()
	{
	isGrounded = Physics2D.Linecast (
		transform.position + transform.up * 0.1f,
		transform.position - transform.up * 1f,
		groundLayer);
	isAGrounded = Physics2D.Linecast (
		transform.position + transform.up * 0.1f,
		transform.position - transform.up * 0.1f,
		AgroundLayer);
	//isGrounded=true且つJumpボタンを押した時Jumpメソッド実行
		//Jump
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(isGrounded || isAGrounded){
				anim.SetBool ("Junp", true);
				isGrounded = false;
				anim.SetBool ("Dash", false);
				rigidbody2D.AddForce (Vector2.up * JumpPower);
			}
		} 
		if(isGrounded){
			anim.SetBool ("Jump", false);
		}
			Vector2 Position = transform.position;
		//Jキーを押すと右に
		if (Input.GetKey (KeyCode.J)) {
			int x = -1;
			anim.SetBool ("Dash", true);
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			transform.position = Position;
		}
		//Lキーを押すと左に
		else if (Input.GetKey (KeyCode.L)) {
			int x = 1;
			anim.SetBool ("Dash", true);
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			transform.position = Position;
		}else {
			//横移動の速度を0にしてピタッと止まるようにする
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
			//Dash→Wait
			anim.SetBool ("Dash", false);
		}
			if(transform.position.x > mainCamera.transform.position.x - 6){
				//カメラ位置
				Vector3 cameraPos = mainCamera.transform.position;
				//idousitara
				cameraPos.x = transform.position.x + 4;
				mainCamera.transform.position = cameraPos;
		}
		//Xで通常攻撃
		if (Input.GetKey (KeyCode.X)&&Time.time > nextfire) {
			nextfire = Time.time + fireRate;
			anim.SetTrigger("attack");
			Instantiate(Slash, transform.position + new Vector3(1f * transform.localScale.x,1.0f,0f), transform.rotation);
		}
		//ZでMPを１減らして魔法
		if (Input.GetKey (KeyCode.C)&&Time.time > nextfire) { 
			MpScript PlayerMp = MpScript.GetComponent<MpScript>();
			if(PlayerMp.num >= 1){
			nextfire = Time.time + fireRate;
			anim.SetTrigger("attack");
			Instantiate(mahou, transform.position + new Vector3(2f * transform.localScale.x,5f,0f), transform.rotation);
			MpScript.MpCost(50);
			}
		}
	}
	//敵の攻撃に当たったらコルーチン"Damage"に行く
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			StartCoroutine("Damage");
		}
	}
	//点滅するコルーチン
	IEnumerator Damage()
	{
		gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
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
		gameObject.layer = LayerMask.NameToLayer("Player");

	}
}

