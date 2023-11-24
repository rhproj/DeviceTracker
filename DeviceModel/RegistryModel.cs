using System.ComponentModel.DataAnnotations;

namespace DeviceModel
{
    public class RegistryModel
    {
        public int Number { get; init; }
        [Required]
        public string UserInfo { get; init; }
        [Required(AllowEmptyStrings =true)]
        public string DeviceName { get; init; }
        [Required]
        public string DeviceID { get; init; }
    }
}