using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    public ParticleSystem targetExplosion;

    public LayerMask layermask;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shell")
        {
            ParticleSystem fire = Instantiate(targetExplosion, transform.position, transform.rotation);

            fire.Play();

            Destroy(gameObject);
            Destroy(fire.gameObject, 2.0f);

        }
    }
}
    