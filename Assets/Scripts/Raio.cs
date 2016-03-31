using UnityEngine;
using System.Collections;

public class Raio : MonoBehaviour {

	private float  lifeTime = 5f;
	private float localLifeTime;
	private Rigidbody2D rb;
	public int drag; 
	
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		drag = Random.Range(0, 5);
		rb.drag = drag;
		localLifeTime = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		localLifeTime -= Time.deltaTime;
		
		if(localLifeTime < 0){
			Destroy();
		}
	}
	
	void OnTriggerEnter2D (Collider2D col){
		if(col.gameObject.tag == "Player"){
			Destroy();
		}
	}
	
	void Destroy(){
		gameObject.SetActive (false);
		drag = Random.Range(0, 5);
		localLifeTime = lifeTime;
	} 
}
