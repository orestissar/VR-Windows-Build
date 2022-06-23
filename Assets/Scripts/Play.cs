using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public GameObject Spawner;
    GameObject cur_animation;
    int count;
    int play = 0;

    public GameObject clickPlay;
   

    private void Start()
    {
        count = Spawner.transform.childCount;              
    }

    void doPlay()
    {
        cur_animation.GetComponent<PlayableDirector>().enabled = true;
    }

    void doPause()
    {
        cur_animation.GetComponent<PlayableDirector>().enabled = false;
    }

    [System.Obsolete]
    public void PlayPause()
    {
        for (int i = 0; i < count; i++)
        {
            if (Spawner.transform.GetChild(i).gameObject.active==true)
            {
                cur_animation = Spawner.transform.GetChild(i).gameObject;
            }
        }


        play += 1;
        if (play % 2 == 1)
        {
            doPause();
            clickPlay.SetActive(true);
            gameObject.GetComponent<Image>().enabled = false;
        }
        if (play % 2 == 0)
        {
            doPlay();
            clickPlay.SetActive(false);
            gameObject.GetComponent<Image>().enabled = true;
        }
    }

    public void resetPause()
    {
        play = 1;
        PlayPause();
    }


}
