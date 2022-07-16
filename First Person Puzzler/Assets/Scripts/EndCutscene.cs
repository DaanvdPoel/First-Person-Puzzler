using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutscene : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(LoadBackIntoMainMenu());
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator LoadBackIntoMainMenu()
    {
        yield return new WaitForSeconds(48f);
        SceneManager.LoadScene(0);
    }
}


