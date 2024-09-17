using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace OpenSilverDynamicDemoData
{
    public class DemoObject
    {
        private Dictionary<string, int> _counter = new Dictionary<string, int>();

        public string this[string key]
        {
            get
            {
                string modifiedKey = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                    key.Replace("_", " "));
                if (!_counter.ContainsKey(key))
                {
                    _counter.Add(key, 0);
                }
                _counter[key]++;
                return modifiedKey + " " + _counter[key];
            }
        }
    }

    public class DemoCollection
    {
        public IEnumerable<DemoObject> this[string key]
        {
            get
            {
                int.TryParse(key, out var collectionSize);
                if (collectionSize == 0)
                {
                    collectionSize = 10;
                }

                var demoObject = new DemoObject();
                return Enumerable.Repeat(demoObject, collectionSize).ToList();
            }
        }
    }

    public class Model
    {
        public DemoCollection DemoCollection { get; set; }

        public Model()
        {
            DemoCollection = new DemoCollection();
        }
    }

    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Enter construction logic here...
            DataContext = new Model();
        }
    }
}
