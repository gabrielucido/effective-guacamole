using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterPlacement : MonoBehaviour
{
 public Transform letterContainer;
    public TMP_Text letterPrefab;
    public TMP_Text fraseAlvoText;
    private string targetPhrase;
    private string currentInput = "";

    public GameObject targetFraseDisplay;

    public PlayerMovement _playerMovement;

    public PlayerInputHandler _playerInputHandler;

    public GameObject letterController;

    public GameObject officeUI;

    private Dictionary<char, int> letterCounts = new Dictionary<char, int>();

    private void Start()
    {
        targetPhrase = fraseAlvoText.text;

        _playerMovement = GetComponent<PlayerMovement>();

        // Inicialize o dicionário de contagem de letras
        foreach (char letter in targetPhrase)
        {
            if (char.IsLetter(letter))
            {
                letterCounts[letter] = 0;
            }
        }
        
    }

    private void Update()
    {
            if (Input.anyKeyDown)
            {
           
                char pressedKey = Input.inputString[0];

                if (char.IsLetter(pressedKey) && targetPhrase.Contains(pressedKey.ToString()))
                {
                    // Verifica se ainda é possível adicionar a letra
                    if (letterCounts[pressedKey] < CountOccurrences(targetPhrase, pressedKey))
                    {
                        AddLetter(pressedKey);
                        letterCounts[pressedKey]++;
                    }
                }
            }
            //  else 
            // {
            //     Debug.Log(currentInput);
            //     Debug.Log(currentInput.Length);
            //     Debug.Log(targetPhrase.Length);
            //     Debug.Log("essa é a target phrase " + targetPhrase);
            // }
           if(currentInput == targetPhrase)
           {
            Debug.Log("Verdade");
            officeUI.SetActive(false);
            _playerMovement.transform.position = new Vector3 (-1.5f,0.124f,0);
           }
        //    else{
        //     Debug.Log("Nao sao e nao sei pq");
        //    }
        
    }

    private int CountOccurrences(string str, char letter)
    {
        int count = 0;
        foreach (char c in str)
        {
            if (c == letter)
            {
                count++;
            }
        }
        return count;
    }
    public void AddLetter(char letter)
    {
        currentInput += letter;
        UpdateLetterDisplay();
    }

    // Função para atualizar a exibição das letras com base na entrada atual
    private void UpdateLetterDisplay()
    {
    // Percorra cada letra na frase-alvo
    for (int i = 0; i < targetPhrase.Length; i++)
    {
        TMP_Text letterText = Instantiate(letterPrefab, letterContainer);
        char letter = targetPhrase[i];

        // Verifique se a letra está na entrada atual
        if (currentInput.Contains(letter.ToString()))
        {
            letterText.text = letter.ToString();
        }
        else
        {
            
            letterText.text = "_"; // Use "_" para representar letras ausentes
        }

        // Posicione as letras com base em sua ordem na frase-alvo
        letterText.rectTransform.localPosition = new Vector3(i * 50, 0, 0);
    }
    }

    // Função para verificar se o jogador completou a frase
    public bool CheckCompletion()
    {
        return currentInput == targetPhrase;
    }

    private string ShuffleString(string str)
    {
        char[] array = str.ToCharArray();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            char value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
        return new string(array);
    }
}
