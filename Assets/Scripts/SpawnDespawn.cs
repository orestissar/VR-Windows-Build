using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDespawn : MonoBehaviour
{
    int click = 0;
    public GameObject spawn;

    public void Swap()
    {
        if (click % 2 == 0)
        {
            spawn.SetActive(true);
        }
        else if (click % 2 == 1)
        {
            spawn.SetActive(false);
        }

        click += 1;
    }
}
