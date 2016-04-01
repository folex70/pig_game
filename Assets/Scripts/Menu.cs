using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void menuStart(){
		SceneManager.LoadScene("game");  
	}
	
	public void menuExit(){
		//sair
		Application.Quit();
	}
	
	public void menuCredits(){
		SceneManager.LoadScene("credits");  
	}
	
	public void menuTitle(){
		SceneManager.LoadScene("menu");  
	}
}
