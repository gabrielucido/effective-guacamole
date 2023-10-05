using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetFraseDisplay : MonoBehaviour
{
   
    public TMP_Text fraseAlvoEmbaralhadaText; // Arraste o objeto TextMeshProUGUI para cá

    private string targetPhrase;
    private string shuffledPhrase;

    private void Start()
    {
        targetPhrase = fraseAlvoEmbaralhadaText.text;
        shuffledPhrase = ShuffleString(targetPhrase);
        fraseAlvoEmbaralhadaText.text = shuffledPhrase;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            char pressedKey = Input.inputString[0];

            if (char.IsLetter(pressedKey))
            {
                // Verifique se a letra está presente na frase-alvo original
                if (targetPhrase.Contains(pressedKey.ToString()))
                {
                    // Encontre a primeira ocorrência da letra na frase embaralhada
                    int index = shuffledPhrase.IndexOf(pressedKey);

                    if (index >= 0)
                    {
                        // Substitua a letra encontrada por um espaço em branco
                        shuffledPhrase = shuffledPhrase.Remove(index, 1).Insert(index, " ");
                        fraseAlvoEmbaralhadaText.text = shuffledPhrase;
                    }
                }
            }
        }
    }

    private string ShuffleString(string str)
    {
        char[] array = str.ToCharArray();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            char value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
        return new string(array);
    }
}
