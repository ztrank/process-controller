using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProcessController.Models
{
    /// <summary>
    /// User created watcher to monitor processes
    /// </summary>
    public class Watcher
    {
        /// <summary>
        /// Internal Process list
        /// </summary>
        [JsonIgnore]
        private List<Process> processes;

        /// <summary>
        /// Gets or sets the Watcher's Name
        /// </summary>
        /// <remarks>
        /// The Name is a unique value to identify a watcher
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Process Name
        /// </summary>
        /// <remarks>
        /// This is the name that will be used in the GetProcessByName method to retrieve the running process information
        /// </remarks>
        public string ProcessName { get; set; }

        /// <summary>
        /// Gets or sets the Order
        /// </summary>
        public int Order { get; set; }

        [JsonIgnore]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the list of running processes
        /// </summary>
        [JsonIgnore]
        public List<Process> Processes
        {
            get
            {
                if (this.processes == null)
                {
                    this.processes = new List<Process>();
                }

                return this.processes;
            }

            set
            {
                if (this.processes == null)
                {
                    this.processes = value;
                }
                else
                {
                    this.processes.Clear();
                    this.processes.AddRange(value);
                }
            }
        }
    }
}
