using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    Vector3 resetPosition;
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 resetPosition = new Vector3(1.7f, 2.8f, 16.9f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }
}
