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
    public bool finished = false;

    public void SetFinished(bool target)
    {
        finished = target;
    }


    private void Start()
    {
        Run();
        clouds.VisibleClouds(Color.clear);
    }



    public override FluentNode Create()
    {
        return
        Show()

        * Write("Bienvenido humano")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Soy Tangerine")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Te invito a jugar el juego de las semillas que caen del cielo")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)
        * Write("En el tiras semillas del cielo")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Y debes evitar que toquen las nubes")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Como cuando no habia razón para nada")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Ahora el cielo es lo unico que hay que alcanzar")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Cuando logras que una semilla toque la tierra")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Veras que nacera un arbol")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Este arbol durara exactamente un minuto en crecer ")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Y sus frutos produciran mas capacidad para semilla")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("y tu poder de semilla incrementara")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Los humanos se encuentran entusiasmados por las cosechas de mandarinas")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        * Write("Vamos a por ellos!")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)

        //* Write("Tambien este juego es infinito, entonces no vallas por ahí buscando ningún final")
        //    * Do(() => {
        //        finished = false;
        //    })
        //* ContinueWhen(() => finished)

        //* Write("Hasta luego.")
        //    * Do(() => {
        //        finished = false;
        //    })
        //* ContinueWhen(() => finished)

        /// * Write("Por cierto, este juego lo jugaras hasta tu aburrimiento, ya que no tiene fin")
        //    * Do(() => {
        //        finished = false;
        //    })
        /// * ContinueWhen(() => finished)


        /// * Write("Hahahahaha...")
        //    * Do(() => {
        //        finished = false;
        //    })
        /// * ContinueWhen(() => finished)


        * Hide()

        * Do(() => { 

                starting.SetReady();
                clouds.VisibleClouds(Color.white);

        })

        * End();

    }

}
