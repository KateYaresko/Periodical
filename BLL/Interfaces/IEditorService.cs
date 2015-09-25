using BLL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEditorService
    {
        List<CategoryEdit> GetCategories();
        List<EditionEdit> GetEditions();
        List<ArticleEdit> GetArticles();

        void CreateCategory(CategoryEdit category);
        void CreateEdition(EditionEdit edition);
        void CreateArticle(ArticleEdit article);

        void EditCategory(CategoryEdit category);
        void EditEdition(EditionEdit edition);
        void EditArticle(ArticleEdit article);

        void DeleteCategory(int categoryId);
        void DeleteEdition(int editionId);
        void DeleteArticle(int articleId);

        void Dispose();
    }
}
