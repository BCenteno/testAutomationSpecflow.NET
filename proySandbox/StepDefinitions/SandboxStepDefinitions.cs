using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MyteSpecFlowAutomation.Fortification.Steps
{
    [Binding]
    public class TJSteps
    {
        Table dataTable = new Table(new string[] {"dummy header"});
        Table TA = new Table(new string[] { "dummy header" });
        Table TB = new Table(new string[] { "dummy header" });
        JObject JsonA = new JObject();


        //--------------------------------------------------------------------------------

        [When(@"I load the following data")]
        public void WhenILoadTheFollowingData(Table table)
        {
            dataTable = table;
        }

        [Then(@"""([^""]*)"" es un ""([^""]*)""")]
        public void ThenEsUn(string nombreE, string mascotaE)
        {
            var row = dataTable.Rows.FirstOrDefault(x => x["nombre"] == nombreE);


            if (row == null)
            {
                Assert.Fail($"el nombre {nombreE} no está en la tabla");
            };

            if (row["mascota"] != mascotaE)
            {
                Assert.Fail($"los tipos no coinciden, el verdadero tipo de {nombreE} es {row["mascota"]}");
            };
        }



        [When(@"I load TA")]
        public void WhenILoadTA(Table table)
        {
            TA = table;
        }

        [When(@"I load TB")]
        public void WhenILoadTB(Table table)
        {
            TB = table;
        }

        [Then(@"""([^""]*)"" compra ""([^""]*)""")]
        public void ThenCompra(string expectedAmo, string expectedComida)
        {   //refactorar FirstOrDefault
            TableRow? rowTA = TA.Rows.FirstOrDefault(x => x["Amo"] == expectedAmo);
            if (rowTA == null)
            {
                Assert.Fail($"el Amo {expectedAmo} no está en la tabla");
            };

            string mascota = rowTA["mascota"];
            var rowTB = TB.Rows.FirstOrDefault(x => x["mascota"] == mascota);
            if (rowTB == null)
            {
                Assert.Fail($"la comida {expectedComida} no está en la tabla");
            };

            string actualComida = rowTB["comida"];
            if (actualComida != expectedComida)
            {
                Assert.Fail($"{expectedComida} no es la comida la correcta, {expectedAmo} debería comprar {actualComida}");
            };

        }

        

        [Then(@"the json is created")]
        public void ThenTheJsonIsCreated()
        {
            JArray arrayA = new JArray();
            foreach(TableRow row in TA.Rows)
            {
                bool existe = arrayA.Any(x => x["Amo"].ToString() == row["Amo"]);

                if (existe)
                {                           //cast
                    JObject AmoEncontrado = (JObject)arrayA.First(x => x["Amo"].ToString() == row["Amo"]);
                    ((JArray)AmoEncontrado["Telefonos"]).Add(row["telefono"]);
                    //a pesar de ya ser un JArray hubo que castear de todos modos para que funcione
                }
                else
                {
                    JObject newJO = new()
                    {
                        {"Amo",row["Amo"]},
                        {"Telefonos",new JArray {row["telefono"]}}
                    };
                    arrayA.Add(newJO);
                };
            };
            Console.WriteLine("aqui esperAmos");

        }

        /* -------------------------------------NEW ACTIVITY------------------------------------- */
        /* -------------------------------------NEW ACTIVITY------------------------------------- */
        /* -------------------------------------NEW ACTIVITY------------------------------------- */
        /* -------------------------------------NEW ACTIVITY------------------------------------- */
        /* -------------------------------------NEW ACTIVITY------------------------------------- */



    }
}
