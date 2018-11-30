using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> collectableItems;
    public List<string> collectedItems;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    private HealthBarController HealthBar;


    void Start() {
        controller = GetComponent<CharacterController>();
        HealthBar = FindObjectOfType<HealthBarController>();
    }

    void Update() {
        Movement();

    }



    private void OnTriggerStay(Collider other) {
        if (Input.GetKey("e")) {
            foreach (GameObject item in collectableItems) {
                if (other.gameObject == item) {
                    collectedItems.Add(other.name);
                    Destroy(other.gameObject);
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other) {
        print("bam");
        if (other.gameObject.CompareTag("Angel")) {
            HealthBar.DecreaseLife(10);

        }
    }


    void Movement() {

        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            //if (Input.GetButton("Jump")) {
            //    moveDirection.y = jumpSpeed;
            //}
        }

#if UNITY_EDITOR
        yaw += speed * Input.GetAxis("Mouse X");
        pitch -= speed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
#endif

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
