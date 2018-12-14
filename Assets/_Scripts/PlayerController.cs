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

    private GameManager GameManager;
    private HealthBarController HealthBar;

    private bool ControllerConnected;

    public string[] names;

    void Start() {
        controller = GetComponent<CharacterController>();
        HealthBar = FindObjectOfType<HealthBarController>();
        GameManager = FindObjectOfType<GameManager>();

        CheckIfControllerConnected();
    }

    void CheckIfControllerConnected() {
        names = Input.GetJoystickNames();
        if (names.Length != 0)
            ControllerConnected = true;
    }

    void FixedUpdate() {
        Movement();
    }


    // Responsible for picking up items
    private void OnTriggerStay(Collider other) {
        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("x")) {
            foreach (GameObject item in collectableItems) {
                if (other.gameObject == item) {
                    collectedItems.Add(other.name);
                    Destroy(other.gameObject);
                }
            }
            // When you have found the door in this case
            if(other.GetComponent<DoorController>() != null && collectedItems.Contains("key")) {
                other.GetComponent<DoorController>().OpenDoor();
            }

            if(collectedItems.Contains("screwdriver") && collectedItems.Contains("stereoglass")) {
                GameManager.TARDIS.SetActive(true);
                GameManager.AllAngelEnemies.SetActive(false);
                transform.position = GameManager.PlayerTeleport.position;
            }
        }
    }


    // Responsible for the player's life
    private void OnTriggerEnter(Collider other) {
        float damage = 10;
        // When an invisible angel has crashed the player
        if (other.gameObject.CompareTag("Angel") && !other.GetComponent<AngelController>().AngelFound) {
            HealthBar.DecreaseLife(damage);
            GameManager.PlayerLife -= damage;
            
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

#if UNITY_EDITOR || UNITY_STANDALONE
        float newSpeed = speed * 1.5f; 
        if (ControllerConnected) {
            yaw += newSpeed * Input.GetAxis("Horizontal2");
            pitch -= newSpeed * Input.GetAxis("Vertical2");
        } else {
            yaw += newSpeed * Input.GetAxis("Mouse X");
            pitch -= newSpeed * Input.GetAxis("Mouse Y");
        }



        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
#endif

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
