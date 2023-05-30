using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 to 1

        Debug.Log(rawSinWave);

        movementFactor = (rawSinWave + 1f) / 2f; // goes from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
 