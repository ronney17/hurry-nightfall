using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSkybox : MonoBehaviour
{
    public float Skyboxspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * Skyboxspeed);
    }
}
