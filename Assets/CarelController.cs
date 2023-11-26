using System.Diagnostics;
using System;

public class CarelController : MonoBehaviour
{
    // Define a delegate for functions with no parameters and void return type.
    public delegate void CarelAction(Rigidbody carelRigidbody);
    public Rigidbody carelRigidbody;

    string[] commands; // Commands to be executed by Carel

    public GameObject carel; // Reference to Carel's GameObject.
    public GameObject alphabet;
    public ProgramHandler handler; // Handles the program logic

    private void Start()
    {
        // Initialize the handler and update Carel's move direction at the start
        handler = alphabet.GetComponent<ProgramHandler>();
        UpdateMoveDirection();
    }

    void Update()
    {
        // Check for user input (space key) to start executing commands
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(gameObject.transform.eulerAngles.y);
            StartCoroutine(ExecuteCommandsCoroutine());
        }
    }

    public IEnumerator ExecuteCommandsCoroutine()
    {
        // This coroutine executes a sequence of commands
        String[] c = handler.getCommand();
        foreach (var command in c)
        {
            // Execute different actions based on the command
            switch (command)
            {
                case "Forward":
                    yield return StartCoroutine(MoveCarlTest());
                    break;
                case "Right":
                    yield return StartCoroutine(TurnRight());
                    break;
                case "Left":
                    yield return StartCoroutine(TurnLeft());
                    break;
            }
            yield return new WaitForSeconds(1f); // Wait for one second
        }
    }

    private Vector3 moveDirection;
    private void UpdateMoveDirection()
    {
        // Update Carel's movement direction based on its current rotation
        Quaternion rotation = carel.transform.rotation;
        // Logic to determine the move direction
    }

    public IEnumerator MoveCarlTest()
    {
        // Move Carel forward by a certain number of steps
        // Logic to move Carel
    }

    public float turnAngle = 90f;
    public float turnDuration = 5f;

    public IEnumerator TurnLeft()
    {
        // Turn Carel to the left over a duration
        // Logic to turn left
    }

    public IEnumerator TurnRight()
    {
        // Turn Carel to the right over a duration
        // Logic to turn right
    }
}
