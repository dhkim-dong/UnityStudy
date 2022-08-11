using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public Transform[] bombPos;
    public GameObject bombPrefab;
    [Range(0f,3f)]
    public float interval = 1.0f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;

        if(delta > interval)
        {
            delta = 0;
            GenerateBomb();
        }
    }

    public void GenerateBomb()
    {
        int rand = Random.RandomRange(0, 11);

        GameObject bomb = Instantiate(bombPrefab, bombPos[rand].position, Quaternion.identity);
    }
}
