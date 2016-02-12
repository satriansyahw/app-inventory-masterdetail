using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.Specialized;
using MyInventory.Models;
using Intersoft.Crosslight;
using MyInventory.ModelServices;
using MyInventory.ViewModels;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace MyInventory.WinRT.Data
{
    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public sealed class DesignTimeDataSource
    {
        public IEnumerable<Item> Items { get; private set; }
        public DesignItemDetailViewModel ItemDetailViewModel { get; private set; }
        public IEnumerable<GroupItem<Item>> AllGroups { get; private set; }
        public GroupItem<Item> Group { get; private set; }
        public string ErrorTrace { get; private set; }

        public DesignTimeDataSource()
        {
            ItemRepository repository = new ItemRepository();

            this.Items = repository.GetAll();
            this.AllGroups = this.Items.OrderBy(o => o.Location).GroupBy(o => o.Location).Select(o => new GroupItem<Item>(o)).ToList();
            this.Group = this.AllGroups.First();
            this.ItemDetailViewModel = new DesignItemDetailViewModel(this.Group.First());
        }
    }

    public sealed class DesignItemDetailViewModel 
    {
        public Item Item { get; set; }

        public DesignItemDetailViewModel(Item item)
        {
            this.Item = item;
        }
    }

}
