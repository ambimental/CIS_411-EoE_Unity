/*
 *  @class      HoverClass.cs
 *  @purpose    When hovering over a card it gets bigger
 *  @author     CIS 411 
 *  @date       2020/4/1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverClass : MonoBehaviour
{

    //declarations of object names
    private SpriteRenderer rend;
    private int originalOrder;

    /*
     * @name    Start
     * @purpose sets colliders to true and initializes objects
     * 
     * @return  Void
     */
    void Start()
    {
        //allowing collisons to happen, which allows mouse detection
        Physics.queriesHitTriggers = true;
        //setting the SpriteRenderer to the current object's renderer
        Rend = GetComponent<SpriteRenderer>();
    }

    /*
     * @name    OnMouseEnter
     * @purpose When the mouse enters the object the sorting order is changed and the object is bigger
     * 
     * @return  Void
     */
    public void OnMouseEnter()
    {
        //storing the original sorting order
        OriginalOrder = Rend.sortingOrder;
        //setting the max sorting order, so it will always appear on top
        Rend.sortingOrder = 999;
        //increasing the renderer's localScale by 50% while the mouse is on it
        Rend.transform.localScale += new Vector3(0.4F, 0.4F);
    }

    /*
     * @name    OnMouseExit
     * @purpose When the mouse exits the object the sorting order and size return to normal
     * 
     * @return  Void
     */
    public void OnMouseExit()
    {
        //restting the sorting order to the stored original value
        Rend.sortingOrder = OriginalOrder;
        //resetting the localScale to its original value via reducing it by 50%
        Rend.transform.localScale -= new Vector3(0.4F, 0.4F);
    }

    //accessors and mutators
    public SpriteRenderer Rend { get => rend; set => rend = value; }
    public int OriginalOrder { get => originalOrder; set => originalOrder = value; }
}