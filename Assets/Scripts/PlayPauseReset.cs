using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPauseReset : MonoBehaviour
{
   public GameObject Play;
    
   int playclick;
    
    public void ResetPause()
    {
        
        if (playclick % 2 == 0)
        {
            Play.SetActive(true);

        }
        if (playclick % 2 == 1)
        {
            Play.SetActive(false);
        }
        playclick += 1;
    }

    public void resetnext()
    {        
        
        Play.SetActive(false);        

    }

}
