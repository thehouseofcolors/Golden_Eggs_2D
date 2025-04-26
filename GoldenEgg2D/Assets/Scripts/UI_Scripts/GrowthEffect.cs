using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthEffect : MonoBehaviour
{
    public float scale;
    public float maxScale = 1f;
    public float growthRate = 0.1f;

    void Start()
    {
        scale = 0.1f;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void Update()
    {
        if (scale < maxScale)
        {
            scale += growthRate * Time.deltaTime;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
