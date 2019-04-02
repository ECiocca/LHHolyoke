using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour {
    float mouseX;
    float mouseY;
    public float mouseSensitivity = 100.0f;
    public float rotY;
    public float rotX;
    public float rotZ = 0;
    float currentX;
    float currentY;
    float currentZ;
    public float speed = .5f;
    public bool isAirplaneChild;
    public GameObject airplane;
    public GameObject shoot;
    // Start is called before the first frame update
    void Start()
    {
        rotY = this.gameObject.transform.localRotation.y;
        rotX = this.gameObject.transform.localRotation.x;
        currentX = 0;
        currentY = 0;
    }

    // Update is called once per frame
    void Update()
    {

        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        if (gameObject.transform.parent == airplane.transform)
        {
            isAirplaneChild = true;
        }

        if (isAirplaneChild == true)
        {
            rotY = Mathf.Clamp(rotY, -30, 30);
            rotX = Mathf.Clamp(rotX, -30, 30);
        }

        if (isAirplaneChild == false)
        {
            var fps = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            if (fps != null)
            {
                fps.enabled = true;
            }
            if (shoot != null)
            {
                shoot.SetActive(false);
            }
        }
    
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, rotZ);
        transform.localRotation = localRotation;

        currentX += rotX * Time.deltaTime;
        currentY += rotY * Time.deltaTime;
        currentZ = 0;

        if (isAirplaneChild == true)
        {
            airplane.transform.rotation = Quaternion.Euler(currentX, currentY, currentZ);
            var fps = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            if (fps != null)
            {
                fps.enabled = false;
            }
            if (shoot != null)
            {
                shoot.SetActive(false);
            }
        }
    }
}
