using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    private float speedControl = 1.0f;
    //private HoleMovement scoreController;


    // Update is called once per frame
    void Update()
    {
        //scoreController = GetComponent<HoleMovement>();

        if (((int)(HoleMovement.score) % 100) == 0 && HoleMovement.score != 0)
        {
            //Debug.Log("Inside Me");
            speedControl = speedControl + 0.05f;
            //Debug.Log(speedControl);
        }

        //Debug.Log(speedControl);
        transform.Translate((Vector3.up * (Time.deltaTime) * speedControl), Space.World);

    }
}
