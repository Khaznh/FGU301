using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PondContainer : MonoBehaviour
{
    public List<FishStats> listFish;

    public FishStats GetRandomFish() 
    {
        if (listFish == null || listFish.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, listFish.Count);

        return listFish[randomIndex];
    }
}
