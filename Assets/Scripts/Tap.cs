using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour {

	public float  lifeTime;
	private float localLifeTime;

	// Use this for initialization
	void Start () {
		localLifeTime = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		localLifeTime -= Time.deltaTime;
		
		if(localLifeTime < 0){
			Destroy();
		}
	}
	

	void Destroy(){
		gameObject.SetActive (false);
		localLifeTime = lifeTime;
	} 
}
