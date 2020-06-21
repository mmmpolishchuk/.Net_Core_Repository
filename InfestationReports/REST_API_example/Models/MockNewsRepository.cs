using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http.OData;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace REST_API_example.Models
{
    public class MockNewsRepository : INewsRepository
    {
        private List<News> News = new List<News>
        {
            new News
            {
                Id = 0, Title = "Humanity finally colonized the Mercury!!", Text = "", AuthorName = "Jeremy Clarkson",
                IsFake = true
            },
            new News
            {
                Id = 1, Title = "Increase your lifespan by 10 years, every morning you need...", Text = "",
                AuthorName = "Svetlana Sokolova", IsFake = true
            },
            new News
            {
                Id = 2, Title = "Scientists estimated the time of the vaccine invention: it is a summer of 2021",
                Text = "", AuthorName = "John Jones", IsFake = false
            },
            new News
            {
                Id = 3, Title = "Ukraine reduces the cost of its obligations!", Text = "", AuthorName = "Cerol Denvers",
                IsFake = false
            },
            new News
            {
                Id = 4, Title = "A new species were discovered in Africa: it is blue legless cat", Text = "",
                AuthorName = "Jimmy Felon", IsFake = true
            },
        };

        public IEnumerable<News> GetAllNews(bool isFake)
        {
            return News.Where(news => news.IsFake == isFake);
        }

        public void CreateNews(News news)
        {
            News.Add(news);
        }

        public void DeleteNews(int id)
        {
            News.RemoveAt(id);
        }

        public void MoveNews(int id, News anotherNews)
        {
            News[id].Id = anotherNews.Id;
            News[id].Title = anotherNews.Title;
            News[id].Text = anotherNews.Text;
            News[id].AuthorName = anotherNews.AuthorName;
            News[id].IsFake = anotherNews.IsFake;
        }
        public void UpdateNews(int id, News news)
        {
            var newsToUpdate = News.Find(n => n.Id == id);

            if (news.Title != null)
            {
                newsToUpdate.Title = news.Title;
            }
            else if (news.Text != null)
            {
                newsToUpdate.Text = news.Text;
            }
            else if (news.AuthorName != null)
            {
                newsToUpdate.AuthorName = news.AuthorName;
            }
        }
    }
}
