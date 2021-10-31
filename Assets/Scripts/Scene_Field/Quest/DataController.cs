using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DataController : MonoBehaviour
{
   
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }
    public string GameDataFileName = "HansungOnData.json";
    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if(_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        LoadGameData();
        SaveGameData();
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        if (File.Exists(filePath))
        {
            print("불러오기 성공");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            print("새로운 파일 생성");
            _gameData = new GameData();
        }
    }
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);

        print("저장완료");
        print("2는 " + gameData.isClear2);
        print("3는 " + gameData.isClear3);
        print("4는 " + gameData.isClear4);
        print("5는 " + gameData.isClear5);
    }
    // Update is called once per frame
    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
