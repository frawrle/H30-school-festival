using UnityEngine;

public class Move : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject,1);
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust);
    }


}
