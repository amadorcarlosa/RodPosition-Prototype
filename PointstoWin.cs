using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointstoWin : MonoBehaviour
{  
    private int currentPoints;
    private int pointsToWin;
    public GameObject rods;

    // Start is called before the first frame update
    void Start()
    {
        pointsToWin = rods.transform.childCount;
        print("Points to Win  " + pointsToWin);
    
    }


    // Update is called once per frame
    void Update()
    {
        if(currentPoints >= pointsToWin)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void AddPoints()
    {
        currentPoints++;
    }
}
