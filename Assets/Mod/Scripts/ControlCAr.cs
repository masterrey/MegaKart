using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
public class ControlCAr : MonoBehaviour
{
    [Header("Movement Settings")]
    [Min(0.001f), Tooltip("Top speed attainable when moving forward.")]
    public float TopSpeed;

    [Tooltip("How quickly the kart reaches top speed.")]
    public float Acceleration;

    [Min(0.001f), Tooltip("Top speed attainable when moving backward.")]
    public float ReverseSpeed;

    [Tooltip("How quickly the kart slows down when the brake is applied.")]
    public float Braking;

    Rigidbody rigidbody;

    IInput[] m_Inputs;
    public WheelCollider wheelColliderTD;
    public WheelCollider wheelColliderTE;
    public WheelCollider wheelColliderDD;
    public WheelCollider wheelColliderDE;

    public InputData Input { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        m_Inputs = GetComponents<IInput>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GatherInputs();
        if (Input.Accelerate)
        {
            //rigidbody.AddForce(Vector3.forward * 1000);
            wheelColliderTD.motorTorque = 1000;
            wheelColliderTE.motorTorque = 1000;
        }
        else
        {
            wheelColliderTD.motorTorque = 000;
            wheelColliderTE.motorTorque = 000;
        }
        if (Input.Brake)
        {
            
            wheelColliderTD.brakeTorque = 300;
            wheelColliderTE.brakeTorque = 300;
            wheelColliderDD.brakeTorque = 900;
            wheelColliderDE.brakeTorque = 900;
        }
        else
        {
            wheelColliderTD.brakeTorque = 00;
            wheelColliderTE.brakeTorque = 00;
            wheelColliderDD.brakeTorque = 00;
            wheelColliderDE.brakeTorque = 00;
        }

        

        wheelColliderDD.steerAngle = Input.TurnInput * 50;
        wheelColliderDE.steerAngle = Input.TurnInput * 50;
    }

    void GatherInputs()
    {
        // reset input

        Input = new InputData();
       

        // gather nonzero input from our sources
        for (int i = 0; i < m_Inputs.Length; i++)
        {
            Input = m_Inputs[i].GenerateInput();
           
        }
    }
}
