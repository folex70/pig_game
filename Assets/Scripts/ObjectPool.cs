using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	public static ObjectPool current;
	public GameObject pooledObject;
	public int pooledNumberOfObjects = 5; //numero de objetos que serao de fato criados
	public bool willGrow = true;


	public List<GameObject> pooledObjectsList; //listas para armazenar os objetos. Precisa do Collections.Generic para funcionar


	void Awake()
	{
		current = this;
	}
	void Start () {

		pooledObjectsList = new List<GameObject> (); //instancia

		//primeiro passo do pool - criaçao dos objetos
		for(int i=0; i < pooledNumberOfObjects; i++)
		{
			GameObject obj = (GameObject) Instantiate (pooledObject);
			obj.SetActive(false);
			pooledObjectsList.Add(obj);
		}            
	}
	
	public GameObject GetPooledObject() 
	{
		for (int i =0; i < pooledObjectsList.Count; i++) 
		{

			if(!pooledObjectsList[i].activeInHierarchy)
			{
				return pooledObjectsList[i];
			}
		}

		if (willGrow) 
		{
			GameObject obj = (GameObject) Instantiate (pooledObject);
			pooledObjectsList.Add(obj);
			return obj;
		}

		return null;

	}


}