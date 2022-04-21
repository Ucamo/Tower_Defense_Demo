using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls Bullets/Projectiles, it will follow it's target or set as inactive after it's lifetime it's up.
public class BulletController : MonoBehaviour
{
    [SerializeField]
    float lifeTime;
    [SerializeField]
    float speed;
    [SerializeField]
    int damage;
    [SerializeField]
    GameObject target;

    void OnEnable() {
        StartCoroutine(SeflHide());
    }
    IEnumerator SeflHide() {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
        target=null;
    }

    void Update(){
        if(target!=null){
            FollowTarget();
        }else{
            gameObject.SetActive(false);
        }
    }

    void FollowTarget(){
        if(target!=null && target.activeSelf){
        Vector3 targetPosition = new Vector3(target.transform.position.x,target.transform.position.y,target.transform.position.z);
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
            target=null;
        }
        }        
    }

    public void SetTarget(GameObject _target){
        target=_target;
    }

    public int GetDamage(){
        return damage;
    }
}
