using UnityEngine;
using UnityEngine.Video;

public class FunnelInteraction : MonoBehaviour
{
    public GameObject spaceTransitionVideo;  // Reference to the RawImage or video display object
    private VideoPlayer videoPlayer;  // Reference to the VideoPlayer component

    public GameObject[] infoPanels;  // Array of info panels for each segment

    void Start()
    {
        // Get the Video Player component attached to the video object
        videoPlayer = spaceTransitionVideo.GetComponent<VideoPlayer>();

        // Subscribe to the prepareCompleted event
        videoPlayer.prepareCompleted += OnVideoPrepared;

        // Optional: If the video should start preparing in advance
        videoPlayer.Prepare();
    }

    // Method that is triggered when the video is prepared
    void OnVideoPrepared(VideoPlayer vp)
    {
        // Play the video once it's ready
        vp.Play();
    }

    // Play the space transition video
    void PlaySpaceTransition(int segmentIndex)
    {
        // Make sure the video object is active before playing the video
        spaceTransitionVideo.SetActive(true);

        // If the video is already prepared, just play it, otherwise wait for preparation
        if (videoPlayer.isPrepared)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Prepare();
        }

        // Start coroutine to wait for video to finish and show info panel
        StartCoroutine(WaitForVideoEnd(segmentIndex));
    }

    // Wait until the video ends before showing the info panel
    System.Collections.IEnumerator WaitForVideoEnd(int segmentIndex)
    {
        // Wait until the video finishes playing
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // Hide the video object once the video finishes
        spaceTransitionVideo.SetActive(false);

        // Show the corresponding info panel for the tapped segment
        ShowInfoPanel(segmentIndex);
    }

    void ShowInfoPanel(int index)
    {
        // Hide all info panels first
        foreach (GameObject panel in infoPanels)
        {
            panel.SetActive(false);
        }

        // Show the correct panel based on the segment index
        if (index < infoPanels.Length)
        {
            infoPanels[index].SetActive(true);
        }
    }
}
