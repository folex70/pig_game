using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Text goldText;
	public Text hiGoldText;
	public int currentGold =0;
	public int hiGold =0;

	// Use this for initialization
	void Start () {
		_GM.instance.Load();
		currentGold 	= _GM.instance.GetCurrentGold();
		hiGold 		= _GM.instance.GetGold();
		if(currentGold > hiGold) {
			_GM.instance.SetGold(currentGold);
			hiGold 		= _GM.instance.GetGold();
		}
		goldText.text 	= "0000000"+currentGold.ToString();	
		hiGoldText.text = "0000000"+hiGold.ToString();	
	}
	
	void Update(){
		currentGold 	= _GM.instance.GetCurrentGold();
		goldText.text 	= "0000000"+currentGold.ToString();	
		hiGoldText.text = "0000000"+hiGold.ToString();	
	}
	
}
