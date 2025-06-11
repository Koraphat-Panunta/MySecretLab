using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionCommand : MonoBehaviour
{
    // Start is called before the first frame update
    int frame;
    public KeyCode AttackKey;
    public Vector2 lookDelta;
    void Start()
    {
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frame++;
        lookDelta.x = Input.GetAxis("Mouse X") * Time.deltaTime;
        lookDelta.y = Input.GetAxis("Mouse Y") *Time.deltaTime;
    }
    public void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack been called " + context.phase+" on frame "+frame);
    }
}
