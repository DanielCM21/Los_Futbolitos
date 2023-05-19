using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Marcadores : MonoBehaviour
{
    private float Puntaje = 0;

    private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh= GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = Puntaje.ToString();

    }

    public void SumarPuntaje() {
        Puntaje += 1;
    }
}
