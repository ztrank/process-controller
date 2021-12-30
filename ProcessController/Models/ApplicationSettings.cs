using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProcessController.Models
{
    public class ApplicationSettings
    {
        [JsonIgnore]
        public bool PendingChanges
        {
            get
            {
                return false;
            }
        }


        public void MarkSaved()
        {
            
        }

        public ApplicationSettings Clone()
        {
            return new ApplicationSettings();
        }
    }
}
