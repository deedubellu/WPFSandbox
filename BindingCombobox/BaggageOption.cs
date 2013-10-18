namespace FlightCentre.TudFaregateProvider.Common
{
    
    public class BaggageOption
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int AllowedPieces { get; set; }
        public string Key { get; set; }

        public decimal MaxWeight { get; set; }

        //HACK: I couldn't get the baggage combobox to display the description of the selected item. Instead it just displays the string representation (ToString())
        public override string ToString()
        {
            return Description;
        }
    }
}