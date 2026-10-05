using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem fireFX;
    [SerializeField] Transform Ship;
    [SerializeField] float controlspeed = 10f;

    [SerializeField] float minX = -8f;
    [SerializeField] float maxX = 8f;
    [SerializeField] float minY = -8f;
    [SerializeField] float maxY = 8f;

    [SerializeField] Transform aimPivot;
    [SerializeField] float aimLimit = 35f;
    [SerializeField] float aimSpeed = 5f;

    Vector2 lookInput;

    float currentAimX;
    float currentAimY;

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

    public void OnLook(InputValue value)
    {
        Debug.Log("Look input received: " + value.Get<Vector2>());
        lookInput = value.Get<Vector2>();
    }
    public void OnAttack(InputValue value)
    {
        if (!value.isPressed) return;

        fireFX.Play();
    }
    // Update is called once per frame
    void Update()
    {
        float xoffset = movements.x *controlspeed * Time.deltaTime;
        float yoffset = movements.y * controlspeed * Time.deltaTime;
        //transform.position = new Vector3(transform.localPosition.x + xoffset, 0f, 0f);
        Vector3 position = Ship.localPosition;
        position.x = Mathf.Clamp(position.x + xoffset, minX, maxX);
        position.y = Mathf.Clamp(position.y + yoffset, minY, maxY);


        Ship.localPosition = position;

        float targetAimX = lookInput.x * aimLimit;
        float targetAimY = lookInput.y * aimLimit;

        targetAimX = Mathf.Clamp(targetAimX, -aimLimit, aimLimit);
        targetAimY = Mathf.Clamp(targetAimY, -aimLimit, aimLimit);

        currentAimX = Mathf.Lerp(currentAimX, targetAimX, aimSpeed * Time.deltaTime);
        currentAimY = Mathf.Lerp(currentAimY, targetAimY, aimSpeed * Time.deltaTime);
        Debug.Log("Current Aim X: " + currentAimX + ", Current Aim Y: " + currentAimY);

        aimPivot.localRotation = Quaternion.Euler(-currentAimY, currentAimX, 0f);

    }
}
