using System.Net.Sockets;
using System;

namespace Pretpark
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(new System.Net.IPAddress(new byte[] { 127,0,0,1 }), 5000);
            server.Start();

            int teller = 0;
            while(true)
            {
                using Socket connectie = server.AcceptSocket();
                using Stream request = new NetworkStream(connectie);
                using StreamReader requestLezer = new StreamReader(request);

                string userAgentMessage = "U gebruikt de browser: ";

                string[]? regel1 = requestLezer.ReadLine()?.Split(" ");
                if (regel1 == null) continue;
                (string methode, string url, string httpversie) = (regel1[0], regel1[1], regel1[2]);
                string? regel = requestLezer.ReadLine();
                int contentLength = 0;
                
                while (!string.IsNullOrEmpty(regel) && !requestLezer.EndOfStream)
                {
                    string[] stukjes = regel.Split(":");
                    (string header, string waarde) = (stukjes[0], stukjes[1]);
                    if (header.ToLower() == "content-length")
                        contentLength = int.Parse(waarde);
                    regel = requestLezer.ReadLine();
                    if (header.ToLower() == "user-agent")
                    {
                        string tmp = waarde;
                        string[] tmpParts = tmp.Split(" ");
                        string browser = "";
                        if(tmpParts.Length == 13)
                        {
                            browser = tmpParts[tmpParts.Length - 2];
                        } 
                        else
                        {
                            browser = tmpParts[tmpParts.Length - 1];
                        }

                        string[] browserParts = browser.Split("/");
                        switch(browserParts[0])
                        {
                            case "rv":
                                userAgentMessage += "FireFox";
                            break;
                            case "Chrome":
                                userAgentMessage += "Chrome";
                            break;
                            case "OPR":
                                userAgentMessage += "Opera";
                            break;
                            case "Edg":
                                userAgentMessage += "Microsoft Edge";
                            break;
                            default:
                                userAgentMessage += "Unknown";
                            break;
                        }
                    }
                }
                if (contentLength > 0)
                {
                    char[] bytes = new char[(int)contentLength];
                    requestLezer.Read(bytes, 0, (int)contentLength);
                }
                string message = "";
                int messageSize = 0;
                bool correctURL = false;
                
                if(url == "/")
                {
                    correctURL = true;
                    message = "<p>Welkom bij de website van Pretpark <a href=\"https://nl.wikipedia.org/wiki/Den_Haag\">Den Haag!</a></p><br>" + userAgentMessage;
            
                    messageSize = message.Length;
                }
                else if(url == "/contact")
                {
                    correctURL = true;
                    message = "<p>Een andere webpagina</p>";
            
                    messageSize = message.Length;
                }
                else if(url == "/teller")
                {
                    correctURL = true;
                    teller++;
                    message = teller.ToString();
            
                    messageSize = message.Length;
                }
                else if(url.StartsWith("/add?"))
                {
                    correctURL = true;
                    string tempString = url.Substring(5);

                    int ?a = null;
                    int ?b = null;

                    if(Int32.TryParse(tempString.Substring(2, tempString.Length-6), out int _a))
                    {
                        a = _a;
                    }

                    if(Int32.TryParse(tempString.Substring(6), out int _b))
                    {
                        b = _b;
                    }
                    
                    if (a != null && b != null)
                    {
                        int ?c =  a + b;
                        message = "Antwoord = " + c;
                    }
                    else
                    {
                        message = "Er is iets fout gegaan";
                    }
            
                    messageSize = message.Length;
                }
                else if(url == "/mijnteller")
                {
                    correctURL = true;
                    int mijnteller = 1;
                    int nextTeller = 2;

                    message = "Uw teller = " + mijnteller + " klik <a href=\"http://localhost:5000/mijnteller?a=" + nextTeller + "\">hier</a> om er 1 bij op te tellen";
            
                    messageSize = message.Length;
                }
                else if(url.StartsWith("/mijnteller?"))
                {
                    correctURL = true;
                    string tempString = url.Substring(14);
                    int ?mijnteller = null;

                    if(Int32.TryParse(tempString, out int _a))
                    {
                        mijnteller = _a;
                    }

                    if(mijnteller != null)
                    {
                        int ?nextTeller = mijnteller + 1;
                        message = "Uw teller = " + mijnteller + " klik <a href=\"http://localhost:5000/mijnteller?a=" + nextTeller + "\">hier</a> om er 1 bij op te tellen";
            
                        messageSize = message.Length;
                    }
                    else
                    {
                        message = "Er is iets fout gegaan";
                    }
                }
                
                if(correctURL)
                {
                    connectie.Send(System.Text.Encoding.ASCII.GetBytes("HTTP/1.0 200 OK\r\nContent-Type: text/html\r\nContent-Length: " + messageSize +"\r\n\r\n" + message + ""));
                }
                else
                {
                    connectie.Send(System.Text.Encoding.ASCII.GetBytes("HTTP/1.0 404 OK\r\nContent-Type: text/html\r\nContent-Length: " + messageSize +"\r\n\r\n" + message + ""));
                }
            }
        }
    }
}
