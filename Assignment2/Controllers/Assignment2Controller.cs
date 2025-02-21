using System.Diagnostics;
using System.Numerics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Assignment2Controller : ControllerBase
    {
        /// <summary>
        /// This is a robot game for delivering packages while avoding obstacles, at the end of the game it retuens the score for the number of deliveries made.
        /// </summary>
        /// <param name="collisions">It takes the input of collisions Occurred.</param>
        /// <param name="deliveries">It takes the input of deliveries made.</param>
        /// <returns>
        /// It returns the final score for the successful delivery of packages.
        /// </returns>
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// POST DATA/FORM DATA/REQUEST BODY: Collisions=2&Deliveries=5
        /// <example>
        /// POST:https://localhost:7090/api/J1/Delivedriod-> 730
        /// </example>
        /// POST DATA/FORM DATA/REQUEST BODY: Collisions=10&Deliveries=0
        /// <example>
        /// POST:https://localhost:7090/api/J1/Delivedriod-> -100
        /// </example>   
        /// POST DATA/FORM DATA/REQUEST BODY: Collisions=3&Deliveries=2
        /// <example>
        /// POST:https://localhost:7090/api/J1/Delivedriod-> 70
        /// </example>

        [HttpPost(template:"/api/J1/Delivedriod")]
        [Consumes("application/x-www-form-urlencoded")]
        public int Delivedriod([FromForm]int Collisions,[FromForm]int Deliveries)
        {
            int total=0;
            if (Deliveries > Collisions)
            {
                total += 500;
            }
            if (Deliveries > 0)
            {
                total += Deliveries * 50;
            }
            if (Collisions > 0)
            {
                total -= Collisions * 10;
            }
            return total;
        }
        /// <summary>
        /// This is a robot game for delivering packages while avoding obstacles, at the end of the game it retuens the score for the number of deliveries made.
        /// </summary>
        /// <param name="redplate">It takes the cost of redplate sushi.</param>
        /// <param name="greenplate">It takes the cost of green plate sushi.</param>
        /// <param name="blueplate">It takes the cost of blue plate sushi.</param>
        /// <returns>
        /// It returns the final score for the successful delivery of packages.
        /// </returns>
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// POST DATA/FORM DATA/REQUEST BODY: redplate=0&greenplate=2&blueplate=4
        /// <example>
        /// POST:https://localhost:7090/api/J1/mealcost-> 28
        /// </example>
        /// POST DATA/FORM DATA/REQUEST BODY: redplate=3&greenplate=2&blueplate=1
        /// <example>
        /// POST:https://localhost:7090/api/J1/mealcost-> 22
        /// </example>
        /// POST DATA/FORM DATA/REQUEST BODY: redplate=6&greenplate=9&blueplate=0
        /// <example>
        /// POST:https://localhost:7090/api/J1/mealcost-> 22
        /// </example>

        [HttpPost(template: "/api/J1/mealcost")]
        [Consumes("application/x-www-form-urlencoded")]
        public int Mealcost([FromForm] int redplate, [FromForm] int greenplate, [FromForm] int blueplate)
        {
            int redsushi = 3;
            int greensushi = 4;
            int bluesushi = 5;
            int total = (redplate*redsushi)+(greenplate*greensushi)+(blueplate*bluesushi);
            return total;
        }
        /// <summary>
        /// To find the Dusa's size after eating Yobi's of smaller than its size. Dusa run  away if it finds Yobi's of similar too its size or larger.
        /// </summary>
        /// <param name="inputsize">It takes the input sizes of Dusa and Yobi's of different sizes</param>
        /// <returns>
        /// It returns the final size of Dusa after eating Yobi's of smaller than it's size.
        /// </returns>
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// POST DATA/FORM DATA/REQUEST BODY: inputsize=5&inputsize=3&inputsize=2&inputsize=9&inputsize=20&inputsize=22&inputsize=14
        /// <example>
        /// POST:https://localhost:7090/api/J2/size-> 19
        /// </example>
        /// POST DATA/FORM DATA/REQUEST BODY: inputsize=10&inputsize=10&inputsize=3&inputsize=5
        /// <example>
        /// POST:https://localhost:7090/api/J2/size-> 10
        /// </example>
 
        [HttpPost(template:"/api/J2/size")]
        [Consumes("application/x-www-form-urlencoded")]
        public int Size([FromForm] List<int> inputsize)
        {
            int totalsize = inputsize[0];
            for (int i = 1; i < inputsize.Count; i++)
            {
                Debug.WriteLine($"list item is { inputsize[i]}");
                
                if (inputsize[i]<totalsize)
                {
                    totalsize += inputsize[i];
                    Debug.WriteLine($"total size is {totalsize}");
                }
                else
                {
                    return totalsize;
                }
            }
            return totalsize;
        }
        /// <summary>
        /// Total Spiciness of Chillies evaluated by SHU values.
        /// </summary>
        /// <param name="ingredients">It takes the Chilli names as a string input</param>
        /// <returns>
        /// It returns the total spiciness of chillies after the adding all the SHU values of the input chillies.
        /// </returns>
        /// <example>
        /// GET:https://localhost:7090/api/J2/ChiliPeppers?ingredients=Poblano,Cayenne,Thai,Poblano-> 118000
        /// </example>
        /// GET:https://localhost:7090/api/J2/ChiliPeppers?ingredients=Habanero,Habanero,Habanero,Habanero,Habanero-> 625000
        /// <example>
        /// GET:https://localhost:7090/api/J2/ChiliPeppers?ingredients=Poblano,Mirasol,Serrano,Cayenne,Thai,Habanero,Serrano-> 278500
        /// </example>

        [HttpGet(template: "/api/J2/ChiliPeppers")]
        public int Peppers(string ingredients)
        {
            string[] ingredient = ingredients.Split(',');
            Debug.WriteLine("Items in String" + ingredient);

            Dictionary<string, int> ingredientValues = new Dictionary<string, int>()
            {
                   {"Poblano",1500},
                   {"Mirasol",6000 },
                   {"Serrano",15500 },
                   {"Cayenne",40000 },
                   {"Thai",75000 },
                   {"Habanero", 125000}
           };
            Debug.WriteLine("Values in Dictionary" + ingredientValues);
            int total = 0;

            for (int i = 0; i <ingredient.Length; i++)
            {
                Debug.WriteLine("List item is" + ingredient[i]);
                foreach (KeyValuePair<string,int> ingredientNames in ingredientValues)
                {
                    if (ingredient[i].Contains(ingredientNames.Key))
                    {
                        Debug.WriteLine("key is" + ingredientNames);
                        total += ingredientNames.Value;
                    }   
                }
            }

            return total;
        }
        /// <summary>
        /// To find the number of participants has achieved Bronze medal in a competition.
        /// </summary>
        /// <param name="values">It takes the number of participants and their scores</param>
        /// <returns>
        /// It returns the bronze medal score and number of participants received it.
        /// </returns>
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// POST DATA/FORM DATA/REQUEST BODY: values=4&values=70&values=62&values=58&values=73"
        /// <example>
        /// POST:https://localhost:7090/api/J3/bronzeMedal-> 62 1
        /// </example>
        /// POST DATA/FORM DATA/REQUEST BODY: values=8&values=75&values=70&values=60&values=70&values=70&values=60&values=75&values=70
        /// <example>
        /// POST:https://localhost:7090/api/J3/bronzeMedal-> 60 2
        /// </example>
        [HttpPost(template:"/api/J3/bronzeMedal")]
        [Consumes("application/x-www-form-urlencoded")]
        public string BronzeMedal([FromForm] List<int> values)
        {
            List<int> scores = new List<int>();
            foreach (var score in values)
            {
                if (!scores.Contains(score)) 
                { 
                scores.Add(score);
                }
            }
            scores.Sort();
            scores.Reverse();
            int bronzeValue = scores[2];
            int participants = 0;
            foreach (var score in values)
            {
                if (score == bronzeValue)
                {
                    participants++;
                }
            }

            return bronzeValue+" "+participants ;
        }
    }
}
