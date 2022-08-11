using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarControl : MonoBehaviour
{
    [SerializeField] Image hpbar;

    Camera cam;
    Canvas canvas;
    RectTransform rectParent;
    RectTransform rectHp;

    public Vector3 offset = new Vector3(0, 2.5f, 0);
    public Transform enemyPos;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        cam = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHp = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        var screenPos = Camera.main.WorldToScreenPoint(enemyPos.position + offset);

        var localPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, cam, out localPos);

        rectHp.localPosition = localPos;
    }

    public void HpDown()
    {
        hpbar.fillAmount -= 0.1f;
    }

}
