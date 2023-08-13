using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;

    public void Death() {
        if (health <= 0) { 
            Destroy(gameObject);
        }
    }
}
