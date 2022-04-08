using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSinc : MonoBehaviour
{
    public WheelCollider wheelCollider;
    public Transform wtransform;
    public TrailRenderer trail;
    private WheelHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wtransform.position = pos;
        wtransform.rotation = rot;

        wheelCollider.GetGroundHit(out hit);

        if (Mathf.Abs(hit.sidewaysSlip) > 0.1f || Mathf.Abs(hit.forwardSlip) > 0.4f)
        {
            trail.emitting = true;
        }
        else
        {
            trail.emitting = false;
        }
    
    }
}
