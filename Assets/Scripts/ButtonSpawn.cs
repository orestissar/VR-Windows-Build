using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ButtonSpawn : MonoBehaviour
{
    public GameObject animation;
    //public List<GameObject> disable;
    public GameObject Spawner;
    List<GameObject> Alembics;
    int count;
    int play = 0;
    float speed;

    int showav = 0;
    List<GameObject> resetIcons;

    private void Start()
    {
        count = Spawner.transform.childCount;              
    }

    public void AnimationSpawn()
    {
        play = 0;
        for(int i = 0; i < count; i++)
        {            
            Spawner.transform.GetChild(i).gameObject.SetActive(false);
        }
        animation.SetActive(true);
        animation.GetComponent<PlayableDirector>().enabled = true;
        //Debug.Log(animation.transform.GetChild(0).name);
        //
        //foreach (GameObject reset in GameObject.FindGameObjectsWithTag("ResetIcon"))
        //{
        //    Debug.Log(reset.name);
        //    reset.SetActive(false);            
        //}


    }


    void doPlay()
    {
        animation.GetComponent<PlayableDirector>().enabled = true;
    }

    public void doPause()
    {
        animation.GetComponent<PlayableDirector>().enabled = false;
    }


    void PlayPause()
    {
        play += 1;
        if (play % 2 == 1)
        {
            doPause();
        }
        if (play % 2 == 0)
        {
            doPlay();
        }
    }



    //public void exitplay()
    //{        
    //    Application.Quit();
    //}

    public void SliderControl(float value)
    {

        speed = value;

        PlayableDirector director = animation.GetComponent<PlayableDirector>();
        director.playableGraph.GetRootPlayable(0).SetSpeed(speed / 10);
        if (speed <= 0.5)
        {
            speed = 1;
        }
        Debug.Log(speed);
    }







}

