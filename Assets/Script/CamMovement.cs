using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float XSens;
    public float YSens;

    public Transform LookingPoint;

    public float RotationY;
    public float RotationX;

    bool isCameraLooked = false;

    // Start is called before the first frame update
    void Start()
    {
        camerLooken();
        RotationX = 45;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isCameraLooked)
        {
            camerUnlooken();
        }
        else
        {
            camerLooken();
        }

        RotationX += Input.GetAxisRaw("Mouse X") * Time.deltaTime * XSens;
        RotationY -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * YSens;

        RotationY = Mathf.Clamp(RotationY, -90, 90);
        transform.rotation = Quaternion.Euler(RotationY, RotationX, 0);

        LookingPoint.rotation = Quaternion.Euler(0, RotationX, 0);

    }

    void camerLooken()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCameraLooked = true;
    }

    void camerUnlooken()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCameraLooked = false;
    }
}
