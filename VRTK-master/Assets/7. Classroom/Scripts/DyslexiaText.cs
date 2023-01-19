using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DyslexiaText : MonoBehaviour
{
    TMP_Text boardText;
    
    string[] words;

    public int velocity = 30;
    int velocityTracker;

    // Start is called before the first frame update
    void Start()
    {
        boardText = GetComponent<TMP_Text>();
        velocityTracker = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (velocityTracker == 0) { ChangeText(); velocityTracker = velocity; }
        else velocityTracker--;
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
            if (Random.Range(1, 6) > 1) continue;
            words[i] = messUpWord(words[i]);
        }
    }

    string messUpWord(string word)
    {
        //Case with paragraph
        if (word[word.Length -1] =='\n')
        {
            if (word.Length - 1 < 3)
            {

                return word;
            }
            if (word.Length - 1 < 4)
            {
                return messUpMessyPart(word);
            }

            return word[0] + messUpMessyPart(word.Substring(1, word.Length - 3)) + word[word.Length - 2] + word[word.Length - 1];
        }

        //Case without paragraph
        if (word.Length < 3)
        {
            
            return word;
        }
        if (word.Length < 4)
        {
            return messUpMessyPart(word);
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

            a = Random.Range(0, word.Length);
            b = Random.Range(0, word.Length);
        } while (!(a < b));

        if (b == word.Length - 1) return word.Substring(0, a) + word[b] + word.Substring(a + 1, b - (a + 1)) + word[a];
        return word.Substring(0, a) + word[b] + word.Substring(a + 1, b - (a+1)) + word[a] + word.Substring(b + 1);
    }

    string messUpText()
    {
        words = getWords();
        messUpWords();
        return string.Join(" ", words);
    }
}
