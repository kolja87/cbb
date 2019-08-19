namespace cbb.core
{
    using System.IO;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    /// <summary>
    /// Preferences options stored in this data model.
    /// </summary>
    public class Preferences
    {
        #region private members

        /// <summary>
        /// The preferences file name.
        /// </summary>
        private string file = "prefs.cbb";

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the repository locations.
        /// </summary>
        /// <value>
        /// The repository directories.
        /// </value>
        public List<string> Repository { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="Preferences"/> class.
        /// </summary>
        public Preferences()
        {

        }

        #endregion

        #region public methods

        /// <summary>
        /// Saves this instance of preferences in the .cbb file as xml structured data.
        /// </summary>
        public void Save()
        {
            // Store file in the location relative to the core executing assembly.
            var dataFile = Path.Combine(Path.GetDirectoryName(CoreAssembly.GetAssemblyLocation().ToString()), file);

            using (var stream = new FileStream(dataFile, FileMode.Create))
            {
                // Serialize state of the object in the file.
                var serializer = new XmlSerializer(typeof(Preferences));
                serializer.Serialize(stream, this);
            }
        }

        /// <summary>
        /// Loads this instance data from serialized file.
        /// </summary>
        /// <returns></returns>
        public static Preferences Load()
        {
            var dataFile = Path.Combine(Path.GetDirectoryName(CoreAssembly.GetAssemblyLocation().ToString()), "prefs.cbb");

            using (var stream = new FileStream(dataFile, FileMode.Open))
            {
                // Loads saved serialized data and return it as Preferences object.
                var deserializer = new XmlSerializer(typeof(Preferences));
                return (Preferences)deserializer.Deserialize(stream);
            }
        }

        #endregion
    }
}
