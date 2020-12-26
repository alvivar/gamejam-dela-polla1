using UnityEngine;
using System.Collections;

namespace navarro
{
    public class FireMover : MonoBehaviour
    {
        public float bulletSpeed = 10;
        private Vector3 _startPos;
        private Vector3 _direction;
        private bool _available = true;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void FireBall(Vector3 pos, Vector3 dir)
        {
            if (_available)
            {
                _available = false;
                _startPos = pos;
                this.transform.position = pos;
                _direction = dir;
                StartCoroutine(Move());
            }
        }

        private IEnumerator Move()
        {
            while (Vector3.Distance(this.transform.position, _startPos) < 100f)
            {
                yield return new WaitForEndOfFrame();
                this.transform.Translate(Time.deltaTime * bulletSpeed * _direction);
            }
            yield return new WaitForEndOfFrame();
            this.transform.Translate(Vector3.up * -9000);
            _available = true;
        }
    }
}