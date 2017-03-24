using UnityEngine;
using System.Collections;

public class BoundaryRandomMove : MonoBehaviour {

    public float steer = 20f;
    public float maxSpeed= 10f;

    private Vector2 facing;
    private Rigidbody2D rigid;
    private bool firstTime = true;
    void Start() {
        facing.x = -transform.position.x;
        facing.y = -transform.position.y;
        facing.Normalize();
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Steer());
    }
    
    void Rotate(float degrees) {
        facing = Quaternion.AngleAxis(degrees, Vector3.forward) * facing;
    }

    float RandomBinomial() {
        return Random.value - Random.value;
    }

    //int Cadran(Vector2 vec) {
    //    if (vec.x >= 0 && vec.y >= 0) {
    //        return 1;
    //    }
    //    if (vec.x <= 0 && vec.y >= 0) {
    //        return 2;
    //    }
    //    if (vec.x <= 0 && vec.y <= 0) {
    //        return 3;
    //    }
    //    if (vec.x >= 0 && vec.y <= 0) {
    //        return 4;
    //    }
    //    return 0;
    //}

    IEnumerator Steer() {
        float angle;
        while (true) {
            angle = RandomBinomial() * steer;
            yield return new WaitForSeconds(angle / steer);
            Rotate(angle);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (firstTime) {
            firstTime = false;
        } else {
            facing.x = -transform.position.x;
            facing.y = -transform.position.y;
            facing.Normalize();
            Rotate(Random.Range(-1f, 1f) * steer);
        }
    }

    void FixedUpdate() {
        rigid.velocity = facing * maxSpeed;
    }

}
