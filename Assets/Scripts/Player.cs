using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	
	public float speed;
	public bool flipX;
	

	// Use this for initialization
	void Start () {
		//pega o componente do inspector
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetButton("Horizontal")){
			if(Input.GetAxis("Horizontal") > 0){
				rb.velocity = new Vector2(speed, 0);
				flipX = false;
			}else{
				rb.velocity = new Vector2(speed*(-1), 0);
				flipX = true;//!flipX;
			}
		}
				
		sprite.flipX = flipX;			
				
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "raio"){
			//gameover
			Debug.Log("colidiu com um raio e morreu");
		}
		
		if(col.gameObject.tag == "silver"){
			//+1 pontos
			Debug.Log("colidiu com uma moeda de prata");
		}
				
		if(col.gameObject.tag == "gold"){
			//+3 pontos
			Debug.Log("colidiu com uma moeda de ouro");
		}
	}
}
