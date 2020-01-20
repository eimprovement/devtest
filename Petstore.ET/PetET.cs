using System;

namespace Petstore.ET
{
    public class PetET
    {
        public long id { get; set; }
        public CategoryET category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public TagET[] tags { get; set; }
        public string status { get; set; }
    }


}



 