using System.ComponentModel.DataAnnotations.Schema;
using TelegramParse.Data.Enum;

namespace TelegramParse.Entity
{
    public class Vacancies
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey(nameof(AppUser))]
        public long AppUserId {  get; set; }
        public AppUser? AppUser { get; set; }
        [ForeignKey(nameof(City))]
        public int CityId {  get; set; }
        public City? City { get; set; }
        public ITPosition position { get; set; }
    }
}
