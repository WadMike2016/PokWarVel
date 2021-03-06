namespace MarvelApi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventLists
    {
      
    
        public int id { get; set; }
        public int available { get; set; }
        public int returned { get; set; }
        public string collectionURI { get; set; }
        public int? items_id { get; set; }
    
        
        public  List<EventSummaries> EventSummaries { get; set; }
        
        public  List<Characters> Characters { get; set; }
    }
}
