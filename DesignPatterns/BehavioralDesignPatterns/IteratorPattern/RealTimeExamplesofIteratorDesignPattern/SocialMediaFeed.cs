using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RealTimeExamplesofIteratorDesignPattern
{
    /// <summary>
    /// Client Code
    /// </summary>
    public static class SocialMediaFeed
    {
        public static void Run()
        {
            var userFeed = new Feed();
            userFeed.AddPost(new TextUpdate { Author = "Pranaya", Date = DateTime.Now, Text = "Welcome to Dot Net Tutorials" });
            userFeed.AddPost(new ImagePost { Author = "Kumar", Date = DateTime.Now, ImageURL = "Path/Image.jpg" });
            userFeed.AddPost(new VideoPost { Author = "Roit", Date = DateTime.Now, VideoURL = "Path/Video.mp4" });
            var iterator = userFeed.CreateIterator();
            while (iterator.HasNext())
            {
                var post = iterator.Next();
                if (post is TextUpdate textPost)
                {
                    Console.WriteLine($"{textPost.Author}: {textPost.Text}");
                }
                else if (post is ImagePost imgPost)
                {
                    Console.WriteLine($"{imgPost.Author} shared an image: {imgPost.ImageURL}");
                }
                else if (post is VideoPost videoPost)
                {
                    Console.WriteLine($"{videoPost.Author} shared a video: {videoPost.VideoURL}");
                }
            }
            
        }
    }
    //Define the Post
    public abstract class Post
    {
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
    public class TextUpdate : Post
    {
        public string Text { get; set; }
    }
    public class ImagePost : Post
    {
        public string ImageURL { get; set; }
    }
    public class VideoPost : Post
    {
        public string VideoURL { get; set; }
    }
    public class LinkShare : Post
    {
        public string Link { get; set; }
    }
    
    //Implement the Feed
    public class Feed : INextAggregate<Post>
    {
        private List<Post> _posts = new List<Post>();
        public void AddPost(Post post)
        {
            _posts.Add(post);
        }
        public INextIterator<Post> CreateIterator()
        {
            return new FeedIterator(this);
        }
        private class FeedIterator : INextIterator<Post>
        {
            private Feed _feed;
            private int _currentIndex = 0;
            public FeedIterator(Feed feed)
            {
                _feed = feed;
            }
            public bool HasNext()
            {
                return _currentIndex < _feed._posts.Count;
            }
            public Post Next()
            {
                return _feed._posts[_currentIndex++];
            }
        }
    }
}
