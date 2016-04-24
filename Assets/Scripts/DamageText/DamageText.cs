using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Complete
{
    public class DamageText : MonoBehaviour
    {
        public float duration;
        private float timeAlive;
        private Vector3 hitPoint;

        void Start()
        {
            //Destroy(this, duration);
        }

        public void Initialize(float damage, Collider collider, TankHealth tankHealth)
        {
            hitPoint = collider.transform.position;
            GameObject canvas = GameObject.Find("MessageCanvas");

            GetComponent<Animator>().SetTrigger("Hit");

            RectTransform damageTextRectTransform = GetComponent<RectTransform>();
            damageTextRectTransform.transform.SetParent(canvas.transform);
            damageTextRectTransform.position = Camera.main.WorldToScreenPoint(hitPoint);
            GetComponent<Text>().text = Mathf.FloorToInt(damage).ToString();
            float scale = 1 + (damage / tankHealth.m_StartingHealth) * 3;
            damageTextRectTransform.localScale = new Vector3(scale, scale, scale);
        }

        // Update is called once per frame
        void Update()
        {
            timeAlive += Time.deltaTime;
            float progress = timeAlive / duration;
            GetComponent<Text>().color = new Color(1, 1, 1, 1 - progress);

            GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(hitPoint);
        }
    }
}
