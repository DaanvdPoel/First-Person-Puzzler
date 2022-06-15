using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeswitchCameraEffects : MonoBehaviour
{
    Camera cam;
    public AnimationCurve fov_curve;
    public float animation_length = 1, animation_intensity = 1;
    public float baseFov = 60;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    public void PerformAnimation()
    {
        StartCoroutine(PerformAnim());
    }
    
    IEnumerator PerformAnim()
    {
        for (float t = 0; t < animation_length; t += Time.deltaTime)
        {
            cam.fieldOfView = baseFov + (baseFov * (fov_curve.Evaluate(t/animation_length)*animation_intensity));
            yield return null;
        }
        cam.fieldOfView = baseFov;
        
    }
}
