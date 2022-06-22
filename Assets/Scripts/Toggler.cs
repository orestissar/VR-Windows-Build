using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggler : MonoBehaviour
{
       
    public GameObject toggle;
   
    public void clicks()
    {
        if (toggle.activeInHierarchy)
        {
            toggle.SetActive(false);
        }
       else if (!toggle.activeInHierarchy)
        {
            toggle.SetActive(true);
        }
    }
}
