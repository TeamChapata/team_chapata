using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public TutorialEventsController t;
    public movimiento_caballero m;

    void OnTriggerEnter2D(Collider2D other)
    {
        movimiento_pnj_prueba_1.canwalk = false;
        m.anim.enabled = false;
        t.nextEvent_a();
    }

    void OnTriggerStay2D(Collider2D other)
    {
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (t.acabado())
        {
            GameObject.Find("suelo").transform.Translate(new Vector3(-30, 30, 0) * 30 * Time.deltaTime);
            GameObject.Find("fondo").transform.Translate(new Vector3(-30, 30, 0) * 30 * Time.deltaTime);
            GameObject.Find("caballero").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            GameObject.Find("bocadillo").GetComponent<Text>().text = "Comienza el primer capitulo...";

       
            Thread.Sleep(5000);
            SceneManager.LoadScene("fondo1");
        }
    }
}