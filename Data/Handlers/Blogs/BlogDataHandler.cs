using Models.Blogs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.Handlers.Blogs
{
    class BlogDataHandler
    {
        private static readonly SqlConnection Db = ConnectionHandler.SqlConnection;

        public static IBlog GetBlogFromUid(string userUid)
        {
            Blog blogDto = new Blog();
            using (SqlConnection con = Db)
            {
                string query = "SELECT * FROM Blogs WHERE UID = @UserUID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@UserUID", SqlDbType.Int);
                    cmd.Parameters["@UserUID"].Value = userUid;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            blogDto.Id = reader.GetInt32(0);
                            blogDto.User = UserDataHandler.GetUserByUid(userUid);
                        }
                    }
                }
                con.Close();
            }

            return blogDto;
        }


        public static IEnumerable<IBlogPost> GetBlogPosts(int blogId)
        {
            IList<BlogPostDto> blogPosts = new List<BlogPostDto>();
            using (SqlConnection con = Db)
            {
                string query = "SELECT * FROM BlogPosts WHERE BlogID = @BlogID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@BlogID", SqlDbType.Int);
                    cmd.Parameters["BlogID"].Value = blogId;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BlogPostDto blogPost = new BlogPostDto
                            {
                                BlogId = blogId,
                                Id = reader.GetInt32(0),
                                Content = reader.GetString(1),
                                Comments = GetBlogComments(reader.GetInt32(0))
                            };
                            blogPosts.Add(blogPost);
                        }
                    }
                }
                con.Close();
            }
            return blogPosts;
        }
        public static IEnumerable<IBlogComment> GetBlogComments(int blogPostId)
        {
            IList<IBlogComment> blogComments = new List<IBlogComment>();
            using (SqlConnection con = Db)
            {
                string query = "SELECT * FROM BlogComments WHERE BlogPostID = @BlogPostID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("BlogPostID", SqlDbType.Int);
                    cmd.Parameters["BlogPostID"].Value = blogPostId;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        BlogCommentDto blogComment = new BlogCommentDto
                        {
                            Id = reader.GetInt32(0),
                            User = UserDataHandler.GetUserByUid(reader.GetString(1)),
                            Content = reader.GetString(2),
                            LikedBy = GetBlogCommentLikers(reader.GetInt32(0)),
                            Likes = reader.GetInt32(4)
                        };
                        blogComments.Add(blogComment);
                    }
                }
                con.Close();
            }
            return blogComments;
        }
        public static IEnumerable<IUser> GetBlogCommentLikers(int blogPostId)
        {
            IList<IUser> likers = new List<IUser>();
            using (SqlConnection con = Db)
            {
                string query = "SELECT * FROM BlogCommentLikers WHERE BlogPostID = @BlogPostID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@BlogPostID", SqlDbType.Int);
                    cmd.Parameters["BlogPostID"].Value = blogPostId;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        UserDto user = new UserDto
                        {
                            Id = reader.GetInt32(0),
                            Uid = reader.GetString(1),
                            Username = reader.GetString(2)
                        };
                        likers.Add(user);
                    }

                }
            }
            return likers;
        }
        public static void CreateBlogPost(IBlogPost blogPost)
        {
            using (SqlConnection con = Db)
            {
                string query = "INSERT INTO BlogPosts (BlogID,Content) VALUES (@BlogID,@Content)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@BlogID", SqlDbType.Int);
                    cmd.Parameters.Add("@Content", SqlDbType.Text);
                    cmd.Parameters["@BlogID"].Value = blogPost.BlogId;
                    cmd.Parameters["@Content"].Value = blogPost.Content;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void CreateBlog(string userUid)
        {
            using (SqlConnection con = Db)
            {
                string query = "INSERT INTO Blogs (UserUID) Values (@UserUID)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@UserUID", SqlDbType.Int);
                    cmd.Parameters["@UserUID"].Value = userUid;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateBlogComment(IBlogComment comment)
        {
            using (SqlConnection con = Db)
            {
                string query = "INSERT INTO BlogComments (UserID, BlogPostID, Content) VALUES (@UserID,@BlogPostID, @Content)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters.Add("@BlogPostID", SqlDbType.Int);
                    cmd.Parameters.Add("@Content", SqlDbType.Text);
                    cmd.Parameters["@UserID"].Value = comment.User.Id;
                    cmd.Parameters["@BlogPostID"].Value = comment.BlogPost.Id;
                    cmd.Parameters["@Content"].Value = comment.Content;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
