using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int launcherSceneNumber = 0;
    public IDataBase DB;
    public GameManager() {
        instance = this;
    }
    void Awake() {
        DB = new DBSim(); //Подключение к дб
        DontDestroyOnLoad(this.gameObject);
    }
    public void ChangeScene(int number) {
        SceneManager.LoadScene(number);
    }
}
