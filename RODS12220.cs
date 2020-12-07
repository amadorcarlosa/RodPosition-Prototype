using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RODS12220 : MonoBehaviour
{
    public GameObject Name;
    public bool Marker;


    private bool moving2;
    private bool finished;


    private string pop;



    private float startPosX2;
    private float startPosY2;
    private float DifferenceofX;
    private float DifferenceofY;

    private Vector3 resetPosition2;
    void Start()
    {

        resetPosition2 = this.transform.localPosition; // This locks the initial position of the rod
       


    }

    // Update is called once per frame
    void Update()
    {
        if (finished == false)
        {
            if (moving2)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                gameObject.transform.position = new Vector3(mousePos.x - startPosX2, mousePos.y - startPosY2, gameObject.transform.position.z); //This drags the rod


            }

        }
      

    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //This connects mouse poistions to the rod

            startPosX2 = mousePos.x - transform.position.x;
            startPosY2 = mousePos.y - transform.position.y;

            moving2 = true;
        }
    }
    private void OnMouseUp()
    {
        moving2 = false;

       
        pop = tag;
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(pop);//local array from a game object to find target rods
     

        Debug.Log("update");

        foreach (GameObject go in gos)
        {




            float curDistancex = (Mathf.Abs(go.transform.position.x - this.transform.position.x));
           float curDistancey = (Mathf.Abs(go.transform.position.y - this.transform.position.y)); //calculates each rod and distance fromtarget when released

            if (curDistancex <= 0.2f && curDistancey <= 0.2f && go.name != name && this.gameObject.layer != go.layer) //if the rod is close to the position/ and is not itself and on a diiferrent lyer this is true
            {
                print("name" + name + "New Position" + go.transform.position);
                this.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
                go.SetActive(false);
                finished = true;
                
               break;
                
            }
            else
               
            {

            }
        }
        if (finished == false)
        {
            this.transform.localPosition = new Vector3(resetPosition2.x, resetPosition2.y, resetPosition2.z);
        }

    }
   
}
    
   

 
