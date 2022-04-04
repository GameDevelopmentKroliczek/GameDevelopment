using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    Rigidbody rb;
    asteroidController asteroid;
    public float YPosition = 0f;
    public float XPosition = 0f;
    public float ZPosition = 0f;
    public bool isPlaying = false;
    private Vector2 screenBounds;


    Vector3 RotationAngleLeft;
    Vector3 RotationAngleRight;
    Vector3 StopAngle;
    public Vector3 lastMousePosition;
    public float lastMousePosX;
    Vector3 MousePosition;



    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //UI_EndScreen endScreen = gameObject.GetComponent<UI_EndScreen>();
        isPlaying = true;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        RotationAngleLeft = new Vector3(0, 220, 180);
        RotationAngleRight = new Vector3(0, 140, 180);
        StopAngle = new Vector3(0, 180, 180);

    }

    public void Update()
    {

        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.z = 0f;
        if (isPlaying == true)
        {
            //Spielerposition wird mit Mausposition gleichgesetzt
            rb.transform.position = MousePosition;

            lastMousePosX = lastMousePosition.x;
            //Dreht den Spieler um die Entfernung in Grad
            if (Input.GetAxis("Mouse X") < -0.1)
            {
                Quaternion RotationLeft = Quaternion.Euler(RotationAngleLeft);
                transform.rotation = Quaternion.Slerp(transform.rotation, RotationLeft, 0.1f);
            }

            if (Input.GetAxis("Mouse X") > 0.1)
            {
                Quaternion RotationRight = Quaternion.Euler(RotationAngleRight);
                transform.rotation = Quaternion.Slerp(transform.rotation, RotationRight, 0.1f);
            }

            //Dreht den Spieler um wieder gerade wenn sich die Maus nicht bewegt
            if (Input.GetAxis("Mouse X") > -0.1 && Input.GetAxis("Mouse X") < 0.1)
            {
                Quaternion StopDeltaRotation = Quaternion.Euler(StopAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, StopDeltaRotation, 0.01f);
            }

        }
    }



    public void OnTriggerEnter(Collider collider)
    {
        //Spiel wird gestoppt bei Kollision mit Asteroid
        asteroidController asteroid = collider.GetComponent<asteroidController>();
        //collision.gameObject.tag == "Spawnable";
        if (asteroid != null)
        {
            isPlaying = false;
            Time.timeScale = 0f;
           // TriggerEndscreen();

        }

    }
}
