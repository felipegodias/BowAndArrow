using System;
using System.Collections.Generic;
using System.Threading;

using SpeechLib;

using UnityEngine;

using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{

    private readonly List<VoiceThread> m_voiceThreads = new List<VoiceThread>();

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
        Action<VoiceThread> action = vt =>
        {
            Thread.Sleep(delayInMilliseconds);
            vt.Voice = new SpVoice();
            vt.Voice.Speak(text);
            m_voiceThreads.Remove(vt);
        };
        var voiceThread = new VoiceThread();
        var thread = new Thread(() => action(voiceThread));
        voiceThread.Thread = thread;
        m_voiceThreads.Add(voiceThread);
        thread.Start();
    }

    private void OnDestroy()
    {
        foreach (VoiceThread voiceThread in m_voiceThreads) { voiceThread.Kill(); }
    }

    [Serializable]
    public class SFXEntry
    {

        public string Name;

        public AudioSource[] Sources;

    }

    private class VoiceThread
    {

        public Thread Thread;

        public SpVoice Voice;

        public void Kill()
        {
            Voice?.Skip("Sentence", int.MaxValue);
            Thread.Abort();
        }

    }

}
