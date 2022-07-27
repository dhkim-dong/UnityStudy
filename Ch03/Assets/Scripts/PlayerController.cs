using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] GameObject gunPrefab;
    [SerializeField] Transform gunPos;
    [SerializeField] Transform LookPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        GunShoot();
    }

    void GunShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �������� �̿��� ������Ʈ ����
            GameObject bullet = Instantiate(gunPrefab, gunPos.position, Quaternion.identity);

            // BulletController���� �Ѿ˹߻� �Լ� ����
            bullet.transform.GetComponent<BulletController>().BulletFire();
        }
    }

    void Lookat()
    {
        transform.LookAt(LookPos.position);
    }
}
