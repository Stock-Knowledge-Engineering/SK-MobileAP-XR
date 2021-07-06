using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool isModule;
    public DataManager dataManager;
    public string levelName;
    public float timeAtLevel;

    private void Start()
    {
        if (isModule == true)
        {
            dataManager.Load();
        }
        dataManager = GameObject.FindObjectOfType<DataManager>();
    }

    private void Update()
    {
        if (isModule == true)
        {
            timeAtLevel += Time.deltaTime;
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }
    
    public void OpenURL(string URLLink)
    {
        Application.OpenURL(URLLink);
    }

    public void Logout(string scene)
    {
        PlayerPrefs.SetString("CurrentUsername", "");
        PlayerPrefs.SetString("CurrentPassword", "");
        PlayerPrefs.SetString("IsRemembertrue", "false");

        SceneManager.LoadScene(scene);
    }
}
