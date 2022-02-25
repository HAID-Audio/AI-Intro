using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject position0;
    public GameObject position1;

    
    public float speed = 1.5f;
    public void Start()
    {
            
    }
    // Update is called once per frame
    private void Update()
    {

         AIMoveTowards();
        //Method 1 X + -
        #region Method 1
        //if cube is on left of dimond, move right

        /*
        if (transform.position.x < position0.transform.position.x)
        {
            
            AIPosition.x += (1 * Time.deltaTime);           
        }
        else
        {           
            AIPosition.x -= (1 * Time.deltaTime);           
        }
        transform.position = AIPosition;
        */
        #endregion
        // Method 2 Y + -
        #region Method 2
        /*
        if (transform.position.y < position0.transform.position.y)
        {
            transform.position += (Vector3) Vector2.up * 1 * Time.deltaTime;
        }
        else
        {    
        transform.position -= (Vector3)Vector2.up * 1 * Time.deltaTime;       
        }
        */
        #endregion
        //Method 3
        //direction from a to b
        //is B - A
        // X = B - A
        #region Method 3
        /*
        Vector2 directionToPos0 = (position0.transform.position - transform.position);
        directionToPos0.Normalize();
        transform.position += (Vector3)directionToPos0 * 1 * Time.deltaTime;
        */
        #endregion

    }
    private void AIMoveTowards()
    {
        Vector2 AIPosition = transform.position;
        Vector2 directionToPos0 = (position0.transform.position);
        directionToPos0.Normalize();
        transform.position += (Vector3)directionToPos0 * speed * Time.deltaTime;
    }


}
