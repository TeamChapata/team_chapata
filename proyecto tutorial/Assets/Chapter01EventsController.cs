using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Chapter01EventsController : MonoBehaviour
{
    // CONSTANTES DE ELEMENTOS
    private const string bocadillo = "bocadillo";                            //Nombre del campo de texto
    private const string op_a = "op_a";                                      //Nombre del boton 1
    private const string op_b = "op_b";                                      //Nombre del boton 2
    private const string nombre_vida = "vida_";                              //Nombre de las imagenes de vida;
    private const string campo_multiplicador_ataque = "AtaqueBox";           //Nombre del campo que muestra el multiplicador de ataque
    private const string campo_multiplicador_defensa = "DefensaBox";         //Nombre del campo que muestra el multiplicador de defensa

    // VARIABLES DE ELEMENTOS
    private Text campoTexto;                                                 //Elemento de output de texto
    private GameObject botonUno;                                             //Elemento de output de texto
    private GameObject botonDos;                                             //Elemento de output de texto
    private GameObject[] vidasImagen = new GameObject[6];                    //Elementos de vida
    private Text campoAtaqueBox;                                             //Elemento de output del valor de ataque
    private Text campoDefensaBox;                                            //Elemento de output del valor de defensa

    // VARIABLES DE CONTROL DE EVENTOS
    [SerializeField] private bool vivo = true;                                // Variable de evento
    [SerializeField] private bool maxVida = true;                             // Variable de evento
    [SerializeField] private bool ayudarJagri = false;
    [SerializeField] private bool llaveCogida = false;
    [SerializeField] private bool dragonMuerto = false;


    // VARIABLES DE ESTADO
    private static int estado = 0;                                            //Variable de control de los estados
        
    // VARIABLES DE ESTADISTICAS
    private bool[] vidas = new bool[6] { true , true , true,
                                         false, false, false };                //Cantidad de vidas
    private double ataque = 0.1;                                               //Estadistica de ataque  :: base = 0.1
    private double defensa = 0.0;                                              //Estadistica de defensa :: base = 0.0
    private string cabeceraDiario = "Diario de Jose Luis:\n";                  //Cabecera del diario
    private string diario = "";                                                //Cadena de diario

    private void Awake()
    {
        campoTexto = GameObject.Find(bocadillo).GetComponent<Text>();
        botonUno = GameObject.Find(op_a);
        botonDos = GameObject.Find(op_b);

        //inicializacion de las vidas
        for (int n = 0; n < vidas.Length; n++)
        {
            SpriteRenderer sprite = GameObject.Find(nombre_vida + n).GetComponent<SpriteRenderer>();
            vidasImagen[n] = sprite.gameObject;
            if (n < 3)
            {
                vidasImagen[n].SetActive(true); //Habilita las tres primeras vidas
            }
            else
            {
                vidasImagen[n].SetActive(false);  //Deshabilita las tres segundas vidas
            }
        }
    }

    //-----------------------------------------------------//
    //
    //------------- MODULO DIARIO -------------------------//
    //
    //-----------------------------------------------------//

    private void insertarEntradaDiario(string entrada)
    {
        diario = "- " + entrada + "\n";
    }

    private void mostrarDiario()
    {
        //to-do
    }

    private void ocultarDiario()
    {
        //to-do
    }

    //-----------------------------------------------------//
    //
    //------------- MODULO VIDAS --------------------------//
    //
    //-----------------------------------------------------//

    private int getVida()
    {
        int retVal = 6;
        for(int n = 6; n > 0 && !vidas[n]; n--)
        {
            retVal--;
        }
        return retVal;
    }

    private void vidaAbajo(int cantidad)
    {
        for (int n = 0; n < cantidad && getVida() > 0; n++)
        {
            vidas[getVida() - 1] = false;
            vidasImagen[getVida() - 1].SetActive(false);
            if (getVida() <= 0)
            {
                vivo = false;
            }
        }
    }

    private void vidaArriba(int cantidad)
    {
        for (int n = 0; n < cantidad && getVida() < 6; n++)
        {
            vidas[getVida()] = true;
            vidasImagen[getVida()].SetActive(true);
            if (getVida() == 6)
            {
                maxVida = true;
            }
        }
    }

    //-----------------------------------------------------//
    //
    //------------- MODULO COMBATE ------------------------//
    //
    //-----------------------------------------------------//

    private bool combatir()
    {
        System.Random rnd = new System.Random();
        int jugador = rnd.Next(1, 11); //Aleatorio entre 1 y 10 para el jugador
        int enemigo = rnd.Next(1, 11); //Aleatorio entre 1 y 10 para el enemigo

        double valor_jugador = jugador * (1.0 + ataque);
        double valor_enemigo = enemigo * (1.0 - defensa);

        if (valor_enemigo > valor_jugador)
        {
            vidaAbajo(1);
        }
        return valor_enemigo > valor_jugador;
    }

    //-----------------------------------------------------//
    //
    //------------- MODULO EVENTOS ------------------------//
    //
    //-----------------------------------------------------//


    public void nextEvent_a()
    {
        riseEvent(estado, 0);
    }

    public void nextEvent_b()
    {
        riseEvent(estado, 1);
    }

    private void setButtons(bool b1_interactiable, string b1_text, bool b2_interactiable, string b2_text)
    {
        botonUno.GetComponent<Button>().interactable = b1_interactiable;
        botonUno.GetComponentInChildren<Text>().text = b1_text;
        botonDos.GetComponent<Button>().interactable = b2_interactiable;
        botonDos.GetComponentInChildren<Text>().text = b2_text;
    }

    public void riseEvent(int eventCode, int value)
    {
        switch (eventCode)
        {
            case 0:
                eventHandler01_000(value);
                break;
            case 1:
                eventHandler01_001(value);
                break;
            case 2:
                eventHandler01_002(value);
                break;
            case 3:
                eventHandler01_003(value);
                break;
            case 4:
                eventHandler01_004(value);
                break;
            case 5:
                eventHandler01_005(value);
                break;
            case 6:
                eventHandler01_006(value);
                break;
            case 7:
                eventHandler01_007(value);
                break;
            case 8:
                eventHandler01_008(value);
                break;
            case 9:
                eventHandler01_009(value);
                break;
            case 10:
                eventHandler01_010(value);
                break;
            case 11:
                eventHandler01_011(value);
                break;
            case 12:
                eventHandler01_012(value);
                break;
            case 13:
                eventHandler01_013(value);
                break;
            case 14:
                eventHandler01_014(value);
                break;
            case 15:
                eventHandler01_015(value);
                break;
            case 16:
                eventHandler01_016(value);
                break;
            case 17:
                eventHandler01_017(value);
                break;
            case 18:
                eventHandler01_018(value);
                break;
            case 19:
                eventHandler01_019(value);
                break;
            case 21:
                eventHandler01_021(value);
                break;
            case 22:
                eventHandler01_022(value);
                break;
            case 23:
                eventHandler01_023(value);
                break;
            case 24:
                eventHandler01_024(value);
                break;
            case 25:
                eventHandler01_025(value);
                break;
            case 26:
                eventHandler01_026(value);
                break;
            case 27:
                eventHandler01_027(value);
                break;
            case 28:
                eventHandler01_028(value);
                break;
            case 29:
                eventHandler01_029(value);
                break;
            case 30:
                eventHandler01_030(value);
                break;
            case 31:
                eventHandler01_031(value);
                break;
            case 32:
                eventHandler01_032(value);
                break;
            case 33:
                eventHandler01_033(value);
                break;
            case 34:
                eventHandler01_034(value);
                break;
            case 35:
                eventHandler01_035(value);
                break;
            case 36:
                eventHandler01_036(value);
                break;
            case 37:
                eventHandler01_037(value);
                break;
            case 38:
                eventHandler01_038(value);
                break;
            case 39:
                eventHandler01_039(value);
                break;
            case 40:
                eventHandler01_040(value);
                break;
            case 41:
                eventHandler01_041(value);
                break;
            case 42:
                eventHandler01_042(value);
                break;
            case 210:
                eventHandler01_210(value);
                break;
            case 330:
                eventHandler01_330(value);
                break;
            case 410:
                eventHandler01_410(value);
                break;
            case 610:
                eventHandler01_610(value);
                break;
            case 630:
                eventHandler01_630(value);
                break;
            case 800:
                eventHandler01_800(value);
                break;
            case 820:
                eventHandler01_820(value);
                break;
            default:
                Debug.Log("Evento no encontrado");
                break;
        }
    }

    private void eventHandler01_000(int value)
    {
        campoTexto.text = "";
        setButtons(true, "continuar", false, "");
        estado = 1;
    }

    private void eventHandler01_001(int value)
    {
        campoTexto.text = "Apareces tirado en medio del campo, no sabes que ha ocurrido, te duele la garganta, pero puedes respirar bien.";
        setButtons(true, "continuar", false, "");
        estado = 2;
    }

    private void eventHandler01_002(int value)
    {
        campoTexto.text = "Todo es muy extranyo, abres los ojos y ves a tu lado una barra de pan, te levantas y la recoges. Curiosamente, te sientes muy seguro con ella en la mano. No hay tiempo que perder, tienes que encontrar respuestas.";
        setButtons(true, "continuar", false, "");
        estado = 3;
    }

    private void eventHandler01_003(int value)
    {
        campoTexto.text = "Tras unos minutos siguiendo el sendero, te encuentras con una anciana, estas feliz de encontrar a alguien con quien hablar. La anciana te mira de manera extranya, y al acercarte te habla.";
        setButtons(true, "continuar", false, "");
        estado = 4;
    }

    private void eventHandler01_004(int value)
    {
        campoTexto.text = "Anciana: Eres tu, las leyendas eran ciertasâ€¦ peroâ€¦ no llevas delantal. Toma, lo necesitaras en tu aventura, y recuerda mantenerlo impoluto, es muy importante!";
        setButtons(true, "continuar", false, "");
        estado = 5;
    }

    private void eventHandler01_005(int value)
    {
        campoTexto.text = "Te colocas el delantal y te alejas mientras la anciana te sonrie esperanzada. De que leyenda esta hablando? Por que debes llevar delantal? Centrate, no debes perder el tiempo, tienes que volver con tu pareja, estara preocupada.";
        setButtons(true, "continuar", false, "");
        estado = 6;
    }

    private void eventHandler01_006(int value)
    {
        campoTexto.text = "Siguiendo el camino a lo lejos avistas un bosque del que provienen ruidos. Te aproximas a una persona grande y fornida, con una camisa de cuadros roja y una barba exuberante.";
        setButtons(true, "continuar", false, "");
        estado = 7;
    }

    private void eventHandler01_007(int value)
    {
        campoTexto.text = "Jagri: Hola forastero, me llamo Jagri, me pillas bastante ocupado con el trabajo. Te agradeceria que me echaras una mano, estaria muy agradecido contigo.";
        setButtons(true, "continuar", false, "");
        estado = 8;
    }

    private void eventHandler01_008(int value)
    {
        campoTexto.text = "Parece que tienes ante ti la primera decision de la historia, que haces?, Ayudas a Jagri?\\nA)	Ayudar a Jagri, no pierdo nada por ayudarle.\\nB)	Debo seguir mi camino, no tengo tiempo que perder.";
        setButtons(true, "A", true, "B");
        estado = 800;
    }

    private void eventHandler01_800(int value)
    {
        if(value == 0)
        {
            ayudarJagri = true;
            estado = 9;

            insertarEntradaDiario("Ayudaste a jagri.");
        }
        else
        {
            ayudarJagri = false;
            estado = 10;

            insertarEntradaDiario("Desoiste a un amigo, Jagri lo recordara.");
        }
        campoTexto.text = "";
        setButtons(false, "", false, "");
    }

    private void eventHandler01_009(int value)
    {
        campoTexto.text = "Tras un rato talando arboles junto a Jagri, recibes su agradecimiento y os despedis hasta la siguiente. Debes seguir el camino y averiguar que haces aqui.";
        setButtons(true, "continuar", false, "");
        estado = 11;
    }

    private void eventHandler01_010(int value)
    {
        campoTexto.text = "Dices a Jagri que lo lamentas mucho y prosigues tu camino, debes averiguar que haces aqui.";
        setButtons(true, "continuar", false, "");
        estado = 11;
    }

    private void eventHandler01_011(int value)
    {
        campoTexto.text = "Llevas horas siguiendo el mismo camino, pasas el tiempo pegando patadas a guijarros que encuentras, hasta que tras una patada oyes un ruido metalico.";
        setButtons(true, "continuar", false, "");
        estado = 12;
    }

    private void eventHandler01_012(int value)
    {
        campoTexto.text = "Miras al suelo y ves una llave oxidada, Deberias cogerla?\\nA)	Por que no? Lo maximo que puede pasar es que enfermes.\\nB)	No, esta demasiado oxidada para servir para algo.";
        setButtons(true, "A", true, "B");
        estado = 210;
    }

    private void eventHandler01_210(int value)
    {
        if (value == 0)
        {
            llaveCogida = true;
            estado = 13;
            insertarEntradaDiario("Recogiste la llave del camino.");
        }
        else
        {
            llaveCogida = false;
            estado = 13;
            insertarEntradaDiario("Decidiste no llevarte la llave mugrienta.");
        }
        campoTexto.text = "";
        setButtons(false, "", false, "");
    }

    private void eventHandler01_013(int value)
    {
        campoTexto.text = "Sigues tu camino, feliz porque has visto una aldea en la lejania, vas a poder reponer fuerzas para el viaje que te espera. La gente de la aldea te mira como te miraba la anciana que has encontrado al comienzo de la historia, con asombro, algunos con miedo, otros con admiracion.";
        setButtons(true, "continuar", false, "");
        estado = 14;
    }

    private void eventHandler01_014(int value)
    {
        campoTexto.text = "Encuentras un lugar perfecto para resguardarte al abrigo, junto con un horno que emite gran cantidad de calor. Que deseas hacer?\\nA)	Reforzar tu barra de pan y aumentar su danyo.\\nB)	Coger un delantal extra para el viaje.";
        setButtons(true, "continuar", false, "");
        estado = 410;
    }

    private void eventHandler01_410(int value)
    {
        if (value == 0)
        {
            ataque += 0.05;
            estado = 15;
            insertarEntradaDiario("Mejoraste el ataque en el horno de la aldea.");
        }
        else
        {
            vidaArriba(1);
            estado = 15;
            insertarEntradaDiario("Recuperaste salud antes de comenzar el camino");
        }
        campoTexto.text = "";
        setButtons(false, "", false, "");
    }

    private void eventHandler01_015(int value)
    {
        campoTexto.text = "Cuando te dispones a abandonar la aldea te encuentras una extranya criatura en el camino, la gente te pide en manada que acabes con ella, pero parece una fiera muy peligrosa. Que haces?";
        setButtons(true, "continuar", false, "");
        estado = 16;
    }

    private void eventHandler01_016(int value)
    {
        campoTexto.text = "A)	Atacar a la criatura. (Probabilidad de perder un delantal limpio)\\nB)	Bordear la criatura y seguir tu aventura.";
        setButtons(true, "continuar", false, "");
        estado = 610;
    }

    private void eventHandler01_610(int value)
    {
        if (value == 0)
        {
            insertarEntradaDiario("Te enfrentaste a un dragón");
            if (combatir())
            {
                ataque += 0.10;
                estado = 17;
                dragonMuerto = true;
                insertarEntradaDiario("Cumpliste tu papel de heroe a costa de tu integridad.");
            }
            else
            {
                ataque += 0.10;
                estado = 17;
                dragonMuerto = true;
                insertarEntradaDiario("Cumpliste tu papel como heroe.");
                //DIARIO HABER GANADO
            }
        }
        else
        {
            estado = 21;
            dragonMuerto = false;
            insertarEntradaDiario("Fallaste a toda una aldea.");
        }
        campoTexto.text = "";
        setButtons(false, "", false, "");
    }

    private void eventHandler01_017(int value)
    {
        campoTexto.text = "Acabas con la criatura, la gente explota con multitud de agradecimientos hacia tu persona, te llaman \"El elegido\", comentan entre cuchicheos que la leyenda se esta cumpliendo.";
        setButtons(true, "continuar", false, "");
        estado = 18;
    }

    private void eventHandler01_018(int value)
    {
        campoTexto.text = "Te escabulles como puedes de la multitud y continuas, aunque agradeces todo eso, necesitas respuestas, no mas preguntas.";
        setButtons(true, "continuar", false, "");
        estado = 19;
    }

    private void eventHandler01_019(int value)
    {
        campoTexto.text = "Tras salir de la aldea, te encuentras con una persona volviendo hacia esta. La persona te saluda amablemente, te da las gracias por haber acabado con la criatura y te ofrece reforzar tu barra de pan por haber salvado su pueblo.";
        setButtons(true, "continuar", false, "");
        estado = 23;
    }

    private void eventHandler01_021(int value)
    {
        campoTexto.text = "Bordeas a la criatura, la gente llora de tristeza, gritan que la leyenda era falsa y no hay esperanza, Esperanza de que?, no importa, debes seguir tu camino.";
        setButtons(true, "continuar", false, "");
        estado = 22;
    }

    private void eventHandler01_022(int value)
    {
        campoTexto.text = "Tras salir de la aldea, te encuentras con una persona volviendo hacia esta. La persona te saluda con mala cara, te echa en cara haber ignorado la leyenda y haber abandonado a la aldea. Te alejas sin mirarle a los ojos.";
        setButtons(true, "continuar", false, "");
        estado = 23;
    }

    private void eventHandler01_023(int value)
    {
        campoTexto.text = "Con todo ocurrido hace un momento rondando en tu cabeza, vuelves al camino hasta encontrar un rio que debes cruzar si no quieres volver sobre tus pasos.";
        setButtons(true, "continuar", false, "");
        estado = 24;
    }

    private void eventHandler01_024(int value)
    {
        if (ayudarJagri)
        {
            estado = 25;
        }
        else
        {
            estado = 31;
        }
    }

    private void eventHandler01_025(int value)
    {
        campoTexto.text = "Encuentras un puente para cruzar, pero esta totalmente destruido. Cuando te dispones a bordear el rio oyes una voz familiar gritando que esperes. Es Jagri. Se acerca a ti y se ofrece a construir un pequenyo puente para pasar el rio.";
        setButtons(true, "continuar", false, "");
        estado = 26;
    }

    private void eventHandler01_026(int value)
    {
        campoTexto.text = "En poco mas de una hora estas en la otra orilla del rio despidiendote de Jagri; te giras para continuar la aventura mientras sonries por haber encontrado a un amigo en este momento";
        setButtons(true, "continuar", false, "");
        estado = 27;
    }

    private void eventHandler01_027(int value)
    {
        campoTexto.text = "Poco despues de despedirte de Jagri al lado del rio encuentras una cabanya con una cerradura oxidada, y te acuerdas de la llave que viste antes en el camino.";
        setButtons(true, "continuar", false, "");
        estado = 28;
    }

    private void eventHandler01_028(int value)
    {
        campoTexto.text = "Ante la puerta debes tomar una decision:\\nA)	Usas la llave para abrir la puerta de la cabanya.\\nB)	Ignoras la cabanya y continuas con tu apresurado viaje.";
        setButtons(llaveCogida, "continuar", false, "");
        estado = 820;
    }

    private void eventHandler01_820(int value)
    {
        if (value == 0)
        {
            estado = 29;

            defensa += 0.10;
            insertarEntradaDiario("Entraste en la cabaña misteriosa.");
        }
        else
        {
            estado = 30;
            insertarEntradaDiario("No conseguiste abrir la cerradura de la cabaña.");
        }
        campoTexto.text = "";
        setButtons(false, "", false, "");
    }

    private void eventHandler01_029(int value)
    {
        campoTexto.text = "Por suerte cogiste la llave, asi que la usas para entrar en la cabanya y encuentras unos delantales de un material mucho mas resistente a las manchas que los que llevas puestos. Los coges y te pones uno, parece que los necesitaras en tu aventura.";
        setButtons(true, "continuar", false, "");
        estado = 36;
    }

    private void eventHandler01_030(int value)
    {
        campoTexto.text = "Vuelves al sendero para continuar tu aventura, sin siquiera pensar en que secretos podria albergar la cabanya que ya dejas atras.";
        setButtons(true, "continuar", false, "");
        estado = 36;
    }

    private void eventHandler01_031(int value)
    {
        campoTexto.text = "Encuentras un puente para cruzar, pero esta totalmente destruido. Visto que no puedes usarlo, comienzas a bordear el rio en busca de otro camino, y lo encuentras, pero custodiado por otra bestia.";
        setButtons(true, "continuar", false, "");
        estado = 32;
    }

    private void eventHandler01_032(int value)
    {
        campoTexto.text = "Al acercarte para investigar ves una barca con un candado oxidado en la orilla en el que podrias usar la llave oxidada que has visto antes.";
        setButtons(true, "continuar", false, "");
        estado = 33;
    }

    private void eventHandler01_033(int value)
    {
        campoTexto.text = "Podrias coger la barca o buscar un camino alternativo. Se vislumbra un puente en la lejania.\\nA)	Usas la llave para desbloquear la barca y cruzar el rio.\\nB)	Caminas hacia el puente que se ve al fondo.";
        setButtons(llaveCogida, "continuar", false, "");
        estado = 330;
    }

    private void eventHandler01_330(int value)
    {
        if(value == 0)
        {
            estado = 34;

            insertarEntradaDiario("Robaste la barca al barquero, no tuviste que pagar dinero.");
            // DIARIO HAS USADO LA BARCA
        }
        else
        {
            estado = 35;

            insertarEntradaDiario("Tus actos te llevaron a usar la fuerza");
            // DIARIO VAS AL PUENTE
        }
        campoTexto.text = "";
        setButtons(false, "", false, "");
    }

    private void eventHandler01_034(int value)
    {
        campoTexto.text = "Por suerte cogiste la llave, asi que coges la barca intentando no despertar a la bestia del camino y cruzas el rio sin problemas.";
        setButtons(true, "continuar", false, "");
        estado = 36;
    }

    private void eventHandler01_035(int value)
    {
        campoTexto.text = "Te lamentas por no usar la llave, debido a esa decision tienes que luchar contra una bestia que tiene cara de pocos amigos. (Pierdes 1 delantal)";
        setButtons(true, "continuar", false, "");
        estado = 36;
    }

    private void eventHandler01_036(int value)
    {
        campoTexto.text = "Mas delante en el camino encuentras otro lugar con horno como el de la aldea, parecen comunes en este lugar.\nA)	Mejorar ataque.\nB)	Obtener nuevo delantal";
        setButtons(true, "continuar", false, "");
        estado = 630;
    }

    private void eventHandler01_630(int value)
    {
        if (value == 0)
        {
            ataque += 0.05;
            estado = 37;

            insertarEntradaDiario("Mejoraste el ataque.");
            //DIARIO HAS MEJORADO EL ATAQUE
        }
        else
        {
            vidaArriba(1);
            estado = 37;
            insertarEntradaDiario("Te equipaste para la aventura con un nuevo delantal.");
            //DIARIO HAS MEJORADO LA VIDA
        }
        campoTexto.text = "";
        setButtons(false, "", false, "");
    }

    private void eventHandler01_037(int value)
    {
        campoTexto.text = "Tras reponer energias, sigues tu camino esperando llegar a encontrar algo pronto. Tus plegarias son oidas pronto y encuentras a un ninyo jugando en un campo de maiz a la orilla del camino.";
        setButtons(true, "continuar", false, "");
        estado = 38;
    }

    private void eventHandler01_038(int value)
    {
        campoTexto.text = "El ninyo te reconoce como \"El elegido\" y te cuenta la leyenda que habla sobre ti; un hombre con una barra de pan y un delantal inmaculado, DoughtBoy, librara a las Tierras de Panaderia del gran mal que les acecha en las montanyas del norte.";
        setButtons(true, "continuar", false, "");
        estado = 39;
    }

    private void eventHandler01_039(int value)
    {
        campoTexto.text = "Te habla tambien de una gran puerta de piedra en las montanyas que solo se abrira a quien tenga la bendicion del rey de la zona. Tu nuevo objetivo, ir a ver ese rey; pero primero debes buscar informacion en la aldea que visitaste un tiempo antes.";
        setButtons(true, "continuar", false, "");
        estado = 40;
    }

    private void eventHandler01_040(int value)
    {
        if(dragonMuerto)
        {
            estado = 41;
        }
        else
        {
            estado = 42;
        }
        campoTexto.text = "";
        setButtons(false, "", false, "");
    }

    private void eventHandler01_041(int value)
    {
        campoTexto.text = "Llegas a la aldea un dia despues, hablas con las gentes y te cuentan todo lo necesario para llegar al castillo, incluso un atajo para llegar antes a el. Pasas la noche en la aldea y al dia siguiente partes hacia el castillo del rey.";
        setButtons(false, "continuar", false, "");
        estado = -1;
    }

    private void eventHandler01_042(int value)
    {
        campoTexto.text = "Al llegar a la aldea no quedan mas que escombros y cenizas, la bestia que dejaste viva ha masacrado la aldea y no queda nada, maldices tus acciones y gritas al cielo. Al levantar la vista ves en el horizonte unas almenas, debe ser el castillo del rey, no hay tiempo que perder.";
        setButtons(false, "continuar", false, "");
        estado = -1;
    }
}