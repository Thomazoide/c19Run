using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonedasCont : MonoBehaviour
{
    public static MonedasCont instancia;
    public TextMeshProUGUI texto;
    int cont = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(instancia == null){
            instancia = this;
        }
    }
    public void cambiarValor(int valor){
        cont += valor;
        texto.text = "X" + cont.ToString();
    }
}
