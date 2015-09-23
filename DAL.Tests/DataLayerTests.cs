using BLL.Services;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tests
{
    [TestFixture]
    public class DataLayerTests
    {

        //[Test]
        //public void Can_Add_Entity()
        //{
        //    EFUnitOfWork ef = new EFUnitOfWork();

        //    EditionsService es = new EditionsService(ef);

        //    es.AddArticle(new Article { Title = "123123123"} );

        //    var res = es.GetArticles();

        //    Assert.AreEqual(1, res);

        //}

        //[Test]
        //public void Can_Get_Cat()
        //{
        //    EFUnitOfWork ef = new EFUnitOfWork();

        //    EditionsService es = new EditionsService(ef);

        //    var res = es.GetCategories();

        //    Assert.AreEqual(1, res);

        //}


        [Test]
        public void Can_Get_Cat()
        {
            EFUnitOfWork ef = new EFUnitOfWork();

            var sample = new Category() { Name = "yura skaki" };

            ef.Categories.Create(sample);

            Assert.NotNull(ef.Categories.GetAll());

        }
    }
}
