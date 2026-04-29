using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

public class BallLauncher : MonoBehaviour
{
    Rigidbody rb;
    public GameObject direccion;
    public PlayerInput playerInput;
    public float velDesplazamiento;
    public int fuerzaLanzamiento;

    bool hasLaunched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector2 movement = playerInput.actions["Move"].ReadValue<Vector2>();
        transform.eulerAngles += new Vector3(0, movement.x * velDesplazamiento, 0) * Time.deltaTime;

        if (rb.linearVelocity.sqrMagnitude <= 0.0001)
        {
            direccion.SetActive(true);
            hasLaunched = false;
        }
    }       

    public void Launch()
    {
        if (hasLaunched) return;

        if (direccion != null)
        {
            direccion.SetActive(false);
        }

        if (rb != null)
        {
            rb.AddForce(transform.forward * fuerzaLanzamiento);
        }



        hasLaunched = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Deadzone"))
        {
            if (direccion != null)
            {
                direccion.SetActive(true);
            }

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            transform.position = new Vector3(0f, 0.35f, -4.4f);
            transform.eulerAngles += new Vector3(0,0,0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            hasLaunched = false;
        }
    }
}