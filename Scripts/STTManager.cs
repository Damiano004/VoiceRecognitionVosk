using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STTManager : MonoBehaviour
{
    [SerializeField] private VoskSpeechToText vSTT;
    [SerializeField] private Text text;
    [Tooltip("Turns off the microphone when a result is returned")]
    [SerializeField] private bool disabeOnResult;
    // startMicrophone = true -> don't start microphone onInit...yeah it's confusing but it is what it is i guess
    private readonly bool startMicrophone = true;
    [HideInInspector] public bool running;
    // list of numbers
    private readonly List<List<string>> WORD_NUMBER = new List<List<string>>()
    {
        new List<string>(){"zero","0"},
        new List<string>(){"uno","1"},
        new List<string>(){"due","2"},
        new List<string>(){"tre","3"},
        new List<string>(){"quattro","4"},
        new List<string>(){"cinque","5"},
        new List<string>(){"sei","6"},
        new List<string>(){"sette","7"},
        new List<string>(){"otto","8"},
        new List<string>(){"nove","9"}
    };
    
    void Start()
    {
        running = !startMicrophone;
        vSTT.StartVoskStt(startMicrophone: startMicrophone);
        Debug.Log("VoskStt started");
        vSTT.OnTranscriptionResult += HandleTranscriptionResult;
    }

    private void HandleTranscriptionResult(string obj)
    {
        // initialize result text
        string resultText = "Result: ";
        // null check just in case
        if(null == obj)
        {
            Debug.Log("Transcription result returned a null object");
            return;
        }
        Debug.Log(obj);
        // returns an object that contains the "text" and "confidence" value for each alternative found
        RecognitionResult result = new RecognitionResult(obj);
        // cycles through all the alternatives found
        for (int i = 0; i < result.Phrases.Length; i++)
        {
            // separate each alternative with a \n
            if (i > 0)
            {
                resultText += "\n";
            }
            // for each word in the alternative
            foreach (string word in result.Phrases[i].Text.Split(' '))
            {
                // convert the word numbers found into numbers
                resultText += WordToNumberConverter(word);
            }
            resultText += "["+ result.Phrases[i].Confidence + "]";
        }
        // put the result onto a UI text
        text.text = resultText;
        if (disabeOnResult)
        {
            Debug.Log("Disabeling on result...");
            CallToggleRecording();
        }
    }

    // converts words into their number
    private string WordToNumberConverter(string word)
    {
        List<string> match = WORD_NUMBER.Find(value => value[0] == word);
        // if match found replace the word with the number
        if (null != match)
        {
            Debug.LogFormat("switching {0} to {1}", word, match[1]);
            return match[1] + " ";
        }
        // else leave the word as it is
        else
        {
            Debug.Log("No matches found, returning " + word);
            return word + " ";
        }
    }

    public void CallToggleRecording()
    {
        running = !running;
        vSTT.ToggleRecording();
    }
}
