using HeyCurator_MVC.Models;

namespace HeyCurator_MVC.ViewModels
{
    public class AddItemInStorageViewModel
    {
        public int ItemId { get; set; }
        public int StorageId { get; set; }
        public int StorageCount { get; set; }
        public int ExhibitId { get; set; }

        public AddItemInStorageViewModel()
        {
            ItemInStorage item = new ItemInStorage();
            Storage storage = new Storage();
        }

    }
}
