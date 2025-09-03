namespace AP2.S2023A2Console
{
    public class ComeLeave
    {
        // private fields
        private DateTime date => new DateTime(JsonDate, JsonTime);
        private int comeInOut;
        private int noPeople;

        // getter methods
        public DateTime getDate()
        {
            return date;
        }

        public int getComeInOut()
        {
            return comeInOut;
        }

        public int getNoPeople()
        {
            return noPeople;
        }


        // separate json serialize properties to use mock.json
        // -> they needed to be public, so it does not match the exercise requirements
        public DateOnly JsonDate { get; set; }         // mockaroo does not allow to set a timespan in DateTime type
        public TimeOnly JsonTime { get; set; }         // therefore date and time are separate values in the mock.json
        
        public int JsonComeInOut 
        { 
            get => comeInOut; 
            set { comeInOut = value; } 
        }
        
        public int JsonNoPeople 
        { 
            get => noPeople; 
            set { noPeople = value; } 
        }
    }
}
