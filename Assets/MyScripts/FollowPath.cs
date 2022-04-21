using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class allow objects to follow a series of game objects named "Path (x)" where x it's the next piece to follow.
public class FollowPath : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    int currentTarget=0;
    void Update()
    {
        //Follow the path
        FollowPath_Piece();
    }

    void FollowPath_Piece()
    {
        GameObject PathTrack = GameObject.Find("Path ("+currentTarget+")");
        if(PathTrack!=null){
        Vector3 targetPosition = new Vector3(PathTrack.transform.position.x,PathTrack.transform.position.y,PathTrack.transform.position.z);
        Vector3 currentPosition = transform.position;
        transform.position = Vector3.MoveTowards(currentPosition,targetPosition, speed);

        // Determine which direction to rotate towards
        Vector3 targetDirection = targetPosition - currentPosition;

        // The step size is equal to speed times frame time.
        float singleStep = 5f * Time.deltaTime;
        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(currentPosition, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        

        float dist = Vector3.Distance(targetPosition, currentPosition);

        if(dist<=0.5){
            currentTarget++;
        }     
        }  
    }

    public void ResetTarget(){
        currentTarget=0;
    }
}
