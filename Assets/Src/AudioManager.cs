using System;
using System.Threading;

using SpeechLib;

using UnityEngine;

using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private SFXEntry[] m_entries;

    public void Play(string sfx)
    {
        foreach (SFXEntry sfxEntry in m_entries)
        {
            if (!string.Equals(sfxEntry.Name, sfx, StringComparison.OrdinalIgnoreCase)) { continue; }

            AudioSource source = sfxEntry.Sources[Random.Range(0, sfxEntry.Sources.Length)];
            Instantiate(source);
        }
    }

    public void Speak(int delayInMilliseconds, string text)
    {
        Action action = () => {
            Thread.Sleep(delayInMilliseconds);
            var voice = new SpVoice();
            voice.Speak(text);
        };
        var thread = new Thread(() => action());
        thread.Start();
    }

    [Serializable]
    public class SFXEntry
    {

        public string Name;

        public AudioSource[] Sources;

    }

}