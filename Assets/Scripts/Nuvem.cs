using UnityEngine;
using System.Collections;

public class Nuvem : MonoBehaviour {

	public float speed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (Vector2.right* speed* Time.deltaTime);


	}

	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.tag == "limite_dir"){
			speed = speed * (-1);
		}

		if(col.gameObject.tag == "limite_esq"){
			speed = speed * (-1);
		}
	}
}
