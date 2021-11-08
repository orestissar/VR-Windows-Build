using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSlider : MonoBehaviour
{
    public GameObject spawner;
    int count;

    private void Start()
    {
        count = spawner.transform.childCount;
    }



}
