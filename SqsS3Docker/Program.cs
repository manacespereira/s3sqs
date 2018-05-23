using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqsS3Docker
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sqsHelper = new SQSHelper("AKIAIRJXFRCBKAQ55WSA", "lPDJrZBUjnNdJsIkcshavciTOiibbaMzBh03MqBh", RegionEndpoint.SAEast1);

            sqsHelper.CreateQueue("TESTEQUEUE").Wait();

            var a = sqsHelper.GetQueue().Result;

            sqsHelper.SendMessage(a.QueueUrls.First(), $"{DateTime.Now.ToString()}").Wait();

            var messages = sqsHelper.GetAllMessages(a.QueueUrls.First()).Result;
        }
    }
}
