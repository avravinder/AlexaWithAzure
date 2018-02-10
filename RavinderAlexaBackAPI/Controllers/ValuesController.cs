using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Alexa.NET;
using Alexa.NET.Request.Type;


// Functonality - This will parse and then get the ingredients for each item .

namespace RavinderAlexaBackAPI.Controllers
{
 // [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        
        // POST api/values
      //  [Authorize]
        [HttpPost]

        // This is the method that is being invoked. This is the main method that will parse the intent and generate the result. 
        public SkillResponse Post([FromBody]SkillRequest request)
        {

            SkillResponse response = null;
            if(request !=null)
            {
                PlainTextOutputSpeech outputSpeech = new PlainTextOutputSpeech();
                string Item = (request.Request as IntentRequest)?.Intent.Slots.FirstOrDefault(s=> s.Key == "Item").Value.Value.ToString();
               if (Item.ToUpper()  == "Bread".ToUpper() )
                { outputSpeech.Text = Item + " Ingredients are wheat flour , water"; }

                else if (Item.ToUpper() == "Cookie".ToUpper())
                {
                    outputSpeech.Text = Item + " Ingredients are flour ,Sugar, Egg and vanilla";
                }
                else if (Item.ToUpper() == "Sandwich".ToUpper())
                {
                    outputSpeech.Text = Item + " Ingredients are Bread, Lettuce, Tomato";
                }
                else if (Item.ToUpper() == "Biryani".ToUpper())
                {
                    outputSpeech.Text = Item + " Ingredients are Rice, Vegetable, Spices";
                }
                else
                {
                    outputSpeech.Text = " I am not an expert at cooking " + Item + " but i am learning. Will let you know in a few Hours.";

                }

             response = ResponseBuilder.Tell(outputSpeech);
                
             
            }
            return response;
        }
            
              
    }
}
