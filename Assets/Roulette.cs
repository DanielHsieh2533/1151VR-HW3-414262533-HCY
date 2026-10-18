using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    float rotSpeed = 0;
    float accel = 1;
    float buttonDown = -1;
    static System.Random rnd = new System.Random();
    float time = 0;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            rotSpeed += accel;
            buttonDown = 0;
            time = rnd.Next(100, 151);
        }
        else if(buttonDown <= time && buttonDown >= 0)
        {
            rotSpeed += accel;
            buttonDown += accel;
        }
        transform.Rotate(0, 0, this.rotSpeed);
        this.rotSpeed *= 0.96f;
        if(rotSpeed < 0.001)
        {
            rotSpeed = 0;
            buttonDown = -1;
        }
    }
}
