using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject,1f);
    }
}
