using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //create a new client instance 
            ResidentialStandsAPI myAPI = new ResidentialStandsAPI("http://127.0.0.1:8000/api/");
            Console.WriteLine(await myAPI.deleteStand("19 Calway St Jakaranda Gwanda"));
        }

    }

    public class ResidentialStandsAPI{

        private HttpClient client ;
        private string url ;

        public ResidentialStandsAPI(string url){
            this.client = new HttpClient();
            this.url = url;
        }

        public async System.Threading.Tasks.Task<string> checkGatewayAsync(){
           using (HttpResponseMessage responce = await client.GetAsync(this.url+"gateway/")){
               return await responce.Content.ReadAsStringAsync();
           }
        }

        public async System.Threading.Tasks.Task<string> getAllStands(){
            using (HttpResponseMessage responce = await client.GetAsync(this.url+"getAllStands/")){
               return await responce.Content.ReadAsStringAsync();
           }
        }

        public async System.Threading.Tasks.Task<string> deleteStand(string address){
            IEnumerable<KeyValuePair<string,string>> data = new List<KeyValuePair<string,string>>(){
                new KeyValuePair<string,string>("address",address),
            };

            HttpContent dataToParse = new FormUrlEncodedContent(data)
            ;
            using (HttpResponseMessage responce = await client.PostAsync(this.url+"deleteStand/",dataToParse)){
               return await responce.Content.ReadAsStringAsync();
           }
        }

        public async System.Threading.Tasks.Task<string> addUser(string username,string password){
            IEnumerable<KeyValuePair<string,string>> data = new List<KeyValuePair<string,string>>(){
                new KeyValuePair<string,string>("username",username),
                new KeyValuePair<string,string>("password",password),
            };

            HttpContent dataToParse = new FormUrlEncodedContent(data)
            ;
            using (HttpResponseMessage responce = await client.PostAsync(this.url+"addUser/",dataToParse)){
               return await responce.Content.ReadAsStringAsync();
           }
        }

        public async System.Threading.Tasks.Task<string> Authenticate(string username,string password){
            IEnumerable<KeyValuePair<string,string>> data = new List<KeyValuePair<string,string>>(){
                new KeyValuePair<string,string>("username",username),
                new KeyValuePair<string,string>("password",password),
            };

            HttpContent dataToParse = new FormUrlEncodedContent(data)
            ;
            using (HttpResponseMessage responce = await client.PostAsync(this.url+"authenticate/",dataToParse)){
               return await responce.Content.ReadAsStringAsync();
           }
        }
    }

}



