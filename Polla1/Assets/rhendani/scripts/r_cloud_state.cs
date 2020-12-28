using UnityEngine;

public class r_cloud_state : MonoBehaviour
{

    public bool isRight;
    public float speed;

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.GetComponent<r_seed_component>() != null)
        {
            collision.transform.position = Vector3.one * 99;
            collision.gameObject.SetActive(false);
        }

    }

}
