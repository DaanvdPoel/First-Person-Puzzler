using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimator : MonoBehaviour
{
    [SerializeField] Material[] mats;
    public float delayBetween = 1;
    MeshRenderer mr;
    int i;
    float t;
    
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > delayBetween)
        {
            if (i == mats.Length-1) {i = 0;}
            else {i++;}
            UpdateMaterial();
            t = 0;
        }
    }
    
    void UpdateMaterial()
    {
        Material[] meshmats = mr.sharedMaterials; 
        meshmats[1] = mats[i];
        mr.sharedMaterials = meshmats;
    }
}
