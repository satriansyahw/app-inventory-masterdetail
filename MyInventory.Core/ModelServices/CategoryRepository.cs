using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using MyInventory.Models;

namespace MyInventory.ModelServices
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields

        IEnumerable<Category> _items = null;

        #endregion

        #region Methods

        private Category CreateCategory(XElement x)
        {
            Category category = new Category()
            {
                Name = x.Element("Name").Value,
                Id = int.Parse(x.Element("Id").Value),
                Image = x.Element("Id").Value + ".jpg"
            };

            if (!string.IsNullOrEmpty(category.Image))
                category.LargeImage = typeof(ItemRepository).GetTypeInfo().Assembly.GetManifestResourceStream("MyInventory.Assets.Images.Category." + category.Image).ToByte();


            return category;
        }

        public virtual Category Get(int id)
        {
            return this.GetAll().FirstOrDefault(o => o.Id == id);
        }

        public virtual IEnumerable<Category> GetAll()
        {
            if (_items == null)
            {
                XDocument doc = XDocument.Load(typeof(CategoryRepository).GetTypeInfo().Assembly.GetManifestResourceStream("MyInventory.Assets.Data.Categories.xml"));

                var query = from x in doc.Descendants("Category") select CreateCategory(x);

                _items = query.ToList();
            }

            return _items;
        }

        public virtual Category GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(o => o.Name == name);
        }

        #endregion
    }
}