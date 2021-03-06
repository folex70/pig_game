﻿using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class _GM : MonoBehaviour {

    private int _currentLevel;
	private int _currentGold;
	private int _totalGold;

    public static _GM instance;

    void Awake()
    {
        if (instance == null) {
			//DontDestroyOnLoad(gameObject);
			instance = this;
		} 
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
    }

	public void SetCurrentGold(int num)
    {
        _currentGold = num;
    }

    public int GetCurrentGold()
    {
        return _currentGold;
    }
	
	public void SetGold(int num)
    {
        _totalGold = num;
    }

    public int GetGold()
    {
        return _totalGold;
    }
	
    public void SetLevel(int num)
    {
        _currentLevel = num;
    }

    public int GetLevel()
    {
        return _currentLevel;
    }

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		PlayerData data = new PlayerData ();
		//data.maxScore = _maxScore;
		data.totalGold = _totalGold;
		data.Gold = _currentGold;

		bf.Serialize (file, data);
		file.Close ();


	}

	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			//_maxScore = data.maxScore;
			_totalGold = data.totalGold;
			_currentGold = data.Gold;

		}

	}
   
}

[Serializable]
class PlayerData
{
	public int totalGold;
	public int Gold;
}