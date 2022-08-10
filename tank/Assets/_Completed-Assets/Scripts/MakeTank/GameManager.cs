using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Tank
{



    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int tank1Hp;
        public int tank2Hp;
        public Text tank1Hptxt;
        public Text tank2Hptxt;

        private void Update()
        {
            SetTextHP();
        }


        void SetTextHP()
        {
            tank1Hptxt.text = string.Format("TANK1 : {0:00}", tank1Hp);
            tank2Hptxt.text = string.Format("TANK2 : {0:00}", tank2Hp);
        }
    }
}
