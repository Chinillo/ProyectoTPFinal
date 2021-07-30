using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.Indicators
{
    [RequireComponent(typeof(Canvas))] //agrego componente canvas
    public class OffScreenIndicators : MonoBehaviour
    {
        public Camera activeCamera; //camara para que funcionen los indicadores
        public List<Indicator> targetIndicators; //lista de indicadores que necesitemos
        public GameObject indicatorPrefab; //objeto para instanciar un nuevo indicador
        public float checkTime = .1f; //segundos de espera
        public Vector2 offset; //por si tenemos que sobrescribir la posicion del objeto

        private Transform _transform;
        void Start()
        {
            _transform = transform;
            InstantiateIndicators(); //inicializa apenas se crea el objeto

            Timing.RunCoroutine(UpdateIndicators().CancelWith(gameObject)); //si el gameobject es eliminado tmb se elimina la courutina y dejamos tranqui al while
        }

        private void InstantiateIndicators() //recorriendo la lista de indicadores y instanciandolos en el juego si no, se tendra que realizar uno
        {
            foreach (var targetIndicator in targetIndicators) //para recorrerla, utilizo un foreach
            {
                if(targetIndicator.indicatorUI == null) //es nulo ya que no lo setié
                {
                    targetIndicator.indicatorUI = Instantiate(indicatorPrefab).transform; //lo creo
                    targetIndicator.indicatorUI.SetParent(_transform); //para que queden todos los indicadores dentro del canvas hago esto
                }

                var rectTransform = targetIndicator.indicatorUI.GetComponent<RectTransform>(); //intento conseguir el componente rect transform
                if (rectTransform == null) //si es nulo no lo tiene
                {
                    rectTransform = targetIndicator.indicatorUI.gameObject.AddComponent<RectTransform>(); //asi que creo un componente
                }

                targetIndicator.rectTransform = rectTransform; //y lo seteo
            }
        }

        private void UpdatePosition(Indicator targetIndicator) //actualizar la posicion de los indicadores
        {
            var rect = targetIndicator.rectTransform.rect; //accedo a los limites del objeto de la imagen

            var indicatorPosition = activeCamera.WorldToScreenPoint(targetIndicator.target.position); //uso WorldToScreenPointpara convertir las cordenadas del mundo en coordenadas de pantalla, target.position es el target que quiero seguir

            if(indicatorPosition.z < 0) //si el objeto esta atras de la camara, invierto las posiciones de y & x
            {
                indicatorPosition.y = -indicatorPosition.y;
                indicatorPosition.x = -indicatorPosition.x;
            }
            var newPosition = new Vector3(indicatorPosition.x, indicatorPosition.y, indicatorPosition.z); //guardo una posicion para restar la rotacion

            indicatorPosition.x = Mathf.Clamp(indicatorPosition.x, rect.width / 2, Screen.width - rect.width / 2) + offset.x; //modifico los valores para que queden dentro de la pantalla 
            indicatorPosition.y = Mathf.Clamp(indicatorPosition.y, rect.height / 2, Screen.height - rect.height / 2) + offset.y; //divido entre 2 para obtener la mitad de la pantalla (ancho y alto) para que la posicion se mantenga dentro de los limites de la pantalla
            indicatorPosition.z = 0; //no necesita haber profundidad

            targetIndicator.indicatorUI.up = (newPosition - indicatorPosition.normalized); //realizo la rotacion utilizando up, y normalizo los vectores para pasarlos de 0 a 1
            targetIndicator.indicatorUI.position = indicatorPosition; //actualizamos por fin la posicion del objeto
        }

        private IEnumerator<float> UpdateIndicators() //courutine que devuelve un IEnumerator necesario para MEC
        {
            while (true) //recorre dentro de la courutine hasta que se termine el programa
            {
                foreach (var targetIndicator in targetIndicators) //recorremos los indicadores con un foreach
                {
                    UpdatePosition(targetIndicator); //llamamos a la funcion
                }

                yield return Timing.WaitForSeconds(checkTime); //esperar una cantidad de segundos determinada por el usuario
            }
        }
    }

    [System.Serializable] //necesito esto para que unity deje poner indicadores
    public class Indicator
    {
        public Transform target; //objetivo que el jugador va a estar "siguiendo"
        public Transform indicatorUI; //interfaz grafica del integrador
        public RectTransform rectTransform; //no visible por el usuario
    }
}