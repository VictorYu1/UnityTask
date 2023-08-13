using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour {
    public bool isGrounded;

    private void OnCollisionEnter() {
        isGrounded = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isGrounded = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 3500, 0));
        }
    }
}
