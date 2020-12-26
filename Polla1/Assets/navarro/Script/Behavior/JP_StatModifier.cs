using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace navarro
{
    public class JP_StatModifier : JP_AbstractBehavior
    {

        public JP_AuraManager aura;
        public JP_PlayerStats stats;

        private Vector3 previousScale;
        private bool deployRuning;
        public Text textFiled;

        // Use this for initialization
        void Start()
        {
            previousScale = aura.gameObject.transform.localScale;
            aura.gameObject.transform.localScale = Vector3.zero;
        }

        // Update is called once per frame
        void Update()
        {
            var deploy = inputState.GetButtonValue(inputButtons[0]);

            if (stats.power > 20 && deploy && !deployRuning)
            {
                stats.power -= 20;
                StartCoroutine(ResizeAura());
                textFiled.text = "Wife uses love" + "  \n" + textFiled.text;
            }
            else if (stats.power < 20 && deploy && !deployRuning)
            {
                textFiled.text = "Not Enough Love!" + "  \n" + textFiled.text;
            }
        }

        private IEnumerator ResizeAura()
        {
            aura.gameObject.transform.localScale = previousScale;
            deployRuning = true;
            yield return new WaitForSeconds(1f);
            aura.gameObject.transform.localScale = Vector3.zero;
            deployRuning = false;
        }
    }
}

