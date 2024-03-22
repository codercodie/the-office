using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private static Player instance;
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Animator animator;
    public StopStartPlayerMovement playerMovement;
    public Vector3 cubiclePosition, mainOfficePosition, hallwayPosition, conferenceRoomPosition, bathroomPosition, cafePosition, bossOfficePosition;

    private void Awake()
    {
        // Ensure there is only one instance of the Player object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SetStartingPositions();
        transform.position = cubiclePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.moving)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            movement.Normalize();

            rb.velocity = movement * moveSpeed;

            animator.SetFloat("Vertical", verticalInput);
            animator.SetFloat("Horizontal", horizontalInput);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    public void SetStartingPositions()
    {
        // set starting positions depending on which building entered/exited
        cubiclePosition = new Vector3(4.17f, -0.83f, 0f);
        mainOfficePosition = new Vector3(-5.65f, -0.98f, 0f);
        hallwayPosition = new Vector3(-6.09f, -0.83f, 0f);
        conferenceRoomPosition = new Vector3(3.71f, -0.83f, 0f);
        bathroomPosition = new Vector3(-6.09f, -0.83f, 0f);
        cafePosition = new Vector3(-6.09f, -0.83f, 0f);
        bossOfficePosition = new Vector3(-4.09f, -0.83f, 0f);
    }


}