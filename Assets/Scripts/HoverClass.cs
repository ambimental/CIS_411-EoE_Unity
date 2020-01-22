using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HoverClass : MonoBehaviour {
    //declarations of object names
    public SpriteRenderer rend;
    public int originalOrder;

    //method that runs on start, used to generate initial settings and objects
    void Start()
    {
        //allowing collisons to happen, which allows mouse detection
        Physics.queriesHitTriggers = true;
        //setting the SpriteRenderer to the current object's renderer
        rend = GetComponent<SpriteRenderer>();
    }

    //Function called when the mouse enters the collider
    private void OnMouseEnter()
    {
        //storing the original sorting order
        originalOrder = rend.sortingOrder;
        //setting the max sorting order, so it will always appear on top
        rend.sortingOrder = 999;
        //increasing the renderer's localScale by 50% while the mouse is on it
        rend.transform.localScale += new Vector3(0.4F, 0.4F);
    }

    private void OnMouseExit()
    {
        //restting the sorting order to the stored original value
        rend.sortingOrder = originalOrder;
        //resetting the localScale to its original value via reducing it by 50%
        rend.transform.localScale -= new Vector3(0.4F, 0.4F);
    }
}