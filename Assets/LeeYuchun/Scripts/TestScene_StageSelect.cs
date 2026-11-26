using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScene_StageSelect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene("Scenes/SceneTitle");
    }
}
