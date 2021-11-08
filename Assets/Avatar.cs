using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Avatar : MonoBehaviour
{
    public GameObject spawner;
    int count;
    int playclick;
    GameObject current;
    int showav=0;
    public GameObject Play;
    
    float speed=10;
    GameObject SSlider;    
    Slider slider;
    PlayableDirector director;


    private void Start()
    {
        count = spawner.transform.childCount;

        SSlider = GameObject.FindGameObjectWithTag("Speeder");
        slider = SSlider.GetComponent<Slider>();

    }

    private void Update()
    {
        for (int i = 0; i < count; i++)
        {
            if (spawner.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                current = spawner.transform.GetChild(i).gameObject;
            }
        }
        director = current.GetComponent<PlayableDirector>();
        director.playableGraph.GetRootPlayable(0).SetSpeed(speed / 10);
    }


    public void showavatar()
    {
        
        if (showav % 2 == 0)
        {
            //Debug.Log("ON");
            current.transform.GetChild(0).gameObject.SetActive(false);
            Play.SetActive(true);
        }
        if (showav % 2 == 1)
        {
            //Debug.Log("OFF");
            current.transform.GetChild(0).gameObject.SetActive(true);
            Play.SetActive(false);
        }                     
    
        showav += 1;

    }

    public void resetnext()
    {
        
        Play.SetActive(false);
        current.transform.GetChild(0).gameObject.SetActive(true);
        showav = 0;
        
    }


    public void SpeedControl(float value)
    {
        speed = value;
        //director = current.GetComponent<PlayableDirector>();
        
        //director.playableGraph.GetRootPlayable(0).SetSpeed(speed / 10);
        if (speed <= 0.5)
        {
            speed = 1;
        }
        //Debug.Log(speed);

    }

}



