using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        // Creating videos
        List<Video> videos = new List<Video>
        {
            new Video("Video 1", "Author 1", 120),
            new Video("Video 2", "Author 2", 180),
            new Video("Video 3", "Author 3", 90),
            new Video("Video 4", "Author 4", 150)
        };

        // Adding comments to videos
        videos[0].AddComment("User1", "Great video!");
        videos[0].AddComment("User2", "I learned a lot from this.");
        videos[0].AddComment("User3", "This video is terrible!");
        videos[0].AddComment("User4", "Do the chickens have large talons?");

        videos[1].AddComment("ViewerX", "Nice content!");
        videos[1].AddComment("ViewerY", "Could you make more videos on this topic?");
        videos[1].AddComment("Viewerz", "Awesome video bro!");

        videos[2].AddComment("FollowerA", "This was helpful.");
        videos[2].AddComment("FollowerB", "Thank you for more resources on this topic.");
        videos[2].AddComment("FollowerC", "Do you have more videos like this?");

        videos[3].AddComment("Subscriber1", "Keep up the good work!");
        videos[3].AddComment("Subscriber2", "Looking forward to the next one.");
        videos[3].AddComment("Subscriber3", "Do you put out a video every week?");

        // Displaying information for each video
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}