using Unity.VisualScripting;
using UnityEngine;

public class OP_PlayerController : MonoBehaviour
{
    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 input = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z+transform.position.z));
        float halfWidth = cam.orthographicSize * cam.aspect;
       
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("halfwidth: " + halfWidth);
            Debug.Log("mouse x: " + input.x);
            Debug.Log("mouse unchanged: " + Input.mousePosition.x);
        }
        if (input.x >= -halfWidth && input.x <= halfWidth-transform.localScale.x)
        {
            transform.position = new Vector3(input.x, transform.position.y, transform.position.z);
        }else if (input.x < -halfWidth)
        {
            transform.position = new Vector3(-halfWidth, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(halfWidth, transform.position.y, transform.position.z);
        }
    }
}


