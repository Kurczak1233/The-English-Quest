using System.Collections.Generic;
using The_quest_of_English.Models;

namespace The_quest_of_English
{
    public class PlacementTestPointsAndPlacementTestTasksViewModel
    {
        public string Points{ get; set; }
        public IEnumerable<PlacementTestTaskViewModel> Tasks{ get; set; }
    }
}
