using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutscene : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LoadBackIntoMainMenu());
    }

    IEnumerator LoadBackIntoMainMenu()
    {
        yield return new WaitForSeconds(48f);
        SceneManager.LoadScene(0);
    }
}


