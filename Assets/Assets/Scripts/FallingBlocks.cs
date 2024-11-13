using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;





public class fallingblock : MonoBehaviour
{
    public float time;
    public Rigidbody2D rb;
    LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(SpawnDelay(rb));
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }

    }



    private IEnumerator SpawnDelay(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(time);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}