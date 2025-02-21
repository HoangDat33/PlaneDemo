using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 10f; // Tốc độ bay (tăng giá trị này để bay nhanh hơn)
    private Rigidbody rb;
    private Transform ap;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Tắt trọng lực để không rơi
        ap = pointA.transform;
    }

    void Update()
    {
        // Tính toán hướng di chuyển từ vị trí hiện tại đến điểm mục tiêu
        Vector3 direction = (ap.position - transform.position).normalized;

        // Thiết lập tốc độ di chuyển
        rb.linearVelocity = direction * speed;

        // Đổi điểm đến khi đến gần mục tiêu
        if (Vector3.Distance(transform.position, ap.position) < 0.5f)
        {
            ap = ap == pointB.transform ? pointA.transform : pointB.transform;
        }
    }
}
