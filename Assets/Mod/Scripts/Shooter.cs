using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    IInput[] m_Inputs;
    public ItemReceived itemReceived;
    public GameObject target;
    public InputData Input { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        m_Inputs = GetComponents<IInput>();
    }

    // Update is called once per frame
    void Update()
    {
        GatherInputs();

        if (Input.Fire)
        {
            GameObject received = itemReceived.GetItem();
            if (received != null)
            Instantiate(received, target.transform);
        }

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
