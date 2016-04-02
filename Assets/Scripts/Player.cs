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
	public int magicBoxNumber;
	//--------efeitos da caixa--
	public GameObject prefabThunder;
	public GameObject prefabThunder1;
	public GameObject prefabThunder2;
	public GameObject prefabThunder3;
	public GameObject prefabThunder4;
	public GameObject prefabThunder5;
	public GameObject prefabThunder6;
	public GameObject prefabSilver;
	public GameObject prefabGold;
	public GameObject prefabNuvem;
	public GameObject bgChuva;
	public float magicBoxEffectTimeleft = 10f;
	//--------------------------
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
		//Debug.Log("Gold "+localGold);
		//Debug.Log("Level "+localLevel);
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
		
		if(col.gameObject.tag == "magic_box"){
			//efeito aleatorio no jogo
			magicBoxNumber = Random.Range(0, 6);
			Debug.Log(magicBoxNumber);
			switch(magicBoxNumber){
				case 1:
					Instantiate (prefabNuvem);
					Debug.Log("drop nuvem");
				break;
				
				case 2:
					bgChuva.SetActive(true);
					magicBoxEffectTimeleft -= Time.deltaTime;;
					if(magicBoxEffectTimeleft < 0){
						bgChuva.SetActive(false);
					}
					Debug.Log("chuva");
				break;
				
				case 3:
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Instantiate (prefabSilver);
					Debug.Log("drop 10 silver");
				break;
				
				case 4:
					Instantiate (prefabGold);
					Instantiate (prefabGold);
					Instantiate (prefabGold);
					Instantiate (prefabGold);
					Instantiate (prefabGold);
					Debug.Log("drop 5 gold coin");
				break;
				
				case 5:
					Instantiate (prefabThunder);
					Instantiate (prefabThunder1);
					Instantiate (prefabThunder2);
					Instantiate (prefabThunder3);
					Instantiate (prefabThunder4);
					Instantiate (prefabThunder5);
					Instantiate (prefabThunder6);
					Debug.Log("drop raios");
				break;
					
				case 6:
					speed += 1;
					Debug.Log("speed +1");
				break;
				
				default:
					Instantiate (prefabGold);
					Debug.Log("drop 1 gold");
				break;
			}
		}
	}
	
	 void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "raio" || col.gameObject.tag == "espinho"){
			gameOver();
		}
    }
	
	void gameOver(){
		//Application.LoadLevel(Application.loadedLevel);
		//SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);  
		SceneManager.LoadScene("gameOver");  
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
			Instantiate (prefabNuvem);
        }
        _GM.instance.SetLevel(localLevel);
	}
}
