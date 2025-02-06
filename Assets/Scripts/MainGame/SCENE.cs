using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCENE : MonoBehaviour
{
    public string targetSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {
        // Load the target scene
        SceneManager.LoadScene(targetSceneName);
    }
}
