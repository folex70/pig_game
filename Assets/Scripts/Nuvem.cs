using UnityEngine;
using System.Collections;

public class Nuvem : MonoBehaviour {

	public float speed = 3f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("DropThunder",3f, 3f);
		InvokeRepeating ("DropSilverCoin",2f, 2f);
		InvokeRepeating ("DropGoldenCoin",17f, 17f);
		//DropCoin();
		//DropThunder();
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
}
