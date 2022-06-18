using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public int rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    // Rotate the camera
    void Rotate()
    {
        float horizantalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizantalInput * Time.deltaTime * rotationSpeed); 

    }
}
