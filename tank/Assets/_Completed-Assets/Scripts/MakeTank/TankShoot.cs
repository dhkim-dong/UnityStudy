using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Rigidbody prefabShell;
    public Transform shellPos;
    public float shootAngle;    // 슛앵글을 조절해서 높이 조절하는 기능

    public float shootDelay;
    public int playerNum;
    private float time = 0;
    string fireName;
    private float minPower =15;
    private float maxPower =30;
    private float chargeTime = 0.75f;
    private float chargePower;
    private float shootPower;

    // Start is called before the first frame update
    void Start()
    {
        fireName = "Fire" + playerNum;
        time = shootDelay;
        chargePower = (maxPower - maxPower) / chargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButtonDown(fireName))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if(time> shootDelay)
        {
            Rigidbody shellInstance = Instantiate(prefabShell, shellPos.position, shellPos.rotation);
            shellInstance.velocity = transform.forward * 20f;
            time = 0;
        }
    }
}
