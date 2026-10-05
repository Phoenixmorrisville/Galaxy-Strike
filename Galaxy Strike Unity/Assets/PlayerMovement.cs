using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlspeed = 10f;

    [SerializeField] float minX = -8f;
    [SerializeField] float maxX = 8f;

    Vector2 movements;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnMove(InputValue value)
    {
        Debug.Log("Move input received: " + value.Get<Vector2>());
        Debug.Log(value.Get<Vector2>());
        movements = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        float xoffset = movements.x *controlspeed * Time.deltaTime;
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x + xoffset, minX, maxX);

        transform.position = position;
    }
}
