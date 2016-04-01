using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	
	public float speed;
	public bool flipX;
	public int localGold;
	public int localLevel;
	AudioSource audio;
	public AudioClip  pickCoin;

	// Use this for initialization
	void Start () {
		//pega o componente do inspector
		localGold =0;
		localLevel =0;
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		audio = GetComponent<AudioSource>();
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
		checkLevel();
		Debug.Log("Gold "+localGold);
		Debug.Log("Level "+localLevel);
		_GM.instance.SetCurrentGold(localGold);
	}
	
	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag == "silver"){
			//+1 pontos 
			localGold += 1;
			audio.PlayOneShot(pickCoin, 0.7F);
		}
				
		if(col.gameObject.tag == "gold"){
			//+3 pontos
			localGold += 3;
			audio.PlayOneShot(pickCoin, 0.7F);
		}
	}
	
	 void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "raio" || col.gameObject.tag == "espinho"){
			gameOver();
		}
    }
	
	void gameOver(){
		//Application.LoadLevel(Application.loadedLevel);
		 SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);  
	}
	
	void checkLevel(){
		
        if(localLevel == 0 && localGold > 10)
        {
            localLevel = 1;
        }
        else if ((localLevel < 10) && localGold > (10 * localLevel))
        {
            localLevel++;
        }
        else if ((localLevel >= 10) && localGold > (20 * localLevel))
        {
            localLevel++;
        }
        _GM.instance.SetLevel(localLevel);
	}
}
