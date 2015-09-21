using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using AutoMapper;

namespace BLL.Services
{
    public class ArticlesService : IArticlesService
    {
        private IUnitOfWork Db { get; set; }
        public ArticlesService(IUnitOfWork uow)
        {
            Db = uow;
        }

        private int articleLimit = 3;

        public int ArticleLimit
        {
            get { return articleLimit; }
        }

        private IEnumerable<ArticleDTO> GetAllArticles(int editionId)
        {
            Mapper.CreateMap<Article, ArticleDTO>();
            return Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Db.Articles.GetBy(article => article.Edition.EditionId == editionId)); 
        }

        private IEnumerable<ArticleDTO> GetLimitedArticles(int editionId)
        {
            IEnumerable<ArticleDTO> articles = GetAllArticles(editionId);
            return articles.Take(ArticleLimit);
        }

        public IEnumerable<ArticleDTO> GetArticles(int editionId, bool isSubscribed)
        {
            //if (isSubscribed)
            {
                return GetAllArticles(editionId);
            }
            //return GetLimitedArticles(editionId);
        }

        public EditionDTO GetEditionById(int editionId)
        {
            Mapper.CreateMap<Edition, EditionDTO>();
            return Mapper.Map<Edition, EditionDTO>(Db.Editions.GetByID(editionId));
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
