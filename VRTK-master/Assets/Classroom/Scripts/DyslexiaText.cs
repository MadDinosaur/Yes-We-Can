using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DyslexiaText : MonoBehaviour
{
    TMP_Text boardText;
    
    string[] words;
    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        boardText = GetComponent<TMP_Text>();
        words = getWords();

        InvokeRepeating("ChangeText", 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ChangeText()
    {
        boardText.SetText(messUpText());
    }

    string[] getWords()
    {
        return boardText.text.Split(' ');
    }

    void messUpWords()
    {
        for (int i = 0; i < words.Length; i++)
        {
            if (rnd.Next(1, 10) > 1) continue;
            words[i] = messUpWord(words[i]);
        }
    }

    string messUpWord(string word)
    {
        if (word.Length < 3)
        {

            return word;
        }

        return word[0] + messUpMessyPart(word.Substring(1, word.Length - 2)) + word[word.Length - 1];
    }

    string messUpMessyPart(string word)
    {
        if (word.Length < 2)
        {

            return word;
        }

        int a, b;
        do
        {

            a = rnd.Next(0, word.Length - 1);
            b = rnd.Next(0, word.Length - 1);
        } while (!(a < b));

        return word.Substring(0, a) + word[b] + word.Substring(a + 1, b - (a+1)) + word[a] + word.Substring(b + 1);
    }

    string messUpText()
    {
        messUpWords();
        return string.Join(" ", words);
    }
}
