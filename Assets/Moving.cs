using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [Range(0f, 100f)]
    public float speed = 1;
    [Range(500f, 5000f)]
    public float thrust = 500f; // Lực đẩy về phía trước
    [Range(500f, 5000f)]
    public float lift = 500f; // Lực nâng
    public float rollSpeed = 50f; // Tốc độ lăn (Roll)
    public float pitchSpeed = 50f; // Tốc độ ngóc (Pitch)
    public float yawSpeed = 30f; // Tốc độ xoay (Yaw)
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * thrust * Time.deltaTime, ForceMode.Acceleration);
        }
        // Lực nâng (Lift) để máy bay không bị rơi
        Vector3 liftForce = Vector3.up * lift * rb.linearVelocity.magnitude;
        rb.AddForce(liftForce, ForceMode.Force);
        // Điều khiển Pitch (ngóc lên/ngóc xuống)
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        transform.Rotate(pitch, 0, 0);
        // Điều khiển Roll (nghiêng trái/phải)
        if (Input.GetKey(KeyCode.I))
        {
            transform.Rotate(0, 0, rollSpeed * Time.deltaTime);
        }
        //if (Input.GetAxis("Horizontal")==true)
        //{
        // transform.Rotate(0, 0, -rollSpeed * Time.deltaTime);
        //}
        // Điều khiển Yaw (xoay trái/phải)
        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        transform.Rotate(0, yaw, 0);
    }
}