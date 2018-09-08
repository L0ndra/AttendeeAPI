using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;

#if MOBILE
using System.Windows.Input;
#endif

namespace Conference.DataObjects
{
    public class Session: BaseTableEntity
    {
        public Session() {
            this.Speakers = new List<Speaker>();
        }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the short title that is displayed in the navigation bar
        /// For instance "Intro to X.Forms"
        /// </summary>
        /// <value>The short title.</value>
        public string ShortTitle { get; set; }

        /// <summary>
        /// Gets or sets the abstract.
        /// </summary>
        /// <value>The abstract.</value>
        public string Abstract { get; set; }

        /// <summary>
        /// Gets or sets the speakers.
        /// </summary>
        /// <value>The speakers.</value>
        public virtual ICollection<Speaker> Speakers { get; set; }
        
        public IEnumerable<string> SpeakersIds { get; set; }

        /// <summary>
        /// Gets or sets the room.
        /// </summary>
        /// <value>The room.</value>
        public virtual Room Room { get; set; }
        
        public string RoomId { get; set; }

        /// <summary>
        /// Gets or sets the main category.
        /// </summary>
        /// <value>The main category.</value>
        public virtual Category MainCategory { get; set; }
        
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        public DateTime? EndTime { get; set; }

    }
}