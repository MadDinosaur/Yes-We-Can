using UnityEngine;

public class UIFollow : MonoBehaviour
{

    public Transform followerIndicator;
    public float threshold;
    public float speed = 1;
    public float min_Distance = 0.1f;

    private bool _adjust;
    
    private void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, followerIndicator.position)+" - " + threshold);
        if (Vector3.Distance(transform.position, followerIndicator.position) > threshold) _adjust = true;
        // Debug.Log(followerIndicator.rotation);
        if (_adjust)
        {
            transform.position = Vector3.Slerp(transform.position, followerIndicator.position, speed);
            //transform.rotation = new Quaternion(followerIndicator.rotation.x, followerIndicator.rotation.y, 0, 1f);
            transform.rotation = followerIndicator.rotation;
            if (Vector3.Distance(transform.position, followerIndicator.position) < min_Distance) _adjust = false;
        }
    }
}
 