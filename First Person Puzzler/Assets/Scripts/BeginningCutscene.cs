using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginningCutscene : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LoadGameScene());
       

    }

    IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(19f);
        Debug.Log("waiting time over");
        SceneManager.LoadScene(2);
    }
}
