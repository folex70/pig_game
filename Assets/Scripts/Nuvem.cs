using UnityEngine;
using System.Collections;

public class Nuvem : MonoBehaviour {

	public float speed = 3f;
	public float timeDropThunder = 3f;
	public float timeDropGoldenCoin = 17f;
	public float timeDropSilverCoin = 2f;
	public int currentLevel; 
	public int localCountLevel =0; 
	public GameObject prefabBox;
	public int spawnBoxRandomInt;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("DropThunder",timeDropThunder, timeDropThunder);
		InvokeRepeating ("DropSilverCoin",timeDropSilverCoin, timeDropSilverCoin);
		InvokeRepeating ("DropGoldenCoin",timeDropGoldenCoin, timeDropGoldenCoin);
		//DropCoin();
		//DropThunder();
		//DropMagicBox();
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (Vector2.right* speed* Time.deltaTime);
		checkLevel();
		
		spawnBoxRandomInt = Random.Range(0,1000);
		if(spawnBoxRandomInt == 50){
			DropMagicBox();
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.tag == "limite_dir"){
			speed = speed * (-1);
		}

		if(col.gameObject.tag == "limite_esq"){
			speed = speed * (-1);
		}
	}
	
	void DropThunder()
    {
        //Instantiate (obstaculo_prefab);
        GameObject obj = ObjectPool.current.GetPooledObject();

        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
	
	void DropSilverCoin()
    {
        //Instantiate (obstaculo_prefab);
        GameObject obj = ObjectPoolSilver.current.GetPooledObject();

        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
	
	void DropGoldenCoin()
    {
        //Instantiate (obstaculo_prefab);
        GameObject obj = ObjectPoolGold.current.GetPooledObject();

        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
	
	void DropMagicBox()
    {
        Instantiate (prefabBox);
    }
	
	void checkLevel(){
		currentLevel = _GM.instance.GetLevel();
		
		if(localCountLevel < currentLevel){
			speed = Mathf.Abs(speed) +  0.2f;
			timeDropThunder = Mathf.Abs(speed) -  0.2f;
			CancelInvoke();
			InvokeRepeating ("DropThunder",timeDropThunder, timeDropThunder);
			InvokeRepeating ("DropSilverCoin",timeDropSilverCoin, timeDropSilverCoin);
			InvokeRepeating ("DropGoldenCoin",timeDropGoldenCoin, timeDropGoldenCoin);
			localCountLevel = currentLevel;
		}
	}
}
