using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IArticlesService
    {
        int ArticleLimit { get; }
        IEnumerable<ArticleDTO> GetArticles(int editionId, bool isSibscribed);
        EditionDTO GetEditionById(int editionId);
        void Dispose();
    }
}
