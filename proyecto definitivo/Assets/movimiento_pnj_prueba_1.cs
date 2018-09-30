using System.Collections;
using UnityEngine;

public class movimiento_pnj_prueba_1 : MonoBehaviour {
    public float speed;
    public static bool canwalk = true;

    // Use this for initialization
    void Start()
    {
        speed = 10;
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (canwalk)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
    }
}
