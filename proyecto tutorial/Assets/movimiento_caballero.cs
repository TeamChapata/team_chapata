using System.Collections;
using UnityEngine;

public class movimiento_caballero : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (movimiento_pnj_prueba_1.canwalk)
        {
            anim.enabled = true;
        }
    }
}