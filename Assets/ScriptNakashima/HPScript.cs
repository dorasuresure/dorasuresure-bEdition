using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPScript : MonoBehaviour
{

    RectTransform rt;

    //開始
    public GameObject player;   //プレイヤー
    public Text GameOverText;  //ゲームオーバーの文字
    private bool gameOver = false;  //ゲームオーバー判定
    //終了

    // Use this for initialization
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    //開始
    void Update()
    {
		//ライフが0以下になった時・・・sizeDelta.x　←yをxに変更
        if (rt.sizeDelta.x <= 0)
        {
            //ゲームオーバー判定をtrueにし、ユニティちゃんを消去
            GameOver();
        }
        //ゲームオーバー判定がtrueの時
        if (gameOver)
        {
            //ゲームオーバーの文字を表示
            GameOverText.enabled = true;
        }
		//画面をクリックすると・・・&& rt.sizeDelta.x <= 0　←を追加
		if (Input.GetMouseButtonDown(0) && rt.sizeDelta.x <= 0)
        {
            //タイトルへ戻る
            Application.LoadLevel("title");
        }
    }

    public void HPDown(int ap)
    {
        rt.sizeDelta -= new Vector2(ap, 0);
    }

    public void GameOver()
    {
        gameOver = true;
        Destroy(player);
		//DestroyImmediate (player, true);
		Debug.Log ("gameover");
	}
}
