using Vuforia;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;

public class ReadARImageTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;

    public AudioSource leavesAudio;
    public AudioSource spellAudio;
    public PlayableDirector wolfDirector;
    public GameObject vidCanvas;
    public GameObject vidRawImage;


    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            //   audio.Play();
            //leavesAudio.Play();
            //spellAudio.Play();
            wolfDirector.Evaluate();
            wolfDirector.Play();
        }
        else
        {
            // Stop audio when target is lost
            //  audio.Stop();
            vidRawImage.GetComponentInChildren<VideoPlayer>().Stop();
            vidCanvas.SetActive(false);
            wolfDirector.Stop();
            
            
  
        }
    }
}


