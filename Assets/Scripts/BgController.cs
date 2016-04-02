using UnityEngine;
using System.Collections;

public class BgController : MonoBehaviour {

	public GameObject bg0;
	public GameObject bg1;
	public GameObject bg2;
	public GameObject bg3;
	public GameObject bg4;
	public GameObject bg5;
	public GameObject bg6;
	public int localLevel;
	public int bgChanger =0;
	public int bg =1;

	// Use this for initialization
	void Start () {
		
		bg0.SetActive (true);
		bg1.SetActive (false);
		bg2.SetActive (false);
		bg3.SetActive (false);
		bg4.SetActive (false);
		bg5.SetActive (false);
		bg6.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		localLevel = _GM.instance.GetLevel();
		if(localLevel > bgChanger){
			bgChanger++;
			changeBg();
		}
	}
	
	void changeBg(){
		//Debug.Log("entrou no chageBG() "+bg);
		switch (bg){
			case 1: 
				bg0.SetActive (true);
				bg1.SetActive (false);
				bg2.SetActive (false);
				bg3.SetActive (false);
				bg4.SetActive (false);
				bg5.SetActive (false);
				bg6.SetActive (false);
			break;
			case 2: 
				bg0.SetActive (false);
				bg1.SetActive (false);
				bg2.SetActive (true);
				bg3.SetActive (false);
				bg4.SetActive (false);
				bg5.SetActive (false);
				bg6.SetActive (false);
			break;
			case 3: 
				bg0.SetActive (false);
				bg1.SetActive (false);
				bg2.SetActive (false);
				bg3.SetActive (true);
				bg4.SetActive (false);
				bg5.SetActive (false);
				bg6.SetActive (false);
			break;
			case 4:
				bg0.SetActive (false);
				bg1.SetActive (false);
				bg2.SetActive (false);
				bg3.SetActive (false);
				bg4.SetActive (true);
				bg5.SetActive (false);
				bg6.SetActive (false);			
			break;
			case 5:
				bg0.SetActive (false);
				bg1.SetActive (false);
				bg2.SetActive (false);
				bg3.SetActive (false);
				bg4.SetActive (false);
				bg5.SetActive (true);
				bg6.SetActive (false);			
			break;
			case 6: 
				bg0.SetActive (false);
				bg1.SetActive (false);
				bg2.SetActive (false);
				bg3.SetActive (false);
				bg4.SetActive (false);
				bg5.SetActive (false);
				bg6.SetActive (true);
			break;
			default:
				bg0.SetActive (true);
				bg1.SetActive (false);
				bg2.SetActive (false);
				bg3.SetActive (false);
				bg4.SetActive (false);
				bg5.SetActive (false);
				bg6.SetActive (false);
			break;
		}
		bg++;
			if(bg>6){
				bg=0;
			}
	}
}
