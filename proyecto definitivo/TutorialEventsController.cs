using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class TutorialEventsController : MonoBehaviour
{
    [SerializeField] private bool colocarVino = false;                       // Variable de evento [Evento :: 0001]
    [SerializeField] private bool comidaQuemada = false;                     // Variable de evento [Evento :: 0002]
    [SerializeField] private bool atragantado = false;                       // Variable de evento [Evento :: 0003]


    private const string bocadillo = "bocadillo";              //Nombre del campo de texto
    private const string op_a = "op_a";                        //Nombre del boton 1
    private const string op_b = "op_b";                        //Nombre del boton 2

    private static int estado = 0;

    private Text campoTexto;
    private GameObject botonUno;
    private GameObject botonDos;

    private void Awake()
    {
        campoTexto = GameObject.Find(bocadillo).GetComponent<Text>();
        botonUno = GameObject.Find(op_a);
        botonDos = GameObject.Find(op_b);
    }

    public void nextEvent_a()
    {
        riseEvent(estado, 0);
    }

    public void nextEvent_b()
    {
        riseEvent(estado, 1);
    }

    /// <summary>
    /// Function recives event ID, and option value.
    /// </summary>
    public void riseEvent(int eventCode, int value)
    {
        switch(eventCode)
        {
            case 0:
                eventHandler00_000(value);
                break;
            case 1:
                eventHandler00_001(value);
                break;
            case 2:
                eventHandler00_002(value);
                break;
            case 3:
                eventHandler00_003(value);
                break;
            case 4:
                eventHandler00_004(value);
                break;
            case 5:
                eventHandler00_005(value);
                break;
            case 6:
                eventHandler00_006(value);
                break;
            case 7:
                eventHandler00_007(value);
                break;
            case 8:
                eventHandler00_008(value);
                break;
            case 9:
                eventHandler00_009(value);
                break;
            case 10:
                eventHandler00_010(value);
                break;
            case 11:
                eventHandler00_011(value);
                break;
            case 12:
                eventHandler00_012(value);
                break;
            case 13:
                eventHandler00_013(value);
                break;
            case 14:
                eventHandler00_014(value);
                break;
            case 15:
                eventHandler00_015(value);
                break;
            default:
                Debug.Log("Evento no encontrado");
                break;
        }
    }

    private void setButtons(bool b1_interactiable, string b1_text, bool b2_interactiable, string b2_text)
    {
        botonUno.GetComponent<Button>().interactable = b1_interactiable;
        botonUno.GetComponentInChildren<Text>().text = b1_text;
        botonDos.GetComponent<Button>().interactable = b2_interactiable;
        botonDos.GetComponentInChildren<Text>().text = b2_text;
    }

    private void eventHandler00_000(int value)
    {
        setButtons(true, "continuar", false, "");
        estado = 1;
    }

    private void eventHandler00_001(int value)
    {
        campoTexto.text = "Narrador: El protagonista de nuestra historia es José Luis, el panadero más famoso del barrio, " +
                "que vive una vida corriente con su pareja. A partir de ahora, serás tú el que elija por José Luis en cada una" +
                " de las decisiones a las que se enfrente.";

        setButtons(true, "continuar", false, "");
        estado = 2;
    }
    
    private void eventHandler00_002(int value)
    {
        campoTexto.text = "Te encuentras preparando una cena romántica para tu pareja. Recuerda que las decisiones son" +
            " más importantes de lo que crees.";

        setButtons(true, "continuar", false, "");
        estado = 3;
    }

    private void eventHandler00_003(int value)
    {
        campoTexto.text = "Te encuentras preparando una cena romántica para tu pareja. Recuerda que las decisiones son" +
            " más importantes de lo que crees.";

        setButtons(true, "continuar", false, "");
        estado = 4;
    }

    private void eventHandler00_004(int value)
    {
        campoTexto.text = "A) Preparar un par de copas de vino para la cena.\n" +
            "B) Mejor no preparar las copas, quizás más tarde si se anima la noche";

        setButtons(true, "A", true, "B");
        estado = 5;
    }

    private void eventHandler00_005(int value)
    {
        campoTexto.text = "Olvidas las copas y te centras en tu cena, quieres " +
            "que sea perfecta, pero ese deseo desaparece rápido de tu mente cuando oyes " +
            "una mosca a tu alrededor. Sabes que la cena es importante, pero la mosca no " +
            "para y no puedes concentrarte. ¿Qué deberías hacer?";

        setButtons(true, "Continuar", false, "");
        estado = 6;
    }

    private void eventHandler00_006(int value)
    {
        campoTexto.text = "A)	Dejar la cena un momento e intentar cazar la mosca.\n" +
            "B)	Ignorar la mosca y seguir cocinando";

        setButtons(true, "A", true, "B");
        estado = 7;
    }

    private void eventHandler00_007(int value)
    {
        if (value == 0)
        {
            comidaQuemada = true;
            estado = 8;
        }
        else
        {
            comidaQuemada = false;
            estado = 12;
        }
        setButtons(false, "", false, "");
        
    }

    private void eventHandler00_008(int value)
    {
        campoTexto.text = "Has conseguido cazar la mosca, ya no te molestará más, sin embargo, " +
            "has tardado en darle caza y, ¡la cena se te ha quemado! ¡Qué desastre!";

        setButtons(true, "Continuar", false, "");
        estado = 9;
    }

    private void eventHandler00_009(int value)
    {
        campoTexto.text = "Tienes que arreglar como sea la situación, así que preparas un par de " +
            "bocadillos con pan recién hecho por ti, no es la mejor solución, pero no tienes alimentos " +
            "para preparar más comida";

        setButtons(true, "Continuar", false, "");
        estado = 10;
    }

    private void eventHandler00_010(int value)
    {
        campoTexto.text = "El momento ha llegado, te sientas a la mesa y comenzáis a comer. Tu pareja " +
            "te sonríe al ver las pintas que tienes después de lo ocurrido con la cena. Tras un par de " +
            "bocados, te atragantas con un trozo de pan.";

        setButtons(true, "Continuar", false, "");
        estado = 11;
    }

    private void eventHandler00_011(int value)
    {
        campoTexto.text = "Acabas desmallado, todo por una mala decisión. ¿Quizás la próxima vez " +
            "tengas más cuidado no?";

        setButtons(true, "Continuar", false, "");
        estado = 15;
    }

    private void eventHandler00_012(int value)
    {
        campoTexto.text = "Has cocinado mejor otras veces, pero no está nada mal para la situación." +
            " La mosca ha terminado saliendo por la ventana y tienes lista la cena";

        setButtons(true, "Continuar", false, "");
        estado = 13;
    }

    private void eventHandler00_013(int value)
    {
        campoTexto.text = "Por fin estáis sentados uno frente al otro, el momento es perfecto. " +
            "Tras unos cuantos bocados de cena, la mosca reaparece y te hace atragantarte. " +
            "Piensas rápido en coger un poco de vino para intentar pasar el apuro, pero… has decidido " +
            "que era mejor no preparar las copas aún.";

        setButtons(true, "Continuar", false, "");
        estado = 14;
    }

    private void eventHandler00_014(int value)
    {
        campoTexto.text = "Acabas desmallado, todo por una mala decisión. ¿Quizás la próxima vez " +
            "tengas más cuidado no?";

        setButtons(true, "Continuar", false, "");
        estado = 15;
    }

    private void eventHandler00_015(int value) //FIN
    {
        campoTexto.text = "";

        setButtons(false, "", false, "");
        estado = -1;
    }
}