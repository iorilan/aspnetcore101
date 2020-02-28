namespace DIWithAutofac
{
    public class GreetingService2 : IGreetingService
    {
        public string Greet(string name) {
            var greet = "";
            var h = System.DateTime.Now.Hour;
            if(h < 12){
                greet = "Morning";
            }
            else if(h >= 12 && h < 18){
                greet = "Afternoon";
            }
            else{
                greet = "Evening";
            }
            return $"{greet}, {name}";
        } 
    }
}
