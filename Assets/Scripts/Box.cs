using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	public float  lifeTime =6f;
	private float localLifeTime;

	// Use this for initialization
	void Start () {
		localLifeTime = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		localLifeTime -= Time.deltaTime;
		
		if(localLifeTime < 0){
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.tag == "Player"){
			//Debug.Log("Destruir");
			Destroy(gameObject);
		}
	}

}
