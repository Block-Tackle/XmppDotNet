using System.Collections.Generic;
using System.Linq;
using Matrix.Core.Attributes;
using Matrix.Xml;
using Matrix.Xmpp.XData;

namespace Matrix.Xmpp.Disco
{
    /// <summary>
    /// Disco Information
    /// </summary>
    [XmppTag(Name = Tag.Query, Namespace = Namespaces.DiscoInfo)]
    public class Info : XmppXElement
    {
        #region << Constructors >>
        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        public Info()
            : base(Namespaces.DiscoInfo, Tag.Query)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public Info(string node)
            : this()
        {
            Node = node;
        }
        #endregion

        /// <summary>
        /// Optional node Attrib
        /// </summary>
        public string Node
        {
            get { return GetAttribute("node"); }
            set { SetAttribute("node", value); }
        }


        /// <summary>
        /// Adds a identity.
        /// </summary>
        /// <returns></returns>
        public Identity AddIdentity()
        {
            var id = new Identity();
            Add(id);            
            return id;
        }

        /// <summary>
        /// Adds a identity.
        /// </summary>
        /// <param name="id">The id.</param>
        public void AddIdentity(Identity id)
        {
            Add(id);
        }

        /// <summary>
        /// Adds a feature.
        /// </summary>
        /// <returns></returns>
        public Feature AddFeature()
        {
            var feat = new Feature();
            Add(feat);
            
            return feat;
        }

        /// <summary>
        /// Adds a feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        public void AddFeature(Feature feature)
        {
            Add(feature);
        }

        /// <summary>
        /// Gets the identities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Identity> GetIdentities()
        {         
            return Elements<Identity>();            
        }

        /// <summary>
        /// Gets all Features
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Feature> GetFeatures()
        {
            return Elements<Feature>();
        }

        /// <summary>
        /// Check if a feature is supported
        /// </summary>
        /// <param name="var">The var.</param>
        /// <returns>
        /// 	<c>true</c> if the specified feature exists; otherwise, <c>false</c>.
        /// </returns>
        public bool HasFeature(string var)
        {
            return GetFeatures().Any(feat => feat.Var == var);
        }

        /// <summary>
        /// Gets all XData Froms
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Data> GetDataForms()
        {
            return Elements<Data>();
        }

        /// <summary>
        /// Add a xdata form
        /// </summary>
        /// <param name="form"></param>
        public void AddDataForm(Data form)
        {
            Add(form);
        }

        #region << Extension Properties >>
        /// <summary>
        /// Gets or sets the Xdata object.
        /// </summary>
        /// <value>The X data.</value>
        public Data XData
        {
            get { return Element<Data>(); }
            set { Replace(value); }
        }
        #endregion
    }
}