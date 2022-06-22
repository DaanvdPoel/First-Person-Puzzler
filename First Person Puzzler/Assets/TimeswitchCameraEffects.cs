using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeswitchCameraEffects : MonoBehaviour
{
    Camera cam;
    public AnimationCurve fov_curve;
    public float animation_length = 1, animation_intensity = 1;
    public float baseFov = 60;
    public Image flash;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        if (test)
        {
            foreach (GameObject pa in past)
            {
                pa.SetActive(tog);
            }
            foreach (GameObject pr in present)
            {
                pr.SetActive(!tog);
            }
        }
    }
    
    
    
    public bool test;
    public GameObject[] past,present;
    bool tog;
    void Update()
    {
        if ((test) && (Input.GetKeyDown(KeyCode.P)))
        {
            PerformAnimation();
            //test = false;
            tog = !tog;
            foreach (GameObject pa in past)
            {
                pa.SetActive(tog);
            }
            foreach (GameObject pr in present)
            {
                pr.SetActive(!tog);
            }
        }
    }
    
    
    // Update is called once per frame
    public void PerformAnimation()
    {
        StartCoroutine(PerformAnim());
    }
    
    IEnumerator PerformAnim()
    {
        flash.color = Color.white;
        for (float t = 0; t < animation_length; t += Time.deltaTime)
        {   
            Color c = flash.color;
            c.a = Mathf.MoveTowards(c.a, 0, (t / (animation_length*8)));
            flash.color = c;
            
            cam.fieldOfView = baseFov + (baseFov * (fov_curve.Evaluate(t/animation_length)*animation_intensity));
            yield return null;
        }
        cam.fieldOfView = baseFov;
        
    }
}
