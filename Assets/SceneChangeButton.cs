using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeButton : MonoBehaviour
{
    public Scenechanger change;
    

    private void Start()
    {
        // Attach the button click listener
        //Button button = GetComponent<Button>();
        //button.onClick.AddListener(ChangeScene);
    }

    private void Update()
    {
        if (change.targetSceneName == "MovingTarget")
        {
            Debug.Log("Done!");
        }
    }

    public void ChangeScene()
    {
        // Load the target scene
        SceneManager.LoadScene(change.targetSceneName);
    }
}
