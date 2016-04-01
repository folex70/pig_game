using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Text goldText;
	public int currentGold;

	// Use this for initialization
	void Start () {
		currentGold = _GM.instance.GetCurrentGold();
	}
	
	// Update is called once per frame
	void Update () {
		currentGold = _GM.instance.GetCurrentGold();
		goldText.text = "0000000"+currentGold.ToString();
	}
}
