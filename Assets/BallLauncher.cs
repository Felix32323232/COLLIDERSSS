using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

public class BallLauncher : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 direction;
    public Vector3 rotation;
    public GameObject direccion;
    public PlayerInput playerInput;
    public float velDesplazamiento = 4.3f;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
;

    }

    void Update()
    {
        Vector2 movement = playerInput.actions["Move"].ReadValue<Vector2>();
        direction = direccion.transform.position;
        transform.eulerAngles +=  new Vector3(0, movement.x * velDesplazamiento, 0) * Time.deltaTime;


        //(movement.y * velDesplazamiento, movement.x * velDesplazamiento, 0); 


    }
    
    public void Launch()
    {
        rb.AddForce(transform.forward);
    }
   

}
