using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    [SerializeField] private float minRotationSpeed;
    [SerializeField] private float maxRotationSpeed;
    private Vector3 rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = new Vector3(Random.Range(minRotationSpeed, maxRotationSpeed), Random.Range(minRotationSpeed, maxRotationSpeed), Random.Range(minRotationSpeed, maxRotationSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
