using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewScene : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadAScene()
    {
        Invoke("LoadASceneHelper", 0.5f);
    }

    public void ResetScene() 
    {
        Invoke("ResetSceneHelper", 0.5f);
    }

    public void ResetSceneHelper()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void LoadASceneHelper()
    {
        SceneManager.LoadScene(sceneToLoad);
        Destroy(gameObject); 
    }
}
