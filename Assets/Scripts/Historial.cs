using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Historial : MonoBehaviour
{
    private SqliteHelper db;
    [SerializeField]
    private GameObject textTemplate;
    public void GenerarTextoPuntuaciones()
    {
        List<PuntuacionRegistrada> puntuaciones = db.ObtenerPuntuaciones();
        foreach (PuntuacionRegistrada p in puntuaciones)
        {
            GameObject texto = Instantiate(textTemplate) as GameObject;
            texto.SetActive(true);
            texto.GetComponent<TextListPuntuacion>().EstablecerTexto(p.nombresUsuario);
            texto.transform.SetParent(textTemplate.transform.parent, false);

            GameObject texto2 = Instantiate(textTemplate) as GameObject;
            texto2.SetActive(true);
            texto2.GetComponent<TextListPuntuacion>().EstablecerTexto(p.nombreNivel);
            texto2.transform.SetParent(textTemplate.transform.parent, false);

            GameObject texto3 = Instantiate(textTemplate) as GameObject;
            texto3.SetActive(true);
            texto3.GetComponent<TextListPuntuacion>().EstablecerTexto(p.tiempoNivel.ToString());
            texto3.transform.SetParent(textTemplate.transform.parent, false);

            GameObject texto4 = Instantiate(textTemplate) as GameObject;
            texto4.SetActive(true);
            texto4.GetComponent<TextListPuntuacion>().EstablecerTexto(p.puntuacionNivel.ToString());
            texto4.transform.SetParent(textTemplate.transform.parent, false);

            GameObject texto5 = Instantiate(textTemplate) as GameObject;
            texto5.SetActive(true);
            texto5.GetComponent<TextListPuntuacion>().EstablecerTexto(p.fecha);
            texto5.transform.SetParent(textTemplate.transform.parent, false);


        }
    }
    // Start is called before the first frame update
    void Start()
    {
        db = new SqliteHelper();
        GenerarTextoPuntuaciones();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
