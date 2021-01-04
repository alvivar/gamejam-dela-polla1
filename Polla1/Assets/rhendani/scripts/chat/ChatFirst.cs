using Fluent;
using UnityEngine;
//using matnesis.TeaTime;


/// <summary>
/// This example shows how to inherit from Conversation and add a npc image to the options presenter
/// </summary>
public class ChatFirst : ChatComponentOptions
{
    //[ShowInfo("OBJECTS")]
    //public CameraCharacter animCam;
    //public Transform targetPoint;
    //public Transform characterPoint;
    //public DoorComponent door;

    public r_cloud_handler clouds;
    public r_start_component starting;
    public Animator tanger;
    public RaySoundHandler sound;
    public GameObject skipButton;
    public GameObject exitButton;
    public GameObject tangerineButton;

    bool finishedStuff = true;

    public void SetFinished()
    {
        if (!finishedStuff)
        {
            sound.PlaySound("ui1");
            tanger.enabled = true;
            finishedStuff = true;
        }
        
    }


    void Finish()
    {
        finishedStuff = false;
        tanger.enabled = false;
        tanger.transform.localScale = Vector3.one;
    }



    private void Start()
    {
        Run();
        clouds.VisibleClouds(Color.clear);
    }


    public void Ready()
    {
        exitButton.SetActive(true);
        tangerineButton.SetActive(true);
        starting.SetReady();
        clouds.VisibleClouds(Color.white);
    }


    public override FluentNode Create()
    {
        return
        Show()

        * Write("Bienvenido, mi nombre es Tanger.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Soy el alma de las mandarinas.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Te invito a participar en el juego de las semillas que caen del cielo. (Tanger Madness)")
            * Do(() => {
                Finish();
                exitButton.SetActive(true);
                skipButton.SetActive(true);
            })
        * ContinueWhen(() => finishedStuff)

        //* Write("Muy cotizado en la zona.")
        //    * Do(() => {
        //        Finish();
        //    })
        //* ContinueWhen(() => finishedStuff)

        * Write("En el tienes el poder de lanzar semillas del cielo, al dar click en la parte superior de la pantalla.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Las semillas pueden sembrarse en el suelo, o tocaran las nubes, y esto las lanzara largo y desaparecerán.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Como cuando no había razón para nada, Ahora el cielo es lo único que hay que alcanzar!")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Cuando logras que una semilla toca la tierra, nacerá un místico árbol de mandarinas.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Con todo su poder y esplendor.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Este árbol durara exactamente un minuto en crecer, y luego empezara a producir.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Sus frutos producirán mas capacidad para semilla, y tu poder de semilla incrementara.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Dependiendo de si siembras muchos o pocos arboles, no habrá diferencia una vez que consigas tener muchos.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Lo que significa que siembras sin fin.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Bueno me despido, eso ha sido todo, gracias por tu tiempo.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)

        * Write("Hasta luego y que tengas una agradable cosecha.")
            * Do(() => {
                Finish();
            })
        * ContinueWhen(() => finishedStuff)
        * Hide()

        * Do(() => {

            Ready();

        })

        * End();

    }

}
