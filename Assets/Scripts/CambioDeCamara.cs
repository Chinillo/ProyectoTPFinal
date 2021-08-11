using UnityEngine;

public class CambioDeCamara : MonoBehaviour
{
    public GameObject camara1;
    public GameObject camara2;

    AudioListener camara1AudioLis;
    AudioListener camara2AudioLis;

    void Start()
    {
        camara1AudioLis = camara1.GetComponent<AudioListener>();
        camara2AudioLis = camara2.GetComponent<AudioListener>();

        cambioPosCamara(PlayerPrefs.GetInt("PosicionCamara"));
    }
    void Update()
    {
        CambiarCamara();
    }

    public void cameraPositonM()
    {
        Contador();
    }

    void CambiarCamara()
    { 
        if (Input.GetKeyDown(KeyCode.F))
        {
            Contador();
        }
    }

    void Contador()
    {
        
        int contadorCamara = PlayerPrefs.GetInt("PosicionCamara");
        contadorCamara++;
        cambioPosCamara(contadorCamara);
    }

    void cambioPosCamara(int posCamara)
    {
        if (posCamara > 1)
        {
            posCamara = 0;
        }

        PlayerPrefs.SetInt("PosicionCamara", posCamara);

        if (posCamara == 0)
        {
            camara1.SetActive(true);
            camara1AudioLis.enabled = true;

            camara2AudioLis.enabled = false;
            camara2.SetActive(false);       
        }

        if (posCamara == 1)
        {
            camara1.SetActive(false);
            camara1AudioLis.enabled = false;

            camara2AudioLis.enabled = true;
            camara2.SetActive(true);   
        }
    }
}