using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggler : MonoBehaviour
{

    int click = 0;
   public GameObject toggle;
      

    public void clicks()
    {

        if (click % 2 == 0)
        {
            toggle.SetActive(true);
            
        }

        if (click % 2 == 1)
        {
            
            toggle.SetActive(false);
        }

        click += 1;
       
    }


}
