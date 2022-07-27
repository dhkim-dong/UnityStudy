using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject gunPrefab;
    [SerializeField] Transform gunPos;

    bool CanAttack = false;
    float delay = 0;
    [SerializeField] float attackDelay = 3f;

    [SerializeField] float enemySpeed = 5f;
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    float curPos;

    bool istarget1 = true;
    bool istarget2 = false;

    // Start is called before the first frame update
    void Start()
    {
        curPos = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        curPos += Time.deltaTime * enemySpeed;
        
        if(curPos >= target2.position.x)
        {
            curPos = target2.position.x;
            enemySpeed = -5f;
        }else if(curPos <= target1.position.x)
        {
            curPos = target1.position.x;
            enemySpeed = 5f;
        }

        transform.position = new Vector3(curPos, 1, 4);

        AttackDelay();
    }

    void AttackDelay()
    {
        delay += Time.deltaTime;
        if (attackDelay <= delay)
        {
            EnemyAttack();
            delay = 0;
        }     
    }

    void EnemyAttack()
    {
        // 프리펩을 이용한 오브젝트 생성
        GameObject bullet = Instantiate(gunPrefab, gunPos.position, Quaternion.identity);

        // BulletController에서 총알발사 함수 실행
        bullet.transform.GetComponent<BulletController>().BulletEnemyFire();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BULLET"))
        {
            Destroy(gameObject);
        }
    }
}
