using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class consolDIsplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text sceneNameText;
    // Update is called once per frame
    private 

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Get the name of the current scene
        string sceneName = currentScene.name;

        // Display the scene name in the UI Text component
        sceneNameText.text = "Current Scene: " + sceneName;
    }
}
