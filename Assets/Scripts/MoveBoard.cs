//WILL BE USED TO MOVE THE BOARD AROUND, RATHER THAN CHANGIN SCENES

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoard : MonoBehaviour {

    //the game object Board
    public GameObject Board;

    //to change the x and y position of the canvas
    public RectTransform GameBoard;

    //X and Y coordinates of the desired board sections
    public float playerRotationX = 0, playerRotationY = 0;
    public float computerOneRotationX = 0, computerOneRotationY = -10;
    public float computerTwoRotationX = 7, computerTwoRotationY = 0;
    public float computerThreeRotationX = 0, computerThreeRotationY = 10;

    public float currentX, currentY; //z will always be 0

    //the start function to initiate the game object
    private void Start()
    {
        Board = GameObject.Find("Board and Image");
        

        //gets the current x and y rotation coordinates
        //currentX = Board.transform.eulerAngles.x;
        //currentY = Board.transform.eulerAngles.y;

        //Debug.Log(currentX + " " + currentY);
    }

    //player board locations and movement
    public void PlayerBoardLocation() //(0, 0, 0)
    {
        //check for current x,y,z rotations and then determine which way to move to the player board
        if (currentX == computerOneRotationX && currentY == computerOneRotationY) //(0, -10, 0)
        {
            Board.transform.Rotate(0, 10, 0);

            currentX = playerRotationX; //sets x and y
            currentY = playerRotationY;

            //Debug.Log(currentX + " " + currentY);
        }
        else if (currentX == computerTwoRotationX && currentY == computerTwoRotationY) //(7, 0, 0)
        {
            Board.transform.Rotate(-7, 0, 0);

            currentX = playerRotationX; //sets x and y
            currentY = playerRotationY;

            //Debug.Log(currentX + " " + currentY);
        }
        else if (currentX == computerThreeRotationX && currentY == computerThreeRotationY) //(0, 10, 0)
        {
            Board.transform.Rotate(0, -10, 0);

            currentX = playerRotationX; //sets x and y
            currentY = playerRotationY;

            //Debug.Log(currentX + " " + currentY);
        }
    }

    //computer one locations and movement
    public void ComputerOneBoardLocation() //(0, -10, 0)
    {
        //check for current x,y,z rotations and then determine which way to move to the player board
        if (currentX == playerRotationX && currentY == playerRotationY) //(0, 0, 0)
        {
            //Board.transform.Rotate(0, -10, 0);
            GameBoard.transform.localScale = new Vector3(0, 0, 0);

            currentX = computerOneRotationX; //sets x and y
            currentY = computerOneRotationY;

            //Debug.Log(currentX + " " + currentY);
        }
        else if (currentX == computerTwoRotationX && currentY == computerTwoRotationY) //(7, 0, 0)
        {
            Board.transform.Rotate(-6.893f, -10.0731f, 1.213f);
            //Board.transform.localPosition = new Vector3(0, 0, 0);

            currentX = computerOneRotationX; //sets x and y
            currentY = computerOneRotationY;

           // Debug.Log(currentX + " " + currentY);
        }
        else if (currentX == computerThreeRotationX && currentY == computerThreeRotationY) //(0, 10, 0)
        {
            Board.transform.Rotate(0, -20, 0);

            currentX = computerOneRotationX; //sets x and y
            currentY = computerOneRotationY;

            //Debug.Log(currentX + " " + currentY);
        }
    }

    //computer two locations and movement
    public void ComputerTwoBoardLocation() //(7, 0, 0)
    {
        //check for current x,y,z rotations and then determine which way to move to the player board
        if (currentX == playerRotationX && currentY == playerRotationY) //(7, 0, 0)
        {
            Board.transform.Rotate(7, 0, 0);

            currentX = computerTwoRotationX; //sets x and y
            currentY = computerTwoRotationY;

           // Debug.Log(currentX + " " + currentY);
        }
        else if (currentX == computerOneRotationX && currentY == computerOneRotationY) //(0, -10, 0)
        {
            Board.transform.Rotate(7, 10, 0);

            currentX = computerTwoRotationX; //sets x and y
            currentY = computerTwoRotationY;

           // Debug.Log(currentX + " " + currentY);
        }
        else if (currentX == computerThreeRotationX && currentY == computerThreeRotationY) //(0, 10, 0)
        {
            Board.transform.Rotate(7, -10, 0);

            currentX = computerTwoRotationX; //sets x and y
            currentY = computerTwoRotationY;

            //Debug.Log(currentX + " " + currentY);
        }
    }


    //computer three locations and movement
    public void ComputerThreeBoardLocation() //(0, 10, 0)
    {
        //check for current x,y,z rotations and then determine which way to move to the player board
        if (currentX == playerRotationX && currentY == playerRotationY) //(0, 0, 0)
        {
            Board.transform.Rotate(0f, 10f, 0f);

            currentX = computerThreeRotationX; //sets the x and y
            currentY = computerThreeRotationY;
        }
        else if (currentX == computerOneRotationX && currentY == computerOneRotationY) //(0, -10, 0)
        {
            Board.transform.Rotate(0f, 20f, 0f);

            currentX = computerThreeRotationX; //sets the x and y
            currentY = computerThreeRotationY;
        }
        else if (currentX == computerTwoRotationX && currentY == computerTwoRotationY) //(7, 0, 0)
        {
            Board.transform.Rotate(-6.895f, 10.074f, -1.213f);

            currentX = computerThreeRotationX; //sets the x and y
            currentY = computerThreeRotationY;
        }
    }
}
