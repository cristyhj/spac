using UnityEngine;
using System.Collections;

public class WanderMove : MonoBehaviour {

    public float maxVelocity = 3.5f;
    public float maxAcceleration = 10f;
    public float wanderRadius = 4;
    public float wanderOffset = 1.5f;
    public float wanderRate = 0.4f;
    private float wanderOrientation = 0;
    private Rigidbody2D rb;


    void Start() {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update() {
        Vector3 accel = getSteering();

        steer(accel);
    }

    Vector3 getSteering() {
        float characterOrientation = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;

        /* Update the wander orientation */
        wanderOrientation += randomBinomial() * wanderRate;

        /* Calculate the combined target orientation */
        float targetOrientation = wanderOrientation + characterOrientation;

        /* Calculate the center of the wander circle */
        Vector3 targetPosition = transform.position + (orientationToVector(characterOrientation) * wanderOffset);

        //debugRing.transform.position = targetPosition;

        /* Calculate the target position */
        targetPosition = targetPosition + (orientationToVector(targetOrientation) * wanderRadius);

        //Debug.DrawLine (transform.position, targetPosition);

        return seek(targetPosition);
    }

    float randomBinomial() {
        return Random.value - Random.value;
    }

    Vector3 orientationToVector(float orientation) {
        return new Vector3(Mathf.Cos(orientation), Mathf.Sin(orientation), 0);
    }

    public Vector3 seek(Vector3 targetPosition, float maxSeekAccel) {
        //Get the direction
        Vector3 acceleration = targetPosition - transform.position;

        //Remove the z coordinate
        acceleration.z = 0;

        acceleration.Normalize();

        //Accelerate to the target
        acceleration *= maxSeekAccel;

        return acceleration;
    }

    public Vector3 seek(Vector3 targetPosition) {
        return seek(targetPosition, maxAcceleration);
    }

    public void steer(Vector2 linearAcceleration) {
        rb.velocity += linearAcceleration * Time.deltaTime;

        if (rb.velocity.magnitude > maxVelocity) {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }
}
