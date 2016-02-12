using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Intersoft.Crosslight;
using MyInventory.Infrastructure;
using MyInventory.Models;

namespace MyInventory.ModelServices
{
    /// <summary>
    ///     Represents a XML data repository that provides read-only data access.
    /// </summary>
    public class ItemRepository : IItemRepository
    {
        #region Fields

        IList<Item> _items = null;

        #endregion

        #region Properties

        private ICategoryRepository CategoryRepository
        {
            get
            {
                if (Container.Current.CanResolve<ICategoryRepository>())
                    return Container.Current.Resolve<ICategoryRepository>();
                else
                    return new CategoryRepository(); // design time support
            }
        }

        #endregion

        #region Methods

        public Item Create()
        {
            return new Item();
        }

        private Item CreateItem(XElement x)
        {
            Item item = new Item()
            {
                Name = x.Element("Name").Value,
                Image = x.Element("Image").Value,
                CategoryId = int.Parse(x.Element("CategoryId").Value),
                Category = this.CategoryRepository.Get(int.Parse(x.Element("CategoryId").Value)),
                Quantity = int.Parse(x.Element("Qty").Value),
                Price = decimal.Parse(x.Element("Price").Value, CultureInfo.InvariantCulture),
                Location = x.Element("Location").Value,
                Description = x.Element("Description").Value,
                SerialNumber = x.Element("SerialNumber").Value,
                Notes = x.Element("Notes").Value,
                IsSold = ParseBoolean(x.Element("IsSold")),
                PurchaseDate = DateTime.Parse(x.Element("PurchaseDate").Value, CultureInfo.InvariantCulture),
            };

            if (item.IsSold)
                item.SoldDate = DateTime.Parse(x.Element("SoldDate").Value, CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(item.Image))
            {
                item._thumbnailImage = typeof(ItemRepository).GetTypeInfo().Assembly.GetManifestResourceStream("MyInventory.Assets.Images.Thumbnail." + item.Image).ToByte();
                item._largeImage = typeof(ItemRepository).GetTypeInfo().Assembly.GetManifestResourceStream("MyInventory.Assets.Images.Large." + item.Image).ToByte();
            }

            return item;
        }

        public void Delete(Item entity)
        {
            _items.Remove(entity);
        }

        public void Delete(IEnumerable<Item> entities)
        {
            foreach (Item item in entities)
            {
                this.Delete(item);
            }
        }

        public Item Get(string id)
        {
            return this.GetAll().FirstOrDefault(o => o.Name == id);
        }

        public IEnumerable<Item> GetAll()
        {
            if (_items == null)
            {
                XDocument doc = XDocument.Load(typeof(ItemRepository).GetTypeInfo().Assembly.GetManifestResourceStream("MyInventory.Assets.Data.Inventories.xml"));

                var itemsQuery = from x in doc.Descendants("Item") select CreateItem(x);

                _items = new ObservableCollection<Item>(itemsQuery);
            }

            return _items;
        }

        public CategoryGroup GetCategoryGroup(int categoryId)
        {
            return _items.Where(o => o.Category.Id == categoryId).GroupBy(o => o.Category.Name).Select(o => new CategoryGroup(o)).FirstOrDefault();
        }

        public GroupItem<Item> GetLocationGroup(string group)
        {
            return _items.Where(o => o.Location == group).GroupBy(o => o.Location).Select(o => new GroupItem<Item>(o)).FirstOrDefault();
        }

        public void Insert(Item entity)
        {
            _items.Add(entity);
        }

        private bool ParseBoolean(XElement element)
        {
            if (element == null || string.IsNullOrEmpty(element.Value))
                return false;

            return bool.Parse(element.Value);
        }

        public void Reject(Item entity)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChangesAsync(Action onSuccess = null, Action<Exception> onError = null)
        {
            // Xml repository saving isn't implementated
            throw new System.NotImplementedException();
        }

        public void Update(Item entity)
        {
            // Doesn't need to update anything for Xml repository
        }

        #endregion
    }
}