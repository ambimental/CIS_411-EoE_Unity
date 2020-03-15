using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class jsut displays a image on the deck in the player canvas
 * it is instantiated in the Game Manager and called in the startGameLoopFunction
     */
public class DisplayOneCard : MonoBehaviour
{

    //creates a sprite renderer
    private SpriteRenderer sr;
    //creates a 2D texture to assign the JPeg to
    public Texture2D texSprite;
    //creates a sprite to assign the 2D texture to
    public Sprite tempSprite;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * This finds the Deck Draw Placement UI object in the Playerboard Player Canvas, and adds a new Sprite Component to it. This will be used to render the Sprite on the screen
         * and tells it where to place it, which is the Deck Draw Placement
         * we placed the sr object up here becasue if we kept it with other code it would create a reference problem
         */
        sr = GameObject.Find("Region Card Placement").AddComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayCard()
    {
        /*This goes to our resource folder, searches for the item called "Out-Of-Cards" in the sprite folder that is inside the resource folder
         * and assigns that image which stored as a "2d texture" which is an option in the inspector pane and assignes it to a Texture2D called texSprite*/
        texSprite = Resources.Load<Texture2D>("Sprites/Out-Of-Cards");
        //This creates a sprite using the 2D texture texSprite above. All the code inside the rect parenthesis is just typical mumbo jumbo
        tempSprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.6666f);
        //this assigns the tempSprite we just created to the Sprite Renderer "sr" we created in the Start() function.
        sr.sprite = tempSprite;
        //This is to make sure that the sprite renderer is placed above everything else on the canvas so it is visible
        sr.sortingOrder = 9;
        //this is just to make sure the sorting layer is set to default which is naturally is
        sr.sortingLayerName = "Default";
    }
}
