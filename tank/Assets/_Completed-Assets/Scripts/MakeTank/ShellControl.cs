using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellControl : MonoBehaviour
{
    public ParticleSystem shellExplosion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem fire = Instantiate(shellExplosion, transform.position, transform.rotation);

        fire.Play();

        Destroy(this.gameObject);
        Destroy(fire.gameObject, 1f);
    }
}
