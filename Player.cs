using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 4f; //歩くスピード
	public float JumpPower = 200;//jumpryoku
	public LayerMask groundLayer;
	public GameObject mainCamera;
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded;

	void Start () {
		//各コンポーネントをキャッシュしておく
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
	isGrounded = Physics2D.Linecast (
		transform.position + transform.up * 0.1f,
		transform.position - transform.up * 0.5f,
		groundLayer);
	//isGrounded=true且つJumpボタンを押した時Jumpメソッド実行

		if (isGrounded && Input.GetKey (KeyCode.Space)) {
			anim.SetBool ("junp", true);
			isGrounded = false;
			anim.SetBool ("Dash", false);
			rigidbody2D.AddForce (Vector2.up * JumpPower);
		} 
		if(isGrounded){
			anim.SetBool ("junp", false);
		}
	/*
		float velY = rigidbody2D.velocity.y;
		bool isJumping = velY > 0.1f ? ture:false;
		bool isFalling = velY < 0.1f ? ture:false;
		anim.SetBool ("isJumping", isJumping);
		anim.SetBool ("isFalling", isFalling);
	*/
		//左キー: -1、右キー: 1
		float x = Input.GetAxisRaw ("Horizontal");
		//左か右を入力したら
		if (x != 0) {
			//入力方向へ移動
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
			//localScale.xを-1にすると画像が反転する
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			//Wait→Dash
			anim.SetBool ("Dash", true);
			//gamenntyuuoukara4idou
			if(transform.position.x > mainCamera.transform.position.x - 6){
				//kameraiti
				Vector3 cameraPos = mainCamera.transform.position;
				//idousitara
				cameraPos.x = transform.position.x + 4;
				mainCamera.transform.position = cameraPos;
		}
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			Vector2 pos = transform.position;
			pos.x = Mathf.Clamp (pos.x ,min.x + 0.5f,max.x);
			transform.position = pos;

			//左も右も入力していなかったら
		} else {
			//横移動の速度を0にしてピタッと止まるようにする
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
			//Dash→Wait
			anim.SetBool ("Dash", false);
		}
	}
}