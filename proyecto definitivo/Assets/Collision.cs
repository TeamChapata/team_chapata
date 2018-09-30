using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public Chapter01EventsController t;
    public movimiento_caballero m;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hemos chocado");
        movimiento_pnj_prueba_1.canwalk = false;
        m.anim.enabled = false;
        t.nextEvent_a();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Estamos chocando");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Nos vamos a la vergota");
        if (t.acabado())
        {
            Debug.Log("Nos vamos a la vergotaaaa");
            //Initiate.Fade(pruebas, Color.white, 1.0f);
            Destroy(GameObject.Find("suelo"));
            GameObject.Find("caballero").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GameObject.Find("fondo").transform.Translate(new Vector3(-30, 30, 0) * 30 * Time.deltaTime);
        }
    }
}