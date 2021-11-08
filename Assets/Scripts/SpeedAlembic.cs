using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;


public class SpeedAlembic : MonoBehaviour
{
    //public float speed;
    float speed;

   
    public void SliderControl(float value)
    {

        speed = value;
        GameObject active = GameObject.FindGameObjectWithTag("Player");
        PlayableDirector director = active.GetComponent<PlayableDirector>();
        //director.enabled = false;
        director.playableGraph.GetRootPlayable(0).SetSpeed(speed/10);
        if (speed <= 0.5)
        {
            speed = 1;
        }
        Debug.Log(speed);
    }


}


