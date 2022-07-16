using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginningCutscene : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(LoadGameScene());
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }

    }

    IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(19f);
        Debug.Log("waiting time over");
        SceneManager.LoadScene(2);
    }
}
