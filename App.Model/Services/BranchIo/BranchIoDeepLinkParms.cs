using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Services.BranchIo
{
    /// <summary>
    /// Represents the branch io deep link create params
    /// </summary>
    public class BranchIoDeepLinkParms
    {
        /// <summary>
        /// Gets or sets the branch api key
        /// </summary>
        public string branch_key { get; set; }
        /// <summary>
        /// Gets or sets the channel
        /// </summary>
        public string channel { get; set; }
        /// <summary>
        /// Gets or sets the feature
        /// </summary>
        public string feature { get; set; }
        /// <summary>
        /// Gets or sets the campain
        /// </summary>
        public string campaign { get; set; }
        /// <summary>
        /// Gets or sets the stage
        /// </summary>
        public string stage { get; set; }
        /// <summary>
        /// Gets or sets the tags
        /// </summary>
        public List<string> tags { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="linkData"/> of the link
        /// </summary>
        public linkData data { get; set; }

    }

    /// <summary>
    /// Represents a branch io link data
    /// </summary>
    public class linkData
    {
        /// <summary>
        /// Gets or sets the canonical_identifier
        /// </summary>
        public string canonical_identifier { get; set; }
        /// <summary>
        /// Gets or sets the canonical_identifier
        /// </summary>
        public string og_title { get; set; }
        /// <summary>
        /// Gets or sets the canonical_identifier
        /// </summary>
        public string og_description { get; set; }
        /// <summary>
        /// Gets or sets the canonical_identifier
        /// </summary>
        public string og_image_url { get; set; }
        /// <summary>
        /// Gets or sets the canonical_identifier
        /// </summary>
        public string desktop_url { get; set; }
        /// <summary>
        /// Gets or sets the custom_boolean
        /// </summary>
        public string custom_boolean { get; set; }
        /// <summary>
        /// Gets or sets the custom_integer
        /// </summary>
        public string custom_integer { get; set; }
        /// <summary>
        /// Gets or sets the custom_string
        /// </summary>
        public string custom_string { get; set; }
        /// <summary>
        /// Gets or sets the stage
        /// </summary>
        public string stage { get; set; }
        /// <summary>
        /// Gets or sets the path
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="linkSubData"/>
        /// </summary>
        public linkSubData data { get; set; }

    }
    /// <summary>
    /// represents a branch io link sub data
    /// </summary>
    public class linkSubData
    {
        /// <summary>
        /// Gets or sets the sharing identifier
        /// </summary>
        public string SharingIdentifier { get; set; }

    }
}
