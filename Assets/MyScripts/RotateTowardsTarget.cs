using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Set a target, Rotate facing that object.
public class RotateTowardsTarget : MonoBehaviour
{
    GameObject target;
    public float speed = 1.0f;
    
    void Update()
    {
        if(target!=null){
            // Determine which direction to rotate towards
            Vector3 targetDirection = target.transform.position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }else{
            target = gameObject.GetComponent<SpawnController>().GetTarget();
        }

    }
}
