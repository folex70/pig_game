using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Text goldText;
	public int currentGold =0;

	// Use this for initialization
	void Start () {
		_GM.instance.Load();
		currentGold = _GM.instance.GetCurrentGold();
		goldText.text = "0000000"+currentGold.ToString();	
	}
	
	void Update(){
		currentGold = _GM.instance.GetCurrentGold();
		goldText.text = "0000000"+currentGold.ToString();	
	}
	
}
